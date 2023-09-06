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
 * CLASS SUMMARY:	VesselPropertiesEdit
 * 
 * VesselPropertiesEdit is the form used by users to specify Vessel level parameters.
 * 
 */

namespace TLIConfiguration
{
	public partial class VesselPropertiesEdit : Form
	{
		public VesselPropertiesEdit()
		{
			InitializeComponent();
		}

		private void VesselPropertiesEdit_Load(object sender, EventArgs e)
		{
			SetupDropDowns();
			BindControls();
		}

		private void SetupDropDowns()
		{
			VesselType vt = new VesselType();
			TypeConverter.StandardValuesCollection svcVesselType;

			MeasurementSystem ms = new MeasurementSystem();
			TypeConverter.StandardValuesCollection svcMeasurementSystem;

			svcVesselType = (TypeConverter.StandardValuesCollection)vt.GetStandardValues();
			for (int i = 0; i < svcVesselType.Count; i++)
				cboVesselType.Items.Add(svcVesselType[i]);

			svcMeasurementSystem = (TypeConverter.StandardValuesCollection)ms.GetStandardValues();
			for (int i = 0; i < svcMeasurementSystem.Count; i++)
				cboMeasurementSystem.Items.Add(svcMeasurementSystem[i]);

			cboDCUnits.Items.Add(Units.UnitsString(Units.Inches));
			cboDCUnits.Items.Add(Units.UnitsString(Units.Millimeters));

			if (cboVesselType.Items.Count > 0)
				cboVesselType.SelectedIndex = 0;

			if (cboMeasurementSystem.Items.Count > 0)
				cboMeasurementSystem.SelectedIndex = 0;

			if (cboDCUnits.Items.Count > 0)
				cboDCUnits.SelectedIndex = 0;
		}

		private void BindControls()
		{
			txtVessel.Text = TLIConfiguration.Vessel.VesselName;
			try { cboVesselType.SelectedIndex = cboVesselType.Items.IndexOf(TLIConfiguration.Vessel.VesselTypeString); }	catch { }
			txtOwner.Text = TLIConfiguration.Vessel.Owner;
			txtClass.Text = TLIConfiguration.Vessel.Class;
			txtYard.Text = TLIConfiguration.Vessel.Yard;
			txtYardNo.Text = TLIConfiguration.Vessel.YardNo;

			chkFaceplateTrendEnable.Checked = TLIConfiguration.Vessel.FaceplateTrendEnable;
			txtFaceplateTrendTimeout.Text = TLIConfiguration.Vessel.FaceplateTrendTimeout.ToString();
			try { cboMeasurementSystem.SelectedIndex = cboMeasurementSystem.Items.IndexOf(TLIConfiguration.Vessel.MeasurementSystemString); }	catch { }
			txtSystemWarning.Text = TLIConfiguration.Vessel.SystemWarning;

			txtConfiguredBy.Text = TLIConfiguration.Vessel.ConfiguredBy;
			dtConfigured.Value = TLIConfiguration.Vessel.Configured == DateTime.MinValue ? DateTime.Now : TLIConfiguration.Vessel.Configured;
			txtCommissioningEngineer.Text = TLIConfiguration.Vessel.CommissioningEngineer;
			dtWarrantyExpiration.Value = TLIConfiguration.Vessel.WarrantyExpiration == DateTime.MinValue ? DateTime.Now :TLIConfiguration.Vessel.WarrantyExpiration;
			txtConfigurationHistory.Text = TLIConfiguration.Vessel.ConfigurationHistory;

			chkDCEnabled.Checked = TLIConfiguration.Vessel.DCEnabled;
			try { cboDCUnits.SelectedIndex = cboDCUnits.Items.IndexOf(TLIConfiguration.Vessel.DCUnitsString); } catch { }
			txtDCStarboardSensorMarkDistance.Text = TLIConfiguration.Vessel.DCStarboardSensorMarkDistance.ToString("f2");
			txtDCPortSensorMarkDistance.Text = TLIConfiguration.Vessel.DCPortSensorMarkDistance.ToString("f2");
			txtDCStarboardPortSensorDistance.Text = TLIConfiguration.Vessel.DCStarboardPortSensorDistance.ToString("f2");
			txtDCForeSensorMarkDistance.Text = TLIConfiguration.Vessel.DCForeSensorMarkDistance.ToString("f2");
			txtDCAftSensorMarkDistance.Text = TLIConfiguration.Vessel.DCAftSensorMarkDistance.ToString("f2");
			txtDCForeAftSensorDistance.Text = TLIConfiguration.Vessel.DCForeAftSensorDistance.ToString("f2");
		}

