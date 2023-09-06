using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Xceed.Grid;
using Xceed.Grid.Editors;
using System.ComponentModel;
using System.Drawing.Drawing2D;

/*
 * CLASS SUMMARY:	CustomXceedGridControl
 * 
 * CustomXceedGridControl is a helper class for the XceedGridControl.  It contains common functionality and
 * styling used by the grid within the application.
 * 
 */

namespace TLIConfiguration
{
	public delegate Boolean RowConditionCheck(Xceed.Grid.DataRow dataRow);
	public delegate void ResetDataMemberDelegate(string dataMember);
	public delegate void UpdateDataMemberDelegate(string dataMember);
	public delegate DataTable FillDataMemberDelegate(string dataMember);

	#region RowCondition
	public class RowCondition
	{
		private System.Drawing.Color backColor;
		private RowConditionCheck rowConditionCheck;

		public RowCondition(System.Drawing.Color backColor, RowConditionCheck rowConditionCheck)
		{
			this.backColor = backColor;
			this.rowConditionCheck = rowConditionCheck;
		}

		public Boolean SetRowBackColor(Xceed.Grid.DataRow dataRow)
		{
			if (rowConditionCheck(dataRow))
			{
				dataRow.BackColor = backColor;
				return true;
			}
			return false;
		}

		public void SetColor(Color backColor)
		{
			this.backColor = backColor;
		}


		// Locate and select the next row satisfying the rowconditioncheck
		public Xceed.Grid.DataRow NextRow(GridControl gridControl)
		{
			// grid is empty, nothing to do
			if (gridControl.DataRows == null || gridControl.DataRows.Count == 0)
				return null;

			Xceed.Grid.DataRow dataRow = gridControl.CurrentRow as Xceed.Grid.DataRow;
			// No current row, or not a DataRow
			if (dataRow == null)
				dataRow = gridControl.DataRows[0];

			int startIndex = dataRow.Index;
			for (int i = startIndex + 1; i % gridControl.DataRows.Count != startIndex; i++)
			{
				dataRow = gridControl.DataRows[i % gridControl.DataRows.Count];

				if (dataRow.Visible && rowConditionCheck(dataRow))
				{
					gridControl.CurrentRow = dataRow;
					gridControl.SelectedRows.Clear();
					gridControl.SelectedRows.Add(dataRow);
					dataRow.BringIntoView();
					return dataRow;
				}
			}

			return dataRow;
		}
	}
	#endregion


	public class CustomXceedGridControl : Xceed.Grid.GridControl
	{
		private const string InsertedRowColumn = "IsInserted";
		private const string UpdatedRowColumn = "IsUpdated";
		private const string DeletedRowColumn = "IsDeleted";

		private Color insertedRowColor;
		private Color updatedRowColor;
		private Color deletedRowColor;

		private RowCondition insertedRowCondition;
		private RowCondition updatedRowCondition;
		private RowCondition deletedRowCondition;

		private IList rowConditions;

		private ResetDataMemberDelegate resetDataMemberDelgate;
		private UpdateDataMemberDelegate updateDataMemberDelegate;
		private FillDataMemberDelegate fillDataMemberDelegate;

		public VisualGridElementStyle dataRowStyle1;
		public VisualGridElementStyle dataRowStyle2;

		public VisualGridElementStyle headerRowStyle1;

		private Column expandToFitColumn;
		private int expandToFitColumnInitialWidth;

		private bool allowDelete;

		public CustomXceedGridControl()
		{
			allowDelete = true;
		}

