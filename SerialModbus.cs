using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using ICBObjectModel;
using ICBObjectModel.Enumerations;

/*
 * CLASS SUMMARY:	SerialModbus
 *
 * SerialModbus is the form used to configure GaugePoints for use in the Serial Modbus Slave.
 * 
 */

namespace TLIConfiguration
{
	public partial class SerialModbus : Form
	{
		private DataTable m_dtGauge;
		private DataTable m_dtAlarm;

		private CustomColumnManagerRow m_CustomColumnManagerGaugeRow;
		private Xceed.Grid.DataRow m_EditGaugeRow;
		private Xceed.Grid.SpacerRow m_SpacerGaugeRow;

		private CustomColumnManagerRow m_CustomColumnManagerAlarmRow;
		private Xceed.Grid.DataRow m_EditAlarmRow;
		private Xceed.Grid.SpacerRow m_SpacerAlarmRow;

		private ushort m_iCurrentBase = 0;

		public SerialModbus()
		{
			InitializeComponent();
		}

		private void SerialModbus_Load(object sender, EventArgs e)
		{
			cboAddressRange.Items.Add("3xxxx");
			cboAddressRange.Items.Add("4xxxx");

			SetupAlarmGrid();
			PopulateAlarmGrid();

			SetupGaugeGrid();
			PopulateGaugeGrid();

			BindControls();
		}

		private void BindControls()
		{
			Console.WriteLine("BASE : " + m_iCurrentBase);
			if (m_iCurrentBase == 30000)
				cboAddressRange.SelectedIndex = 0;
			else if (m_iCurrentBase == 40000)
				cboAddressRange.SelectedIndex = 1;
			else
				cboAddressRange.SelectedIndex = 0;

			chkIncludeSystemStatus.Checked = TLIConfiguration.Vessel.IncludeSystemStatusModbusSerial;

			cboAddressRange.SelectedIndexChanged += new EventHandler(CboAddressRange_SelectedIndexChanged);
		}

