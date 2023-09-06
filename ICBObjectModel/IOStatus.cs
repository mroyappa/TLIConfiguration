using System;
using System.Collections.Generic;
using System.Text;

/*
 * CLASS SUMMARY:	IOStatus
 * 
 * IOStatus is an object used by the device engines (AMUEngine, TAUEngine, etc.) to determine
 * the status of individual IO devices.  The object provides members/methods to record when the
 * last good read/write occured and whether or not the device is in a fault condition.
 * 
 */

namespace ICBObjectModel
{
	public class IOStatus
	{
		private string m_sIOID;
		private int m_iIOType;
		private int m_iIOAddress;
		private DateTime m_dtLastRead;
		private bool m_bFault;

		public IOStatus()
		{
			m_dtLastRead = DateTime.Now;
			m_bFault = false;
		}

		public IOStatus(string sIOID, int iIOType, int iIOAddress)
		{
			m_sIOID = sIOID;
			m_iIOType = iIOType;
			m_iIOAddress = iIOAddress;

			m_dtLastRead = DateTime.Now;
			m_bFault = false;
		}

		public IOStatus(string sIOID, int iIOType, int iIOAddress, bool bFault)
		{
			m_sIOID = sIOID;
			m_iIOType = iIOType;
			m_iIOAddress = iIOAddress;
			m_bFault = bFault;
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

		public DateTime LastRead
		{
			get { return m_dtLastRead; }
			set { m_dtLastRead = value; }
		}

		public bool Fault
		{
			get { return m_bFault; }
			set { m_bFault = value; }
		}
	}
}
