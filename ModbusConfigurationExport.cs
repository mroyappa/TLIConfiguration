using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using ICBObjectModel;
using ICBObjectModel.Enumerations;

/*
 * CLASS SUMMARY:	ModbusConfigurationExport
 * 
 * ModbusConfigurationExport is the class which creates the Excel Modbus configuration document.
 * 
 */

namespace TLIConfiguration
{
	public class ModbusConfigurationExport
	{
		private SortedList<ushort, ModbusExportItem> m_SerialModbusExport;
		private SortedList<ushort, ModbusExportItem> m_TCPModbusExport;
		private SortedList<ushort, ModbusExportItem> m_LoadCPUExport;

		private ExcelXml m_ExcelExport;

		public ModbusConfigurationExport()
		{
			m_SerialModbusExport = new SortedList<ushort, ModbusExportItem>();
			m_TCPModbusExport = new SortedList<ushort, ModbusExportItem>();
			m_LoadCPUExport = new SortedList<ushort, ModbusExportItem>();
		}

		public void BuildModbusConfigurationExport()
		{
			BuildSerialGaugePointExport();
			BuildSerialAlarmPointExport();

			if (TLIConfiguration.Vessel.IncludeSystemStatusModbusSerial)
				AddSerialSystemStatusRegisters();

			BuildTCPGaugePointExport();
			BuildTCPAlarmPointExport();

			if (TLIConfiguration.Vessel.IncludeSystemStatusModbusTCP)
				AddTCPSystemStatusRegisters();

			BuildLoadCPUExport();
		}

