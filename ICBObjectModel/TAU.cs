using System;
using System.Collections.Generic;
using System.Text;

/*
 * CLASS SUMMARY:	TAU
 * 
 * TAU class used to define TAUs configued for a Vessel.  This class contains members
 * for TAU Address and device description.
 * 
 */

namespace ICBObjectModel
{
	public class TAU
	{
		private int m_iTAUAddress;
		private string m_sDescription;

		public TAU()
		{}

		public TAU(int iTAUAddress, string sDescription)
		{
			m_iTAUAddress = iTAUAddress;
			m_sDescription = sDescription;
		}

		public int TAUAddress
		{
			get { return m_iTAUAddress; }
			set { m_iTAUAddress = value; }
		}

		public string Description
		{
			get { return m_sDescription; }
			set { m_sDescription = value; }
		}
	}
}
