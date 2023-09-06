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
 * CLASS SUMMARY:	AlarmPointEdit
 * 
 * AlarmPointEdit is the form used by users to specify AlarmPoint parameters.
 * 
 */

namespace TLIConfiguration
{
	public partial class AlarmPointEdit : Form
	{
		private bool m_bNewAlarm;

		private string m_sEquipmentID;
		private string m_sProcessID;
		private Guid m_guidAlarmID;

		private DataTable m_dtDataTable;

		private CustomColumnManagerRow m_alarmCustomColumnManagerRow;
		private Xceed.Grid.SpacerRow m_alarmSpacerRow;

		private int m_ialarmIndex;

		public AlarmPointEdit()
		{
			InitializeComponent();

			m_bNewAlarm = false;

			m_ialarmIndex = 0;
		}

		private void AlarmPointEdit_Load(object sender, EventArgs e)
		{
			SetupDropDowns();
			BindControls();
			SetupGrid();
			PopulateGrid();
		}

		private void SetupDropDowns()
		{
			AlarmMonitorType amt = new AlarmMonitorType();
			TypeConverter.StandardValuesCollection svcAlarmMonitorType;

			AlarmType at = new AlarmType();
			TypeConverter.StandardValuesCollection svcAlarmType;

			Comparator cc = new Comparator();
			TypeConverter.StandardValuesCollection svcComparator;

			svcAlarmMonitorType = (TypeConverter.StandardValuesCollection)amt.GetStandardValues();
			for (int i = 0; i < svcAlarmMonitorType.Count; i++)
				cboAlarmMonitorType.Items.Add(svcAlarmMonitorType[i].ToString());

			svcAlarmType = (TypeConverter.StandardValuesCollection)at.GetStandardValues();
			for (int i = 0; i < svcAlarmType.Count; i++)
				cboAlarmType.Items.Add(svcAlarmType[i].ToString());

			foreach (AlarmPriority ap in TLIConfiguration.Vessel.AlarmPriority)
				cboAlarmPriority.Items.Add(ap.Priority.ToString());

			svcComparator = (TypeConverter.StandardValuesCollection)cc.GetStandardValues();
			for (int i = 0; i < svcComparator.Count; i++)
				cboComparator.Items.Add(svcComparator[i].ToString());

			foreach (AlarmAnnunciation aa in TLIConfiguration.Vessel.AlarmAnnunciation)
				cboAlarmAnnunciation.Items.Add(aa.AlarmAnnunciationName);

			if (cboAlarmMonitorType.Items.Count > 0)
				cboAlarmMonitorType.SelectedIndex = 0;

			if (cboAlarmType.Items.Count > 0)
				cboAlarmType.SelectedIndex = 0;

			if (cboAlarmPriority.Items.Count > 0)
				cboAlarmPriority.SelectedIndex = 0;

			if (cboComparator.Items.Count > 0)
				cboComparator.SelectedIndex = 0;

			if (cboAlarmAnnunciation.Items.Count > 0)
				cboAlarmAnnunciation.SelectedIndex = 0;
		}

		private void BindControls()
		{
			if (!m_bNewAlarm)
			{
				if (TLIConfiguration.VesselAlarmPoints.ContainsKey(m_sEquipmentID))
					if (TLIConfiguration.VesselAlarmPoints[m_sEquipmentID].ContainsKey(m_sProcessID))
						if (TLIConfiguration.VesselAlarmPoints[m_sEquipmentID][m_sProcessID].ContainsKey(m_guidAlarmID))
						{
							AlarmPoint ap = TLIConfiguration.VesselAlarmPoints[m_sEquipmentID][m_sProcessID][m_guidAlarmID];

							txtDisplayName.Text = ap.DisplayName;
							chkEnable.Checked = ap.Enable;
							try { cboAlarmMonitorType.SelectedIndex = cboAlarmMonitorType.Items.IndexOf(ap.AlarmMonitorTypeString); }
							catch { }
							try { cboAlarmType.SelectedIndex = cboAlarmType.Items.IndexOf(ap.AlarmTypeString); }
							catch { }
							try { cboAlarmPriority.SelectedIndex = cboAlarmPriority.Items.IndexOf(ap.AlarmPriority.ToString()); }
							catch { }
							txtAlarmText.Text = ap.AlarmText;

							txtLimit.Text = ap.Limit.ToString("f4");
							try { cboComparator.SelectedIndex = cboComparator.Items.IndexOf(ap.ComparatorString); }
							catch { }
							txtDebounceTimer.Text = ap.DebounceTimer.ToString();
							txtTrailingDebounceTimer.Text = ap.TrailingDebounceTimer.ToString();
							txtAlarmDeadband.Text = ap.AlarmDeadband.ToString("f4");
							chkAutoClear.Checked = ap.AutoClearEnable;
						}
			}
			else
			{
				chkEnable.Checked = true;
			}

			chkEnable_CheckedChanged(this, new EventArgs());
			cboAlarmMonitorType_SelectedIndexChanged(this, new EventArgs());
		}

