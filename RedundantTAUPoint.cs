using System;
using System.Collections.Generic;
using System.Text;

/*
 * CLASS SUMMARY:	RedundantTAUPoint
 * 
 * This is a helper class which is used when a redundant TAU point is identified.
 * 
 */

namespace TLIConfiguration
{
	public class RedundantTAUPoint
	{
		private string m_sProcessID;
		private string m_sEquipmentUnitDisplayName;
		private string m_sGaugePointDisplayName;
		private int m_iTAUAddress;
		private int m_iTAUChannelType;
		private int m_iTAUChannel;

		public RedundantTAUPoint
		(
			string sProcessID,
			string sEquipmentUnitDisplayName,
			string sGaugePointDisplayName,
			int iTAUAddress,
			int iTAUChannelType,
			int iTAUChannel
		)
		{
			m_sProcessID = sProcessID;
			m_sEquipmentUnitDisplayName = sEquipmentUnitDisplayName;
			m_sGaugePointDisplayName = sGaugePointDisplayName;
			m_iTAUAddress = iTAUAddress;
			m_iTAUChannelType = iTAUChannelType;
			m_iTAUChannel = iTAUChannel;
		}

		public string ProcessID
		{
			get { return m_sProcessID; }
		}

		public string EquipmentUnitDisplayName
		{
			get { return m_sEquipmentUnitDisplayName; }
		}

		public string GaugePointDisplayName
		{
			get { return m_sGaugePointDisplayName; }
		}

		public int TAUAddress
		{
			get { return m_iTAUAddress; }
		}

		public int TAUChannelType
		{
			get { return m_iTAUChannelType; }
		}

		public int TAUChannel
		{
			get { return m_iTAUChannel; }
		}
	}
}
