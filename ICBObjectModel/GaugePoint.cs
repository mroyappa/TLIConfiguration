using System;
using System.Text;
using System.Collections.Generic;
using ICBObjectModel.Enumerations;
using System.ComponentModel;

/*
 * CLASS SUMMARY:	GaugePoint
 * 
 * The Gauge Point object provides an interface for physical I/O to be configured for an 
 * Equipment Unit instance.  The object defines I/O raw and engineering scaling ranges, 
 * along with application ranges.  For each Gauge Point configured in a system, a unique
 * ProcessID can be derived from its' EquipmentID, GaugeType and GaugeNumber.  This unique
 * identifer is then used to identify actual values throughout the application.
 * 
 */

namespace ICBObjectModel
{
	public class GaugePoint
	{
		public const string DELIMITER = "$";

		private string m_sDisplayName;
		private string m_sProcessID;
		private bool m_bEnable;
		private bool m_bDisableFaceplateGraph;
		private int m_iGaugeType;
		private int m_iGaugeNumber;
		private float m_fRawMax;
		private float m_fRawMin;
		private float m_fEngineeringMax;	// High Scale Value
		private float m_fEngineeringMin;	// Low Scale Value
		private float m_fFullScaleValue;	// Faceplate Max EU
		private float m_fLowScaleValue;		// Faceplate Min EU
		private int m_iUnits;
		private int m_iUnits2;
		private float m_fLinearOffset;		// Offset
		private float m_fPhysicalOffset;	// Gauge Height
		private int m_iDigitalFilter;		
		private float m_fValueDeadband;
		private List<AlarmPoint> m_lAlarmPointArray;
		private int m_iIOType;
		private AMUInput m_aiAMUInput;
		private TAUInput m_tiTAUInput;
		private ModularBubblerInput m_mbiModularBubblerInput;
		private ModbusInput m_miModbusInput;
		private ModbusInterface[] m_miModbusInterfaceArray;
		private ModbusInterface[] m_miTCPModbusInterfaceArray;
		private bool m_bCalculated;
		private int m_iDFGFloat;

		public GaugePoint()
		{
			//Console.WriteLine("1");
			m_lAlarmPointArray = new List<AlarmPoint>();
			m_aiAMUInput = new AMUInput();
			m_tiTAUInput = new TAUInput();
			m_mbiModularBubblerInput = new ModularBubblerInput();
			m_miModbusInput = new ModbusInput();
			
			m_miModbusInterfaceArray = new ModbusInterface[5];
			m_miModbusInterfaceArray[0] = new ModbusInterface();
			m_miModbusInterfaceArray[1] = new ModbusInterface();
			m_miModbusInterfaceArray[2] = new ModbusInterface();
			m_miModbusInterfaceArray[3] = new ModbusInterface();
			m_miModbusInterfaceArray[4] = new ModbusInterface();

			m_miTCPModbusInterfaceArray = new ModbusInterface[4];
			m_miTCPModbusInterfaceArray[0] = new ModbusInterface();
			m_miTCPModbusInterfaceArray[1] = new ModbusInterface();
			m_miTCPModbusInterfaceArray[2] = new ModbusInterface();
			m_miTCPModbusInterfaceArray[3] = new ModbusInterface();

			m_bCalculated = false;
			m_iDFGFloat = Enumerations.DFGFloat.Standard;
		}

