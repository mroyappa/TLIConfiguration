using System;
using System.Text;
using System.Collections.Generic;
using ICBObjectModel.Enumerations;

/*
 * CLASS SUMMARY:	ModbusInput
 * 
 * The ModbusInput object is used by the GaugePoint class to define a data value
 * aquired via Modbus.
 * 
 */

namespace ICBObjectModel
{
	public class ModbusInput
	{
		private ModbusCommunicationInterface m_ModbusCommunicationInterface;

		private bool m_bEnable;
		private int m_iModbusDataType;
		private ushort m_iRegisterAddress1;
		private ushort m_iRegisterAddress2;
		private float m_fScale;

		private bool m_bSecondaryEnable;
		private int m_iSecondaryModbusDataType;
		private ushort m_iSecondaryRegisterAddress1;
		private ushort m_iSecondaryRegisterAddress2;
		private float m_fSecondaryScale;

		public ModbusInput() : this(ModbusCommunicationInterface.Serial, false, ICBObjectModel.ModbusDataType.Float32, 0, 0, 1, false, ICBObjectModel.ModbusDataType.Float32, 0, 0, 1) { }
		public ModbusInput
		(
			ModbusCommunicationInterface modbusCommunicationInterface,
			bool bEnable,
			int iModbusDataType,
			ushort iRegisterAddress1,
			ushort iRegisterAddress2,
			float fScale,
			bool bSecondayEnable,
			int iSecondayModbusDataType,
			ushort iSecondayRegisterAddress1,
			ushort iSecondayRegisterAddress2,
			float fSecondayScale
		)
		{
			m_ModbusCommunicationInterface = modbusCommunicationInterface;

			m_bEnable = bEnable;
			m_iModbusDataType = iModbusDataType;
			m_iRegisterAddress1 = iRegisterAddress1;
			m_iRegisterAddress2 = iRegisterAddress2;
			m_fScale = fScale;

			m_bSecondaryEnable = bSecondayEnable;
			m_iSecondaryModbusDataType = iSecondayModbusDataType;
			m_iSecondaryRegisterAddress1 = iSecondayRegisterAddress1;
			m_iSecondaryRegisterAddress2 = iSecondayRegisterAddress2;
			m_fSecondaryScale = fSecondayScale;
		}

		[System.Xml.Serialization.XmlIgnore]
		public string ModbusInputID
		{
			get
			{
				if (m_iModbusDataType == ICBObjectModel.ModbusDataType.Int16)
					return m_iRegisterAddress1.ToString();
				else if (m_iModbusDataType == ICBObjectModel.ModbusDataType.Float32)
					return m_iRegisterAddress1.ToString() + ":" + m_iRegisterAddress2.ToString();
				else
					return m_iRegisterAddress1.ToString();
			}
		}

		public ModbusCommunicationInterface ModbusCommunicationInterface
		{
			get { return m_ModbusCommunicationInterface; }
			set { m_ModbusCommunicationInterface = value; }
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

		public bool SecondaryEnable
		{
			get { return m_bSecondaryEnable; }
			set { m_bSecondaryEnable = value; }
		}

		public int SecondaryModbusDataType
		{
			get { return m_iSecondaryModbusDataType; }
			set { m_iSecondaryModbusDataType = value; }
		}

		public ushort SecondaryRegisterAddress1
		{
			get { return m_iSecondaryRegisterAddress1; }
			set { m_iSecondaryRegisterAddress1 = value; }
		}

		public ushort SecondaryRegisterAddress2
		{
			get { return m_iSecondaryRegisterAddress2; }
			set { m_iSecondaryRegisterAddress2 = value; }
		}

		public float SecondaryScale
		{
			get { return m_fSecondaryScale; }
			set { m_fSecondaryScale = value; }
		}
	}
}
