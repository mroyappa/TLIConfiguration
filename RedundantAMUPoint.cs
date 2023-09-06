using System;
using System.Collections.Generic;
using System.Text;

/*
 * CLASS SUMMARY:	RedundantAMUPoint
 * 
 * This is a helper class which is used when a redundant AMU point is identified.
 * 
 */

namespace TLIConfiguration
{

	public class RedundantAMUPoint
	{
		private string m_sProcessID;
		private string m_sEquipmentUnitDisplayName;
		private string m_sGaugePointDisplayName;
		private int m_iAMUAddress;
		private int m_iAMUChannel;

		public RedundantAMUPoint
		(
			string sProcessID,
			string sEquipmentUnitDisplayName,
			string sGaugePointDisplayName,
			int iAMUAddress,
			int iAMUChannel
		)
		{
			m_sProcessID = sProcessID;
			m_sEquipmentUnitDisplayName = sEquipmentUnitDisplayName;
			m_sGaugePointDisplayName = sGaugePointDisplayName;
			m_iAMUAddress = iAMUAddress;
			m_iAMUChannel = iAMUChannel;
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

		public int AMUAddress
		{
			get { return m_iAMUAddress; }
		}

		public int AMUChannel
		{
			get { return m_iAMUChannel; }
		}
	}
}