		public GaugePoint
		(
			string sDisplayName,
			bool bEnable,
			bool bDisableFaceplateGraph,
			int iGaugeType,
			int iGaugeNumber,
			float fRawMax,
			float fRawMin,
			float fEngineeringMax,
			float fEngineeringMin,
			float fFullScaleValue,
			float fLowScaleValue,
			int iUnits,
			int iUnits2,
			float fLinearOffset,
			float fPhysicalOffset,
			int iDigitalFilter,
			float fValueDeadband,
			int iIOType,
			bool bAMUEnable,
			int iAMUAddress,
			int iAMUChannel,
			bool bAnalogAMUChannel,
			bool bTAUEnable,
			int iTAUAddress,
			int iTAUChannelGroupType,
			int iTAUChannel,
			bool bBUBEnable,
			int iBUBAddress,
			int iBUBChannel,
			bool bBUBSecondaryChannelEnable,
			int iBUBSecondaryChannel,
			ModbusCommunicationInterface modbusInputModbusCommunicationInterface,
			bool bModbusInputEnable,
			int iModbusInputModbusDataType,
			ushort iModbusInputRegisterAddress1,
			ushort iModbusInputRegisterAddress2,
			float fModbusInputScale,
			bool bModbusInputSecondayEnable,
			int iModbusInputSecondayModbusDataType,
			ushort iModbusInputSecondayRegisterAddress1,
			ushort iModbusInputSecondayRegisterAddress2,
			float fModbusInputSecondayScale,
			ModbusInterface[] miModbusInterfaceArray,
			ModbusInterface[] miTCPModbusInterfaceArray,
			bool bDisableFaceplateBarGraph,
			bool bCalculated,
			int iDFGFloat
		)
		{
			Console.WriteLine("2");
			m_sDisplayName = sDisplayName;
			m_bEnable = bEnable;
			bDisableFaceplateGraph = m_bDisableFaceplateGraph;
			m_iGaugeType = iGaugeType;
			m_iGaugeNumber = iGaugeNumber;
			m_fRawMax = fRawMax;
			m_fRawMin = fRawMin;
			m_fEngineeringMax = fEngineeringMax;
			m_fEngineeringMin = fEngineeringMin;
			m_fFullScaleValue = fFullScaleValue;
			m_fLowScaleValue = fLowScaleValue;
			m_iUnits = iUnits;
			m_iUnits2 = iUnits2;
			m_fLinearOffset = fLinearOffset;
			m_fPhysicalOffset = fPhysicalOffset;
			m_iDigitalFilter = iDigitalFilter;
			m_fValueDeadband = fValueDeadband;

			m_lAlarmPointArray = new List<AlarmPoint>();

			m_iIOType = iIOType;
			m_aiAMUInput = new AMUInput(bAMUEnable, iAMUAddress, iAMUChannel, bAnalogAMUChannel);
			m_tiTAUInput = new TAUInput(bTAUEnable, iTAUAddress, iTAUChannelGroupType, iTAUChannel);
			m_mbiModularBubblerInput = new ModularBubblerInput(bBUBEnable, iBUBAddress, iBUBChannel, bBUBSecondaryChannelEnable, iBUBSecondaryChannel);
			m_miModbusInput = new ModbusInput(modbusInputModbusCommunicationInterface, bModbusInputEnable, iModbusInputModbusDataType, iModbusInputRegisterAddress1, iModbusInputRegisterAddress2,
				fModbusInputScale, bModbusInputSecondayEnable, iModbusInputSecondayModbusDataType, iModbusInputSecondayRegisterAddress1, iModbusInputSecondayRegisterAddress2, fModbusInputSecondayScale);

			m_miModbusInterfaceArray = new ModbusInterface[5];
			miModbusInterfaceArray.CopyTo(m_miModbusInterfaceArray, 0);

			m_miTCPModbusInterfaceArray = new ModbusInterface[4];
			m_miTCPModbusInterfaceArray.CopyTo(m_miTCPModbusInterfaceArray, 0);

			m_bDisableFaceplateGraph = bDisableFaceplateBarGraph;

			m_bCalculated = bCalculated;
			m_iDFGFloat = iDFGFloat;
		}

		public GaugePoint
		(
			bool bEnable,
			int iGaugeType,
			int iGaugeNumber,
			float fRawMax,
			float fRawMin,
			float fEngineeringMax,
			float fEngineeringMin,
			float fFullScaleValue,
			float fLowScaleValue,
			float fLinearOffset,
			int iDigitalFilter,
			float fValueDeadband,
			List<AlarmPoint> lAlarmPointArray,
			int iIOType,
			AMUInput aiAMUInput,
			TAUInput tiTAUInput,
			ModularBubblerInput mbiModularBubblerInput,
			ModbusInterface[] miModbusInterfaceArray,
			ModbusInterface[] miTCPModbusInterfaceArray
		)
		{
			Console.WriteLine("3");
			m_bEnable = bEnable;
			m_iGaugeType = iGaugeType;
			m_iGaugeNumber = iGaugeNumber;
			m_fRawMax = fRawMax;
			m_fRawMin = fRawMin;
			m_fEngineeringMax = fEngineeringMax;
			m_fEngineeringMin = fEngineeringMin;
			m_fFullScaleValue = fFullScaleValue;
			m_fLowScaleValue = fLowScaleValue;
			m_fLinearOffset = fLinearOffset;
			m_iDigitalFilter = iDigitalFilter;
			m_fValueDeadband = fValueDeadband;
			m_lAlarmPointArray = lAlarmPointArray;
			m_iIOType = iIOType;
			m_aiAMUInput = aiAMUInput;
			m_tiTAUInput = tiTAUInput;
			m_mbiModularBubblerInput = mbiModularBubblerInput;

			if (miModbusInterfaceArray == null)
			{
				m_miModbusInterfaceArray = new ModbusInterface[5];
				m_miModbusInterfaceArray[0] = new ModbusInterface();
				m_miModbusInterfaceArray[1] = new ModbusInterface();
				m_miModbusInterfaceArray[2] = new ModbusInterface();
				m_miModbusInterfaceArray[3] = new ModbusInterface();
				m_miModbusInterfaceArray[4] = new ModbusInterface();
			}
			else
			{
				m_miModbusInterfaceArray = new ModbusInterface[5];
				miModbusInterfaceArray.CopyTo(m_miModbusInterfaceArray, 0);
			}

			if (miTCPModbusInterfaceArray == null)
			{
				m_miTCPModbusInterfaceArray = new ModbusInterface[4];
				m_miTCPModbusInterfaceArray[0] = new ModbusInterface();
				m_miTCPModbusInterfaceArray[1] = new ModbusInterface();
				m_miTCPModbusInterfaceArray[2] = new ModbusInterface();
				m_miTCPModbusInterfaceArray[3] = new ModbusInterface();
			}
			else
			{
				m_miTCPModbusInterfaceArray = new ModbusInterface[4];
				miTCPModbusInterfaceArray.CopyTo(m_miTCPModbusInterfaceArray, 0);
			}
		}

