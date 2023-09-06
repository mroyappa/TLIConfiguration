using System;
using System.Collections.Generic;
using System.Text;

/*
 * CLASS SUMMARY:	RedundantSequenceNumber
 * 
 * This is a helper class which is used when a redundant Export Order is identified.
 * 
 */

namespace TLIConfiguration
{
	public class RedundantSequenceNumber
	{
		private string m_sEquipmentID;
		private string m_sEquipmentUnitDisplayName;
		private int m_iSequenceNumber;

		public RedundantSequenceNumber
		(
			string sEquipmentID,
			string sEquipmentUnitDisplayName,
			int iSequenceNumber
		)
		{
			m_sEquipmentID = sEquipmentID;
			m_sEquipmentUnitDisplayName = sEquipmentUnitDisplayName;
			m_iSequenceNumber = iSequenceNumber;
		}

		public string EquipmentID
		{
			get { return m_sEquipmentID; }
			set { m_sEquipmentID = value; }
		}

		public string EquipmentUnitDisplayName
		{
			get { return m_sEquipmentUnitDisplayName; }
			set { m_sEquipmentUnitDisplayName = value; }
		}

		public int SequenceNumber
		{
			get { return m_iSequenceNumber; }
			set { m_iSequenceNumber = value; }
		}
	}
}
