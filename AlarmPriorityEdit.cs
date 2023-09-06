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
 * CLASS SUMMARY:	AlarmPriorityEdit
 * 
 * AlarmPriorityEdit is the form used to Add/Edit/Delete a Vessel's Alarm Priority list.
 * 
 */

namespace TLIConfiguration
{
	public partial class AlarmPriorityEdit : Form
	{
		private DataTable m_dtDataTable;

		private CustomColumnManagerRow m_CustomColumnManagerRow;
		private Xceed.Grid.InsertionRow m_InsertionRow;
		private Xceed.Grid.DataRow m_EditRow;
		private Xceed.Grid.SpacerRow m_SpacerRow;

		private int m_iIndex;

		public AlarmPriorityEdit()
		{
			InitializeComponent();

			m_iIndex = 0;
		}

		private void AlarmPriorityEdit_Load(object sender, EventArgs e)
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
				customXceedGridControl.AddBoundColumn("Priority", "Alarm Priority", true, false, 125);
				customXceedGridControl.AddBoundColumn("Description", "Description", true, false, 100);
				customXceedGridControl.AddBoundColumn("AlarmColor", "Color", true, false, 150);

				customXceedGridControl.Columns["AlarmColor"].HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left;
				customXceedGridControl.DataRowTemplate.Cells["AlarmColor"].CellEditorManager = new ColorPickerCellEditorManager();
				m_InsertionRow.Cells["AlarmColor"].CellEditorManager = new ColorPickerCellEditorManager();
				customXceedGridControl.DataRowTemplate.Cells["AlarmColor"].Paint += new Xceed.Grid.GridPaintEventHandler(AlarmColorCellPaint);

				customXceedGridControl.ExpandToFitColumn = customXceedGridControl.Columns["Description"];

				customXceedGridControl.Columns["Priority"].SortDirection = Xceed.Grid.SortDirection.Ascending;

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

				customXceedGridControl.HideUnwantedGridColumns(new string[] { "Priority", "Description", "AlarmColor" });
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
			m_dtDataTable.Columns.Add("Priority", typeof(int));
			m_dtDataTable.Columns.Add("Description", typeof(string));
			m_dtDataTable.Columns.Add("AlarmColor", typeof(Color));

			foreach (AlarmPriority ap in TLIConfiguration.Vessel.AlarmPriority)
			{
				dr = m_dtDataTable.NewRow();

				dr["Index"] = m_iIndex++;
				dr["Priority"] = ap.Priority;
				dr["Description"] = ap.Description;
				dr["AlarmColor"] = ap.AlarmColor;

				m_dtDataTable.Rows.Add(dr);
				dr.AcceptChanges();
			}
		}
		private void AlarmColorCellPaint(object sender, Xceed.Grid.GridPaintEventArgs e)
		{
			Xceed.Grid.Cell cell = (Xceed.Grid.Cell)sender;

			Color cFillColor;
			Rectangle rCell;

			if (cell.Value != null)
			{
				cFillColor = (Color)cell.Value;
				rCell = new Rectangle(e.DisplayRectangle.Location, e.DisplayRectangle.Size);

				e.Graphics.FillRectangle(new SolidBrush(cFillColor), rCell);
			}
		}


		private void InitializingNewDataRow(object sender, Xceed.Grid.InitializingNewDataRowEventArgs e)
		{
		}

		private void AddingDataRow(object sender, Xceed.Grid.AddingDataRowEventArgs e)
		{
			e.DataRow.BeginningEdit += new CancelEventHandler(BeginningEdit);
			e.DataRow.EndingEdit += new CancelEventHandler(EndingEdit);
		}

		private void BeginningEdit(object sender, CancelEventArgs e)
		{
			m_EditRow = (Xceed.Grid.DataRow)sender;
		}

