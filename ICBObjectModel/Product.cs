using System;
using System.Text;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;

/*
 * CLASS SUMMARY:	Product
 * 
 * The Product class is used to describe the material currently contained in a tank (EquipmentUnit).  Each
 * Product has a configured color which is used on the faceplate as well as a SG which is used by the device
 * engines (AMUEngine, TAUEngine, etc.).
 * 
 */

namespace ICBObjectModel
{
	public class Product
	{
		private string m_sProduct;
		private float m_fSpecificGravity;
		private int m_iSpecificGravityUnits;
		private bool m_bCargo;
		private byte m_bGaugeColorR;
		private byte m_bGaugeColorG;
		private byte m_bGaugeColorB;
		private int id = 0;

		public Product()
		{
		}

		public Product(string sProduct, float fSpecificGravity, int iSpecificGravityUnits, bool bCargo, Color cGaugeColor)
		{
			m_sProduct = sProduct;
			m_fSpecificGravity = fSpecificGravity;
			m_bCargo = bCargo;
			m_iSpecificGravityUnits = iSpecificGravityUnits;
			m_bGaugeColorR = cGaugeColor.R;
			m_bGaugeColorG = cGaugeColor.G;
			m_bGaugeColorB = cGaugeColor.B;
        }

        public Product(string sProduct, float fSpecificGravity, int iSpecificGravityUnits, bool bCargo, Color cGaugeColor, int id)
        {
            m_sProduct = sProduct;
            m_fSpecificGravity = fSpecificGravity;
            m_bCargo = bCargo;
            m_iSpecificGravityUnits = iSpecificGravityUnits;
            m_bGaugeColorR = cGaugeColor.R;
            m_bGaugeColorG = cGaugeColor.G;
            m_bGaugeColorB = cGaugeColor.B;
			this.id = id;
        }

        public Product(string sProduct, float fSpecificGravity, int iSpecificGravityUnits, bool bCargo, byte bGaugeColorR, byte bGaugeColorG, byte bGaugeColorB)
		{
			m_sProduct = sProduct;
			m_fSpecificGravity = fSpecificGravity;
			m_bCargo = bCargo;
			m_iSpecificGravityUnits = iSpecificGravityUnits;
			m_bGaugeColorR = bGaugeColorR;
			m_bGaugeColorG = bGaugeColorG;
			m_bGaugeColorB = bGaugeColorB;
		}

		public Product Copy()
		{
			return new Product(m_sProduct, m_fSpecificGravity, m_iSpecificGravityUnits, m_bCargo, m_bGaugeColorR, m_bGaugeColorG, m_bGaugeColorB);
		}

		#if !WindowsCE
			[Category("General"), DisplayName("Product Name")]
		#endif
		public string ProductName
		{
			get { return m_sProduct.ToUpper(); }
			set { m_sProduct = value; }
		}

		#if !WindowsCE
			[Category("Engineering"), DisplayName("Specific Gravity")]
		#endif
		public float SpecificGravity
		{
			get { return m_fSpecificGravity; }
			set { m_fSpecificGravity = value; }
		}

		#if !WindowsCE
			[Category("Engineering"), DisplayName("Specific Gravity Units")]
		#endif
		public int SpecificGravityUnits
		{
			get { return m_iSpecificGravityUnits; }
			set { m_iSpecificGravityUnits = value; }
		}

		#if !WindowsCE
			[Category("General"), DisplayName("Cargo"), Description("Flags product as a potential cargo")]
		#endif
		public bool Cargo
		{
			get { return m_bCargo; }
			set { m_bCargo = value; }
		}

		#if !WindowsCE
			[Category("User Interface"), DisplayName("Gauge Color"), Description("Color of gauge fill.")]
		#endif
		[System.Xml.Serialization.XmlIgnore]
		public Color GaugeColor
		{
			get
			{
				return Color.FromArgb(Convert.ToInt32(m_bGaugeColorR), Convert.ToInt32(m_bGaugeColorG), Convert.ToInt32(m_bGaugeColorB));
			}
			set
			{
				m_bGaugeColorR = value.R;
				m_bGaugeColorG = value.G;
				m_bGaugeColorB = value.B;
			}
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public byte GaugeColorR
		{
			get { return m_bGaugeColorR; }
			set { m_bGaugeColorR = value; }
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public byte GaugeColorG
		{
			get { return m_bGaugeColorG; }
			set { m_bGaugeColorG = value; }
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public byte GaugeColorB
		{
			get { return m_bGaugeColorB; }
			set { m_bGaugeColorB = value; }
		}

		public int ID
		{
			get { return id; }
			set { id = value; }
		}
	}
}
