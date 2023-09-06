using System;
using System.Collections.Generic;
using System.Text;

/*
 * CLASS SUMMARY:	RedundantModbusPoint
 * 
 * This is a helper class which is used when a redundant Modbus Input point is identified.
 * 
 */

namespace TLIConfiguration
{
	public class RedundantModbusPoint
	{
		private string m_sProcessID;
		private string m_sEquipmentType;
		private string m_sEquipmentName;
		private string m_sGaugeType;
		private string m_sAlarmText;
		private bool m_bAlarm;
		private ushort m_iRegister1;
		private ushort m_iRegister2;

		public RedundantModbusPoint
		(
			string sProcessID,
			string sEquipmentType,
			string sEquipmentName,
			string sGaugeType,
			string sAlarmText,
			bool bAlarm,
			ushort iRegister1,
			ushort iRegister2
		)
		{
			m_sProcessID = sProcessID;
			m_sEquipmentType = sEquipmentType;
			m_sEquipmentName = sEquipmentName;
			m_sGaugeType = sGaugeType;
			m_sAlarmText = sAlarmText;
			m_bAlarm = bAlarm;
			m_iRegister1 = iRegister1;
			m_iRegister2 = iRegister2;
		}

		public string ProcessID
		{
			get { return m_sProcessID; }
			set { m_sProcessID = value; }
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

		public string AlarmText
		{
			get { return m_sAlarmText; }
			set { m_sAlarmText = value; }
		}

		public bool Alarm
		{
			get { return m_bAlarm; }
			set { m_bAlarm = value; }
		}

		public ushort Register1
		{
			get { return m_iRegister1; }
			set { m_iRegister1 = value; }
		}

		public ushort Register2
		{
			get { return m_iRegister2; }
			set { m_iRegister2 = value; }
		}
	}
}
