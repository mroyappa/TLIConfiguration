using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;

/*
 * CLASS SUMMARY:	AMU
 * 
 * AMU class used to define AMUs configued for a Vessel.  This class contains members
 * for AMU Address as well as Serial Bus (TLIRuntime can handle multiple AMUs on multiple
 * serial ports).
 * 
 */

namespace ICBObjectModel
{
	public class AMU
	{
		private int m_iAMUAddress;
		private char m_cSerialBus;
		private string m_sDescription;

		public AMU()
		{
		}

		public AMU(int iAMUAddress, char cSerialBus, string sDescription)
		{
			m_iAMUAddress = iAMUAddress;
			m_cSerialBus = cSerialBus;
			m_sDescription = sDescription;
		}

#if !WindowsCE
		[Category("AMU"), DisplayName("Address"), Description("AMU address.")]
#endif
		public int AMUAddress
		{
			get { return m_iAMUAddress; }
			set { m_iAMUAddress = value; }
		}

		public char SerialBus
		{
			get { return m_cSerialBus; }
			set { m_cSerialBus = value; }
		}
#if !WindowsCE
		[Category("AMU")]
#endif
		public string Description
		{
			get { return m_sDescription; }
			set { m_sDescription = value; }
		}
	}
}
