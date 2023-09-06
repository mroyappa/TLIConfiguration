using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ICBObjectModel;

/*
 * CLASS SUMMARY:	ModularBubblerEZTEdit
 * 
 * ModularBubblerEZTEdit is the form used to Add/Edit/Delete a Vessel's list of Modular Bubblers EZTouch Configurations.
 * 
 */

namespace TLIConfiguration
{
	public partial class ModularBubblerEZTEdit : Form
	{
		private DataTable m_dtDataTable;

		private CustomColumnManagerRow m_CustomColumnManagerRow;
		private Xceed.Grid.DataRow m_EditRow;
		private Xceed.Grid.SpacerRow m_SpacerRow;

		private int m_iIndex;
		private int m_iCurrentAddress;
		private List<ModularBubblerEZT> m_LocalChannels;

		private bool m_bRebuildEquipment;

		public ModularBubblerEZTEdit()
		{
			InitializeComponent();

			m_iIndex = 0;
			m_iCurrentAddress = 0;
		}

		private void ModularBubblerEZTEdit_Load(object sender, EventArgs e)
		{
			m_LocalChannels = new List<ModularBubblerEZT>();

			if (!PopulateModularBubblerAddresses())
			{
				MessageBox.Show(this, "Please configure a Modular Bubbler before attempting to configure EZTs.", "No Modular Bubblers Found", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
				this.Close();
				return;
			}

			foreach (ModularBubblerEZT ezt in TLIConfiguration.Vessel.ModularBubblerEZTArray)
				m_LocalChannels.Add(ezt.Copy());

			SetupGrid();
			PopulateGrid();
		}

		private void SetupGrid()
		{
			try
			{
				customXceedGridControl.SetupGridControl();
				customXceedGridControl.BeginInit();

				customXceedGridControl.AllowDelete = false;

				columnManagerRow1.Remove();

				//customXceedGridControl.InitializingNewDataRow += new Xceed.Grid.InitializingNewDataRowEventHandler(InitializingNewDataRow);

				// Custom Column Manager Row
				m_CustomColumnManagerRow = new CustomColumnManagerRow();
				m_CustomColumnManagerRow.BackColor = System.Drawing.Color.White;
				m_CustomColumnManagerRow.ForeColor = System.Drawing.Color.Black;
				m_CustomColumnManagerRow.Height = 17;

				customXceedGridControl.FixedHeaderRows.Add(m_CustomColumnManagerRow);

				// Insertion Row
				/*
				m_InsertionRow = new Xceed.Grid.InsertionRow();
				m_InsertionRow.ForeColor = Color.FromArgb(29, 50, 139);
				m_InsertionRow.BackColor = Color.FromArgb(244, 244, 244);
				customXceedGridControl.FixedHeaderRows.Add(m_InsertionRow);
				m_InsertionRow.EndingEdit += new CancelEventHandler(EndingEdit);
				*/

				// Spacer Row
				m_SpacerRow = new Xceed.Grid.SpacerRow();
				m_SpacerRow.Height = 4;
				customXceedGridControl.FixedHeaderRows.Add(m_SpacerRow);

				// RowSelectorPane
				customXceedGridControl.RowSelectorPane.Visible = false;

				customXceedGridControl.AddBoundColumn("Index", "Index", false, false, 5);
				customXceedGridControl.AddBoundColumn("Channel", "Channel", true, true, 100);
				customXceedGridControl.AddBoundColumn("ScaledValueHigh", "Scaled Value High", true, false, 125);
				customXceedGridControl.AddBoundColumn("ScaledValueLow", "Scaled Value Low", true, false, 125);
				customXceedGridControl.AddBoundColumn("BottomOffset", "Bottom Offset", true, false, 125);
				customXceedGridControl.AddBoundColumn("SpecificGravity", "Specific Gravity", true, false, 125);
				customXceedGridControl.AddBoundColumn("DisplayMax", "Display Max", true, false, 100);
				customXceedGridControl.AddBoundColumn("DisplayMin", "Display Min", true, false, 100);
				customXceedGridControl.AddBoundColumn("ScaledDivisor", "Scaled Divisor", true, false, 125);
				customXceedGridControl.AddBoundColumn("DisplayName", "Display Name", true, false, 125);
				customXceedGridControl.AddBoundColumn("DisplayUnits", "Display Units", true, false, 125);
				customXceedGridControl.AddBoundColumn("DisplayQuotientUnits", "Display Quotient Units", true, false, 135);
				customXceedGridControl.AddBoundColumn("DisplayRemainderUnits", "Display Remainder Units", true, false, 135);
				customXceedGridControl.ExpandToFitColumn = customXceedGridControl.Columns["DisplayRemainderUnits"];

				customXceedGridControl.Columns["Channel"].SortDirection = Xceed.Grid.SortDirection.Ascending;

				customXceedGridControl.EndInit();
			}
			catch (Exception e)
			{
				MessageBox.Show("Error retrieving configuration data.\n" + e.Message, "TLI Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
		}

		private bool PopulateModularBubblerAddresses()
		{
			bool bModularBubblerConfigured = false;

			foreach (ModularBubbler bubbler in TLIConfiguration.Vessel.ModularBubblerArray)
			{
				bool bEZTObjectExist = false;

				bModularBubblerConfigured = true;
				cboModularBubblerAddress.Items.Add(bubbler.ModularBubblerAddress);

				foreach (ModularBubblerEZT ezt in TLIConfiguration.Vessel.ModularBubblerEZTArray)
					if (ezt.ModularBubblerAddress == bubbler.ModularBubblerAddress)
					{
						bEZTObjectExist = true;
						break;
					}

				if(!bEZTObjectExist)
					for (int i = 0; i <= 8; i++)
						TLIConfiguration.Vessel.ModularBubblerEZTArray.Add(ModularBubblerEZT.CreateDefault(bubbler.ModularBubblerAddress, i));
			}

			if (cboModularBubblerAddress.Items.Count > 0)
				cboModularBubblerAddress.SelectedIndex = 0;

			return bModularBubblerConfigured;
		}

		private void PopulateGrid()
		{
			try
			{
				FillDataTable();

				customXceedGridControl.BeginInit();

				customXceedGridControl.DataSource = m_dtDataTable;
				customXceedGridControl.DataMember = "";

				customXceedGridControl.EndInit();

				customXceedGridControl.HideUnwantedGridColumns(new string[] { "Channel", "ScaledValueHigh", "ScaledValueLow", "BottomOffset", "DisplayMax", "DisplayMin", "ScaledDivisor",
					"DisplayName", "DisplayUnits", "DisplayQuotientUnits", "DisplayRemainderUnits"});
			}
			catch (Exception e)
			{
				MessageBox.Show("Error retrieving configuration data.\n" + e.Message, "TLI Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
		}

		private void FillDataTable()
		{
			int iModularBubblerAddress = 0;

			iModularBubblerAddress = Convert.ToInt32(cboModularBubblerAddress.Items[cboModularBubblerAddress.SelectedIndex]);

			DataRow dr;
			m_dtDataTable = new DataTable();

			m_dtDataTable.Columns.Add("Index", typeof(int));
			m_dtDataTable.Columns.Add("Channel", typeof(int));
			m_dtDataTable.Columns.Add("ScaledValueHigh", typeof(float));
			m_dtDataTable.Columns.Add("ScaledValueLow", typeof(float));
			m_dtDataTable.Columns.Add("BottomOffset", typeof(float));
			m_dtDataTable.Columns.Add("SpecificGravity", typeof(float));
			m_dtDataTable.Columns.Add("DisplayMax", typeof(float));
			m_dtDataTable.Columns.Add("DisplayMin", typeof(float));
			m_dtDataTable.Columns.Add("ScaledDivisor", typeof(float));
			m_dtDataTable.Columns.Add("DisplayName", typeof(string));
			m_dtDataTable.Columns.Add("DisplayUnits", typeof(string));
			m_dtDataTable.Columns.Add("DisplayQuotientUnits", typeof(string));
			m_dtDataTable.Columns.Add("DisplayRemainderUnits", typeof(string));

			foreach (ModularBubblerEZT ezt in m_LocalChannels)
			{
				if (ezt.ModularBubblerAddress == iModularBubblerAddress)
				{
					dr = m_dtDataTable.NewRow();

					dr["Index"] = m_iIndex++;
					dr["Channel"] = ezt.Channel;
					dr["ScaledValueHigh"] = ezt.ScaledValueHigh;
					dr["ScaledValueLow"] = ezt.ScaledValueLow;
					dr["BottomOffset"] = ezt.BottomOffset;
					dr["SpecificGravity"] = ezt.SpecificGravity;
					dr["DisplayMax"] = ezt.DisplayMax;
					dr["DisplayMin"] = ezt.DisplayMin;
					dr["ScaledDivisor"] = ezt.ScaledDivisor;
					dr["DisplayName"] = ezt.DisplayName;
					dr["DisplayUnits"] = ezt.DisplayUnits;
					dr["DisplayQuotientUnits"] = ezt.DisplayQuotientUnits;
					dr["DisplayRemainderUnits"] = ezt.DisplayRemainderUnits;

					m_dtDataTable.Rows.Add(dr);
					dr.AcceptChanges();
				}
			}
		}

		private void SaveChannelValuesLocal()
		{
			int iChannel = 0;
			float fScaledValueHigh = 0, fScaledValueLow = 0, fBottomOffset = 0, fDisplayMax = 0, fDisplayMin = 0, fScaledDivisor = 0;
			string sDisplayName = "", sDisplayUnits = "", sDisplayQuotientUnits = "", sDisplayRemainderUnits = "";

			DataTable dt = (DataTable)customXceedGridControl.DataSource;

			foreach (DataRow dr in dt.Rows)
			{
				iChannel = Convert.ToInt32(dr["Channel"]);
				fScaledValueHigh = Convert.ToSingle(dr["ScaledValueHigh"]);
				fScaledValueLow = Convert.ToSingle(dr["ScaledValueLow"]);
				fBottomOffset = Convert.ToSingle(dr["BottomOffset"]);
				fDisplayMax = Convert.ToSingle(dr["DisplayMax"]);
				fDisplayMin = Convert.ToSingle(dr["DisplayMin"]);
				fScaledDivisor = Convert.ToSingle(dr["ScaledDivisor"]);
				sDisplayName = dr["DisplayName"].ToString();
				sDisplayUnits = dr["DisplayUnits"].ToString();
				sDisplayQuotientUnits = dr["DisplayQuotientUnits"].ToString();
				sDisplayRemainderUnits = dr["DisplayRemainderUnits"].ToString();

				foreach (ModularBubblerEZT ezt in m_LocalChannels)
					if (ezt.ModularBubblerAddress == m_iCurrentAddress && ezt.Channel == iChannel)
					{
						ezt.ScaledValueHigh = fScaledValueHigh;
						ezt.ScaledValueLow = fScaledValueLow;
						ezt.BottomOffset = fBottomOffset;
						ezt.DisplayMax = fDisplayMax;
						ezt.DisplayMin = fDisplayMin;
						ezt.ScaledDivisor = fScaledDivisor;
						ezt.DisplayName = sDisplayName;
						ezt.DisplayUnits = sDisplayUnits;
						ezt.DisplayQuotientUnits = sDisplayQuotientUnits;
						ezt.DisplayRemainderUnits = sDisplayRemainderUnits;
						break;
					}
			}
		}

		private void SaveChanges()
		{
			DataTable dt = (DataTable)customXceedGridControl.DataSource;

			TLIConfiguration.Vessel.ModularBubblerEZTArray.Clear();

			foreach (ModularBubblerEZT ezt in m_LocalChannels)
				TLIConfiguration.Vessel.ModularBubblerEZTArray.Add(ezt.Copy());
		}

		private void cboModularBubblerAddress_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_iCurrentAddress > 0)
				SaveChannelValuesLocal();

			m_iCurrentAddress = Convert.ToInt32(cboModularBubblerAddress.Items[cboModularBubblerAddress.SelectedIndex]);

			PopulateGrid();
		}

		private void cmdOk_Click(object sender, EventArgs e)
		{
			SaveChannelValuesLocal();
			SaveChanges();
			this.Close();
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}


		private void customXceedGridControl_AddingDataRow(object sender, Xceed.Grid.AddingDataRowEventArgs e)
		{
			e.DataRow.BeginningEdit += new CancelEventHandler(BeginningEdit);
			e.DataRow.EndingEdit += new CancelEventHandler(EndingEdit);
		}

		private void BeginningEdit(object sender, CancelEventArgs e)
		{
			m_EditRow = (Xceed.Grid.DataRow)sender;
		}

		private void EndingEdit(object sender, CancelEventArgs e)
		{
			if (Disposing)
				return;

			if (m_EditRow != null)
			{
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["ScaledValueHigh"], "Scaled Value High", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["ScaledValueLow"], "Scaled Value Low", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["BottomOffset"], "Bottom Offset", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["SpecificGravity"], "Specific Gravity", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["DisplayMax"], "Display Max", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["DisplayMin"], "Display Min", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["ScaledDivisor"], "Scaled Divisor", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["DisplayName"], "Diplay Name", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["DisplayUnits"], "Display Units", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["DisplayQuotientUnits"], "Display Quotient Units", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["DisplayRemainderUnits"], "Display Remainder Units", e);
			}

			m_EditRow = null;
		}

		public bool RebuildEquipment
		{
			get { return m_bRebuildEquipment; }
		}
	}
}
