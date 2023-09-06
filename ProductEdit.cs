using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ICBObjectModel;
using ICBObjectModel.Enumerations;

/*
 * CLASS SUMMARY:	ProductEdit
 * 
 * ProductEdit is the form used to Add/Edit/Delete a Vessel's list of Products.
 * 
 */

namespace TLIConfiguration
{
	public partial class ProductEdit : Form
	{
		private DataTable m_dtDataTable;

		private CustomColumnManagerRow m_CustomColumnManagerRow;
		private Xceed.Grid.InsertionRow m_InsertionRow;
		private Xceed.Grid.DataRow m_EditRow;
		private Xceed.Grid.SpacerRow m_SpacerRow;

		private int m_iIndex;

		public ProductEdit()
		{
			InitializeComponent();

			m_iIndex = 0;
		}

		private void ProductEdit_Load(object sender, EventArgs e)
		{
			SetupGrid();
			PopulateGrid();
		}

		private void SetupGrid()
		{
			try
			{
				customXceedGridControl.SetupGridControl();
				customXceedGridControl.BeginInit();

				customXceedGridControl.AllowDelete = true;

//				customXceedGridControl.SingleClickEdit = true;

				columnManagerRow1.Remove();

				customXceedGridControl.InitializingNewDataRow += new Xceed.Grid.InitializingNewDataRowEventHandler(InitializingNewDataRow);

				// Custom Column Manager Row
				m_CustomColumnManagerRow = new CustomColumnManagerRow();
				m_CustomColumnManagerRow.BackColor = System.Drawing.Color.White;
				m_CustomColumnManagerRow.ForeColor = System.Drawing.Color.Black;
				m_CustomColumnManagerRow.Height = 17;
				customXceedGridControl.FixedHeaderRows.Add(m_CustomColumnManagerRow);

				// Insertion Row
				m_InsertionRow = new Xceed.Grid.InsertionRow();
				m_InsertionRow.ForeColor = Color.FromArgb(29, 50, 139);
				m_InsertionRow.BackColor = Color.FromArgb(244, 244, 244);
				customXceedGridControl.FixedHeaderRows.Add(m_InsertionRow);

				m_InsertionRow.EndingEdit += new CancelEventHandler(EndingEdit);

				// Spacer Row
				m_SpacerRow = new Xceed.Grid.SpacerRow();
				m_SpacerRow.Height = 4;
				customXceedGridControl.FixedHeaderRows.Add(m_SpacerRow);

				// RowSelectorPane
				customXceedGridControl.RowSelectorPane.Visible = false;

				customXceedGridControl.AddBoundColumn("Index", "Index", false, false, 100);
				customXceedGridControl.AddBoundColumn("ProductName", "Product", true, false, 100);
				customXceedGridControl.AddBoundColumn("SpecificGravity", "Specific Gravity", true, false, 100);
				customXceedGridControl.AddBoundColumn("Cargo", "Cargo", true, false, 75);
				customXceedGridControl.AddBoundColumn("GaugeColor", "Product Color", true, false, 100);

				customXceedGridControl.Columns["GaugeColor"].HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left;
				customXceedGridControl.DataRowTemplate.Cells["GaugeColor"].CellEditorManager = new ColorPickerCellEditorManager();
				m_InsertionRow.Cells["GaugeColor"].CellEditorManager = new ColorPickerCellEditorManager();
				customXceedGridControl.DataRowTemplate.Cells["GaugeColor"].Paint += new Xceed.Grid.GridPaintEventHandler(GaugeColorCellPaint);

				customXceedGridControl.ExpandToFitColumn = customXceedGridControl.Columns["ProductName"];

				customXceedGridControl.Columns["ProductName"].SortDirection = Xceed.Grid.SortDirection.Ascending;

				customXceedGridControl.EndInit();
			}
			catch (Exception e)
			{
				MessageBox.Show("Error retrieving configuration data.\n" + e.Message, "TLI Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
		}

		private void PopulateGrid()
		{
			try
			{
				FillDataTable();

				customXceedGridControl.BeginInit();

				customXceedGridControl.DataSource = m_dtDataTable;
				customXceedGridControl.DataMember = "";

				customXceedGridControl.EndInit();

				customXceedGridControl.HideUnwantedGridColumns(new string[] { "ProductName", "SpecificGravity", "Cargo", "GaugeColor" });
			}
			catch (Exception e)
			{
				MessageBox.Show("Error retrieving configuration data.\n" + e.Message, "TLI Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
		}

		private void FillDataTable()
		{
			DataRow dr;
			m_dtDataTable = new DataTable();

			m_dtDataTable.Columns.Add("Index", typeof(int));
			m_dtDataTable.Columns.Add("ProductName", typeof(string));
			m_dtDataTable.Columns.Add("SpecificGravity", typeof(float));
			m_dtDataTable.Columns.Add("Cargo", typeof(bool));
			m_dtDataTable.Columns.Add("GaugeColor", typeof(Color));

			foreach (Product p in TLIConfiguration.Vessel.Product)
			{
				dr = m_dtDataTable.NewRow();

				dr["Index"] = m_iIndex++;
				dr["ProductName"] = p.ProductName;
				dr["SpecificGravity"] = p.SpecificGravity;
				dr["Cargo"] = p.Cargo;
				dr["GaugeColor"] = p.GaugeColor;

				m_dtDataTable.Rows.Add(dr);
				dr.AcceptChanges();
			}
		}

		private void GaugeColorCellPaint(object sender, Xceed.Grid.GridPaintEventArgs e)
		{
			//Console.WriteLine("PAINT");
			Xceed.Grid.Cell cell = (Xceed.Grid.Cell)sender;

			Color cFillColor;
			Rectangle rCell;

			if (cell.Value != null)
			{
				cFillColor = (Color)cell.Value;
				rCell = new Rectangle(e.DisplayRectangle.Location, e.DisplayRectangle.Size);
				//Console.WriteLine("color : " + cFillColor);

				e.Graphics.FillRectangle(new SolidBrush(cFillColor), rCell);
			}
		}

		private void InitializingNewDataRow(object sender, Xceed.Grid.InitializingNewDataRowEventArgs e)
		{
			e.DataRow.Cells["Cargo"].Value = true;
		}

		private void AddingDataRow(object sender, Xceed.Grid.AddingDataRowEventArgs e)
		{
			e.DataRow.BeginningEdit += new CancelEventHandler(BeginningEdit);
			e.DataRow.EndingEdit += new CancelEventHandler(EndingEdit);
		}

		private void BeginningEdit(object sender, CancelEventArgs e)
		{
			Console.WriteLine("begin");
			m_EditRow = (Xceed.Grid.DataRow)sender;
		}

		// HACK
		private void EndingEdit(object sender, CancelEventArgs e)
		{
			if (Disposing)
				return;

			if (m_EditRow == null)
            {
                Console.WriteLine("EndingEdit : " + m_InsertionRow.Cells["ProductName"].Value + " : " + m_InsertionRow.Cells["SpecificGravity"].Value + " : " +
                    m_InsertionRow.Cells["Cargo"].Value + " : " + m_InsertionRow.Cells["GaugeColor"].Value);
                if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["ProductName"], "Product", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["SpecificGravity"], "Specific Gravity", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["Cargo"], "Cargo", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["GaugeColor"], "Product Color", e);
				if (!e.Cancel) ValidateNewRow(m_InsertionRow, e);
				if (!e.Cancel) m_InsertionRow.Cells["Index"].Value = m_iIndex++;
			}
			else if (m_EditRow != null)
            {
                Console.WriteLine("EndingEdit : " + m_EditRow.Cells["ProductName"].Value + " : " + m_EditRow.Cells["SpecificGravity"].Value + " : " +
                    m_EditRow.Cells["Cargo"].Value + " : " + m_EditRow.Cells["GaugeColor"].Value);
                if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["ProductName"], "Product", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["SpecificGravity"], "Specific Gravity", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["Cargo"], "Cargo", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["GaugeColor"], "Product Color", e);
				if (!e.Cancel) ValidateEditRow(m_EditRow, e);
			}

			m_EditRow = null;
		}

		private void cmdOk_Click(object sender, EventArgs e)
		{
			SaveChanges();
			this.Close();
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ValidateNewRow(Xceed.Grid.InsertionRow insertionRow, CancelEventArgs e)
		{
			DataTable dt = (DataTable)customXceedGridControl.DataSource;

			foreach (DataRow dr in dt.Rows)
			{
				if ((string)dr["ProductName"] == (string)insertionRow.Cells["ProductName"].Value)
				{
					MessageBox.Show("This Product name has already been used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					e.Cancel = true;
					return;
				}
			}
		}

		private void ValidateEditRow(Xceed.Grid.DataRow editRow, CancelEventArgs e)
		{
			DataTable dt = (DataTable)customXceedGridControl.DataSource;

			foreach (DataRow dr in dt.Rows)
			{
				if ((int)dr["Index"] != (int)editRow.Cells["Index"].Value)
				{
					if ((string)dr["ProductName"] == (string)editRow.Cells["ProductName"].Value)
					{
						MessageBox.Show("This Product Name has already being used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
						e.Cancel = true;
						return;
					}
				}
			}
		}

		private void SaveChanges()
		{
			DataTable dt = (DataTable)customXceedGridControl.DataSource;

			TLIConfiguration.Vessel.Product.Clear();

			foreach (DataRow dr in dt.Rows)
			{
				if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Unchanged)
					TLIConfiguration.Vessel.Product.Add(new Product(dr["ProductName"].ToString(), Convert.ToSingle(dr["SpecificGravity"]), 0, Convert.ToBoolean(dr["Cargo"]), (Color)dr["GaugeColor"]));
				else if (dr.RowState == DataRowState.Modified)
				{
					TLIConfiguration.Vessel.Product.Add(new Product(dr["ProductName"].ToString(), Convert.ToSingle(dr["SpecificGravity"]), 0, Convert.ToBoolean(dr["Cargo"]), (Color)dr["GaugeColor"]));
					UpdateProductInVessselConfiguration(dr);
				}
				else if (dr.RowState == DataRowState.Deleted)
					RemoveProductFromVesselConfiguration(dr);
			}
		}

		private void RemoveProductFromVesselConfiguration(DataRow dr)
		{
			string sDeleteProduct = dr["ProductName", DataRowVersion.Original].ToString();

			foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
				if (eu.CurrentProduct == sDeleteProduct)
					eu.CurrentProduct = "";
		}

		private void UpdateProductInVessselConfiguration(DataRow dr)
		{
			string sOriginalProduct = dr["ProductName", DataRowVersion.Original].ToString();
			string sNewProduct = dr["ProductName"].ToString();

			foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
				if (eu.CurrentProduct == sOriginalProduct)
					eu.CurrentProduct = sNewProduct;
		}
	}
}