		#region Form Customization Events


		private void cboAlarmPriority_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_bNewAlarm)
			{
				int iAlarmPriority, iAlarmMonitorType;
				string sAlarmMonitorType;

				try
				{
					sAlarmMonitorType = cboAlarmMonitorType.Items[cboAlarmMonitorType.SelectedIndex].ToString();
					iAlarmMonitorType = AlarmMonitorType.AlarmMonitorTypeID(sAlarmMonitorType);
				}
				catch
				{
					iAlarmMonitorType = 0;
				}

				try { iAlarmPriority = Convert.ToInt32(cboAlarmPriority.Items[cboAlarmPriority.SelectedIndex]); }
				catch { iAlarmPriority = 0; }

				if (iAlarmMonitorType == AlarmMonitorType.ChannelAlarmState)
				{
					if (iAlarmPriority == 1)
						txtAlarmText.Text = "Overfill Alarm";
					else if (iAlarmPriority == 2)
						txtAlarmText.Text = "High Level Alarm";
				}
				else
					txtAlarmText.Text = "";
			}
		}

		private void cboAlarmMonitorType_SelectedIndexChanged(object sender, EventArgs e)
		{
			int iAlarmPriority;
			string sAlarmMonitorType = cboAlarmMonitorType.Items[cboAlarmMonitorType.SelectedIndex].ToString();
			int iAlarmMonitorType = AlarmMonitorType.AlarmMonitorTypeID(sAlarmMonitorType);

			try { iAlarmPriority = Convert.ToInt32(cboAlarmPriority.Items[cboAlarmPriority.SelectedIndex]); }
			catch { iAlarmPriority = 0; }

			switch (iAlarmMonitorType)
			{
				case AlarmMonitorType.AnalogValue:
					lblLimit.Enabled = true;
					txtLimit.Enabled = true;
					lblComparator.Enabled = true;
					cboComparator.Enabled = true;
					lblAlarmDeadband.Enabled = true;
					txtAlarmDeadband.Enabled = true;

					if (m_bNewAlarm)
						txtAlarmText.Text = "";
					break;
				case AlarmMonitorType.AnalogValue2:
					lblLimit.Enabled = true;
					txtLimit.Enabled = true;
					lblComparator.Enabled = true;
					cboComparator.Enabled = true;
					lblAlarmDeadband.Enabled = true;
					txtAlarmDeadband.Enabled = true;

					if (m_bNewAlarm)
						txtAlarmText.Text = "";
					break;
				case AlarmMonitorType.ChannelAlarmState:
					lblLimit.Enabled = false;
					txtLimit.Enabled = false;
					lblComparator.Enabled = false;
					cboComparator.Enabled = false;
					lblAlarmDeadband.Enabled = false;
					txtAlarmDeadband.Enabled = false;

					if (m_bNewAlarm)
					{
						if (iAlarmPriority == 1)
							txtAlarmText.Text = "Overfill Alarm";
						else if (iAlarmPriority == 2)
							txtAlarmText.Text = "High Level Alarm";
						else
							txtAlarmText.Text = "";
					}

					break;
				case AlarmMonitorType.ChannelCondition:
					lblLimit.Enabled = false;
					txtLimit.Enabled = false;
					lblComparator.Enabled = false;
					cboComparator.Enabled = false;
					lblAlarmDeadband.Enabled = false;
					txtAlarmDeadband.Enabled = false;

					if (m_bNewAlarm)
						txtAlarmText.Text = "Cable Error";
					break;
				case AlarmMonitorType.DigitalValue:
					lblLimit.Enabled = true;
					txtLimit.Enabled = true;
					lblComparator.Enabled = true;
					cboComparator.Enabled = true;
					lblAlarmDeadband.Enabled = true;
					txtAlarmDeadband.Enabled = true;

					if (m_bNewAlarm)
						txtAlarmText.Text = "";
					break;
			}
		}

		private void chkEnable_CheckedChanged(object sender, EventArgs e)
		{
			bool bEnable = chkEnable.Checked;

			lblDisplayName.Enabled = bEnable;
			txtDisplayName.Enabled = bEnable;
			lblAlarmMonitorType.Enabled = bEnable;
			cboAlarmMonitorType.Enabled = bEnable;
			lblAlarmType.Enabled = bEnable;
			cboAlarmType.Enabled = bEnable;
			lblAlarmPriority.Enabled = bEnable;
			cboAlarmPriority.Enabled = bEnable;
			lblAlarmText.Enabled = bEnable;
			txtAlarmText.Enabled = bEnable;

			grpEngineering.Enabled = bEnable;
			grpAlarmAnnunciation.Enabled = bEnable;
		}
		#endregion

		#region Grid Support
		private void SetupGrid()
		{
			try
			{
				alarmGrid.SetupGridControl();
				alarmGrid.BeginInit();

				alarmGrid.AllowDelete = true;

				columnManagerRow1.Remove();

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
				alarmGrid.AddBoundColumn("AlarmAnnunciationName", "Alarm Annunciation", true, true, 150);

				alarmGrid.Columns["AlarmAnnunciationName"].SortDirection = Xceed.Grid.SortDirection.Ascending;

				alarmGrid.EndInit();
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

				alarmGrid.BeginInit();

				alarmGrid.DataSource = m_dtDataTable;
				alarmGrid.DataMember = "";

				alarmGrid.EndInit();

				alarmGrid.HideUnwantedGridColumns(new string[] { "AlarmAnnunciationName" });
			}
			catch (Exception e)
			{
				MessageBox.Show("Error retrieving configuration data.\n" + e.Message, "TLI Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
		}

		private void FillDataTable()
		{
			AlarmPoint ap;
			DataRow dr;
			m_dtDataTable = new DataTable();

			m_dtDataTable.Columns.Add("Index", typeof(int));
			m_dtDataTable.Columns.Add("AlarmAnnunciationName", typeof(string));

			ap = new AlarmPoint();

			if (TLIConfiguration.VesselAlarmPoints.ContainsKey(m_sEquipmentID))
				if (TLIConfiguration.VesselAlarmPoints[m_sEquipmentID].ContainsKey(m_sProcessID))
					if (TLIConfiguration.VesselAlarmPoints[m_sEquipmentID][m_sProcessID].ContainsKey(m_guidAlarmID))
						ap = TLIConfiguration.VesselAlarmPoints[m_sEquipmentID][m_sProcessID][m_guidAlarmID];

			if(m_bNewAlarm)
			{
				foreach (AlarmAnnunciation aa in TLIConfiguration.Vessel.AlarmAnnunciation)
					if (aa.AlarmAnnunciationName == "Summary Alarm")
						ap.AlarmAnnunciation.Add("Summary Alarm");

			}

			for (int i = 0; i < ap.AlarmAnnunciation.Count; i++)
			{
				dr = m_dtDataTable.NewRow();

				dr["Index"] = m_ialarmIndex++;
				dr["AlarmAnnunciationName"] = ap.AlarmAnnunciation[i];

				m_dtDataTable.Rows.Add(dr);
				dr.AcceptChanges();
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

		private bool ValidateAlarmPoint()
		{
			bool bReturnValue = false;

			int i = 0;
			float f = 0;

			if (txtDisplayName.Text == null || txtDisplayName.Text == "")
				MessageBox.Show("Name is a required field.", "Alarm Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (txtAlarmText.Text == null || txtAlarmText.Text == "")
				MessageBox.Show("Text is a required field.", "Alarm Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (!float.TryParse(txtLimit.Text, out f))
				MessageBox.Show("Limit must be a valid number.", "Alarm Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (!int.TryParse(txtDebounceTimer.Text, out i))
				MessageBox.Show("Debounce Timer must be a valid number.", "Alarm Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (!int.TryParse(txtTrailingDebounceTimer.Text, out i))
				MessageBox.Show("Trailing Debounce Timer must be a valid number.", "Alarm Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (!float.TryParse(txtAlarmDeadband.Text, out f))
				MessageBox.Show("Auto Deadband must be a valid number.", "Alarm Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else
				bReturnValue = true;
			
			
			return bReturnValue;
		}

		private void SaveConfiguration()
		{
			if (m_bNewAlarm)
			{
				AlarmPoint newAp = new AlarmPoint();
				newAp.AlarmID = Guid.NewGuid();

				if (!TLIConfiguration.VesselAlarmPoints.ContainsKey(m_sEquipmentID))
					TLIConfiguration.VesselAlarmPoints.Add(m_sEquipmentID, new Dictionary<string,Dictionary<Guid,AlarmPoint>>());

				if (!TLIConfiguration.VesselAlarmPoints[m_sEquipmentID].ContainsKey(m_sProcessID))
					TLIConfiguration.VesselAlarmPoints[m_sEquipmentID].Add(m_sProcessID, new Dictionary<Guid, AlarmPoint>());

				TLIConfiguration.VesselAlarmPoints[m_sEquipmentID][m_sProcessID].Add(newAp.AlarmID, newAp);

				m_guidAlarmID = newAp.AlarmID;
			}

			AlarmPoint ap = TLIConfiguration.VesselAlarmPoints[m_sEquipmentID][m_sProcessID][m_guidAlarmID];

			ap.AlarmDeadband = Convert.ToSingle(txtAlarmDeadband.Text);
			ap.AlarmGroup = "Alarm";
			ap.AlarmMonitorTypeString = cboAlarmMonitorType.Items[cboAlarmMonitorType.SelectedIndex].ToString();
			ap.AlarmPriority = Convert.ToInt32(cboAlarmPriority.Items[cboAlarmPriority.SelectedIndex]);
			ap.AlarmText = txtAlarmText.Text;
			ap.AlarmTypeString = cboAlarmType.Items[cboAlarmType.SelectedIndex].ToString();
			ap.AutoClearEnable = chkAutoClear.Checked;
			ap.ComparatorString = cboComparator.Items[cboComparator.SelectedIndex].ToString();
			ap.DebounceTimer = Convert.ToInt32(txtDebounceTimer.Text);
			ap.TrailingDebounceTimer = Convert.ToInt32(txtTrailingDebounceTimer.Text);
			ap.DisplayName = txtDisplayName.Text;
			ap.Enable = chkEnable.Checked;
			ap.Limit = Convert.ToSingle(txtLimit.Text);

			DataTable dt = (DataTable)alarmGrid.DataSource;

			ap.AlarmAnnunciation.Clear();

			foreach (DataRow dr in dt.Rows)
			{
				if (dr.RowState != DataRowState.Deleted)
					ap.AlarmAnnunciation.Add(dr["AlarmAnnunciationName"].ToString());
			}
		}

		private void cmdOk_Click(object sender, EventArgs e)
		{
			if (ValidateAlarmPoint())
			{
				SaveConfiguration();
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		public bool NewAlarm
		{
			get { return m_bNewAlarm; }
			set { m_bNewAlarm = value; }
		}

		public string EquipmentID
		{
			get { return m_sEquipmentID; }
			set { m_sEquipmentID = value; }
		}

		public string ProcessID
		{
			get { return m_sProcessID; }
			set { m_sProcessID = value; }
		}

		public Guid AlarmID
		{
			get { return m_guidAlarmID; }
			set { m_guidAlarmID = value; }
		}

		private void AlarmPointEdit_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Escape)
				this.Close();
		}
	}
}