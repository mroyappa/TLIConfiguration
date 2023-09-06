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
 * CLASS SUMMARY:	AlarmGroupEdit
 * 
 * AlarmGroupEdit is the form used to Add/Edit/Delete a Vessel's Alarm Group list.  It is no longer used.
 * 
 */

namespace TLIConfiguration
{
	public partial class AlarmGroupEdit : Form
	{
		private DataTable m_dtDataTable;

		private CustomColumnManagerRow m_CustomColumnManagerRow;
		private Xceed.Grid.InsertionRow m_InsertionRow;
		private Xceed.Grid.DataRow m_EditRow;
		private Xceed.Grid.SpacerRow m_SpacerRow;

		private int m_iIndex;

		public AlarmGroupEdit()
		{
			InitializeComponent();

			m_iIndex = 0;
		}

		private void AlarmGroupEdit_Load(object sender, EventArgs e)
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

				customXceedGridControl.AllowDelete = false;

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
				customXceedGridControl.AddBoundColumn("AlarmGroupName", "AlarmGroup", true, false, 150);

				customXceedGridControl.ExpandToFitColumn = customXceedGridControl.Columns["AlarmGroupName"];

				customXceedGridControl.Columns["AlarmGroupName"].SortDirection = Xceed.Grid.SortDirection.Ascending;

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

				customXceedGridControl.HideUnwantedGridColumns(new string[] { "AlarmGroupName" });
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
			m_dtDataTable.Columns.Add("AlarmGroupName", typeof(string));

			foreach (AlarmGroup ag in TLIConfiguration.Vessel.AlarmGroup)
			{
				dr = m_dtDataTable.NewRow();

				dr["Index"] = m_iIndex++;
				dr["AlarmGroupName"] = ag.AlarmGroupName;

				m_dtDataTable.Rows.Add(dr);
				dr.AcceptChanges();
			}
		}

		private void InitializingNewDataRow(object sender, Xceed.Grid.InitializingNewDataRowEventArgs e)
		{
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
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_InsertionRow.Cells["AlarmGroupName"], "Alarm Group", e);
				if (!e.Cancel) ValidateNewRow(m_InsertionRow, e);
				if (!e.Cancel) m_InsertionRow.Cells["Index"].Value = m_iIndex++;
			}
			else if (m_EditRow != null)
			{
				if (!e.Cancel) customXceedGridControl.EnforceNonBlankCell(m_EditRow.Cells["AlarmGroupName"], "Alarm Group", e);
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
				if ((string)dr["AlarmGroupName"] == (string)insertionRow.Cells["AlarmGroupName"].Value)
				{
					MessageBox.Show("This Alarm Group name has already been defined.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
					if ((string)dr["AlarmGroupName"] == (string)editRow.Cells["AlarmGroupName"].Value)
					{
						MessageBox.Show("This Alarm Group name has already been defined.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
						e.Cancel = true;
						return;
					}
				}
			}
		}

		private void SaveChanges()
		{
			DataTable dt = (DataTable)customXceedGridControl.DataSource;

			TLIConfiguration.Vessel.AlarmGroup.Clear();

			foreach (DataRow dr in dt.Rows)
			{
				if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Unchanged)
					TLIConfiguration.Vessel.AlarmGroup.Add(new AlarmGroup(dr["AlarmGroupName"].ToString()));
				else if (dr.RowState == DataRowState.Modified)
				{
					TLIConfiguration.Vessel.AlarmGroup.Add(new AlarmGroup(dr["AlarmGroupName"].ToString()));
					UpdateAlarmGroupInVessselConfiguration(dr);
				}
			}
		}

		private void UpdateAlarmGroupInVessselConfiguration(DataRow dr)
		{
			string sOriginalAlarmGroup = dr["AlarmGroupName", DataRowVersion.Original].ToString();
			string sNewAlarmGroup = dr["AlarmGroupName"].ToString();

			foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
			{
				foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[eu.EquipmentID].Values)
				{
					foreach (AlarmPoint ap in TLIConfiguration.VesselAlarmPoints[eu.EquipmentID][gp.ProcessID].Values)
					{
						if (ap.AlarmGroup == sOriginalAlarmGroup)
							ap.AlarmGroup = sNewAlarmGroup;
					}
				}
			}
		}
	}
}