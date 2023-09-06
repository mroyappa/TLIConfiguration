using System;
using System.Collections.Generic;
using System.Text;

/*
 * CLASS SUMMARY:	ProjectConfiguration
 * 
 * ProjectConfiguration is the template class for the *.proj file.  It contains the filename of the Vessel, the
 * relative directory path for EquipmentUnits, and a list of filenames for included equipment.
 * 
 */

namespace TLIConfiguration
{
	public class ProjectConfiguration
	{
		private string m_sVesselFilename;
		private string m_sEquipmentSubDirectory;
		private List<string> m_ConfiguredEquipment;		//Filename


		public ProjectConfiguration()
		{}

		public ProjectConfiguration(string sVesselFilename, string sEquipmentSubdirectory)
		{
			m_sVesselFilename = sVesselFilename;
			m_sEquipmentSubDirectory = sEquipmentSubdirectory;
			m_ConfiguredEquipment = new List<string>();
		}

		public string VesselFilename
		{
			get { return m_sVesselFilename; }
			set { m_sVesselFilename = value; }
		}

		public string EquipmentSubdirectory
		{
			get { return m_sEquipmentSubDirectory; }
			set { m_sEquipmentSubDirectory = value; }
		}

		public List<string> ConfiguredEquipment
		{
			get { return m_ConfiguredEquipment; }
			set { m_ConfiguredEquipment = value; }
		}
	}
}
