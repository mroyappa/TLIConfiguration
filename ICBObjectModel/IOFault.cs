using System;
using System.Collections.Generic;
using System.Text;

/*
 * CLASS SUMMARY:	IOFault
 * 
 * The IOFault object is used to signal an IO Fault throughout the application.  An IO Fault can
 * be defined as a loss of quality communication with a device for a specified amount of time (the
 * IO Fault Timeout).
 * 
 */

namespace ICBObjectModel
{
	public class IOFault
	{
		public const int FAULT_NOTIFICATION_INTERVAL = 300000;
		//public const int FAULT_NOTIFICATION_INTERVAL = 30000;

		private string m_sIOID;
		private int m_iIOType;
		private int m_iIOAddress;
		private DateTime m_dtFaultStartTime;
		private DateTime m_dtFaultEndTime;
		private DateTime m_dtFaultAckTime;
		private DateTime m_dtLastNotificationTime;
		private bool m_bAutoAcknowledge;
		private bool m_bUseCustomFaultMessage;
		private string m_sCustomFaultMessage;

		public IOFault(string sIOID, int iIOType, int iIOAddress)
		{
			m_sIOID = sIOID;
			m_iIOType = iIOType;
			m_iIOAddress = iIOAddress;
			m_dtFaultStartTime = DateTime.Now;

			m_dtFaultEndTime = DateTime.MinValue;
			m_dtFaultAckTime = DateTime.MinValue;
			m_dtLastNotificationTime = DateTime.MinValue;

			m_bAutoAcknowledge = false;
		}

		public IOFault
		(
			string sIOID, 
			int iIOType, 
			int iIOAddress, 
			DateTime dtFaultStartTime, 
			DateTime dtFaultEndTime,
			DateTime dtFaultAckTime, 
			DateTime dtLastNotificationTime,
			bool bAutoAcknowledge,
			bool bUseCustomFaultMessage, 
			string sCustomFaultMessage
		)
		{
			m_sIOID = sIOID;
			m_iIOType = iIOType;
			m_iIOAddress = iIOAddress;
			m_dtFaultStartTime = dtFaultStartTime;
			m_dtFaultEndTime = dtFaultEndTime;
			m_dtFaultAckTime = dtFaultAckTime;
			m_dtLastNotificationTime = dtLastNotificationTime;
			m_bAutoAcknowledge = bAutoAcknowledge;
			m_bUseCustomFaultMessage = bUseCustomFaultMessage;
			m_sCustomFaultMessage = sCustomFaultMessage;
		}

		public IOFault Copy()
		{
			return new IOFault(
				m_sIOID,
				m_iIOType,
				m_iIOAddress,
				m_dtFaultStartTime,
				m_dtFaultEndTime,
				m_dtFaultAckTime,
				m_dtLastNotificationTime,
				m_bAutoAcknowledge,
				m_bUseCustomFaultMessage,
				m_sCustomFaultMessage);
		}

		public bool Report()
		{
			if (m_dtLastNotificationTime == DateTime.MinValue)
				return true;
			else if (m_dtFaultAckTime == DateTime.MinValue)
				return false;
			else if ((DateTime.Now - m_dtLastNotificationTime).TotalMilliseconds >= FAULT_NOTIFICATION_INTERVAL &&
					 (DateTime.Now - m_dtFaultAckTime).TotalMilliseconds >= FAULT_NOTIFICATION_INTERVAL)
				return true;
			else
				return false;
		}

		public bool FaultComplete()
		{
			if ((m_bAutoAcknowledge || m_dtFaultAckTime != DateTime.MinValue) && m_dtFaultEndTime != DateTime.MinValue)
				return true;
			else
				return false;
		}

		public void Notified()
		{
			m_dtLastNotificationTime = DateTime.Now;
			m_dtFaultAckTime = DateTime.MinValue;
		}

		public string IOID
		{
			get { return m_sIOID; }
			set { m_sIOID = value; }
		}

		public int IOType
		{
			get { return m_iIOType; }
			set { m_iIOType = value; }
		}

		public int IOAddress
		{
			get { return m_iIOAddress; }
			set { m_iIOAddress = value; }
		}

		public DateTime FaultStartTime
		{
			get { return m_dtFaultStartTime; }
			set { m_dtFaultStartTime = value; }
		}

		public DateTime FaultEndTime
		{
			get { return m_dtFaultEndTime; }
			set { m_dtFaultEndTime = value; }
		}

		public DateTime FaultAckTime
		{
			get { return m_dtFaultAckTime; }
			set { m_dtFaultAckTime = value; }
		}

		public DateTime LastNotificationTime
		{
			get { return m_dtLastNotificationTime; }
			set 
			{ 
				m_dtLastNotificationTime = value;
			}
		}

		public bool AutoAcknowledge
		{
			get { return m_bAutoAcknowledge; }
			set { m_bAutoAcknowledge = value; }
		}

		public bool UseCustomFaultMessage
		{
			get { return m_bUseCustomFaultMessage; }
			set { m_bUseCustomFaultMessage = value; }
		}

		public string CustomFaultMessage
		{
			get { return m_sCustomFaultMessage; }
			set { m_sCustomFaultMessage = value; }
		}
	}
}
