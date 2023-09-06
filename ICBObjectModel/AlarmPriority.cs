using System;
using System.Text;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;

/*
 * CLASS SUMMARY:	AlarmPriority
 * 
 * The AlarmPriority object is used to track a numeric AlarmPriority, a Description of
 * the Priority, and a color used on faceplates when an alarm of the given type occurs.
 * The color used coincides to color used on the border of the faceplate when an alarm 
 * is active.
 * 
 */

namespace ICBObjectModel
{
	public class AlarmPriority
	{
		private int m_iPriority;
		private string m_sDescription;
		private byte m_bAlarmColorR;
		private byte m_bAlarmColorG;
		private byte m_bAlarmColorB;

		public AlarmPriority()
		{
		}

		public AlarmPriority(int iPriority, string sDescription, Color cAlarmColor)
		{
			m_iPriority = iPriority;
			m_sDescription = sDescription;
			m_bAlarmColorR = cAlarmColor.R;
			m_bAlarmColorG = cAlarmColor.G;
			m_bAlarmColorB = cAlarmColor.B;
		}

		public AlarmPriority(int iPriority, string sDescription, byte bAlarmColorR, byte bAlarmColorG, byte bAlarmColorB)
		{
			m_iPriority = iPriority;
			m_sDescription = sDescription;
			m_bAlarmColorR = bAlarmColorR;
			m_bAlarmColorG = bAlarmColorG;
			m_bAlarmColorB = bAlarmColorB;
		}

		#if !WindowsCE
			[Category("General"), Description("Alarm priority")]
		#endif
		public int Priority
		{
			get { return m_iPriority; }
			set { m_iPriority = value; }
		}

		#if !WindowsCE
			[Category("General"), Description("Priority description.  Note:  Must be unique.")]
		#endif
		public string Description
		{
			get { return m_sDescription; }
			set { m_sDescription = value; }
		}

		#if !WindowsCE
			[Category("User Interface"), DisplayName("Alarming Color"), Description("The color the faceplate background will be set to when an alarm is active.")]
		#endif
		[System.Xml.Serialization.XmlIgnore]
		public Color AlarmColor
		{
			get
			{
				return Color.FromArgb(Convert.ToInt32(m_bAlarmColorR), Convert.ToInt32(m_bAlarmColorG), Convert.ToInt32(m_bAlarmColorB));
			}
			set
			{
				m_bAlarmColorR = value.R;
				m_bAlarmColorG = value.G;
				m_bAlarmColorB = value.B;
			}
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public byte AlarmColorR
		{
			get { return m_bAlarmColorR; }
			set { m_bAlarmColorR = value; }
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public byte AlarmColorG
		{
			get { return m_bAlarmColorG; }
			set { m_bAlarmColorG = value; }
		}

		#if !WindowsCE
			[Browsable(false)]
		#endif
		public byte AlarmColorB
		{
			get { return m_bAlarmColorB; }
			set { m_bAlarmColorB = value; }
		}
	}
}
