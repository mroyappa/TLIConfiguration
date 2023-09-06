using System;
using System.Text;
using System.Drawing;
using System.Collections.Generic;
using ICBObjectModel.Enumerations;
using System.ComponentModel;

/*
 * CLASS SUMMARY:	EquipmentUnit
 * 
 * The Equipment Unit is the primary object used in defining the makeup of a Vessel.  This object is used 
 * to describe major equipment elements such as Cargo Tanks, Ballast Tanks, etc.  Further, an array of one 
 * or more Gauge Point objects are used to define sensors and instruments installed in the Equipment Unit.  
 * These gauges could be for level, temperature, pressure, etc.
 * 
 */

namespace ICBObjectModel
{
	public class EquipmentUnit
	{
		private string m_sDisplayName;
		private bool m_bEnable;
		private int m_iEquipmentType;
		private string m_sEquipmentLocation;
		private string m_sEquipment;
		private string m_sCurrentProduct;
		private float m_fTankHeight;
		private float m_fVolumeMax;
		private float m_fVolumeMin;
		private bool m_bSpecificGravityApplicable;
		private bool m_bIndependentOverfillAlarm;
		private int m_iIndependentOverfillAlarmPercentage;
		private float m_fIndependentOverfillAlarmLimit;
		private bool m_bIndependentHighLevelAlarm;
		private int m_iIndependentHighLevelAlarmPercentage;
		private float m_fIndependentHighLevelAlarmLimit;
		private List<Sounding> m_lSoundingTable;
		private SoundingCorrection m_scSoundingCorrection;
		private List<GaugePoint> m_lGaugePointArray;
		private MTDEInterface m_miMTDEInterface;
		private Point m_pSummaryScreenFaceplateLocation;
		private List<StopGauge> m_sgStopGaugeArray;
		private bool m_bExportEnable;
		private int m_iExportOrder;
		private bool m_bUpdated;

		public EquipmentUnit()
		{
			m_lSoundingTable = new List<Sounding>();
			m_scSoundingCorrection = new SoundingCorrection(true);
			m_lGaugePointArray = new List<GaugePoint>();
			m_miMTDEInterface = new MTDEInterface();
			m_sgStopGaugeArray = new List<StopGauge>();
		}

		public EquipmentUnit
		(
			string sDisplayName,
			bool bEnable,
			int iEquipmentType,
			string sEquipmentLocation,
			string sEquipment,
			string sCurrentProduct,
			float fTankHeight,
			float fVolumeMax,
			float fVolumeMin,
			bool bSpecificGravityApplicable,
			bool bIndependentOverfillAlarm,
			int iIndependentOverfillAlarmPercentage,
			float fIndependentOverfillAlarmLimit,
			bool bIndependentHighLevelAlarm,
			int iIndependentHighLevelAlarmPercentage,
			float fIndependentHighLevelAlarmLimit,
			bool bExportEnable,
			int iExportOrder
		)
		{
			m_sDisplayName = sDisplayName;
			m_bEnable = bEnable;
			m_iEquipmentType = iEquipmentType;
			m_sEquipmentLocation = sEquipmentLocation;
			m_sEquipment = sEquipment;
			m_sCurrentProduct = sCurrentProduct;
			m_fTankHeight = fTankHeight;
			m_fVolumeMax = fVolumeMax;
			m_fVolumeMin = fVolumeMin;
			m_bSpecificGravityApplicable = bSpecificGravityApplicable;
			m_bIndependentOverfillAlarm = bIndependentOverfillAlarm;
			m_iIndependentOverfillAlarmPercentage = iIndependentOverfillAlarmPercentage;
			m_fIndependentOverfillAlarmLimit = fIndependentOverfillAlarmLimit;
			m_bIndependentHighLevelAlarm = bIndependentHighLevelAlarm;
			m_iIndependentHighLevelAlarmPercentage = iIndependentHighLevelAlarmPercentage;
			m_fIndependentHighLevelAlarmLimit = fIndependentHighLevelAlarmLimit;
			m_bExportEnable = bExportEnable;
			m_iExportOrder = iExportOrder;
			MTDEAddr = 0;

			m_lSoundingTable = new List<Sounding>();
			m_scSoundingCorrection = new SoundingCorrection(true);
			m_lGaugePointArray = new List<GaugePoint>();
			m_miMTDEInterface = new MTDEInterface();
			m_pSummaryScreenFaceplateLocation = new Point();
			m_sgStopGaugeArray = new List<StopGauge>();
		}

