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
 * CLASS SUMMARY:	AlarmAnnunciationEdit
 * 
 * AlarmAnnunciationEdit is the form used to Add/Edit/Delete a Vessel's Alarm Annunciation list.
 * 
 */

namespace TLIConfiguration
{
	public partial class AlarmAnnunciationEdit : Form
	{
		private DataTable m_dtDataTable;

		private CustomColumnManagerRow m_CustomColumnManagerRow;
		private Xceed.Grid.InsertionRow m_InsertionRow;
		private Xceed.Grid.DataRow m_EditRow;
		private Xceed.Grid.SpacerRow m_SpacerRow;

		private int m_iIndex;

		public AlarmAnnunciationEdit()
		{
			InitializeComponent();

			m_iIndex = 0;
		}

		private void AlarmAnnunciationEdit_Load(object sender, EventArgs e)
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
				customXceedGridControl.AddBoundColumn("AlarmAnnunciationName", "Alarm Annunciation", true, false, 150);
				customXceedGridControl.AddBoundColumn("AMUOutputAddress", "AMU Address", true, false, 100);
				customXceedGridControl.AddBoundColumn("AMUOutputDigitalAddress", "AMU Digital Channel", true, false, 150);
				customXceedGridControl.AddBoundColumn("KeepActiveOnAcknowledge", "Keep Active On Ack", true, false, 125);
				customXceedGridControl.AddBoundColumn("AMUOutputEnable", "Enabled", true, false, 60);

				customXceedGridControl.ExpandToFitColumn = customXceedGridControl.Columns["AlarmAnnunciationName"];
				
				customXceedGridControl.Columns["AlarmAnnunciationName"].SortDirection = Xceed.Grid.SortDirection.Ascending;

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

				customXceedGridControl.HideUnwantedGridColumns(new string[] { "AlarmAnnunciationName", "AMUOutputEnable", "AMUOutputEnable", "AMUOutputAddress", "AMUOutputDigitalAddress", "KeepActiveOnAcknowledge" });
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
			m_dtDataTable.Columns.Add("AlarmAnnunciationName", typeof(string));
			m_dtDataTable.Columns.Add("AMUOutputEnable", typeof(bool));
			m_dtDataTable.Columns.Add("AMUOutputAddress", typeof(int));
			m_dtDataTable.Columns.Add("AMUOutputDigitalAddress", typeof(int));
			m_dtDataTable.Columns.Add("KeepActiveOnAcknowledge", typeof(bool));

			foreach (AlarmAnnunciation aa in TLIConfiguration.Vessel.AlarmAnnunciation)
			{
				dr = m_dtDataTable.NewRow();

				dr["Index"] = m_iIndex++;
				dr["AlarmAnnunciationName"] = aa.AlarmAnnunciationName;
				dr["AMUOutputEnable"] = aa.AMUOutputEnable;
				dr["AMUOutputAddress"] = aa.AMUOutputAddress;
				dr["AMUOutputDigitalAddress"] = aa.AMUOutputDigitalChannel;
				dr["KeepActiveOnAcknowledge"] = aa.KeepActiveOnAcknowledge;

				m_dtDataTable.Rows.Add(dr);
				dr.AcceptChanges();
			}
		}

