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
 * CLASS SUMMARY:	ModularBubblerChannelEdit
 * 
 * ModularBubblerChannelEdit is the form used to Add/Edit/Delete a Vessel's list of Modular Bubbler Channels.
 * 
 */

namespace TLIConfiguration
{
	public partial class ModularBubblerChannelEdit : Form
	{
		private DataTable m_dtDataTable;

		private CustomColumnManagerRow m_CustomColumnManagerRow;
		private Xceed.Grid.DataRow m_EditRow;
		private Xceed.Grid.SpacerRow m_SpacerRow;

		private int m_iIndex;
		private int m_iCurrentAddress;
		private int m_iCurrentChannel;
		private List<ModularBubblerChannel> m_LocalChannels;

		private bool m_bRebuildEquipment;

		public ModularBubblerChannelEdit()
		{
			InitializeComponent();

			m_iIndex = 0;
			m_iCurrentAddress = 0;
			m_iCurrentChannel = 0;
		}

		private void ModularBubblerChannelEdit_Load(object sender, EventArgs e)
		{
			m_LocalChannels = new List<ModularBubblerChannel>();
			foreach (ModularBubblerChannel mbc in TLIConfiguration.Vessel.ModularBubberChannelArray)
				m_LocalChannels.Add(mbc.Copy());

			if (!PopulateModularBubblerAddresses())
			{
				MessageBox.Show(this, "Please configure a Modular Bubbler before attempting to configure channels.", "No Modular Bubblers Found", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
				this.Close();
				return;
			}

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

				customXceedGridControl.AddBoundColumn("Index", "Index", false, false, 100);
				customXceedGridControl.AddBoundColumn("Channel", "Channel", true, true, 100);
				customXceedGridControl.AddBoundColumn("BoardType", "Board Type", true, false, 100);

				customXceedGridControl.ExpandToFitColumn = customXceedGridControl.Columns["BoardType"];

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
				bModularBubblerConfigured = true;
				cboModularBubblerAddress.Items.Add(bubbler.ModularBubblerAddress);
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

				customXceedGridControl.HideUnwantedGridColumns(new string[] { "Channel", "BoardType" });
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
			m_dtDataTable.Columns.Add("BoardType", typeof(string));

			foreach (ModularBubblerChannel channel in m_LocalChannels)
			{
				if (channel.ModularBubblerAddress == iModularBubblerAddress)
				{
					dr = m_dtDataTable.NewRow();

					dr["Index"] = m_iIndex++;
					dr["Channel"] = channel.Channel;
					dr["BoardType"] = channel.BoardType;

					m_dtDataTable.Rows.Add(dr);
					dr.AcceptChanges();
				}
			}
		}

		private void SetChannelTimingControls()
		{
			// Clear Controls
			for (int i = 0; i < 8; i++)
			{
				grpBUBExpectedTiming.Controls["txtBUBExTmTime" + i.ToString()].Text = "";
				((CheckBox)grpBUBExpectedTiming.Controls["chkBUBExTmPurge" + i.ToString()]).Checked = false;
				((CheckBox)grpBUBExpectedTiming.Controls["chkBUBExTmTank" + i.ToString()]).Checked = false;
				((CheckBox)grpBUBExpectedTiming.Controls["chkBUBExTmMeasure" + i.ToString()]).Checked = false;
				((CheckBox)grpBUBExpectedTiming.Controls["chkBUBExTmReadSensor" + i.ToString()]).Checked = false;
			}

			foreach(ModularBubblerChannel mbc in m_LocalChannels)
				if (mbc.ModularBubblerAddress == m_iCurrentAddress && mbc.Channel == m_iCurrentChannel)
				{
					for (int i = 0; i < 8; i++)
					{
						grpBUBExpectedTiming.Controls["txtBUBExTmTime" + i.ToString()].Text = mbc.Time[i].ToString();
						((CheckBox)grpBUBExpectedTiming.Controls["chkBUBExTmPurge" + i.ToString()]).Checked = mbc.PurgeValve[i];
						((CheckBox)grpBUBExpectedTiming.Controls["chkBUBExTmTank" + i.ToString()]).Checked = mbc.TankValve[i];
						((CheckBox)grpBUBExpectedTiming.Controls["chkBUBExTmMeasure" + i.ToString()]).Checked = mbc.Measure[i];
						((CheckBox)grpBUBExpectedTiming.Controls["chkBUBExTmReadSensor" + i.ToString()]).Checked = mbc.ReadSensor[i];
					}
				}
		}

		private void SaveChannelValuesLocal()
		{
			string sBoardType = "";
			DataTable dt = (DataTable)customXceedGridControl.DataSource;
			
			foreach (DataRow dr in dt.Rows)
				if (Convert.ToInt32(dr["Channel"]) == m_iCurrentChannel)
					sBoardType = dr["BoardType"].ToString();

			foreach (ModularBubblerChannel mbc in m_LocalChannels)
				if (mbc.ModularBubblerAddress == m_iCurrentAddress && mbc.Channel == m_iCurrentChannel)
				{
					mbc.BoardType = sBoardType;

					ushort iTiming = 0;
					for (int i = 0; i < 8; i++)
					{
						if (!ushort.TryParse(grpBUBExpectedTiming.Controls["txtBUBExTmTime" + i.ToString()].Text, out iTiming))
							iTiming = mbc.Time[i];

						mbc.Time[i] = iTiming;
						mbc.PurgeValve[i] = ((CheckBox)grpBUBExpectedTiming.Controls["chkBUBExTmPurge" + i.ToString()]).Checked;
						mbc.TankValve[i] = ((CheckBox)grpBUBExpectedTiming.Controls["chkBUBExTmTank" + i.ToString()]).Checked;
						mbc.Measure[i] = ((CheckBox)grpBUBExpectedTiming.Controls["chkBUBExTmMeasure" + i.ToString()]).Checked;
						mbc.ReadSensor[i] = ((CheckBox)grpBUBExpectedTiming.Controls["chkBUBExTmReadSensor" + i.ToString()]).Checked;
					}
				}
		}
		
		private void SaveChanges()
		{
			DataTable dt = (DataTable)customXceedGridControl.DataSource;

			TLIConfiguration.Vessel.ModularBubberChannelArray.Clear();

			foreach (ModularBubblerChannel mbc in m_LocalChannels)
				TLIConfiguration.Vessel.ModularBubberChannelArray.Add(mbc.Copy());
		}

		private void cboModularBubblerAddress_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_iCurrentAddress > 0 && m_iCurrentChannel > 0)
				SaveChannelValuesLocal();

