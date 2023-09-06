using System;
using System.Collections.Generic;
using System.Text;

/*
 * CLASS SUMMARY:	IOProcessValue
 * 
 * IOProcessValue is the primary object used to pass gauge values throughout the application.  The
 * ProcessID member is the one unique value used to descrbe individual GaugePoints and is thus used
 * to uniquely identify each value.
 * 
 */

namespace ICBObjectModel
{
	public class IOProcessValue
	{
		private string m_sProcessID;
		private string m_sEquipmentID;
		private string m_sEquipment;
		private string m_sEquipmentLocation;
		private int m_iEquipmentType;
		private int m_iGaugeType;
		private int m_iGaugeNumber;
		private bool m_bAnalogChannel;
		private byte m_bChannelState;
		private float m_fValue;		// Primary value
		private int m_iUnits;
		private float m_fValue2;	// Secondary value (i.e. Sounding)
		private int m_iUnits2;
		private int m_iIOType;
		private int m_iIOAddress;
		private int m_iIOChannelGroupType;
		private int m_iIOChannel;

		public IOProcessValue
		(
			string sProcessID, 
			string sEquipmentID,
			string sEquipment,
			string sEquipmentLocation,
			int iEquipmentType,
			int iGaugeType,
			int iGaugeNumber,
			bool bAnalogChannel, 
			byte bChannelState, 
			float fValue, 
			int iUnits,
			float fValue2,
			int iUnits2,
			int iIOType,
			int iIOAddress,
			int iIOChannelGroupType,
			int iIOChannel
		)
		{
			m_sProcessID = sProcessID;
			m_sEquipmentID = sEquipmentID;
			m_sEquipment = sEquipment;
			m_sEquipmentLocation = sEquipmentLocation;
			m_iEquipmentType = iEquipmentType;
			m_iGaugeType = iGaugeType;
			m_iGaugeNumber = iGaugeNumber;
			m_bAnalogChannel = bAnalogChannel;
			m_bChannelState = bChannelState;
			m_fValue = fValue;
			m_iUnits = iUnits;
			m_fValue2 = fValue2;
			m_iUnits2 = iUnits2;
			m_iIOType = iIOType;
			m_iIOAddress = iIOAddress;
			m_iIOChannelGroupType = iIOChannelGroupType;
			m_iIOChannel = iIOChannel;
		}

		public IOProcessValue Copy()
		{
			IOProcessValue iopv = 
				new IOProcessValue
				(
					m_sProcessID,
					m_sEquipmentID,
					m_sEquipment,
					m_sEquipmentLocation,
					m_iEquipmentType,
					m_iGaugeType,
					m_iGaugeNumber,
					m_bAnalogChannel, 
					m_bChannelState, 
					m_fValue, 
					m_iUnits,
					m_fValue2,
					m_iUnits2,
					m_iIOType,
					m_iIOAddress,
					m_iIOChannelGroupType,
					m_iIOChannel
				);

			return iopv;
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

		public bool AnalogChannel
		{
			get { return m_bAnalogChannel; }
			set { m_bAnalogChannel = value; }
		}

		public byte ChannelState
		{
			get { return m_bChannelState; }
			set { m_bChannelState = value; }
		}

		public float Value
		{
			get { return m_fValue; }
			set { m_fValue = value; }
		}

		public int Units
		{
			get { return m_iUnits; }
			set { m_iUnits = value; }
		}

		public float Value2
		{
			get { return m_fValue2; }
			set { m_fValue2 = value; }
		}

		public int Units2
		{
			get { return m_iUnits2; }
			set { m_iUnits2 = value; }
		}

		public int IOType
		{
			get { return m_iIOType; }
		}

		public int IOAddress
		{
			get { return m_iIOAddress; }
		}

		public int IOChannelGroupType
		{
			get { return m_iIOChannelGroupType; }
		}

		public int IOChannel
		{
			get { return m_iIOChannel; }
		}
	}
}