		// HACK
		private void EndingEdit(object sender, CancelEventArgs e)
		{
			if (Disposing)
				return;

			if (m_EditRow == null)
			{
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["Priority"], "Alarm Priority", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["Description"], "Description", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["AlarmColor"], "Alarm Color", e);
				if (!e.Cancel) ValidateNewRow(m_InsertionRow, e);
				if (!e.Cancel) m_InsertionRow.Cells["Index"].Value = m_iIndex++;
			}
			else if (m_EditRow != null)
			{
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["Priority"], "Alarm Priority", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["Description"], "Description", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["AlarmColor"], "Alarm Color", e);
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
				if ((int)dr["Priority"] == (int)insertionRow.Cells["Priority"].Value)
				{
					MessageBox.Show("This Alarm Priority has already been defined.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					e.Cancel = true;
					return;
				}
				else if ((string)dr["Description"] == (string)insertionRow.Cells["Description"].Value)
				{
					MessageBox.Show("This Alarm Priority has already been defined.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
					if ((int)dr["Priority"] == (int)editRow.Cells["Priority"].Value)
					{
						MessageBox.Show("This Alarm Priority has already been defined.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
						e.Cancel = true;
						return;
					}
					else if ((string)dr["Description"] == (string)editRow.Cells["Description"].Value )
					{
						MessageBox.Show("This Alarm Priority has already been defined.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
						e.Cancel = true;
						return;
					}
				}
			}
		}

		private void SaveChanges()
		{
			DataTable dt = (DataTable)customXceedGridControl.DataSource;

			TLIConfiguration.Vessel.AlarmPriority.Clear();

			foreach (DataRow dr in dt.Rows)
			{
				if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Unchanged)
					TLIConfiguration.Vessel.AlarmPriority.Add(new AlarmPriority(Convert.ToInt32(dr["Priority"]), dr["Description"].ToString(), (Color)dr["AlarmColor"]));
				else if (dr.RowState == DataRowState.Modified)
				{
					TLIConfiguration.Vessel.AlarmPriority.Add(new AlarmPriority(Convert.ToInt32(dr["Priority"]), dr["Description"].ToString(), (Color)dr["AlarmColor"]));
					UpdateAlarmPriorityInVessselConfiguration(dr);
				}
				else if (dr.RowState == DataRowState.Deleted)
					RemoveAlarmPriorityFromVesselConfiguration(dr);
			}
		}

		private void RemoveAlarmPriorityFromVesselConfiguration(DataRow dr)
		{
			Dictionary<string, Dictionary<string, List<Guid>>> deleteKeys = new Dictionary<string, Dictionary<string, List<Guid>>>();

			int iDeletedPriority = Convert.ToInt32(dr["Priority", DataRowVersion.Original].ToString());

			foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
				if (TLIConfiguration.VesselGaugePoints.ContainsKey(eu.EquipmentID))
					foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[eu.EquipmentID].Values)
						if (TLIConfiguration.VesselAlarmPoints.ContainsKey(eu.EquipmentID))
							if (TLIConfiguration.VesselAlarmPoints[eu.EquipmentID].ContainsKey(gp.ProcessID))
								foreach (AlarmPoint ap in TLIConfiguration.VesselAlarmPoints[eu.EquipmentID][gp.ProcessID].Values)
									if (ap.AlarmPriority == iDeletedPriority)
									{
										if(!deleteKeys.ContainsKey(eu.EquipmentID))
											deleteKeys.Add(eu.EquipmentID, new Dictionary<string,List<Guid>>());

										if (!deleteKeys[eu.EquipmentID].ContainsKey(gp.ProcessID))
											deleteKeys[eu.EquipmentID].Add(gp.ProcessID, new List<Guid>());

										deleteKeys[eu.EquipmentID][gp.ProcessID].Add(ap.AlarmID);
									}

			foreach (string sEquipmentID in deleteKeys.Keys)
				foreach (string sProcessID in deleteKeys[sEquipmentID].Keys)
					foreach (Guid guidAlarmID in deleteKeys[sEquipmentID][sProcessID])
						TLIConfiguration.VesselAlarmPoints[sEquipmentID][sProcessID].Remove(guidAlarmID);
		}

		private void UpdateAlarmPriorityInVessselConfiguration(DataRow dr)
		{
			int iOriginalPriority = Convert.ToInt32(dr["Priority", DataRowVersion.Original]);
			int iNewPriority = Convert.ToInt32(dr["Priority"]);

			foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
			{
				if (TLIConfiguration.VesselGaugePoints.ContainsKey(eu.EquipmentID))
				{
					foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[eu.EquipmentID].Values)
					{
						if (TLIConfiguration.VesselAlarmPoints.ContainsKey(eu.EquipmentID))
						{
							if (TLIConfiguration.VesselAlarmPoints[eu.EquipmentID].ContainsKey(gp.ProcessID))
							{
								foreach (AlarmPoint ap in TLIConfiguration.VesselAlarmPoints[eu.EquipmentID][gp.ProcessID].Values)
								{
									if (ap.AlarmPriority == iOriginalPriority)
										ap.AlarmPriority = iNewPriority;
								}
							}
						}
					}
				}
			}
		}

	}
}