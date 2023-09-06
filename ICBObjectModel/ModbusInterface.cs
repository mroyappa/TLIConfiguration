using System;
using System.Collections.Generic;
using System.Text;

namespace ICBObjectModel
{
	public class ModbusInterface
	{
		private bool m_bEnable;
		private int m_iModbusDataType;
		private ushort m_iRegisterAddress1;
		private ushort m_iRegisterAddress2;
		private float m_fScale;

		public ModbusInterface()
		{
			m_bEnable = false;
			m_iModbusDataType = ICBObjectModel.ModbusDataType.Float32;
			m_iRegisterAddress1 = 0;
			m_iRegisterAddress2 = 0;
			m_fScale = 1;
			CMaxRegisterAddress1 = 0;
			CMaxRegisterAddress2 = 0;
			CMaxScale = 1;
		}

		public ModbusInterface
		(
			bool bEnable,
			int iModbusDataType,
			ushort iRegisterAddress1,
			ushort iRegisterAddress2,
			float fScale
		)
		{
			m_bEnable = bEnable;
			m_iModbusDataType = iModbusDataType;
			m_iRegisterAddress1 = iRegisterAddress1;
			m_iRegisterAddress2 = iRegisterAddress2;
			m_fScale = fScale;
			CMaxRegisterAddress1 = 0;
			CMaxRegisterAddress2 = 0;
			CMaxScale = 1;
		}

		public ModbusInterface Copy()
		{
			return new ModbusInterface(
				m_bEnable,
				m_iModbusDataType,
				m_iRegisterAddress1,
				m_iRegisterAddress2,
				m_fScale);
		}

		public bool Enable
		{
			get { return m_bEnable; }
			set { m_bEnable = value; }
		}

		public int ModbusDataType
		{
			get { return m_iModbusDataType; }
			set { m_iModbusDataType = value; }
		}

		public ushort RegisterAddress1
		{
			get { return m_iRegisterAddress1; }
			set { m_iRegisterAddress1 = value; }
		}

		public ushort RegisterAddress2
		{
			get { return m_iRegisterAddress2; }
			set { m_iRegisterAddress2 = value; }
		}

		public float Scale
		{
			get { return m_fScale; }
			set { m_fScale = value; }
		}

		public ushort CMaxRegisterAddress1 { get; set; }
		public ushort CMaxRegisterAddress2 { get; set; }
		public float CMaxScale { get; set; }
	}

	public class ModbusDataType
	{
		public const int Float32 = 0;
		public const int Int16 = 1;

		public const string Float32String = "Float32";
		public const string Int16String = "Int16";

		public static string GetModbusDataTypeString(int iModbusDataType)
		{
			switch (iModbusDataType)
			{
				case 0:
					return "Float32";
				case 1:
					return "Int16";
				default:
					return "Float32";
			}
		}

		public static int GetModbusDataTypeID(string sModbusDataType)
		{
			switch (sModbusDataType)
			{
				case Float32String:
					return 0;
				case Int16String:
					return 1;
				default:
					return 0;
			}
		}
	}
}