			m_iCurrentAddress = Convert.ToInt32(cboModularBubblerAddress.Items[cboModularBubblerAddress.SelectedIndex]);
			m_iCurrentChannel = 0;

			PopulateGrid();
		}

		private void customXceedGridControl_SelectedRowsChanged(object sender, EventArgs e)
		{
			if (customXceedGridControl.SelectedRows.Count == 0)
				return;

			if (typeof(Xceed.Grid.DataRow) == customXceedGridControl.SelectedRows[0].GetType())
			{
				if (m_iCurrentAddress > 0 && m_iCurrentChannel > 0)
					SaveChannelValuesLocal();

				m_iCurrentChannel = Convert.ToInt32(((Xceed.Grid.DataRow)customXceedGridControl.SelectedRows[0]).Cells["Channel"].Value);
				SetChannelTimingControls();
			}
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

		private void cmdRestoreDefaults_Click(object sender, EventArgs e)
		{
			if (m_iCurrentAddress == 0 || m_iCurrentChannel == 0)
				return;

			foreach (ModularBubblerChannel mbc in m_LocalChannels)
				if (mbc.ModularBubblerAddress == m_iCurrentAddress && mbc.Channel == m_iCurrentChannel)
				{
					mbc.SetToDefaults();
					SetChannelTimingControls();
					break;
				}
		}

		private void cmdSetAlike_Click(object sender, EventArgs e)
		{
			if (m_iCurrentAddress == 0 || m_iCurrentChannel == 0)
				return;

			SaveChannelValuesLocal();

			foreach(ModularBubblerChannel mbcSetLike in m_LocalChannels)
				if (mbcSetLike.ModularBubblerAddress == m_iCurrentAddress && mbcSetLike.Channel == m_iCurrentChannel)
				{
					foreach (ModularBubblerChannel mbc in m_LocalChannels)
						if (mbc.ModularBubblerAddress == m_iCurrentAddress && mbc.Channel != m_iCurrentChannel)
							mbcSetLike.CopyTo(mbc);

					break;
				}
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
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["BoardType"], "Board Type", e);
			}

			m_EditRow = null;
		}

		public bool RebuildEquipment
		{
			get { return m_bRebuildEquipment; }
		}
	}
}