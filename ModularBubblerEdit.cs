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
 * CLASS SUMMARY:	ModularBubblerEdit
 * 
 * ModularBubblerEdit is the form used to Add/Edit/Delete a Vessel's list of Modular Bubblers.
 * 
 */

namespace TLIConfiguration
{
	public partial class ModularBubblerEdit : Form
	{
		private DataTable m_dtDataTable;

		private CustomColumnManagerRow m_CustomColumnManagerRow;
		private Xceed.Grid.InsertionRow m_InsertionRow;
		private Xceed.Grid.DataRow m_EditRow;
		private Xceed.Grid.SpacerRow m_SpacerRow;

		private int m_iIndex;

		private bool m_bRebuildEquipment;

		public ModularBubblerEdit()
		{
			InitializeComponent();

			m_iIndex = 0;
		}

		private void ModularBubblerEdit_Load(object sender, EventArgs e)
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
				customXceedGridControl.AddBoundColumn("ModularBubblerAddress", "Bubbler Address", true, false, 100);
				customXceedGridControl.AddBoundColumn("SyncTimeHigh", "Sync Time High", true, false, 100);
				customXceedGridControl.AddBoundColumn("SyncTimeLow", "Sync Time Low", true, false, 100);
				customXceedGridControl.AddBoundColumn("Description", "Description", true, false, 150);

				customXceedGridControl.ExpandToFitColumn = customXceedGridControl.Columns["Description"];

				customXceedGridControl.Columns["ModularBubblerAddress"].SortDirection = Xceed.Grid.SortDirection.Ascending;

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

				customXceedGridControl.HideUnwantedGridColumns(new string[] { "ModularBubblerAddress", "SyncTimeHigh", "SyncTimeLow", "Description" });
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
			m_dtDataTable.Columns.Add("ModularBubblerAddress", typeof(int));
			m_dtDataTable.Columns.Add("Description", typeof(string));
			m_dtDataTable.Columns.Add("SyncTimeHigh", typeof(int));
			m_dtDataTable.Columns.Add("SyncTimeLow", typeof(int));

			foreach (ModularBubbler bubbler in TLIConfiguration.Vessel.ModularBubblerArray)
			{
				dr = m_dtDataTable.NewRow();

				dr["Index"] = m_iIndex++;
				dr["ModularBubblerAddress"] = bubbler.ModularBubblerAddress;
				dr["Description"] = bubbler.Description;
				dr["SyncTimeHigh"] = bubbler.SyncTimeHigh;
				dr["SyncTimeLow"] = bubbler.SyncTimeLow;

				m_dtDataTable.Rows.Add(dr);
				dr.AcceptChanges();
			}
		}
		
