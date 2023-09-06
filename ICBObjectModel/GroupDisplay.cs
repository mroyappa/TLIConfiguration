using System;
using System.Text;
using System.Drawing;
using System.Collections.Generic;

/*
 * CLASS SUMMARY:	GroupDisplay
 * 
 * The GroupDisplay class is used to store Group Displays designed by users.  In addition to
 * a name and Group Display Index, this class also contains an array of GroupDisplayFaceplate 
 * objects (defined below) which are used to described the actual faceplates included in the 
 * Group Display.  This description includes ProcessID, Faceplate Location, and Magnification.
 * 
 */

namespace ICBObjectModel
{
	public class GroupDisplay
	{
		private string m_sName;
		private int m_iIndex;
		private List<GroupDisplayFaceplate> m_gdpGroupDisplayFaceplates;

		public GroupDisplay()
		{
			m_gdpGroupDisplayFaceplates = new List<GroupDisplayFaceplate>();
		}

		public GroupDisplay(string sName, int iIndex)
		{
			m_sName = sName;
			m_iIndex = iIndex;

			m_gdpGroupDisplayFaceplates = new List<GroupDisplayFaceplate>();
		}

		public string Name
		{
			get { return m_sName; }
			set { m_sName = value; }
		}

		public int Index
		{
			get { return m_iIndex; }
			set { m_iIndex = value; }
		}

		public List<GroupDisplayFaceplate> GroupDisplayFaceplates
		{
			get { return m_gdpGroupDisplayFaceplates; }
			set { m_gdpGroupDisplayFaceplates = value; }
		}
	}

	public class GroupDisplayFaceplate
	{
		private string m_sEquipmentID;
		private string m_sProcessID;
		private Point m_pFaceplateLocation;
		private int m_iSizeMultiplier;

		public GroupDisplayFaceplate()
		{
			m_pFaceplateLocation = new Point();
			m_iSizeMultiplier = 1;
		}

		public GroupDisplayFaceplate(string sEquipmentID, string sProcessID, Point pFaceplateLocation, int iSizeMultiplier)
		{
			m_sEquipmentID = sEquipmentID;
			m_sProcessID = sProcessID;
			m_pFaceplateLocation = pFaceplateLocation;
			m_iSizeMultiplier = iSizeMultiplier;
			
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

		public Point FaceplateLocation
		{
			get { return m_pFaceplateLocation; }
			set { m_pFaceplateLocation = value; }
		}

		public int SizeMultiplier
		{
			get { return m_iSizeMultiplier; }
			set { m_iSizeMultiplier = value; }
		}
	}
}