		public GaugePoint Copy()
		{
			GaugePoint gp = new GaugePoint(
				m_sDisplayName,
				m_bEnable,
				m_bDisableFaceplateGraph,
				m_iGaugeType,
				m_iGaugeNumber,
				m_fRawMax,
				m_fRawMin,
				m_fEngineeringMax,
				m_fEngineeringMin,
				m_fFullScaleValue,
				m_fLowScaleValue,
				m_iUnits,
				m_iUnits2,
				m_fLinearOffset,
				m_fPhysicalOffset,
				m_iDigitalFilter,
				m_fValueDeadband,
				m_iIOType,
				m_aiAMUInput.Enable,
				m_aiAMUInput.AMUAddress,
				m_aiAMUInput.Channel,
				m_aiAMUInput.AnalogChannel,
				m_tiTAUInput.Enable,
				m_tiTAUInput.TAUAddress,
				m_tiTAUInput.ChannelGroupType,
				m_tiTAUInput.Channel,
				m_mbiModularBubblerInput.Enable,
				m_mbiModularBubblerInput.ModularBubblerAddress,
				m_mbiModularBubblerInput.Channel,
				m_mbiModularBubblerInput.SecondaryChannelEnable,
				m_mbiModularBubblerInput.SecondaryChannel,
				m_miModbusInput.ModbusCommunicationInterface,
				m_miModbusInput.Enable,
				m_miModbusInput.ModbusDataType,
				m_miModbusInput.RegisterAddress1,
				m_miModbusInput.RegisterAddress2,
				m_miModbusInput.Scale,
				m_miModbusInput.SecondaryEnable,
				m_miModbusInput.SecondaryModbusDataType,
				m_miModbusInput.SecondaryRegisterAddress1,
				m_miModbusInput.SecondaryRegisterAddress2,
				m_miModbusInput.SecondaryScale,
				m_miModbusInterfaceArray,
				m_miTCPModbusInterfaceArray,
				m_bDisableFaceplateGraph,
				m_bCalculated,
				m_iDFGFloat);

			foreach (AlarmPoint ap in m_lAlarmPointArray)
				gp.m_lAlarmPointArray.Add(ap.Copy());

			return gp;
		}

		public string CreateProcessID(string sEquipmentID)
		{
			return sEquipmentID + DELIMITER + m_iGaugeType.ToString() + m_iGaugeNumber.ToString();
		}
		public string CreateProcessID(string sEquipment, string sEquipmentType, string sEquipmentLocation)
		{
			// Equipment members before the DELIMITER also make up the equipmentid so that in the ui,
			// process data can be decoded.

			return (sEquipment + sEquipmentLocation + sEquipmentType + DELIMITER + m_iGaugeType.ToString() + m_iGaugeNumber.ToString());
		}

		public static string CreateProcessIDForConfiguraion(string sEquipmentID, int iGaugeType, int iGaugeNumber)
		{
			return sEquipmentID + DELIMITER + iGaugeType.ToString() + iGaugeNumber.ToString();
		}

