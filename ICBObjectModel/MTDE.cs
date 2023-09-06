using System;
using System.Text;
using System.Collections.Generic;

#if WINXP
using System.ComponentModel;
#endif

/*
 * CLASS SUMMARY:	MTDE
 * 
 * The MTDE class is used to enumerate MTDE addresses associated with a configuration.
 * 
 */

namespace ICBObjectModel
{
	public class MTDE
	{
		private int m_iMTDEAddress;
		private string m_sDescription;

		public MTDE()
		{
		}

		public MTDE(int iMTDEAddress, string sDescription)
		{
			m_iMTDEAddress = iMTDEAddress;
			m_sDescription = sDescription;
		}

#if WINXP
		[Category("MTDE"), DisplayName("Address"), Description("MTDE address.")]
#endif
		public int MTDEAddress
		{
			get { return m_iMTDEAddress; }
			set { m_iMTDEAddress = value; }
		}

#if WINXP
		[Category("MTDE")]
#endif
		public string Description
		{
			get { return m_sDescription; }
			set { m_sDescription = value; }
		}
	}
}
