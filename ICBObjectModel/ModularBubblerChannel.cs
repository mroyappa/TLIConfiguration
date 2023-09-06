using System;
using System.Collections.Generic;
using System.Text;

namespace ICBObjectModel
{
	public class ModularBubblerChannel
	{
		private int m_iModularBubblerAddress;
		private int m_iChannel;
		private string m_sBoardType;
		private ushort[] m_Time;
		private bool[] m_PurgeValve;
		private bool[] m_TankValve;
		private bool[] m_Measure;
		private bool[] m_ReadSensor;

		public ModularBubblerChannel()
		{
			m_iModularBubblerAddress = 0;
			m_iChannel = 0;
			m_sBoardType = "";
			m_Time = new ushort[8];
			m_PurgeValve = new bool[8];
			m_TankValve = new bool[8];
			m_Measure = new bool[8];
			m_ReadSensor = new bool[8];
		}

		public ModularBubblerChannel
		(
			int iModularBubblerAddress,
			int iChannel,
			string sBoardType,
			ushort[] time,
			bool[] purgeValve,
			bool[] tankValve,
			bool[] measure,
			bool[] readSensor
		)
		{
			m_Time = new ushort[8];
			m_PurgeValve = new bool[8];
			m_TankValve = new bool[8];
			m_Measure = new bool[8];
			m_ReadSensor = new bool[8];

			m_iModularBubblerAddress = iModularBubblerAddress;
			m_iChannel = iChannel;
			m_sBoardType = sBoardType;
			time.CopyTo(m_Time, 0);
			purgeValve.CopyTo(m_PurgeValve, 0);
			tankValve.CopyTo(m_TankValve, 0);
			measure.CopyTo(m_Measure, 0);
			readSensor.CopyTo(m_ReadSensor, 0);
		}

		public ModularBubblerChannel Copy()
		{
			ushort[] time = new ushort[8];
			bool[] purgeValve = new bool[8];
			bool[] tankValve = new bool[8];
			bool[] measure = new bool[8];
			bool[] readSensor = new bool[8];

			m_Time.CopyTo(time, 0);
			m_PurgeValve.CopyTo(purgeValve, 0);
			m_TankValve.CopyTo(tankValve, 0);
			m_Measure.CopyTo(measure, 0);
			m_ReadSensor.CopyTo(readSensor, 0);

			return new ModularBubblerChannel(
				m_iModularBubblerAddress,
				m_iChannel,
				m_sBoardType,
				time,
				purgeValve,
				tankValve,
				measure,
				readSensor);
		}

		public static ModularBubblerChannel CreateDefaultChannel(int iModularBubblerAddress, int iChannel)
		{
			ushort[] time = new ushort[8];
			bool[] purgeValve = new bool[8];
			bool[] tankValve = new bool[8];
			bool[] measure = new bool[8];
			bool[] readSensor = new bool[8];

			time[0] = 0;
			time[1] = 100;
			time[2] = 300;
			time[3] = 1000;
			time[4] = 1050;
			time[5] = 1700;
			time[6] = 2000;
			time[7] = 0;

			purgeValve[0] = true;
			purgeValve[1] = true;
			purgeValve[2] = false;
			purgeValve[3] = true;
			purgeValve[4] = false;
			purgeValve[5] = false;
			purgeValve[6] = false;
			purgeValve[7] = false;

			tankValve[0] = false;
			tankValve[1] = true;
			tankValve[2] = true;
			tankValve[3] = false;
			tankValve[4] = true;
			tankValve[5] = true;
			tankValve[6] = false;
			tankValve[7] = false;

			measure[0] = false;
			measure[1] = false;
			measure[2] = false;
			measure[3] = true;
			measure[4] = true;
			measure[5] = true;
			measure[6] = false;
			measure[7] = false;

			readSensor[0] = false;
			readSensor[1] = false;
			readSensor[2] = false;
			readSensor[3] = false;
			readSensor[4] = false;
			readSensor[5] = true;
			readSensor[6] = false;
			readSensor[7] = false;

			return new ModularBubblerChannel(
				iModularBubblerAddress,
				iChannel,
				"A02251A-30",
				time,
				purgeValve,
				tankValve,
				measure,
				readSensor);
		}

		public void SetToDefaults()
		{
			m_sBoardType = "A02251A-30";

			m_Time[0] = 0;
			m_Time[1] = 100;
			m_Time[2] = 300;
			m_Time[3] = 1000;
			m_Time[4] = 1050;
			m_Time[5] = 1700;
			m_Time[6] = 2000;
			m_Time[7] = 0;

			m_PurgeValve[0] = true;
			m_PurgeValve[1] = true;
			m_PurgeValve[2] = false;
			m_PurgeValve[3] = true;
			m_PurgeValve[4] = false;
			m_PurgeValve[5] = false;
			m_PurgeValve[6] = false;
			m_PurgeValve[7] = false;

			m_TankValve[0] = false;
			m_TankValve[1] = true;
			m_TankValve[2] = true;
			m_TankValve[3] = false;
			m_TankValve[4] = true;
			m_TankValve[5] = true;
			m_TankValve[6] = false;
			m_TankValve[7] = false;

			m_Measure[0] = false;
			m_Measure[1] = false;
			m_Measure[2] = false;
			m_Measure[3] = true;
			m_Measure[4] = true;
			m_Measure[5] = true;
			m_Measure[6] = false;
			m_Measure[7] = false;

			m_ReadSensor[0] = false;
			m_ReadSensor[1] = false;
			m_ReadSensor[2] = false;
			m_ReadSensor[3] = false;
			m_ReadSensor[4] = false;
			m_ReadSensor[5] = true;
			m_ReadSensor[6] = false;
			m_ReadSensor[7] = false;
		}

		public void CopyTo(ModularBubblerChannel modularBubberChannel)
		{
			modularBubberChannel.BoardType = m_sBoardType;
			m_Time.CopyTo(modularBubberChannel.Time, 0);
			m_PurgeValve.CopyTo(modularBubberChannel.PurgeValve, 0);
			m_TankValve.CopyTo(modularBubberChannel.TankValve, 0);
			m_Measure.CopyTo(modularBubberChannel.Measure, 0);
			m_ReadSensor.CopyTo(modularBubberChannel.ReadSensor, 0);
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

		public string BoardType
		{
			get { return m_sBoardType; }
			set { m_sBoardType = value; }
		}

		public ushort[] Time
		{
			get { return m_Time; }
			set { m_Time = value; }
		}

		public bool[] PurgeValve
		{
			get { return m_PurgeValve; }
			set { m_PurgeValve = value; }
		}

		public bool[] TankValve
		{
			get { return m_TankValve; }
			set { m_TankValve = value; }
		}

		public bool[] Measure
		{
			get { return m_Measure; }
			set { m_Measure = value; }
		}

		public bool[] ReadSensor
		{
			get { return m_ReadSensor; }
			set { m_ReadSensor = value; }
		}
	}
}
