using System;
using System.Text;
using System.Collections.Generic;
using ICBObjectModel;
using ICBObjectModel.Enumerations;

namespace TLIConfiguration
{
	public class CargoMaxConfigurationExport
	{
		private const ushort TANK_VALUE_START_REGISTER = 40001;
		private const ushort SHIP_PARAMETER_START_REGISTER = 41001;

		private Dictionary<int, EquipmentUnit> m_SortedEquipment;
		private SortedDictionary<int, CargoMaxExportItem> m_CargoMaxExport;
		private ExcelXml m_ExcelExport;

		public CargoMaxConfigurationExport()
		{
			SortEquipment();
			BuildCargoMaxConfigurationExport();
		}

		private void SortEquipment()
		{
			m_SortedEquipment = new Dictionary<int, EquipmentUnit>();

			foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
			{
				if (eu.ExportEnable)
					if (!m_SortedEquipment.ContainsKey(eu.ExportOrder))
						m_SortedEquipment.Add(eu.ExportOrder, eu);
			}
		}

		private void BuildCargoMaxConfigurationExport()
		{
			int iCurrentTankRegister = TANK_VALUE_START_REGISTER;
			int iCurrentShipRegister = SHIP_PARAMETER_START_REGISTER;

			bool bIncrementTank = false, bIncrementShip = false;

			m_CargoMaxExport = new SortedDictionary<int, CargoMaxExportItem>();

			foreach (EquipmentUnit eu in m_SortedEquipment.Values)
			{
				bIncrementTank = false;
				bIncrementShip = false;

				if (eu.EquipmentType == EquipmentType.Cargo || eu.EquipmentType == EquipmentType.Ballast || 
					eu.EquipmentType == EquipmentType.Fuel || eu.EquipmentType == EquipmentType.Draft || 
					eu.EquipmentType == EquipmentType.Trim || eu.EquipmentType == EquipmentType.List)
				{
					if(TLIConfiguration.VesselGaugePoints.ContainsKey(eu.EquipmentID))
						foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[eu.EquipmentID].Values)
						{
							switch (gp.GaugeType)
							{
								case(GaugeType.AverageTemperature):
									{
										bIncrementTank = true;

										m_CargoMaxExport.Add(iCurrentTankRegister + 2, new CargoMaxExportItem(
											eu.EquipmentTypeString,
											eu.Equipment,
											gp.GaugeTypeString,
											Units.UnitsString(gp.Units),
											"N/A",
											iCurrentTankRegister + 2,
											"Float",
											"Low Word (Float)"));

										m_CargoMaxExport.Add(iCurrentTankRegister + 3, new CargoMaxExportItem(
											eu.EquipmentTypeString,
											eu.Equipment,
											gp.GaugeTypeString,
											Units.UnitsString(gp.Units),
											"N/A",
											iCurrentTankRegister + 3,
											"Float",
											"High Word (Float)"));
									}
									break;
								case GaugeType.Level:
									{
										if (eu.EquipmentType == EquipmentType.Draft)
										{
											bIncrementShip = true;

											m_CargoMaxExport.Add(iCurrentShipRegister, new CargoMaxExportItem(
												eu.EquipmentTypeString,
												eu.Equipment,
												"Level (Draft)",
												Units.UnitsString(gp.Units),
												Units.UnitsString(gp.Units),
												iCurrentShipRegister,
												"Float",
												"Low Word (Float"));

											m_CargoMaxExport.Add(iCurrentShipRegister + 1, new CargoMaxExportItem(
												eu.EquipmentTypeString,
												eu.Equipment,
												"Level (Draft)",
												Units.UnitsString(gp.Units),
												Units.UnitsString(gp.Units),
												iCurrentShipRegister + 1,
												"Float",
												"High Word (Float"));

										}
										else
										{
											bIncrementTank = true;

											m_CargoMaxExport.Add(iCurrentTankRegister, new CargoMaxExportItem(
												eu.EquipmentTypeString,
												eu.Equipment,
												"Level (Innage)",
												Units.UnitsString(gp.Units),
												Units.UnitsString(gp.Units2),
												iCurrentTankRegister,
												"Float",
												"Low Word (Float)"));

											m_CargoMaxExport.Add(iCurrentTankRegister + 1, new CargoMaxExportItem(
												eu.EquipmentTypeString,
												eu.Equipment,
												"Level (Innage)",
												Units.UnitsString(gp.Units),
												Units.UnitsString(gp.Units2),
												iCurrentTankRegister + 1,
												"Float",
												"High Word (Float)"));
										}
									}
									break;
								case GaugeType.Ullage:
									{
										bIncrementTank = true;

										m_CargoMaxExport.Add(iCurrentTankRegister, new CargoMaxExportItem(
											eu.EquipmentTypeString,
											eu.Equipment,
											"Level (Ullage)",
											Units.UnitsString(gp.Units),
											Units.UnitsString(gp.Units2),
											iCurrentTankRegister,
											"Float",
											"Low Word (Float)"));

										m_CargoMaxExport.Add(iCurrentTankRegister + 1, new CargoMaxExportItem(
											eu.EquipmentTypeString,
											eu.Equipment,
											"Level (Ullage)",
											Units.UnitsString(gp.Units),
											Units.UnitsString(gp.Units2),
											iCurrentTankRegister + 1,
											"Float",
											"High Word (Float)"));
									}
									break;
								case GaugeType.List:
									{
										bIncrementShip = true;

										m_CargoMaxExport.Add(iCurrentShipRegister, new CargoMaxExportItem(
											eu.EquipmentTypeString,
											eu.Equipment,
											"List",
											Units.UnitsString(gp.Units),
											Units.UnitsString(gp.Units),
											iCurrentShipRegister,
											"Float",
											"Low Word (Float"));

										m_CargoMaxExport.Add(iCurrentShipRegister + 1, new CargoMaxExportItem(
											eu.EquipmentTypeString,
											eu.Equipment,
											"List",
											Units.UnitsString(gp.Units),
											Units.UnitsString(gp.Units),
											iCurrentShipRegister + 1,
											"Float",
											"High Word (Float"));

									}
									break;
								case GaugeType.Trim:
									{
										bIncrementShip = true;

										m_CargoMaxExport.Add(iCurrentShipRegister, new CargoMaxExportItem(
											eu.EquipmentTypeString,
											eu.Equipment,
											"Trim",
											Units.UnitsString(gp.Units),
											Units.UnitsString(gp.Units),
											iCurrentShipRegister,
											"Float",
											"Low Word (Float"));

										m_CargoMaxExport.Add(iCurrentShipRegister + 1, new CargoMaxExportItem(
											eu.EquipmentTypeString,
											eu.Equipment,
											"Trim",
											Units.UnitsString(gp.Units),
											Units.UnitsString(gp.Units),
											iCurrentShipRegister + 1,
											"Float",
											"High Word (Float"));
									}
									break;
							}
						}
				}

				if (bIncrementTank)
					iCurrentTankRegister += 4;

				if (bIncrementShip)
					iCurrentShipRegister += 2;
			}
		}