		private void InitializingNewDataRow(object sender, Xceed.Grid.InitializingNewDataRowEventArgs e)
		{
			e.DataRow.Cells["SyncTimeHigh"].Value = 300;
			e.DataRow.Cells["SyncTimeLow"].Value = 2700;
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
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["ModularBubblerAddress"], "Bubbler Address", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["Description"], "Description", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["SyncTimeHigh"], "Sync Time High", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["SyncTimeLow"], "Sync Time Low", e);
				if (!e.Cancel) ValidateNewRow(m_InsertionRow, e);
				if (!e.Cancel) m_InsertionRow.Cells["Index"].Value = m_iIndex++;
			}
			else if (m_EditRow != null)
			{
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["ModularBubblerAddress"], "Bubbler Address", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["Description"], "Description", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["SyncTimeHigh"], "Sync Time High", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["SyncTimeLow"], "Sync Time Low", e);
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
				if ((int)dr["ModularBubblerAddress"] == (int)insertionRow.Cells["ModularBubblerAddress"].Value)
				{
					MessageBox.Show("This Modular Bubbler Address has already been used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
					if ((int)dr["ModularBubblerAddress"] == (int)editRow.Cells["ModularBubblerAddress"].Value)
					{
						MessageBox.Show("This Modular Bubbler Address is already being used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
						e.Cancel = true;
						return;
					}
				}
			}
		}

		private void SaveChanges()
		{
			DataTable dt = (DataTable)customXceedGridControl.DataSource;

			TLIConfiguration.Vessel.ModularBubblerArray.Clear();

			foreach (DataRow dr in dt.Rows)
			{
				if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Unchanged)
				{
					TLIConfiguration.Vessel.ModularBubblerArray.Add(new ModularBubbler(Convert.ToInt32(dr["ModularBubblerAddress"]), dr["Description"].ToString(),
						Convert.ToUInt16(dr["SyncTimeHigh"]), Convert.ToUInt16(dr["SyncTimeLow"])));

					if (dr.RowState == DataRowState.Added)
					{
						for (int i = 1; i <= 8; i++)
							TLIConfiguration.Vessel.ModularBubberChannelArray.Add(ModularBubblerChannel.CreateDefaultChannel(Convert.ToInt32(dr["ModularBubblerAddress"]), i));

						for(int i = 0; i <=8; i++)
							TLIConfiguration.Vessel.ModularBubblerEZTArray.Add(ModularBubblerEZT.CreateDefault(Convert.ToInt32(dr["ModularBubblerAddress"]), i));
					}
				}
				else if (dr.RowState == DataRowState.Modified)
				{
					TLIConfiguration.Vessel.ModularBubblerArray.Add(new ModularBubbler(Convert.ToInt32(dr["ModularBubblerAddress"]), dr["Description"].ToString(),
						Convert.ToUInt16(dr["SyncTimeHigh"]), Convert.ToUInt16(dr["SyncTimeLow"])));

					UpdateModularBubblerInVessselConfiguration(dr);
				}
				else if (dr.RowState == DataRowState.Deleted)
				{
					RemoveModularBubblerFromVesselConfiguration(dr);
					RemoveModularBubblerChannelsFromVesselConfiguration(Convert.ToInt32(dr["ModularBubblerAddress", DataRowVersion.Original]));
				}
			}
		}

		private void UpdateModularBubblerInVessselConfiguration(DataRow dr)
		{
			int iOriginalMODBUB = Convert.ToInt32(dr["ModularBubblerAddress", DataRowVersion.Original]);
			int iNewMODBUB = Convert.ToInt32(dr["ModularBubblerAddress"]);

			foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
			{
				foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[eu.EquipmentID].Values)
				{
					if (gp.BUBAddress == iOriginalMODBUB)
					{
						gp.BUBAddress = iNewMODBUB;

						foreach (ModularBubblerChannel mbc in TLIConfiguration.Vessel.ModularBubberChannelArray)
						{
							if (mbc.ModularBubblerAddress == iOriginalMODBUB)
								mbc.ModularBubblerAddress = iNewMODBUB;
						}
					}
				}
			}
		}

		private void RemoveModularBubblerFromVesselConfiguration(DataRow dr)
		{
			Dictionary<string, List<string>> deletedKeys = new Dictionary<string, List<string>>();

			int iDeletedAddress = Convert.ToInt32(dr["ModularBubblerAddress", DataRowVersion.Original]);

			m_bRebuildEquipment = true;

			foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
				if (TLIConfiguration.VesselGaugePoints.ContainsKey(eu.EquipmentID))
					foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[eu.EquipmentID].Values)
						if (gp.BUBEnable && gp.BUBAddress == iDeletedAddress)
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

		public void RemoveModularBubblerChannelsFromVesselConfiguration(int iModularBubberAddress)
		{
			for (int i = TLIConfiguration.Vessel.ModularBubberChannelArray.Count; i > 0; i--)
				if (TLIConfiguration.Vessel.ModularBubberChannelArray[i - 1].ModularBubblerAddress == iModularBubberAddress)
					TLIConfiguration.Vessel.ModularBubberChannelArray.RemoveAt(i - 1);
		}

		public bool RebuildEquipment
		{
			get { return m_bRebuildEquipment; }
		}
	}
}