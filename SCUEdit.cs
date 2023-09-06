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
 * CLASS SUMMARY:	SCUEdit
 * 
 * SCUEdit is the form used to Add/Edit/Delete a Vessel's list of SCUs.
 * 
 */

namespace TLIConfiguration
{
	public partial class SCUEdit : Form
	{
		private DataTable m_dtDataTable;

		private CustomColumnManagerRow m_CustomColumnManagerRow;
		private Xceed.Grid.InsertionRow m_InsertionRow;
		private Xceed.Grid.DataRow m_EditRow;
		private Xceed.Grid.SpacerRow m_SpacerRow;

		private int m_iIndex;

		public SCUEdit()
		{
			InitializeComponent();

			m_iIndex = 0;
		}

		private void SCUEdit_Load(object sender, EventArgs e)
		{
			SetupGrid();
			PopulateGrid();
		}

		private void SetupGrid()
		{
			try
			{
				customXceedGridControl.SetupGridControl();
				customXceedGridControl.BeginInit();

				customXceedGridControl.AllowDelete = true;

//				customXceedGridControl.SingleClickEdit = true;

				columnManagerRow1.Remove();

				customXceedGridControl.InitializingNewDataRow += new Xceed.Grid.InitializingNewDataRowEventHandler(InitializingNewDataRow);

				// Custom Column Manager Row
				m_CustomColumnManagerRow = new CustomColumnManagerRow();
				m_CustomColumnManagerRow.BackColor = System.Drawing.Color.White;
				m_CustomColumnManagerRow.ForeColor = System.Drawing.Color.Black;
				m_CustomColumnManagerRow.Height = 17;
				customXceedGridControl.FixedHeaderRows.Add(m_CustomColumnManagerRow);

				// Insertion Row
				m_InsertionRow = new Xceed.Grid.InsertionRow();
				m_InsertionRow.ForeColor = Color.FromArgb(29, 50, 139);
				m_InsertionRow.BackColor = Color.FromArgb(244, 244, 244);
				customXceedGridControl.FixedHeaderRows.Add(m_InsertionRow);

				m_InsertionRow.EndingEdit += new CancelEventHandler(EndingEdit);

				// Spacer Row
				m_SpacerRow = new Xceed.Grid.SpacerRow();
				m_SpacerRow.Height = 4;
				customXceedGridControl.FixedHeaderRows.Add(m_SpacerRow);

				// RowSelectorPane
				customXceedGridControl.RowSelectorPane.Visible = false;

				customXceedGridControl.AddBoundColumn("Index", "Index", false, false, 100);
				customXceedGridControl.AddBoundColumn("TankName", "Tank Name", true, false, 80);
				customXceedGridControl.AddBoundColumn("TAUAddress", "TAU Address", true, false, 80);
				customXceedGridControl.AddBoundColumn("SCUChannel", "SCU Channel", true, false, 80);
				customXceedGridControl.AddBoundColumn("TopFloatName", "Top Float Name", true, false, 115);
				customXceedGridControl.AddBoundColumn("UllageHatch", "Ullage Hatch", true, false, 115);
				customXceedGridControl.AddBoundColumn("LF", "Level Full", true, false, 115);
				customXceedGridControl.AddBoundColumn("BottomOffset", "Bottom Offset", true, false, 115);
				customXceedGridControl.AddBoundColumn("DensityOffset", "Density Offset", true, false, 115);
				customXceedGridControl.AddBoundColumn("Config1", "Config 1", true, false, 80);
				customXceedGridControl.AddBoundColumn("Config2", "Config 2", true, false, 80);
				customXceedGridControl.AddBoundColumn("AutoZeroRange", "Auto-Zero Range", true, false, 115);
				customXceedGridControl.AddBoundColumn("AutoZeroTimeout", "Auto-Zero Timeout", true, false, 115);

				customXceedGridControl.ExpandToFitColumn = customXceedGridControl.Columns["TankName"];

				customXceedGridControl.Columns["TankName"].SortDirection = Xceed.Grid.SortDirection.Ascending;

				customXceedGridControl.EndInit();
			}
			catch (Exception e)
			{
				MessageBox.Show("Error retrieving configuration data.\n" + e.Message, "TLI Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
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

				customXceedGridControl.HideUnwantedGridColumns(new string[] { "TankName", "TAUAddress", "SCUChannel", "TopFloatName", "LF", "UllageHatch", "BottomOffset", "DensityOffset", "Config1", "Config2", "AutoZeroRange", "AutoZeroTimeout" });
			}
			catch (Exception e)
			{
				MessageBox.Show("Error retrieving configuration data.\n" + e.Message, "TLI Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
		}

		private void FillDataTable()
		{
			DataRow dr;
			m_dtDataTable = new DataTable();
			m_dtDataTable.Columns.Add("Index", typeof(int));
			m_dtDataTable.Columns.Add("TankName", typeof(string));
			m_dtDataTable.Columns.Add("TAUAddress", typeof(int));
			m_dtDataTable.Columns.Add("SCUChannel", typeof(int));
			m_dtDataTable.Columns.Add("TopFloatName", typeof(string));
			m_dtDataTable.Columns.Add("LF", typeof(float));
			m_dtDataTable.Columns.Add("UllageHatch", typeof(float));
			m_dtDataTable.Columns.Add("BottomOffset", typeof(float));
			m_dtDataTable.Columns.Add("DensityOffset", typeof(float));
			m_dtDataTable.Columns.Add("Config1", typeof(byte));
			m_dtDataTable.Columns.Add("Config2", typeof(byte));
			m_dtDataTable.Columns.Add("AutoZeroRange", typeof(float));
			m_dtDataTable.Columns.Add("AutoZeroTimeout", typeof(int));

			foreach (SCU scu in TLIConfiguration.Vessel.SCUArray)
			{
				dr = m_dtDataTable.NewRow();

				dr["Index"] = m_iIndex++;
				dr["TankName"] = scu.TankName;
				dr["TAUAddress"] = scu.TAUAddress;
				dr["SCUChannel"] = scu.SCUChannel;
				dr["TopFloatName"] = scu.TopFloatName;
				dr["LF"] = scu.LF;
				dr["UllageHatch"] = scu.UllageHatch;
				dr["BottomOffset"] = scu.BottomOffset;
				dr["DensityOffset"] = scu.DensityOffset;
				dr["Config1"] = scu.Config1;
				dr["Config2"] = scu.Config2;
				dr["AutoZeroRange"] = scu.AutoZeroRange;
				dr["AutoZeroTimeout"] = scu.AutoZeroTimeout;

				m_dtDataTable.Rows.Add(dr);
				dr.AcceptChanges();
			}
		}

		private void InitializingNewDataRow(object sender, Xceed.Grid.InitializingNewDataRowEventArgs e)
		{
			int iMaxChannel = 0;

			foreach (DataRow dr in m_dtDataTable.Rows)
				if (Convert.ToInt32(dr["SCUChannel"]) > iMaxChannel)
					iMaxChannel = Convert.ToInt32(dr["SCUChannel"]);

			e.DataRow.Cells["TankName"].Value = "Tank";
			e.DataRow.Cells["TAUAddress"].Value = 25;
			e.DataRow.Cells["SCUChannel"].Value = iMaxChannel + 1;
			e.DataRow.Cells["TopFloatName"].Value = "TopFloat";
			e.DataRow.Cells["LF"].Value = 0.0F;
			e.DataRow.Cells["UllageHatch"].Value = 0.0F;
			e.DataRow.Cells["BottomOffset"].Value = 0.0F;
			e.DataRow.Cells["DensityOffset"].Value = 0.0F;
			e.DataRow.Cells["Config1"].Value = 0x00;
			e.DataRow.Cells["Config2"].Value = 0x00;
			e.DataRow.Cells["AutoZeroRange"].Value = 0.0F;
			e.DataRow.Cells["AutoZeroTimeout"].Value = 0;
		}

		private void AddingDataRow(object sender, Xceed.Grid.AddingDataRowEventArgs e)
		{
			e.DataRow.BeginningEdit += new CancelEventHandler(BeginningEdit);
			e.DataRow.EndingEdit += new CancelEventHandler(EndingEdit);
		}

		private void BeginningEdit(object sender, CancelEventArgs e)
		{
			m_EditRow = (Xceed.Grid.DataRow)sender;
		}

		// HACK
		private void EndingEdit(object sender, CancelEventArgs e)
		{
			if (Disposing)
				return;

			if (m_EditRow == null)
			{
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["TankName"], "Tank Name", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["TAUAddress"], "TAU Address", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["SCUChannel"], "SCU Channel", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["TopFloatName"], "Top Float Name", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["LF"], "LF", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["UllageHatch"], "Ullage Hatch", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["BottomOffset"], "Bottom Offset", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["DensityOffset"], "Density Offset", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["Config1"], "Config 1", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["Config2"], "Config 2", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["AutoZeroRange"], "Auto-Zero Range", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["AutoZeroTimeout"], "Auto-Zero Timeout", e);
				if (!e.Cancel) ValidateNewRow(m_InsertionRow, e);
				if (!e.Cancel) m_InsertionRow.Cells["Index"].Value = m_iIndex++;
			}
			else if (m_EditRow != null)
			{
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["TankName"], "Tank Name", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["TAUAddress"], "TAU Address", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["SCUChannel"], "SCU Channel", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["TopFloatName"], "Top Float Name", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["LF"], "LF", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["UllageHatch"], "Ullage Hatch", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["BottomOffset"], "Bottom Offset", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["DensityOffset"], "Density Offset", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["Config1"], "Config 1", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["Config2"], "Config 2", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["AutoZeroRange"], "Auto-Zero Range", e);
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["AutoZeroTimeout"], "Auto-Zero Timeout", e);
				if (!e.Cancel) ValidateEditRow(m_EditRow, e);
			}

			m_EditRow = null;
		}

