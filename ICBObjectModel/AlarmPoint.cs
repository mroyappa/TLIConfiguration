using System;
using System.Text;
using System.Collections.Generic;
using ICBObjectModel.Enumerations;
using System.ComponentModel;

/*
 * CLASS SUMMARY:	AlarmPoint
 * 
 * AlarmPoint is the class used to define an alarm.  Hierarchically an AlarmPoint belongs
 * to a GaugePoint.  This object allows for the definition of all aspects of an alarm including:
 * AlarmMonitorType (Analog, ChannelState, etc.), AlarmPriority, Debounce, AlarmAnnunciations, etc.
 * 
 */

namespace ICBObjectModel
{
	public class AlarmPoint
	{
		private string m_sDisplayName;
		private bool m_bEnable;
		private Guid m_guidAlarmID;
		private int m_iAlarmMonitorType;
		private string m_sAlarmType;
		private string m_sAlarmGroup;
		private string m_sAlarmText;
		private int m_iAlarmPriority;
		private string m_sComparator;
		private float m_fLimit;
		private float m_fFaceplateSetpoint;
		private int m_iLimitUnits;
		private float m_fAlarmDeadband;
		private float m_fDebounceTimer;
		private float m_fTrailingDebounceTimer;
		private bool m_bAutoClearEnable;
		private List<string> m_sAlarmAnnunciation;
		private ModbusInterface m_ModbusInterface;
		private ModbusInterface m_TCPModbusInterface;

		public AlarmPoint()
		{
			m_sAlarmAnnunciation = new List<string>();
			m_ModbusInterface = new ModbusInterface();
			m_TCPModbusInterface = new ModbusInterface();
		}

		public AlarmPoint
		(
			string sDisplayName,
			bool bEnable,
			Guid guidAlarmID,
			int iAlarmMonitorType,
			string sAlarmType,
			string sAlarmGroup,
			string sAlarmText,
			int iAlarmPriority,
			string sComparator,
			float fLimit,
			int iLimitUnits,
			float fAlarmDeadband,
			float fDebounceTimer,
			float fTrailingDebounceTimer,
			bool bAutoClearEnable,
			List<string> sAlarmAnnunciation,
			ModbusInterface miModbusInterface,
			ModbusInterface miTCPModbusInterface
		)
		{
			m_sDisplayName = sDisplayName;
			m_bEnable = bEnable;
			m_guidAlarmID = guidAlarmID;
			m_iAlarmMonitorType = iAlarmMonitorType;
			m_sAlarmType = sAlarmType;
			m_sAlarmGroup = sAlarmGroup;
			m_sAlarmText = sAlarmText;
			m_iAlarmPriority = iAlarmPriority;
			m_sComparator = sComparator;
			m_fLimit = fLimit;
			m_iLimitUnits = iLimitUnits;
			m_fAlarmDeadband = fAlarmDeadband;
			m_fDebounceTimer = fDebounceTimer;
			m_fTrailingDebounceTimer = fTrailingDebounceTimer;
			m_bAutoClearEnable = bAutoClearEnable;
			m_sAlarmAnnunciation = sAlarmAnnunciation;
			m_ModbusInterface = miModbusInterface;
			m_TCPModbusInterface = miTCPModbusInterface;
		}