		public void BuildExcelExport(string sFilename)
		{
			m_ExcelExport = new ExcelXml(sFilename, "TLI Configuration");

			// Serial Worksheet

			m_ExcelExport.NewWorkSheet("Serial Interface");

			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell(TLIConfiguration.Vessel.VesselName, "SHDG");
			m_ExcelExport.EndRow();

			m_ExcelExport.AddEmptyRow();

			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("Equipment Type", "SHDG");
			m_ExcelExport.AddTextCell("Equipment Name", "SHDG");
			m_ExcelExport.AddTextCell("Gauge Type", "SHDG");
			m_ExcelExport.AddTextCell("Units", "SHDG");
			m_ExcelExport.AddTextCell("Process Value", "SHDG");
			m_ExcelExport.AddTextCell("Alarm", "SHDG");
			m_ExcelExport.AddTextCell("Register", "SHDG");
			m_ExcelExport.AddTextCell("Data Type", "SHDG");
			m_ExcelExport.AddTextCell("Scale", "SHDG");
			m_ExcelExport.AddTextCell("Display Max", "SHDG");
			m_ExcelExport.AddTextCell("Display Min", "SHDG");
			m_ExcelExport.AddTextCell("Description", "SHDG");
			m_ExcelExport.EndRow();

			foreach (ModbusExportItem mei in m_SerialModbusExport.Values)
			{
				m_ExcelExport.NewRow();
				m_ExcelExport.AddTextCell(mei.EquipmentType);
				m_ExcelExport.AddTextCell(mei.EquipmentName);
				m_ExcelExport.AddTextCell(mei.GaugeType);
				m_ExcelExport.AddTextCell(mei.Units);
				m_ExcelExport.AddTextCell(mei.ProcessValue ? "X" : "");
				m_ExcelExport.AddTextCell(mei.Alarm ? "X" : "");
				m_ExcelExport.AddNumericCell(mei.Register.ToString(), "DFT");
				m_ExcelExport.AddTextCell(mei.DataType);
				m_ExcelExport.AddTextCell(mei.Scale);
				m_ExcelExport.AddTextCell(mei.FaceplateMax.ToString("f4"));
				m_ExcelExport.AddTextCell(mei.FaceplateMin.ToString("f4"));
				m_ExcelExport.AddTextCell(mei.Description);
				m_ExcelExport.EndRow();
			}

			m_ExcelExport.EndWorkSheet();

			// TCP Worksheet

			m_ExcelExport.NewWorkSheet("TCP Interface");

			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell(TLIConfiguration.Vessel.VesselName, "SHDG");
			m_ExcelExport.EndRow();

			m_ExcelExport.AddEmptyRow();

			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("Equipment Type", "SHDG");
			m_ExcelExport.AddTextCell("Equipment Name", "SHDG");
			m_ExcelExport.AddTextCell("Gauge Type", "SHDG");
			m_ExcelExport.AddTextCell("Units", "SHDG");
			m_ExcelExport.AddTextCell("Process Value", "SHDG");
			m_ExcelExport.AddTextCell("Alarm", "SHDG");
			m_ExcelExport.AddTextCell("Register", "SHDG");
			m_ExcelExport.AddTextCell("Data Type", "SHDG");
			m_ExcelExport.AddTextCell("Scale", "SHDG");
			m_ExcelExport.AddTextCell("Display Max", "SHDG");
			m_ExcelExport.AddTextCell("Display Min", "SHDG");
			m_ExcelExport.AddTextCell("Description", "SHDG");
			m_ExcelExport.EndRow();

			foreach (ModbusExportItem mei in m_TCPModbusExport.Values)
			{
				m_ExcelExport.NewRow();
				m_ExcelExport.AddTextCell(mei.EquipmentType);
				m_ExcelExport.AddTextCell(mei.EquipmentName);
				m_ExcelExport.AddTextCell(mei.GaugeType);
				m_ExcelExport.AddTextCell(mei.Units);
				m_ExcelExport.AddTextCell(mei.ProcessValue ? "X" : "");
				m_ExcelExport.AddTextCell(mei.Alarm ? "X" : "");
				m_ExcelExport.AddNumericCell(mei.Register.ToString(), "DFT");
				m_ExcelExport.AddTextCell(mei.DataType);
				m_ExcelExport.AddTextCell(mei.Scale);
				m_ExcelExport.AddTextCell(mei.FaceplateMax.ToString("f4"));
				m_ExcelExport.AddTextCell(mei.FaceplateMin.ToString("f4"));
				m_ExcelExport.AddTextCell(mei.Description);
				m_ExcelExport.EndRow();
			}

			m_ExcelExport.EndWorkSheet();

			// Load CPU Worksheet
			m_ExcelExport.NewWorkSheet("Load CPU Interface");

			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell(TLIConfiguration.Vessel.VesselName, "SHDG");
			m_ExcelExport.EndRow();

			m_ExcelExport.AddEmptyRow();

			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("Equipment Type", "SHDG");
			m_ExcelExport.AddTextCell("Equipment Name", "SHDG");
			m_ExcelExport.AddTextCell("Gauge Type", "SHDG");
			m_ExcelExport.AddTextCell("Units", "SHDG");
			m_ExcelExport.AddTextCell("Process Value", "SHDG");
			m_ExcelExport.AddTextCell("Alarm", "SHDG");
			m_ExcelExport.AddTextCell("Register", "SHDG");
			m_ExcelExport.AddTextCell("Data Type", "SHDG");
			m_ExcelExport.AddTextCell("Scale", "SHDG");
			m_ExcelExport.AddTextCell("Description", "SHDG");
			m_ExcelExport.EndRow();

			foreach (ModbusExportItem mei in m_LoadCPUExport.Values)
			{
				m_ExcelExport.NewRow();
				m_ExcelExport.AddTextCell(mei.EquipmentType);
				m_ExcelExport.AddTextCell(mei.EquipmentName);
				m_ExcelExport.AddTextCell(mei.GaugeType);
				m_ExcelExport.AddTextCell(mei.Units);
				m_ExcelExport.AddTextCell(mei.ProcessValue ? "X" : "");
				m_ExcelExport.AddTextCell(mei.Alarm ? "X" : "");
				m_ExcelExport.AddNumericCell(mei.Register.ToString(), "DFT");
				m_ExcelExport.AddTextCell(mei.DataType);
				m_ExcelExport.AddTextCell(mei.Scale);
				m_ExcelExport.AddTextCell(mei.Description);
				m_ExcelExport.EndRow();
			}

			m_ExcelExport.EndWorkSheet();

			m_ExcelExport.Close();
		}