		public void SetupGridControl()
		{
			rowConditions = new ArrayList();

			// Add columns to track the state of edits
			AddUnboundColumn(InsertedRowColumn, typeof(bool));
			AddUnboundColumn(UpdatedRowColumn, typeof(bool));
			AddUnboundColumn(DeletedRowColumn, typeof(bool));

			// Initialize default colors
			insertedRowColor = System.Drawing.Color.LimeGreen;
			updatedRowColor = System.Drawing.Color.Yellow;
			deletedRowColor = System.Drawing.Color.Red;

			// Create row conditions and add them to RowCondition arraylist
			insertedRowCondition = new RowCondition(insertedRowColor, IsRowInserted);
			rowConditions.Add(insertedRowCondition);

			updatedRowCondition = new RowCondition(updatedRowColor, IsRowUpdated);
			rowConditions.Add(updatedRowCondition);

			deletedRowCondition = new RowCondition(deletedRowColor, IsRowDeleted);
			rowConditions.Add(deletedRowCondition);

			// Add event handlers when rows are added to the grid
			this.AddingDataRow += new AddingDataRowEventHandler(CustomXceedGridControl_AddingDataRow);
			this.InitializingNewDataRow += new InitializingNewDataRowEventHandler(CustomXceedGridControl_InitializingNewDataRow);

			// Add custom paint handlers for the status of rows
			this.DataRowTemplate.Paint += new GridPaintEventHandler(DataRowTemplate_Paint);

			// This is to auto-assign database delegates
			this.DataSourceChanged += new EventHandler(CustomXceedGridControl_DataSourceChanged);

			// This is to catch the 'Delete' key to mark a row deleted.
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(CustomXceedGridControl_KeyDown);

			// Apply DataRow Styles
			dataRowStyle1 = new Xceed.Grid.VisualGridElementStyle();
			dataRowStyle1.BackColor = Color.FromArgb(237, 243, 254);

			dataRowStyle2 = new Xceed.Grid.VisualGridElementStyle();
			dataRowStyle2.BackColor = Color.White;

			headerRowStyle1 = new Xceed.Grid.VisualGridElementStyle();
			headerRowStyle1.BackColor = Color.White;

			DataRowTemplateStyles.Add(dataRowStyle1);
			DataRowTemplateStyles.Add(dataRowStyle2);

			// Use these delegates if not using a datatable
			resetDataMemberDelgate = null;
			updateDataMemberDelegate = null;
			fillDataMemberDelegate = null;

			expandToFitColumn = null;

			// Default to single row selection mode
			this.SelectionMode = SelectionMode.One;
		}


		public Column ExpandToFitColumn
		{
			get { return expandToFitColumn; }
			set
			{
				expandToFitColumn = value;
				if (expandToFitColumn != null)
					expandToFitColumnInitialWidth = expandToFitColumn.Width;

				if (this.DesignMode == false)
					if (expandToFitColumn != null)
						ExpandColumn(expandToFitColumn, expandToFitColumnInitialWidth);
			}
		}

		/// <summary>
		/// Ensures the last column is expanded on the grid to fill the DisplayRectangle when the grid is resized.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>        

		protected override void OnResize(EventArgs e)
		{
			if (this.Parent != null && this.Parent.Disposing)
				return;

			try
			{
				if (this.DesignMode == false)
					if (expandToFitColumn != null)
						ExpandColumn(expandToFitColumn, expandToFitColumnInitialWidth);
			}
			catch { }

			base.OnResize(e);
		}


