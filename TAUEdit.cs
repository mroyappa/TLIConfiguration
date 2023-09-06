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
 * CLASS SUMMARY:	TAUEdit
 * 
 * TAUEdit is the form used to Add/Edit/Delete a Vessel's list of TAUs.
 * 
 */

namespace TLIConfiguration
{
	public partial class TAUEdit : Form
	{
		private DataTable m_dtDataTable;

		private CustomColumnManagerRow m_CustomColumnManagerRow;
		private Xceed.Grid.InsertionRow m_InsertionRow;
		private Xceed.Grid.DataRow m_EditRow;
		private Xceed.Grid.SpacerRow m_SpacerRow;

		private int m_iIndex;

		private bool m_bRebuildEquipment;

		public TAUEdit()
		{
			InitializeComponent();

			m_iIndex = 0;
		}

		private void TAUEdit_Load(object sender, EventArgs e)
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
				customXceedGridControl.AddBoundColumn("TAUAddress", "TAU Address", true, false, 150);
				customXceedGridControl.AddBoundColumn("Description", "Description", true, false, 150);

				customXceedGridControl.ExpandToFitColumn = customXceedGridControl.Columns["Description"];

				customXceedGridControl.Columns["TAUAddress"].SortDirection = Xceed.Grid.SortDirection.Ascending;

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

				customXceedGridControl.HideUnwantedGridColumns(new string[] { "TAUAddress", "Description" });
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
			m_dtDataTable.Columns.Add("TAUAddress", typeof(int));
			m_dtDataTable.Columns.Add("Description", typeof(string));

			foreach (TAU tau in TLIConfiguration.Vessel.TAUArray)
			{
				dr = m_dtDataTable.NewRow();

				dr["Index"] = m_iIndex++;
				dr["TAUAddress"] = tau.TAUAddress;
				dr["Description"] = tau.Description;

				m_dtDataTable.Rows.Add(dr);
				dr.AcceptChanges();
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
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["TAUAddress"], "TAU Address", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["Description"], "Description", e);
				if (!e.Cancel) ValidateNewRow(m_InsertionRow, e);
				if (!e.Cancel) m_InsertionRow.Cells["Index"].Value = m_iIndex++;
			}
			else if (m_EditRow != null)
			{
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["TAUAddress"], "TAU Address", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["Description"], "Description", e);
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
				if ((int)dr["TAUAddress"] == (int)insertionRow.Cells["TAUAddress"].Value)
				{
					MessageBox.Show("This TAU Address has already been used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
					if ((int)dr["TAUAddress"] == (int)editRow.Cells["TAUAddress"].Value)
					{
						MessageBox.Show("This TAU Address is already being used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
						e.Cancel = true;
						return;
					}
				}
			}
		}

		private void SaveChanges()
		{
			DataTable dt = (DataTable)customXceedGridControl.DataSource;

			TLIConfiguration.Vessel.TAUArray.Clear();

			foreach (DataRow dr in dt.Rows)
			{
				if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Unchanged)
					TLIConfiguration.Vessel.TAUArray.Add(new TAU(Convert.ToInt32(dr["TAUAddress"]), dr["Description"].ToString()));
				else if (dr.RowState == DataRowState.Modified)
				{
					TLIConfiguration.Vessel.TAUArray.Add(new TAU(Convert.ToInt32(dr["TAUAddress"]), dr["Description"].ToString()));
					UpdateTAUInVessselConfiguration(dr);
				}
				else if (dr.RowState == DataRowState.Deleted)
					RemoveTAUFromVesselConfiguration(dr);
			}
		}

		private void UpdateTAUInVessselConfiguration(DataRow dr)
		{
			int iOriginalTAU = Convert.ToInt32(dr["TAUAddress", DataRowVersion.Original]);
			int iNewTAU = Convert.ToInt32(dr["TAUAddress"]);

			foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
			{
				foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[eu.EquipmentID].Values)
				{
					if (gp.TAUAddress == iOriginalTAU)
						gp.TAUAddress = iNewTAU;
				}
			}
		}

		private void RemoveTAUFromVesselConfiguration(DataRow dr)
		{
			Dictionary<string, List<string>> deletedKeys = new Dictionary<string, List<string>>();

			int iDeletedAddress = Convert.ToInt32(dr["TAUAddress", DataRowVersion.Original]);

			m_bRebuildEquipment = true;

			for (int i = TLIConfiguration.Vessel.SCUArray.Count; i > 0; i--)
				if (TLIConfiguration.Vessel.SCUArray[i - 1].TAUAddress == iDeletedAddress)
					TLIConfiguration.Vessel.SCUArray.RemoveAt(i - 1);

			foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
				if (TLIConfiguration.VesselGaugePoints.ContainsKey(eu.EquipmentID))
					foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[eu.EquipmentID].Values)
						if (gp.TAUEnable && gp.TAUAddress == iDeletedAddress)
						{
							if (!deletedKeys.ContainsKey(eu.EquipmentID))
								deletedKeys.Add(eu.EquipmentID, new List<string>());

							deletedKeys[eu.EquipmentID].Add(gp.ProcessID);
						}

			foreach (string sEquipmentID in deletedKeys.Keys)
				foreach (string sProcessID in deletedKeys[sEquipmentID])
				{
					TLIConfiguration.VesselGaugePoints[sEquipmentID].Remove(sProcessID);

					if (TLIConfiguration.VesselAlarmPoints.ContainsKey(sEquipmentID))
						if (TLIConfiguration.VesselAlarmPoints[sEquipmentID].ContainsKey(sProcessID))
							TLIConfiguration.VesselAlarmPoints[sEquipmentID].Remove(sProcessID);
				}
		}

		public bool RebuildEquipment
		{
			get { return m_bRebuildEquipment; }
		}
	}
}