		private void cmdOk_Click(object sender, EventArgs e)
		{
			SaveChanges();
			this.Close();
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ValidateNewRow(Xceed.Grid.InsertionRow insertionRow, CancelEventArgs e)
		{
			DataTable dt = (DataTable)customXceedGridControl.DataSource;

			foreach (DataRow dr in dt.Rows)
			{
				if ((int)dr["TAUAddress"] == (int)insertionRow.Cells["TAUAddress"].Value && (int)dr["SCUChannel"] == (int)insertionRow.Cells["SCUChannel"].Value)
				{
					MessageBox.Show("This TAU Address and SCU Channel have already been used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					e.Cancel = true;
					return;
				}
			}
		}

		private void ValidateEditRow(Xceed.Grid.DataRow editRow, CancelEventArgs e)
		{
			DataTable dt = (DataTable)customXceedGridControl.DataSource;

			foreach (DataRow dr in dt.Rows)
			{
				if ((int)dr["Index"] != (int)editRow.Cells["Index"].Value)
				{
					if ((int)dr["TAUAddress"] == (int)editRow.Cells["TAUAddress"].Value && (int)dr["SCUChannel"] == (int)editRow.Cells["SCUChannel"].Value)
					{
						MessageBox.Show("This TAU Address and SCU Channel have already been used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
						e.Cancel = true;
						return;
					}
				}
			}
		}

		private void SaveChanges()
		{
			DataTable dt = (DataTable)customXceedGridControl.DataSource;

			TLIConfiguration.Vessel.SCUArray.Clear();

			foreach (DataRow dr in dt.Rows)
			{
				if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Unchanged || dr.RowState == DataRowState.Modified)
					TLIConfiguration.Vessel.SCUArray.Add(new SCU(
						Convert.ToInt32(dr["TAUAddress"]),
						Convert.ToInt32(dr["SCUChannel"]),
						Convert.ToSingle(dr["LF"]),
						Convert.ToSingle(dr["UllageHatch"]),
						Convert.ToByte(dr["Config1"]),
						Convert.ToByte(dr["Config2"]),
						0x00,
						0x00,
						Convert.ToSingle(dr["BottomOffset"]),
						0,
						0,
						Convert.ToSingle(dr["DensityOffset"]),
						dr["TopFloatName"].ToString(),
						"",
						dr["TankName"].ToString(),
						Convert.ToSingle(dr["AutoZeroRange"]),
						Convert.ToInt32(dr["AutoZeroTimeout"]),
						0));
			}
		}
	}
}