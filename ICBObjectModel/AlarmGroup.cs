using System;
using System.Text;
using System.Collections.Generic;

/*
 * CLASS SUMMARY:	AlarmGroup
 * 
 * The original FDS of the TLIRuntime provided for a mechanism both visually and programmatically
 * to group alarms.  This class was created for the management of Alarm Group.  Sometime since the
 * initial release of the application, this concept has been removed.
 * 
 */

namespace ICBObjectModel
{
	public class AlarmGroup
	{
		private string m_sAlarmGroup;

		public AlarmGroup()
		{
		}
		
		public AlarmGroup(string sAlarmGroup)
		{
			m_sAlarmGroup = sAlarmGroup;
		}

		public string AlarmGroupName
		{
			get { return m_sAlarmGroup; }
			set { m_sAlarmGroup = value; }
		}
	}
}
