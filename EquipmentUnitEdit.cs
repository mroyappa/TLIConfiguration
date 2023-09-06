using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ICBObjectModel;
using ICBObjectModel.Enumerations;

/*
 * CLASS SUMMARY:	EquipmentUnitEdit
 * 
 * EquipmentUnitEdit is the form used by users to specify EquipmentUnit parameters.
 * 
 */

namespace TLIConfiguration
{
	public partial class EquipmentUnitEdit : Form
	{
		private DataTable m_dtAlarmDataTable;

		private CustomColumnManagerRow m_alarmCustomColumnManagerRow;
		private Xceed.Grid.SpacerRow m_alarmSpacerRow;

		private int m_ialarmIndex;

		private string m_sEquipmentID;

		private bool m_bRemoveEquipmentUnit;
		private string m_sOldEquipmentID;

		public EquipmentUnitEdit()
		{
			InitializeComponent();

			m_ialarmIndex = 0;
		}

		private void EquipmentUnitEdit_Load(object sender, EventArgs e)
		{
			SetupDropDowns();
			BindControls();
			SetupAlarmGrid();
			PopulateAlarmGrid();
		}

		private void SetupDropDowns()
		{
			EquipmentType et = new EquipmentType();
			TypeConverter.StandardValuesCollection svcEquipmentType;

			EquipmentLocation el = new EquipmentLocation();
			TypeConverter.StandardValuesCollection svcEquipmentLocation;

			svcEquipmentType = (TypeConverter.StandardValuesCollection)et.GetStandardValues();
			for (int i = 0; i < svcEquipmentType.Count; i++)
				cboEquipmentType.Items.Add(svcEquipmentType[i].ToString());

			svcEquipmentLocation = (TypeConverter.StandardValuesCollection)el.GetStandardValues();
			for (int i = 0; i < svcEquipmentLocation.Count; i++)
				cboEquipmentLocation.Items.Add(svcEquipmentLocation[i].ToString());

			Console.WriteLine("MTDESIZE : " + TLIConfiguration.Vessel.MTDEArray.Count);
			foreach(MTDE mtde in TLIConfiguration.Vessel.MTDEArray)
            {
				mtdeAddrDropdown.Items.Add(mtde.MTDEAddress);
            }

			foreach(AlarmAnnunciation aa in TLIConfiguration.Vessel.AlarmAnnunciation)
				cboAlarmAnnunciation.Items.Add(aa.AlarmAnnunciationName);

			if(cboEquipmentType.Items.Count > 0)
				cboEquipmentType.SelectedIndex = 0;

			if(cboEquipmentLocation.Items.Count > 0)
				cboEquipmentLocation.SelectedIndex = 0;

			if (cboAlarmAnnunciation.Items.Count > 0)
				cboAlarmAnnunciation.SelectedIndex = 0;
		}

