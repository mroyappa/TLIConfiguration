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
 * CLASS SUMMARY:	AddAlarmPoint
 * 
 * This is the original form used to add an AlarmPoint to a GaugePoint.  It is no longer used.
 * 
 */

namespace TLIConfiguration
{
	public partial class AddAlarmPoint : Form
	{
		AlarmPoint m_AlarmPoint;
		string m_sEquipmentID;
		string m_sProcessID;

		public AddAlarmPoint()
		{
			InitializeComponent();
		}

		private void AddAlarmPoint_Load(object sender, EventArgs e)
		{
			BindControls();
		}

		private void BindControls()
		{
			AlarmMonitorType amt = new AlarmMonitorType();
			TypeConverter.StandardValuesCollection svcAlarmMonitorType;

			AlarmType at = new AlarmType();
			TypeConverter.StandardValuesCollection svcAlarmType;

			svcAlarmMonitorType = (TypeConverter.StandardValuesCollection)amt.GetStandardValues();
			for (int i = 0; i < svcAlarmMonitorType.Count; i++)
				cboAlarmMonitorType.Items.Add(svcAlarmMonitorType[i]);

			svcAlarmType = (TypeConverter.StandardValuesCollection)at.GetStandardValues();
			for (int i = 0; i < svcAlarmType.Count; i++)
				cboAlarmType.Items.Add(svcAlarmType[i]);

			if (cboAlarmMonitorType.Items.Count > 0)
				cboAlarmMonitorType.SelectedIndex = 0;

			if (cboAlarmType.Items.Count > 0)
				cboAlarmType.SelectedIndex = 0;
		}

		private bool ValidateInput()
		{
			int iTryParse;

			if (!int.TryParse(txtAlarmPriority.Text, out iTryParse))
			{
				MessageBox.Show(this, "Priority must be a number.", "Alarm Point", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
				return false;
			}
			else if (txtAlarmGroup.Text == null || txtAlarmGroup.Text == "")
			{
				MessageBox.Show(this, "Please specify a value for group.", "Alarm Point", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
				return false;
			}
			else if (txtAlarmText == null || txtAlarmText.Text == "")
			{
				MessageBox.Show(this, "Please specify a value for text.", "Alarm Point", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
				return false;
			}

			m_AlarmPoint = new AlarmPoint();
			m_AlarmPoint.AlarmID = Guid.NewGuid();
			m_AlarmPoint.Enable = true;
			m_AlarmPoint.AlarmMonitorTypeString = cboAlarmMonitorType.Items[cboAlarmMonitorType.SelectedIndex].ToString();
			m_AlarmPoint.AlarmTypeString = cboAlarmType.Items[cboAlarmType.SelectedIndex].ToString();
			m_AlarmPoint.AlarmPriority = Convert.ToInt32(txtAlarmPriority.Text);
			m_AlarmPoint.AlarmGroup = txtAlarmGroup.Text;
			m_AlarmPoint.AlarmText = txtAlarmText.Text;
			m_AlarmPoint.DisplayName = txtDisplayName.Text == "" ? m_AlarmPoint.AlarmID.ToString() : txtDisplayName.Text;

			return true;
		}

		private void cmdOk_Click(object sender, EventArgs e)
		{
			if (ValidateInput())
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		public AlarmPoint AlarmPoint
		{
			get { return m_AlarmPoint; }
		}

		public string EquipmentID
		{
			set { m_sEquipmentID = value; }
		}

		public string ProcessID
		{
			set { m_sProcessID = value; }
		}
	}
}