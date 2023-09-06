using System;
using System.Text;
using System.Collections.Generic;

/*
 * CLASS SUMMARY:	TAUInput
 * 
 * The TAUInput object is used by the GaugePoint class to define a data value
 * aquired from a TAU.
 * 
 */

namespace ICBObjectModel
{
	public class TAUInput
	{
		private bool m_bEnable;
		private int m_iTAUAddress;
		private int m_iChannelGroupType;
		private int m_iChannel;

		public TAUInput()
		{}

		public TAUInput
		(
			bool bEnable,
			int iTAUAddress,
			int iChannelGroupType,
			int iChannel
		)
		{
			m_bEnable = bEnable;
			m_iTAUAddress = iTAUAddress;
			m_iChannelGroupType = iChannelGroupType;
			m_iChannel = iChannel;
		}

		public bool Enable
		{
			get { return m_bEnable; }
			set { m_bEnable = value; }
		}

		public int TAUAddress
		{
			get { return m_iTAUAddress; }
			set { m_iTAUAddress = value; }
		}

		public int ChannelGroupType
		{
			get { return m_iChannelGroupType; }
			set { m_iChannelGroupType = value; }
		}

		public int Channel
		{
			get { return m_iChannel; }
			set { m_iChannel = value; }
		}

		public string TAUID
		{
			get { return m_iTAUAddress.ToString() + ":" + m_iChannelGroupType.ToString() + ":" + m_iChannel.ToString(); }
		}
	}
}