		private void BindControls()
		{
			if (m_sEquipmentID != "new")
			{
				if (TLIConfiguration.VesselEquipment.ContainsKey(m_sEquipmentID))
				{
					txtEquipment.Text = TLIConfiguration.VesselEquipment[m_sEquipmentID].Equipment;
					chkEnable.Checked = TLIConfiguration.VesselEquipment[m_sEquipmentID].Enable;
					try { cboEquipmentType.SelectedIndex = cboEquipmentType.Items.IndexOf(TLIConfiguration.VesselEquipment[m_sEquipmentID].EquipmentTypeString); }
					catch { }
					try { cboEquipmentLocation.SelectedIndex = cboEquipmentLocation.Items.IndexOf(TLIConfiguration.VesselEquipment[m_sEquipmentID].EquipmentLocationString); }
					catch { }

					txtSummaryLocationX.Text = TLIConfiguration.VesselEquipment[m_sEquipmentID].SummaryScreenFaceplateLocation.X.ToString();
					txtSummaryLocationY.Text = TLIConfiguration.VesselEquipment[m_sEquipmentID].SummaryScreenFaceplateLocation.Y.ToString();
					chkExportEnable.Checked = TLIConfiguration.VesselEquipment[m_sEquipmentID].ExportEnable;
					txtExportOrder.Text = TLIConfiguration.VesselEquipment[m_sEquipmentID].ExportOrder.ToString();

					chkIndependentOverfillAlarm.Checked = TLIConfiguration.VesselEquipment[m_sEquipmentID].IndependentOverfillAlarm;
					txtIndependentOverfillAlarmPercentage.Text = TLIConfiguration.VesselEquipment[m_sEquipmentID].IndependentOverfillAlarmPercentage.ToString();
					chkIndependentHighLevelAlarm.Checked = TLIConfiguration.VesselEquipment[m_sEquipmentID].IndependentHighLevelAlarm;
					txtIndependentHighLevelAlarmPercentage.Text = TLIConfiguration.VesselEquipment[m_sEquipmentID].IndependentHighLevelAlarmPercentage.ToString();

					chkMTDEEnabled.Checked = TLIConfiguration.VesselEquipment[m_sEquipmentID].MTDEEnable;
					chkMTDEFuelTank.Checked = TLIConfiguration.VesselEquipment[m_sEquipmentID].MTDEFuelTank;
					txtMTDEName.Text = TLIConfiguration.VesselEquipment[m_sEquipmentID].MTDEName.ToString();
					txtMTDEOrder.Text = TLIConfiguration.VesselEquipment[m_sEquipmentID].MTDEOrder.ToString();
					mtdeAddrDropdown.SelectedItem = TLIConfiguration.VesselEquipment[m_sEquipmentID].MTDEAddr;
					

					if(!chkExportEnable.Checked)
						txtExportOrder.Text = (TLIConfiguration.FindMaxExportOrder() + 1).ToString();

					if(!chkMTDEEnabled.Checked)
						txtMTDEOrder.Text = (TLIConfiguration.FindMaxMTDEOrder() + 1).ToString();
				}
				else
					MessageBox.Show("Error retrieving equipment configuration.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
			else
			{
				chkEnable.Checked = true;

				txtExportOrder.Text = (TLIConfiguration.FindMaxExportOrder() + 1).ToString();
				txtMTDEOrder.Text = (TLIConfiguration.FindMaxMTDEOrder() + 1).ToString();
				mtdeAddrDropdown.SelectedItem = 0;
			}

			chkEnable_CheckedChanged(this, new EventArgs());
			chkIndependentOverfillAlarm_CheckedChanged(this, new EventArgs());
			chkIndependentHighLevelAlarm_CheckedChanged(this, new EventArgs());
			chkMTDEEnabled_CheckedChanged(this, new EventArgs());

			cboEquipmentType_SelectedIndexChanged(this, new EventArgs());
		}

		#region Alarm Grid Support
		private void SetupAlarmGrid()
		{
			try
			{
				alarmGrid.SetupGridControl();
				alarmGrid.BeginInit();

				alarmGrid.AllowDelete = true;

				columnManagerRow2.Remove();

				// Custom Column Manager Row
				m_alarmCustomColumnManagerRow = new CustomColumnManagerRow();
				m_alarmCustomColumnManagerRow.BackColor = System.Drawing.Color.White;
				m_alarmCustomColumnManagerRow.ForeColor = System.Drawing.Color.Black;
				m_alarmCustomColumnManagerRow.Height = 17;
				alarmGrid.FixedHeaderRows.Add(m_alarmCustomColumnManagerRow);

				// Insertion Row
				//				m_InsertionRow = new Xceed.Grid.InsertionRow();
				//				m_InsertionRow.ForeColor = Color.FromArgb(29, 50, 139);
				//				m_InsertionRow.BackColor = Color.FromArgb(244, 244, 244);
				//				customXceedGridControl.FixedHeaderRows.Add(m_InsertionRow);

				//				m_InsertionRow.EndingEdit += new CancelEventHandler(EndingEdit);

				// Spacer Row
				m_alarmSpacerRow = new Xceed.Grid.SpacerRow();
				m_alarmSpacerRow.Height = 4;
				alarmGrid.FixedHeaderRows.Add(m_alarmSpacerRow);

				// RowSelectorPane
				alarmGrid.RowSelectorPane.Visible = false;

				alarmGrid.AddBoundColumn("Index", "Index", false, false, 100);
				alarmGrid.AddBoundColumn("AlarmAnnunciationName", "Stop Gauge Annunciation", true, true, 150);

				alarmGrid.Columns["AlarmAnnunciationName"].SortDirection = Xceed.Grid.SortDirection.Ascending;

				alarmGrid.EndInit();
			}
			catch (Exception e)
			{
				MessageBox.Show("Error retrieving configuration data.\n" + e.Message, "TLI Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
		}

		private void PopulateAlarmGrid()
		{
			try
			{
				FillAlarmDataTable();

				alarmGrid.BeginInit();

				alarmGrid.DataSource = m_dtAlarmDataTable;
				alarmGrid.DataMember = "";

				alarmGrid.EndInit();

				alarmGrid.HideUnwantedGridColumns(new string[] { "AlarmAnnunciationName" });
			}
			catch (Exception e)
			{
				MessageBox.Show("Error retrieving configuration data.\n" + e.Message, "TLI Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
		}

		private void FillAlarmDataTable()
		{
			EquipmentUnit eu;
			DataRow dr;

			m_dtAlarmDataTable = new DataTable();

			m_dtAlarmDataTable.Columns.Add("Index", typeof(int));
			m_dtAlarmDataTable.Columns.Add("AlarmAnnunciationName", typeof(string));

			eu = new EquipmentUnit();

			if (TLIConfiguration.VesselEquipment.ContainsKey(m_sEquipmentID))
				eu = TLIConfiguration.VesselEquipment[m_sEquipmentID];

			if (eu.StopGaugeArray.Count > 0)
			{
				for (int i = 0; i < eu.StopGaugeArray[0].AlarmAnnunciation.Count; i++)
				{
					dr = m_dtAlarmDataTable.NewRow();

					dr["Index"] = m_ialarmIndex++;
					dr["AlarmAnnunciationName"] = eu.StopGaugeArray[0].AlarmAnnunciation[i];

					m_dtAlarmDataTable.Rows.Add(dr);
					dr.AcceptChanges();
				}
			}
		}

		private void cmdAddAlarmAnnunciation_Click(object sender, EventArgs e)
		{
			DataTable dt;
			string sAlarmAnnunciationName;

			dt = (DataTable)alarmGrid.DataSource;
			sAlarmAnnunciationName = cboAlarmAnnunciation.Items[cboAlarmAnnunciation.SelectedIndex].ToString();

			bool bFound = false;

			foreach (DataRow dr in dt.Rows)
			{
				if (dr["AlarmAnnunciationName"].ToString() == sAlarmAnnunciationName)
				{
					bFound = true;
					break;
				}
			}

			if (!bFound)
			{
				DataRow dr = dt.NewRow();
				dr["Index"] = m_ialarmIndex++;
				dr["AlarmAnnunciationName"] = sAlarmAnnunciationName;

				dt.Rows.Add(dr);
			}
		}

		#endregion

		private bool ValidateEquipment()
		{
			bool bReturnValue = false;

			int i = 0;
			float f = 0;

			if (txtEquipment.Text == null || txtEquipment.Text == "")
				MessageBox.Show("Name is a required field.", "Equipment Unit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (chkExportEnable.Checked && !int.TryParse(txtExportOrder.Text, out _))
				MessageBox.Show("Export Order must be a valid number.");
			else if (TankEquipment() && !int.TryParse(txtSummaryLocationX.Text, out _))
				MessageBox.Show("Summary Location X must be a valid number.", "Equipment Unit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (TankEquipment() && !int.TryParse(txtSummaryLocationY.Text, out _))
				MessageBox.Show("Summary Location Y must be a valid number.", "Equipment Unit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (TankEquipment() && chkIndependentOverfillAlarm.Checked && !int.TryParse(txtIndependentOverfillAlarmPercentage.Text, out _))
				MessageBox.Show("Overfill Percentage must be a valid number.", "Equipment Unit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (TankEquipment() && chkIndependentHighLevelAlarm.Checked && !int.TryParse(txtIndependentHighLevelAlarmPercentage.Text, out _))
				MessageBox.Show("High Level Percentage must be a valid number.", "Equipment Unit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (TankEquipment() && chkMTDEEnabled.Checked && !int.TryParse(txtMTDEName.Text, out _))
				MessageBox.Show("MTDE Tank Name must be a valid number.", "Equipment Unit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (TankEquipment() && chkMTDEEnabled.Checked && !int.TryParse(txtMTDEOrder.Text, out _))
				MessageBox.Show("MTDE Order must be a valid number.", "Equipment Unit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if ((TankEquipment() && chkIndependentOverfillAlarm.Checked) && int.Parse(txtIndependentOverfillAlarmPercentage.Text) < 0 || int.Parse(txtIndependentOverfillAlarmPercentage.Text) > 100)
				MessageBox.Show("Overfill Percentage must be between 0 and 100.", "Equipment Unit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if ((TankEquipment() && chkIndependentHighLevelAlarm.Checked) && int.Parse(txtIndependentHighLevelAlarmPercentage.Text) < 0 || int.Parse(txtIndependentHighLevelAlarmPercentage.Text) > 100)
				MessageBox.Show("High Level Percentage must be between 0 and 100.", "Equipment Unit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else
				bReturnValue = true;

			// Check for duplicate equipment
			if (bReturnValue)
			{
				string sCurrentEquipmentID = EquipmentUnit.CreateEquipmentID(txtEquipment.Text, EquipmentLocation.GetEquipmentLocation(cboEquipmentLocation.Items[cboEquipmentLocation.SelectedIndex].ToString()), EquipmentType.EquipmentTypeID(cboEquipmentType.Items[cboEquipmentType.SelectedIndex].ToString()));

				if(m_sEquipmentID != sCurrentEquipmentID)
					if(TLIConfiguration.VesselEquipment.ContainsKey(sCurrentEquipmentID))
					{
						MessageBox.Show("This vessel already contains equipment with this Name, Type, and Location.", "Equipment Unit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
						bReturnValue = false;
					}
			}

			return bReturnValue;
		}

		private void SaveConfiguration()
		{
			EquipmentUnit eu;

			string sCurrentEquipmentID = EquipmentUnit.CreateEquipmentID(txtEquipment.Text, EquipmentLocation.GetEquipmentLocation(cboEquipmentLocation.Items[cboEquipmentLocation.SelectedIndex].ToString()), EquipmentType.EquipmentTypeID(cboEquipmentType.Items[cboEquipmentType.SelectedIndex].ToString()));

			if (m_sEquipmentID == "new")
			{
				EquipmentUnit newEu;

                newEu = new EquipmentUnit
                {
                    Equipment = txtEquipment.Text,
                    EquipmentTypeString = cboEquipmentType.Items[cboEquipmentType.SelectedIndex].ToString(),
                    EquipmentLocationString = cboEquipmentLocation.Items[cboEquipmentLocation.SelectedIndex].ToString(),
                    MTDEAddr = (int)mtdeAddrDropdown.SelectedItem
                };

                if (newEu.EquipmentType == EquipmentType.Ballast || newEu.EquipmentType == EquipmentType.Fuel
					|| newEu.EquipmentType == EquipmentType.Misc)
				{
                    newEu.StopGaugeArray = new List<StopGauge>
                    {
                        new StopGauge(false, Guid.NewGuid(), true, newEu.EquipmentID, "", Comparator.GreaterThanOrEqualTo, 80, 0, new List<string>()),
                        new StopGauge(false, Guid.NewGuid(), false, newEu.EquipmentID, "", Comparator.LessThanOrEqualTo, 30, 0, new List<string>())
                    };

                    newEu.StopGaugeArray[0].IndicationColor = Color.Black;
					newEu.StopGaugeArray[1].IndicationColor = Color.Silver;
				}
				else if (newEu.EquipmentType == EquipmentType.Cargo)
				{
                    newEu.StopGaugeArray = new List<StopGauge>
                    {
                        new StopGauge(false, Guid.NewGuid(), true, newEu.EquipmentID, "", Comparator.LessThanOrEqualTo, 80, 0, new List<string>()),
                        new StopGauge(false, Guid.NewGuid(), false, newEu.EquipmentID, "", Comparator.GreaterThanOrEqualTo, 30, 0, new List<string>())
                    };

                    newEu.StopGaugeArray[0].IndicationColor = Color.Black;
					newEu.StopGaugeArray[1].IndicationColor = Color.Silver;
				}

				m_sEquipmentID = newEu.EquipmentID;

				TLIConfiguration.VesselEquipment.Add(m_sEquipmentID, newEu);
			}

			eu = TLIConfiguration.VesselEquipment[m_sEquipmentID];

			if (m_sEquipmentID != "new" && (m_sEquipmentID != sCurrentEquipmentID))
			{
				if (!TLIConfiguration.VesselEquipment.ContainsKey(sCurrentEquipmentID))
				{
					eu.Equipment = txtEquipment.Text;
					eu.EquipmentTypeString = cboEquipmentType.Items[cboEquipmentType.SelectedIndex].ToString();
					eu.EquipmentLocationString = cboEquipmentLocation.Items[cboEquipmentLocation.SelectedIndex].ToString();
					eu.MTDEAddr = (int) mtdeAddrDropdown.SelectedItem;

					TLIConfiguration.VesselEquipment.Add(sCurrentEquipmentID, eu);

					if (TLIConfiguration.VesselGaugePoints.ContainsKey(m_sEquipmentID))
						TLIConfiguration.VesselGaugePoints.Add(sCurrentEquipmentID, TLIConfiguration.VesselGaugePoints[m_sEquipmentID]);

					if (TLIConfiguration.VesselAlarmPoints.ContainsKey(m_sEquipmentID))
						TLIConfiguration.VesselAlarmPoints.Add(sCurrentEquipmentID, TLIConfiguration.VesselAlarmPoints[m_sEquipmentID]);


					if(TLIConfiguration.VesselAlarmPoints.ContainsKey(m_sEquipmentID))
						TLIConfiguration.VesselAlarmPoints.Remove(m_sEquipmentID);

					if(TLIConfiguration.VesselGaugePoints.ContainsKey(m_sEquipmentID))
						TLIConfiguration.VesselGaugePoints.Remove(m_sEquipmentID);

					TLIConfiguration.VesselEquipment.Remove(m_sEquipmentID);

					m_bRemoveEquipmentUnit = true;
					m_sOldEquipmentID = m_sEquipmentID;
					m_sEquipmentID = sCurrentEquipmentID;
				}
				else
				{
					MessageBox.Show("Equipment with the same name, type, and location already exist.", "Equipment Unit", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					return;
				}
			}

			SetEquipmentDisplayName(eu);

			eu.Enable = chkEnable.Checked;
		
			eu.ExportEnable = chkExportEnable.Checked;

			if (eu.ExportEnable)
				eu.ExportOrder = int.Parse(txtExportOrder.Text);
			else 
				eu.ExportOrder = 1;

			if (TankEquipment())
			{
				eu.SummaryScreenFaceplateLocation = new Point(int.Parse(txtSummaryLocationX.Text), int.Parse(txtSummaryLocationY.Text));

				eu.IndependentOverfillAlarm = chkIndependentOverfillAlarm.Checked;
				eu.IndependentOverfillAlarmPercentage = int.Parse(txtIndependentOverfillAlarmPercentage.Text);

				eu.IndependentHighLevelAlarm = chkIndependentHighLevelAlarm.Checked;
				eu.IndependentHighLevelAlarmPercentage = int.Parse(txtIndependentHighLevelAlarmPercentage.Text);

				eu.MTDEEnable = chkMTDEEnabled.Checked;
				eu.MTDEFuelTank = chkMTDEFuelTank.Checked;
				eu.MTDEName = int.Parse(txtMTDEName.Text);
				eu.MTDEOrder = int.Parse(txtMTDEOrder.Text);
				eu.MTDEAddr = (int) mtdeAddrDropdown.SelectedItem;

				DataTable dt = (DataTable)alarmGrid.DataSource;
				foreach (StopGauge sg in eu.StopGaugeArray)
				{
					sg.AlarmAnnunciation.Clear();
					foreach (DataRow dr in dt.Rows)
					{
						if (dr.RowState != DataRowState.Deleted)
							sg.AlarmAnnunciation.Add(dr["AlarmAnnunciationName"].ToString());
					}
				}

			}
			else
			{
				eu.SummaryScreenFaceplateLocation = new Point(int.Parse(txtSummaryLocationX.Text), int.Parse(txtSummaryLocationY.Text));
				eu.TankHeight = 0;
				eu.VolumeMax = 0;
				eu.VolumeMin = 0;

				eu.IndependentOverfillAlarm = false;
				eu.IndependentOverfillAlarmPercentage = 0;

				eu.IndependentHighLevelAlarm = false;
				eu.IndependentHighLevelAlarmPercentage = 0;

				eu.MTDEEnable = false;
				eu.MTDEOrder = 0;
			}

		}

		private void SetEquipmentDisplayName(EquipmentUnit eu)
		{
			switch (eu.EquipmentType)
			{
				case EquipmentType.Ballast:
//					if (eu.DisplayName == null)
						eu.DisplayName = "Ballast_" + eu.Equipment;
					break;
				case EquipmentType.Cargo:
//					if (eu.DisplayName == null)
						eu.DisplayName = "Cargo_" + eu.Equipment;
					break;
				case EquipmentType.Draft:
//					if (eu.DisplayName == null)
						eu.DisplayName = "Draft_" + eu.Equipment;
					break;
				case EquipmentType.Fuel:
//					if (eu.DisplayName == null)
						eu.DisplayName = "Fuel_" + eu.Equipment;
					break;
				case EquipmentType.List:
//					if (eu.DisplayName == null)
						eu.DisplayName = "List_" + eu.Equipment;
					break;
				case EquipmentType.Trim:
//					if (eu.DisplayName == null)
						eu.DisplayName = "Trim_" + eu.Equipment;
					break;
				case EquipmentType.Manifold:
//					if (eu.DisplayName == null)
						eu.DisplayName = "Manifold_" + eu.Equipment;
					break;
				case EquipmentType.Misc:
					eu.DisplayName = "Misc_" + eu.Equipment;
					break;
			}
		}

		private void CmdOk_Click(object sender, EventArgs e)
		{
			if (ValidateEquipment())
			{
				SaveConfiguration();
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void CmdCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		#region Form Customization Events

		private void cboEquipmentLocation_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_sEquipmentID == "new" && cboEquipmentLocation.SelectedIndex >= 0)
			{
				string sEquipmentType = cboEquipmentType.Items[cboEquipmentType.SelectedIndex].ToString();
				int iEquipmentTypeID = EquipmentType.EquipmentTypeID(sEquipmentType);
				string sEquipmentLocation = EquipmentLocation.GetEquipmentLocation(cboEquipmentLocation.Items[cboEquipmentLocation.SelectedIndex].ToString());
				Point pSummaryLocation = TLIConfiguration.GetNextSummaryPosition(iEquipmentTypeID, sEquipmentLocation);

				txtSummaryLocationX.Text = pSummaryLocation.X.ToString();
				txtSummaryLocationY.Text = pSummaryLocation.Y.ToString();
			}
		}
		private void cboEquipmentType_SelectedIndexChanged(object sender, EventArgs e)
		{
			string sEquipmentType = cboEquipmentType.Items[cboEquipmentType.SelectedIndex].ToString();
			int iEquipmentTypeID = EquipmentType.EquipmentTypeID(sEquipmentType);

			if (m_sEquipmentID == "new" && cboEquipmentLocation.SelectedIndex >= 0)
			{
				string sEquipmentLocation = EquipmentLocation.GetEquipmentLocation(cboEquipmentLocation.Items[cboEquipmentLocation.SelectedIndex].ToString());
				Point pSummaryLocation = TLIConfiguration.GetNextSummaryPosition(iEquipmentTypeID, sEquipmentLocation);

				txtSummaryLocationX.Text = pSummaryLocation.X.ToString();
				txtSummaryLocationY.Text = pSummaryLocation.Y.ToString();
			}

			switch (iEquipmentTypeID)
			{
				case EquipmentType.Ballast:
					EquipmentlLocationEnable(true);
					SummaryFaceplateLocationEnable(true);
					GroupIndependentAlarmsEnable(true);
					GroupMTDEEnable(true);
					ExportEnable(true);
					break;
				case EquipmentType.Cargo:
					EquipmentlLocationEnable(true);
					SummaryFaceplateLocationEnable(true);
					GroupIndependentAlarmsEnable(true);
					GroupMTDEEnable(true);
					ExportEnable(true);
					break;
				case EquipmentType.Draft:
					EquipmentlLocationEnable(true);
					SummaryFaceplateLocationEnable(false);
					GroupIndependentAlarmsEnable(false);
					GroupMTDEEnable(false);
					ExportEnable(true);
					break;
				case EquipmentType.Fuel:
					EquipmentlLocationEnable(true);
					SummaryFaceplateLocationEnable(true);
					GroupIndependentAlarmsEnable(true);
					GroupMTDEEnable(true);
					ExportEnable(true);
					break;
				case EquipmentType.List:
					EquipmentlLocationEnable(false);
					SummaryFaceplateLocationEnable(false);
					GroupIndependentAlarmsEnable(false);
					GroupMTDEEnable(false);
					ExportEnable(true);
					break;
				case EquipmentType.Manifold:
					EquipmentlLocationEnable(true);
					SummaryFaceplateLocationEnable(true);
					GroupIndependentAlarmsEnable(false);
					GroupMTDEEnable(false);
					ExportEnable(false);
					break;
				case EquipmentType.Trim:
					EquipmentlLocationEnable(false);
					SummaryFaceplateLocationEnable(false);
					GroupIndependentAlarmsEnable(false);
					GroupMTDEEnable(false);
					ExportEnable(true);
					break;
				case EquipmentType.Misc:
					EquipmentlLocationEnable(true);
					SummaryFaceplateLocationEnable(true);
					GroupIndependentAlarmsEnable(true);
					GroupMTDEEnable(false);
					ExportEnable(true);
					break;
			}
		}
		private void chkEnable_CheckedChanged(object sender, EventArgs e)
		{
			bool bEnable = chkEnable.Checked;

			lblEquipment.Enabled = bEnable;
			txtEquipment.Enabled = bEnable;
			lblEquipmentType.Enabled = bEnable;
			cboEquipmentType.Enabled = bEnable;
			lblEquipmentLocation.Enabled = bEnable;
			cboEquipmentLocation.Enabled = bEnable;
			lblSummaryLocation.Enabled = bEnable;
			lblSummaryLocationX.Enabled = bEnable;
			lblSummaryLocationY.Enabled = bEnable;
			txtSummaryLocationX.Enabled = bEnable;
			txtSummaryLocationY.Enabled = bEnable;
			chkExportEnable.Enabled = bEnable;
			txtExportOrder.Enabled = bEnable;

			if (bEnable && !chkExportEnable.Checked)
				txtExportOrder.Enabled = false;

			grpIndependentAlarm.Enabled = bEnable;
			grpMTDE.Enabled = bEnable;

		}

		private void chkIndependentOverfillAlarm_CheckedChanged(object sender, EventArgs e)
		{
			lblIndependentOverfillAlarmPercentage.Enabled = chkIndependentOverfillAlarm.Checked;
			txtIndependentOverfillAlarmPercentage.Enabled = chkIndependentOverfillAlarm.Checked;
		}

		private void chkIndependentHighLevelAlarm_CheckedChanged(object sender, EventArgs e)
		{
			lblIndependentHighLevelAlarmPercentage.Enabled = chkIndependentHighLevelAlarm.Checked;
			txtIndependentHighLevelAlarmPercentage.Enabled = chkIndependentHighLevelAlarm.Checked;
		}

		private void chkMTDEEnabled_CheckedChanged(object sender, EventArgs e)
		{
			lblMTDEFuelTank.Enabled = chkMTDEEnabled.Checked;
			chkMTDEFuelTank.Enabled = chkMTDEEnabled.Checked;
			lblMTDEName.Enabled = chkMTDEEnabled.Checked;
			txtMTDEName.Enabled = chkMTDEEnabled.Checked;
			lblMTDEOrder.Enabled = chkMTDEEnabled.Checked;
			txtMTDEOrder.Enabled = chkMTDEEnabled.Checked;
		}

		private void chkExportEnable_CheckedChanged(object sender, EventArgs e)
		{
			txtExportOrder.Enabled = chkExportEnable.Checked;
		}

		#endregion

		#region Form Customization Helpers

		private bool TankEquipment()
		{
			string sEquipmentType = cboEquipmentType.Items[cboEquipmentType.SelectedIndex].ToString();
			int iEquipmentTypeID = EquipmentType.EquipmentTypeID(sEquipmentType);

			switch (iEquipmentTypeID)
			{
				case EquipmentType.Ballast:
					return true;
				case EquipmentType.Cargo:
					return true;
				case EquipmentType.Draft:
					return false;
				case EquipmentType.Fuel:
					return true;
				case EquipmentType.List:
					return false;
				case EquipmentType.Manifold:
					return false;
				case EquipmentType.Trim:
					return false;
				case EquipmentType.Misc:
					return true;
				default: return false;
			}
		}

		private void EquipmentlLocationEnable(bool bEnable)
		{
			lblEquipmentLocation.Enabled = bEnable;
			cboEquipmentLocation.Enabled = bEnable;
		}

		private void SummaryFaceplateLocationEnable(bool bEnable)
		{
			lblSummaryLocation.Enabled = bEnable;
			lblSummaryLocationX.Enabled = bEnable;
			lblSummaryLocationY.Enabled = bEnable;
			txtSummaryLocationX.Enabled = bEnable;
			txtSummaryLocationY.Enabled = bEnable;
		}

		private void ExportEnable(bool bEnable)
		{
			chkExportEnable.Enabled = bEnable;
			txtExportOrder.Enabled = bEnable;

			if (bEnable && !chkExportEnable.Checked)
				txtExportOrder.Enabled = false;
		}

		private void GroupIndependentAlarmsEnable(bool bEnable)
		{
			grpIndependentAlarm.Enabled = bEnable;
		}

		private void GroupMTDEEnable(bool bEnable)
		{
			grpMTDE.Enabled = bEnable;
		}
		#endregion

		public string EquipmentID
		{
			get { return m_sEquipmentID; }
			set { m_sEquipmentID = value; }
		}

		public bool RemoveEquipmentUnit
		{
			get { return m_bRemoveEquipmentUnit; }
		}

		public string OldEquipmentID
		{
			get { return m_sOldEquipmentID; }
		}

		private void EquipmentUnitEdit_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Escape)
				Close();
		}

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}