using System;
using System.Collections.Generic;
using System.Text;

/*
 * CLASS SUMMARY:	IOErrorCount
 * 
 * IOErrorCount is a generic object used by all of the IO Engines (AMUEngine, TAUEngine, etc.) which
 * keeps count of varying error conditions for individual IO devices.
 * 
 */

namespace ICBObjectModel
{
	public class IOErrorCount
	{
		private string m_sAddress;
		private int m_iTimeouts;
		private int m_iBadCheckSums;
		private int m_iPartialMessage;

		public IOErrorCount()
		{
			m_sAddress = "0";
			m_iTimeouts = 0;
			m_iBadCheckSums = 0;
			m_iPartialMessage = 0;
		}

		public IOErrorCount(string sAddress)
		{
			m_sAddress = sAddress;
			m_iTimeouts = 0;
			m_iBadCheckSums = 0;
			m_iPartialMessage = 0;
		}

		public IOErrorCount(string sAddress, int iTimeouts, int iBadCheckSums, int iPartialMessage)
		{
			m_sAddress = sAddress;
			m_iTimeouts = iTimeouts;
			m_iBadCheckSums = iBadCheckSums;
			m_iPartialMessage = iPartialMessage;
		}

		public IOErrorCount Copy()
		{
			return new IOErrorCount(m_sAddress, m_iTimeouts, m_iBadCheckSums, m_iPartialMessage);
		}

		public string Address
		{
			get { return m_sAddress; }
			set { m_sAddress = value; }
		}

		public int Timeouts
		{
			get { return m_iTimeouts; }
			set { m_iTimeouts = value; }
		}

		public int BadCheckSums
		{
			get { return m_iBadCheckSums; }
			set { m_iBadCheckSums = value; }
		}

		public int PartialMessage
		{
			get { return m_iPartialMessage; }
			set { m_iPartialMessage = value; }
		}
	}
}
