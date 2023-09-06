using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

/*
 * CLASS SUMMARY:	RedundantModbusPointExceptions
 * 
 * RedundantModbusPointExceptions is the form used to identify and display redundant Modbus Input points.
 * 
 */

namespace TLIConfiguration
{
	public partial class RedundantModbusPointExceptions : Form
	{
		Dictionary<string, RedundantModbusPoint> m_rapModbusPoints;

		private DataTable m_dtDataTable;
		private CustomColumnManagerRow m_CustomColumnManagerRow;
		private Xceed.Grid.SpacerRow m_SpacerRow;

		public RedundantModbusPointExceptions()
		{
			InitializeComponent();

			m_rapModbusPoints = new Dictionary<string, RedundantModbusPoint>();
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

				customXceedGridControl.AddBoundColumn("EquipmentType", "Equipment Type", true, false, 75);
				customXceedGridControl.AddBoundColumn("EquipmentName", "Equipment", true, false, 75);
				customXceedGridControl.AddBoundColumn("GaugeType", "Gauge Type", true, false, 75);
				customXceedGridControl.AddBoundColumn("Alarm", "Alarm", true, false, 75);
				customXceedGridControl.AddBoundColumn("AlarmText", "Alarm", true, false, 75);
				customXceedGridControl.AddBoundColumn("Register1", "Register LW", true, false, 75);
				customXceedGridControl.AddBoundColumn("Register2", "Register HW", true, false, 75);

				customXceedGridControl.ExpandToFitColumn = customXceedGridControl.Columns["EquipmentType"];

				customXceedGridControl.Columns["Register1"].SortDirection = Xceed.Grid.SortDirection.Ascending;

//				group1.GroupBy = "AMUAddress";

				customXceedGridControl.EndInit();
			}
			catch (Exception e)
			{
				MessageBox.Show("Error retrieving Modbus data.\n" + e.Message, "TLI Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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

				customXceedGridControl.HideUnwantedGridColumns(new string[] { "EquipmentType", "EquipmentName", "GaugeType", "Alarm", "AlarmText", "Register1", "Register2" });
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

			m_dtDataTable.Columns.Add("EquipmentType", typeof(string));
			m_dtDataTable.Columns.Add("EquipmentName", typeof(string));
			m_dtDataTable.Columns.Add("GaugeType", typeof(string));
			m_dtDataTable.Columns.Add("Alarm", typeof(bool));
			m_dtDataTable.Columns.Add("AlarmText", typeof(string));
			m_dtDataTable.Columns.Add("Register1", typeof(string));
			m_dtDataTable.Columns.Add("Register2", typeof(string));

			foreach (RedundantModbusPoint rap in m_rapModbusPoints.Values)
			{
				dr = m_dtDataTable.NewRow();

				dr["EquipmentType"] = rap.EquipmentType;
				dr["EquipmentName"] = rap.EquipmentName;
				dr["GaugeType"] = rap.GaugeType;
				dr["Alarm"] = rap.Alarm;
				dr["AlarmText"] = rap.AlarmText;
				dr["Register1"] = rap.Register1.ToString();
				dr["Register2"] = rap.Register2 == 0 ? "" : rap.Register2.ToString();

				m_dtDataTable.Rows.Add(dr);
				dr.AcceptChanges();
			}
		}

		private void cmdOk_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		public Dictionary<string, RedundantModbusPoint> RedundantModbusPoints
		{
			get { return m_rapModbusPoints; }
			set { m_rapModbusPoints = value; }
		}
	}
}