		public void BuildExcelExport(string sFilename)
		{
			m_ExcelExport = new ExcelXml(sFilename, "TLI Configuration");

			m_ExcelExport.NewWorkSheet(TLIConfiguration.Vessel.VesselName);

			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("Equipment Type", "SHDG");
			m_ExcelExport.AddTextCell("Equipment Name", "SHDG");
			m_ExcelExport.AddTextCell("Gauge Type", "SHDG");
			m_ExcelExport.AddTextCell("Units", "SHDG");
			m_ExcelExport.AddTextCell("CargoMax Return Units", "SHDG");
			m_ExcelExport.AddTextCell("Register", "SHDG");
			m_ExcelExport.AddTextCell("Data Type", "SHDG");
			m_ExcelExport.AddTextCell("Description", "SHDG");
			m_ExcelExport.EndRow();

			foreach (CargoMaxExportItem cmei in m_CargoMaxExport.Values)
			{
				m_ExcelExport.NewRow();
				m_ExcelExport.AddTextCell(cmei.EquipmentType);
				m_ExcelExport.AddTextCell(cmei.EquipmentName);
				m_ExcelExport.AddTextCell(cmei.GaugeType);
				m_ExcelExport.AddTextCell(cmei.Units);
				m_ExcelExport.AddTextCell(cmei.ReturnUnits);
				m_ExcelExport.AddNumericCell(cmei.Register.ToString(), "DFT");
				m_ExcelExport.AddTextCell(cmei.DataType);
				m_ExcelExport.AddTextCell(cmei.Description);
				m_ExcelExport.EndRow();
			}

			m_ExcelExport.EndWorkSheet();
			m_ExcelExport.Close();
		}
	}

	public class CargoMaxExportItem
	{
		private string m_sEquipmentType;
		private string m_sEquipmentName;
		private string m_sGaugeType;
		private string m_sUnits;
		private string m_sReturnUnits;
		private int m_iRegister;
		private string m_sDataType;
		private string m_sDescription;

		public CargoMaxExportItem()
		{
		}

		public CargoMaxExportItem
		(
			string sEquipmentType,
			string sEquipmentName,
			string sGaugeType,
			string sUnits,
			string sReturnUnits,
			int iRegister,
			string sDataType,
			string sDescription
		)
		{

			m_sEquipmentType = sEquipmentType;
			m_sEquipmentName = sEquipmentName;
			m_sGaugeType = sGaugeType;
			m_sUnits = sUnits;
			m_sReturnUnits = sReturnUnits;
			m_iRegister = iRegister;
			m_sDataType = sDataType;
			m_sDescription = sDescription;
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

		public string ReturnUnits
		{
			get { return m_sReturnUnits; }
			set { m_sReturnUnits = value; }
		}

		public int Register
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
	}
}
