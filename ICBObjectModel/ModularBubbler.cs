using System;
using System.Collections.Generic;
using System.Text;

namespace ICBObjectModel
{
	public class ModularBubbler
	{
		private int m_iModularBubblerAddress;
		private string m_sDescription;
		private ushort m_iSyncTimeHigh;
		private ushort m_iSyncTimeLow;

		public ModularBubbler()
		{ }

		public ModularBubbler(int iModularBubblerAddress, string sDescription, ushort iSyncTimeHigh, ushort iSyncTimeLow)
		{
			m_iModularBubblerAddress = iModularBubblerAddress;
			m_sDescription = sDescription;
			m_iSyncTimeHigh = iSyncTimeHigh;
			m_iSyncTimeLow = iSyncTimeLow;
		}

		public int ModularBubblerAddress
		{
			get { return m_iModularBubblerAddress; }
			set { m_iModularBubblerAddress = value; }
		}

		public string Description
		{
			get { return m_sDescription; }
			set { m_sDescription = value; }
		}

		public ushort SyncTimeHigh
		{
			get { return m_iSyncTimeHigh; }
			set { m_iSyncTimeHigh = value; }
		}

		public ushort SyncTimeLow
		{
			get { return m_iSyncTimeLow; }
			set { m_iSyncTimeLow = value; }
		}
	}
}