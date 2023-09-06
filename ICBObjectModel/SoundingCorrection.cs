using System;
using System.Collections.Generic;
using System.Text;

/*
 * CLASS SUMMARY:	SoundingCorrection
 * 
 * The SoundingCorrection class was originally included to provide a means of allowing the
 * vessel's crew to enter corrected sounding values measured at the tank.  This is ended up not
 * being used and is thus, not supported.
 * 
 */

namespace ICBObjectModel
{
	public class SoundingCorrection
	{
		private bool m_bEnable;
		private List<Correction> m_lCorrectionTable;

		public SoundingCorrection()
		{
		}

		public SoundingCorrection(bool bEnable)
		{
			m_bEnable = bEnable;
			m_lCorrectionTable = new List<Correction>();
		}

		public bool Enable
		{
			get { return m_bEnable; }
			set { m_bEnable = value; }
		}

		public List<Correction> CorrectionTable
		{
			get { return m_lCorrectionTable; }
			set { m_lCorrectionTable = value; }
		}
	}

	public class Correction
	{
		private float m_fSounding;
		private float m_fLevel;

		public Correction()
		{
			m_fSounding = 0;
			m_fLevel = 0;
		}

		public Correction(float fSounding, float fLevel)
		{
			m_fSounding = fSounding;
			m_fLevel = fLevel;
		}

		public Correction Copy()
		{
			return new Correction(m_fSounding, m_fLevel);
		}

		public float Sounding
		{
			get { return m_fSounding; }
			set { m_fSounding = value; }
		}

		public float Level
		{
			get { return m_fLevel; }
			set { m_fLevel = value; }
		}
	}
}
