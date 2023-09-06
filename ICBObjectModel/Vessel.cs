using System;
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;
using ICBObjectModel.Enumerations;

/*
 * CLASS SUMMARY:	Vessel
 * 
 * Vessel is the top level class which contains all objects and collections used to define a 
 * vessel configuration.
 * 
 */

namespace ICBObjectModel
{
	public class Vessel
	{
		private string m_sDisplayName;
		private string m_sVessel;
		private int m_iVesselType;
		private int m_iMeasurementSystem;
		private string m_sOwner;
		private string m_sYard;
		private string m_sYardNo;
		private string m_sClass;
		private DateTime m_dtConfigured;
		private string m_sConfiguredBy;
		private string m_sConfigurationHistory;
		private string m_sCommissioningEngineer;
		private DateTime m_dtWarrantyExpiration;
		private bool m_bFaceplateTrendEnable;
		private int m_iFaceplateTrendTimeout;
		private string m_sSystemWarning;
		private List<AMU> m_lAMUArray;
		private List<TAU> m_lTAUArray;
		private List<MTDE> m_lMTDEArray;
		private List<SCU> m_lSCUArray;
		private List<ModularBubbler> m_lModularBubblerArray;
		private List<ModularBubblerChannel> m_lModularBubblerChannelArray;
		private List<ModularBubblerEZT> m_lModularBubblerEZTArray;
		private List<string> m_lConfiguredEquipment;
		private List<EquipmentUnit> m_lEquipmentArray;
		private List<Product> m_lProduct;
		private List<AlarmGroup> m_lAlarmGroup;
		private List<AlarmPriority> m_lAlarmPriority;
		private List<AlarmAnnunciation> m_lAlarmAnnunciation;
		private List<GroupDisplay> m_lGroupDisplayArray;
		private bool m_bIncludeSystemStatusModbusSerial;
		private bool m_bIncludeSystemStatusModbusTCP;

		// Draft Correction Members
		private bool m_bDCEnabled;
		private int m_iDCUnits;
		private float m_fDCStarboardSensorMarkDistance;
		private float m_fDCPortSensorMarkDistance;
		private float m_fDCStarboardPortSensorDistance;
		private float m_fDCForeSensorMarkDistance;
		private float m_fDCAftSensorMarkDistance;
		private float m_fDCForeAftSensorDistance;

		public Vessel()
		{
			m_lAMUArray = new List<AMU>();
			m_lTAUArray = new List<TAU>();
			m_lMTDEArray = new List<MTDE>();
			m_lSCUArray = new List<SCU>();
			m_lModularBubblerArray = new List<ModularBubbler>();
			m_lModularBubblerChannelArray = new List<ModularBubblerChannel>();
			m_lModularBubblerEZTArray = new List<ModularBubblerEZT>();
			m_lConfiguredEquipment = new List<string>();
			m_lEquipmentArray = new List<EquipmentUnit>();
			m_lProduct = new List<Product>();
			m_lAlarmGroup = new List<AlarmGroup>();
			m_lAlarmPriority = new List<AlarmPriority>();
			m_lAlarmAnnunciation = new List<AlarmAnnunciation>();
			m_lGroupDisplayArray = new List<GroupDisplay>();

			m_bDCEnabled = false;
			m_iDCUnits = Units.Inches;
			m_fDCStarboardSensorMarkDistance = 0;
			m_fDCPortSensorMarkDistance = 0;
			m_fDCStarboardPortSensorDistance = 0;
			m_fDCForeSensorMarkDistance = 0;
			m_fDCAftSensorMarkDistance = 0;
			m_fDCForeAftSensorDistance = 0;

			m_bIncludeSystemStatusModbusSerial = false;
			m_bIncludeSystemStatusModbusTCP = false;
		}

