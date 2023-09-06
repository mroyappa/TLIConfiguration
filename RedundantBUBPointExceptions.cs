using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

/*
 * CLASS SUMMARY:	RedundantBUBPointExceptions
 * 
 * RedundantBUBPointExceptions is the form used to identify and display redundant BUB points.
 * 
 */

namespace TLIConfiguration
{
	public partial class RedundantBUBPointExceptions : Form
	{
		Dictionary<string, RedundantBUBPoint> m_rapBUBPoints;

		private DataTable m_dtDataTable;
		private CustomColumnManagerRow m_CustomColumnManagerRow;
		private Xceed.Grid.SpacerRow m_SpacerRow;

		public RedundantBUBPointExceptions()
		{
			InitializeComponent();

			m_rapBUBPoints = new Dictionary<string, RedundantBUBPoint>();
		}

		private void RedundantAMUPointExceptions_Load(object sender, EventArgs e)
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

//				customXceedGridControl.InitializingNewDataRow += new Xceed.Grid.InitializingNewDataRowEventHandler(InitializingNewDataRow);

				// Custom Column Manager Row
				m_CustomColumnManagerRow = new CustomColumnManagerRow();
				m_CustomColumnManagerRow.BackColor = System.Drawing.Color.White;
				m_CustomColumnManagerRow.ForeColor = System.Drawing.Color.Black;
				m_CustomColumnManagerRow.Height = 17;
				customXceedGridControl.FixedHeaderRows.Add(m_CustomColumnManagerRow);


				// Spacer Row
				m_SpacerRow = new Xceed.Grid.SpacerRow();
				m_SpacerRow.Height = 4;
				customXceedGridControl.FixedHeaderRows.Add(m_SpacerRow);

				// RowSelectorPane
				customXceedGridControl.RowSelectorPane.Visible = false;

				customXceedGridControl.AddBoundColumn("EquipmentUnitDisplayName", "Equipment Unit", true, false, 150);
				customXceedGridControl.AddBoundColumn("GaugePointDisplayName", "Gauge Point", true, false, 150);
				customXceedGridControl.AddBoundColumn("BUBAddress", "BUB Address", true, false, 100);
				customXceedGridControl.AddBoundColumn("BUBChannel", "Channel", true, false, 75);

				customXceedGridControl.ExpandToFitColumn = customXceedGridControl.Columns["EquipmentUnitDisplayName"];

				customXceedGridControl.Columns["BUBChannel"].SortDirection = Xceed.Grid.SortDirection.Ascending;

				group1.GroupBy = "BUBAddress";

				customXceedGridControl.EndInit();
			}
			catch (Exception e)
			{
				MessageBox.Show("Error retrieving BUB data.\n" + e.Message, "TLI Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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

				customXceedGridControl.HideUnwantedGridColumns(new string[] { "EquipmentUnitDisplayName", "GaugePointDisplayName", "BUBAddress", "BUBChannel" });
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

			m_dtDataTable.Columns.Add("ProcessID", typeof(string));
			m_dtDataTable.Columns.Add("EquipmentUnitDisplayName", typeof(string));
			m_dtDataTable.Columns.Add("GaugePointDisplayName", typeof(string));
			m_dtDataTable.Columns.Add("BUBAddress", typeof(int));
			m_dtDataTable.Columns.Add("BUBChannel", typeof(int));

			foreach (RedundantBUBPoint rap in m_rapBUBPoints.Values)
			{
				dr = m_dtDataTable.NewRow();

				dr["ProcessID"] = rap.ProcessID;
				dr["EquipmentUnitDisplayName"] = rap.EquipmentUnitDisplayName;
				dr["GaugePointDisplayName"] = rap.GaugePointDisplayName;
				dr["BUBAddress"] = rap.BUBAddress;
				dr["BUBChannel"] = rap.BUBChannel;

				m_dtDataTable.Rows.Add(dr);
				dr.AcceptChanges();
			}
		}

		private void cmdOk_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		public Dictionary<string, RedundantBUBPoint> RedundantBUBPoints
		{
			get { return m_rapBUBPoints; }
			set { m_rapBUBPoints = value; }
		}
	}
}