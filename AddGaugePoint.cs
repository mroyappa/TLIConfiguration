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
 * CLASS SUMMARY:	AddGaugePoint
 * 
 * This is the original form used to add a GaugePoint to an EquipmentUnit.  It is no longer used.
 * 
 */

namespace TLIConfiguration
{
	public partial class AddGaugePoint : Form
	{
		GaugePoint m_GaugePoint;
		string m_sEquipmentID;

		public AddGaugePoint()
		{
			InitializeComponent();
		}

		private void AddGaugePoint_Load(object sender, EventArgs e)
		{
			BindControls();
		}

		private void BindControls()
		{
			GaugeType gt = new GaugeType();
			TypeConverter.StandardValuesCollection svcGaugeType;

			svcGaugeType = (TypeConverter.StandardValuesCollection)gt.GetStandardValues();
			for (int i = 0; i < svcGaugeType.Count; i++)
				cboGaugeType.Items.Add(svcGaugeType[i]);

			for (int i = 1; i < 4; i++)
				cboGaugeNumber.Items.Add(i.ToString());

			if(cboGaugeType.Items.Count > 0)
				cboGaugeType.SelectedIndex = 0;

			cboGaugeNumber.SelectedIndex = 0;
		}

		private bool ValidateInput()
		{
			m_GaugePoint = new GaugePoint();
			m_GaugePoint.Enable = true;
			m_GaugePoint.GaugeTypeString = cboGaugeType.Items[cboGaugeType.SelectedIndex].ToString();
			m_GaugePoint.GaugeNumber = Convert.ToInt32(cboGaugeNumber.Items[cboGaugeNumber.SelectedIndex]);
			m_GaugePoint.ProcessID = m_GaugePoint.CreateProcessID(m_sEquipmentID);
			m_GaugePoint.DisplayName = txtDisplayName.Text == "" ? m_GaugePoint.ProcessID : txtDisplayName.Text;

			if(TLIConfiguration.VesselGaugePoints.ContainsKey(m_sEquipmentID))
			{
				if (TLIConfiguration.VesselGaugePoints[m_sEquipmentID].ContainsKey(m_GaugePoint.ProcessID))
				{
					MessageBox.Show(this, "This equipment unit already contains a gauge point with this Type and Number.", "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					return false;
				}
			}
			
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
		}

		public GaugePoint GaugePoint
		{
			get { return m_GaugePoint; }
		}

		public string EquipmentID
		{
			set { m_sEquipmentID = value; }
		}
	}
}