		public Vessel(string sVessel, int iVesselType, int iMeasurementSystem)
		{
			m_sVessel = sVessel;
			m_iVesselType = iVesselType;
			m_iMeasurementSystem = iMeasurementSystem;

			m_lAMUArray = new List<AMU>();
			m_lTAUArray = new List<TAU>();
			m_lMTDEArray = new List<MTDE>();
			m_lSCUArray = new List<SCU>();
			m_lModularBubblerArray = new List<ModularBubbler>();
			m_lModularBubblerChannelArray = new List<ModularBubblerChannel>();
			m_lModularBubblerEZTArray = new List<ModularBubblerEZT>();
			m_lConfiguredEquipment = new List<string>();
			m_lEquipmentArray = new List<EquipmentUnit>();
			m_lProduct = new List<Product>();
			m_lAlarmGroup = new List<AlarmGroup>();
			m_lAlarmPriority = new List<AlarmPriority>();
			m_lAlarmAnnunciation = new List<AlarmAnnunciation>();
			m_lGroupDisplayArray = new List<GroupDisplay>();

			m_bDCEnabled = false;
			m_iDCUnits = Units.Inches;
			m_fDCStarboardSensorMarkDistance = 0;
			m_fDCPortSensorMarkDistance = 0;
			m_fDCStarboardPortSensorDistance = 0;
			m_fDCForeSensorMarkDistance = 0;
			m_fDCAftSensorMarkDistance = 0;
			m_fDCForeAftSensorDistance = 0;

			m_bIncludeSystemStatusModbusSerial = false;
			m_bIncludeSystemStatusModbusTCP = false;
		}

