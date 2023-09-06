using System;
using System.Collections.Generic;
using System.Text;

/*
 * CLASS SUMAMRY:	IOProcessVariable
 * 
 * This class is used by the device engine (AMUEngine, TAUEngine, etc.) as an internal object
 * to track individual IO point values and calculations.  Included in the object are all
 * parameters to scale and filter raw IO values.
 * 
 */

namespace ICBObjectModel
{
	public class IOProcessVariable
	{
		public const float UNINITIALIZED_RAW = -999;

		private bool m_bForceEvaluation;
		private string m_sProcessID;
		private string m_sEquipmentID;
		private string m_sEquipment;
		private string m_sEquipmentLocation;
		private int m_iEquipmentType;
		private float m_fTankHeight;
		private int m_iGaugeType;
		private int m_iGaugeNumber;
		private int m_iIOType;
		private string m_sIOID;
		private int m_iIOAddress;
		public int m_iIOChannelGroupType;
		private int m_iIOChannel;
		private bool m_bIOSecondaryChannelEnable;
		private int m_iIOSecondaryChannel;
		private bool m_bAnalogChannel;
		private bool m_bSpecificGravityApplicable;
		private float m_fRawMax;
		private float m_fRawMin;
		private float m_fEngineeringMax;
		private float m_fEngineeringMin;
		private float m_fFullScaleValue;
		private float m_fLowScaleValue;
		private float m_fLinearOffset;
		private float m_fPhysicalOffset;
		private int m_iDigitalFilter;
		private float m_fValueDeadband;
		private int m_iUnits;
		private int m_iUnits2;
		private float[] m_fRaw;
		private float m_fLastRaw;
		private int m_iLastRawIndex;
		private byte m_bPreviousChannelState;
		private byte m_bChannelState;
		private byte m_bSecondaryChannelState;
		private float m_fPreviousValue;
		private float m_fValue;
		private bool m_bAggregateEnable1;
		private float m_fAggregateValue1;
		private byte m_bAggregateChannelState1;
		private bool m_bAggregateEnable2;
		private float m_fAggregateValue2;
		private byte m_bAggregateChannelState2;
		private bool m_bAggregateEnable3;
		private float m_fAggregateValue3;
		private byte m_bAggregateChannelState3;
		private bool m_bReportValue;
		private bool m_bReportAggregateValue;
		private int m_iDFGFloat;

		public IOProcessVariable
		(
			string sProcessID,
			string sEquipmentID,
			string sEquipment,
			string sEquipmentLocation,
			int iEquipmentType,
			float fTankHeight,
			int iGaugeType,
			int iGaugeNumber,
			int iIOType,
			string sIOID,
			int iIOAddress,
			int iIOChannelGroupType,
			int iIOChannel,
			bool bAnalogChannel,
			bool bSpecificGravityApplicable,
			float fRawMax,
			float fRawMin,
			float fEngineeringMax,
			float fEngineeringMin,
			float fFullScaleValue,
			float fLowScaleValue,
			float fLinearOffset,
			float fPhysicalOffset,
			int iDigitalFilter,
			float fValueDeadband,
			int iUnits,
			int iUnits2,
			int iDFGFloat
		)
		{
			m_sProcessID = sProcessID;
			m_sEquipmentID = sEquipmentID;
			m_sEquipment = sEquipment;
			m_sEquipmentLocation = sEquipmentLocation;
			m_iEquipmentType = iEquipmentType;
			m_fTankHeight = fTankHeight;
			m_iGaugeType = iGaugeType;
			m_iGaugeNumber = iGaugeNumber;
			m_iIOType = iIOType;
			m_sIOID = sIOID;
			m_iIOAddress = iIOAddress;
			m_iIOChannel = iIOChannel;
			m_iIOChannelGroupType = iIOChannelGroupType;
			m_bAnalogChannel = bAnalogChannel;
			m_bSpecificGravityApplicable = bSpecificGravityApplicable;
			m_fRawMax = fRawMax;
			m_fRawMin = fRawMin;
			m_fEngineeringMax = fEngineeringMax;
			m_fEngineeringMin = fEngineeringMin;
			m_fFullScaleValue = fFullScaleValue;
			m_fLowScaleValue = fLowScaleValue;
			m_fLinearOffset = fLinearOffset;
			m_fPhysicalOffset = fPhysicalOffset;
			m_iDigitalFilter = iDigitalFilter;
			m_fValueDeadband = fValueDeadband;
			m_iUnits = iUnits;
			m_iUnits2 = iUnits2;
			m_iDFGFloat = iDFGFloat;

			if (m_iDigitalFilter <= 0)
			{
				m_iDigitalFilter = 1;
				m_fRaw = new float[m_iDigitalFilter];
			}
			else
				m_fRaw = new float[m_iDigitalFilter];

			for (int i = 0; i <= m_iDigitalFilter - 1; i++)
				m_fRaw[i] = UNINITIALIZED_RAW;

			m_fLastRaw = UNINITIALIZED_RAW;
			m_iLastRawIndex = -1;
			m_fPreviousValue = -1;
			m_fValue = 0;
			m_bIOSecondaryChannelEnable = false;
			m_iIOSecondaryChannel = 0;
			m_bSecondaryChannelState = 0x00;
			m_fAggregateValue1 = 0;
			m_fAggregateValue2 = 0;
			m_fAggregateValue3 = 0;
			m_bReportValue = false;
			m_bReportAggregateValue = false;
		}