		private void SetupGaugeGrid()
		{
			try
			{
				gcGauge.SetupGridControl();
				gcGauge.BeginInit();

				gcGauge.AllowDelete = false;
				gcGauge.SingleClickEdit = false;

				columnManagerRow1.Remove();

				// Custom Column Manager Row
				m_CustomColumnManagerGaugeRow = new CustomColumnManagerRow();
				m_CustomColumnManagerGaugeRow.BackColor = System.Drawing.Color.White;
				m_CustomColumnManagerGaugeRow.ForeColor = System.Drawing.Color.Black;
				m_CustomColumnManagerGaugeRow.Height = 17;
				gcGauge.FixedHeaderRows.Add(m_CustomColumnManagerGaugeRow);

				// Spacer Row
				m_SpacerGaugeRow = new Xceed.Grid.SpacerRow();
				m_SpacerGaugeRow.Height = 4;
				gcGauge.FixedHeaderRows.Add(m_SpacerGaugeRow);

				// RowSelectorPane
				gcGauge.RowSelectorPane.Visible = false;

				gcGauge.AddBoundColumn("ProcessID", "ProcessID", false, true, 1);
				gcGauge.AddBoundColumn("EquipmentName", "Equipment", true, true, 150);
				gcGauge.AddBoundColumn("GaugeName", "Gauge", true, true, 150);
				gcGauge.AddBoundColumn("GaugeSort", "GaugeSort", false, false, 1);
				gcGauge.AddBoundColumn("ModbusDataType", "Data Type", true, false, 100);
				gcGauge.AddBoundColumn("RegisterAddress1", "Register LW", true, false, 100);
				gcGauge.AddBoundColumn("RegisterAddress2", "Register HW", true, true, 100);
				gcGauge.AddBoundColumn("Scale", "Scale", true, false, 75);

				Xceed.Grid.Editors.ComboBoxEditor cbe = new Xceed.Grid.Editors.ComboBoxEditor();
				cbe.Columns.Add(new Xceed.Editors.ColumnInfo("Data Type", typeof(string), 100));
				cbe.Items.Add("Float32");
				cbe.Items.Add("Int16");
				gcGauge.Columns["ModbusDataType"].CellEditorManager = cbe;

				gcGauge.Columns["RegisterAddress1"].DataComparer = new DBNullToBottomComparer();
				gcGauge.Columns["RegisterAddress1"].SortDirection = Xceed.Grid.SortDirection.Ascending;
				gcGauge.Columns["EquipmentName"].SortDirection = Xceed.Grid.SortDirection.Ascending;
				gcGauge.Columns["GaugeSort"].SortDirection = Xceed.Grid.SortDirection.Ascending;

//				gcGauge.ExpandToFitColumn = gcGauge.Columns["EquipmentName"];

				gcGauge.EndInit();
			}
			catch (Exception e)
			{
				MessageBox.Show("Error retrieving configuration data.\n" + e.Message, "TLI Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
		}

		private void SetupAlarmGrid()
		{
			try
			{
				gcAlarm.SetupGridControl();
				gcAlarm.BeginInit();

				gcAlarm.AllowDelete = false;
				gcAlarm.SingleClickEdit = false;

				columnManagerRow2.Remove();

				// Custom Column Manager Row
				m_CustomColumnManagerAlarmRow = new CustomColumnManagerRow();
				m_CustomColumnManagerAlarmRow.BackColor = System.Drawing.Color.White;
				m_CustomColumnManagerAlarmRow.ForeColor = System.Drawing.Color.Black;
				m_CustomColumnManagerAlarmRow.Height = 17;
				gcAlarm.FixedHeaderRows.Add(m_CustomColumnManagerAlarmRow);

				// Spacer Row
				m_SpacerAlarmRow = new Xceed.Grid.SpacerRow();
				m_SpacerAlarmRow.Height = 4;
				gcAlarm.FixedHeaderRows.Add(m_SpacerAlarmRow);

				// RowSelectorPane
				gcAlarm.RowSelectorPane.Visible = false;

				gcAlarm.AddBoundColumn("ProcessID", "ProcessID", false, true, 1);
				gcAlarm.AddBoundColumn("AlarmMonitorType", "AlarmMonitorType", false, true, 1);
				gcAlarm.AddBoundColumn("AlarmType", "AlarmType", false, true, 1);
				gcAlarm.AddBoundColumn("AlarmText", "AlarmText", false, true, 1);
				gcAlarm.AddBoundColumn("AlarmPriority", "AlarmPriority", false, true, 1);
				gcAlarm.AddBoundColumn("Comparator", "Comparator", false, true, 1);
				gcAlarm.AddBoundColumn("EquipmentName", "Equipment", true, true, 150);
				gcAlarm.AddBoundColumn("GaugeName", "Gauge", true, true, 200);
				gcAlarm.AddBoundColumn("AlarmName", "Alarm", true, true, 150);
				gcAlarm.AddBoundColumn("GaugeSort", "GaugeSort", false, false, 1);
				gcAlarm.AddBoundColumn("ModbusDataType", "Data Type", true, false, 100);
				gcAlarm.AddBoundColumn("RegisterAddress1", "Register", true, false, 100);

				gcAlarm.Columns["RegisterAddress1"].DataComparer = new DBNullToBottomComparer();
				gcAlarm.Columns["RegisterAddress1"].SortDirection = Xceed.Grid.SortDirection.Ascending;
				gcAlarm.Columns["EquipmentName"].SortDirection = Xceed.Grid.SortDirection.Ascending;
				gcAlarm.Columns["GaugeSort"].SortDirection = Xceed.Grid.SortDirection.Ascending;

//				gcAlarm.ExpandToFitColumn = gcAlarm.Columns["EquipmentName"];

				gcAlarm.EndInit();
			}
			catch (Exception e)
			{
				MessageBox.Show("Error retrieving configuration data.\n" + e.Message, "TLI Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
		}

		private void PopulateGaugeGrid()
		{
			try
			{
				FillGaugeDataTable();

				gcGauge.BeginInit();
				gcGauge.DataSource = m_dtGauge;
				gcGauge.DataMember = "";
				gcGauge.EndInit();

				gcGauge.HideUnwantedGridColumns(new string[] { "EquipmentName", "GaugeName", "ModbusDataType", "RegisterAddress1", "RegisterAddress2", "Scale" });
			}
			catch (Exception e)
			{
				MessageBox.Show("Error retrieving configuration data.\n" + e.StackTrace, "TLI Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
		}

		private void PopulateAlarmGrid()
		{
			try
			{
				FillAlarmDataTable();

				gcAlarm.BeginInit();
				gcAlarm.DataSource = m_dtAlarm;
				gcAlarm.DataMember = "";
				gcAlarm.EndInit();

				gcAlarm.HideUnwantedGridColumns(new string[] { "EquipmentName", "GaugeName", "AlarmName", "RegisterAddress1" });
			}
			catch (Exception e)
			{
				MessageBox.Show("Error retrieving configuration data.\n" + e.Message, "TLI Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
		}

		private void FillGaugeDataTable()
		{
			DataRow dr;
			m_dtGauge = new DataTable();

			m_dtGauge.Columns.Add("EquipmentID", typeof(string));
			m_dtGauge.Columns.Add("ProcessID", typeof(string));
			m_dtGauge.Columns.Add("ModbusInterfaceIndex", typeof(int));
			m_dtGauge.Columns.Add("EquipmentName", typeof(string));
			m_dtGauge.Columns.Add("GaugeName", typeof(string));
			m_dtGauge.Columns.Add("GaugeSort", typeof(int));
			m_dtGauge.Columns.Add("ModbusDataType", typeof(string));
			m_dtGauge.Columns.Add("RegisterAddress1", typeof(ushort));
			m_dtGauge.Columns.Add("RegisterAddress2", typeof(ushort));
			m_dtGauge.Columns.Add("Scale", typeof(float));

			foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
			{
				if (TLIConfiguration.VesselGaugePoints.ContainsKey(eu.EquipmentID))
				{
					//Console.WriteLine("count : " + TLIConfiguration.VesselGaugePoints[eu.EquipmentID].Values.Count);
					foreach (GaugePoint k in TLIConfiguration.VesselGaugePoints[eu.EquipmentID].Values)
					{
						Console.WriteLine("id : " + k.GaugeType + " " + k.ModbusInterfaceArray.Length);
					}
					foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[eu.EquipmentID].Values)
					{
						if (gp.GaugeType == GaugeType.PowerFail)
						{
							Console.WriteLine("POWER FAIL");
							int index = 0;

							dr = m_dtGauge.NewRow();

							dr["EquipmentID"] = eu.EquipmentID;
							dr["ProcessID"] = gp.ProcessID;
							dr["EquipmentName"] = eu.EquipmentTypeString + " - " + eu.Equipment;
							dr["GaugeName"] = "Power Fail";
							dr["GaugeSort"] = GaugeType.GetModbusGaugeSort(GaugeType.PowerFail, gp.GaugeNumber);

							dr["ModbusInterfaceIndex"] = index;
							gp.ModbusInterfaceArray[index].Enable = true;
							if (gp.ModbusInterfaceArray != null && gp.ModbusInterfaceArray[index].Enable &&
									gp.ModbusInterfaceArray[index].RegisterAddress1 > 0)
							{
								dr["ModbusDataType"] = ModbusDataType.GetModbusDataTypeString(gp.ModbusInterfaceArray[index].ModbusDataType);
								dr["RegisterAddress1"] = gp.ModbusInterfaceArray[index].RegisterAddress1;
								dr["Scale"] = gp.ModbusInterfaceArray[index].Scale;
							}

							m_dtGauge.Rows.Add(dr);
						}
						else if (gp.GaugeType != GaugeType.ChannelStateAlarmMonitor)
						{
							dr = m_dtGauge.NewRow();

							dr["EquipmentID"] = eu.EquipmentID;
							dr["ProcessID"] = gp.ProcessID;
							dr["EquipmentName"] = eu.EquipmentTypeString + " - " + eu.Equipment;
							dr["GaugeName"] = gp.GaugeTypeStringExtended;
							dr["GaugeSort"] = GaugeType.GetModbusGaugeSort(gp.GaugeType, gp.GaugeNumber);

							dr["ModbusInterfaceIndex"] = 0;

							if (gp.ModbusInterfaceArray != null)
							{
								if (gp.ModbusInterfaceArray[0] != null)
								{
									if (gp.ModbusInterfaceArray[0].Enable &&
										gp.ModbusInterfaceArray[0].RegisterAddress1 > 0)
									{
											Console.WriteLine("COME CORRECT :) " + m_iCurrentBase);
										if (gp.ModbusInterfaceArray[0].RegisterAddress1 > 40000)
										{
											m_iCurrentBase = 40000;
                                            //cboAddressRange.SelectedItem = "4xxxx";
                                            cboAddressRange.SelectedIndex = 1;
                                        }
										else
										{
											m_iCurrentBase = 30000;
											cboAddressRange.SelectedIndex = 0;
										}
											
										dr["ModbusDataType"] = ModbusDataType.GetModbusDataTypeString(gp.ModbusInterfaceArray[0].ModbusDataType);
										dr["RegisterAddress1"] = gp.ModbusInterfaceArray[0].RegisterAddress1;
										dr["Scale"] = gp.ModbusInterfaceArray[0].Scale;

										if(gp.ModbusInterfaceArray[0].ModbusDataType == ModbusDataType.Float32)
											dr["RegisterAddress2"] = gp.ModbusInterfaceArray[0].RegisterAddress2;
									}
								}
							}

							m_dtGauge.Rows.Add(dr);

							// Add sounding values and % capacity

							if ((eu.EquipmentType == EquipmentType.Cargo ||
								eu.EquipmentType == EquipmentType.Ballast ||
								eu.EquipmentType == EquipmentType.Fuel ||
								eu.EquipmentType == EquipmentType.Misc) &&
								(gp.GaugeType == GaugeType.Level || gp.GaugeType == GaugeType.Ullage))
							{
								// Volume
								dr = m_dtGauge.NewRow();

								dr["EquipmentID"] = eu.EquipmentID;
								dr["ProcessID"] = gp.ProcessID;
								dr["EquipmentName"] = eu.EquipmentTypeString + " - " + eu.Equipment;
								dr["GaugeName"] = "Volume";
								dr["GaugeSort"] = GaugeType.GetModbusGaugeSort(99, 0);

								dr["ModbusInterfaceIndex"] = 1;

								if (gp.ModbusInterfaceArray != null)
								{
									if (gp.ModbusInterfaceArray[1] != null)
									{
										if (gp.ModbusInterfaceArray[1].Enable &&
											gp.ModbusInterfaceArray[1].RegisterAddress1 > 0)
										{
											if (gp.ModbusInterfaceArray[0].RegisterAddress1 > 40000)
												m_iCurrentBase = 40000;
											else
												m_iCurrentBase = 30000;

											dr["ModbusDataType"] = ModbusDataType.GetModbusDataTypeString(gp.ModbusInterfaceArray[1].ModbusDataType);
											dr["RegisterAddress1"] = gp.ModbusInterfaceArray[1].RegisterAddress1;
											dr["Scale"] = gp.ModbusInterfaceArray[1].Scale;

											if (gp.ModbusInterfaceArray[1].ModbusDataType == ModbusDataType.Float32)
												dr["RegisterAddress2"] = gp.ModbusInterfaceArray[1].RegisterAddress2;
										}
									}
								}

								m_dtGauge.Rows.Add(dr);

								// % Capacity
								dr = m_dtGauge.NewRow();

								dr["EquipmentID"] = eu.EquipmentID;
								dr["ProcessID"] = gp.ProcessID;
								dr["EquipmentName"] = eu.EquipmentTypeString + " - " + eu.Equipment;
								dr["GaugeName"] = "% Capacity";
								dr["GaugeSort"] = GaugeType.GetModbusGaugeSort(99, 0);

								dr["ModbusInterfaceIndex"] = 2;

								if (gp.ModbusInterfaceArray != null)
								{
									if (gp.ModbusInterfaceArray.Length > 2 && gp.ModbusInterfaceArray[2] != null)
									{
										if (gp.ModbusInterfaceArray[2].Enable &&
											gp.ModbusInterfaceArray[2].RegisterAddress1 > 0)
										{
											if (gp.ModbusInterfaceArray[0].RegisterAddress1 > 40000)
												m_iCurrentBase = 40000;
											else
												m_iCurrentBase = 30000;

											dr["ModbusDataType"] = ModbusDataType.GetModbusDataTypeString(gp.ModbusInterfaceArray[2].ModbusDataType);
											dr["RegisterAddress1"] = gp.ModbusInterfaceArray[2].RegisterAddress1;
											dr["Scale"] = gp.ModbusInterfaceArray[2].Scale;

											if (gp.ModbusInterfaceArray[2].ModbusDataType == ModbusDataType.Float32)
												dr["RegisterAddress2"] = gp.ModbusInterfaceArray[2].RegisterAddress2;
										}
									}
								}

								m_dtGauge.Rows.Add(dr);

							}
							else
							{
								if (gp.ModbusInterfaceArray != null)
								{
									if (gp.ModbusInterfaceArray[1] != null)
										gp.ModbusInterfaceArray[1].Enable = false;

									if (gp.ModbusInterfaceArray.Length == 5 && gp.ModbusInterfaceArray[2] != null)
										gp.ModbusInterfaceArray[2].Enable = false;
								}
							}
						}
					}
				}
			}
		}

		private void FillAlarmDataTable()
		{
			DataRow dr;
			m_dtAlarm = new DataTable();

			m_dtAlarm.Columns.Add("EquipmentID", typeof(string));
			m_dtAlarm.Columns.Add("ProcessID", typeof(string));
			m_dtAlarm.Columns.Add("AlarmMonitorType", typeof(int));
			m_dtAlarm.Columns.Add("AlarmType", typeof(string));
			m_dtAlarm.Columns.Add("AlarmText", typeof(string));
			m_dtAlarm.Columns.Add("AlarmPriority", typeof(int));
			m_dtAlarm.Columns.Add("Comparator", typeof(string));
			m_dtAlarm.Columns.Add("Limit", typeof(float));
			m_dtAlarm.Columns.Add("EquipmentName", typeof(string));
			m_dtAlarm.Columns.Add("GaugeName", typeof(string));
			m_dtAlarm.Columns.Add("AlarmName", typeof(string));
			m_dtAlarm.Columns.Add("GaugeSort", typeof(int));
			m_dtAlarm.Columns.Add("ModbusDataType", typeof(string));
			m_dtAlarm.Columns.Add("RegisterAddress1", typeof(ushort));

			foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
			{
				if (TLIConfiguration.VesselGaugePoints.ContainsKey(eu.EquipmentID))
					foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[eu.EquipmentID].Values)
					{
						if(TLIConfiguration.VesselAlarmPoints.ContainsKey(eu.EquipmentID) &&
							TLIConfiguration.VesselAlarmPoints[eu.EquipmentID].ContainsKey(gp.ProcessID))
							foreach (AlarmPoint ap in TLIConfiguration.VesselAlarmPoints[eu.EquipmentID][gp.ProcessID].Values)
							{
								dr = m_dtAlarm.NewRow();

								dr["EquipmentID"] = eu.EquipmentID;
								dr["ProcessID"] = gp.ProcessID;
								dr["AlarmMonitorType"] = ap.AlarmMonitorType;
								dr["AlarmType"] = ap.AlarmType;
								dr["AlarmText"] = ap.AlarmText;
								dr["AlarmPriority"] = ap.AlarmPriority;
								dr["Comparator"] = ap.Comparator;
								dr["Limit"] = ap.Limit;
								dr["EquipmentName"] = eu.EquipmentTypeString + " - " + eu.Equipment;
								dr["GaugeName"] = gp.GaugeTypeStringExtended;
								dr["AlarmName"] = ap.DisplayName;
								dr["GaugeSort"] = GaugeType.GetModbusGaugeSort(gp.GaugeType, gp.GaugeNumber);

								if (ap.ModbusInterface != null)
								{
									if (ap.ModbusInterface.Enable &&
										ap.ModbusInterface.RegisterAddress1 > 0)
									{
										//if (ap.ModbusInterface.RegisterAddress1 > 40000)
										//	m_iCurrentBase = 40000;
										//else if (ap.ModbusInterface.RegisterAddress1 > 30000)
											m_iCurrentBase = 0;
												
										dr["ModbusDataType"] = ModbusDataType.GetModbusDataTypeString(ap.ModbusInterface.ModbusDataType);
										dr["RegisterAddress1"] = ap.ModbusInterface.RegisterAddress1;
									}
								}

								m_dtAlarm.Rows.Add(dr);
							}
					}
			}
		}

		private bool ValidateGaugeEditRow()
		{
			try
			{
				ushort iMinRange, iMaxRange, iRegisterAddress1, iRegisterAddress2;
				string sProcessID;

				if (m_EditGaugeRow == null)
					return false;

				if (cboAddressRange.SelectedIndex == 0)
				{
					iMinRange = 30001;
					iMaxRange = 40000;
				}
				else
				{
					iMinRange = 40001;
					iMaxRange = 50000;
				}

				sProcessID = m_EditGaugeRow.Cells["ProcessID"].Value.ToString();
				iRegisterAddress1 = Convert.ToUInt16(m_EditGaugeRow.Cells["RegisterAddress1"].Value);

				if (iRegisterAddress1 < iMinRange || iRegisterAddress1 > iMaxRange)
				{
					MessageBox.Show("Invalid Register LW.  Value must be between " + iMinRange.ToString() + " - " + iMaxRange + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}

				foreach (DataRow dr in m_dtGauge.Rows)
				{
					if (dr["ProcessID"].ToString() != sProcessID && dr["RegisterAddress1"] != DBNull.Value)
					{
						if (Convert.ToUInt16(dr["RegisterAddress1"]) == iRegisterAddress1)
						{
							MessageBox.Show("The Register LW you have specified has already been assigned to another gauge.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return false;
						}
					}

					if (dr["ProcessID"].ToString() != sProcessID && dr["RegisterAddress2"] != DBNull.Value)
					{
						if (Convert.ToUInt16(dr["RegisterAddress2"]) == iRegisterAddress1)
						{
							MessageBox.Show("The Register LW you have specified has already been assigned to another gauge.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return false;
						}
					}
				}

				foreach (DataRow dr in m_dtAlarm.Rows)
				{
					if(dr["RegisterAddress1"] != DBNull.Value)
					{
						if (Convert.ToUInt16(dr["RegisterAddress1"]) == iRegisterAddress1)
						{
							MessageBox.Show("The Register LW you have specified has already been assigned to an alarm.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return false;
						}
					}
				}

				if (m_EditGaugeRow.Cells["ModbusDataType"].Value.ToString() == ModbusDataType.Float32String)
				{
					iRegisterAddress2 = Convert.ToUInt16(m_EditGaugeRow.Cells["RegisterAddress2"].Value);

					if (iRegisterAddress2 < iMinRange || iRegisterAddress2 > iMaxRange)
					{
						MessageBox.Show("Invalid Register HW.  Value must be between " + iMinRange.ToString() + " - " + iMaxRange + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}

					foreach (DataRow dr in m_dtGauge.Rows)
					{
						if (dr["ProcessID"].ToString() != sProcessID && dr["RegisterAddress1"] != DBNull.Value)
						{
							if (Convert.ToUInt16(dr["RegisterAddress1"]) == iRegisterAddress2)
							{
								MessageBox.Show("The Register HW you have specified has already been assigned to another gauge.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								return false;
							}
						}

						if (dr["ProcessID"].ToString() != sProcessID && dr["RegisterAddress2"] != DBNull.Value)
						{
							if (Convert.ToUInt16(dr["RegisterAddress2"]) == iRegisterAddress2)
							{
								MessageBox.Show("The Register HW you have specified has already been assigned to another gauge.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								return false;
							}
						}
					}

					foreach (DataRow dr in m_dtAlarm.Rows)
					{
						if (dr["RegisterAddress1"] != DBNull.Value)
						{
							if (Convert.ToUInt16(dr["RegisterAddress1"]) == iRegisterAddress2)
							{
								MessageBox.Show("The Register HW you have specified has already been assigned to an alarm.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								return false;
							}
						}
					}
				}

				return true;
			}
			catch
			{
				MessageBox.Show("Error validating input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		private bool ValidateAlarmEditRow()
		{
			try
			{
				ushort iMinRange, iMaxRange, iRegisterAddress1;
				string sProcessID, sAlarmMonitorType, sAlarmType, sAlarmText,
					sAlarmPriority, sComparator, sLimit;

				if (m_EditAlarmRow == null)
					return false;

				//if (cboAddressRange.SelectedItem.ToString().Contains("3"))
				//{
					iMinRange = 1;
					iMaxRange = 50000;
				//}
				//else
				//{
				//	iMinRange = 40001;
				//	iMaxRange = 50000;
				//}

				sProcessID = m_EditAlarmRow.Cells["ProcessID"].Value.ToString();
				sAlarmMonitorType = m_EditAlarmRow.Cells["AlarmMonitorType"].Value.ToString();
				sAlarmType = m_EditAlarmRow.Cells["AlarmType"].Value.ToString();
				sAlarmText = m_EditAlarmRow.Cells["AlarmText"].Value.ToString();
				sAlarmPriority = m_EditAlarmRow.Cells["AlarmPriority"].Value.ToString();
				sComparator = m_EditAlarmRow.Cells["Comparator"].Value.ToString();
				sLimit = m_EditAlarmRow.Cells["Limit"].Value.ToString();

				iRegisterAddress1 = Convert.ToUInt16(m_EditAlarmRow.Cells["RegisterAddress1"].Value);

				if (iRegisterAddress1 < iMinRange || iRegisterAddress1 > iMaxRange)
				{
					MessageBox.Show("Invalid register value.  Value must be between " + iMinRange.ToString() + " - " + iMaxRange + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}

				foreach (DataRow dr in m_dtGauge.Rows)
				{
					if (dr["RegisterAddress1"] != DBNull.Value)
					{
						if (Convert.ToUInt16(dr["RegisterAddress1"]) == iRegisterAddress1)
						{
							MessageBox.Show("The register you have specified has already been assigned to a gauge.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return false;
						}
					}

					if (dr["RegisterAddress2"] != DBNull.Value)
					{
						if (Convert.ToUInt16(dr["RegisterAddress2"]) == iRegisterAddress1)
						{
							MessageBox.Show("The register you have specified has already been assigned to a gauge.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return false;
						}
					}
				}

				foreach (DataRow dr in m_dtAlarm.Rows)
				{
					if ((dr["ProcessID"].ToString() != sProcessID ||
						dr["AlarmMonitorType"].ToString() != sAlarmMonitorType ||
						dr["AlarmType"].ToString() != sAlarmType ||
						dr["AlarmText"].ToString() != sAlarmText ||
						dr["AlarmPriority"].ToString() != sAlarmPriority ||
						dr["Comparator"].ToString() != sComparator ||
						dr["Limit"].ToString() != sLimit) &&
						dr["RegisterAddress1"] != DBNull.Value)
					{
						if (Convert.ToUInt16(dr["RegisterAddress1"]) == iRegisterAddress1)
						{
							MessageBox.Show("The register you have specified has already been assigned to another alarm.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return false;
						}
					}
				}

				return true;
			}
			catch
			{
				MessageBox.Show("Error validating input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		private bool SaveGaugeValues()
		{
			string sEquipmentID, sProcessID;
			int iModbusInterfaceIndex;
			GaugePoint gp;

			try
			{
				foreach (DataRow dr in m_dtGauge.Rows)
				{
					sEquipmentID = dr["EquipmentID"].ToString();
					sProcessID = dr["ProcessID"].ToString();
					iModbusInterfaceIndex = Convert.ToInt32(dr["ModbusInterfaceIndex"]);

					if (TLIConfiguration.VesselGaugePoints.ContainsKey(sEquipmentID))
						if (TLIConfiguration.VesselGaugePoints[sEquipmentID].ContainsKey(sProcessID))
						{
							gp = TLIConfiguration.VesselGaugePoints[sEquipmentID][sProcessID];

							if (gp.ModbusInterfaceArray == null)
								gp.ModbusInterfaceArray = new ModbusInterface[5];

							if (gp.ModbusInterfaceArray.Length != 5)
								gp.ModbusInterfaceArray = Util.ExtendArray(gp.ModbusInterfaceArray, 5);

							if (gp.ModbusInterfaceArray[iModbusInterfaceIndex] == null)
								gp.ModbusInterfaceArray[iModbusInterfaceIndex] = new ModbusInterface();

							if (dr["RegisterAddress1"] != DBNull.Value &&
								dr["RegisterAddress1"].ToString() != "" &&
								dr["RegisterAddress1"].ToString() != "0")
							{
								gp.ModbusInterfaceArray[iModbusInterfaceIndex].Enable = true;
								gp.ModbusInterfaceArray[iModbusInterfaceIndex].ModbusDataType = ModbusDataType.GetModbusDataTypeID(dr["ModbusDataType"].ToString());
								gp.ModbusInterfaceArray[iModbusInterfaceIndex].RegisterAddress1 = Convert.ToUInt16(dr["RegisterAddress1"]);
								gp.ModbusInterfaceArray[iModbusInterfaceIndex].Scale = Convert.ToSingle(dr["Scale"] == DBNull.Value ? 1 : dr["Scale"]);

								if (gp.ModbusInterfaceArray[iModbusInterfaceIndex].ModbusDataType == ModbusDataType.Float32)
									gp.ModbusInterfaceArray[iModbusInterfaceIndex].RegisterAddress2 = Convert.ToUInt16(dr["RegisterAddress2"]);
								else
									gp.ModbusInterfaceArray[iModbusInterfaceIndex].RegisterAddress2 = 0;
							}
							else
								gp.ModbusInterfaceArray[iModbusInterfaceIndex].Enable = false;
						}
				}

				return true;
			}
			catch
			{
				MessageBox.Show("Error saving gauging registers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		private bool SaveAlarmValues()
		{
			string sEquipmentID, sProcessID, sAlarmMonitorType, sAlarmType,
				sAlarmText, sAlarmPriority, sComparator, sLimit;

			try
			{
				foreach (DataRow dr in m_dtAlarm.Rows)
				{
					sEquipmentID = dr["EquipmentID"].ToString();	
					sProcessID = dr["ProcessID"].ToString();
					sAlarmMonitorType = dr["AlarmMonitorType"].ToString();
					sAlarmType = dr["AlarmType"].ToString();
					sAlarmText = dr["AlarmText"].ToString();
					sAlarmPriority = dr["AlarmPriority"].ToString();
					sComparator = dr["Comparator"].ToString();
					sLimit = dr["Limit"].ToString();

					if(TLIConfiguration.VesselAlarmPoints.ContainsKey(sEquipmentID))
						if(TLIConfiguration.VesselAlarmPoints[sEquipmentID].ContainsKey(sProcessID))
							foreach (AlarmPoint ap in TLIConfiguration.VesselAlarmPoints[sEquipmentID][sProcessID].Values)
							{
								if (ap.AlarmMonitorType.ToString() == sAlarmMonitorType &&
									ap.AlarmType == sAlarmType &&
									ap.AlarmText == sAlarmText &&
									ap.AlarmPriority.ToString() == sAlarmPriority &&
									ap.Comparator == sComparator &&
									ap.Limit.ToString() == sLimit)
								{
									if (ap.ModbusInterface == null)
										ap.ModbusInterface = new ModbusInterface();

									if (dr["RegisterAddress1"] != DBNull.Value &&
										dr["RegisterAddress1"].ToString() != "" &&
										dr["RegisterAddress1"].ToString() != "0")
									{
										ap.ModbusInterface.Enable = true;
										ap.ModbusInterface.ModbusDataType = ModbusDataType.Int16;
										ap.ModbusInterface.RegisterAddress1 = Convert.ToUInt16(dr["RegisterAddress1"]);
										ap.ModbusInterface.RegisterAddress2 = 0;
										ap.ModbusInterface.Scale = 1;
									}
									else
										ap.ModbusInterface.Enable = false;
								}
							}
				}

				return true;
			}
			catch
			{
				MessageBox.Show("Error saving alarm registers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		private void CopyTCPGaugeValues()
		{
			DataRow dr;
			m_dtGauge.Rows.Clear();

			foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
			{
				if (TLIConfiguration.VesselGaugePoints.ContainsKey(eu.EquipmentID))
				{
					foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[eu.EquipmentID].Values)
					{
						if (gp.GaugeType != GaugeType.ChannelStateAlarmMonitor)
						{
							dr = m_dtGauge.NewRow();

							dr["EquipmentID"] = eu.EquipmentID;
							dr["ProcessID"] = gp.ProcessID;
							dr["EquipmentName"] = eu.EquipmentTypeString + " - " + eu.Equipment;
							dr["GaugeName"] = gp.GaugeTypeStringExtended;
							dr["GaugeSort"] = GaugeType.GetModbusGaugeSort(gp.GaugeType, gp.GaugeNumber);

							dr["ModbusInterfaceIndex"] = 0;

							if (gp.TCPModbusInterfaceArray != null)
							{
								if (gp.TCPModbusInterfaceArray[0] != null)
								{
									if (gp.TCPModbusInterfaceArray[0].Enable &&
										gp.TCPModbusInterfaceArray[0].RegisterAddress1 > 0)
									{
										if (gp.TCPModbusInterfaceArray[0].RegisterAddress1 > 40000)
											m_iCurrentBase = 40000;
										else
											m_iCurrentBase = 30000;

										dr["ModbusDataType"] = ModbusDataType.GetModbusDataTypeString(gp.TCPModbusInterfaceArray[0].ModbusDataType);
										dr["RegisterAddress1"] = gp.TCPModbusInterfaceArray[0].RegisterAddress1;
										dr["Scale"] = gp.TCPModbusInterfaceArray[0].Scale;

										if (gp.TCPModbusInterfaceArray[0].ModbusDataType == ModbusDataType.Float32)
											dr["RegisterAddress2"] = gp.TCPModbusInterfaceArray[0].RegisterAddress2;
									}
								}
							}

							m_dtGauge.Rows.Add(dr);

							// Add sounding values and % capacity

							if ((eu.EquipmentType == EquipmentType.Cargo ||
								eu.EquipmentType == EquipmentType.Ballast ||
								eu.EquipmentType == EquipmentType.Fuel) &&
								(gp.GaugeType == GaugeType.Level || gp.GaugeType == GaugeType.Ullage))
							{
								// Volume
								dr = m_dtGauge.NewRow();

								dr["EquipmentID"] = eu.EquipmentID;
								dr["ProcessID"] = gp.ProcessID;
								dr["EquipmentName"] = eu.EquipmentTypeString + " - " + eu.Equipment;
								dr["GaugeName"] = "Volume";
								dr["GaugeSort"] = GaugeType.GetModbusGaugeSort(99, 0);

								dr["ModbusInterfaceIndex"] = 1;

								if (gp.TCPModbusInterfaceArray != null)
								{
									if (gp.TCPModbusInterfaceArray[1] != null)
									{
										if (gp.TCPModbusInterfaceArray[1].Enable &&
											gp.TCPModbusInterfaceArray[1].RegisterAddress1 > 0)
										{
											if (gp.TCPModbusInterfaceArray[0].RegisterAddress1 > 40000)
												m_iCurrentBase = 40000;
											else
												m_iCurrentBase = 30000;

											dr["ModbusDataType"] = ModbusDataType.GetModbusDataTypeString(gp.TCPModbusInterfaceArray[1].ModbusDataType);
											dr["RegisterAddress1"] = gp.TCPModbusInterfaceArray[1].RegisterAddress1;
											dr["Scale"] = gp.TCPModbusInterfaceArray[1].Scale;

											if (gp.TCPModbusInterfaceArray[1].ModbusDataType == ModbusDataType.Float32)
												dr["RegisterAddress2"] = gp.TCPModbusInterfaceArray[1].RegisterAddress2;
										}
									}
								}

								m_dtGauge.Rows.Add(dr);

								// % Capacity
								dr = m_dtGauge.NewRow();

								dr["EquipmentID"] = eu.EquipmentID;
								dr["ProcessID"] = gp.ProcessID;
								dr["EquipmentName"] = eu.EquipmentTypeString + " - " + eu.Equipment;
								dr["GaugeName"] = "% Capacity";
								dr["GaugeSort"] = GaugeType.GetModbusGaugeSort(99, 0);

								dr["ModbusInterfaceIndex"] = 2;

								if (gp.TCPModbusInterfaceArray != null)
								{
									if (gp.TCPModbusInterfaceArray.Length >= 3 && gp.TCPModbusInterfaceArray[2] != null)
									{
										if (gp.TCPModbusInterfaceArray[2].Enable &&
											gp.TCPModbusInterfaceArray[2].RegisterAddress1 > 0)
										{
											if (gp.TCPModbusInterfaceArray[0].RegisterAddress1 > 40000)
												m_iCurrentBase = 40000;
											else
												m_iCurrentBase = 30000;

											dr["ModbusDataType"] = ModbusDataType.GetModbusDataTypeString(gp.TCPModbusInterfaceArray[2].ModbusDataType);
											dr["RegisterAddress1"] = gp.TCPModbusInterfaceArray[2].RegisterAddress1;
											dr["Scale"] = gp.TCPModbusInterfaceArray[2].Scale;

											if (gp.TCPModbusInterfaceArray[2].ModbusDataType == ModbusDataType.Float32)
												dr["RegisterAddress2"] = gp.TCPModbusInterfaceArray[2].RegisterAddress2;
										}
									}
								}

								m_dtGauge.Rows.Add(dr);

							}
						}
					}
				}
			}
		}

		private void CopyTCPAlarmValues()
		{
			DataRow dr;
			m_dtAlarm.Rows.Clear();

			foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
			{
				if (TLIConfiguration.VesselGaugePoints.ContainsKey(eu.EquipmentID))
					foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[eu.EquipmentID].Values)
					{
						if (TLIConfiguration.VesselAlarmPoints.ContainsKey(eu.EquipmentID))
							if (TLIConfiguration.VesselAlarmPoints[eu.EquipmentID].ContainsKey(gp.ProcessID))
								foreach (AlarmPoint ap in TLIConfiguration.VesselAlarmPoints[eu.EquipmentID][gp.ProcessID].Values)
								{
									dr = m_dtAlarm.NewRow();

									dr["EquipmentID"] = eu.EquipmentID;
									dr["ProcessID"] = gp.ProcessID;
									dr["AlarmMonitorType"] = ap.AlarmMonitorType;
									dr["AlarmType"] = ap.AlarmType;
									dr["AlarmText"] = ap.AlarmText;
									dr["AlarmPriority"] = ap.AlarmPriority;
									dr["Comparator"] = ap.Comparator;
									dr["Limit"] = ap.Limit;
									dr["EquipmentName"] = eu.EquipmentTypeString + " - " + eu.Equipment;
									dr["GaugeName"] = gp.GaugeTypeStringExtended;
									dr["AlarmName"] = ap.DisplayName;
									dr["GaugeSort"] = GaugeType.GetModbusGaugeSort(gp.GaugeType, gp.GaugeNumber);

									if (ap.TCPModbusInterface != null)
									{
										if (ap.TCPModbusInterface.Enable &&
											ap.TCPModbusInterface.RegisterAddress1 > 0)
										{
											if (ap.TCPModbusInterface.RegisterAddress1 > 40000)
												m_iCurrentBase = 40000;
											else
												m_iCurrentBase = 30000;

											dr["ModbusDataType"] = ModbusDataType.GetModbusDataTypeString(ap.TCPModbusInterface.ModbusDataType);
											dr["RegisterAddress1"] = ap.TCPModbusInterface.RegisterAddress1;
										}
									}

									m_dtAlarm.Rows.Add(dr);
								}
					}
			}
		}

		private void AddingGaugeDataRow(object sender, Xceed.Grid.AddingDataRowEventArgs e)
		{
			e.DataRow.BeginningEdit += new CancelEventHandler(BeginningGaugeEdit);
			e.DataRow.EditBegun += new EventHandler(EditGaugeBegun);
			e.DataRow.EndingEdit += new CancelEventHandler(EndingGaugeEdit);
		}

		private void AddingAlarmDataRow(object sender, Xceed.Grid.AddingDataRowEventArgs e)
		{
			e.DataRow.BeginningEdit += new CancelEventHandler(BeginningAlarmEdit);
			e.DataRow.EditBegun += new EventHandler(EditAlarmBegun);
			e.DataRow.EndingEdit += new CancelEventHandler(EndingAlarmEdit);
		}

		private void BeginningGaugeEdit(object sender, CancelEventArgs e)
		{
			m_EditGaugeRow = (Xceed.Grid.DataRow)sender;
		}

		private void BeginningAlarmEdit(object sender, CancelEventArgs e)
		{
			m_EditAlarmRow = (Xceed.Grid.DataRow)sender;
		}

		private void EditGaugeBegun(object sender, EventArgs e)
		{
			bool bFirstRegister = true;
			ushort iMaxRegister;

			if (m_EditGaugeRow.Cells["RegisterAddress1"].Value == DBNull.Value ||
				m_EditGaugeRow.Cells["RegisterAddress1"].Value.ToString() == "")
			{
				Console.WriteLine("EDIT ? " + cboAddressRange.Items.Count);
				if (cboAddressRange.SelectedIndex == 0)
					iMaxRegister = 30001;
				else
					iMaxRegister = 40001;

				foreach (DataRow dr in m_dtGauge.Rows)
				{
					if (dr["RegisterAddress1"] != DBNull.Value)
						if (Convert.ToUInt16(dr["RegisterAddress1"]) >= iMaxRegister)
						{
							iMaxRegister = Convert.ToUInt16(dr["RegisterAddress1"]);
							bFirstRegister = false;
						}

					if (dr["RegisterAddress2"] != DBNull.Value)
						if (Convert.ToUInt16(dr["RegisterAddress2"]) >= iMaxRegister)
						{
							iMaxRegister = Convert.ToUInt16(dr["RegisterAddress2"]);
							bFirstRegister = false;
						}
				}

				foreach (DataRow dr in m_dtAlarm.Rows)
				{
					if(dr["RegisterAddress1"] != DBNull.Value)
						if (Convert.ToUInt16(dr["RegisterAddress1"]) >= iMaxRegister)
						{
							iMaxRegister = Convert.ToUInt16(dr["RegisterAddress1"]);
							bFirstRegister = false;
						}
				}

				if(bFirstRegister)
					m_EditGaugeRow.Cells["RegisterAddress1"].Value = iMaxRegister;
				else
					m_EditGaugeRow.Cells["RegisterAddress1"].Value = iMaxRegister + 1;

				m_EditGaugeRow.Cells["Scale"].Value = 1;
			}
		}

		private void EditAlarmBegun(object sender, EventArgs e)
		{
			bool bFirstRegister = true;
			ushort iMaxRegister = 1;

			if (m_EditAlarmRow.Cells["RegisterAddress1"].Value == DBNull.Value ||
				m_EditAlarmRow.Cells["RegisterAddress1"].Value.ToString() == "")
			{
				//if (cboAddressRange.SelectedItem.ToString().Contains("3"))
				//	iMaxRegister = 30001;
				//else
					//iMaxRegister = 40001;

				foreach (DataRow dr in m_dtGauge.Rows)
				{
					if (dr["RegisterAddress1"] != DBNull.Value)
						if (Convert.ToUInt16(dr["RegisterAddress1"]) >= iMaxRegister)
						{
							iMaxRegister = Convert.ToUInt16(dr["RegisterAddress1"]);
							bFirstRegister = false;
						}

					if (dr["RegisterAddress2"] != DBNull.Value)
						if (Convert.ToUInt16(dr["RegisterAddress2"]) >= iMaxRegister)
						{
							iMaxRegister = Convert.ToUInt16(dr["RegisterAddress2"]);
							bFirstRegister = false;
						}
				}

				foreach (DataRow dr in m_dtAlarm.Rows)
				{
					if (dr["RegisterAddress1"] != DBNull.Value)
						if (Convert.ToUInt16(dr["RegisterAddress1"]) >= iMaxRegister)
						{
							iMaxRegister = Convert.ToUInt16(dr["RegisterAddress1"]);
							bFirstRegister = false;
						}
				}

				if (bFirstRegister)
					m_EditAlarmRow.Cells["RegisterAddress1"].Value = iMaxRegister;
				else
					m_EditAlarmRow.Cells["RegisterAddress1"].Value = iMaxRegister + 1;
			}
		}

		private void EndingGaugeEdit(object sender, CancelEventArgs e)
		{
			if (Disposing)
				return;

			if (m_EditGaugeRow != null)
			{
				if (m_EditGaugeRow.Cells["RegisterAddress1"].Value == DBNull.Value)
				{
					m_EditGaugeRow.Cells["ModbusDataType"].Value = DBNull.Value;
					m_EditGaugeRow.Cells["RegisterAddress1"].Value = DBNull.Value;
					m_EditGaugeRow.Cells["RegisterAddress2"].Value = DBNull.Value;
					m_EditGaugeRow.Cells["Scale"].Value = DBNull.Value;
					m_EditGaugeRow = null;
					return;
				}

				if (!e.Cancel) gcGauge.EnforceNonBlankCell(m_EditGaugeRow.Cells["ModbusDataType"], "Data Type", e);
				if (!e.Cancel) gcGauge.EnforceNonBlankCell(m_EditGaugeRow.Cells["RegisterAddress1"], "Register LW", e);
				if (!e.Cancel) gcGauge.EnforceNonBlankCell(m_EditGaugeRow.Cells["Scale"], "Scale", e);

				if (!e.Cancel)
				{
					if (m_EditGaugeRow.Cells["ModbusDataType"].Value.ToString() == ModbusDataType.GetModbusDataTypeString(ModbusDataType.Float32))
						m_EditGaugeRow.Cells["RegisterAddress2"].Value = Convert.ToUInt16(m_EditGaugeRow.Cells["RegisterAddress1"].Value) + 1;
					else
						m_EditGaugeRow.Cells["RegisterAddress2"].Value = DBNull.Value;
				}

				if (!e.Cancel)
					if (!ValidateGaugeEditRow())
						e.Cancel = true;
			}
			
			m_EditGaugeRow = null;
		}

		private void EndingAlarmEdit(object sender, CancelEventArgs e)
		{
			if (Disposing)
				return;

			if (m_EditAlarmRow != null)
			{
				if (m_EditAlarmRow.Cells["RegisterAddress1"].Value == DBNull.Value)
				{
					m_EditAlarmRow.Cells["RegisterAddress1"].Value = DBNull.Value;
					m_EditAlarmRow = null;
					return;
				}

				if (!e.Cancel) gcAlarm.EnforceNonBlankCell(m_EditAlarmRow.Cells["RegisterAddress1"], "Register", e);

				if (!e.Cancel)
					if (!ValidateAlarmEditRow())
						e.Cancel = true;
			}

			m_EditAlarmRow = null;
		}

		private void CboAddressRange_SelectedIndexChanged(object sender, EventArgs e)
		{
			int iOffset;

			if (cboAddressRange.SelectedIndex == 0)
			{
				m_iCurrentBase = 30000;
                iOffset = -10000;
            }
			else
			{
				m_iCurrentBase = 40000;
                iOffset = 10000;
            }

			foreach (DataRow dr in m_dtGauge.Rows)
			{
				if (dr["RegisterAddress1"] != DBNull.Value &&
					dr["RegisterAddress1"].ToString() != "" &&
					dr["RegisterAddress1"].ToString() != "0")
				{
					dr["RegisterAddress1"] = Convert.ToUInt16(dr["RegisterAddress1"]) + iOffset;
				}

				if (dr["RegisterAddress2"] != DBNull.Value &&
					dr["RegisterAddress2"].ToString() != "" &&
					dr["RegisterAddress2"].ToString() != "0")
				{
					dr["RegisterAddress2"] = Convert.ToUInt16(dr["RegisterAddress2"]) + iOffset;
				}
			}

			foreach (DataRow dr in m_dtAlarm.Rows)
			{
				if (dr["RegisterAddress1"] != DBNull.Value &&
					dr["RegisterAddress1"].ToString() != "" &&
					dr["RegisterAddress1"].ToString() != "0")
				{
					dr["RegisterAddress1"] = Convert.ToUInt16(dr["RegisterAddress1"]);// + iOffset;
				}
			}
		}

		private void CmdCopy_Click(object sender, EventArgs e)
		{
			DialogResult dr;
			dr = MessageBox.Show("Are you sure that you want to copy all register values from the TCP interface?", "Copy TCP Interface", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (dr == DialogResult.Yes)
			{
				CopyTCPGaugeValues();
				CopyTCPAlarmValues();
			}
		}

		private void CmdOk_Click(object sender, EventArgs e)
		{
			if (SaveGaugeValues())
			{
				if (SaveAlarmValues())
				{
					TLIConfiguration.Vessel.IncludeSystemStatusModbusSerial = chkIncludeSystemStatus.Checked;

					DialogResult = DialogResult.OK;
					Close();
				}
			}
		}

		private void CmdClearGauge_Click(object sender, EventArgs e)
		{
			DialogResult drlt;
			drlt = MessageBox.Show("Are you sure that you want to clear all register values?", "Clear Registers", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (drlt == DialogResult.Yes)
			{
				foreach (DataRow dr in m_dtGauge.Rows)
				{
					dr["ModbusDataType"] = DBNull.Value;
					dr["RegisterAddress1"] = DBNull.Value;
					dr["RegisterAddress2"] = DBNull.Value;
					dr["Scale"] = DBNull.Value;
				}

				foreach (DataRow dr in m_dtAlarm.Rows)
				{
					dr["ModbusDataType"] = DBNull.Value;
					dr["RegisterAddress1"] = DBNull.Value;
				}
			}
		}

		private void CmdCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}