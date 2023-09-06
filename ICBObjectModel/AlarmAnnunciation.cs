using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;

/*
 * CLASS SUMMARY:	AlarmAnnunciation
 * 
 * This class is used to enumerate Alarm Annunciations associated with alarms.  Class contains
 * memebers to track AMU Address/Channel of Digitial Output as well as how to handle
 * the annuciation when the alarm is acknowledged.
 * 
 */

namespace ICBObjectModel
{
	public class AlarmAnnunciation
	{
		private string m_sAlarmAnnunciation;
		private AMUOutput m_aoAMUOutput;
		private bool m_bKeepActiveOnAcknowledge;

		public AlarmAnnunciation()
		{
			m_aoAMUOutput = new AMUOutput();
			m_bKeepActiveOnAcknowledge = false;
		}

		public AlarmAnnunciation(string sAlarmAnnunciation, AMUOutput aoAMUOutput, bool bKeepActiveOnAcknowledge)
		{
			m_sAlarmAnnunciation = sAlarmAnnunciation;
			m_aoAMUOutput = aoAMUOutput;
			m_bKeepActiveOnAcknowledge = bKeepActiveOnAcknowledge;
		}
		public AlarmAnnunciation Copy()
		{
			return new AlarmAnnunciation(m_sAlarmAnnunciation, m_aoAMUOutput.Copy(), m_bKeepActiveOnAcknowledge);
		}

#if !WindowsCE
		[Category("General"), DisplayName("Alarm Annunciation Name"), Description("Note:  Must be unique.")]
#endif
		public string AlarmAnnunciationName
		{
			get { return m_sAlarmAnnunciation; }
			set { m_sAlarmAnnunciation = value; }
		}
#if !WindowsCE
		[Browsable(false)]
#endif
		public AMUOutput AMUOutput
		{
			get { return m_aoAMUOutput; }
			set { m_aoAMUOutput = value; }
		}

#if !WindowsCE
		[Category("AMU"), DisplayName("Enable")]
#endif
		[System.Xml.Serialization.XmlIgnore]
		public bool AMUOutputEnable
		{
			get { return m_aoAMUOutput.Enable; }
			set { m_aoAMUOutput.Enable = value; }
		}
#if !WindowsCE
		[Category("AMU"), DisplayName("Address"), Description("Address of AMU which is connected to annuncuation relay.")]
#endif
		[System.Xml.Serialization.XmlIgnore]
		public int AMUOutputAddress
		{
			get { return m_aoAMUOutput.AMUAddress; }
			set { m_aoAMUOutput.AMUAddress = value; }
		}
#if !WindowsCE
		[Category("AMU"), DisplayName("Digital Channel"), Description("Digital output point to be triggered.")]
#endif
		[System.Xml.Serialization.XmlIgnore]
		public int AMUOutputDigitalChannel
		{
			get { return m_aoAMUOutput.DigitalOutput; }
			set { m_aoAMUOutput.DigitalOutput = value; }
		}

		public bool KeepActiveOnAcknowledge
		{
			get { return m_bKeepActiveOnAcknowledge; }
			set { m_bKeepActiveOnAcknowledge = value; }
		}
	}
}
