using System;
using System.Text;
using ICBObjectModel.Enumerations;

/*
 * CLASS SUMMARY:	AlarmInstance
 * 
 * The AlarmInstance class is used to represent active alarms.  The instance class contains members
 * which detail the AlarmInstance Start, End, and Ack time (if occured) as well as the AlarmPoint,
 * ProcessID, and EquipmentUnit that the AlarmInstance was created.
 * 
 */

namespace ICBObjectModel
{
	public class AlarmInstance
	{
		private Guid m_guidAlarmInstanceID;
		private AlarmPoint m_apAlarmPoint;
		private string m_sProcessID;
		private string m_sEquipmentID;
		private float m_fProcessValue;
		private DateTime m_dtAlarmStartTime;
		private DateTime m_dtAlarmEndTime;
		private DateTime m_dtAlarmAckTime;

		public AlarmInstance
		(
			Guid guidAlarmInstanceID,
			AlarmPoint apAlarmPoint,
			string sProcessID,
			string sEquipmentID,
			float fProcessValue,
			DateTime dtAlarmStartTime
		)
			: this(guidAlarmInstanceID, apAlarmPoint, sProcessID, sEquipmentID, fProcessValue, dtAlarmStartTime, NullValue.DateTimeNull, NullValue.DateTimeNull) { }
		public AlarmInstance
		(
			Guid guidAlarmInstanceID,
			AlarmPoint apAlarmPoint,
			string sProcessID,
			string sEquipmentID,
			float fProcessValue,
			DateTime dtAlarmStartTime,
			DateTime dtAlarmEndTime,
			DateTime dtAlarmAckTime
		)
		{
			m_guidAlarmInstanceID = guidAlarmInstanceID;
			m_apAlarmPoint = apAlarmPoint;
			m_sProcessID = sProcessID;
			m_sEquipmentID = sEquipmentID;
			m_fProcessValue = fProcessValue;
			m_dtAlarmStartTime = dtAlarmStartTime;
			m_dtAlarmEndTime = dtAlarmEndTime;
			m_dtAlarmAckTime = dtAlarmAckTime;
		}

		public string AlarmInstancePriorityKey()
		{
			return m_apAlarmPoint.AlarmPriority.ToString() + " : " + m_dtAlarmStartTime.ToString() + " : " + m_guidAlarmInstanceID.ToString();
		}

		public static string AlarmInstanceIDFromAlarmInstancePriorityKey(string sAlarmInstancePriorityKey)
		{
			try
			{
				string[] sParse;
				sParse = sAlarmInstancePriorityKey.Split(new char[] { ':' });
				return sParse[4].Trim();
			}
			catch
			{
				return "";
			}
		}

		public AlarmInstance Copy()
		{
			return new AlarmInstance(
				m_guidAlarmInstanceID,
				m_apAlarmPoint,
				m_sProcessID,
				m_sEquipmentID,
				m_fProcessValue,
				m_dtAlarmStartTime,
				m_dtAlarmEndTime,
				m_dtAlarmAckTime);
		}

		public bool AlarmAcknowledged
		{
			get { return m_dtAlarmAckTime != NullValue.DateTimeNull; }
		}

		public bool AlarmEnded
		{
			get { return m_dtAlarmEndTime != NullValue.DateTimeNull; }
		}

		public Guid AlarmInstanceID
		{
			get { return m_guidAlarmInstanceID; }
			set { m_guidAlarmInstanceID = value; }
		}

		public AlarmPoint AlarmPoint
		{
			get { return m_apAlarmPoint; }
			set { m_apAlarmPoint = value; }
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

		public float ProcessValue
		{
			get { return m_fProcessValue; }
			set { m_fProcessValue = value; }
		}

		public DateTime AlarmStartTime
		{
			get { return m_dtAlarmStartTime; }
			set { m_dtAlarmStartTime = value; }
		}

		public DateTime AlarmEndTime
		{
			get { return m_dtAlarmEndTime; }
			set { m_dtAlarmEndTime = value; }
		}

		public DateTime AlarmAckTime
		{
			get { return m_dtAlarmAckTime; }
			set { m_dtAlarmAckTime = value; }
		}
	}
}
