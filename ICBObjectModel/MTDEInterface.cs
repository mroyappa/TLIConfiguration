using System;
using System.Collections.Generic;
using System.Text;

/*
 * CLASS SUMMARY:	MTDEInterface
 * 
 * The MTDEInterface object is used to configure an EquipmentUnit for display on an MTDE.  This object
 * defines the name to be used on the MTDE, display order and tank type.
 * 
 */

namespace ICBObjectModel
{
	public class MTDEInterface
	{
		private bool m_bEnable;
		private int m_iMTDEName;
		private int m_iMTDEOrder;
		private bool m_bFuelTank;

		public MTDEInterface()
		{
		}

		public MTDEInterface(bool bEnable, int iMTDEName, int iMTDEOrder, bool bFuelTank)
		{
			m_bEnable = bEnable;
			m_iMTDEName = iMTDEName;
			m_iMTDEOrder = iMTDEOrder;
			m_bFuelTank = bFuelTank;
		}

		public bool Enable
		{
			get { return m_bEnable; }
			set { m_bEnable = value; }
		}

		public int MTDEName
		{
			get { return m_iMTDEName; }
			set { m_iMTDEName = value; }
		}

		public int MTDEOrder
		{
			get { return m_iMTDEOrder; }
			set { m_iMTDEOrder = value; }
		}

		public bool FuelTank
		{
			get { return m_bFuelTank; }
			set { m_bFuelTank = value; }
		}
	}
}