		private void InitializingNewDataRow(object sender, Xceed.Grid.InitializingNewDataRowEventArgs e)
		{
			e.DataRow.Cells["AMUOutputAddress"].Value = 1;
			e.DataRow.Cells["AMUOutputDigitalAddress"].Value = 1;
			e.DataRow.Cells["AMUOutputEnable"].Value = true;
			e.DataRow.Cells["KeepActiveOnAcknowledge"].Value = false;
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
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["AlarmAnnunciationName"], "Alarm Annunciation", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["AMUOutputAddress"], "AMU Address", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["AMUOutputDigitalAddress"], "AMU Digital Channel", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["AMUOutputEnable"], "Enabled", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["KeepActiveOnAcknowledge"], "Keep Active On Ack", e);
				if (!e.Cancel) ValidateNewRow(m_InsertionRow, e);
				if (!e.Cancel) m_InsertionRow.Cells["Index"].Value = m_iIndex++;
			}
			else if (m_EditRow != null)
			{
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["AlarmAnnunciationName"], "Alarm Annunciation", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["AMUOutputAddress"], "AMU Address", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["AMUOutputDigitalAddress"], "AMU Digital Channel", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["AMUOutputEnable"], "Enabled", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["KeepActiveOnAcknowledge"], "Keep Active On Ack", e);
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
				if ((string)dr["AlarmAnnunciationName"] == (string)insertionRow.Cells["AlarmAnnunciationName"].Value)
				{
					MessageBox.Show("This Alarm Annunciation name has already been defined.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					e.Cancel = true;
					return;
				}
				else if ((int)dr["AMUOutputAddress"] == (int)insertionRow.Cells["AMUOutputAddress"].Value && (int)dr["AMUOutputDigitalAddress"] == (int)insertionRow.Cells["AMUOutputDigitalAddress"].Value)
				{
					MessageBox.Show("This AMU Address and Digital Channel are already being used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					e.Cancel = true;
					return;
				}
			}
		}

		private void ValidateEditRow(Xceed.Grid.DataRow editRow, CancelEventArgs e)
		{
			DataTable dt = (DataTable) customXceedGridControl.DataSource;

			foreach (DataRow dr in dt.Rows)
			{
				if ((int)dr["Index"] != (int)editRow.Cells["Index"].Value)
				{
					if ((string)dr["AlarmAnnunciationName"] == (string)editRow.Cells["AlarmAnnunciationName"].Value)
					{
						MessageBox.Show("This Alarm Annunciation name has already been defined.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
						e.Cancel = true;
						return;
					}
					else if ((int)dr["AMUOutputAddress"] == (int)editRow.Cells["AMUOutputAddress"].Value && (int)dr["AMUOutputDigitalAddress"] == (int)editRow.Cells["AMUOutputDigitalAddress"].Value)
					{
						MessageBox.Show("This AMU Address and Digital Channel are already being used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
						e.Cancel = true;
						return;
					}
				}
			}
		}

		private void SaveChanges()
		{
			DataTable dt = (DataTable)customXceedGridControl.DataSource;

			TLIConfiguration.Vessel.AlarmAnnunciation.Clear();

			foreach (DataRow dr in dt.Rows)
			{
				if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Unchanged)
					TLIConfiguration.Vessel.AlarmAnnunciation.Add(new AlarmAnnunciation(dr["AlarmAnnunciationName"].ToString(), new AMUOutput(Convert.ToBoolean(dr["AMUOutputEnable"]), Convert.ToInt32(dr["AMUOutputAddress"]), Convert.ToInt32(dr["AMUOutputDigitalAddress"])), Convert.ToBoolean(dr["KeepActiveOnAcknowledge"])));
				else if (dr.RowState == DataRowState.Modified)
				{
					TLIConfiguration.Vessel.AlarmAnnunciation.Add(new AlarmAnnunciation(dr["AlarmAnnunciationName"].ToString(), new AMUOutput(Convert.ToBoolean(dr["AMUOutputEnable"]), Convert.ToInt32(dr["AMUOutputAddress"]), Convert.ToInt32(dr["AMUOutputDigitalAddress"])), Convert.ToBoolean(dr["KeepActiveOnAcknowledge"])));
					UpdateAlarmAnnunciationInVessselConfiguration(dr);
				}
				else if(dr.RowState == DataRowState.Deleted)
					RemoveAlarmAnnuncaitionFromVesselConfiguration(dr);
			}
		}

		private void UpdateAlarmAnnunciationInVessselConfiguration(DataRow dr)
		{
			string sOriginalName, sNewName;

			sOriginalName = dr["AlarmAnnunciationName", DataRowVersion.Original].ToString();
			sNewName = dr["AlarmAnnunciationName"].ToString();

			if (sOriginalName != sNewName)
			{
				foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
				{
					foreach (StopGauge sg in (eu.StopGaugeArray))
					{
						for (int i = 0; i < sg.AlarmAnnunciation.Count; i++)
						{
							if (sg.AlarmAnnunciation[i] == sOriginalName)
								sg.AlarmAnnunciation[i] = sNewName;
						}
					}
				}

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
										for (int i = 0; i < ap.AlarmAnnunciation.Count; i++)
										{
											if (ap.AlarmAnnunciation[i] == sOriginalName)
												ap.AlarmAnnunciation[i] = sNewName;
										}
									}
								}
							}
						}
					}
				}
			}
		}

		private void RemoveAlarmAnnuncaitionFromVesselConfiguration(DataRow dr)
		{
			string sDeletedAlarmAnnunciation = dr["AlarmAnnunciationName", DataRowVersion.Original].ToString();

			foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
			{
				foreach(StopGauge sg in (eu.StopGaugeArray))
				{
					for (int i = sg.AlarmAnnunciation.Count; i > 0; i--)
					{
						if (sg.AlarmAnnunciation[i - 1] == sDeletedAlarmAnnunciation)
							sg.AlarmAnnunciation.RemoveAt(i - 1);
					}
				}
			}

			foreach(EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
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
									for (int i = ap.AlarmAnnunciation.Count; i > 0; i--)
									{
										if (ap.AlarmAnnunciation[i - 1] == sDeletedAlarmAnnunciation)
											ap.AlarmAnnunciation.RemoveAt(i - 1);
									}
								}
							}
						}
					}
				}
			}
		}
	}
}