		public AlarmPoint Copy()
		{
			AlarmPoint ap = new AlarmPoint(
				m_sDisplayName,
				m_bEnable,
				m_guidAlarmID,
				m_iAlarmMonitorType,
				m_sAlarmType,
				m_sAlarmGroup,
				m_sAlarmText,
				m_iAlarmPriority,
				m_sComparator,
				m_fLimit,
				m_iLimitUnits,
				m_fAlarmDeadband,
				m_fDebounceTimer,
				m_fTrailingDebounceTimer,
				m_bAutoClearEnable,
				new List<string>(),
				m_ModbusInterface.Copy(),
				m_TCPModbusInterface.Copy()
				);

			ap.FaceplateSetpoint = m_fFaceplateSetpoint;

			foreach (string sAlarmAnnunciation in m_sAlarmAnnunciation)
				ap.AlarmAnnunciation.Add(sAlarmAnnunciation);

			return ap;
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
			[Category("General")]
		#endif
		public bool Enable
		{
			get { return m_bEnable; }
			set { m_bEnable = value; }
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		[System.Xml.Serialization.XmlIgnore]
		public Guid AlarmID
		{
			get { return m_guidAlarmID; }
			set { m_guidAlarmID = value; }
		}

		#if !WindowsCE
			[Category("General"), DisplayName("Alarm Monitor Type"), TypeConverter(typeof(AlarmMonitorType))]
		#endif
		[System.Xml.Serialization.XmlIgnore]
		public string AlarmMonitorTypeString
		{
			get
			{
				switch (m_iAlarmMonitorType)
				{
					case Enumerations.AlarmMonitorType.AnalogValue:
						return "Analog Value";
					case Enumerations.AlarmMonitorType.AnalogValue2:
						return "Sounding";
					case Enumerations.AlarmMonitorType.ChannelAlarmState:
						return "Channel Alarm State";
					case Enumerations.AlarmMonitorType.ChannelCondition:
						return "Channel Condition";
					case Enumerations.AlarmMonitorType.DigitalValue:
						return "Digital Value";
					default:
						return "Analog Value";
				}
			}

			set
			{
				switch (value)
				{
					case "Analog Value":
						m_iAlarmMonitorType = Enumerations.AlarmMonitorType.AnalogValue;
						break;
					case "Sounding":
						m_iAlarmMonitorType = Enumerations.AlarmMonitorType.AnalogValue2;
						break;
					case "Channel Alarm State":
						m_iAlarmMonitorType = Enumerations.AlarmMonitorType.ChannelAlarmState;
						break;
					case "Channel Condition":
						m_iAlarmMonitorType = Enumerations.AlarmMonitorType.ChannelCondition;
						break;
					case "Digital Value":
						m_iAlarmMonitorType = Enumerations.AlarmMonitorType.DigitalValue;
						break;
				}
			}
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public int AlarmMonitorType
		{
			get { return m_iAlarmMonitorType; }
			set { m_iAlarmMonitorType = value; }
		}

		#if !WindowsCE
			[Category("General"), DisplayName("Alarm Type"), TypeConverter(typeof(AlarmType))]
		#endif
		[System.Xml.Serialization.XmlIgnore]
		public string AlarmTypeString
		{
			get
			{
				switch (m_sAlarmType)
				{
					case Enumerations.AlarmType.Alarm:
						return "Alarm";
					case Enumerations.AlarmType.HighAlarm:
						return "High Alarm";
					case Enumerations.AlarmType.HighWarning:
						return "High Warning";
					case Enumerations.AlarmType.LowAlarm:
						return "Low Alarm";
					case Enumerations.AlarmType.LowWarning:
						return "Low Warning";
					case Enumerations.AlarmType.Warning:
						return "Warning";
					default:
						return "Alarm";
				}
			}
			set
			{
				switch (value)
				{
					case "Alarm":
						m_sAlarmType = Enumerations.AlarmType.Alarm;
						break;
					case "High Alarm":
						m_sAlarmType = Enumerations.AlarmType.HighAlarm;
						break;
					case "High Warning":
						m_sAlarmType = Enumerations.AlarmType.HighWarning;
						break;
					case "Low Alarm":
						m_sAlarmType = Enumerations.AlarmType.LowAlarm;
						break;
					case "Low Warning":
						m_sAlarmType = Enumerations.AlarmType.LowWarning;
						break;
					case "Warning":
						m_sAlarmType = Enumerations.AlarmType.Warning;
						break;
				}
			}
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public string AlarmType
		{
			get { return m_sAlarmType; }
			set { m_sAlarmType = value; }
		}

		#if !WindowsCE
			[Category("General"), DisplayName("Alarm Group")]
		#endif
		public string AlarmGroup
		{
			get { return m_sAlarmGroup; }
			set { m_sAlarmGroup = value; }
		}

		#if !WindowsCE
			[Category("General"), DisplayName("Alarm Text")]
		#endif
		public string AlarmText
		{
			get { return m_sAlarmText; }
			set { m_sAlarmText = value; }
		}

		#if !WindowsCE
			[Category("General"), DisplayName("Alarm Priority")]
		#endif
		public int AlarmPriority
		{
			get { return m_iAlarmPriority; }
			set { m_iAlarmPriority = value; }
		}

		#if !WindowsCE
			[Category("Engineering"), DisplayName("Comparator"), TypeConverter(typeof(Comparator))]
		#endif
		[System.Xml.Serialization.XmlIgnore]
		public string ComparatorString
		{
			get
			{
				switch (m_sComparator)
				{
					case Enumerations.Comparator.EqualTo:
						return "Equal To";
					case Enumerations.Comparator.GreaterThan:
						return "Greater Than";
					case Enumerations.Comparator.GreaterThanOrEqualTo:
						return "Greater Than Or Equal To";
					case Enumerations.Comparator.LessThan:
						return "Less Than";
					case Enumerations.Comparator.LessThanOrEqualTo:
						return "Less Than Or Equal To";
					default:
						return "Equal To";
				}
			}
			set
			{
				switch (value)
				{
					case "Equal To":
						m_sComparator = Enumerations.Comparator.EqualTo;
						break;
					case "Greater Than":
						m_sComparator = Enumerations.Comparator.GreaterThan;
						break;
					case "Greater Than Or Equal To":
						m_sComparator = Enumerations.Comparator.GreaterThanOrEqualTo;
						break;
					case "Less Than":
						m_sComparator = Enumerations.Comparator.LessThan;
						break;
					case "Less Than Or Equal To":
						m_sComparator = Enumerations.Comparator.LessThanOrEqualTo;
						break;
				}
			}
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public string Comparator
		{
			get { return m_sComparator; }
			set { m_sComparator = value; }
		}

		#if !WindowsCE
			[Category("Engineering"), DisplayName("Limit")]
		#endif
		public float Limit
		{
			get { return m_fLimit; }
			set { m_fLimit = value; }
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public float FaceplateSetpoint
		{
			get { return m_fFaceplateSetpoint; }
			set { m_fFaceplateSetpoint = value; }
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public int LimitUnits
		{
			get { return m_iLimitUnits; }
			set { m_iLimitUnits = value; }
		}

		#if !WindowsCE
			[Category("Engineering"), DisplayName("Alarm Deadband"), Description("Deadband applied when alarm ends.")]
		#endif
		public float AlarmDeadband
		{
			get { return m_fAlarmDeadband; }
			set { m_fAlarmDeadband = value; }
		}

		#if !WindowsCE
			[Category("Engineering"), DisplayName("Debounce Timer"), Description("Debounce for annunciating a new alarm.")]
		#endif
		public float DebounceTimer
		{
			get { return m_fDebounceTimer; }
			set { m_fDebounceTimer = value; }
		}

		#if !WindowsCE
			[Category("Engineering"), DisplayName("Trailing Debounce Timer"), Description("Trailing debounce for ending an alarm.")]
		#endif
		public float TrailingDebounceTimer
		{
			get { return m_fTrailingDebounceTimer; }
			set { m_fTrailingDebounceTimer = value; }
		}

		#if !WindowsCE
			[Category("Engineering"), DisplayName("Auto Acknowledge Alarm"), Description("Alarm will be automatically acknowledged if alarm ends before it has been acknowledged.")]
		#endif
		public bool AutoClearEnable
		{
			get { return m_bAutoClearEnable; }
			set { m_bAutoClearEnable = value; }
		}

		#if !WindowsCE
			[Category("Alarm Annunciation"), DisplayName("Alarm Annunciations"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor,System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		#endif
		public List<string> AlarmAnnunciation
		{
			get { return m_sAlarmAnnunciation; }
			set { m_sAlarmAnnunciation = value; }
		}

		public ModbusInterface ModbusInterface
		{
			get { return m_ModbusInterface; }
			set { m_ModbusInterface = value; }
		}

		public ModbusInterface TCPModbusInterface
		{
			get { return m_TCPModbusInterface; }
			set { m_TCPModbusInterface = value; }
		}
	}
}
