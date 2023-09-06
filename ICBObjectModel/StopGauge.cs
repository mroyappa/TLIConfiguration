using System;
using System.Text;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;

/*
 * CLASS SUMMARY:	StopGauge
 * 
 * The StopGauge class is used to define Stop Gagues for ProcessIDs.  It contains all 
 * members/methods required to describe a Stop Gauge.
 * 
 */

namespace ICBObjectModel
{
	public class StopGauge
	{
		private bool m_bEnable;
		private Guid m_guidStopGaugeID;
		private bool m_bStopFinal;
		private byte m_bIndicationColorR;
		private byte m_bIndicationColorG;
		private byte m_bIndicationColorB;
		private string m_sEquipmentID;
		private string m_sProcessID;
		private string m_sComparator;
		private float m_fPercentage;
		private float m_fLimit;

		private List<string> m_sAlarmAnnunciation;

		public StopGauge()
		{
			m_sAlarmAnnunciation = new List<string>();
		}

		public StopGauge
		(
			bool bEnable,
			Guid guidStopGaugeID,
			bool bStopFinal,
			string sEquipmentID,
			string sProcessID,
			string sComparator,
			float fPercentage,
			float fLimit,
			List<string> sAlarmAnnunciation
		)
		{
			m_bEnable = bEnable;
			m_guidStopGaugeID = guidStopGaugeID;
			m_bStopFinal = bStopFinal;
			m_bIndicationColorR = 0;
			m_bIndicationColorG = 0;
			m_bIndicationColorB = 0;
			m_sEquipmentID = sEquipmentID;
			m_sProcessID = sProcessID;
			m_sComparator = sComparator;
			m_fPercentage = fPercentage;
			m_fLimit = fLimit;
			m_sAlarmAnnunciation = sAlarmAnnunciation;
		}

		public StopGauge Copy()
		{
			return new StopGauge(
				m_bEnable,
				m_guidStopGaugeID,
				m_bStopFinal,
				m_sEquipmentID,
				m_sProcessID,
				m_sComparator,
				m_fPercentage,
				m_fLimit,
				m_sAlarmAnnunciation);
		}

		public bool Enable
		{
			get { return m_bEnable; }
			set { m_bEnable = value; }
		}

		public Guid StopGaugeID
		{
			get { return m_guidStopGaugeID; }
			set { m_guidStopGaugeID = value; }
		}

		#if !WindowsCE
			[Category("General"), DisplayName("Stop High")]
		#endif
		public bool StopFinal
		{
			get { return m_bStopFinal; }
			set { m_bStopFinal = value; }
		}

		#if !WindowsCE
			[Category("User Interface"), DisplayName("Gauge Color"), Description("Color of gauge fill.")]
		#endif
		[System.Xml.Serialization.XmlIgnore]
		public Color IndicationColor
		{
			get
			{
				return Color.FromArgb(Convert.ToInt32(m_bIndicationColorR), Convert.ToInt32(m_bIndicationColorG), Convert.ToInt32(m_bIndicationColorB));
			}
			set
			{
				m_bIndicationColorR = value.R;
				m_bIndicationColorG = value.G;
				m_bIndicationColorB = value.B;
			}
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public byte IndicationColorR
		{
			get { return m_bIndicationColorR; }
			set { m_bIndicationColorR = value; }
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public byte IndicationColorG
		{
			get { return m_bIndicationColorG; }
			set { m_bIndicationColorG = value; }
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public byte IndicationColorB
		{
			get { return m_bIndicationColorB; }
			set { m_bIndicationColorB = value; }
		}

		public string EquipmentID
		{
			get { return m_sEquipmentID; }
			set { m_sEquipmentID = value; }
		}

		public string ProcessID
		{
			get { return m_sProcessID; }
			set { m_sProcessID = value; }
		}

		public string Comparator
		{
			get { return m_sComparator; }
			set { m_sComparator = value; }
		}

		public float Percentage
		{
			get { return m_fPercentage; }
			set { m_fPercentage = value; }
		}


		#if !WindowsCE
			[Browsable(false)]
		#endif
		[System.Xml.Serialization.XmlIgnore]
		public float Limit
		{
			get { return m_fLimit; }
			set { m_fLimit = value; }
		}

		#if !WindowsCE
			[Category("Alarm Annunciation"), DisplayName("Alarm Annunciations"), Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor,System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		#endif
		public List<string> AlarmAnnunciation
		{
			get { return m_sAlarmAnnunciation; }
			set { m_sAlarmAnnunciation = value; }
		}
	}
}