		public string GetAverageTemperatureProcessID()
		{ 
			return m_sEquipmentID + GaugePoint.DELIMITER + Enumerations.GaugeType.AverageTemperature.ToString() + "1";
		}

		public static string ForceAverageTemperatureProcessID(string sProcessID)
		{
			try
			{
				string sEquipmentID = sProcessID.Substring(0, sProcessID.IndexOf(GaugePoint.DELIMITER));
				return sEquipmentID + GaugePoint.DELIMITER + Enumerations.GaugeType.AverageTemperature.ToString() + "1";
			}
			catch
			{
				return "";
			}
		}

		public bool ForceEvaluation
		{
			get { return m_bForceEvaluation; }
			set { m_bForceEvaluation = value; }
		}

		public string ProcessID
		{
			get { return m_sProcessID; }
			set { m_sProcessID = value; }
		}

		public string EquipmentID
		{
			get { return m_sEquipmentID; }
			set { m_sEquipmentID = value; }
		}

		public string Equipment
		{
			get { return m_sEquipment; }
			set { m_sEquipment = value; }
		}

		public string EquipmentLocation
		{
			get { return m_sEquipmentLocation; }
			set { m_sEquipmentLocation = value; }
		}

		public int EquipmentType
		{
			get { return m_iEquipmentType; }
			set { m_iEquipmentType = value; }
		}

		public float TankHeight
		{
			get { return m_fTankHeight; }
			set { m_fTankHeight = value; }
		}

		public int GaugeType
		{
			get { return m_iGaugeType; }
			set { m_iGaugeType = value; }
		}

		public int GaugeNumber
		{
			get { return m_iGaugeNumber; }
			set { m_iGaugeNumber = value; }
		}

		public int IOType
		{
			get { return m_iIOType; }
			set { m_iIOType = value; }
		}

		public string IOID
		{
			get { return m_sIOID; }
			set { m_sIOID = value; }
		}

		public int IOAddress
		{
			get { return m_iIOAddress; }
			set { m_iIOAddress = value; }
		}

		public int IOChannelGroupType
		{
			get { return m_iIOChannelGroupType; }
			set { m_iIOChannelGroupType = value; }
		}

		public int IOChannel
		{
			get { return m_iIOChannel; }
			set { m_iIOChannel = value; }
		}

		public bool IOSecondaryChannelEnable
		{
			get { return m_bIOSecondaryChannelEnable; }
			set { m_bIOSecondaryChannelEnable = value; }
		}

		public int IOSecondaryChannel
		{
			get { return m_iIOSecondaryChannel; }
			set { m_iIOSecondaryChannel = value; }
		}

		public bool AnalogChannel
		{
			get { return m_bAnalogChannel; }
			set { m_bAnalogChannel = value; }
		}

		public bool SpecificGravityApplicable
		{
			get { return m_bSpecificGravityApplicable; }
			set { m_bSpecificGravityApplicable = value; }
		}

