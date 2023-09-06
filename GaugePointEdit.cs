using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ICBObjectModel;
using ICBObjectModel.Enumerations;
using System.IO;

/*
 * CLASS SUMMARY:	GaugePointEdit
 * 
 * GaugePointEdit is the form used by users to specify GaugePoint parameters.
 * 
 */

namespace TLIConfiguration
{
	public partial class GaugePointEdit : Form
	{
		private string m_sEquipmentID;
		private string m_sProcessID;

		private EquipmentUnit m_euCurrentEU;

		private int m_iIndex;
		private DataTable m_dtDataTable;
		private CustomColumnManagerRow m_CustomColumnManagerRow;
		private Xceed.Grid.InsertionRow m_InsertionRow;
		private Xceed.Grid.DataRow m_EditRow;
		private Xceed.Grid.SpacerRow m_SpacerRow;

		private string m_sAverageTemperatureProcessID;

		private bool m_bRemoveGaugePoint;
		private string m_sOldProcessID;
		private bool m_bEngineeringEnabled;

		public GaugePointEdit()
		{
			InitializeComponent();

			m_iIndex = 0;
			m_sAverageTemperatureProcessID = "";
		}

		#region Form Specific Events & Form Initialization

		private void GaugePointEdit_Load(object sender, EventArgs e)
		{
			m_euCurrentEU = TLIConfiguration.VesselEquipment[m_sEquipmentID];
			SetupDropDowns();
			BindControls();
			SetupGrid();
			PopulateGrid();
		}

