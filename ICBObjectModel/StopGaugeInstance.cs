using System;
using System.Text;
using System.Collections.Generic;
using ICBObjectModel.Enumerations;

/*
 * CLASS SUMMARY:	StopGaugeInstance
 * 
 * The StopGaugeInstance class is used to represent active stop gagues.  The instance class contains members
 * which detail the StopGaugeInstance Start, End, and Ack time (if occured) as well as the StopGauge,
 * ProcessID, and EquipmentUnit that the StopGaugeInstance was created.
 * 
 */

namespace ICBObjectModel
{
	public class StopGaugeInstance
	{
		private Guid m_guidStopGaugeInstanceID;
		private StopGauge m_sgStopGauge;
		private DateTime m_dtStopGaugeStartTime;
		private DateTime m_dtStopGaugeEndTime;
		private DateTime m_dtStopGaugeAckTime;

		public StopGaugeInstance
		(
			Guid guidStopGaugeInstanceID,
			StopGauge sgStopGauge,
			DateTime dtStopGaugeStartTime
		)
			: this(guidStopGaugeInstanceID, sgStopGauge, dtStopGaugeStartTime, NullValue.DateTimeNull, NullValue.DateTimeNull) { }

		public StopGaugeInstance
		(
			Guid guidStopGaugeInstanceID,
			StopGauge sgStopGauge,
			DateTime dtStopGaugeStartTime,
			DateTime dtStopGaugeEndTime,
			DateTime dtStopGaugeAckTime
		)
		{
			m_guidStopGaugeInstanceID = guidStopGaugeInstanceID;
			m_sgStopGauge = sgStopGauge;
			m_dtStopGaugeStartTime = dtStopGaugeStartTime;
			m_dtStopGaugeEndTime = dtStopGaugeEndTime;
			m_dtStopGaugeAckTime = dtStopGaugeAckTime;
		}

		public StopGaugeInstance Copy()
		{
			return new StopGaugeInstance(
				m_guidStopGaugeInstanceID,
				m_sgStopGauge,
				m_dtStopGaugeStartTime,
				m_dtStopGaugeEndTime,
				m_dtStopGaugeAckTime);
		}

		public bool StopGaugeAcknowledged
		{
			get { return m_dtStopGaugeAckTime != NullValue.DateTimeNull; }
		}

		public bool StopGaugeEnded
		{
			get { return m_dtStopGaugeEndTime != NullValue.DateTimeNull; }
		}

		public Guid StopGaugeInstanceID
		{
			get { return m_guidStopGaugeInstanceID; }
			set { m_guidStopGaugeInstanceID = value; }
		}

		public StopGauge StopGauge
		{
			get { return m_sgStopGauge; }
			set { m_sgStopGauge = value; }
		}

		public DateTime StopGaugeStartTime
		{
			get { return m_dtStopGaugeStartTime; }
			set { m_dtStopGaugeStartTime = value; }
		}

		public DateTime StopGaugeEndTime
		{
			get { return m_dtStopGaugeEndTime; }
			set { m_dtStopGaugeEndTime = value; }
		}

		public DateTime StopGaugeAckTime
		{
			get { return m_dtStopGaugeAckTime; }
			set { m_dtStopGaugeAckTime = value; }
		}
	}
}
