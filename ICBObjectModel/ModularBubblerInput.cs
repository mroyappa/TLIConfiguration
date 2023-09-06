using System;
using System.Text;
using System.Collections.Generic;

/*
 * CLASS SUMMARY:	ModularBubblerInput
 * 
 * The ModularBubblerInput object is used by the GaugePoint class to define a data value
 * aquired from a Modular Bubbler.
 * 
 */

namespace ICBObjectModel
{
	public class ModularBubblerInput
	{
		private bool m_bEnable;
		private int m_iModularBubblerAddress;
		private int m_iChannel;
		private bool m_bSecondaryChannelEnable;
		private int m_iSecondaryChannel;

		public ModularBubblerInput()
		{}

		public ModularBubblerInput
		(
			bool bEnable,
			int iModularBubblerAddress,
			int iChannel,
			bool bSecondaryChannelEnable,
			int iSecondaryChannel
		)
		{
			m_bEnable = bEnable;
			m_iModularBubblerAddress = iModularBubblerAddress;
			m_iChannel = iChannel;
			m_bSecondaryChannelEnable = bSecondaryChannelEnable;
			m_iSecondaryChannel = iSecondaryChannel;
		}

		public bool Enable
		{
			get { return m_bEnable; }
			set { m_bEnable = value; }
		}

		public int ModularBubblerAddress
		{
			get { return m_iModularBubblerAddress; }
			set { m_iModularBubblerAddress = value; }
		}

		public int Channel
		{
			get { return m_iChannel; }
			set { m_iChannel = value; }
		}

		public bool SecondaryChannelEnable
		{
			get { return m_bSecondaryChannelEnable; }
			set { m_bSecondaryChannelEnable = value; }
		}

		public int SecondaryChannel
		{
			get { return m_iSecondaryChannel; }
			set { m_iSecondaryChannel = value; }
		}

		public string BUBID
		{
			get { return m_iModularBubblerAddress.ToString() + ":" + m_iChannel.ToString(); }
		}

		public string SECONDARY_BUBID
		{
			get { return m_iModularBubblerAddress.ToString() + ":" + m_iSecondaryChannel.ToString(); }
		}
	}
}
