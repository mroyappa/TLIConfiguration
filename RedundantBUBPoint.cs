using System;
using System.Collections.Generic;
using System.Text;

/*
 * CLASS SUMMARY:	RedundantBUBPoint
 * 
 * This is a helper class which is used when a redundant BUB point is identified.
 * 
 */

namespace TLIConfiguration
{

	public class RedundantBUBPoint
	{
		private string m_sProcessID;
		private string m_sEquipmentUnitDisplayName;
		private string m_sGaugePointDisplayName;
		private int m_iBUBAddress;
		private int m_iBUBChannel;

		public RedundantBUBPoint
		(
			string sProcessID,
			string sEquipmentUnitDisplayName,
			string sGaugePointDisplayName,
			int iBUBAddress,
			int iBUBChannel
		)
		{
			m_sProcessID = sProcessID;
			m_sEquipmentUnitDisplayName = sEquipmentUnitDisplayName;
			m_sGaugePointDisplayName = sGaugePointDisplayName;
			m_iBUBAddress = iBUBAddress;
			m_iBUBChannel = iBUBChannel;
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

		public int BUBAddress
		{
			get { return m_iBUBAddress; }
		}

		public int BUBChannel
		{
			get { return m_iBUBChannel; }
		}
	}
}
