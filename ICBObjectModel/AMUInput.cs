using System;
using System.Collections.Generic;
using System.Text;

/*
 * CLASS SUMMARY:	AMUInput
 * 
 * The AMUInput object is used by the GaugePoint class to define a data value
 * aquired from an AMU.  This class defines the AMU Address and Channel.
 * 
 */

namespace ICBObjectModel
{
	public class AMUInput
	{
		private bool m_bEnable;
		private int m_iAMUAddress;
		private int m_iChannel;
		private bool m_bAnalogChannel;

		public AMUInput()
		{
		}

		public AMUInput(bool bEnable, int iAMUAddress, int iChannel, bool bAnalogChannel)
		{
			m_bEnable = bEnable;
			m_iAMUAddress = iAMUAddress;
			m_iChannel = iChannel;
			m_bAnalogChannel = bAnalogChannel;
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

		public int Channel
		{
			get { return m_iChannel; }
			set { m_iChannel = value; }
		}
		
		public bool AnalogChannel
		{
			get { return m_bAnalogChannel; }
			set { m_bAnalogChannel = value; }
		}
		
		[System.Xml.Serialization.XmlIgnore]
		public string AMUID
		{
			get { return m_iAMUAddress.ToString() + ":" + m_iChannel.ToString(); }
		}
	}
}