		private void BuildSerialGaugePointExport()
		{
			foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
			{
				if (TLIConfiguration.VesselGaugePoints.ContainsKey(eu.EquipmentID))
				{
					foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[eu.EquipmentID].Values)
					{
						try
						{
							if (gp.ModbusInterfaceArray[0] != null && gp.ModbusInterfaceArray[0].Enable)
							{
								m_SerialModbusExport.Add(gp.ModbusInterfaceArray[0].RegisterAddress1, new ModbusExportItem(
									eu.EquipmentTypeString,
									eu.Equipment,
									gp.GaugeTypeStringForModbusExport,
									Units.UnitsString(gp.Units),
									true,
									false,
									gp.ModbusInterfaceArray[0].RegisterAddress1,
									ModbusDataType.GetModbusDataTypeString(gp.ModbusInterfaceArray[0].ModbusDataType),
									gp.ModbusInterfaceArray[0].ModbusDataType == ModbusDataType.Float32 ? "Low Word (Float)" : "Int16",
									gp.ModbusInterfaceArray[0].Scale.ToString("f4"),
									gp.FullScaleValue,
									gp.LowScaleValue));

								if (gp.ModbusInterfaceArray[0].RegisterAddress2 > 0)
								{
									m_SerialModbusExport.Add(gp.ModbusInterfaceArray[0].RegisterAddress2, new ModbusExportItem(
										eu.EquipmentTypeString,
										eu.Equipment,
										gp.GaugeTypeStringForModbusExport,
										Units.UnitsString(gp.Units),
										true,
										false,
										gp.ModbusInterfaceArray[0].RegisterAddress2,
										ModbusDataType.GetModbusDataTypeString(gp.ModbusInterfaceArray[0].ModbusDataType),
										"High Word (Float)",
										gp.ModbusInterfaceArray[0].Scale.ToString("f4"), 
										gp.FullScaleValue,
										gp.LowScaleValue));
								}
							}

							if (gp.ModbusInterfaceArray[1] != null && gp.ModbusInterfaceArray[1].Enable)
							{
								m_SerialModbusExport.Add(gp.ModbusInterfaceArray[1].RegisterAddress1, new ModbusExportItem(
									eu.EquipmentTypeString,
									eu.Equipment,
									"Volume",
									Units.UnitsString(gp.Units2),
									true,
									false,
									gp.ModbusInterfaceArray[1].RegisterAddress1,
									ModbusDataType.GetModbusDataTypeString(gp.ModbusInterfaceArray[1].ModbusDataType),
									gp.ModbusInterfaceArray[1].ModbusDataType == ModbusDataType.Float32 ? "Low Word (Float)" : "Int16",
									gp.ModbusInterfaceArray[1].Scale.ToString("f4"),
									eu.VolumeMax,
									eu.VolumeMin));

								if (gp.ModbusInterfaceArray[1].RegisterAddress2 > 0)
								{
									m_SerialModbusExport.Add(gp.ModbusInterfaceArray[1].RegisterAddress2, new ModbusExportItem(
										eu.EquipmentTypeString,
										eu.Equipment,
										"Volume",
										Units.UnitsString(gp.Units2),
										true,
										false,
										gp.ModbusInterfaceArray[1].RegisterAddress2,
										ModbusDataType.GetModbusDataTypeString(gp.ModbusInterfaceArray[1].ModbusDataType),
										"High Word (Float)",
										gp.ModbusInterfaceArray[1].Scale.ToString("f4"),
										eu.VolumeMax,
										eu.VolumeMin));
								}
							}

							if (gp.ModbusInterfaceArray.Length >= 3 && gp.ModbusInterfaceArray[2] != null && gp.ModbusInterfaceArray[2].Enable)
							{
								m_SerialModbusExport.Add(gp.ModbusInterfaceArray[2].RegisterAddress1, new ModbusExportItem(
									eu.EquipmentTypeString,
									eu.Equipment,
									"% Capacity",
									"%",
									true,
									false,
									gp.ModbusInterfaceArray[2].RegisterAddress1,
									ModbusDataType.GetModbusDataTypeString(gp.ModbusInterfaceArray[2].ModbusDataType),
									gp.ModbusInterfaceArray[2].ModbusDataType == ModbusDataType.Float32 ? "Low Word (Float)" : "Int16",
									gp.ModbusInterfaceArray[2].Scale.ToString("f4"),
									100,
									0));

								if (gp.ModbusInterfaceArray[2].RegisterAddress2 > 0)
								{
									m_SerialModbusExport.Add(gp.ModbusInterfaceArray[2].RegisterAddress2, new ModbusExportItem(
										eu.EquipmentTypeString,
										eu.Equipment,
										"% Capacity",
										"%",
										true,
										false,
										gp.ModbusInterfaceArray[2].RegisterAddress2,
										ModbusDataType.GetModbusDataTypeString(gp.ModbusInterfaceArray[2].ModbusDataType),
										"High Word (Float)",
										gp.ModbusInterfaceArray[2].Scale.ToString("f4"),
										100,
										0));
								}
							}
						}
						catch
						{
							MessageBox.Show("An error occured while generating the Modbus export.  The most likely cause is a duplicate register.  Please correct and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
						}
					}
				}
			}
		}