		public Vessel
		(
			string sVessel, 
			int iVesselType, 
			int iMeasurementSystem, 
			List<AMU> lAMUArray,
			List<MTDE> lMTDEArray,
			List<string> lConfiguredEquipment,
			List<EquipmentUnit> lEquipmentArray,
			List<Product> lProductArray,
			List<AlarmGroup> lAlarmGroupArray,
			List<AlarmPriority> lAlarmPriorityArray,
			List<AlarmAnnunciation> lAlarmAnnunciationArray
		)
		{
			m_sVessel = sVessel;
			m_iVesselType = iVesselType;
			m_iMeasurementSystem = iMeasurementSystem;
			m_lAMUArray = lAMUArray;
			m_lMTDEArray = lMTDEArray;
			m_lConfiguredEquipment = lConfiguredEquipment;
			m_lEquipmentArray = lEquipmentArray;
			m_lProduct = lProductArray;
			m_lAlarmGroup = lAlarmGroupArray;
			m_lAlarmPriority = lAlarmPriorityArray;
			m_lAlarmAnnunciation = lAlarmAnnunciationArray;

			m_bDCEnabled = false;
			m_iDCUnits = Units.Inches;
			m_fDCStarboardSensorMarkDistance = 0;
			m_fDCPortSensorMarkDistance = 0;
			m_fDCStarboardPortSensorDistance = 0;
			m_fDCForeSensorMarkDistance = 0;
			m_fDCAftSensorMarkDistance = 0;
			m_fDCForeAftSensorDistance = 0;

			m_bIncludeSystemStatusModbusSerial = false;
			m_bIncludeSystemStatusModbusTCP = false;
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public string DisplayName
		{
			get { return m_sDisplayName; }
			set { m_sDisplayName = value; }
		}

		#if !WindowsCE
			[Category("General"), DisplayName("Vessel Name")]
		#endif
		public string VesselName
		{
			get { return m_sVessel; }
			set { m_sVessel = value; }
		}

		#if !WindowsCE
			[Category("General"), DisplayName("Vessel Type"), TypeConverter(typeof(VesselType))]
		#endif
		[System.Xml.Serialization.XmlIgnore]
		public string VesselTypeString
		{
			get
			{
				switch (m_iVesselType)
				{
					case Enumerations.VesselType.Tug:
						return "Tug";
					case Enumerations.VesselType.Barge:
						return "Barge";
					case Enumerations.VesselType.Platform:
						return "Platform";
					case Enumerations.VesselType.Tanker:
						return "Tanker";
					default:
						return "Tug";
				}
			}
			set
			{
				switch (value)
				{
					case "Tug":
						m_iVesselType = Enumerations.VesselType.Tug;
						break;
					case "Barge":
						m_iVesselType = Enumerations.VesselType.Barge;
						break;
					case "Platform":
						m_iVesselType = Enumerations.VesselType.Platform;
						break;
					case "Tanker":
						m_iVesselType = Enumerations.VesselType.Tanker;
						break;
				}
			}
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public int VesselType
		{
			get { return m_iVesselType; }
			set { m_iVesselType = value; }
		}

		#if !WindowsCE
			[Category("General"), DisplayName("Measurement System"), Description("Units of measure data will be displayed in (English / Metric)"), TypeConverter(typeof(MeasurementSystem))]
		#endif
		[System.Xml.Serialization.XmlIgnore]
		public string MeasurementSystemString
		{
			get
			{
				switch (m_iMeasurementSystem)
				{
					case Enumerations.MeasurementSystem.English:
						return "English";
					case Enumerations.MeasurementSystem.Metric:
						return "Metric";
					default:
						return "English";
				}
			}
			set
			{
				switch (value)
				{
					case "English":
						m_iMeasurementSystem = Enumerations.MeasurementSystem.English;
						break;
					case "Metric":
						m_iMeasurementSystem = Enumerations.MeasurementSystem.Metric;
						break;
				}
			}
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public int MeasurementSystem
		{
			get { return m_iMeasurementSystem; }
			set { m_iMeasurementSystem = value; }
		}

		#if !WindowsCE
			[Category("General"), DisplayName("Owner")]
		#endif
		public string Owner
		{
			get { return m_sOwner; }
			set { m_sOwner = value; }
		}

		#if !WindowsCE
			[Category("General"), DisplayName("Yard")]
		#endif
		public string Yard
		{
			get { return m_sYard; }
			set { m_sYard = value; }
		}

		#if !WindowsCE
			[Category("General"), DisplayName("Yard No.")]
		#endif
		public string YardNo
		{
			get { return m_sYardNo; }
			set { m_sYardNo = value; }
		}

		#if !WindowsCE
			[Category("General"), DisplayName("Class")]
		#endif
		public string Class
		{
			get { return m_sClass; }
			set { m_sClass = value; }
		}

		#if !WindowsCE
			[Category("General"), DisplayName("Configuration Date")]
		#endif
		public DateTime Configured
		{
			get { return m_dtConfigured; }
			set { m_dtConfigured = value; }
		}

		#if !WindowsCE
			[Category("General"), DisplayName("Configured By")]
		#endif
		public string ConfiguredBy
		{
			get { return m_sConfiguredBy; }
			set { m_sConfiguredBy = value; }
		}

		#if !WindowsCE
			[Category("General"), DisplayName("Configuration History")]
		#endif
		public string ConfigurationHistory
		{
			get { return m_sConfigurationHistory; }
			set { m_sConfigurationHistory = value; }
		}

		#if !WindowsCE
			[Category("General"), DisplayName("Commissioning Engineer")]
		#endif
		public string CommissioningEngineer
		{
			get { return m_sCommissioningEngineer; }
			set { m_sCommissioningEngineer = value; }
		}

		#if !WindowsCE
			[Category("General"), DisplayName("Warranty Expiration")]
		#endif
		public DateTime WarrantyExpiration
		{
			get { return m_dtWarrantyExpiration; }
			set { m_dtWarrantyExpiration = value; }
		}

		#if !WindowsCE
			[Category("User Interface"), DisplayName("Faceplate Trend Enable"), Description("Enables / Disables trending arrows on all faceplates")]
		#endif
		public bool FaceplateTrendEnable
		{
			get { return m_bFaceplateTrendEnable; }
			set { m_bFaceplateTrendEnable = value; }
		}

		#if !WindowsCE
			[Category("User Interface"), DisplayName("Faceplate Trend Timout"), Description("Milliseconds until faceplate timesout from a rising / falling trend.")]
		#endif
		public int FaceplateTrendTimeout
		{
			get { return m_iFaceplateTrendTimeout; }
			set { m_iFaceplateTrendTimeout = value; }
		}

		public string SystemWarning
		{
			get { return m_sSystemWarning; }
			set { m_sSystemWarning = value; }
		}

		#if !WindowsCE
			[Category("Global Definitions"), DisplayName("AMU Array"), Description("All configured AMUs.")]
		#endif
		public List<AMU> AMUArray
		{
			get { return m_lAMUArray; }
			set { m_lAMUArray = value; }
		}

		public List<TAU> TAUArray
		{
			get { return m_lTAUArray; }
			set { m_lTAUArray = value; }
		}

		#if !WindowsCE
			[Category("Global Definitions"), DisplayName("MTDE Array"), Description("All configured MTDEs.")]
		#endif
		public List<MTDE> MTDEArray
		{
			get { return m_lMTDEArray; }
			set { m_lMTDEArray = value; }
		}

		public List<SCU> SCUArray
		{
			get { return m_lSCUArray; }
			set { m_lSCUArray = value; }
		}

		public List<ModularBubbler> ModularBubblerArray
		{
			get { return m_lModularBubblerArray; }
			set { m_lModularBubblerArray = value; }
		}

		public List<ModularBubblerChannel> ModularBubberChannelArray
		{
			get { return m_lModularBubblerChannelArray; }
			set { m_lModularBubblerChannelArray = value; }
		}

		public List<ModularBubblerEZT> ModularBubblerEZTArray
		{
			get { return m_lModularBubblerEZTArray; }
			set { m_lModularBubblerEZTArray = value; }
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public List<string> ConfiguredEquipment
		{
			get { return m_lConfiguredEquipment; }
			set { m_lConfiguredEquipment = value; }
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		[System.Xml.Serialization.XmlIgnore]
		public List<EquipmentUnit> EquipmentArray
		{
			get { return m_lEquipmentArray; }
			set { m_lEquipmentArray = value; }
		}

		#if !WindowsCE
			[Category("Global Definitions"), DisplayName("Products"), Description("All configured products.")]
		#endif
		public List<Product> Product
		{
			get { return m_lProduct; }
			set { m_lProduct = value; }
		}

		#if !WindowsCE
			[Category("Global Definitions"), DisplayName("Alarms Groups"), Description("All configured alarm groups.")]
		#endif
		public List<AlarmGroup> AlarmGroup
		{
			get { return m_lAlarmGroup; }
			set { m_lAlarmGroup = value; }
		}

		#if !WindowsCE
			[Category("Global Definitions"), DisplayName("Alarm Priorities"), Description("All configured system alarm priorities.")]
		#endif
		public List<AlarmPriority> AlarmPriority
		{
			get { return m_lAlarmPriority; }
			set { m_lAlarmPriority = value; }
		}

		#if !WindowsCE
			[Category("Global Definitions"), DisplayName("Alarm Annunciations"), Description("All configured alarm Annunciations.")]
		#endif
		public List<AlarmAnnunciation> AlarmAnnunciation
		{
			get { return m_lAlarmAnnunciation; }
			set { m_lAlarmAnnunciation = value; }
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public List<GroupDisplay> GroupDisplayArray
		{
			get { return m_lGroupDisplayArray; }
			set { m_lGroupDisplayArray = value; }
		}

		public bool IncludeSystemStatusModbusSerial
		{
			get { return m_bIncludeSystemStatusModbusSerial; }
			set { m_bIncludeSystemStatusModbusSerial = value; }
		}

		public bool IncludeSystemStatusModbusTCP
		{
			get { return m_bIncludeSystemStatusModbusTCP; }
			set { m_bIncludeSystemStatusModbusTCP = value; }
		}

		public bool DCEnabled
		{
			get { return m_bDCEnabled; }
			set { m_bDCEnabled = value; }
		}

		public int DCUnits
		{
			get { return m_iDCUnits; }
			set { m_iDCUnits = value; }
		}

		[System.Xml.Serialization.XmlIgnore]
		public string DCUnitsString
		{
			get
			{
				switch (m_iDCUnits)
				{
					case Enumerations.Units.Inches:
						return "Inches";
					case Enumerations.Units.Millimeters:
						return "Millimeters";
					default:
						return "Inches";
				}
			}
			set
			{
				switch (value)
				{
					case "Inches":
						m_iDCUnits = Enumerations.Units.Inches;
						break;
					case "Millimeters":
						m_iDCUnits = Enumerations.Units.Millimeters;
						break;
				}
			}
		}

		public float DCStarboardSensorMarkDistance
		{
			get {return m_fDCStarboardSensorMarkDistance; }
			set { m_fDCStarboardSensorMarkDistance = value; }
		}

		public float DCPortSensorMarkDistance
		{
			get { return m_fDCPortSensorMarkDistance; }
			set { m_fDCPortSensorMarkDistance = value; }
		}

		public float DCStarboardPortSensorDistance
		{
			get { return m_fDCStarboardPortSensorDistance; }
			set { m_fDCStarboardPortSensorDistance = value; }
		}

		public float DCForeSensorMarkDistance
		{
			get { return m_fDCForeSensorMarkDistance; }
			set { m_fDCForeSensorMarkDistance = value; }
		}

		public float DCAftSensorMarkDistance
		{
			get { return m_fDCAftSensorMarkDistance; }
			set { m_fDCAftSensorMarkDistance = value; }
		}

		public float DCForeAftSensorDistance
		{
			get { return m_fDCForeAftSensorDistance; }
			set { m_fDCForeAftSensorDistance = value; }
		}
	}
}