		public EquipmentUnit
		(
			bool bEnable,
			int iEquipmentType,
			string sEquipmentLocation,
			string sEquipment,
			float fTankHeight,
			float fVolumeMax,
			float fVolumeMin,
			List<Sounding> lSoundingTable,
			SoundingCorrection scSoundingCorrection,
			List<GaugePoint> lGaugePointArray,
			MTDEInterface miMTDEInterface
		)
		{
			m_bEnable = bEnable;
			m_iEquipmentType = iEquipmentType;
			m_sEquipmentLocation = sEquipmentLocation;
			m_sEquipment = sEquipment;
			m_fTankHeight = fTankHeight;
			m_fVolumeMax = fVolumeMax;
			m_fVolumeMin = fVolumeMin;
			m_lSoundingTable = lSoundingTable;
			m_scSoundingCorrection = scSoundingCorrection;
			m_lGaugePointArray = lGaugePointArray;
			m_miMTDEInterface = miMTDEInterface;
		}

		public EquipmentUnit Copy()
		{
			EquipmentUnit eu = new EquipmentUnit(
				m_sDisplayName,
				m_bEnable,
				m_iEquipmentType,
				m_sEquipmentLocation,
				m_sEquipment,
				m_sCurrentProduct,
				m_fTankHeight,
				m_fVolumeMax,
				m_fVolumeMin,
				m_bSpecificGravityApplicable,
				m_bIndependentOverfillAlarm,
				m_iIndependentOverfillAlarmPercentage,
				m_fIndependentOverfillAlarmLimit,
				m_bIndependentHighLevelAlarm,
				m_iIndependentHighLevelAlarmPercentage,
				m_fIndependentHighLevelAlarmLimit,
				m_bExportEnable,
				m_iExportOrder);

			foreach (Sounding s in m_lSoundingTable)
				eu.SoundingTable.Add(s.Copy());

			eu.SoundingCorrection.Enable = m_scSoundingCorrection.Enable;

			foreach (Correction c in m_scSoundingCorrection.CorrectionTable)
				eu.SoundingCorrection.CorrectionTable.Add(c.Copy());

			eu.SummaryScreenFaceplateLocation = new Point(m_pSummaryScreenFaceplateLocation.X, m_pSummaryScreenFaceplateLocation.Y);

			eu.MTDEInterface = new MTDEInterface(m_miMTDEInterface.Enable, m_miMTDEInterface.MTDEName, m_miMTDEInterface.MTDEOrder, m_miMTDEInterface.FuelTank);

			foreach (StopGauge sg in m_sgStopGaugeArray)
				eu.StopGaugeArray.Add(sg.Copy());

			return eu;
		}
        public static string EquipmentFromEquipmentID(string sEquipmentID)
        {
            try
            {
                return sEquipmentID.Substring(0, sEquipmentID.Length - 2);
            }
            catch
            {
                return sEquipmentID;
            }
        }

		public static int EquipmentTypeFromEquipmentID(string sEquipmentID)
		{
			try
			{
				return Convert.ToInt32(sEquipmentID.Substring(sEquipmentID.Length - 1));
			}
			catch
			{
				return -1;
			}
		}

