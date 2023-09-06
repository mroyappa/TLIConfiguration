using System;
using System.Collections.Generic;
using System.Text;

namespace ICBObjectModel
{
	public class ModularBubblerEZT
	{
		private int m_iModularBubblerAddress;
		private int m_iChannel;
		private float m_fScaledValueHigh;
		private float m_fScaledValueLow;
		private float m_fBottomOffset;
		private float m_fSpecificGravity;
		private float m_fDisplayMax;
		private float m_fDisplayMin;
		private float m_fScaledDivisor;
		private string m_sDisplayName;
		private string m_sDisplayUnits;
		private string m_sDisplayQuotientUnits;
		private string m_sDisplayRemainderUnits;

		public ModularBubblerEZT()
		{
			m_iModularBubblerAddress = 0;
			m_iChannel = 0;
			m_fScaledValueHigh = 16.723F;
			m_fScaledValueLow = 0;
			m_fBottomOffset = 0;
			m_fSpecificGravity = 1;
			m_fDisplayMax = 16.723F;
			m_fDisplayMin = 0;
			m_fScaledDivisor = 12;
			m_sDisplayName = "tank";
			m_sDisplayUnits = "ft-in";
			m_sDisplayQuotientUnits = "ft";
			m_sDisplayRemainderUnits = "in";
		}

		public ModularBubblerEZT
		(
			int iModularBubblerAddress,
			int iChannel,
			float fScaledValueHigh,
			float fScaledValueLow,
			float fBottomOffset,
			float fSpecificGravity,
			float fDisplayMax,
			float fDisplayMin,
			float fScaledDivisor,
			string sDisplayName,
			string sDisplayUnits,
			string sDisplayQuotientUnits,
			string sDisplayRemainderUnits
		)
		{
			m_iModularBubblerAddress = iModularBubblerAddress;
			m_iChannel = iChannel;
			m_fScaledValueHigh = fScaledValueHigh;
			m_fScaledValueLow = fScaledValueLow;
			m_fBottomOffset = fBottomOffset;
			m_fSpecificGravity = fSpecificGravity;
			m_fDisplayMax = fDisplayMax;
			m_fDisplayMin = fDisplayMin;
			m_fScaledDivisor = fScaledDivisor;
			m_sDisplayName = sDisplayName;
			m_sDisplayUnits = sDisplayUnits;
			m_sDisplayQuotientUnits = sDisplayQuotientUnits;
			m_sDisplayRemainderUnits = sDisplayRemainderUnits;
		}

		public static ModularBubblerEZT CreateDefault(int iModularBubblerAddress, int iChannel)
		{
			return new ModularBubblerEZT(iModularBubblerAddress, iChannel,
				16.723F,
				0,
				0,
				1,
				16.723F,
				0,
				12,
				"Tank",
				"ft-in",
				"ft",
				"in");
		}

		public ModularBubblerEZT Copy()
		{
			return new ModularBubblerEZT(
				m_iModularBubblerAddress,
				m_iChannel,
				m_fScaledValueHigh,
				m_fScaledValueLow,
				m_fBottomOffset,
				m_fSpecificGravity,
				m_fDisplayMax,
				m_fDisplayMin,
				m_fScaledDivisor,
				m_sDisplayName,
				m_sDisplayUnits,
				m_sDisplayQuotientUnits,
				m_sDisplayRemainderUnits);
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

		public float ScaledValueHigh
		{
			get { return m_fScaledValueHigh; }
			set { m_fScaledValueHigh = value; }
		}

		public float ScaledValueLow
		{
			get { return m_fScaledValueLow; }
			set { m_fScaledValueLow = value; }
		}

		public float BottomOffset
		{
			get { return m_fBottomOffset; }
			set { m_fBottomOffset = value; }
		}

		public float SpecificGravity
		{
			get { return m_fSpecificGravity; }
			set { m_fSpecificGravity = value; }
		}

		public float DisplayMax
		{
			get { return m_fDisplayMax; }
			set { m_fDisplayMax = value; }
		}

		public float DisplayMin
		{
			get { return m_fDisplayMin; }
			set { m_fDisplayMin = value; }
		}

		public float ScaledDivisor
		{
			get { return m_fScaledDivisor; }
			set { m_fScaledDivisor = value; }
		}

		public string DisplayName
		{
			get { return m_sDisplayName; }
			set { m_sDisplayName = value; }
		}

		public string DisplayUnits
		{
			get { return m_sDisplayUnits; }
			set { m_sDisplayUnits = value; }
		}

		public string DisplayQuotientUnits
		{
			get { return m_sDisplayQuotientUnits; }
			set { m_sDisplayQuotientUnits = value; }
		}

		public string DisplayRemainderUnits
		{
			get { return m_sDisplayRemainderUnits; }
			set { m_sDisplayRemainderUnits = value; }
		}
	}
}
