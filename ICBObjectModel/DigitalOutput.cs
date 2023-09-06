using System;
using System.Collections.Generic;
using System.Text;

/*
 * CLASS SUMMARY:	DigitalOutput
 * 
 * The object used to to signal Digital Ouput (relay) statuses to the AMUEngine.
 * 
 */

namespace ICBObjectModel
{
	public class DigitalOutput
	{
		private AMUOutput m_aoAMUOutput;
		private int m_iValue;

		public DigitalOutput(AMUOutput aoAMUOutput, int iValue)
		{
			m_aoAMUOutput = aoAMUOutput;
			m_iValue = iValue;
		}

		public AMUOutput AMUOutput
		{
			get { return m_aoAMUOutput; }
			set { m_aoAMUOutput = value; }
		}

		public int Value
		{
			get { return m_iValue; }
			set { m_iValue = value; }
		}
	}
}
