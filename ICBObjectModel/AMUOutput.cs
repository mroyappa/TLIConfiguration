using System;
using System.Collections.Generic;
using System.Text;

/*
 * CLASS SUMMARY:	AMUOutput
 * 
 * The AMUOutput class is used by the AlarmAnnunciation class to define the AMU Address
 * and Digital Output channel used when an alarm Annunciation is needed. 
 * 
 */

namespace ICBObjectModel
{
	public class AMUOutput
	{
		private bool m_bEnable;
		private int m_iAMUAddress;
		private int m_iDigitalOutput;

		public AMUOutput()
		{
		}

		public AMUOutput(bool bEnable, int iAMUAddress, int iDigitalOutput)
		{
			m_bEnable = bEnable;
			m_iAMUAddress = iAMUAddress;
			m_iDigitalOutput = iDigitalOutput;
		}

		public AMUOutput Copy()
		{
			return new AMUOutput(m_bEnable, m_iAMUAddress, m_iDigitalOutput);
		}

		public bool Enable
		{
			get { return m_bEnable; }
			set { m_bEnable = value; }
		}

		public int AMUAddress
		{
			get { return m_iAMUAddress; }
			set { m_iAMUAddress = value; }
		}

		public int DigitalOutput
		{
			get { return m_iDigitalOutput; }
			set { m_iDigitalOutput = value; }
		}
	}
}