		private void BuildSerialAlarmPointExport()
		{
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
									if (ap.ModbusInterface.Enable)
									{
										m_SerialModbusExport.Add(ap.ModbusInterface.RegisterAddress1, new ModbusExportItem(
											eu.EquipmentTypeString,
											eu.Equipment,
											gp.GaugeTypeStringForModbusExport,
											"",
											false,
											true,
											ap.ModbusInterface.RegisterAddress1,
											"Bool",
											ap.DisplayName + "   {0 = Inactive, 1 = Active}",// Unacknowledged, 2 = Active Acknowledged}",
											ap.ModbusInterface.Scale.ToString("f4"),
											2,
											0));
									}
								}
							}
						}
					}
				}
			}
		}


		private void AddSerialSystemStatusRegisters()
		{
			ushort iMaxAddress = 0;

			foreach (ushort iRegister in m_SerialModbusExport.Keys)
				iMaxAddress = iRegister;

			if (iMaxAddress == 0)
				iMaxAddress = 40000;

			m_SerialModbusExport.Add(Convert.ToUInt16(iMaxAddress + 1),
				new ModbusExportItem(
					"SYSTEM_STATUS",
					"SYSTEM_FAULT_ACTIVE",
					"SYSTEM_FAULT_ACTIVE",
					"",
					true,
					false,
					Convert.ToUInt16(iMaxAddress + 1),
					"Int16",
					"{0 = Inactive, 1 = Active}",
					"1",
					1,
					0));

			m_SerialModbusExport.Add(Convert.ToUInt16(iMaxAddress + 2),
				new ModbusExportItem(
					"SYSTEM_STATUS",
					"ALARM_ACTIVE",
					"ALARM_ACTIVE",
					"",
					true,
					false,
					Convert.ToUInt16(iMaxAddress + 2),
					"Int16",
					"{0 = Inactive, 1 = Active}",
					"1",
					1,
					0));

			m_SerialModbusExport.Add(Convert.ToUInt16(iMaxAddress + 3),
				new ModbusExportItem(
					"SYSTEM_STATUS",
					"LOAD_CPU_BIDIRECTIONAL_CONNECTED",
					"LOAD_CPU_BIDIRECTIONAL_CONNECTED",
					"",
					true,
					false,
					Convert.ToUInt16(iMaxAddress + 3),
					"Int16",
					"{0 = Inactive, 1 = Active}",
					"1",
					1,
					0));

			m_SerialModbusExport.Add(Convert.ToUInt16(iMaxAddress + 4),
				new ModbusExportItem(
					"SYSTEM_STATUS",
					"LOAD_CPU_CORRECTION_ENABLED",
					"LOAD_CPU_CORRECTION_ENABLED",
					"",
					true,
					false,
					Convert.ToUInt16(iMaxAddress + 4),
					"Int16",
					"{0 = Inactive, 1 = Active}",
					"1",
					1,
					0));
		}

		private void BuildTCPGaugePointExport()
		{
			foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
			{
				if (TLIConfiguration.VesselGaugePoints.ContainsKey(eu.EquipmentID))
				{
					foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[eu.EquipmentID].Values)
					{
						try
						{
							if (gp.TCPModbusInterfaceArray[0] != null && gp.TCPModbusInterfaceArray[0].Enable)
							{
								m_TCPModbusExport.Add(gp.TCPModbusInterfaceArray[0].RegisterAddress1, new ModbusExportItem(
									eu.EquipmentTypeString,
									eu.Equipment,
									gp.GaugeTypeStringForModbusExport,
									Units.UnitsString(gp.Units),
									true,
									false,
									gp.TCPModbusInterfaceArray[0].RegisterAddress1,
									ModbusDataType.GetModbusDataTypeString(gp.TCPModbusInterfaceArray[0].ModbusDataType),
									gp.TCPModbusInterfaceArray[0].ModbusDataType == ModbusDataType.Float32 ? "Low Word (Float)" : "Int16",
									gp.TCPModbusInterfaceArray[0].Scale.ToString("f4"),
									gp.FullScaleValue,
									gp.LowScaleValue));

								if (gp.TCPModbusInterfaceArray[0].RegisterAddress2 > 0)
								{
									m_TCPModbusExport.Add(gp.TCPModbusInterfaceArray[0].RegisterAddress2, new ModbusExportItem(
										eu.EquipmentTypeString,
										eu.Equipment,
										gp.GaugeTypeStringForModbusExport,
										Units.UnitsString(gp.Units),
										true,
										false,
										gp.TCPModbusInterfaceArray[0].RegisterAddress2,
										ModbusDataType.GetModbusDataTypeString(gp.TCPModbusInterfaceArray[0].ModbusDataType),
										"High Word (Float)",
										gp.TCPModbusInterfaceArray[0].Scale.ToString("f4"),
										gp.FullScaleValue,
										gp.LowScaleValue));
								}
							}

							if (gp.TCPModbusInterfaceArray[1] != null && gp.TCPModbusInterfaceArray[1].Enable)
							{
								m_TCPModbusExport.Add(gp.TCPModbusInterfaceArray[1].RegisterAddress1, new ModbusExportItem(
									eu.EquipmentTypeString,
									eu.Equipment,
									"Volume",
									Units.UnitsString(gp.Units2),
									true,
									false,
									gp.TCPModbusInterfaceArray[1].RegisterAddress1,
									ModbusDataType.GetModbusDataTypeString(gp.TCPModbusInterfaceArray[1].ModbusDataType),
									gp.TCPModbusInterfaceArray[1].ModbusDataType == ModbusDataType.Float32 ? "Low Word (Float)" : "Int16",
									gp.TCPModbusInterfaceArray[1].Scale.ToString("f4"),
									eu.VolumeMax,
									eu.VolumeMin));

								if (gp.TCPModbusInterfaceArray[1].RegisterAddress2 > 0)
								{
									m_TCPModbusExport.Add(gp.TCPModbusInterfaceArray[1].RegisterAddress2, new ModbusExportItem(
										eu.EquipmentTypeString,
										eu.Equipment,
										"Volume",
										Units.UnitsString(gp.Units2),
										true,
										false,
										gp.TCPModbusInterfaceArray[1].RegisterAddress2,
										ModbusDataType.GetModbusDataTypeString(gp.TCPModbusInterfaceArray[1].ModbusDataType),
										"High Word (Float)",
										gp.TCPModbusInterfaceArray[1].Scale.ToString("f4"),
										eu.VolumeMax,
										eu.VolumeMin));
								}
							}

							if (gp.TCPModbusInterfaceArray.Length >= 3 && gp.TCPModbusInterfaceArray[2] != null && gp.TCPModbusInterfaceArray[2].Enable)
							{
								m_TCPModbusExport.Add(gp.TCPModbusInterfaceArray[2].RegisterAddress1, new ModbusExportItem(
									eu.EquipmentTypeString,
									eu.Equipment,
									"% Capacity",
									"%",
									true,
									false,
									gp.TCPModbusInterfaceArray[2].RegisterAddress1,
									ModbusDataType.GetModbusDataTypeString(gp.TCPModbusInterfaceArray[2].ModbusDataType),
									gp.TCPModbusInterfaceArray[2].ModbusDataType == ModbusDataType.Float32 ? "Low Word (Float)" : "Int16",
									gp.TCPModbusInterfaceArray[2].Scale.ToString("f4"),
									100,
									0));

								if (gp.TCPModbusInterfaceArray[2].RegisterAddress2 > 0)
								{
									m_TCPModbusExport.Add(gp.TCPModbusInterfaceArray[2].RegisterAddress2, new ModbusExportItem(
										eu.EquipmentTypeString,
										eu.Equipment,
										"% Capacity",
										"%",
										true,
										false,
										gp.TCPModbusInterfaceArray[2].RegisterAddress2,
										ModbusDataType.GetModbusDataTypeString(gp.TCPModbusInterfaceArray[2].ModbusDataType),
										"High Word (Float)",
										gp.TCPModbusInterfaceArray[2].Scale.ToString("f4"),
										100,
										0));
								}
							}
						}
						catch
						{
							MessageBox.Show("An error occured while generating the Modbus export.  The most likely cause is a duplicate register.  Please correct and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
						}
					}
				}
			}
		}

		private void BuildTCPAlarmPointExport()
		{
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
									if (ap.TCPModbusInterface.Enable)
									{
										m_TCPModbusExport.Add(ap.TCPModbusInterface.RegisterAddress1, new ModbusExportItem(
											eu.EquipmentTypeString,
											eu.Equipment,
											gp.GaugeTypeStringForModbusExport,
											"",
											false,
											true,
											ap.TCPModbusInterface.RegisterAddress1,
											"Int16",
											ap.DisplayName + "   {0 = Inactive, 1 = Active Unacknowledged, 2 = Active Acknowledged}",
											ap.TCPModbusInterface.Scale.ToString("f4"),
											2,
											0));
									}
								}
							}
						}
					}
				}
			}
		}

		private void AddTCPSystemStatusRegisters()
		{
			ushort iMaxAddress = 0;

			foreach (ushort iRegister in m_TCPModbusExport.Keys)
				iMaxAddress = iRegister;

			if (iMaxAddress == 0)
				iMaxAddress = 40000;

			m_TCPModbusExport.Add(Convert.ToUInt16(iMaxAddress + 1),
				new ModbusExportItem(
					"SYSTEM_STATUS",
					"SYSTEM_FAULT_ACTIVE",
					"SYSTEM_FAULT_ACTIVE",
					"",
					true,
					false,
					Convert.ToUInt16(iMaxAddress + 1),
					"Int16",
					"{0 = Inactive, 1 = Active}",
					"1",
					1,
					0));

			m_TCPModbusExport.Add(Convert.ToUInt16(iMaxAddress + 2),
				new ModbusExportItem(
					"SYSTEM_STATUS",
					"ALARM_ACTIVE",
					"ALARM_ACTIVE",
					"",
					true,
					false,
					Convert.ToUInt16(iMaxAddress + 2),
					"Int16",
					"{0 = Inactive, 1 = Active}",
					"1",
					1,
					0));

			m_TCPModbusExport.Add(Convert.ToUInt16(iMaxAddress + 3),
				new ModbusExportItem(
					"SYSTEM_STATUS",
					"LOAD_CPU_BIDIRECTIONAL_CONNECTED",
					"LOAD_CPU_BIDIRECTIONAL_CONNECTED",
					"",
					true,
					false,
					Convert.ToUInt16(iMaxAddress + 3),
					"Int16",
					"{0 = Inactive, 1 = Active}",
					"1",
					1,
					0));

			m_TCPModbusExport.Add(Convert.ToUInt16(iMaxAddress + 4),
				new ModbusExportItem(
					"SYSTEM_STATUS",
					"LOAD_CPU_CORRECTION_ENABLED",
					"LOAD_CPU_CORRECTION_ENABLED",
					"",
					true,
					false,
					Convert.ToUInt16(iMaxAddress + 4),
					"Int16",
					"{0 = Inactive, 1 = Active}",
					"1",
					1,
					0));
		}

		private void BuildLoadCPUExport()
		{
			ushort iTankRegister = 40001, iShipRegister = 41001, iCorrectedVolumeRegister = 42001, iCorrectedShipRegister = 43001;

			SortedDictionary<int, EquipmentUnit> loadCPUExportOrder = new SortedDictionary<int, EquipmentUnit>();

			foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
				if (eu.ExportEnable && !loadCPUExportOrder.ContainsKey(eu.ExportOrder))
					loadCPUExportOrder.Add(eu.ExportOrder, eu);

			foreach (EquipmentUnit eu in loadCPUExportOrder.Values)
			{
				if (TLIConfiguration.VesselGaugePoints.ContainsKey(eu.EquipmentID) &&
					(eu.EquipmentType == EquipmentType.Cargo || eu.EquipmentType == EquipmentType.Ballast ||
					eu.EquipmentType == EquipmentType.Fuel || eu.EquipmentType == EquipmentType.Draft ||
					eu.EquipmentType == EquipmentType.Trim || eu.EquipmentType == EquipmentType.List ||
					eu.EquipmentType == EquipmentType.Misc))
				{
					bool bIncrementTank = false, bIncrementTemp = false, bIncrementShip = false;
					int iTankUnits = 0, iVolumeUnits = 0, iTempUnits = 0, iShipUnits = 0;
					string sTankGaugeType = "", sTempGaugeType = "", sShipGaugeType = "";

					foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[eu.EquipmentID].Values)
					{
						switch (gp.GaugeType)
						{
							case (GaugeType.AverageTemperature):
								bIncrementTemp = true;
								iTempUnits = gp.Units;
								sTempGaugeType = gp.GaugeTypeStringForModbusExport;
								break;
							case GaugeType.Level:
								{
									if (eu.EquipmentType == EquipmentType.Draft)
									{
										bIncrementShip = true;
										iShipUnits = gp.Units;
										sShipGaugeType = gp.GaugeTypeStringForModbusExport;
									}
									else
									{
										bIncrementTank = true;
										iTankUnits = gp.Units;
										iVolumeUnits = gp.Units2;
										sTankGaugeType = gp.GaugeTypeStringForModbusExport;
									}
								}
								break;
							case GaugeType.Ullage:
								bIncrementTank = true;
								iTankUnits = gp.Units;
								iVolumeUnits = gp.Units2;
								sTankGaugeType = gp.GaugeTypeStringForModbusExport;
								break;
							case GaugeType.List:
								bIncrementShip = true;
								iShipUnits = gp.Units;
								sShipGaugeType = gp.GaugeTypeStringForModbusExport;
								break;
							case GaugeType.Trim:
								bIncrementShip = true;
								iShipUnits = gp.Units;
								sShipGaugeType = gp.GaugeTypeStringForModbusExport;
								break;
						}
					}

					if (bIncrementTank)
					{
						m_LoadCPUExport.Add(iTankRegister,
							new ModbusExportItem(
									eu.EquipmentTypeString,
									eu.Equipment,
									sTankGaugeType,
									Units.UnitsString(iTankUnits),
									true,
									false,
									iTankRegister,
									ModbusDataType.Float32String,
									"Low Word (Float)",
									"1.0000",
									0,
									0));

						m_LoadCPUExport.Add(Convert.ToUInt16(iTankRegister + 1),
							new ModbusExportItem(
									eu.EquipmentTypeString,
									eu.Equipment,
									sTankGaugeType,
									Units.UnitsString(iTankUnits),
									true,
									false,
									Convert.ToUInt16(iTankRegister + 1),
									ModbusDataType.Float32String,
									"High Word (Float)",
									"1.0000",
									0,
									0));

						iTankRegister += 2;

						m_LoadCPUExport.Add(iCorrectedVolumeRegister,
							new ModbusExportItem(
								eu.EquipmentTypeString,
								eu.Equipment,
								"Corrected Volume",
								Units.UnitsString(iVolumeUnits),
								true,
								false,
								iCorrectedVolumeRegister,
								ModbusDataType.Float32String,
								"Low Word (Float)",
								"1.0000",
								0,
								0));

						m_LoadCPUExport.Add(Convert.ToUInt16(iCorrectedVolumeRegister + 1),
							new ModbusExportItem(
								eu.EquipmentTypeString,
								eu.Equipment,
								"Corrected Volume",
								Units.UnitsString(iVolumeUnits),
								true,
								false,
								Convert.ToUInt16(iCorrectedVolumeRegister + 1),
								ModbusDataType.Float32String,
								"High Word (Float)",
								"1.0000",
								0,
								0));

						iCorrectedVolumeRegister += 2;
					}

					if (bIncrementTemp)
					{
						m_LoadCPUExport.Add(iTankRegister,
							new ModbusExportItem(
									eu.EquipmentTypeString,
									eu.Equipment,
									sTempGaugeType,
									Units.UnitsString(iTempUnits),
									true,
									false,
									iTankRegister,
									ModbusDataType.Float32String,
									"Low Word (Float)",
									"1.0000",
									0,
									0));

						m_LoadCPUExport.Add(Convert.ToUInt16(iTankRegister + 1),
							new ModbusExportItem(
									eu.EquipmentTypeString,
									eu.Equipment,
									sTempGaugeType,
									Units.UnitsString(iTempUnits),
									true,
									false,
									Convert.ToUInt16(iTankRegister + 1),
									ModbusDataType.Float32String,
									"High Word (Float)",
									"1.0000",
									0,
									0));

						iTankRegister += 2;
					}

					if (bIncrementShip)
					{
						m_LoadCPUExport.Add(iShipRegister,
							new ModbusExportItem(
									eu.EquipmentTypeString,
									eu.Equipment,
									sShipGaugeType,
									Units.UnitsString(iShipUnits),
									true,
									false,
									iShipRegister,
									ModbusDataType.Float32String,
									"Low Word (Float)",
									"1.0000",
									0,
									0));

						m_LoadCPUExport.Add(Convert.ToUInt16(iShipRegister + 1),
							new ModbusExportItem(
									eu.EquipmentTypeString,
									eu.Equipment,
									sShipGaugeType,
									Units.UnitsString(iShipUnits),
									true,
									false,
									Convert.ToUInt16(iShipRegister + 1),
									ModbusDataType.Float32String,
									"High Word (Float)",
									"1.0000",
									0,
									0));

						iShipRegister += 2;

						m_LoadCPUExport.Add(iCorrectedShipRegister,
							new ModbusExportItem(
								eu.EquipmentTypeString,
								eu.Equipment,
								"Corrected " + sShipGaugeType,
								Units.UnitsString(iShipUnits),
								true,
								false,
								iCorrectedShipRegister,
								ModbusDataType.Float32String,
								"Low Word (Float)",
								"1.0000",
								0,
								0));

						m_LoadCPUExport.Add(Convert.ToUInt16(iCorrectedShipRegister + 1),
							new ModbusExportItem(
								eu.EquipmentTypeString,
								eu.Equipment,
								"Corrected " + sShipGaugeType,
								Units.UnitsString(iShipUnits),
								true,
								false,
								Convert.ToUInt16(iCorrectedShipRegister + 1),
								ModbusDataType.Float32String,
								"Low Word (Float)",
								"1.0000",
								0,
								0));

						iCorrectedShipRegister += 2;
					}

				}
			}
		}
	}

	public class ModbusExportItem
	{
		private string m_sEquipmentType;
		private string m_sEquipmentName;
		private string m_sGaugeType;
		private string m_sUnits;
		private bool m_bProcessValue;
		private bool m_bAlarm;
		private ushort m_iRegister;
		private string m_sDataType;
		private string m_sDescription;
		private string m_sScale;
		private float m_fFaceplateMax;
		private float m_fFaceplateMin;

		public ModbusExportItem()
		{
		}

		public ModbusExportItem
		(
			string sEquipmentType,
			string sEquipmentName,
			string sGaugeType,
			string sUnits,
			bool bProcessValue,
			bool bAlarm,
			ushort iRegister,
			string sDataType,
			string sDescription,
			string sScale,
			float fFaceplateMax,
			float fFaceplateMin
		)
		{
			m_sEquipmentType = sEquipmentType;
			m_sEquipmentName = sEquipmentName;
			m_sGaugeType = sGaugeType;
			m_sUnits = sUnits;
			m_bProcessValue = bProcessValue;
			m_bAlarm = bAlarm;
			m_sDataType = sDataType;
			m_iRegister = iRegister;
			m_sDescription = sDescription;
			m_sScale = sScale;
			m_fFaceplateMax = fFaceplateMax;
			m_fFaceplateMin = fFaceplateMin;
		}

		public string EquipmentType
		{
			get { return m_sEquipmentType; }
			set { m_sEquipmentType = value; }
		}

		public string EquipmentName
		{
			get { return m_sEquipmentName; }
			set { m_sEquipmentName = value; }
		}

		public string GaugeType
		{
			get { return m_sGaugeType; }
			set { m_sGaugeType = value; }
		}

		public string Units
		{
			get { return m_sUnits; }
			set { m_sUnits = value; }
		}

		public bool ProcessValue
		{
			get { return m_bProcessValue; }
			set { m_bProcessValue = value; }
		}

		public bool Alarm
		{
			get { return m_bAlarm; }
			set { m_bAlarm = value; }
		}

		public ushort Register
		{
			get { return m_iRegister; }
			set { m_iRegister = value; }
		}

		public string DataType
		{
			get { return m_sDataType; }
			set { m_sDataType = value; }
		}

		public string Description
		{
			get { return m_sDescription; }
			set { m_sDescription = value; }
		}

		public string Scale
		{
			get { return m_sScale; }
			set { m_sScale = value; }
		}

		public float FaceplateMax
		{
			get { return m_fFaceplateMax; }
			set { m_fFaceplateMax = value; }
		}

		public float FaceplateMin
		{
			get { return m_fFaceplateMin; }
			set { m_fFaceplateMin = value; }
		}
	}
}