		public static string CreateEquipmentID(string sEquipment, string sEquipmentLocation, int iEquipmentType)
		{
			return sEquipment + sEquipmentLocation + iEquipmentType.ToString();
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
			[Browsable(false)]
		#endif
		[System.Xml.Serialization.XmlIgnore]
		public string EquipmentID
		{
			get { return m_sEquipment + m_sEquipmentLocation + m_iEquipmentType.ToString(); }
		}

		#if !WindowsCE
			[Category("General")]
		#endif
		public bool Enable
		{
			get { return m_bEnable; }
			set { m_bEnable = value; }
		}

		#if !WindowsCE
			[Category("General"), DisplayName("Equipment Type"), TypeConverter(typeof(EquipmentType))]
		#endif
		[System.Xml.Serialization.XmlIgnore]
		public string EquipmentTypeString
		{
			get
			{
				switch (m_iEquipmentType)
				{
					case Enumerations.EquipmentType.Ballast:
						return "Ballast";
					case Enumerations.EquipmentType.Cargo:
						return "Cargo";
					case Enumerations.EquipmentType.Draft:
						return "Draft";
					case Enumerations.EquipmentType.Fuel:
						return "Fuel / Aux";
					case Enumerations.EquipmentType.List:
						return "List";
					case Enumerations.EquipmentType.Manifold:
						return "Manifold";
					case Enumerations.EquipmentType.Trim:
						return "Trim";
					case Enumerations.EquipmentType.Misc:
						return "Misc";
					default:
						return "Ballast";
				}
			}

			set
			{
				switch (value)
				{
					case "Ballast":
						m_iEquipmentType = Enumerations.EquipmentType.Ballast;
						break;
					case "Cargo":
						m_iEquipmentType = Enumerations.EquipmentType.Cargo;
						break;
					case "Draft":
						m_iEquipmentType = Enumerations.EquipmentType.Draft;
						break;
					case "Fuel / Aux":
						m_iEquipmentType = Enumerations.EquipmentType.Fuel;
						break;
					case "List":
						m_iEquipmentType = Enumerations.EquipmentType.List;
						break;
					case "Manifold":
						m_iEquipmentType = Enumerations.EquipmentType.Manifold;
						break;
					case "Trim":
						m_iEquipmentType = Enumerations.EquipmentType.Trim;
						break;
					case "Misc":
						m_iEquipmentType = Enumerations.EquipmentType.Misc;
						break;
				}
			}
		}

		[System.Xml.Serialization.XmlIgnore]
		public string EquipmentAbbreviation
		{
			get
			{
				switch (m_iEquipmentType)
				{
					case ICBObjectModel.Enumerations.EquipmentType.Ballast:
						return "B-" + m_sEquipment;
					case ICBObjectModel.Enumerations.EquipmentType.Cargo:
						return "C-" + m_sEquipment;
					case ICBObjectModel.Enumerations.EquipmentType.Fuel:
						return "A-" + m_sEquipment;
					case ICBObjectModel.Enumerations.EquipmentType.Manifold:
						return "M-" + m_sEquipment;
					case ICBObjectModel.Enumerations.EquipmentType.Misc:
						return "MI-" + m_sEquipment;
					default:
						return m_sEquipment;
				}
			}
		}

		public static string GetEquipmentAbbreviation(int iEquipmentType, string sEquipment)
		{
			switch(iEquipmentType)
			{
				case ICBObjectModel.Enumerations.EquipmentType.Ballast:
					return "B-" + sEquipment;
				case ICBObjectModel.Enumerations.EquipmentType.Cargo:
					return "C-" + sEquipment;
				case ICBObjectModel.Enumerations.EquipmentType.Fuel:
					return "A-" + sEquipment;
				case ICBObjectModel.Enumerations.EquipmentType.Manifold:
					return "M-" + sEquipment;
				case ICBObjectModel.Enumerations.EquipmentType.Misc:
					return "MI-" + sEquipment;
				default:
					return sEquipment;
			}
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public int EquipmentType
		{
			get { return m_iEquipmentType; }
			set { m_iEquipmentType = value; }
		}

		#if !WindowsCE
			[Category("General"), DisplayName("Equipment Location"), TypeConverter(typeof(EquipmentLocation))]
		#endif
		[System.Xml.Serialization.XmlIgnore]
		public string EquipmentLocationString
		{
			get
			{
				switch (m_sEquipmentLocation)
				{
					case Enumerations.EquipmentLocation.Aft:
						return "Aft";
					case Enumerations.EquipmentLocation.Center:
						return "Center";
					case Enumerations.EquipmentLocation.Fore:
						return "Fore";
					case Enumerations.EquipmentLocation.Port:
						return "Port";
					case Enumerations.EquipmentLocation.Starboard:
						return "Starboard";
					default:
						return "Port";
				}
			}
			set
			{
				switch (value)
				{
					case "Aft":
						m_sEquipmentLocation = Enumerations.EquipmentLocation.Aft;
						break;
					case "Center":
						m_sEquipmentLocation = Enumerations.EquipmentLocation.Center;
						break;
					case "Fore":
						m_sEquipmentLocation = Enumerations.EquipmentLocation.Fore;
						break;
					case "Port":
						m_sEquipmentLocation = Enumerations.EquipmentLocation.Port;
						break;
					case "Starboard":
						m_sEquipmentLocation = Enumerations.EquipmentLocation.Starboard;
						break;
				}
			}
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public string EquipmentLocation
		{
			get { return m_sEquipmentLocation; }
			set { m_sEquipmentLocation = value; }
		}

		#if !WindowsCE
			[Category("General"), DisplayName("Equipment Name"), Description("The name of the piece of equipment.  Note:  All tanks must have a numeric name to be compatable with the MTDE.")]
		#endif
		public string Equipment
		{
			get { return m_sEquipment; }
			set { m_sEquipment = value; }
		}

		#if !WindowsCE
			[Category("General"), DisplayName("Current Product")]
		#endif
		public string CurrentProduct
		{
			get { return m_sCurrentProduct == null ? "" : m_sCurrentProduct.ToUpper(); }
			set { m_sCurrentProduct = value; }
		}

		#if !WindowsCE
			[Category("Engineering"), DisplayName("Tank Height")]
		#endif
		public float TankHeight
		{
			get { return m_fTankHeight; }
			set { m_fTankHeight = value; }
		}

		#if !WindowsCE
			[Category("Engineering"), DisplayName("Volume Max")]
		#endif
		public float VolumeMax
		{
			get { return m_fVolumeMax; }
			set { m_fVolumeMax = value; }
		}

		#if !WindowsCE
			[Category("Engineering"), DisplayName("Volume Min")]
		#endif
		public float VolumeMin
		{
			get { return m_fVolumeMin; }
			set { m_fVolumeMin = value; }
		}

		public bool SpecificGravityApplicable
		{
			get { return m_bSpecificGravityApplicable; }
			set { m_bSpecificGravityApplicable = value; }
		}

		#if !WindowsCE
			[Category("Alarming"), DisplayName("Independent Overfill AMU Present")]
		#endif
		public bool IndependentOverfillAlarm
		{
			get { return m_bIndependentOverfillAlarm; }
			set { m_bIndependentOverfillAlarm = value; }
		}

		#if !WindowsCE
			[Category("Alarming"), DisplayName("Independent Overfill Alarm Percentage"), Description("Percentage of volume.")]
		#endif
		public int IndependentOverfillAlarmPercentage
		{
			get { return m_iIndependentOverfillAlarmPercentage; }
			set { m_iIndependentOverfillAlarmPercentage = value; }
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		[System.Xml.Serialization.XmlIgnore]
		public float IndependentOverfillAlarmLimit
		{
			get { return m_fIndependentOverfillAlarmLimit; }
			set { m_fIndependentOverfillAlarmLimit = value; }
		}

		#if !WindowsCE
			[Category("Alarming"), DisplayName("Independent High Level AMU Present")]
		#endif
		public bool IndependentHighLevelAlarm
		{
			get { return m_bIndependentHighLevelAlarm; }
			set { m_bIndependentHighLevelAlarm = value; }
		}
		
		#if !WindowsCE
			[Category("Alarming"), DisplayName("Independent High Level Alarm Percentage"), Description("Percentage of volume.")]
		#endif
		public int IndependentHighLevelAlarmPercentage
		{
			get { return m_iIndependentHighLevelAlarmPercentage; }
			set { m_iIndependentHighLevelAlarmPercentage = value; }
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		[System.Xml.Serialization.XmlIgnore]
		public float IndependenHighLevelAlarmLimit
		{
			get { return m_fIndependentHighLevelAlarmLimit; }
			set { m_fIndependentHighLevelAlarmLimit = value; }
		}

		#if !WindowsCE
			[Category("Engineering"), DisplayName("Sounding Table")]
		#endif
		public List<Sounding> SoundingTable
		{
			get { return m_lSoundingTable; }
			set { m_lSoundingTable = value; }
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public SoundingCorrection SoundingCorrection
		{
			get { return m_scSoundingCorrection; }
			set { m_scSoundingCorrection = value; }
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public List<GaugePoint> GaugePointArray
		{
			get { return m_lGaugePointArray; }
			set { m_lGaugePointArray = value; }
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public MTDEInterface MTDEInterface
		{
			get { return m_miMTDEInterface; }
			set { m_miMTDEInterface = value; }
		}

		#if !WindowsCE
			[Category("MTDE"), DisplayName("Enable")]
		#endif
		[System.Xml.Serialization.XmlIgnore]
		public bool MTDEEnable
		{
			get { return m_miMTDEInterface.Enable; }
			set { m_miMTDEInterface.Enable = value; }
		}

		#if !WindowsCE
			[Category("MTDE"), DisplayName("Tank Name")]
		#endif
		[System.Xml.Serialization.XmlIgnore]
		public int MTDEName
		{
			get { return m_miMTDEInterface.MTDEName; }
			set { m_miMTDEInterface.MTDEName = value; }
		}

		#if !WindowsCE
			[Category("MTDE"), DisplayName("Tank Order")]
		#endif
		[System.Xml.Serialization.XmlIgnore]
		public int MTDEOrder
		{
			get { return m_miMTDEInterface.MTDEOrder; }
			set { m_miMTDEInterface.MTDEOrder = value; }
		}

		[System.Xml.Serialization.XmlIgnore]
		public bool MTDEFuelTank
		{
			get { return m_miMTDEInterface.FuelTank; }
			set { m_miMTDEInterface.FuelTank = value; }
		}

		#if !WindowsCE
			[Category("User Interface"), DisplayName("Summary Screen Faceplate Location"), Description("Location of faceplate on summary screens.  Note:  The top left block is (0,0)")]
		#endif
		public Point SummaryScreenFaceplateLocation
		{
			get { return m_pSummaryScreenFaceplateLocation; }
			set { m_pSummaryScreenFaceplateLocation = value; }
		}

		#if !WindowsCE
			[Category("Stop Gauge"), DisplayName("Stop Gauge"), Description("Note:  Two should be set up for each tank.  One set as a Stop Final, and one set as Stop Warning (Not Stop Final)")]
		#endif
		public List<StopGauge> StopGaugeArray
		{
			get { return m_sgStopGaugeArray; }
			set { m_sgStopGaugeArray = value; }
		}

		public bool ExportEnable
		{
			get { return m_bExportEnable; }
			set { m_bExportEnable = value; }
		}

		public int ExportOrder
		{
			get { return m_iExportOrder; }
			set { m_iExportOrder = value; }
		}

		[System.Xml.Serialization.XmlIgnore]
		public bool Updated
		{
			get { return m_bUpdated; }
			set { m_bUpdated = value; }
		}

		public int MTDEAddr { get; set; }
	}

	public class Sounding
	{
		private float m_fLevel;
		private float m_fVolume;

		public Sounding()
		{
			m_fLevel = 0;
			m_fVolume = 0;
		}

		public Sounding(float fLevel, float fVolume)
		{
			m_fLevel = fLevel;
			m_fVolume = fVolume;
		}

		public Sounding Copy()
		{
			return new Sounding(m_fLevel, m_fVolume);
		}

		#if !WindowsCE
			[Category("General")]
		#endif
		public float Level
		{
			get { return m_fLevel; }
			set { m_fLevel = value; }
		}

		#if !WindowsCE
			[Category("General")]
		#endif
		public float Volume
		{
			get { return m_fVolume; }
			set { m_fVolume = value; }
		}
	}
}