		private bool ValidateForm()
		{
			int i = 0;

			if (TLIConfiguration.Vessel.VesselName == null || TLIConfiguration.Vessel.VesselName == "")
			{
				MessageBox.Show("Vessel Name can not be blank.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return false;
			}
			else if(!int.TryParse(txtFaceplateTrendTimeout.Text, out i))
			{
				MessageBox.Show("Trend Arrow Timeout must be a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return false;
			}
			else
				return true;
		}

		private void SaveConfiguration()
		{
			TLIConfiguration.Vessel.VesselName = txtVessel.Text;
			TLIConfiguration.Vessel.DisplayName = txtVessel.Text;
			TLIConfiguration.Vessel.VesselTypeString = cboVesselType.Items[cboVesselType.SelectedIndex].ToString();
			TLIConfiguration.Vessel.Owner = txtOwner.Text;
			TLIConfiguration.Vessel.Class = txtClass.Text;
			TLIConfiguration.Vessel.Yard = txtYard.Text;
			TLIConfiguration.Vessel.YardNo = txtYardNo.Text;

			TLIConfiguration.Vessel.FaceplateTrendEnable = chkFaceplateTrendEnable.Checked;
			TLIConfiguration.Vessel.FaceplateTrendTimeout = Convert.ToInt32(txtFaceplateTrendTimeout.Text);
			TLIConfiguration.Vessel.MeasurementSystemString = cboMeasurementSystem.Items[cboMeasurementSystem.SelectedIndex].ToString();
			TLIConfiguration.Vessel.SystemWarning = txtSystemWarning.Text;

			TLIConfiguration.Vessel.ConfiguredBy = txtConfiguredBy.Text;
			TLIConfiguration.Vessel.Configured = dtConfigured.Value;
			TLIConfiguration.Vessel.CommissioningEngineer = txtCommissioningEngineer.Text;
			TLIConfiguration.Vessel.WarrantyExpiration = dtWarrantyExpiration.Value;
			TLIConfiguration.Vessel.ConfigurationHistory = txtConfigurationHistory.Text;

			TLIConfiguration.Vessel.DCEnabled = chkDCEnabled.Checked;
			TLIConfiguration.Vessel.DCUnitsString = cboDCUnits.Items[cboDCUnits.SelectedIndex].ToString();
			TLIConfiguration.Vessel.DCStarboardSensorMarkDistance = Convert.ToSingle(txtDCStarboardSensorMarkDistance.Text);
			TLIConfiguration.Vessel.DCPortSensorMarkDistance = Convert.ToSingle(txtDCPortSensorMarkDistance.Text);
			TLIConfiguration.Vessel.DCStarboardPortSensorDistance = Convert.ToSingle(txtDCStarboardPortSensorDistance.Text);
			TLIConfiguration.Vessel.DCForeSensorMarkDistance = Convert.ToSingle(txtDCForeSensorMarkDistance.Text);
			TLIConfiguration.Vessel.DCAftSensorMarkDistance = Convert.ToSingle(txtDCAftSensorMarkDistance.Text);
			TLIConfiguration.Vessel.DCForeAftSensorDistance = Convert.ToSingle(txtDCForeAftSensorDistance.Text);
		}

		private void cmdOk_Click(object sender, EventArgs e)
		{
			if (ValidateForm())
			{
				SaveConfiguration();
				this.Close();
			}
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void chkFaceplateTrendEnable_CheckedChanged(object sender, EventArgs e)
		{
			if (chkFaceplateTrendEnable.Checked)
			{
				lblFaceplateTrendTimeout.Enabled = true;
				txtFaceplateTrendTimeout.Enabled = true;
			}
			else
			{
				lblFaceplateTrendTimeout.Enabled = false;
				txtFaceplateTrendTimeout.Enabled = false;
			}
		}
	}
}