		void CustomXceedGridControl_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete && CurrentCell.IsBeingEdited == false)
				DeleteSelectedRows();
		}


		public void DeleteSelectedRows()
		{
			if (allowDelete)
			{
				for (int i = SelectedRows.Count - 1; i >= 0; i--)
				{
					Xceed.Grid.DataRow dataRow = null;
					dataRow = SelectedRows[i] as Xceed.Grid.DataRow;

					if (dataRow != null)
					{
						if (DialogResult.Yes == MessageBox.Show("Are you sure that you want to delete this row?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
						{
							BeginInit();
							dataRow.CancelEdit();
							dataRow.Remove();
							EndInit();
						}
					}
				}
			}
		}


		void CustomXceedGridControl_DataSourceChanged(object sender, EventArgs e)
		{
			if (this.Disposing)
				return;

			if (this.Parent != null && this.Parent.Disposing)
				return;

			SetDatabaseDelegates();
		}

		public void SetDatabaseDelegates()
		{
			//if (DataSource != null && DataSource is Database)
			//{
			//    Database database = DataSource as Database;
			//    resetDataMemberDelgate = database.ResetTable;
			//    updateDataMemberDelegate = database.UpdateDataTable;
			//    fillDataMemberDelegate = database.FillDataTable;
			//}
			
			if (DataSource != null && DataSource is GridDataTable)
			{
				GridDataTable dataTable = DataSource as GridDataTable;
				resetDataMemberDelgate = dataTable.Reset;
				updateDataMemberDelegate = dataTable.Update;
				fillDataMemberDelegate = dataTable.Fill;
			}
		}

		/// <summary>
		/// Hides columns that are not specified in the wantedColumns array from being displayed in the grid.
		/// The grid will show these columns by default even if AddBoundColumn is called.  The result is that a field
		/// added to a usp_GetXXX stored procedure will cause a new, potentially unwanted column to appear in the grid.
		/// Including this call after setting up the grid will prevent any new columns from appearing at runtime.
		/// </summary>
		/// <param name="grid">The grid</param>
		/// <param name="wantedColumns">List of columns that should be displayed</param>
		public void HideUnwantedGridColumns(string[] wantedColumns)
		{
			int i;

			foreach (Xceed.Grid.Column column in Columns)
			{
				for (i = 0; i < wantedColumns.Length; ++i)
					if (column.FieldName == wantedColumns[i])
						break;

				if (i == wantedColumns.Length)
					column.Visible = false;
			}
		}

		/// <summary>
		/// Generic helper for enforcing non-blank values in cells, usually used during InsertionRow_EndingEdit
		/// </summary>
		/// <param name="cell">Cell to check</param>
		/// <param name="sFieldText">Friendly field name to use if reporting an error condition via MessageBox</param>
		/// <param name="e">CancelEventArgs from InsertionRow_EndingEdit to allow us to cancel the edit on invalid data</param>
		public void EnforceNonBlankCell(Xceed.Grid.Cell cell, string sFieldText, CancelEventArgs e)
		{
			try
			{
				if (cell.Value == null || cell.Value == System.DBNull.Value || cell.Value.ToString() == "")
				{
					MessageBox.Show(sFieldText + " cannot be blank.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					e.Cancel = true;
				}
			}
			catch
			{
				// Just leave it, database will enforce constraints on Save, this is just a convenience
			}
		}

		public bool AllowDelete
		{
			get { return allowDelete; }
			set { allowDelete = value; }
		}

		public Color InsertedRowColor
		{
			get
			{
				return insertedRowColor;
			}
			set
			{
				insertedRowColor = value;
				if (insertedRowCondition != null)
					insertedRowCondition.SetColor(insertedRowColor);
			}
		}

		public Color UpdatedRowColor
		{
			get
			{
				return updatedRowColor;
			}
			set
			{
				updatedRowColor = value;
				if (updatedRowCondition != null)
					updatedRowCondition.SetColor(updatedRowColor);
			}
		}

		public Color DeletedRowColor
		{
			get
			{
				return deletedRowColor;
			}
			set
			{
				deletedRowColor = value;
				if (deletedRowCondition != null)
					deletedRowCondition.SetColor(deletedRowColor);
			}
		}

		public ResetDataMemberDelegate ResetDataMemberDelegate
		{
			get { return resetDataMemberDelgate; }
			set { resetDataMemberDelgate = value; }
		}

		public UpdateDataMemberDelegate UpdateDataMemberDelegate
		{
			get { return updateDataMemberDelegate; }
			set { updateDataMemberDelegate = value; }
		}

		public FillDataMemberDelegate FillDataMemberDelegate
		{
			get { return fillDataMemberDelegate; }
			set { fillDataMemberDelegate = value; }
		}

		private void DataRowTemplate_Paint(object sender, GridPaintEventArgs e)
		{
			Xceed.Grid.DataRow dataRow = sender as Xceed.Grid.DataRow;
			foreach (RowCondition rowCondition in rowConditions)
			{
				if (rowCondition.SetRowBackColor(dataRow))
				{
					return;
				}
			}
			dataRow.ResetBackColor();

			return;
		}

		public Boolean HasPendingChanges()
		{
			// Could capture appropriate events and set flag for a more efficient approach, but we are using this model to maintain
			// datasets with a small number of rows so what have you
			foreach (Xceed.Grid.DataRow row in DataRows)
				if (IsRowDeleted(row) || IsRowUpdated(row) || IsRowInserted(row))
					return true;

			return false;
		}

		public Boolean IsRowDeleted(Xceed.Grid.DataRow dataRow)
		{
			return dataRow.Cells[DeletedRowColumn].Value.Equals(true);
		}

		public Boolean IsRowUpdated(Xceed.Grid.DataRow dataRow)
		{
			return dataRow.Cells[UpdatedRowColumn].Value.Equals(true);
		}

		public Boolean IsRowInserted(Xceed.Grid.DataRow dataRow)
		{
			return dataRow.Cells[InsertedRowColumn].Value.Equals(true);
		}

		private void CustomXceedGridControl_InitializingNewDataRow(object sender, InitializingNewDataRowEventArgs e)
		{
			e.DataRow.Cells[InsertedRowColumn].Value = true;
			e.DataRow.Cells[UpdatedRowColumn].Value = false;
			e.DataRow.Cells[DeletedRowColumn].Value = false;
		}

		private void CustomXceedGridControl_AddingDataRow(object sender, AddingDataRowEventArgs e)
		{
			InitializeRowStatus(e.DataRow);

			foreach (DataCell dataCell in e.DataRow.Cells)
			{
				if (dataCell.ReadOnly == false)
				{
					dataCell.ValueChanging += new ValueChangingEventHandler(dataCell_ValueChanging);
				}

			}
		}

		void dataCell_ValueChanging(object sender, ValueChangingEventArgs e)
		{
			try
			{
				DataCell dataCell = null;
				dataCell = sender as DataCell;

				if
				(
					(dataCell.Value == null && e.NewValue == null) ||
					(dataCell.Value == DBNull.Value && e.NewValue == null) ||	// This one happens when a DBNull cell is click-edited but unchanged
					(dataCell.Value != null && e.NewValue != null && dataCell.Value.Equals(e.NewValue)))
				{
					e.Cancel = true;
				}
				else
				{
					if (dataCell.ParentRow.Cells[InsertedRowColumn].Value.Equals(false))
					{
						dataCell.ParentRow.Cells[UpdatedRowColumn].Value = true;
					}
				}
			}
			finally
			{

			}
		}

		private void InitializeRowStatus(Xceed.Grid.DataRow dataRow)
		{
			dataRow.Cells[InsertedRowColumn].Value = false;
			dataRow.Cells[UpdatedRowColumn].Value = false;
			dataRow.Cells[DeletedRowColumn].Value = false;
		}

		public Xceed.Grid.Column AddBoundColumn(string columnName)
		{
			return AddBoundColumn(columnName, null, false, true, 0);
		}

		public Column AddBoundColumn(string fieldName, string title, bool visible, bool readOnly, int width)
		{
			return AddBoundColumn(fieldName, title, visible, readOnly, width, "");
		}

		public Column AddBoundColumn(string fieldName, string title, bool visible, bool readOnly, int width, string formatSpecifier)
		{
			DataBoundColumn dataBoundColumn = null;

			dataBoundColumn = new DataBoundColumn(fieldName);
			dataBoundColumn.Title = title;
			dataBoundColumn.Visible = visible;
			dataBoundColumn.ReadOnly = readOnly;

			dataBoundColumn.Width = width;
			dataBoundColumn.NullText = "";
			dataBoundColumn.FormatSpecifier = formatSpecifier;
			Columns.Add(dataBoundColumn);

			return dataBoundColumn;
		}

		public Xceed.Grid.Column InsertBoundColumn(int index, string columnName)
		{
			return InsertBoundColumn(index, columnName, null, false, true, 0);
		}

		public Column InsertBoundColumn(int index, string fieldName, string title, bool visible, bool readOnly, int width)
		{
			DataBoundColumn dataBoundColumn = null;

			dataBoundColumn = new DataBoundColumn(fieldName);
			dataBoundColumn.Title = title;
			dataBoundColumn.Visible = visible;
			dataBoundColumn.ReadOnly = readOnly;

			dataBoundColumn.Width = width;
			dataBoundColumn.NullText = "";
			Columns.Insert(index, dataBoundColumn);

			return dataBoundColumn;
		}



		// adds a bound date-time column
		public Column AddBoundDateTimeColumn(String fieldName, String title, Boolean visible, Boolean readOnly, Int32 width)
		{
			Column col = AddBoundColumn(fieldName, title, visible, readOnly, width);
			col.FormatSpecifier = "MM/dd/yyyy HH:mm:ss";
			return col;
		}

		// adds a bound date column
		public Column AddBoundDateColumn(String fieldName, String title, Boolean visible, Boolean readOnly, Int32 width)
		{
			Column col = AddBoundColumn(fieldName, title, visible, readOnly, width);
			col.FormatSpecifier = "MM/dd/yyyy";
			if (!readOnly)
			{
				GridDateTimePicker picker = new GridDateTimePicker();
				col.CellEditor = picker;
				picker.ShowCheckBox = true;
				picker.Format = DateTimePickerFormat.Custom;
				picker.CustomFormat = "MM/dd/yyyy";
			}
			return col;
		}


		// Adds a hidden, read-only, unbound column
		public Column AddUnboundColumn(String fieldName, Type type)
		{
			return AddUnboundColumn(fieldName, type, null, false, true, 0);
		}

		// Adds an unbound column
		public Column AddUnboundColumn(string fieldName, Type type, string title, bool visible, bool readOnly, int width)
		{
			Column column = null;

			column = new Column(fieldName, type);
			column.Title = title;
			column.Visible = visible;
			column.ReadOnly = readOnly;
			column.Width = width;
			column.NullText = "";
			Columns.Add(column);

			return column;
		}

		public void ResetDataMember()
		{
			BeginInit();

			resetDataMemberDelgate(DataMember);

			foreach (Xceed.Grid.DataRow dataRow in DataRows)
			{
				InitializeRowStatus(dataRow);
			}

			EndInit();
		}

		public void FillDataMember()
		{
			if (FillDataMemberDelegate != null)
			{
				FillDataMemberDelegate(DataMember);
			}
		}

		public void UpdateDataMember()
		{
			UpdateDataMember(false);
		}

		public void UpdateDataMember(bool refill)
		{
			BeginInit();

			try
			{
				// end cell editing, to commit value
				if (CurrentCell is DataCell)
				{
					Xceed.Grid.DataRow dataRow;
					dataRow = CurrentRow as Xceed.Grid.DataRow;
					dataRow.EndEdit();
				}

				// The grid will not allow removal of items in the enumerated collection, so we'll
				// have to build a separate list of deletions and call Remove() on each
				ArrayList deletions = null;
				deletions = new ArrayList();
				foreach (Xceed.Grid.DataRow dataRow in DataRows)
				{
					if (IsRowDeleted(dataRow))
					{
						deletions.Add(dataRow);
					}
				}
				foreach (Xceed.Grid.DataRow dataRow in deletions)
				{
					dataRow.Remove();
				}

				// update the database
				updateDataMemberDelegate(DataMember);

				if (refill)
				{
					// if refill requested, fill table from original select query
					if (FillDataMemberDelegate != null)
					{
						FillDataMemberDelegate(DataMember);
					}

				}
				else
				{
					// otherwise automatic update has taken care of synchronization, and we
					// may need to re-initialize each row (for our internal state flags)
					foreach (Xceed.Grid.DataRow dataRow in DataRows)
					{
						InitializeRowStatus(dataRow);
					}
				}
			}
			finally
			{
				EndInit();
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{

				// this is apparently required to make the grid unbind itself from the datasource;
				// otherwise if the datasource outlives the grid, its event handler references keep
				// the grid from being garbage collected, and changes to the datasource are processed
				// against the otherwise inaccessible "phantom" grid object
				try
				{
					this.DataSource = null;
					this.DataMember = null;
				}
				catch { }
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Ensures the last column is expanded on the grid to fill the DisplayRectangle whenever the grouping is updated
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void OnGroupingUpdated(EventArgs e)
		{
			if (this.Parent != null && this.Parent.Disposing)
				return;

			if (expandToFitColumn == null)
				return;

			try
			{
				if (this.DesignMode == false)
					if (expandToFitColumn != null)
						ExpandColumn(expandToFitColumn, expandToFitColumnInitialWidth);
			}
			catch { }

			base.OnGroupingUpdated(e);
		}                

		
		public void ExpandLastColumn()
		{
			int totalWidth = DisplayRectangle.Width;
			int lastVisibleIndex = 0;
			int visibleColumnWidths = 0;
			int secondTotalWidth = DisplayRectangle.Width;

			foreach (Xceed.Grid.Column column in Columns)
			{
				if ((column.Visible) && (column.VisibleIndex > lastVisibleIndex))
					lastVisibleIndex = column.VisibleIndex;

				if (column.Visible)
				{
					visibleColumnWidths = visibleColumnWidths + column.Width;
				}
			}

			if (Columns == null || Columns.Count == 0)
				return;

			Xceed.Grid.Column rightColumn = Columns.GetColumnAtVisibleIndex(lastVisibleIndex);

			// Remove other columns width
			foreach (Xceed.Grid.Column column in Columns)
			{
				if ((column.Visible) && (column != rightColumn))
					totalWidth -= column.Width;
			}

			secondTotalWidth = (secondTotalWidth - visibleColumnWidths) + rightColumn.Width;

			// Remove margins
			foreach (Xceed.Grid.Group group in GroupTemplates)
			{
				if (group.Visible)
					totalWidth -= group.SideMargin.Width;
			}

			// Remove row selector
			if (RowSelectorPane.Visible)
				totalWidth -= RowSelectorPane.Width;

			// Remove fixed column splitter
			if (FixedColumnSplitter.Visible)
				totalWidth -= FixedColumnSplitter.Width;

			// if (totalWidth - 50 > 0)
			//     rightColumn.Width = totalWidth - 50;
			if (totalWidth >= 0)
				rightColumn.Width = totalWidth;
		}


		public void ExpandColumn(Column expandColumn, int minimumWidth)
		{
			if (Columns == null || Columns.Count == 0)
				return;

			// Total grid width
			int totalWidth = DisplayRectangle.Width;

			// Remove width of other columns (except the expandColumn)
			foreach (Xceed.Grid.Column column in Columns)
				if ((column.Visible) && (column != expandColumn))
					totalWidth -= column.Width;

			// Remove margins
			foreach (Xceed.Grid.Group group in GroupTemplates)
				if (group.Visible)
					totalWidth -= group.SideMargin.Width;

			// Remove row selector
			if (RowSelectorPane.Visible)
				totalWidth -= RowSelectorPane.Width;

			// Remove fixed column splitter
			if (FixedColumnSplitter.Visible)
				totalWidth -= FixedColumnSplitter.Width;

			if (totalWidth >= 0)
				expandColumn.Width = Math.Max(totalWidth, minimumWidth);
		}
	}

	public class CustomColumnManagerRow : ColumnManagerRow
	{
		public CustomColumnManagerRow()
			: base()
		{

		}

		public CustomColumnManagerRow(RowSelector rowSelector)
			: base(rowSelector)
		{

		}

		protected CustomColumnManagerRow(CustomColumnManagerRow template)
			: base(template)
		{

		}

		protected override Row CreateInstance()
		{
			return new CustomColumnManagerRow(this);
		}

		protected override Cell CreateCell(Column parentColumn)
		{
			return new CustomColumnManagerCell(parentColumn);
		}
	}

	public class CustomColumnManagerCell : Xceed.Grid.ColumnManagerCell
	{

		public CustomColumnManagerCell(Column parentColumn)
			: base(parentColumn)
		{

		}

		public CustomColumnManagerCell()
		{

		}


		protected override void PaintBackground(GridPaintEventArgs e)
		{
			Rectangle rectangle = e.DisplayRectangle;
			GraphicsContainer graphicsContainer = e.Graphics.BeginContainer();
			e.Graphics.SetClip(rectangle);
			rectangle.Width += 5;

			Color color1 = new Color();
			Color color2 = new Color();
			Color color3 = new Color();

			int rectangleHeightDiv2 = rectangle.Height / 2;
			rectangle = new Rectangle(rectangle.Location.X, rectangle.Location.Y, rectangle.Width, rectangleHeightDiv2);

			//HACK, but style sheet type is not exposed, so we need some cheez-e method of differentiating which grids need the dark header columns.
			if (this.ParentGrid.Title == "Dark")
			{
				color1 = Color.Gray;
				color2 = Color.DimGray;
				color3 = Color.FromArgb(20, 20, 20);
			}
			else
			{
				color1 = Color.WhiteSmoke;
				color2 = Color.Gainsboro;
				color3 = Color.Silver;
			}
			if (base.MouseState == ColumnManagerCellMouseState.ColumnPressed)
			{
				color1 = Color.FromArgb(208, 224, 244);
				color2 = Color.FromArgb(106, 170, 235);
				color3 = Color.FromArgb(184, 250, 255);
			}

			e.Graphics.FillRectangle(new System.Drawing.Drawing2D.LinearGradientBrush(rectangle, color1, color2, 90, false), rectangle);
			rectangle.Offset(0, rectangleHeightDiv2);
			e.Graphics.FillRectangle(new System.Drawing.Drawing2D.LinearGradientBrush(rectangle, color2, color3, 90, false), rectangle);
			e.Graphics.EndContainer(graphicsContainer);
			e.Graphics.DrawLine(System.Drawing.Pens.DarkGray, e.DisplayRectangle.Right - 1, e.DisplayRectangle.Top, e.DisplayRectangle.Right - 1, e.DisplayRectangle.Bottom);

			// Note: The below alignment check will not work if the HorizontalAlignment is inherited from the AmbientParent
			// You must explicitly set the alignment to Right to get this code to work
			Rectangle glyphRectangle;
			if (HorizontalAlignment != Xceed.Grid.HorizontalAlignment.Right)
				glyphRectangle = new Rectangle(e.DisplayRectangle.Right - 12, e.DisplayRectangle.Top + 4, 8, 8);
			else
				// Right-aligned column, glyph on left
				glyphRectangle = new Rectangle(e.DisplayRectangle.Left + 4, e.DisplayRectangle.Top + 4, 8, 8);

			switch (this.ParentColumn.SortDirection)
			{
				case Xceed.Grid.SortDirection.Ascending:
					{
						//  A
						// B C
						Point A = new Point(glyphRectangle.Left + (glyphRectangle.Width / 2), glyphRectangle.Top);
						Point B = new Point(glyphRectangle.Left, glyphRectangle.Bottom);
						Point C = new Point(glyphRectangle.Right, glyphRectangle.Bottom);

						e.Graphics.FillPolygon(new System.Drawing.Drawing2D.LinearGradientBrush(glyphRectangle, Color.FromArgb(137, 137, 137), Color.FromArgb(94, 94, 94), 90, true), new Point[] { A, C, B }, FillMode.Winding);
						break;
					}
				case Xceed.Grid.SortDirection.Descending:
					{
						// B C
						//  A       
						Point A = new Point(glyphRectangle.Left + (glyphRectangle.Width / 2), glyphRectangle.Bottom);
						Point B = new Point(glyphRectangle.Left, glyphRectangle.Top);
						Point C = new Point(glyphRectangle.Right, glyphRectangle.Top);

						e.Graphics.FillPolygon(new System.Drawing.Drawing2D.LinearGradientBrush(glyphRectangle, Color.FromArgb(94, 94, 94), Color.FromArgb(137, 137, 137), 90, true), new Point[] { A, C, B }, FillMode.Winding);
						break;
					}
			}
		}
	}

	public class DBNullToBottomComparer : IComparer
	{
		public DBNullToBottomComparer()
		{
		}

		int IComparer.Compare(object x, object y)
		{
			if (x == System.DBNull.Value && y == System.DBNull.Value)
				return 0;
			else if (x == System.DBNull.Value && y != System.DBNull.Value)
				return 1;
			else if (x != null && y == System.DBNull.Value)
				return -1;
			else
				return (Convert.ToString(x)).CompareTo(Convert.ToString(y));

		}
	}
}