		public float RawMax
		{
			get { return m_fRawMax; }
			set { m_fRawMax = value; }
		}

		public float RawMin
		{
			get { return m_fRawMin; }
			set { m_fRawMin = value; }
		}

		public float EngineeringMax
		{
			get { return m_fEngineeringMax; }
			set { m_fEngineeringMax = value; }
		}

		public float EngineeringMin
		{
			get { return m_fEngineeringMin; }
			set { m_fEngineeringMin = value; }
		}

		public float FullScaleValue
		{
			get { return m_fFullScaleValue; }
			set { m_fFullScaleValue = value; }
		}

		public float LowScaleValue
		{
			get { return m_fLowScaleValue; }
			set { m_fLowScaleValue = value; }
		}

		public float LinearOffset
		{
			get { return m_fLinearOffset; }
			set { m_fLinearOffset = value; }
		}

		public float PhysicalOffset
		{
			get { return m_fPhysicalOffset; }
			set { m_fPhysicalOffset = value; }
		}

		public int DigitalFilter
		{
			get { return m_iDigitalFilter; }
			set { m_iDigitalFilter = value; }
		}

		public float ValueDeadband
		{
			get { return m_fValueDeadband; }
			set { m_fValueDeadband = value; }
		}

		public int Units
		{
			get { return m_iUnits; }
			set { m_iUnits = value; }
		}

		public int Units2
		{
			get { return m_iUnits2; }
			set { m_iUnits2 = value; }
		}

		public float[] Raw
		{
			get { return m_fRaw; }
			set { m_fRaw = value; }
		}

		public float LastRaw
		{
			get { return m_fLastRaw; }
			set { m_fLastRaw = value; }
		}

		public int LastRawIndex
		{
			get { return m_iLastRawIndex; }
			set { m_iLastRawIndex = value; }
		}

		public byte PreviousChannelState
		{
			get { return m_bPreviousChannelState; }
			set { m_bPreviousChannelState = value; }
		}

		public byte ChannelState
		{
			get { return m_bChannelState; }
			set { m_bChannelState = value; }
		}

		public byte SecondaryChannelState
		{
			get { return m_bSecondaryChannelState; }
			set { m_bSecondaryChannelState = value; }
		}

		public float PreviousValue
		{
			get { return m_fPreviousValue; }
			set { m_fPreviousValue = value; }
		}

		public float Value
		{
			get { return m_fValue; }
			set { m_fValue = value; }
		}

		public bool AggregateEnable1
		{
			get { return m_bAggregateEnable1; }
			set { m_bAggregateEnable1 = value; }
		}

		public float AggregateValue1
		{
			get { return m_fAggregateValue1; }
			set { m_fAggregateValue1 = value; }
		}

		public byte AggregateChannelState1
		{
			get { return m_bAggregateChannelState1; }
			set { m_bAggregateChannelState1 = value; }
		}

		public bool AggregateEnable2
		{
			get { return m_bAggregateEnable2; }
			set { m_bAggregateEnable2 = value; }
		}

		public float AggregateValue2
		{
			get { return m_fAggregateValue2; }
			set { m_fAggregateValue2 = value; }
		}

		public byte AggregateChannelState2
		{
			get { return m_bAggregateChannelState2; }
			set { m_bAggregateChannelState2 = value; }
		}

		public bool AggregateEnable3
		{
			get { return m_bAggregateEnable3; }
			set { m_bAggregateEnable3 = value; }
		}

		public float AggregateValue3
		{
			get { return m_fAggregateValue3; }
			set { m_fAggregateValue3 = value; }
		}

		public byte AggregateChannelState3
		{
			get { return m_bAggregateChannelState3; }
			set { m_bAggregateChannelState3 = value; }
		}

		public bool ReportValue
		{
			get { return m_bReportValue; }
			set { m_bReportValue = value; }
		}

		public bool ReportAggregateValue
		{
			get { return m_bReportAggregateValue; }
			set { m_bReportAggregateValue = value; }
		}

		public int DFGFloat
		{
			get { return m_iDFGFloat; }
			set { m_iDFGFloat = value; }
		}
	}
}
