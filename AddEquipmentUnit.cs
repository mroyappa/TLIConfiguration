using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ICBObjectModel;
using ICBObjectModel.Enumerations;

/*
 * CLASS SUMMARY:	AddEquipmentUnit
 * 
 * This is the original form used to add an EquipmentUnit to the Vessel.  It is no longer used.
 * 
 */

namespace TLIConfiguration
{
	public partial class AddEquipmentUnit : Form
	{
		private EquipmentUnit m_EquipmentUnit;
		private int m_iEquipmentType;

		public AddEquipmentUnit()
		{
			InitializeComponent();
		}

		private void AddEquipmentUnit_Load(object sender, EventArgs e)
		{
			BindControls();
		}

		private void BindControls()
		{
			EquipmentType et = new EquipmentType();
			TypeConverter.StandardValuesCollection svcEquipmentType;

			EquipmentLocation el = new EquipmentLocation();
			TypeConverter.StandardValuesCollection svcEquipmentLocation;

			svcEquipmentType = (TypeConverter.StandardValuesCollection) et.GetStandardValues();
			for (int i = 0; i < svcEquipmentType.Count; i++)
				cboEquipmentType.Items.Add(svcEquipmentType[i]);

			svcEquipmentLocation = (TypeConverter.StandardValuesCollection)el.GetStandardValues();
			for(int i = 0; i < svcEquipmentLocation.Count; i++)
				cboEquipmentLocation.Items.Add(svcEquipmentLocation[i]);

			if (cboEquipmentType.Items.Count > 0)
			{
				for (int i = 0; i < cboEquipmentType.Items.Count; i++)
				{
					if (m_iEquipmentType == ICBObjectModel.Enumerations.EquipmentType.EquipmentTypeID(cboEquipmentType.Items[i].ToString()))
					{
						cboEquipmentType.SelectedIndex = i;
						cboEquipmentType.Enabled = false;
						break;
					}
				}
			}

			if (cboEquipmentLocation.Items.Count > 0)
				cboEquipmentLocation.SelectedIndex = 0;
			

		}

		private bool ValidateInput()
		{
			if (txtEquipmentName.Text == null || txtEquipmentName.Text == "")
			{
				MessageBox.Show(this, "Name is a required field.", "Equipment Unit", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
				return false;
			}

			m_EquipmentUnit = new EquipmentUnit();
			m_EquipmentUnit.Enable = true;
			m_EquipmentUnit.Equipment = txtEquipmentName.Text;
			m_EquipmentUnit.EquipmentType = m_iEquipmentType;
			m_EquipmentUnit.EquipmentLocationString = cboEquipmentLocation.Items[cboEquipmentLocation.SelectedIndex].ToString();
			m_EquipmentUnit.DisplayName = "";

			if (TLIConfiguration.VesselEquipment.ContainsKey(m_EquipmentUnit.EquipmentID))
			{
				MessageBox.Show(this, "This vessel already contains equipment with this Name, Type, and Location.", "Equipment Unit", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
				return false;
			}

			switch (m_EquipmentUnit.EquipmentType)
			{
				case ICBObjectModel.Enumerations.EquipmentType.Ballast:
//					if (m_EquipmentUnit.DisplayName == "")
					m_EquipmentUnit.DisplayName = "Ballast_" + m_EquipmentUnit.Equipment;
					break;
				case ICBObjectModel.Enumerations.EquipmentType.Cargo:
//					if (m_EquipmentUnit.DisplayName == "")
					m_EquipmentUnit.DisplayName = "Cargo_" + m_EquipmentUnit.Equipment;
					break;
				case ICBObjectModel.Enumerations.EquipmentType.Draft:
//					if (m_EquipmentUnit.DisplayName == "")
					m_EquipmentUnit.DisplayName = "Draft_" + m_EquipmentUnit.Equipment;
					break;
				case ICBObjectModel.Enumerations.EquipmentType.Fuel:
//					if (m_EquipmentUnit.DisplayName == "")
					m_EquipmentUnit.DisplayName = "Fuel_" + m_EquipmentUnit.Equipment;
					break;
				case ICBObjectModel.Enumerations.EquipmentType.List:
//					if (m_EquipmentUnit.DisplayName == "")
					m_EquipmentUnit.DisplayName = "List_" + m_EquipmentUnit.Equipment;
					break;
				case ICBObjectModel.Enumerations.EquipmentType.Trim:
//					if (m_EquipmentUnit.DisplayName == "")
					m_EquipmentUnit.DisplayName = "Trim_" + m_EquipmentUnit.Equipment;
					break;
				case ICBObjectModel.Enumerations.EquipmentType.Manifold:
//					if (m_EquipmentUnit.DisplayName == "")
					m_EquipmentUnit.DisplayName = "Manifold_" + m_EquipmentUnit.Equipment;
					break;
			}

			return true;
		}

		private void cmdOk_Click(object sender, EventArgs e)
		{
			if (ValidateInput())
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		public EquipmentUnit EquipmentUnit
		{
			get { return m_EquipmentUnit; }
		}

		public int EquipmentType
		{
			get { return m_iEquipmentType; }
			set { m_iEquipmentType = value; }
		}
	}
}