		private void cmdOk_Click(object sender, EventArgs e)
		{
			if (ValidateGaugePoint())
			{
				if (ValidateUnits())
				{
					SaveConfiguration();
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
			}
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void SetupDropDowns()
		{
			GaugeType gt = new GaugeType();
			TypeConverter.StandardValuesCollection svcGaugeType;

			Units units = new Units();
			TypeConverter.StandardValuesCollection svcUnits;

			IOType iot = new IOType();
			TypeConverter.StandardValuesCollection svcIOType;

			TAUChannelGroupType cgt = new TAUChannelGroupType();
			TypeConverter.StandardValuesCollection svcChannelGroupType;

			DFGFloat df = new DFGFloat();
			TypeConverter.StandardValuesCollection svcDFGFloat;

			svcGaugeType = (TypeConverter.StandardValuesCollection)gt.GetStandardValues();
			for (int i = 0; i < svcGaugeType.Count; i++)
				cboGaugeType.Items.Add(svcGaugeType[i].ToString());

			cboGaugeNumber.Items.Add("1");
			cboGaugeNumber.Items.Add("2");
			cboGaugeNumber.Items.Add("3");
			cboGaugeNumber.Items.Add(GetGaugeNumberDescription(GaugeType.Temperature, 1));
			cboGaugeNumber.Items.Add(GetGaugeNumberDescription(GaugeType.Temperature, 2));
			cboGaugeNumber.Items.Add(GetGaugeNumberDescription(GaugeType.Temperature, 3));

			svcUnits = (TypeConverter.StandardValuesCollection)units.GetStandardValues();
			for (int i = 0; i < svcUnits.Count; i++)
			{
				cboUnits1.Items.Add(svcUnits[i].ToString());
				cboUnits2.Items.Add(svcUnits[i].ToString());
			}

			svcIOType = (TypeConverter.StandardValuesCollection)iot.GetStandardValues();
			for (int i = 0; i < svcIOType.Count; i++)
				cboIOType.Items.Add(svcIOType[i].ToString());

			string sChannelGroupType;
			svcChannelGroupType = (TypeConverter.StandardValuesCollection)cgt.GetStandardValues();
			for (int i = 0; i < svcChannelGroupType.Count; i++)
			{
				sChannelGroupType = svcChannelGroupType[i].ToString();
				if (svcChannelGroupType[i].ToString() != "Level 2" && svcChannelGroupType[i].ToString() != "Ullage 1" && svcChannelGroupType[i].ToString() != "Ullage 2")
					cboIOChannelGroupType.Items.Add(svcChannelGroupType[i].ToString());
			}

			svcDFGFloat = (TypeConverter.StandardValuesCollection)df.GetStandardValues();
			for (int i = 0; i < svcDFGFloat.Count; i++)
				cboDFGFloat.Items.Add(svcDFGFloat[i].ToString());

			foreach (AMU amu in TLIConfiguration.Vessel.AMUArray)
				cboAMUAddress.Items.Add(amu.AMUAddress.ToString());

			foreach (TAU tau in TLIConfiguration.Vessel.TAUArray)
				cboTAUAddress.Items.Add(tau.TAUAddress.ToString());

			foreach (ModularBubbler modbub in TLIConfiguration.Vessel.ModularBubblerArray)
				cboMODBUBAddress.Items.Add(modbub.ModularBubblerAddress.ToString());

			foreach (Product p in TLIConfiguration.Vessel.Product)
			{
				if (m_euCurrentEU.EquipmentType == EquipmentType.Cargo && p.Cargo)
					cboCurrentProduct.Items.Add(p.ProductName);
				else if(m_euCurrentEU.EquipmentType != EquipmentType.Cargo && !p.Cargo)
					cboCurrentProduct.Items.Add(p.ProductName);
			}

			for(int i = 1; i < 33; i++)
				cboIOChannel.Items.Add(i.ToString());

			for (int i = 1; i < 9; i++)
				cboIOChannel8.Items.Add(i.ToString());

			for (int i = 1; i < 9; i++)
				cboSecondaryChannel.Items.Add(i.ToString());

			cboModbusInputCommunicationInterface.Items.Add(ModbusCommunicationInterface.Serial.ToString());
			cboModbusInputCommunicationInterface.Items.Add(ModbusCommunicationInterface.Ethernet.ToString());

			cboModbusInputDataType.Items.Add("Float32");
			cboModbusInputDataType.Items.Add("Int16");

			cboSecondaryModbusInputDataType.Items.Add("Float32");
			cboSecondaryModbusInputDataType.Items.Add("Int16");

			if (cboGaugeType.Items.Count > 0)
				cboGaugeType.SelectedIndex = 0;

			if (cboGaugeNumber.Items.Count > 0)
				cboGaugeNumber.SelectedIndex = 0;

			if (cboUnits1.Items.Count > 0)
				cboUnits1.SelectedIndex = 0;

			if (cboUnits2.Items.Count > 0)
				cboUnits2.SelectedIndex = 0;

			if (cboIOType.Items.Count > 0)
				cboIOType.SelectedIndex = 0;

			if (cboIOChannelGroupType.Items.Count > 0)
				cboIOChannelGroupType.SelectedIndex = 0;

			if (cboAMUAddress.Items.Count > 0)
				cboAMUAddress.SelectedIndex = 0;

			if (cboTAUAddress.Items.Count > 0)
				cboTAUAddress.SelectedIndex = 0;

			if (cboMODBUBAddress.Items.Count > 0)
				cboMODBUBAddress.SelectedIndex = 0;

			if (cboIOChannel.Items.Count > 0)
				cboIOChannel.SelectedIndex = 0;

			if (cboIOChannel8.Items.Count > 0)
				cboIOChannel8.SelectedIndex = 0;

			if (cboModbusInputCommunicationInterface.Items.Count > 0)
				cboModbusInputCommunicationInterface.SelectedIndex = 0;

			if (cboModbusInputDataType.Items.Count > 0)
				cboModbusInputDataType.SelectedIndex = 0;

			if (cboSecondaryModbusInputDataType.Items.Count > 0)
				cboSecondaryModbusInputDataType.SelectedIndex = 0;

			if (cboSecondaryChannel.Items.Count > 0)
				cboSecondaryChannel.SelectedIndex = 0;

			if (cboCurrentProduct.Items.Count > 0)
				cboCurrentProduct.SelectedIndex = 0;

			if (cboDFGFloat.Items.Count >= 1)
				cboDFGFloat.SelectedIndex = 1;
		}

		private void BindControls()
		{
			if (m_sProcessID != "new")
			{
				if (TLIConfiguration.VesselGaugePoints.ContainsKey(m_sEquipmentID))
					if (TLIConfiguration.VesselGaugePoints[m_sEquipmentID].ContainsKey(m_sProcessID))
					{
						GaugePoint gp = TLIConfiguration.VesselGaugePoints[m_sEquipmentID][m_sProcessID];

						txtDisplayName.Text = gp.DisplayName;
						chkEnable.Checked = gp.Enable;
						try { cboGaugeType.SelectedIndex = cboGaugeType.Items.IndexOf(gp.GaugeTypeString); }
						catch { }
						try { cboGaugeNumber.SelectedIndex = cboGaugeNumber.Items.IndexOf(GetGaugeNumberDescription(gp.GaugeType, gp.GaugeNumber)); }
						catch { }
						try { cboUnits1.SelectedIndex = cboUnits1.Items.IndexOf(Units.UnitsString(gp.Units)); }
						catch { }
						try { cboUnits2.SelectedIndex = cboUnits2.Items.IndexOf(Units.UnitsString(gp.Units2)); }
						catch { }
						chkDisableFaceplateGraph.Checked = gp.DisableFaceplateGraph;

						txtRawMax.Text = gp.RawMax.ToString("f4");
						txtRawMin.Text = gp.RawMin.ToString("f4");
						txtRawDeadband.Text = gp.ValueDeadband.ToString("f4");
						txtDigitalFilter.Text = gp.DigitalFilter.ToString();
						txtEngineeringMax.Text = gp.EngineeringMax.ToString("f4");
						txtEngineeringMin.Text = gp.EngineeringMin.ToString("f4");
						txtHighScaleValue.Text = gp.FullScaleValue.ToString("f4");
						txtLowScaleValue.Text = gp.LowScaleValue.ToString("f4");
						txtLinearOffset.Text = gp.LinearOffset.ToString("f4");
						txtPhysicalOffset.Text = gp.PhysicalOffset.ToString("f4");

						txtVolumeMax.Text = "5000";
						txtVolumeMin.Text = "0";

						if (gp.GaugeType == GaugeType.List || gp.GaugeType == GaugeType.Trim)
							chkCalculated.Checked = gp.Calculated;

						if (gp.IOType == IOType.AMU)
						{
							chkIOEnable.Checked = gp.AMUEnable;

							try { cboAMUAddress.SelectedIndex = cboAMUAddress.Items.IndexOf(gp.AMUAddress.ToString()); }
							catch { }
							try { cboIOChannel.SelectedIndex = cboIOChannel.Items.IndexOf(gp.AMUChannel.ToString()); }
							catch { }

							chkAnalogChannel.Checked = gp.AMUAnalogChannel;
							cboIOType.SelectedItem = IOType.AMUString;
							
							chkSecondaryChannelEnable.Enabled = false;
						}
						else if (gp.IOType == IOType.TAU)
						{
							chkIOEnable.Checked = gp.TAUEnable;

							try { cboTAUAddress.SelectedIndex = cboTAUAddress.Items.IndexOf(gp.TAUAddress.ToString()); }
							catch { }
							try { cboIOChannel.SelectedIndex = cboIOChannel.Items.IndexOf(gp.TAUChannel.ToString()); }
							catch { }
							try { cboIOChannelGroupType.SelectedIndex = cboIOChannelGroupType.Items.IndexOf(TAUChannelGroupType.GetChannelGroupTypeString(gp.TAUChannelGroupType)); }
							catch { }
							try { cboDFGFloat.SelectedIndex = cboDFGFloat.Items.IndexOf(DFGFloat.DFGFloatString(gp.DFGFloat)); }
							catch { }

							chkSecondaryChannelEnable.Enabled = false;

							cboIOType.SelectedItem = IOType.TAUString;
						}
						else if (gp.IOType == IOType.ModularBubbler)
						{
							chkIOEnable.Checked = gp.BUBEnable;
							chkSecondaryChannelEnable.Checked = gp.BUBSecondaryChannelEnable;

							try { cboMODBUBAddress.SelectedIndex = cboMODBUBAddress.Items.IndexOf(gp.BUBAddress.ToString()); }
							catch { }
							try { cboIOChannel8.SelectedIndex = cboIOChannel8.Items.IndexOf(gp.BUBChannel.ToString()); }
							catch { }

							if (gp.BUBSecondaryChannelEnable)
								try { cboSecondaryChannel.SelectedIndex = cboSecondaryChannel.Items.IndexOf(gp.BUBSecondaryChannel.ToString()); }
								catch { }

							cboIOType.SelectedItem = IOType.ModularBubblerString;
						}
						else if (gp.IOType == IOType.Modbus)
						{
							chkIOEnable.Checked = gp.ModbusInput.Enable;

							try { cboModbusInputCommunicationInterface.SelectedIndex = cboModbusInputCommunicationInterface.Items.IndexOf(
                                gp.ModbusInput.ModbusCommunicationInterface.ToString()); }
							catch { }
							try { cboModbusInputDataType.SelectedIndex = cboModbusInputDataType.Items.IndexOf(
                                ModbusDataType.GetModbusDataTypeString(gp.ModbusInput.ModbusDataType)); }
							catch { }
							txtModbusInputScale.Text = gp.ModbusInput.Scale.ToString("f6");
							txtModbusInputRegister1.Text = gp.ModbusInput.RegisterAddress1.ToString();
							txtModbusInputRegister2.Text = gp.ModbusInput.RegisterAddress2.ToString();

							chkSecondaryModbusInputEnabled.Checked = gp.ModbusInput.SecondaryEnable;
							try { cboSecondaryModbusInputDataType.SelectedIndex = cboSecondaryModbusInputDataType.Items.IndexOf(
                                ModbusDataType.GetModbusDataTypeString(gp.ModbusInput.ModbusDataType)); }
							catch { }
							txtSecondaryModbusInputScale.Text = gp.ModbusInput.SecondaryScale.ToString("f1");
							txtSecondaryModbusInputRegister1.Text = gp.ModbusInput.SecondaryRegisterAddress1.ToString();
							txtSecondaryModbusInputRegister2.Text = gp.ModbusInput.SecondaryRegisterAddress2.ToString();

							chkSecondaryChannelEnable.Enabled = false;

							cboIOType.SelectedItem = IOType.ModbusString;
						}

						// Members associated with Equipment Unit object but moved to Gauge Point form for clarity
						txtVolumeMax.Text = m_euCurrentEU.VolumeMax.ToString("f4");
						txtVolumeMin.Text = m_euCurrentEU.VolumeMin.ToString("f4");
						chkSpecificGravityApplicable.Checked = m_euCurrentEU.SpecificGravityApplicable;
						try { cboCurrentProduct.SelectedIndex = cboCurrentProduct.Items.IndexOf(m_euCurrentEU.CurrentProduct); }
						catch { }

					}
			}
			else
			{
				chkEnable.Checked = true;
				chkIOEnable.Checked = true;
				
				if(cboAMUAddress.Items.Count > 0)
					cboIOChannel.SelectedIndex = TLIConfiguration.FindMaxAMUChannel(Convert.ToInt32(cboAMUAddress.Items[cboAMUAddress.SelectedIndex]));
			}

			chkIOEnable_CheckedChanged(this, new EventArgs());
			chkEnable_CheckedChanged(this, new EventArgs());
			cboGaugeType_SelectedIndexChanged(this, new EventArgs());
			cboIOType_SelectedIndexChanged(this, new EventArgs());
		}

#endregion

		#region Validation

		private bool ValidateGaugePoint()
		{
			bool bReturnValue = false;

			int i = 0;
			float f = 0;

			if (txtDisplayName.Text == null || txtDisplayName.Text == "")
				MessageBox.Show("Name is a required field.", "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (grpSounding.Enabled && !float.TryParse(txtVolumeMax.Text, out f))
				MessageBox.Show("Volume Max must be a valid number.", "Equipment Unit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (grpSounding.Enabled && !float.TryParse(txtVolumeMin.Text, out f))
				MessageBox.Show("Volume Min must be a valid number.", "Equipment Unit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (grpSounding.Enabled && float.Parse(txtVolumeMax.Text) <= float.Parse(txtVolumeMin.Text))
				MessageBox.Show("Volume Max must be greater than Volume Min.", "Equipment Unit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (m_bEngineeringEnabled && !float.TryParse(txtRawMax.Text, out f))
				MessageBox.Show("Raw Max must be a valid number.", "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (m_bEngineeringEnabled && !float.TryParse(txtRawMin.Text, out f))
				MessageBox.Show("Raw Min must be a valid number.", "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (m_bEngineeringEnabled && !float.TryParse(txtRawDeadband.Text, out f))
				MessageBox.Show("Raw Deadband must be a valid number.", "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (m_bEngineeringEnabled && !int.TryParse(txtDigitalFilter.Text, out i))
				MessageBox.Show("Digital Filter must be a valid number.", "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (m_bEngineeringEnabled && !float.TryParse(txtEngineeringMax.Text, out f))
				MessageBox.Show("High Scale Value must be a valid number.", "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (m_bEngineeringEnabled && !float.TryParse(txtEngineeringMin.Text, out f))
				MessageBox.Show("Low Scale Value must be a valid number.", "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (lblHighScaleValue.Enabled && !float.TryParse(txtHighScaleValue.Text, out f))
				MessageBox.Show("Faceplate Max must be a valid number.", "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (lblHighScaleValue.Enabled && !float.TryParse(txtLowScaleValue.Text, out f))
				MessageBox.Show("Faceplate Min must be a valid number.", "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (m_bEngineeringEnabled && (float.Parse(txtRawMax.Text) <= float.Parse(txtRawMin.Text)))
				MessageBox.Show("Raw Max must be greater than Raw Min.", "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (m_bEngineeringEnabled && txtEngineeringMax.Enabled && (float.Parse(txtEngineeringMax.Text) <= float.Parse(txtEngineeringMin.Text)))
				MessageBox.Show("High Scale Value must be greater than Low Scale Value.", "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (lblHighScaleValue.Enabled && (float.Parse(txtHighScaleValue.Text) <= float.Parse(txtLowScaleValue.Text)))
				MessageBox.Show("Faceplate Max must be greater than Faceplate Min.", "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (m_bEngineeringEnabled && !float.TryParse(txtLinearOffset.Text, out f))
				MessageBox.Show("Offset must be a valid number.", "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if(m_bEngineeringEnabled && !float.TryParse(txtPhysicalOffset.Text, out f))
				MessageBox.Show("Max Gauge Height must be a valid number.", "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (grpDataCollection.Enabled && chkIOEnable.Checked && cboIOType.SelectedItem.ToString() == IOType.AMUString && cboAMUAddress.SelectedIndex < 0)
				MessageBox.Show("Please specify a Device address.", "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (grpDataCollection.Enabled && chkIOEnable.Checked && cboIOType.SelectedItem.ToString() == IOType.TAUString && cboTAUAddress.SelectedIndex < 0)
				MessageBox.Show("Please specify a Device address.", "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (grpDataCollection.Enabled && chkIOEnable.Checked && cboIOType.SelectedItem.ToString() == IOType.ModularBubblerString && cboMODBUBAddress.SelectedIndex < 0)
				MessageBox.Show("Please specify a Device address.", "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (grpDataCollection.Enabled && chkIOEnable.Checked && cboIOChannel.SelectedIndex < 0)
				MessageBox.Show("Please specify a Device channel.", "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (grpDataCollection.Enabled && chkIOEnable.Checked && cboIOType.SelectedItem.ToString() == IOType.ModularBubblerString && cboIOChannel8.SelectedIndex < 0)
				MessageBox.Show("Please specify a Device channel.", "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (grpDataCollection.Enabled && chkIOEnable.Checked && cboIOType.SelectedItem.ToString() == IOType.ModularBubblerString && chkSecondaryChannelEnable.Checked && cboSecondaryChannel.SelectedIndex < 0)
				MessageBox.Show("Please specify a Secondary Channel.", "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (grpModbusInput.Enabled && !int.TryParse(txtModbusInputRegister1.Text, out i))
				MessageBox.Show("Register LW must be a valid number.", "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (grpModbusInput.Enabled && !int.TryParse(txtModbusInputRegister2.Text, out i))
				MessageBox.Show("Register HW must be a valid number.", "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (grpModbusInput.Enabled && chkSecondaryChannelEnable.Checked && !int.TryParse(txtSecondaryModbusInputRegister1.Text, out i))
				MessageBox.Show("Sounding Register LW must be a valid number.", "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (grpModbusInput.Enabled && chkSecondaryChannelEnable.Checked && !int.TryParse(txtSecondaryModbusInputRegister2.Text, out i))
				MessageBox.Show("Sounding Register HW must be a valid number.", "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else if (Convert.ToInt32(GaugeType.GetGaugeTypeID(cboGaugeType.Items[cboGaugeType.SelectedIndex].ToString())) == GaugeType.HogSag && EquipmentUnit.EquipmentTypeFromEquipmentID(m_sEquipmentID) != EquipmentType.Misc)
				MessageBox.Show("Hog/Sag Gauge Point can only be added to a Misc Equipment Unit.", "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			else
				bReturnValue = true;

			if(bReturnValue)
			{
				string sCurrentProcessID = GaugePoint.CreateProcessIDForConfiguraion(m_sEquipmentID,
                    GaugeType.GetGaugeTypeID(cboGaugeType.Items[cboGaugeType.SelectedIndex].ToString()),
                    Convert.ToInt32(GetGaugeNumberID(cboGaugeNumber.Items[cboGaugeNumber.SelectedIndex].ToString())));

				if(m_sProcessID != sCurrentProcessID)
				{
					if(TLIConfiguration.VesselGaugePoints.ContainsKey(m_sEquipmentID))
					{
						if(TLIConfiguration.VesselGaugePoints[m_sEquipmentID].ContainsKey(sCurrentProcessID))
						{
							MessageBox.Show(this, "This equipment unit already contains a gauge point with this Type and Number.",
                                "Gauge Point", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
							bReturnValue = false;
						}
					}
				}
			}

			return bReturnValue;
		}

		private bool ValidateUnits()
		{
			int iGaugeType, iUnits, iUnits2;

			bool bReturnValue = false;

			iGaugeType = GaugeType.GetGaugeTypeID(cboGaugeType.Items[cboGaugeType.SelectedIndex].ToString());
			iUnits = Units.UnitsID(cboUnits1.Items[cboUnits1.SelectedIndex].ToString());
			iUnits2 = Units.UnitsID(cboUnits2.Items[cboUnits2.SelectedIndex].ToString());

			switch (iGaugeType)
			{
				case GaugeType.AverageTemperature:
				case GaugeType.Temperature:
					{
						if (iUnits != Units.Fahrenheit && iUnits != Units.Celsius)
							MessageBox.Show("You have specified invalid Gauge Units for this Gauge Type.", "Gauge Point",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
						else
							bReturnValue = true;
					}
					break;
				case GaugeType.ChannelStateAlarmMonitor:
					{
						bReturnValue = true;
					}
					break;
				case GaugeType.Ullage:
				case GaugeType.Level:
					{
						if (iUnits != Units.Inches && iUnits != Units.Millimeters)
							MessageBox.Show("You have specified invalid Gauge Units for this Gauge Type.", "Gauge Point",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
						else
						{
							if (EquipmentUnit.EquipmentTypeFromEquipmentID(m_sEquipmentID) == EquipmentType.Draft)
								bReturnValue = true;
							else if (iUnits2 != Units.BBL && iUnits2 != Units.CubicMeters && iUnits2 != Units.Gallons &&
                                iUnits2 != Units.Kiloliters && iUnits2 != Units.Liters && iUnits2 != Units.LongTons)
								MessageBox.Show("You have specified invalid Sounding Units for this Gauge Type.", "Gauge Point",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
							else
								bReturnValue = true;
						}
					}
					break;
				case GaugeType.List:
					{
						if (iUnits != Units.Degrees)
							MessageBox.Show("You have specified invalid Gauge Units for this Gauge Type.", "Gauge Point",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
						else
							bReturnValue = true;
						break;
					}
				case GaugeType.Trim:
					{
						if (iUnits != Units.Degrees && iUnits != Units.Inches && iUnits != Units.Millimeters)
							MessageBox.Show("You have specified invalid Gauge Units for this Gauge Type.", "Gauge Point",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
						else
							bReturnValue = true;

						break;
					}
				case GaugeType.Pressure:
					{
						if (iUnits != Units.Bar && iUnits != Units.MilliBars && iUnits != Units.PSI &&
                            iUnits != Units.Millimeters && iUnits != Units.Discrete && iUnits != Units.DiscreteAlt)
							MessageBox.Show("You have specified invalid Gauge Units for this Gauge Type.", "Gauge Point",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
						else
							bReturnValue = true;
					}
					break;
				case GaugeType.PowerFail:
					{
						if (iUnits != Units.Discrete)
							MessageBox.Show("You have specified invalid Gauge Units for this Gauge Type, please select \"Discrete\".", "Gauge Point",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
						else
							bReturnValue = true;
					}
					break;
				case GaugeType.HogSag:
					{
						if (iUnits != Units.Inches && iUnits != Units.Millimeters)
							MessageBox.Show("You have specified invalid Gauge Units for this Gauge Type.", "Gauge Point",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
						else if (float.Parse(txtHighScaleValue.Text) <= 0)
							MessageBox.Show("Faceplate Max must be greater than 0 for Hog/Sag.", "Gauge Point",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
						else if (float.Parse(txtLowScaleValue.Text) >= 0)
							MessageBox.Show("Faceplate Min must be less than 0 for Hog/Sag.", "Gauge Point",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
						else
							bReturnValue = true;
					}
					break;
			}

			return bReturnValue;
		}

		#endregion

		#region Save Configuration
		private void SaveConfiguration()
		{
			GaugePoint gp;

			string sCurrentProcessID = GaugePoint.CreateProcessIDForConfiguraion(m_sEquipmentID,
                GaugeType.GetGaugeTypeID(cboGaugeType.Items[cboGaugeType.SelectedIndex].ToString()),
                Convert.ToInt32(GetGaugeNumberID(cboGaugeNumber.Items[cboGaugeNumber.SelectedIndex].ToString())));

			if (m_sProcessID == "new")
			{
				GaugePoint newGp = new GaugePoint();
				AlarmPoint apCableCondition, apHighAlarm, apLowAlarm, apPowerFail;

				newGp.Enable = true;
				newGp.GaugeTypeString = cboGaugeType.Items[cboGaugeType.SelectedIndex].ToString();
				newGp.GaugeNumber = Convert.ToInt32(GetGaugeNumberID(cboGaugeNumber.Items[cboGaugeNumber.SelectedIndex].ToString()));
				newGp.ProcessID = newGp.CreateProcessID(m_sEquipmentID);
				newGp.DisplayName = txtDisplayName.Text;

				m_sProcessID = newGp.ProcessID;

				if (!TLIConfiguration.VesselGaugePoints.ContainsKey(m_sEquipmentID))
					TLIConfiguration.VesselGaugePoints.Add(m_sEquipmentID, new Dictionary<string, GaugePoint>());

				TLIConfiguration.VesselGaugePoints[m_sEquipmentID].Add(m_sProcessID, newGp);

				if (!TLIConfiguration.VesselAlarmPoints.ContainsKey(m_sEquipmentID))
					TLIConfiguration.VesselAlarmPoints.Add(m_sEquipmentID, new Dictionary<string, Dictionary<Guid, AlarmPoint>>());

				if (!TLIConfiguration.VesselAlarmPoints[m_sEquipmentID].ContainsKey(m_sProcessID))
					TLIConfiguration.VesselAlarmPoints[m_sEquipmentID].Add(m_sProcessID, new Dictionary<Guid, AlarmPoint>());

				if (newGp.GaugeType != GaugeType.AverageTemperature)
				{
					if (chkIOEnable.Checked)
					{
						apCableCondition = new AlarmPoint("Cable Condition", true, Guid.NewGuid(), AlarmMonitorType.ChannelCondition,
                            AlarmType.Alarm, "Alarm", newGp.DisplayName + " " + "Cable Error", 5, Comparator.EqualTo, 0, Units.BBL, 0, 0, 0,
                            false, new List<string>(), new ModbusInterface(), new ModbusInterface());

						foreach (AlarmAnnunciation aa in TLIConfiguration.Vessel.AlarmAnnunciation)
							if (aa.AlarmAnnunciationName == "Buzzer")
								apCableCondition.AlarmAnnunciation.Add("Buzzer");
							else if (aa.AlarmAnnunciationName == "Gauging Buzzer")
								apCableCondition.AlarmAnnunciation.Add("Gauging Buzzer");

						TLIConfiguration.VesselAlarmPoints[m_sEquipmentID][m_sProcessID].Add(apCableCondition.AlarmID, apCableCondition);
					}
				}

				if (newGp.GaugeType == GaugeType.Pressure)
				{
					apHighAlarm = new AlarmPoint("High Pressure Alarm", true, Guid.NewGuid(), AlarmMonitorType.AnalogValue, AlarmType.HighAlarm, "Alarm",
                        "High Pressure Alarm", 3, Comparator.GreaterThanOrEqualTo, 100, Units.UnitsID(cboUnits1.Items[cboUnits1.SelectedIndex].ToString()), 0, 0, 0,
                        false, new List<string>(), new ModbusInterface(), new ModbusInterface());
					apLowAlarm = new AlarmPoint("Low Pressure Alarm", true, Guid.NewGuid(), AlarmMonitorType.AnalogValue, AlarmType.LowAlarm, "Alarm",
                        "Low Pressure Alarm", 3, Comparator.LessThanOrEqualTo, 0, Units.UnitsID(cboUnits1.Items[cboUnits1.SelectedIndex].ToString()), 0, 0, 0,
                        false, new List<string>(), new ModbusInterface(), new ModbusInterface());

					foreach (AlarmAnnunciation aa in TLIConfiguration.Vessel.AlarmAnnunciation)
					{
						if (aa.AlarmAnnunciationName == "Pressure Alarm" || aa.AlarmAnnunciationName == "Buzzer" || aa.AlarmAnnunciationName == "Gauging Buzzer")
						{
							apHighAlarm.AlarmAnnunciation.Add(aa.AlarmAnnunciationName);
							apLowAlarm.AlarmAnnunciation.Add(aa.AlarmAnnunciationName);
						}
					}

					TLIConfiguration.VesselAlarmPoints[m_sEquipmentID][m_sProcessID].Add(apHighAlarm.AlarmID, apHighAlarm);
					TLIConfiguration.VesselAlarmPoints[m_sEquipmentID][m_sProcessID].Add(apLowAlarm.AlarmID, apLowAlarm);
				}

				if (newGp.GaugeType == GaugeType.AverageTemperature)
				{
					apHighAlarm = new AlarmPoint("High Temperature Alarm", true, Guid.NewGuid(), AlarmMonitorType.AnalogValue, AlarmType.HighAlarm, "Alarm",
                        "High Temperature Alarm", 4, Comparator.GreaterThanOrEqualTo, 100, Units.UnitsID(cboUnits1.Items[cboUnits1.SelectedIndex].ToString()), 0, 0, 0,
                        false, new List<string>(), new ModbusInterface(), new ModbusInterface());
					apLowAlarm = new AlarmPoint("Low Temperature Alarm", true, Guid.NewGuid(), AlarmMonitorType.AnalogValue, AlarmType.LowAlarm, "Alarm",
                        "Low Temperature Alarm", 4, Comparator.LessThanOrEqualTo, 0, Units.UnitsID(cboUnits1.Items[cboUnits1.SelectedIndex].ToString()), 0, 0, 0,
                        false, new List<string>(), new ModbusInterface(), new ModbusInterface());

					foreach (AlarmAnnunciation aa in TLIConfiguration.Vessel.AlarmAnnunciation)
					{
						if (aa.AlarmAnnunciationName == "Temperature Alarm" || aa.AlarmAnnunciationName == "Buzzer" || aa.AlarmAnnunciationName == "Gauging Buzzer")
						{
							apHighAlarm.AlarmAnnunciation.Add(aa.AlarmAnnunciationName);
							apLowAlarm.AlarmAnnunciation.Add(aa.AlarmAnnunciationName);
						}
					}

					TLIConfiguration.VesselAlarmPoints[m_sEquipmentID][m_sProcessID].Add(apHighAlarm.AlarmID, apHighAlarm);
					TLIConfiguration.VesselAlarmPoints[m_sEquipmentID][m_sProcessID].Add(apLowAlarm.AlarmID, apLowAlarm);
				}

				if (newGp.GaugeType == GaugeType.ChannelStateAlarmMonitor && newGp.DisplayName.Contains("Overfill"))
				{
					apHighAlarm = new AlarmPoint("Overfill Alarm", true, Guid.NewGuid(), AlarmMonitorType.ChannelAlarmState, AlarmType.HighAlarm, "Alarm",
                        "Overfill Alarm", 1, Comparator.GreaterThanOrEqualTo, 0, 0, 0, 0, 0, false, new List<string>(), new ModbusInterface(), new ModbusInterface());

					foreach (AlarmAnnunciation aa in TLIConfiguration.Vessel.AlarmAnnunciation)
					{
						if (aa.AlarmAnnunciationName == "Overfill Alarm" || aa.AlarmAnnunciationName == "Summary Alarm")
							apHighAlarm.AlarmAnnunciation.Add(aa.AlarmAnnunciationName);
					}

					TLIConfiguration.VesselAlarmPoints[m_sEquipmentID][m_sProcessID].Add(apHighAlarm.AlarmID, apHighAlarm);
				}

				if (newGp.GaugeType == GaugeType.ChannelStateAlarmMonitor && newGp.DisplayName.Contains("High Level"))
				{
					apHighAlarm = new AlarmPoint("High Level Alarm", true, Guid.NewGuid(), AlarmMonitorType.ChannelAlarmState, AlarmType.HighWarning, "Alarm",
                        "High Level Alarm", 2, Comparator.GreaterThanOrEqualTo, 0, 0, 0, 0, 0, false, new List<string>(), new ModbusInterface(), new ModbusInterface());

					foreach (AlarmAnnunciation aa in TLIConfiguration.Vessel.AlarmAnnunciation)
					{
						if (aa.AlarmAnnunciationName == "High Level Alarm" || aa.AlarmAnnunciationName == "Summary Alarm")
							apHighAlarm.AlarmAnnunciation.Add(aa.AlarmAnnunciationName);
					}

					TLIConfiguration.VesselAlarmPoints[m_sEquipmentID][m_sProcessID].Add(apHighAlarm.AlarmID, apHighAlarm);
				}

				if (newGp.GaugeType == GaugeType.PowerFail)
				{
					apPowerFail = new AlarmPoint("Power Fail Alarm", true, Guid.NewGuid(), AlarmMonitorType.DigitalValue, AlarmType.Alarm, "Alarm",
                        "Power Fail Alarm", 5, Comparator.EqualTo, 1, Units.BBL, 0, 0, 0, false, new List<string>(), new ModbusInterface(), new ModbusInterface());

					TLIConfiguration.VesselAlarmPoints[m_sEquipmentID][m_sProcessID].Add(apPowerFail.AlarmID, apPowerFail);
				}

				if (newGp.GaugeType == GaugeType.HogSag)
				{
					apHighAlarm = new AlarmPoint("Hog Alarm", true, Guid.NewGuid(), AlarmMonitorType.AnalogValue, AlarmType.HighAlarm, "Alarm",
                        "Hog Alarm", 4, Comparator.LessThanOrEqualTo, -10, Units.UnitsID(cboUnits1.Items[cboUnits1.SelectedIndex].ToString()), 0, 0, 0,
                        false, new List<string>(), new ModbusInterface(), new ModbusInterface());
					apLowAlarm = new AlarmPoint("Sag Alarm", true, Guid.NewGuid(), AlarmMonitorType.AnalogValue, AlarmType.LowAlarm, "Alarm",
                        "Sag Alarm", 4, Comparator.GreaterThanOrEqualTo, 10, Units.UnitsID(cboUnits1.Items[cboUnits1.SelectedIndex].ToString()), 0, 0, 0,
                        false, new List<string>(), new ModbusInterface(), new ModbusInterface());

					foreach (AlarmAnnunciation aa in TLIConfiguration.Vessel.AlarmAnnunciation)
					{
						if (aa.AlarmAnnunciationName == "Temperature Alarm" || aa.AlarmAnnunciationName == "Buzzer" || aa.AlarmAnnunciationName == "Gauging Buzzer")
						{
							apHighAlarm.AlarmAnnunciation.Add(aa.AlarmAnnunciationName);
							apLowAlarm.AlarmAnnunciation.Add(aa.AlarmAnnunciationName);
						}
					}

					TLIConfiguration.VesselAlarmPoints[m_sEquipmentID][m_sProcessID].Add(apHighAlarm.AlarmID, apHighAlarm);
					TLIConfiguration.VesselAlarmPoints[m_sEquipmentID][m_sProcessID].Add(apLowAlarm.AlarmID, apLowAlarm);
				}
			}

			gp = TLIConfiguration.VesselGaugePoints[m_sEquipmentID][m_sProcessID];
			
			if (m_sProcessID != "new" && m_sProcessID != sCurrentProcessID)
			{
				if (!TLIConfiguration.VesselGaugePoints[m_sEquipmentID].ContainsKey(sCurrentProcessID))
				{
					gp.GaugeTypeString = cboGaugeType.Items[cboGaugeType.SelectedIndex].ToString();
					gp.GaugeNumber = Convert.ToInt32(GetGaugeNumberID(cboGaugeNumber.Items[cboGaugeNumber.SelectedIndex].ToString()));
					gp.ProcessID = gp.CreateProcessID(m_sEquipmentID);

					TLIConfiguration.VesselGaugePoints[m_sEquipmentID].Add(sCurrentProcessID, gp);

					if (TLIConfiguration.VesselAlarmPoints.ContainsKey(m_sEquipmentID) && TLIConfiguration.VesselAlarmPoints[m_sEquipmentID].ContainsKey(m_sProcessID))
							TLIConfiguration.VesselAlarmPoints[m_sEquipmentID].Add(sCurrentProcessID, TLIConfiguration.VesselAlarmPoints[m_sEquipmentID][m_sProcessID]);

					if(TLIConfiguration.VesselAlarmPoints.ContainsKey(m_sEquipmentID) && TLIConfiguration.VesselAlarmPoints[m_sEquipmentID].ContainsKey(m_sProcessID))
							TLIConfiguration.VesselAlarmPoints[m_sEquipmentID].Remove(m_sProcessID);

					TLIConfiguration.VesselGaugePoints[m_sEquipmentID].Remove(m_sProcessID);

					m_bRemoveGaugePoint = true;
					m_sOldProcessID = m_sProcessID;
					m_sProcessID = sCurrentProcessID;
				}
				else
				{
					MessageBox.Show(this, "This equipment unit already contains a gauge point with this Type and Number.", "Gauge Point",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					return;
				}
			}

			gp.DisplayName = txtDisplayName.Text;
			gp.Enable = chkEnable.Checked;
			gp.DisableFaceplateGraph = chkDisableFaceplateGraph.Checked;

			gp.Units = Units.UnitsID(cboUnits1.Items[cboUnits1.SelectedIndex].ToString());
			gp.Units2 = Units.UnitsID(cboUnits2.Items[cboUnits2.SelectedIndex].ToString());

			gp.RawMax = Convert.ToSingle(txtRawMax.Text);
			gp.RawMin = Convert.ToSingle(txtRawMin.Text);
			gp.ValueDeadband = Convert.ToSingle(txtRawDeadband.Text);
			gp.DigitalFilter = Convert.ToInt32(txtDigitalFilter.Text);
			gp.EngineeringMax = Convert.ToSingle(txtEngineeringMax.Text);
			gp.EngineeringMin = Convert.ToSingle(txtEngineeringMin.Text);
			gp.FullScaleValue = Convert.ToSingle(txtHighScaleValue.Text);
			gp.LowScaleValue = Convert.ToSingle(txtLowScaleValue.Text);
			gp.LinearOffset = Convert.ToSingle(txtLinearOffset.Text);
			gp.PhysicalOffset = Convert.ToSingle(txtPhysicalOffset.Text);

			if (chkIOEnable.Checked)
			{
				if (cboIOType.SelectedItem.ToString() == IOType.AMUString)
				{
					gp.IOType = IOType.AMU;

					gp.AMUEnable = chkIOEnable.Checked;
					gp.AMUAddress = Convert.ToInt32(cboAMUAddress.Items[cboAMUAddress.SelectedIndex]);
					gp.AMUChannel = Convert.ToInt32(cboIOChannel.Items[cboIOChannel.SelectedIndex]);
					gp.AMUAnalogChannel = chkAnalogChannel.Checked;

					gp.TAUEnable = false;
					gp.BUBEnable = false;
					gp.BUBSecondaryChannelEnable = false;
					gp.ModbusInput.Enable = false;
					gp.ModbusInput.SecondaryEnable = false;
				}
				else if (cboIOType.SelectedItem.ToString() == IOType.TAUString)
				{
					gp.IOType = IOType.TAU;

					gp.TAUEnable = chkIOEnable.Checked;
					gp.TAUAddress = Convert.ToInt32(cboTAUAddress.Items[cboTAUAddress.SelectedIndex]);
					gp.TAUChannel = Convert.ToInt32(cboIOChannel.Items[cboIOChannel.SelectedIndex]);
					gp.TAUChannelGroupType = TAUChannelGroupType.GetChannelGroupTypeID(cboIOChannelGroupType.SelectedItem.ToString());

					gp.DFGFloat = DFGFloat.DFGFloatID(cboDFGFloat.SelectedItem.ToString());

					gp.AMUEnable = false;
					gp.BUBEnable = false;
					gp.BUBSecondaryChannelEnable = false;
					gp.ModbusInput.Enable = false;
					gp.ModbusInput.SecondaryEnable = false;
				}
				else if (cboIOType.SelectedItem.ToString() == IOType.ModularBubblerString)
				{
					gp.IOType = IOType.ModularBubbler;

					gp.BUBEnable = chkIOEnable.Checked;
					gp.BUBAddress = Convert.ToInt32(cboMODBUBAddress.Items[cboMODBUBAddress.SelectedIndex]);
					gp.BUBChannel = Convert.ToInt32(cboIOChannel8.Items[cboIOChannel8.SelectedIndex]);

					gp.BUBSecondaryChannelEnable = chkSecondaryChannelEnable.Checked;
					gp.BUBSecondaryChannel = Convert.ToInt32(cboSecondaryChannel.Items[cboSecondaryChannel.SelectedIndex]);

					gp.AMUEnable = false;
					gp.TAUEnable = false;
					gp.ModbusInput.Enable = false;
					gp.ModbusInput.SecondaryEnable = false;
				}
				else if (cboIOType.SelectedItem.ToString() == IOType.ModbusString)
				{
					gp.IOType = IOType.Modbus;

					gp.ModbusInput.Enable = chkIOEnable.Checked;
					
					gp.ModbusInput.ModbusCommunicationInterface = (ModbusCommunicationInterface)Enum.Parse(typeof(ModbusCommunicationInterface), cboModbusInputCommunicationInterface.Items[cboModbusInputCommunicationInterface.SelectedIndex].ToString());
					gp.ModbusInput.ModbusDataType = ModbusDataType.GetModbusDataTypeID(cboModbusInputDataType.Items[cboModbusInputDataType.SelectedIndex].ToString());
					gp.ModbusInput.Scale = Convert.ToSingle(txtModbusInputScale.Text);
					gp.ModbusInput.RegisterAddress1 = Convert.ToUInt16(txtModbusInputRegister1.Text);
					
					if (gp.ModbusInput.ModbusDataType == ModbusDataType.Float32)
						gp.ModbusInput.RegisterAddress2 = Convert.ToUInt16(txtModbusInputRegister2.Text);
					else
						gp.ModbusInput.RegisterAddress2 = 0;

					if (chkSecondaryModbusInputEnabled.Checked && (gp.GaugeType == GaugeType.Level || gp.GaugeType == GaugeType.Ullage))
					{
						gp.ModbusInput.SecondaryEnable = chkSecondaryModbusInputEnabled.Checked;
						gp.ModbusInput.SecondaryModbusDataType = ModbusDataType.GetModbusDataTypeID(cboSecondaryModbusInputDataType.Items[cboSecondaryModbusInputDataType.SelectedIndex].ToString());
						gp.ModbusInput.SecondaryScale = Convert.ToSingle(txtSecondaryModbusInputScale.Text);
						gp.ModbusInput.SecondaryRegisterAddress1 = Convert.ToUInt16(txtSecondaryModbusInputRegister1.Text);

						if (gp.ModbusInput.SecondaryModbusDataType == ModbusDataType.Float32)
							gp.ModbusInput.SecondaryRegisterAddress2 = Convert.ToUInt16(txtSecondaryModbusInputRegister2.Text);
						else
							gp.ModbusInput.SecondaryRegisterAddress2 = 0;
					}
					else
						gp.ModbusInput.SecondaryEnable = false;

					gp.AMUEnable = false;
					gp.BUBEnable = false;
					gp.BUBSecondaryChannelEnable = false;
					gp.TAUEnable = false;
				}
			}
			else
			{
				gp.AMUEnable = false;
				gp.TAUEnable = false;
				gp.BUBEnable = false; 
				gp.ModbusInput.Enable = false;
				gp.ModbusInput.SecondaryEnable = false;
			}

			if (!chkIOEnable.Checked && (gp.GaugeType == GaugeType.List || gp.GaugeType == GaugeType.Trim))
				gp.Calculated = chkCalculated.Checked;
			else
				gp.Calculated = false;

			// Members from Equipment Unit which have been included on Gauge Point form for clarity
			if (gp.GaugeType == GaugeType.Level || gp.GaugeType == GaugeType.Ullage)
			{
					m_euCurrentEU.TankHeight = gp.PhysicalOffset;				// Equipment Unit Tank Height
					m_euCurrentEU.SpecificGravityApplicable = chkSpecificGravityApplicable.Checked;
					m_euCurrentEU.VolumeMax = float.Parse(txtVolumeMax.Text);
					m_euCurrentEU.VolumeMin = float.Parse(txtVolumeMin.Text);
					try { m_euCurrentEU.CurrentProduct = cboCurrentProduct.Items[cboCurrentProduct.SelectedIndex].ToString(); }
					catch { m_euCurrentEU.CurrentProduct = ""; }

					// Sounding Save Functionality
					m_euCurrentEU.SoundingTable.Clear();
					m_euCurrentEU.SoundingTable = new List<Sounding>();

					foreach (DataRow dr in ((DataTable)customXceedGridControl.DataSource).Rows)
					{
						if (dr.RowState != DataRowState.Deleted)
							m_euCurrentEU.SoundingTable.Add(new Sounding(Convert.ToSingle(dr["Level"]), Convert.ToSingle(dr["Volume"])));
					}
			}

			if (gp.GaugeType == GaugeType.Temperature)
				CheckAndAddAverageTemperature(gp);
		}

		private void CheckAndAddAverageTemperature(GaugePoint gp)
		{
			bool bAverageFound = false;

			foreach (GaugePoint vesselGp in TLIConfiguration.VesselGaugePoints[m_sEquipmentID].Values)
			{
				if (vesselGp.GaugeType == GaugeType.AverageTemperature)
				{
					bAverageFound = true;
					break;
				}
			}

			if (!bAverageFound)
			{
				GaugePoint avgGp;
				AlarmPoint apHighAlarm, apLowAlarm;

				avgGp = new GaugePoint(
					true,
					GaugeType.AverageTemperature,
					1,
					gp.RawMax,
					gp.RawMin,
					gp.EngineeringMax,
					gp.EngineeringMin,
					gp.FullScaleValue,
					gp.LowScaleValue,
					gp.LinearOffset,
					gp.DigitalFilter,
					gp.ValueDeadband,
					new List<AlarmPoint>(),
					IOType.AMU,
					new AMUInput(false, 1, 1, false),
					new TAUInput(false, 0, 0, 0),
					new ModularBubblerInput(false, 0, 0, false, 0),
					new ModbusInterface[2],
					new ModbusInterface[2]);

				avgGp.Units = gp.Units;

				avgGp.ProcessID = avgGp.CreateProcessID(m_sEquipmentID);
				avgGp.DisplayName = "Average Temperature";

				TLIConfiguration.VesselGaugePoints[m_sEquipmentID].Add(avgGp.ProcessID, avgGp);
				m_sAverageTemperatureProcessID = avgGp.ProcessID;

				if (!TLIConfiguration.VesselAlarmPoints.ContainsKey(m_sEquipmentID))
					TLIConfiguration.VesselAlarmPoints.Add(m_sEquipmentID, new Dictionary<string, Dictionary<Guid, AlarmPoint>>());

				if (!TLIConfiguration.VesselAlarmPoints[m_sEquipmentID].ContainsKey(avgGp.ProcessID))
					TLIConfiguration.VesselAlarmPoints[m_sEquipmentID].Add(avgGp.ProcessID, new Dictionary<Guid, AlarmPoint>());

				apHighAlarm = new AlarmPoint("High Temperature Alarm", true, Guid.NewGuid(), AlarmMonitorType.AnalogValue, AlarmType.HighAlarm, "Alarm", "High Temperature Alarm", 4, Comparator.GreaterThanOrEqualTo, 100, Units.UnitsID(cboUnits1.Items[cboUnits1.SelectedIndex].ToString()), 0, 0, 0, false, new List<string>(), new ModbusInterface(), new ModbusInterface());
				apLowAlarm = new AlarmPoint("Low Temperature Alarm", true, Guid.NewGuid(), AlarmMonitorType.AnalogValue, AlarmType.LowAlarm, "Alarm", "Low Temperature Alarm", 4, Comparator.LessThanOrEqualTo, 0, Units.UnitsID(cboUnits1.Items[cboUnits1.SelectedIndex].ToString()), 0, 0, 0, false, new List<string>(), new ModbusInterface(), new ModbusInterface());

				foreach (AlarmAnnunciation aa in TLIConfiguration.Vessel.AlarmAnnunciation)
				{
					if (aa.AlarmAnnunciationName == "Temperature Alarm" || aa.AlarmAnnunciationName == "Buzzer" || aa.AlarmAnnunciationName == "Gauging Buzzer")
					{
						apHighAlarm.AlarmAnnunciation.Add(aa.AlarmAnnunciationName);
						apLowAlarm.AlarmAnnunciation.Add(aa.AlarmAnnunciationName);
					}
				}

				TLIConfiguration.VesselAlarmPoints[m_sEquipmentID][avgGp.ProcessID].Add(apHighAlarm.AlarmID, apHighAlarm);
				TLIConfiguration.VesselAlarmPoints[m_sEquipmentID][avgGp.ProcessID].Add(apLowAlarm.AlarmID, apLowAlarm);
			}
		}
		#endregion

		#region Form Customization Events

		private void SetFormMaster(object sender, EventArgs e)
		{
			SetGaugePointEnable();
			
			if (chkEnable.Checked)
			{
				SetGaugeTypeControls();
				SetGaugeNumberControls();
				SetDataCollectionControls();
			}
		}
  
		private void SetGaugePointEnable()
		{
			lblDisplayName.Enabled = chkEnable.Checked;
			txtDisplayName.Enabled = chkEnable.Checked;
			lblGaugeType.Enabled = chkEnable.Checked;
			cboGaugeType.Enabled = chkEnable.Checked;
			lblGaugeNumber.Enabled = chkEnable.Checked;
			cboGaugeNumber.Enabled = chkEnable.Checked;
			lblUnits1.Enabled = chkEnable.Checked;
			cboUnits1.Enabled = chkEnable.Checked;
			lblUnits2.Enabled = chkEnable.Checked;
			cboUnits2.Enabled = chkEnable.Checked;
			lblDisableFaceplateGraph.Enabled = chkEnable.Checked;
			chkDisableFaceplateGraph.Enabled = chkEnable.Checked;

			grpDataCollection.Enabled = chkEnable.Checked;
			grpModbusInput.Enabled = chkEnable.Checked;
			grpSounding.Enabled = chkEnable.Checked;
			grpEngineering.Enabled = chkEnable.Checked;
			m_bEngineeringEnabled = chkEnable.Checked;
		}

		private void SetGaugeTypeControls()
		{
			string sGaugeType = cboGaugeType.Items[cboGaugeType.SelectedIndex].ToString();
			int iGaugeType = GaugeType.GetGaugeTypeID(sGaugeType);

			switch (iGaugeType)
			{
				case GaugeType.AverageTemperature:
					chkIOEnable.Checked = false;
					grpSounding.Enabled = false;
					EnableEngineering(false, true, false);
					grpDataCollection.Enabled = false;
					Units1Enable(true);
					Units2Enable(false);
					cboGaugeNumber.SelectedIndex = 0;
					cboGaugeNumber.Enabled = false;
					lblDisableFaceplateGraph.Enabled = false;
					chkDisableFaceplateGraph.Enabled = false;
					SoundingTableEnable(false);
//					lblPhysicalOffset.Enabled = false;
//					txtPhysicalOffset.Enabled = false;

					lblCalculated.Enabled = false;
					chkCalculated.Enabled = false;

					EnableSecondaryModbus(false);

					if (m_sProcessID == "new")
						txtDisplayName.Text = "Average Temperature";

					break;
				case GaugeType.ChannelStateAlarmMonitor:
					grpSounding.Enabled = false;
					EnableEngineering(false, false, false);
					grpDataCollection.Enabled = true;

					cboGaugeNumber.Enabled = true;
					Units1Enable(false);
					Units2Enable(false);
					chkAnalogChannel.Checked = false;
					lblDisableFaceplateGraph.Enabled = false;
					chkDisableFaceplateGraph.Enabled = false;
					SoundingTableEnable(false);
//					lblPhysicalOffset.Enabled = false;
//					txtPhysicalOffset.Enabled = false;

					lblCalculated.Enabled = false;
					chkCalculated.Enabled = false;

					EnableSecondaryModbus(false);

					break;
				case GaugeType.Level:
					grpSounding.Enabled = true;
					EnableEngineering(true, true, true);
					grpDataCollection.Enabled = true;

					Units1Enable(true);

					if (EquipmentUnit.EquipmentTypeFromEquipmentID(m_sEquipmentID) == EquipmentType.Draft)
					{
						Units2Enable(false);
						txtVolumeMax.Text = "1";
						lblVolumeMax.Enabled = false;
						txtVolumeMax.Enabled = false;
						lblVolumeMin.Enabled = false;
						txtVolumeMin.Enabled = false;
						lblCurrentProduct.Enabled = true;
						cboCurrentProduct.Enabled = true;
						lblSpecificGravityApplicable.Enabled = true;
						chkSpecificGravityApplicable.Enabled = true;

						EnableSecondaryModbus(false);
					}
					else
					{
						Units2Enable(true);
						lblVolumeMax.Enabled = true;
						txtVolumeMax.Enabled = true;
						lblVolumeMin.Enabled = true;
						txtVolumeMin.Enabled = false;
						lblCurrentProduct.Enabled = true;
						cboCurrentProduct.Enabled = true;
						lblSpecificGravityApplicable.Enabled = true;
						chkSpecificGravityApplicable.Enabled = true;

						EnableSecondaryModbus(true);
					}
					
					chkAnalogChannel.Checked = true;

					lblDisableFaceplateGraph.Enabled = true;
					chkDisableFaceplateGraph.Enabled = true;
					SoundingTableEnable(true);

//					lblPhysicalOffset.Enabled = true;
//					txtPhysicalOffset.Enabled = true;

					cboGaugeNumber.SelectedIndex = 0;
					cboGaugeNumber.Enabled = false;

					lblCalculated.Enabled = false;
					chkCalculated.Enabled = false;

					if (m_sProcessID == "new")
						txtDisplayName.Text = "Level";

					break;
				case GaugeType.List:
					grpSounding.Enabled = false;
					EnableEngineering(true, true, true);
					grpDataCollection.Enabled = true;
					//					chkAMUEnable.Checked = true;
					Units1Enable(true);
					Units2Enable(false);
					chkAnalogChannel.Checked = true;

					lblDisableFaceplateGraph.Enabled = false;
					chkDisableFaceplateGraph.Enabled = false;

					cboGaugeNumber.SelectedIndex = 0;
					cboGaugeNumber.Enabled = false;
					SoundingTableEnable(false);
//					lblPhysicalOffset.Enabled = false;
//					txtPhysicalOffset.Enabled = false;

					lblCalculated.Enabled = true;
					chkCalculated.Enabled = true;
//					chkCalculated_CheckedChanged(this, new EventArgs());

					EnableSecondaryModbus(false);

					if (m_sProcessID == "new")
						txtDisplayName.Text = "List";

					break;
				case GaugeType.Pressure:
					grpSounding.Enabled = false;
					EnableEngineering(true, true, true);
					grpDataCollection.Enabled = true;
					//					chkAMUEnable.Checked = true;
					Units1Enable(true);
					Units2Enable(false);
					chkAnalogChannel.Checked = true;

					lblDisableFaceplateGraph.Enabled = true;
					chkDisableFaceplateGraph.Enabled = true;

					cboGaugeNumber.SelectedIndex = 0;
					cboGaugeNumber.Enabled = false;
					SoundingTableEnable(false);
//					lblPhysicalOffset.Enabled = false;
//					txtPhysicalOffset.Enabled = false;

					lblCalculated.Enabled = false;
					chkCalculated.Enabled = false;

					EnableSecondaryModbus(false);

					if (m_sProcessID == "new")
						txtDisplayName.Text = "Pressure";
					break;
				case GaugeType.Temperature:
					grpSounding.Enabled = false;
					EnableEngineering(true, true, true);
					grpDataCollection.Enabled = true;
					//					chkAMUEnable.Checked = true;
					Units1Enable(true);
					Units2Enable(false);
					chkAnalogChannel.Checked = true;

					lblDisableFaceplateGraph.Enabled = true;
					chkDisableFaceplateGraph.Enabled = true;
					SoundingTableEnable(false);
//					lblPhysicalOffset.Enabled = false;
//					txtPhysicalOffset.Enabled = false;

					cboGaugeNumber.Enabled = true;

					lblCalculated.Enabled = false;
					chkCalculated.Enabled = false;

					EnableSecondaryModbus(false);

					if (m_sProcessID == "new")
						switch (cboGaugeNumber.SelectedIndex)
						{
							case 0:
							case 3:
								txtDisplayName.Text = "Temperature TOP";
								break;
							case 1:
							case 4:
								txtDisplayName.Text = "Temperature MID";
								break;
							case 2:
							case 5:
								txtDisplayName.Text = "Temperature BOT";
								break;
						}

					break;
				case GaugeType.Trim:
					grpSounding.Enabled = false;
					EnableEngineering(true, true, true);
					grpDataCollection.Enabled = true;
					Units1Enable(true);
					Units2Enable(false);
					chkAnalogChannel.Checked = true;

					lblDisableFaceplateGraph.Enabled = false;
					chkDisableFaceplateGraph.Enabled = false;

					cboGaugeNumber.SelectedIndex = 0;
					cboGaugeNumber.Enabled = false;
					SoundingTableEnable(false);
//					lblPhysicalOffset.Enabled = false;
//					txtPhysicalOffset.Enabled = false;

					lblCalculated.Enabled = true;
					chkCalculated.Enabled = true;
//					chkCalculated_CheckedChanged(this, new EventArgs());

					EnableSecondaryModbus(false);

					if (m_sProcessID == "new")
						txtDisplayName.Text = "Trim";

					break;
				case GaugeType.Ullage:
					grpSounding.Enabled = true;
					EnableEngineering(true, true, true);
					grpDataCollection.Enabled = true;
					//					chkAMUEnable.Checked = true;
					Units1Enable(true);
					Units2Enable(true);
					chkAnalogChannel.Checked = true;

					lblDisableFaceplateGraph.Enabled = true;
					chkDisableFaceplateGraph.Enabled = true;

					cboGaugeNumber.SelectedIndex = 0;

					cboGaugeNumber.Enabled = false;
					SoundingTableEnable(true);

//					lblPhysicalOffset.Enabled = true;
//					txtPhysicalOffset.Enabled = true;

					lblCalculated.Enabled = false;
					chkCalculated.Enabled = false;

					EnableSecondaryModbus(true);

					if (m_sProcessID == "new")
						txtDisplayName.Text = "Ullage";

					break;
				case GaugeType.PowerFail:
					grpSounding.Enabled = false;
					EnableEngineering(false, false, false);
					grpDataCollection.Enabled = false;
					cboUnits1.SelectedIndex = cboUnits1.FindString("Discrete");
					Units1Enable(false);
					Units2Enable(false);
					chkAnalogChannel.Checked = true;

					lblDisableFaceplateGraph.Enabled = false;
					chkDisableFaceplateGraph.Enabled = false;

					cboGaugeNumber.SelectedIndex = 0;
					cboGaugeNumber.Enabled = false;
					SoundingTableEnable(false);

//					lblPhysicalOffset.Enabled = false;
//					txtPhysicalOffset.Enabled = false;

					lblCalculated.Enabled = false;
					chkCalculated.Enabled = false;
//					chkCalculated_CheckedChanged(this, new EventArgs());


					EnableSecondaryModbus(false);

					if (m_sProcessID == "new")
						txtDisplayName.Text = "Power Fail";
					break;
				case GaugeType.HogSag:
					chkIOEnable.Checked = false;
					grpSounding.Enabled = false;
					EnableEngineering(false, true, false);
					grpDataCollection.Enabled = false;
					Units1Enable(true);
					Units2Enable(false);
					cboGaugeNumber.SelectedIndex = 0;
					cboGaugeNumber.Enabled = false;
					lblDisableFaceplateGraph.Enabled = false;
					chkDisableFaceplateGraph.Enabled = false;
					SoundingTableEnable(false);
					//					lblPhysicalOffset.Enabled = false;
					//					txtPhysicalOffset.Enabled = false;

					lblCalculated.Enabled = false;
					chkCalculated.Enabled = false;

					EnableSecondaryModbus(false);

					if (m_sProcessID == "new")
						txtDisplayName.Text = "Hog/Sag";

					break;
			}

			if (!chkIOEnable.Checked)
				EnableEngineering(false, false, false);
		}

		private void SetGaugeNumberControls()
		{
			if (m_sProcessID == "new")
			{
				string sGaugeType = cboGaugeType.Items[cboGaugeType.SelectedIndex].ToString();
				int iGaugeType = GaugeType.GetGaugeTypeID(sGaugeType);

				switch (iGaugeType)
				{
					case GaugeType.Temperature:
						{
							switch (cboGaugeNumber.SelectedIndex)
							{
								case 0:
									txtDisplayName.Text = "Temperature TOP";
									break;
								case 1:
									txtDisplayName.Text = "Temperature MID";
									break;
								case 2:
									txtDisplayName.Text = "Temperature BOT";
									break;
								case 3:
									txtDisplayName.Text = "Temperature TOP";
									break;
								case 4:
									txtDisplayName.Text = "Temperature MID";
									break;
								case 5:
									txtDisplayName.Text = "Temperature BOT";
									break;
							}
						}
						break;
				}
			}
		}

		private void SetDataCollectionControls()
		{
			bool bEnable = chkIOEnable.Checked;
			string sGaugeType = cboGaugeType.Items[cboGaugeType.SelectedIndex].ToString();
			int iGaugeType = GaugeType.GetGaugeTypeID(sGaugeType);

			lblIOType.Enabled = bEnable;
			cboIOType.Enabled = bEnable;
			lblIOAddress.Enabled = bEnable;
			cboAMUAddress.Enabled = bEnable;
			cboTAUAddress.Enabled = bEnable;
			cboMODBUBAddress.Enabled = bEnable;
			lblIOChannel.Enabled = bEnable;
			cboIOChannel.Enabled = bEnable;
			cboIOChannel8.Enabled = bEnable;
			lblIOChannelGroupType.Enabled = bEnable;
			cboIOChannelGroupType.Enabled = bEnable;
			lblAnalogChannel.Enabled = bEnable;
			chkAnalogChannel.Enabled = bEnable;
			lblSecondaryChannelEnable.Enabled = bEnable;
			chkSecondaryChannelEnable.Enabled = bEnable;
			lblSecondaryChannel.Enabled = bEnable;
			cboSecondaryChannel.Enabled = bEnable;
			grpModbusInput.Enabled = bEnable;
			lblDFGFloat.Enabled = false;
			cboDFGFloat.Enabled = false;

			if (bEnable)
			{
				lblCalculated.Enabled = false;
				chkCalculated.Enabled = false;

				chkCalculated.CheckedChanged -= new EventHandler(chkCalculated_CheckedChanged);
				chkCalculated.Checked = false;
				chkCalculated.CheckedChanged += new EventHandler(chkCalculated_CheckedChanged);
			}

			switch (iGaugeType)
			{
				case GaugeType.List:
				case GaugeType.Trim:
					{
						lblCalculated.Enabled = true;
						chkCalculated.Enabled = true;

						EnableEngineering(bEnable, bEnable, bEnable);
						lblPhysicalOffset.Enabled = false;
						txtPhysicalOffset.Enabled = false;
					}
					break;
				case GaugeType.AverageTemperature:
					EnableEngineering(false, true, false);
					break;
				case GaugeType.HogSag:
					EnableEngineering(false, true, false);
					break;
				default:
					lblCalculated.Enabled = false;
					chkCalculated.Enabled = false;
					break;
			}

			if (chkCalculated.Checked)
			{
				lblIOEnable.Enabled = false;
				chkIOEnable.Enabled = false;

				lblIOType.Enabled = false;
				cboIOType.Enabled = false;
				lblIOAddress.Enabled = false;
				cboAMUAddress.Enabled = false;
				cboTAUAddress.Enabled = false;
				cboMODBUBAddress.Enabled = false;
				lblIOChannel.Enabled = false;
				cboIOChannel.Enabled = false;
				cboIOChannel8.Enabled = false;
				chkSecondaryChannelEnable.Enabled = false;
				cboSecondaryChannel.Enabled = false;
				lblIOChannelGroupType.Enabled = false;
				cboIOChannelGroupType.Enabled = false;

				EnableEngineering(false, false, false);
				lblPhysicalOffset.Enabled = false;
				txtPhysicalOffset.Enabled = false;

				grpModbusInput.Enabled = false;
			}
			else
			{
				lblIOEnable.Enabled = true;
				chkIOEnable.Enabled = true;
			}

			if (!bEnable)
				return;

			if (cboIOType.SelectedItem.ToString() == IOType.AMUString)
			{
				lblIOAddress.Enabled = true;
				cboAMUAddress.Visible = true;
				cboTAUAddress.Visible = false;
				cboMODBUBAddress.Visible = false;

				lblIOChannel.Enabled = true;
				cboIOChannel.Visible = true;
				cboIOChannel8.Visible = false;

				lblIOChannelGroupType.Enabled = false;
				cboIOChannelGroupType.Enabled = false;

				lblAnalogChannel.Enabled = true;
				chkAnalogChannel.Enabled = true;
				/*
				lblRawMax.Enabled = true;
				lblRawMin.Enabled = true;
				txtRawMax.Enabled = true;
				txtRawMin.Enabled = true;

				lblDigitalFilter.Enabled = true;
				txtDigitalFilter.Enabled = true;
				lblEngineeringMin.Enabled = true;
				txtEngineeringMin.Enabled = true;
				lblEngineeringMax.Enabled = true;
				txtEngineeringMax.Enabled = true;
				*/
				lblDFGFloat.Enabled = false;
				cboDFGFloat.Enabled = false;
				
				lblSecondaryChannelEnable.Enabled = false;
				lblSecondaryChannel.Enabled = false;
				chkSecondaryChannelEnable.Enabled = false;
				cboSecondaryChannel.Enabled = false;
				
				grpModbusInput.Enabled = false;

				if (m_sProcessID == "new" && cboAMUAddress.Items.Count > 0 && cboAMUAddress.SelectedIndex >= 0)
					cboIOChannel.SelectedIndex = TLIConfiguration.FindMaxAMUChannel(Convert.ToInt32(cboAMUAddress.Items[cboAMUAddress.SelectedIndex]));
			}
			else if (cboIOType.SelectedItem.ToString() == IOType.TAUString)
			{
				lblIOAddress.Enabled = true;
				cboAMUAddress.Visible = false;
				cboTAUAddress.Visible = true;
				cboMODBUBAddress.Visible = false;

				lblIOChannel.Enabled = true;
				cboIOChannel.Visible = true;
				cboIOChannel8.Visible = false;

				lblIOChannelGroupType.Enabled = true;
				cboIOChannelGroupType.Enabled = true;

				lblAnalogChannel.Enabled = false;
				chkAnalogChannel.Enabled = false;

				lblRawMax.Enabled = false;
				lblRawMin.Enabled = false;
				txtRawMax.Enabled = false;
				txtRawMin.Enabled = false;

				/*
				lblDigitalFilter.Enabled = true;
				txtDigitalFilter.Enabled = true;
				lblEngineeringMin.Enabled = true;
				txtEngineeringMin.Enabled = true;
				lblEngineeringMax.Enabled = true;
				txtEngineeringMax.Enabled = true;
				*/

				lblDFGFloat.Enabled = true;
				cboDFGFloat.Enabled = true;

				lblSecondaryChannelEnable.Enabled = false;
				lblSecondaryChannel.Enabled = false;
				chkSecondaryChannelEnable.Enabled = false;
				cboSecondaryChannel.Enabled = false;

				grpModbusInput.Enabled = false;

				if (m_sProcessID == "new" && cboTAUAddress.Items.Count > 0 && cboTAUAddress.SelectedIndex >= 0 && cboIOChannelGroupType.SelectedIndex >= 0)
					cboIOChannel.SelectedIndex =
						TLIConfiguration.FindMaxTAUChannel(Convert.ToInt32(cboTAUAddress.Items[cboTAUAddress.SelectedIndex]), ICBObjectModel.Enumerations.TAUChannelGroupType.GetChannelGroupTypeID(cboIOChannelGroupType.Items[cboIOChannelGroupType.SelectedIndex].ToString()));
			}
			else if (cboIOType.SelectedItem.ToString() == IOType.ModularBubblerString)
			{
				lblIOAddress.Enabled = true;
				cboAMUAddress.Visible = false;
				cboTAUAddress.Visible = false;
				cboMODBUBAddress.Visible = true;

				lblIOChannel.Enabled = true;
				cboIOChannel.Visible = false;
				cboIOChannel8.Visible = true;

				lblIOChannelGroupType.Enabled = false;
				cboIOChannelGroupType.Enabled = false;

				lblAnalogChannel.Enabled = false;
				chkAnalogChannel.Enabled = false;

				lblRawMax.Enabled = false;
				lblRawMin.Enabled = false;
				txtRawMax.Enabled = false;
				txtRawMin.Enabled = false;

				/*
				lblDigitalFilter.Enabled = true;
				txtDigitalFilter.Enabled = true;
				lblEngineeringMin.Enabled = true;
				txtEngineeringMin.Enabled = true;
				lblEngineeringMax.Enabled = true;
				txtEngineeringMax.Enabled = true;
				*/

				lblDFGFloat.Enabled = false;
				cboDFGFloat.Enabled = false;

				lblSecondaryChannelEnable.Enabled = true;
				chkSecondaryChannelEnable.Enabled = true;
				lblSecondaryChannel.Enabled = chkSecondaryChannelEnable.Checked;
				cboSecondaryChannel.Enabled = chkSecondaryChannelEnable.Checked;

				grpModbusInput.Enabled = false;

				if (m_sProcessID == "new" && cboMODBUBAddress.Items.Count > 0 && cboMODBUBAddress.SelectedIndex >= 0)
					cboIOChannel8.SelectedIndex = TLIConfiguration.FindMaxMODBUBChannel(Convert.ToInt32(cboMODBUBAddress.Items[cboMODBUBAddress.SelectedIndex]));
			}
			else if (cboIOType.SelectedItem.ToString() == IOType.ModbusString)
			{
				lblIOAddress.Enabled = false;
				cboAMUAddress.Visible = false;
				cboTAUAddress.Visible = false;
				cboMODBUBAddress.Visible = false;

				lblIOChannel.Enabled = false;
				cboIOChannel.Visible = false;
				cboIOChannel8.Visible = false;

				lblIOChannelGroupType.Enabled = false;
				cboIOChannelGroupType.Enabled = false;

				lblAnalogChannel.Enabled = false;
				chkAnalogChannel.Enabled = false;

				lblRawMax.Enabled = false;
				lblRawMin.Enabled = false;
				txtRawMax.Enabled = false;
				txtRawMin.Enabled = false;

				lblDigitalFilter.Enabled = false;
				txtDigitalFilter.Enabled = false;
				/*
				lblEngineeringMin.Enabled = true;
				txtEngineeringMin.Enabled = true;
				lblEngineeringMax.Enabled = true;
				txtEngineeringMax.Enabled = true;
				*/
				lblDFGFloat.Enabled = false;
				cboDFGFloat.Enabled = false;
				
				lblSecondaryChannelEnable.Enabled = false;
				lblSecondaryChannel.Enabled = false;
				chkSecondaryChannelEnable.Enabled = false;
				cboSecondaryChannel.Enabled = false;
				grpModbusInput.Enabled = true;

				/*
				lblSecondaryChannel.Enabled = chkSecondaryChannelEnable.Checked;
				cboSecondaryChannel.Enabled = chkSecondaryChannelEnable.Checked;

				lblSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
				cboSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
				lblSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
				txtSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
				lblSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
				txtSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
				lblSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;
				txtSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;
				*/
				if (cboModbusInputDataType.Items[cboModbusInputDataType.SelectedIndex].ToString() == ModbusDataType.Float32String)
					txtModbusInputRegister2.Enabled = true;
				else
					txtModbusInputRegister2.Enabled = false;

				if (cboSecondaryModbusInputDataType.Items[cboSecondaryModbusInputDataType.SelectedIndex].ToString() == ModbusDataType.Float32String)
					txtSecondaryModbusInputRegister2.Enabled = true;
				else
					txtSecondaryModbusInputRegister2.Enabled = false;

				if (m_sProcessID == "new")
				{
					ushort iMaxModbusInput = TLIConfiguration.FindMaxModbusInputAddress();

					txtModbusInputRegister1.Text = (iMaxModbusInput + 1).ToString();
					txtModbusInputRegister2.Text = (iMaxModbusInput + 2).ToString();

					txtSecondaryModbusInputRegister1.Text = (iMaxModbusInput + 3).ToString();
					txtSecondaryModbusInputRegister2.Text = (iMaxModbusInput + 4).ToString();

				}
			}
		}

		private void chkCalculated_CheckedChanged(object sender, EventArgs e)
		{
			SetFormMaster(sender, e);
			//return;

			if (chkCalculated.Checked)
			{
				lblIOEnable.Enabled = false;
				chkIOEnable.Enabled = false;

				lblIOType.Enabled = false;
				cboIOType.Enabled = false;
				lblIOAddress.Enabled = false;
				cboAMUAddress.Enabled = false;
				cboTAUAddress.Enabled = false;
				cboMODBUBAddress.Enabled = false;
				lblIOChannel.Enabled = false;
				cboIOChannel.Enabled = false;
				cboIOChannel8.Enabled = false;
				chkSecondaryChannelEnable.Enabled = false;
				cboSecondaryChannel.Enabled = false;
				lblIOChannelGroupType.Enabled = false;
				cboIOChannelGroupType.Enabled = false;
				
				EnableEngineering(false, false, false);
				lblPhysicalOffset.Enabled = false;
				txtPhysicalOffset.Enabled = false;

				grpModbusInput.Enabled = false;
			}
			else
			{
				lblIOEnable.Enabled = true;
				chkIOEnable.Enabled = true;
			}
		}

		private void cboGaugeNumber_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetFormMaster(sender, e);
			//return;

			if (m_sProcessID == "new")
			{
				string sGaugeType = cboGaugeType.Items[cboGaugeType.SelectedIndex].ToString();
				int iGaugeType = GaugeType.GetGaugeTypeID(sGaugeType);

				switch (iGaugeType)
				{
					case GaugeType.Temperature:
						{
							switch (cboGaugeNumber.SelectedIndex)
							{
								case 0:
									txtDisplayName.Text = "Temperature TOP";
									break;
								case 1:
									txtDisplayName.Text = "Temperature MID";
									break;
								case 2:
									txtDisplayName.Text = "Temperature BOT";
									break;
							}
						}
						break;
				}
			}
		}

		private void cboGaugeType_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetFormMaster(sender, e);
			//return;

			string sGaugeType = cboGaugeType.Items[cboGaugeType.SelectedIndex].ToString();
			int iGaugeType = GaugeType.GetGaugeTypeID(sGaugeType);

			switch (iGaugeType)
			{
				case GaugeType.AverageTemperature:
					grpSounding.Enabled = false;
					chkIOEnable.Checked = false;
					EnableEngineering(false, true, false);
					grpDataCollection.Enabled = false;
					Units1Enable(true);
					Units2Enable(false);
					cboGaugeNumber.SelectedIndex = 0;
					cboGaugeNumber.Enabled = false;
					lblDisableFaceplateGraph.Enabled = false;
					chkDisableFaceplateGraph.Enabled = false;
					SoundingTableEnable(false);
					lblPhysicalOffset.Enabled = false;
					txtPhysicalOffset.Enabled = false;

					lblCalculated.Enabled = false;
					chkCalculated.Enabled = false;

					chkSecondaryModbusInputEnabled.Checked = false;
					lblSecondaryModbusInputEnabled.Enabled = chkSecondaryModbusInputEnabled.Checked;
					chkSecondaryModbusInputEnabled.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
					cboSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;


					if(m_sProcessID == "new")
						txtDisplayName.Text = "Average Temperature";

					break;
				case GaugeType.ChannelStateAlarmMonitor:
					grpSounding.Enabled = false;
					EnableEngineering(false, false, false);
					grpDataCollection.Enabled = true;
//					chkAMUEnable.Checked = true;
					cboGaugeNumber.Enabled = true;
					Units1Enable(false);
					Units2Enable(false);
					chkAnalogChannel.Checked = false;
					lblDisableFaceplateGraph.Enabled = false;
					chkDisableFaceplateGraph.Enabled = false;
					SoundingTableEnable(false);
					lblPhysicalOffset.Enabled = false;
					txtPhysicalOffset.Enabled = false;

					lblCalculated.Enabled = false;
					chkCalculated.Enabled = false;

					chkSecondaryModbusInputEnabled.Checked = false;
					lblSecondaryModbusInputEnabled.Enabled = chkSecondaryModbusInputEnabled.Checked;
					chkSecondaryModbusInputEnabled.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
					cboSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;

					//if (m_sProcessID == "new")
					//	txtDisplayName.Text = "";

					break;
				case GaugeType.Level:
					grpSounding.Enabled = true;
					EnableEngineering(true, true,  true);
					grpDataCollection.Enabled = true;
//					chkAMUEnable.Checked = true;
					Units1Enable(true);

					if (EquipmentUnit.EquipmentTypeFromEquipmentID(m_sEquipmentID) == EquipmentType.Draft)
					{
						Units2Enable(false);
						txtVolumeMax.Text = "1";
						lblVolumeMax.Enabled = false;
						txtVolumeMax.Enabled = false;
						lblVolumeMin.Enabled = false;
						txtVolumeMin.Enabled = false;
						lblCurrentProduct.Enabled = false;
						cboCurrentProduct.Enabled = false;
						lblSpecificGravityApplicable.Enabled = false;
						chkSpecificGravityApplicable.Enabled = false;

						chkSecondaryModbusInputEnabled.Checked = false;
						lblSecondaryModbusInputEnabled.Enabled = chkSecondaryModbusInputEnabled.Checked;
						chkSecondaryModbusInputEnabled.Enabled = chkSecondaryModbusInputEnabled.Checked;
						lblSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
						cboSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
						lblSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
						txtSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
						lblSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
						txtSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
						lblSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;
						txtSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;
					}
					else
					{
						Units2Enable(true);
						lblVolumeMax.Enabled = true;
						txtVolumeMax.Enabled = true;
						lblVolumeMin.Enabled = false;
						txtVolumeMin.Enabled = false;
						lblCurrentProduct.Enabled = true;
						cboCurrentProduct.Enabled = true;
						lblSpecificGravityApplicable.Enabled = true;
						chkSpecificGravityApplicable.Enabled = true;

						lblSecondaryModbusInputEnabled.Enabled = true;
						chkSecondaryModbusInputEnabled.Enabled = true;
						lblSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
						cboSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
						lblSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
						txtSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
						lblSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
						txtSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
						lblSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;
						txtSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;

					}
					chkAnalogChannel.Checked = true;

					lblDisableFaceplateGraph.Enabled = true;
					chkDisableFaceplateGraph.Enabled = true;
					SoundingTableEnable(true);
					lblPhysicalOffset.Enabled = true;
					txtPhysicalOffset.Enabled = true;

					cboGaugeNumber.SelectedIndex = 0;
					cboGaugeNumber.Enabled = false;

					lblCalculated.Enabled = false;
					chkCalculated.Enabled = false;

					if (m_sProcessID == "new")
						txtDisplayName.Text = "Level";

					break;
				case GaugeType.List:
					grpSounding.Enabled = false;
					EnableEngineering(true, true, true);
					grpDataCollection.Enabled = true;
//					chkAMUEnable.Checked = true;
					Units1Enable(true);
					Units2Enable(false);
					chkAnalogChannel.Checked = true;

					lblDisableFaceplateGraph.Enabled = false;
					chkDisableFaceplateGraph.Enabled = false;

					cboGaugeNumber.SelectedIndex = 0;
					cboGaugeNumber.Enabled = false;
					SoundingTableEnable(false);
					lblPhysicalOffset.Enabled = false;
					txtPhysicalOffset.Enabled = false;

					lblCalculated.Enabled = true;
					chkCalculated.Enabled = true;
					chkCalculated_CheckedChanged(this, new EventArgs());

					chkSecondaryModbusInputEnabled.Checked = false;
					lblSecondaryModbusInputEnabled.Enabled = chkSecondaryModbusInputEnabled.Checked;
					chkSecondaryModbusInputEnabled.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
					cboSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;

					if (m_sProcessID == "new")
						txtDisplayName.Text = "List";

					break;
				case GaugeType.Pressure:
					grpSounding.Enabled = false;
					EnableEngineering(true, true, true);
					grpDataCollection.Enabled = true;
//					chkAMUEnable.Checked = true;
					Units1Enable(true);
					Units2Enable(false);
					chkAnalogChannel.Checked = true;

					lblDisableFaceplateGraph.Enabled = true;
					chkDisableFaceplateGraph.Enabled = true;

					cboGaugeNumber.SelectedIndex = 0;
					cboGaugeNumber.Enabled = false;
					SoundingTableEnable(false);
					lblPhysicalOffset.Enabled = false;
					txtPhysicalOffset.Enabled = false;

					lblCalculated.Enabled = false;
					chkCalculated.Enabled = false;

					chkSecondaryModbusInputEnabled.Checked = false;
					lblSecondaryModbusInputEnabled.Enabled = chkSecondaryModbusInputEnabled.Checked;
					chkSecondaryModbusInputEnabled.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
					cboSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;

					if (m_sProcessID == "new")
						txtDisplayName.Text = "Pressure";
					break;
				case GaugeType.Temperature:
					grpSounding.Enabled = false;
					EnableEngineering(true, true, true);
					grpDataCollection.Enabled = true;
//					chkAMUEnable.Checked = true;
					Units1Enable(true);
					Units2Enable(false);
					chkAnalogChannel.Checked = true;

					lblDisableFaceplateGraph.Enabled = true;
					chkDisableFaceplateGraph.Enabled = true;
					SoundingTableEnable(false);
					lblPhysicalOffset.Enabled = false;
					txtPhysicalOffset.Enabled = false;

					cboGaugeNumber.Enabled = true;

					lblCalculated.Enabled = false;
					chkCalculated.Enabled = false;

					chkSecondaryModbusInputEnabled.Checked = false;
					lblSecondaryModbusInputEnabled.Enabled = chkSecondaryModbusInputEnabled.Checked;
					chkSecondaryModbusInputEnabled.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
					cboSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;

					if (m_sProcessID == "new")
						switch (cboGaugeNumber.SelectedIndex)
						{
							case 0:
							case 3:
								txtDisplayName.Text = "Temperature TOP";
								break;
							case 1:
							case 4:
								txtDisplayName.Text = "Temperature MID";
								break;
							case 2:
							case 5:
								txtDisplayName.Text = "Temperature BOT";
								break;
						}

					break;
				case GaugeType.Trim:
					grpSounding.Enabled = false;
					EnableEngineering(true, true,  true);
					grpDataCollection.Enabled = true;
					Units1Enable(true);
					Units2Enable(false);
					chkAnalogChannel.Checked = true;

					lblDisableFaceplateGraph.Enabled = false;
					chkDisableFaceplateGraph.Enabled = false;

					cboGaugeNumber.SelectedIndex = 0;
					cboGaugeNumber.Enabled = false;
					SoundingTableEnable(false);
					lblPhysicalOffset.Enabled = false;
					txtPhysicalOffset.Enabled = false;

					lblCalculated.Enabled = true;
					chkCalculated.Enabled = true;
					chkCalculated_CheckedChanged(this, new EventArgs());

					chkSecondaryModbusInputEnabled.Checked = false;
					lblSecondaryModbusInputEnabled.Enabled = chkSecondaryModbusInputEnabled.Checked;
					chkSecondaryModbusInputEnabled.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
					cboSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;

					if (m_sProcessID == "new")
						txtDisplayName.Text = "Trim";

					break;
				case GaugeType.Ullage:
					grpSounding.Enabled = true;
					EnableEngineering(true, true,  true);
					grpDataCollection.Enabled = true;
//					chkAMUEnable.Checked = true;
					Units1Enable(true);
					Units2Enable(true);
					chkAnalogChannel.Checked = true;

					lblDisableFaceplateGraph.Enabled = true;
					chkDisableFaceplateGraph.Enabled = true;

					cboGaugeNumber.SelectedIndex = 0;

					cboGaugeNumber.Enabled = false;
					SoundingTableEnable(true);
					lblPhysicalOffset.Enabled = true;
					txtPhysicalOffset.Enabled = true;

					lblCalculated.Enabled = false;
					chkCalculated.Enabled = false;

					lblVolumeMin.Enabled = false;
					txtVolumeMin.Enabled = false;

					lblSecondaryModbusInputEnabled.Enabled = true;
					chkSecondaryModbusInputEnabled.Enabled = true;
					lblSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
					cboSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;

					if (m_sProcessID == "new")
						txtDisplayName.Text = "Ullage";

					break;
				case GaugeType.PowerFail:
					grpSounding.Enabled = false;
					EnableEngineering(false, false, false);
					grpDataCollection.Enabled = false;
					cboUnits1.SelectedIndex = cboUnits1.FindString("Discrete");
					Units1Enable(false);
					Units2Enable(false);
					chkAnalogChannel.Checked = true;

					lblDisableFaceplateGraph.Enabled = false;
					chkDisableFaceplateGraph.Enabled = false;

					cboGaugeNumber.SelectedIndex = 0;
					cboGaugeNumber.Enabled = false;
					SoundingTableEnable(false);
					lblPhysicalOffset.Enabled = false;
					txtPhysicalOffset.Enabled = false;

					lblCalculated.Enabled = false;
					chkCalculated.Enabled = false;
					chkCalculated_CheckedChanged(this, new EventArgs());

					chkSecondaryModbusInputEnabled.Checked = false;
					lblSecondaryModbusInputEnabled.Enabled = chkSecondaryModbusInputEnabled.Checked;
					chkSecondaryModbusInputEnabled.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
					cboSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;

					if (m_sProcessID == "new")
						txtDisplayName.Text = "Power Fail";
					break;
				case GaugeType.HogSag:
					grpSounding.Enabled = false;
					chkIOEnable.Checked = false;
					EnableEngineering(false, true, false);
					grpDataCollection.Enabled = false;
					Units1Enable(true);
					Units2Enable(false);
					chkAnalogChannel.Checked = true;

					lblDisableFaceplateGraph.Enabled = false;
					chkDisableFaceplateGraph.Enabled = false;

					cboGaugeNumber.SelectedIndex = 0;
					cboGaugeNumber.Enabled = false;
					SoundingTableEnable(false);
					lblPhysicalOffset.Enabled = false;
					txtPhysicalOffset.Enabled = false;

					lblCalculated.Enabled = false;
					chkCalculated.Enabled = false;
					chkCalculated_CheckedChanged(this, new EventArgs());

					chkSecondaryModbusInputEnabled.Checked = false;
					lblSecondaryModbusInputEnabled.Enabled = chkSecondaryModbusInputEnabled.Checked;
					chkSecondaryModbusInputEnabled.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
					cboSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
					lblSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;
					txtSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;

					if (m_sProcessID == "new")
						txtDisplayName.Text = "Hog/Sag";
					break;
			}

		}

		private void chkEnable_CheckedChanged(object sender, EventArgs e)
		{
			SetFormMaster(sender, e);
			//return;

			bool bEnable = chkEnable.Checked;

			lblDisplayName.Enabled = chkEnable.Checked;
			txtDisplayName.Enabled = chkEnable.Checked;
			lblGaugeType.Enabled = chkEnable.Checked;
			cboGaugeType.Enabled = chkEnable.Checked;
			lblGaugeNumber.Enabled = chkEnable.Checked;
			cboGaugeNumber.Enabled = chkEnable.Checked;
			lblUnits1.Enabled = chkEnable.Checked;
			cboUnits1.Enabled = chkEnable.Checked;
			lblUnits2.Enabled = chkEnable.Checked;
			cboUnits2.Enabled = chkEnable.Checked;
			lblDisableFaceplateGraph.Enabled = chkEnable.Checked;
			chkDisableFaceplateGraph.Enabled = chkEnable.Checked;

			grpDataCollection.Enabled = chkEnable.Checked;
			grpModbusInput.Enabled = chkEnable.Checked;
			grpSounding.Enabled = chkEnable.Checked;
			grpEngineering.Enabled = chkEnable.Checked;
			m_bEngineeringEnabled = chkEnable.Checked;

			if(bEnable)
				cboGaugeType_SelectedIndexChanged(sender, new EventArgs());
		}

		private void chkIOEnable_CheckedChanged(object sender, EventArgs e)
		{
			SetFormMaster(sender, e);
			//return;

			bool bEnable = chkIOEnable.Checked;
			string sGaugeType = cboGaugeType.Items[cboGaugeType.SelectedIndex].ToString();
			int iGaugeType = GaugeType.GetGaugeTypeID(sGaugeType);

			lblIOType.Enabled = bEnable;
			cboIOType.Enabled = bEnable;
			lblIOAddress.Enabled = bEnable;
			cboAMUAddress.Enabled = bEnable;
			cboTAUAddress.Enabled = bEnable;
			cboMODBUBAddress.Enabled = bEnable;
			lblIOChannel.Enabled = bEnable;
			cboIOChannel.Enabled = bEnable;
			cboIOChannel8.Enabled = bEnable;
			lblIOChannelGroupType.Enabled = bEnable;
			cboIOChannelGroupType.Enabled = bEnable;
			lblAnalogChannel.Enabled = bEnable;
			chkAnalogChannel.Enabled = bEnable;
			lblSecondaryChannelEnable.Enabled = bEnable;
			chkSecondaryChannelEnable.Enabled = bEnable;
			lblSecondaryChannel.Enabled = bEnable;
			cboSecondaryChannel.Enabled = bEnable;

			if (bEnable)
			{
				lblCalculated.Enabled = false;
				chkCalculated.Enabled = false;

				chkCalculated.CheckedChanged -= new EventHandler(chkCalculated_CheckedChanged);
				chkCalculated.Checked = false;
				chkCalculated.CheckedChanged += new EventHandler(chkCalculated_CheckedChanged);
			}
			switch (iGaugeType)
			{
				case GaugeType.List:
				case GaugeType.Trim:
					{
						lblCalculated.Enabled = true;
						chkCalculated.Enabled = true;
						
						EnableEngineering(bEnable, bEnable, bEnable);
						lblPhysicalOffset.Enabled = false;
						txtPhysicalOffset.Enabled = false;
					}
					break;
				default:
					lblCalculated.Enabled = false;
					chkCalculated.Enabled = false;
					break;

			}

			if (bEnable)
				cboIOType_SelectedIndexChanged(sender, e);
		}

		private void cboIOType_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetFormMaster(sender, e);
			//return;

			if (cboIOType.SelectedItem.ToString() == IOType.AMUString && GaugeType.GetGaugeTypeID(cboGaugeType.SelectedItem.ToString()) != GaugeType.ChannelStateAlarmMonitor)
			{
				//Console.WriteLine("COMBO : " + GaugeType.GetGaugeTypeID(cboGaugeType.SelectedItem.ToString()));
				lblIOAddress.Enabled = true;
				cboAMUAddress.Visible = true;
				cboTAUAddress.Visible = false;
				cboMODBUBAddress.Visible = false;

				lblIOChannel.Enabled = true;
				cboIOChannel.Visible = true;
				cboIOChannel8.Visible = false;

				lblIOChannelGroupType.Enabled = false;
				cboIOChannelGroupType.Enabled = false;

				lblAnalogChannel.Enabled = true;
				chkAnalogChannel.Enabled = true;

				lblRawMax.Enabled = true;
				lblRawMin.Enabled = true;
				txtRawMax.Enabled = true;
				txtRawMin.Enabled = true;

				lblDigitalFilter.Enabled = true;
				txtDigitalFilter.Enabled = true;
				lblEngineeringMin.Enabled = true;
				txtEngineeringMin.Enabled = true;
				lblEngineeringMax.Enabled = true;
				txtEngineeringMax.Enabled = true;

				lblDFGFloat.Enabled = false;
				cboDFGFloat.Enabled = false;

				lblSecondaryChannelEnable.Enabled = false;
				lblSecondaryChannel.Enabled = false;
				chkSecondaryChannelEnable.Enabled = false;
				cboSecondaryChannel.Enabled = false;

				grpModbusInput.Enabled = false;

				if (m_sProcessID == "new" && cboAMUAddress.Items.Count > 0 && cboAMUAddress.SelectedIndex >= 0)
					cboIOChannel.SelectedIndex = TLIConfiguration.FindMaxAMUChannel(Convert.ToInt32(cboAMUAddress.Items[cboAMUAddress.SelectedIndex]));
			}
			else if (cboIOType.SelectedItem.ToString() == IOType.TAUString)
			{
				lblIOAddress.Enabled = true;
				cboAMUAddress.Visible = false;
				cboTAUAddress.Visible = true;
				cboMODBUBAddress.Visible = false;

				lblIOChannel.Enabled = true;
				cboIOChannel.Visible = true;
				cboIOChannel8.Visible = false;

				lblIOChannelGroupType.Enabled = true;
				cboIOChannelGroupType.Enabled = true;

				lblAnalogChannel.Enabled = false;
				chkAnalogChannel.Enabled = false;

				lblRawMax.Enabled = false;
				lblRawMin.Enabled = false;
				txtRawMax.Enabled = false;
				txtRawMin.Enabled = false;

				lblDigitalFilter.Enabled = true;
				txtDigitalFilter.Enabled = true;
				lblEngineeringMin.Enabled = true;
				txtEngineeringMin.Enabled = true;
				lblEngineeringMax.Enabled = true;
				txtEngineeringMax.Enabled = true;

				lblDFGFloat.Enabled = true;
				cboDFGFloat.Enabled = true;

				lblSecondaryChannelEnable.Enabled = false;
				lblSecondaryChannel.Enabled = false;
				chkSecondaryChannelEnable.Enabled = false;
				cboSecondaryChannel.Enabled = false;

				grpModbusInput.Enabled = false;

				if (m_sProcessID == "new" && cboTAUAddress.Items.Count > 0 && cboTAUAddress.SelectedIndex >= 0 && cboIOChannelGroupType.SelectedIndex >= 0)
					cboIOChannel.SelectedIndex =
						TLIConfiguration.FindMaxTAUChannel(Convert.ToInt32(cboTAUAddress.Items[cboTAUAddress.SelectedIndex]), ICBObjectModel.Enumerations.TAUChannelGroupType.GetChannelGroupTypeID(cboIOChannelGroupType.Items[cboIOChannelGroupType.SelectedIndex].ToString()));
			}
			else if (cboIOType.SelectedItem.ToString() == IOType.ModularBubblerString)
			{
				lblIOAddress.Enabled = true;
				cboAMUAddress.Visible = false;
				cboTAUAddress.Visible = false;
				cboMODBUBAddress.Visible = true;

				lblIOChannel.Enabled = true;
				cboIOChannel.Visible = false;
				cboIOChannel8.Visible = true;

				lblIOChannelGroupType.Enabled = false;
				cboIOChannelGroupType.Enabled = false;

				lblAnalogChannel.Enabled = false;
				chkAnalogChannel.Enabled = false;

				lblRawMax.Enabled = false;
				lblRawMin.Enabled = false;
				txtRawMax.Enabled = false;
				txtRawMin.Enabled = false;

				lblDigitalFilter.Enabled = true;
				txtDigitalFilter.Enabled = true;
				lblEngineeringMin.Enabled = true;
				txtEngineeringMin.Enabled = true;
				lblEngineeringMax.Enabled = true;
				txtEngineeringMax.Enabled = true;

				lblDFGFloat.Enabled = false;
				cboDFGFloat.Enabled = false;

				lblSecondaryChannelEnable.Enabled = true;
				chkSecondaryChannelEnable.Enabled = true;
				lblSecondaryChannel.Enabled = chkSecondaryChannelEnable.Checked;
				cboSecondaryChannel.Enabled = chkSecondaryChannelEnable.Checked;

				grpModbusInput.Enabled = false;

				if (m_sProcessID == "new" && cboMODBUBAddress.Items.Count > 0 && cboMODBUBAddress.SelectedIndex >= 0)
					cboIOChannel8.SelectedIndex = TLIConfiguration.FindMaxMODBUBChannel(Convert.ToInt32(cboMODBUBAddress.Items[cboMODBUBAddress.SelectedIndex]));
			}
			else if (cboIOType.SelectedItem.ToString() == IOType.ModbusString)
			{
				lblIOAddress.Enabled = false;
				cboAMUAddress.Visible = false;
				cboTAUAddress.Visible = false;
				cboMODBUBAddress.Visible = false;

				lblIOChannel.Enabled = false;
				cboIOChannel.Visible = false;
				cboIOChannel8.Visible = false;

				lblIOChannelGroupType.Enabled = false;
				cboIOChannelGroupType.Enabled = false;

				lblAnalogChannel.Enabled = false;
				chkAnalogChannel.Enabled = false;

				lblRawMax.Enabled = false;
				lblRawMin.Enabled = false;
				txtRawMax.Enabled = false;
				txtRawMin.Enabled = false;

				lblDigitalFilter.Enabled = false;
				txtDigitalFilter.Enabled = false;
				lblEngineeringMin.Enabled = true;
				txtEngineeringMin.Enabled = true;
				lblEngineeringMax.Enabled = true;
				txtEngineeringMax.Enabled = true;

				lblDFGFloat.Enabled = false;
				cboDFGFloat.Enabled = false;

				lblSecondaryChannelEnable.Enabled = false;
				lblSecondaryChannel.Enabled = false;
				chkSecondaryChannelEnable.Enabled = false;
				cboSecondaryChannel.Enabled = false;

				grpModbusInput.Enabled = true;

				if (m_sProcessID == "new")
				{
					ushort iMaxModbusInput = TLIConfiguration.FindMaxModbusInputAddress();

					txtModbusInputRegister1.Text = (iMaxModbusInput + 1).ToString();
					txtModbusInputRegister2.Text = (iMaxModbusInput + 2).ToString();

					txtSecondaryModbusInputRegister1.Text = (iMaxModbusInput + 3).ToString();
					txtSecondaryModbusInputRegister2.Text = (iMaxModbusInput + 4).ToString();

				}
			}
		}

		private void chkSecondaryChannelEnable_CheckedChanged(object sender, EventArgs e)
		{
			SetFormMaster(sender, e);
			//return;

			lblSecondaryChannel.Enabled = chkSecondaryChannelEnable.Checked;
			cboSecondaryChannel.Enabled = chkSecondaryChannelEnable.Checked;
		}

		private void chkSecondaryModbusInputEnabled_CheckedChanged(object sender, EventArgs e)
		{
			SetFormMaster(sender, e);
			//return;

			lblSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
			cboSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
			lblSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
			txtSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
			lblSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
			txtSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
			lblSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;
			txtSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;
		}

		private void cboModbusInputDataType_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetFormMaster(sender, e);
			//return;

			if (cboModbusInputDataType.Items[cboModbusInputDataType.SelectedIndex].ToString() == ModbusDataType.Float32String)
				txtModbusInputRegister2.Enabled = true;
			else
				txtModbusInputRegister2.Enabled = false;
		}

		private void cboSecondaryModbusInputDataType_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetFormMaster(sender, e);
			//return;

			if (cboSecondaryModbusInputDataType.Items[cboSecondaryModbusInputDataType.SelectedIndex].ToString() == ModbusDataType.Float32String)
				txtSecondaryModbusInputRegister2.Enabled = true;
			else
				txtSecondaryModbusInputRegister2.Enabled = false;
		}

		private void cboAMUAddress_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_sProcessID == "new" && cboAMUAddress.Items.Count > 0 && cboAMUAddress.SelectedIndex >= 0)
				cboIOChannel.SelectedIndex = TLIConfiguration.FindMaxAMUChannel(Convert.ToInt32(cboAMUAddress.Items[cboAMUAddress.SelectedIndex]));
		}

		private void cboTAUAddress_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_sProcessID == "new" && cboTAUAddress.Items.Count > 0 && cboTAUAddress.SelectedIndex >= 0 && cboIOChannelGroupType.SelectedIndex >= 0)
				cboIOChannel.SelectedIndex =
					TLIConfiguration.FindMaxTAUChannel(Convert.ToInt32(cboTAUAddress.Items[cboTAUAddress.SelectedIndex]), ICBObjectModel.Enumerations.TAUChannelGroupType.GetChannelGroupTypeID(cboIOChannelGroupType.Items[cboIOChannelGroupType.SelectedIndex].ToString()));
		}

		private void cboMODBUBAddress_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_sProcessID == "new" && cboMODBUBAddress.Items.Count > 0 && cboMODBUBAddress.SelectedIndex >= 0)
				cboIOChannel8.SelectedIndex = TLIConfiguration.FindMaxMODBUBChannel(Convert.ToInt32(cboMODBUBAddress.Items[cboMODBUBAddress.SelectedIndex]));
		}

		private void cboIOChannelGroupType_SelectedIndexChanged(object sender, EventArgs e)
		{
			string sMax, sMin;
			string sChannelGroupType = cboIOChannelGroupType.Items[cboIOChannelGroupType.SelectedIndex].ToString();
			int iChannelGroupType = TAUChannelGroupType.GetChannelGroupTypeID(sChannelGroupType);

			if (m_sProcessID == "new")
			{
				if (TLIConfiguration.Vessel.MeasurementSystem == MeasurementSystem.English)
				{
					sMax = "302";
					sMin = "-67";
				}
				else
				{
					sMax = "150";
					sMin = "-55";
				}

				switch (iChannelGroupType)
				{
					case TAUChannelGroupType.TEMPERATURE_1:
					case TAUChannelGroupType.TEMPERATURE_2:
					case TAUChannelGroupType.TEMPERATURE_3:
						txtRawMax.Text = "150";
						txtRawMin.Text = "-55";
						txtEngineeringMax.Text = "150";
						txtEngineeringMin.Text = "-55";
						txtHighScaleValue.Text = sMax;
						txtLowScaleValue.Text = sMin;
						break;

				}
			}
		}
		#endregion

		#region Form Customization Helpers

		private void Units1Enable(bool bEnable)
		{
			lblUnits1.Enabled = bEnable;
			cboUnits1.Enabled = bEnable;
		}

		private void Units2Enable(bool bEnable)
		{
			lblUnits2.Enabled = bEnable;
			cboUnits2.Enabled = bEnable;
		}

		private int GetGaugeNumberID(string sGaugeNumberDescription)
		{
			switch (sGaugeNumberDescription)
			{
				case "Temp TOP":
					return 1;
				case "Temp MID":
					return 2;
				case "Temp BOT":
					return 3;
				case "1":
					return 1;
				case "2":
					return 2;
				case "3":
					return 3;
				default:
					return 1;
			}
		}

		private string GetGaugeNumberDescription(int iGaugeType, int iGaugeNumber)
		{
			if (iGaugeType == GaugeType.Temperature)
			{
				switch (iGaugeNumber)
				{
					case 1:
						return "Temp TOP";
					case 2:
						return "Temp MID";
					case 3:
						return "Temp BOT";
					default:
						return "Temp TOP";
				}
			}
			else
			{
				switch (iGaugeNumber)
				{
					case 1:
						return "1";
					case 2:
						return "2";
					case 3:
						return "3";
					default:
						return "1";
				}
			}
		}

		private void EnableEngineering(bool bEnabled, bool bEnableScaleValues, bool bEnableRawValues)
		{
			//Console.WriteLine("CHANGE " + DateTime.Now.ToLocalTime() + " : " + bEnabled + " : " + bEnableScaleValues + " : " + bEnableRawValues);
			m_bEngineeringEnabled = bEnabled;

			lblRawMin.Enabled = bEnableRawValues;
			txtRawMin.Enabled = bEnableRawValues;
			lblRawMax.Enabled = bEnableRawValues;
			txtRawMax.Enabled = bEnableRawValues;
			lblRawDeadband.Enabled = bEnabled;
			txtRawDeadband.Enabled = bEnabled;
			lblDigitalFilter.Enabled = bEnabled;
			txtDigitalFilter.Enabled = bEnabled;
			lblEngineeringMin.Enabled = bEnabled;
			txtEngineeringMin.Enabled = bEnabled;
			lblEngineeringMax.Enabled = bEnabled;
			txtEngineeringMax.Enabled = bEnabled;
			lblLowScaleValue.Enabled = bEnableScaleValues;
			txtLowScaleValue.Enabled = bEnableScaleValues;
			lblHighScaleValue.Enabled = bEnableScaleValues;
			txtHighScaleValue.Enabled = bEnableScaleValues;
			lblLinearOffset.Enabled = bEnabled;
			txtLinearOffset.Enabled = bEnabled;
			lblPhysicalOffset.Enabled = bEnabled;
			txtPhysicalOffset.Enabled = bEnabled;

		}

		private void EnableSecondaryModbus(bool bEnable)
		{
			if (!bEnable)
				chkSecondaryModbusInputEnabled.Checked = false;

			lblSecondaryModbusInputEnabled.Enabled = bEnable;
			chkSecondaryModbusInputEnabled.Enabled = bEnable;
			lblSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
			cboSecondaryModbusInputDataType.Enabled = chkSecondaryModbusInputEnabled.Checked;
			lblSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
			txtSecondaryModbusInputRegister1.Enabled = chkSecondaryModbusInputEnabled.Checked;
			lblSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
			txtSecondaryModbusInputRegister2.Enabled = chkSecondaryModbusInputEnabled.Checked;
			lblSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;
			txtSecondaryModbusInputScale.Enabled = chkSecondaryModbusInputEnabled.Checked;
		}

		#endregion

		#region Properties
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

		public string AverageTemperatureProcessID
		{
			get { return m_sAverageTemperatureProcessID; }
			set { m_sAverageTemperatureProcessID = value; }
		}

		public bool RemoveGaugePoint
		{
			get { return m_bRemoveGaugePoint; }
		}

		public string OldProcessID
		{
			get { return m_sOldProcessID; }
		}
		#endregion

		#region Grid Support
		
		private void SoundingTableEnable(bool bEnable)
		{
			if (!bEnable && tabControl.TabPages.Count > 1)
				tabControl.TabPages.Remove(tpSoundingTable);
			else if (bEnable && tabControl.TabPages.Count == 1)
				tabControl.TabPages.Add(tpSoundingTable);
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
				customXceedGridControl.AddBoundColumn("Level", "Level", true, false, 150);
				customXceedGridControl.AddBoundColumn("Volume", "Volume", true, false, 150);

				customXceedGridControl.Columns["Level"].SortDirection = Xceed.Grid.SortDirection.Ascending;

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

				customXceedGridControl.HideUnwantedGridColumns(new string[] { "Level", "Volume" });
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
			m_dtDataTable.Columns.Add("Level", typeof(float));
			m_dtDataTable.Columns.Add("Volume", typeof(float));

			if (TLIConfiguration.VesselEquipment.ContainsKey(m_sEquipmentID))
			{
				foreach (Sounding s in TLIConfiguration.VesselEquipment[m_sEquipmentID].SoundingTable)
				{
					dr = m_dtDataTable.NewRow();

					dr["Index"] = m_iIndex++;
					dr["Level"] = s.Level;
					dr["Volume"] = s.Volume;

					m_dtDataTable.Rows.Add(dr);
					dr.AcceptChanges();
				}
			}
		}

		private void InitializingNewDataRow(object sender, Xceed.Grid.InitializingNewDataRowEventArgs e)
		{
			e.DataRow.Cells["Level"].Value = 0;
			e.DataRow.Cells["Volume"].Value = 0;
		}


		private void customXceedGridControl_AddingDataRow(object sender, Xceed.Grid.AddingDataRowEventArgs e)
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
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["Level"], "Level", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["Volume"], "Volume", e);
				if (!e.Cancel) ValidateNewRow(m_InsertionRow, e);
				if (!e.Cancel) m_InsertionRow.Cells["Index"].Value = m_iIndex++;
			}
			else if (m_EditRow != null)
			{
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["Level"], "Level", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["Volume"], "Volume", e);
				if (!e.Cancel) ValidateEditRow(m_EditRow, e);
			}

			m_EditRow = null;
		}

		private void ValidateNewRow(Xceed.Grid.InsertionRow insertionRow, CancelEventArgs e)
		{
			DataTable dt = (DataTable)customXceedGridControl.DataSource;

			foreach (DataRow dr in dt.Rows)
			{
				if ((float)dr["Level"] == (float)insertionRow.Cells["Level"].Value)
				{
					MessageBox.Show("A value has already been entered for this level.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					e.Cancel = true;
					return;
				}
				else if ((float)dr["Volume"] == (float)insertionRow.Cells["Volume"].Value)
				{
					MessageBox.Show("A value has already been entered for this volume.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
					if ((float)dr["Level"] == (float)editRow.Cells["Level"].Value)
					{
						MessageBox.Show("A value has already been entered for this level.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
						e.Cancel = true;
						return;
					}
					else if ((float)dr["Volume"] == (float)editRow.Cells["Volume"].Value)
					{
						MessageBox.Show("A value has already been entered for this volume.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
						e.Cancel = true;
						return;
					}
				}
			}
		}
		#endregion

		private void cmdImport_Click(object sender, EventArgs e)
		{
			DialogResult dr;

			dr = MessageBox.Show("Importing a new sounding table will cause the existing sounding table to be lost.\nWould you like to continue?",
                "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

			if (dr == DialogResult.Cancel)
				return;

			MessageBox.Show("CSV file should contain the Ullage or Level in Column 1 and the Volume in Column 2.\nAdditionally, no column headers should be used.",
                "CSV File Format", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

			dr = openFileDialog.ShowDialog();

			if (dr == DialogResult.OK)
			{
				FileInfo fi = new FileInfo(openFileDialog.FileName);

				try
				{
					ImportSoundingTable(fi);
				}
				catch
				{
					MessageBox.Show(this, "Error opening sounding table.", "TLI Configuration",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				}
			}
		}

		private void ImportSoundingTable(FileInfo fi)
		{
			StreamReader sr = new StreamReader(fi.FullName);
			bool bImportError = false;
			string sRow;
			int iRowCount = 0;
			string sRowError = "";
			string[] sSounding;

			try
			{
				DataTable dt = new DataTable();
				DataRow dr;

				DataView dv;

				dt.Columns.Add("Level", typeof(float));
				dt.Columns.Add("Volume", typeof(float));

				while ((sRow = sr.ReadLine()) != null)
				{
					iRowCount++;

					try
					{
						sSounding = sRow.Split(new char[] { ',' });

						if (sSounding.Length > 1)
						{
							if (sSounding[0].Length > 0 || sSounding[1].Length > 0)
							{
								dr = dt.NewRow();

								dr["Level"] = Convert.ToSingle(sSounding[0]);
								dr["Volume"] = Convert.ToSingle(sSounding[1]);

								dt.Rows.Add(dr);
							}
						}
					}
					catch
					{
						bImportError = true;

						if (sRowError == "")
							sRowError = iRowCount.ToString();
						else
							sRowError += ", " + iRowCount.ToString();
					}
				}

				sr.Close();

				dv = dt.DefaultView;
				dv.Sort = "Level";


				customXceedGridControl.BeginInit();

				customXceedGridControl.DataSource = dt;
				customXceedGridControl.DataMember = "";

				customXceedGridControl.EndInit();

				customXceedGridControl.HideUnwantedGridColumns(new string[] { "Level", "Volume" });


				if (bImportError)
					MessageBox.Show("The sounding table was imported with errors.\n The following row(s) had errors:\n" + sRowError,
                        "Import", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
				else
				{
					if (TLIConfiguration.VesselEquipment.ContainsKey(m_sEquipmentID))
					{
						float fVolumeTop, fVolumeBottom, fLevelTop, fLevelBottom;

						fVolumeTop = Convert.ToSingle(dt.Rows[0]["Volume"]);
						fVolumeBottom = Convert.ToSingle(dt.Rows[dt.Rows.Count - 1]["Volume"]);
						fLevelTop = Convert.ToSingle(dt.Rows[0]["Level"]);
						fLevelBottom = Convert.ToSingle(dt.Rows[dt.Rows.Count - 1]["Level"]);

						if (fVolumeTop > fVolumeBottom)
						{
							txtVolumeMax.Text = fVolumeTop.ToString("f4");
							txtVolumeMin.Text = fVolumeBottom.ToString("f4");
						}
						else
						{
							txtVolumeMax.Text = fVolumeBottom.ToString("f4");
							txtVolumeMin.Text = fVolumeTop.ToString("f4");
						}

						if (fLevelTop > fLevelBottom)
						{
							txtHighScaleValue.Text = fLevelTop.ToString("f4");
							txtLowScaleValue.Text = fLevelBottom.ToString("f4");
						}
						else
						{
							txtHighScaleValue.Text = fLevelBottom.ToString("f4");
							txtLowScaleValue.Text = fLevelTop.ToString("f4");
						}

					}

					MessageBox.Show("Import successful.", "Import",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Unhandled exception reading file.\n" + e.Message, "File Exception",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
		}

		private void GaugePointEdit_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char) Keys.Escape)
				this.Close();
		}
	}
}