		public static string EquipmentIDFromProcessID(string sProcessID)
		{
			return sProcessID.Substring(0, sProcessID.IndexOf(DELIMITER));
		}

		public static int GaugeTypeFromProcessID(string sProcessID)
		{
			try	{ return Convert.ToInt32(sProcessID.Substring(sProcessID.IndexOf(DELIMITER) + 1, 1)); }
			catch { return -1; }
		}

		public static int GaugeNumberFromProcessID(string sProcessID)
		{
			return Convert.ToInt32(sProcessID.Substring(sProcessID.Length - 1, 1));
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
		public string ProcessID
		{
			get { return m_sProcessID; }
			set { m_sProcessID = value; }
		}

		#if !WindowsCE
			[Category("General")]
		#endif
		public bool Enable
		{
			get { return m_bEnable; }
			set { m_bEnable = value; }
		}

		public bool DisableFaceplateGraph
		{
			get { return m_bDisableFaceplateGraph; }
			set { m_bDisableFaceplateGraph = value; }
		}

		#if !WindowsCE
			[Category("General"), DisplayName("Gauge Type"), Description("Note:  When adding gauge points, Temperature gauge points must exists before the Average Temperature gauge point will function."), TypeConverter(typeof(GaugeType))]
		#endif
		[System.Xml.Serialization.XmlIgnore]
		public string GaugeTypeString
		{
			get
			{
				switch (m_iGaugeType)
				{
					case Enumerations.GaugeType.AverageTemperature:
						return "Average Temperature";
					case Enumerations.GaugeType.ChannelStateAlarmMonitor:
						return "Channel State Alarm Monitor";
					case Enumerations.GaugeType.Level:
						return "Level";
					case Enumerations.GaugeType.List:
						return "List";
					case Enumerations.GaugeType.Pressure:
						return "Pressure";
					case Enumerations.GaugeType.Temperature:
						return "Temperature";
					case Enumerations.GaugeType.Trim:
						return "Trim";
					case Enumerations.GaugeType.Ullage:
						return "Ullage";
					case Enumerations.GaugeType.PowerFail:
						return "Power Fail";
					case Enumerations.GaugeType.HogSag:
						return "Hog / Sag";
					default:
						return "Level";
				}
			}

			set
			{
				switch (value)
				{
					case "Average Temperature":
						m_iGaugeType = Enumerations.GaugeType.AverageTemperature;
						break;
					case "Channel State Alarm Monitor":
						m_iGaugeType = Enumerations.GaugeType.ChannelStateAlarmMonitor;
						break;
					case "Level":
						m_iGaugeType = Enumerations.GaugeType.Level;
						break;
					case "List":
						m_iGaugeType = Enumerations.GaugeType.List;
						break;
					case "Pressure":
						m_iGaugeType = Enumerations.GaugeType.Pressure;
						break;
					case "Temperature":
						m_iGaugeType = Enumerations.GaugeType.Temperature;
						break;
					case "Trim":
						m_iGaugeType = Enumerations.GaugeType.Trim;
						break;
					case "Ullage":
						m_iGaugeType = Enumerations.GaugeType.Ullage;
						break;
					case "Power Fail":
						m_iGaugeType = Enumerations.GaugeType.PowerFail;
						break;
					case "Hog / Sag":
						m_iGaugeType = Enumerations.GaugeType.HogSag;
						break;
				}
			}
		}

		[System.Xml.Serialization.XmlIgnore]
		public string GaugeTypeStringForModbusExport
		{
			get
			{
				switch (m_iGaugeType)
				{
					case Enumerations.GaugeType.AverageTemperature:
						return "Average Temperature";
					case Enumerations.GaugeType.ChannelStateAlarmMonitor:
						return "Channel State Alarm Monitor";
					case Enumerations.GaugeType.Level:
						return "Level";
					case Enumerations.GaugeType.List:
						return "List";
					case Enumerations.GaugeType.Pressure:
						return "Pressure";
					case Enumerations.GaugeType.Temperature:
						{
							switch (m_iGaugeNumber)
							{
								case 1:
									return "Temperature TOP";
								case 2:
									return "Temperature MID";
								case 3:
									return "Temperature BOT";
								default:
									return "Temperature";
							}
						}
					case Enumerations.GaugeType.Trim:
						return "Trim";
					case Enumerations.GaugeType.Ullage:
						return "Ullage";
					case Enumerations.GaugeType.PowerFail:
						return "Power Fail";
					case Enumerations.GaugeType.HogSag:
						return "Hog / Sag";
					default:
						return "Level";
				}
			}
		}

		[System.Xml.Serialization.XmlIgnore]
		public string GaugeTypeStringExtended
		{
			get
			{
				switch (m_iGaugeType)
				{
					case Enumerations.GaugeType.AverageTemperature:
						return "Average Temperature";
					case Enumerations.GaugeType.ChannelStateAlarmMonitor:
						{
							if (m_sDisplayName != "")
								return m_sDisplayName;
							else
								return "Channel State Alarm Monitor";
						}
					case Enumerations.GaugeType.Level:
						return "Level";
					case Enumerations.GaugeType.List:
						return "List";
					case Enumerations.GaugeType.Pressure:
						return "Pressure";
					case Enumerations.GaugeType.Temperature:
						{
							switch (m_iGaugeNumber)
							{
								case 1:
									return "Temperature TOP";
								case 2:
									return "Temperature MID";
								case 3:
									return "Temperature BOT";
								default:
									return "Temperature TOP";
							}
						}
					case Enumerations.GaugeType.Trim:
						return "Trim";
					case Enumerations.GaugeType.Ullage:
						return "Ullage";
					case Enumerations.GaugeType.PowerFail:
						return "Power Fail";
					case Enumerations.GaugeType.HogSag:
						return "Hog / Sag";
					default:
						return "Level";
				}
			}
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public int GaugeType
		{
			get { return m_iGaugeType; }
			set { m_iGaugeType = value; }
		}

		#if !WindowsCE
			[Category("General"), DisplayName("Gauge Number"), Description("Note:  Gauge number is oridinal, and currently only temperature only supports more than one gauge per equipment unit.")]
		#endif
		public int GaugeNumber
		{
			get { return m_iGaugeNumber; }
			set { m_iGaugeNumber = value; }
		}

		#if !WindowsCE
			[Category("Engineering"), DisplayName("Raw Max"), Description("Maximum raw value possible from gauge equipment.")]
		#endif
		public float RawMax
		{
			get { return m_fRawMax; }
			set { m_fRawMax = value; }
		}
		#if !WindowsCE
			[Category("Engineering"), DisplayName("Raw Min"), Description("Minimum raw value possible from gauge equipment.")]
		#endif
		public float RawMin
		{
			get { return m_fRawMin; }
			set { m_fRawMin = value; }
		}

		#if !WindowsCE
			[Category("Engineering"), DisplayName("Engineering Max"), Description("Maximum engieering value corresponding to Raw Max.")]
		#endif
		public float EngineeringMax
		{
			get { return m_fEngineeringMax; }
			set { m_fEngineeringMax = value; }
		}

		#if !WindowsCE
			[Category("Engineering"), DisplayName("Engineering Min"), Description("Minimum engieering value corresponding to Raw Min.")]
		#endif
		public float EngineeringMin
		{
			get { return m_fEngineeringMin; }
			set { m_fEngineeringMin = value; }
		}

		#if !WindowsCE
			[Category("Engineering"), DisplayName("Full Scale Value"), Description("Maximum reportable value.")]
		#endif
		public float FullScaleValue
		{
			get { return m_fFullScaleValue; }
			set { m_fFullScaleValue = value; }
		}

		#if !WindowsCE
			[Category("Engineering"), DisplayName("Low Scale Value"), Description("Minimum reportable value.")]
		#endif
		public float LowScaleValue
		{
			get { return m_fLowScaleValue; }
			set { m_fLowScaleValue = value; }
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public int Units
		{
			get { return m_iUnits; }
			set { m_iUnits = value; }
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public int Units2
		{
			get { return m_iUnits2; }
			set { m_iUnits2 = value; }
		}

		#if !WindowsCE
			[Category("Engineering"), DisplayName("Physical Offset"), Description("Offset used to compensate for either the ullage cap or bottom offset.")]
		#endif
		public float PhysicalOffset
		{
			get { return m_fPhysicalOffset; }
			set { m_fPhysicalOffset = value; }
		}

		#if !WindowsCE
			[Category("Engineering"), DisplayName("Linear Offset"), Description("Offset used to adjust converted reading.")]
		#endif
		public float LinearOffset
		{
			get { return m_fLinearOffset; }
			set { m_fLinearOffset = value; }
		}

		#if !WindowsCE
			[Category("Engineering"), DisplayName("Digital Filter"), Description("Provides simple digital filtering of raw data by average the number of samples requested for 'Digital Filter', 1 will disable filtering")]
		#endif
		public int DigitalFilter
		{
			get { return m_iDigitalFilter; }
			set { m_iDigitalFilter = value; }
		}

		#if !WindowsCE
			[Category("Engineering"), DisplayName("Raw Value Deadband"), Description("Deadband for a value change to be signaled to the user interface.")]
		#endif
		public float ValueDeadband
		{
			get { return m_fValueDeadband; }
			set { m_fValueDeadband = value; }
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public List<AlarmPoint> AlarmPointArray
		{
			get { return m_lAlarmPointArray; }
			set { m_lAlarmPointArray = value; }
		}

		public int IOType
		{
			get { return m_iIOType; }
			set { m_iIOType = value; }
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public AMUInput AMUInput
		{
			get { return m_aiAMUInput; }
			set { m_aiAMUInput = value; }
		}

		[System.Xml.Serialization.XmlIgnore]
		public bool AMUEnable
		{
			get { return m_aiAMUInput.Enable; }
			set { m_aiAMUInput.Enable = value; }
		}

		[System.Xml.Serialization.XmlIgnore]
		public int AMUAddress
		{
			get { return m_aiAMUInput.AMUAddress; }
			set { m_aiAMUInput.AMUAddress = value; }
		}

		[System.Xml.Serialization.XmlIgnore]
		public int AMUChannel
		{
			get { return m_aiAMUInput.Channel; }
			set { m_aiAMUInput.Channel = value; }
		}

		[System.Xml.Serialization.XmlIgnore]
		public bool AMUAnalogChannel
		{
			get { return m_aiAMUInput.AnalogChannel; }
			set { m_aiAMUInput.AnalogChannel = value; }
		}

		public TAUInput TAUInput
		{
			get { return m_tiTAUInput; }
			set { m_tiTAUInput = value; }
		}

		[System.Xml.Serialization.XmlIgnore]
		public bool TAUEnable
		{
			get { return m_tiTAUInput.Enable; }
			set { m_tiTAUInput.Enable = value; }
		}

		[System.Xml.Serialization.XmlIgnore]
		public int TAUAddress
		{
			get { return m_tiTAUInput.TAUAddress; }
			set { m_tiTAUInput.TAUAddress = value; }
		}

		[System.Xml.Serialization.XmlIgnore]
		public int TAUChannelGroupType
		{
			get { return m_tiTAUInput.ChannelGroupType; }
			set { m_tiTAUInput.ChannelGroupType = value; }
		}

		[System.Xml.Serialization.XmlIgnore]
		public int TAUChannel
		{
			get { return m_tiTAUInput.Channel; }
			set { m_tiTAUInput.Channel = value; }
		}

		public ModularBubblerInput ModularBubblerInput
		{
			get { return m_mbiModularBubblerInput; }
			set { m_mbiModularBubblerInput = value; }
		}

		public bool BUBEnable
		{
			get { return m_mbiModularBubblerInput.Enable; }
			set { m_mbiModularBubblerInput.Enable = value; }
		}

		public int BUBAddress
		{
			get { return m_mbiModularBubblerInput.ModularBubblerAddress; }
			set { m_mbiModularBubblerInput.ModularBubblerAddress = value; }
		}

		public int BUBChannel
		{
			get { return m_mbiModularBubblerInput.Channel; }
			set { m_mbiModularBubblerInput.Channel = value; }
		}

		public bool BUBSecondaryChannelEnable
		{
			get { return m_mbiModularBubblerInput.SecondaryChannelEnable; }
			set { m_mbiModularBubblerInput.SecondaryChannelEnable = value; }
		}

		public int BUBSecondaryChannel
		{
			get { return m_mbiModularBubblerInput.SecondaryChannel; }
			set { m_mbiModularBubblerInput.SecondaryChannel = value; }
		}

		public ModbusInput ModbusInput
		{
			get { return m_miModbusInput; }
			set { m_miModbusInput = value; }
		}

		public ModbusInterface[] ModbusInterfaceArray
		{
			get { return m_miModbusInterfaceArray; }
			set { m_miModbusInterfaceArray = value; }
		}

		public ModbusInterface[] TCPModbusInterfaceArray
		{
			get { return m_miTCPModbusInterfaceArray; }
			set { m_miTCPModbusInterfaceArray = value; }
		}

		public bool Calculated
		{
			get { return m_bCalculated; }
			set { m_bCalculated = value; }
		}

		public int DFGFloat
		{
			get { return m_iDFGFloat; }
			set { m_iDFGFloat = value; }
		}
	}
}
