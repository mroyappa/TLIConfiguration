using System;
using System.Text;
using System.Collections.Generic;

/*
 * CLASS SUMMARY:	SCU
 * 
 * The SCU class is used to manage SCU configuration parameters.
 * 
 */

namespace ICBObjectModel
{
	public class SCU
	{
		private int m_iTAUAddress;
		private int m_iSCUChannel;
		private float m_fLF;
		private	float m_fUllageHatch;
		private byte m_bConfig1;
		private	byte m_bConfig2;
		private byte m_bConfig3;
		private	byte m_bConfig4;
		private float m_fBottomOffset;
		private	float m_fTopFloatOffset;
		private float m_fBottomFloatOffset;
		private	float m_fDensityOffset;	
		private string m_sTopFloatName;
		private string m_sBottomFloatName;
		private string m_sTankName;
		private float m_fAutoZeroRange;
		private int m_iAutoZeroTimeout;
		private float m_fVolatileDensityOffset;

		public SCU()
		{}

		public SCU
		(
			int iTAUAddress,
			int iSCUChannel,
			float fLF,
			float fUllageHatch,
			byte bConfig1,
			byte bConfig2,
			byte bConfig3,
			byte bConfig4,
			float fBottomOffset,
			float fTopFloatOffset,
			float fBottomFloatOffset,
			float fDensityOffset,
			string sTopFloatName,
			string sBottomFloatName,
			string sTanksName,
			float fAutoZeroRange,
			int iAutoZeroTimeout,
			float fVolatileDensityOffset
		)
		{
			m_iTAUAddress = iTAUAddress;
			m_iSCUChannel = iSCUChannel;
			m_fLF = fLF;
			m_fUllageHatch = fUllageHatch;
			m_bConfig1 = bConfig1;
			m_bConfig2 = bConfig2;
			m_bConfig3 = bConfig3;
			m_bConfig4 = bConfig4;
			m_fBottomOffset = fBottomOffset;
			m_fTopFloatOffset = fTopFloatOffset;
			m_fBottomFloatOffset = fBottomFloatOffset;
			m_fDensityOffset = fDensityOffset;
			m_sTopFloatName = sTopFloatName;
			m_sBottomFloatName = sBottomFloatName;
			m_sTankName = sTanksName;
			m_fAutoZeroRange = fAutoZeroRange;
			m_iAutoZeroTimeout = iAutoZeroTimeout;
			m_fVolatileDensityOffset = fVolatileDensityOffset;
		}

		public int TAUAddress
		{
			get { return m_iTAUAddress; }
			set { m_iTAUAddress = value; }
		}

		public int SCUChannel
		{
			get { return m_iSCUChannel; }
			set { m_iSCUChannel = value; }
		}

		public float LF
		{
			get { return m_fLF; }
			set { m_fLF = value; }
		}

		public float UllageHatch
		{
			get { return m_fUllageHatch; }
			set { m_fUllageHatch = value; }
		}

		public byte Config1
		{
			get { return m_bConfig1; }
			set { m_bConfig1 = value; }
		}

		public byte Config2
		{
			get { return m_bConfig2; }
			set { m_bConfig2 = value; }
		}

		public byte Config3
		{
			get { return m_bConfig3; }
			set { m_bConfig3 = value; }
		}

		public byte Config4
		{
			get { return m_bConfig4; }
			set { m_bConfig4 = value; }
		}

		public float BottomOffset
		{
			get { return m_fBottomOffset; }
			set { m_fBottomOffset = value; }
		}

		public float BottomFloatOffset
		{
			get { return m_fBottomFloatOffset; }
			set { m_fBottomFloatOffset = value; }
		}

		public float TopFloatOffset
		{
			get { return m_fTopFloatOffset; }
			set { m_fTopFloatOffset = value; }
		}

		public float DensityOffset
		{
			get { return m_fDensityOffset; }
			set { m_fDensityOffset = value; }
		}

		public string TopFloatName
		{
			get { return m_sTopFloatName; }
			set { m_sTopFloatName = value; }
		}

		public string BottomFloatName
		{
			get { return m_sBottomFloatName; }
			set { m_sBottomFloatName = value; }
		}

		public string TankName
		{
			get { return m_sTankName; }
			set { m_sTankName = value; }
		}

		public float AutoZeroRange
		{
			get { return m_fAutoZeroRange; }
			set { m_fAutoZeroRange = value; }
		}

		public int AutoZeroTimeout
		{
			get { return m_iAutoZeroTimeout; }
			set { m_iAutoZeroTimeout = value; }
		}

		public float VolatileDensityOffset
		{
			get { return m_fVolatileDensityOffset; }
			set { m_fVolatileDensityOffset = value; }
		}
	}
}
