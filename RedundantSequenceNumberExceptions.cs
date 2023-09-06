using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

/*
 * CLASS SUMMARY:	RedundantSequenceNumberExceptions
 * 
 * RedundantSequenceNumberExceptions is the form used to identify and display redundant Export Order Sequence Numbers.
 * 
 */

namespace TLIConfiguration
{
	public partial class RedundantSequenceNumberExceptions : Form
	{
		Dictionary<string, RedundantSequenceNumber> m_rsnSequenceNumber;

		private DataTable m_dtDataTable;
		private CustomColumnManagerRow m_CustomColumnManagerRow;
		private Xceed.Grid.SpacerRow m_SpacerRow;

		public RedundantSequenceNumberExceptions()
		{
			InitializeComponent();

			m_rsnSequenceNumber = new Dictionary<string, RedundantSequenceNumber>();
		}

		private void RedundantSequenceNumberExceptions_Load(object sender, EventArgs e)
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
				customXceedGridControl.AddBoundColumn("SequenceNumber", "Sequence Number", true, false, 150);

				customXceedGridControl.ExpandToFitColumn = customXceedGridControl.Columns["EquipmentUnitDisplayName"];

				customXceedGridControl.Columns["SequenceNumber"].SortDirection = Xceed.Grid.SortDirection.Ascending;

				group1.GroupBy = "SequenceNumber";

				customXceedGridControl.EndInit();
			}
			catch (Exception e)
			{
				MessageBox.Show("Error retrieving Sequence Number data.\n" + e.Message, "TLI Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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

				customXceedGridControl.HideUnwantedGridColumns(new string[] { "EquipmentUnitDisplayName", "SequenceNumber" });
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

			m_dtDataTable.Columns.Add("EquipmentID", typeof(string));
			m_dtDataTable.Columns.Add("EquipmentUnitDisplayName", typeof(string));
			m_dtDataTable.Columns.Add("SequenceNumber", typeof(int));

			foreach (RedundantSequenceNumber rsn in m_rsnSequenceNumber.Values)
			{
				dr = m_dtDataTable.NewRow();

				dr["EquipmentID"] = rsn.EquipmentID;
				dr["EquipmentUnitDisplayName"] = rsn.EquipmentUnitDisplayName;
				dr["SequenceNumber"] = rsn.SequenceNumber;

				m_dtDataTable.Rows.Add(dr);
				dr.AcceptChanges();
			}
		}

		private void cmdOk_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		public Dictionary<string, RedundantSequenceNumber> RedundantSequenceNumbers
		{
			get { return m_rsnSequenceNumber; }
			set { m_rsnSequenceNumber = value; }
		}
	}
}