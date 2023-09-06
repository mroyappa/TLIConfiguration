using System;
using System.Text;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using ICBObjectModel;
using ICBObjectModel.Enumerations;

/*
 * CLASS SUMMARY:	TCPModbus
 *
 * TCPModbus is the form used to configure GaugePoints for use in the TCP Modbus Slave.
 * 
 */

namespace TLIConfiguration
{
	public partial class TCPModbus : Form
	{
		private DataTable gaugeTable;
		private DataTable alarmTable;
		private DataTable receivingTable;

		private CustomColumnManagerRow customColumnManagerGaugeRow;
		private Xceed.Grid.DataRow editGaugeRow;
		private Xceed.Grid.SpacerRow spacerGaugeRow;

		private CustomColumnManagerRow customColumnManagerAlarmRow;
		private Xceed.Grid.DataRow editAlarmRow;
		private Xceed.Grid.SpacerRow spacerAlarmRow;

		//private CustomColumnManagerRow customColumnManagerReceivingRow;
		//private Xceed.Grid.DataRow editReceivingRow;
		//private Xceed.Grid.SpacerRow spacerReceivingRow;

		private ushort currentBase = 0;

		private const ushort RECEIVING_REG_START = 42001;

		public TCPModbus()
		{
			InitializeComponent();
		}

		private void TCPModbus_Load(object sender, EventArgs e)
		{
			SetupGaugeGrid();
			PopulateGaugeGrid();

			SetupAlarmGrid();
			PopulateAlarmGrid();

			//SetupReceivingGrid();
			//PopulateReceivingGrid();

            BindControls();
		}

		private void BindControls()
		{
			cboAddressRange.Items.Add("3xxxx");
			cboAddressRange.Items.Add("4xxxx");

			if (currentBase == 30000)
				cboAddressRange.SelectedIndex = 0;
			else if (currentBase == 40000)
				cboAddressRange.SelectedIndex = 1;
			else
				cboAddressRange.SelectedIndex = 0;

			chkIncludeSystemStatus.Checked = TLIConfiguration.Vessel.IncludeSystemStatusModbusTCP;

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
				//gcGauge.AddBoundColumn(columnManagerRow1);
				columnManagerRow1.Remove();

                // Custom Column Manager Row
                customColumnManagerGaugeRow = new CustomColumnManagerRow
				{
					BackColor = Color.White,
					ForeColor = Color.Black,
					Height = 17
				};
				gcGauge.FixedHeaderRows.Add(customColumnManagerGaugeRow);

				// Spacer Row
				spacerGaugeRow = new Xceed.Grid.SpacerRow
				{
					Height = 4
				};
				gcGauge.FixedHeaderRows.Add(spacerGaugeRow);

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
                gcGauge.AddBoundColumn("CMaxRegisterAddress1", "CMax Correction RegLW", true, false, 140);
				gcGauge.AddBoundColumn("CMaxRegisterAddress2", "CMax Correction RegHW", true, true, 140);
				gcGauge.AddBoundColumn("CMaxScale", "CMax Scale", true, false, 75);

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
				MessageBox.Show("Error retrieving configuration data.\n" + e.Message + "\n" + e.StackTrace,
					"TLI Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
				//customColumnManagerAlarmRow
				//gcAlarm.setd
				columnManagerRow2.Remove();

                // Custom Column Manager Row
                customColumnManagerAlarmRow = new CustomColumnManagerRow
				{
					BackColor = Color.White,
					ForeColor = Color.Black,
					Height = 17
				};
				
				gcAlarm.FixedHeaderRows.Add(customColumnManagerAlarmRow);

				// Spacer Row
				spacerAlarmRow = new Xceed.Grid.SpacerRow
				{
					Height = 4
				};
				gcAlarm.FixedHeaderRows.Add(spacerAlarmRow);

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
				MessageBox.Show("Error retrieving configuration data.\n" + e.Message + "\n" + e.StackTrace,
					"TLI Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
		}

		private void PopulateGaugeGrid()
		{
			try
			{
				FillGaugeDataTable();

				gcGauge.BeginInit();
				gcGauge.DataSource = gaugeTable;
				gcGauge.DataMember = "";
				gcGauge.EndInit();
				
				foreach(Xceed.Grid.DataRow row in gcGauge.DataRows)
                {
					Console.WriteLine(row.Index);
					row.Click += new EventHandler(SelectedRowChanged);
				}

				gcGauge.HideUnwantedGridColumns(new string[] { "EquipmentName", "GaugeName", "ModbusDataType", "RegisterAddress1", "RegisterAddress2", "Scale",
					"CMaxRegisterAddress1", "CMaxRegisterAddress2", "CMaxScale"});
			}
			catch (Exception e)
			{
				MessageBox.Show("Error retrieving configuration data.\n" + e.Message + "\n" + e.StackTrace,
					"TLI Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
		}

		private void PopulateAlarmGrid()
		{
			try
			{
				FillAlarmDataTable();

				gcAlarm.BeginInit();
				gcAlarm.DataSource = alarmTable;
				gcAlarm.DataMember = "";
				gcAlarm.EndInit();

				gcAlarm.HideUnwantedGridColumns(new string[] { "EquipmentName", "GaugeName", "AlarmName", "RegisterAddress1" });
			}
			catch (Exception e)
			{
				MessageBox.Show("Error retrieving configuration data.\n" + e.Message + "\n" + e.StackTrace,
					"TLI Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
		}

		private void FillGaugeDataTable()
		{
			DataRow dr;
			gaugeTable = new DataTable();

			gaugeTable.Columns.Add("EquipmentID", typeof(string));
			gaugeTable.Columns.Add("ProcessID", typeof(string));
			gaugeTable.Columns.Add("ModbusInterfaceIndex", typeof(int));
			gaugeTable.Columns.Add("EquipmentName", typeof(string));
			gaugeTable.Columns.Add("GaugeName", typeof(string));
			gaugeTable.Columns.Add("GaugeSort", typeof(int));
			gaugeTable.Columns.Add("ModbusDataType", typeof(string));
			gaugeTable.Columns.Add("RegisterAddress1", typeof(ushort));
			gaugeTable.Columns.Add("RegisterAddress2", typeof(ushort));
			gaugeTable.Columns.Add("Scale", typeof(float));
			gaugeTable.Columns.Add("CMaxRegisterAddress1", typeof(ushort));
			gaugeTable.Columns.Add("CMaxRegisterAddress2", typeof(ushort));
			gaugeTable.Columns.Add("CMaxScale", typeof(float));

			foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
			{
				if (TLIConfiguration.VesselGaugePoints.ContainsKey(eu.EquipmentID))
				{
					foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[eu.EquipmentID].Values)
					{
						if (gp.GaugeType != GaugeType.ChannelStateAlarmMonitor)
						{
							dr = gaugeTable.NewRow();

							dr["EquipmentID"] = eu.EquipmentID;
							dr["ProcessID"] = gp.ProcessID;
							dr["EquipmentName"] = eu.EquipmentTypeString + " - " + eu.Equipment;
							dr["GaugeName"] = gp.GaugeTypeStringExtended;
							dr["GaugeSort"] = GaugeType.GetModbusGaugeSort(gp.GaugeType, gp.GaugeNumber);
							
							dr["ModbusInterfaceIndex"] = 0; //index 0: gauge point reading (e.g. level, pressure, temp)

							if (gp.TCPModbusInterfaceArray != null && gp.TCPModbusInterfaceArray[0] != null)
							{
								ModbusInterface readingInterface = gp.TCPModbusInterfaceArray[0];
								if (readingInterface.Enable && readingInterface.RegisterAddress1 > 0)
								{
									if (readingInterface.RegisterAddress1 > 40000)
										currentBase = 40000;
									else
										currentBase = 30000;

									dr["ModbusDataType"] = ModbusDataType.GetModbusDataTypeString(readingInterface.ModbusDataType);
									dr["RegisterAddress1"] = readingInterface.RegisterAddress1;
									dr["Scale"] = readingInterface.Scale;

									if(readingInterface.ModbusDataType == ModbusDataType.Float32)
										dr["RegisterAddress2"] = readingInterface.RegisterAddress2;

									if(readingInterface.CMaxRegisterAddress1 > 0)
                                    {
										dr["CMaxRegisterAddress1"] = readingInterface.CMaxRegisterAddress1;
										dr["CMaxRegisterAddress2"] = readingInterface.CMaxRegisterAddress2;
										dr["CMaxScale"] = readingInterface.CMaxScale;
                                    }
								}

								//if (gp.TCPModbusInterfaceArray.Length > 3 && readingInterface != null &&
								//	gp.TCPModbusInterfaceArray[3].Enable && readingInterface.RegisterAddress1 > 0)
								//{
								//}
							}

							gaugeTable.Rows.Add(dr);

							// Add sounding values and % capacity

							if ((eu.EquipmentType == EquipmentType.Cargo || eu.EquipmentType == EquipmentType.Ballast ||
								eu.EquipmentType == EquipmentType.Fuel || eu.EquipmentType == EquipmentType.Misc) &&
								(gp.GaugeType == GaugeType.Level || gp.GaugeType == GaugeType.Ullage))
							{
								// Volume
								dr = gaugeTable.NewRow();

								dr["EquipmentID"] = eu.EquipmentID;
								dr["ProcessID"] = gp.ProcessID;
								dr["EquipmentName"] = eu.EquipmentTypeString + " - " + eu.Equipment;
								dr["GaugeName"] = "Volume";
								dr["GaugeSort"] = GaugeType.GetModbusGaugeSort(99, 0);

								dr["ModbusInterfaceIndex"] = 1; //index 1: volume if applicable

								if (gp.TCPModbusInterfaceArray != null && gp.TCPModbusInterfaceArray[1] != null)
								{
									ModbusInterface volInterface = gp.TCPModbusInterfaceArray[1];
									if (volInterface.Enable && volInterface.RegisterAddress1 > 0)
									{
										if (gp.TCPModbusInterfaceArray[0].RegisterAddress1 > 40000)
											currentBase = 40000;
										else
											currentBase = 30000;

										dr["ModbusDataType"] = ModbusDataType.GetModbusDataTypeString(volInterface.ModbusDataType);
										dr["RegisterAddress1"] = volInterface.RegisterAddress1;
										dr["Scale"] = volInterface.Scale;

										if (volInterface.ModbusDataType == ModbusDataType.Float32)
											dr["RegisterAddress2"] = volInterface.RegisterAddress2;

										if(volInterface.CMaxRegisterAddress1 > 0)
                                        {
											dr["CMaxRegisterAddress1"] = volInterface.CMaxRegisterAddress1;
											dr["CMaxRegisterAddress2"] = volInterface.CMaxRegisterAddress2;
											dr["CMaxScale"] = volInterface.CMaxScale;
                                        }
									}

									//if (gp.TCPModbusInterfaceArray.Length > 3 && gp.TCPModbusInterfaceArray[3] != null &&
									//	gp.TCPModbusInterfaceArray[3].Enable &&  gp.TCPModbusInterfaceArray[3].RegisterAddress1 > 0)
									//{
									//}
								}

								gaugeTable.Rows.Add(dr);

								// % Capacity
								dr = gaugeTable.NewRow();

								dr["EquipmentID"] = eu.EquipmentID;
								dr["ProcessID"] = gp.ProcessID;
								dr["EquipmentName"] = eu.EquipmentTypeString + " - " + eu.Equipment;
								dr["GaugeName"] = "% Capacity";
								dr["GaugeSort"] = GaugeType.GetModbusGaugeSort(99, 0);

								dr["ModbusInterfaceIndex"] = 2;  //index 2: capacity if applicable

								if (gp.TCPModbusInterfaceArray != null &&
									gp.TCPModbusInterfaceArray.Length > 2 &&
									gp.TCPModbusInterfaceArray[2] != null)
								{
									ModbusInterface capInterface = gp.TCPModbusInterfaceArray[2];
									if (capInterface.Enable && capInterface.RegisterAddress1 > 0)
									{
										if (gp.TCPModbusInterfaceArray[0].RegisterAddress1 > 40000)
											currentBase = 40000;
										else
											currentBase = 30000;

										dr["ModbusDataType"] = ModbusDataType.GetModbusDataTypeString(capInterface.ModbusDataType);
										dr["RegisterAddress1"] = capInterface.RegisterAddress1;
										dr["Scale"] = capInterface.Scale;

										if (capInterface.ModbusDataType == ModbusDataType.Float32)
											dr["RegisterAddress2"] = capInterface.RegisterAddress2;
									}

									if (capInterface.CMaxRegisterAddress1 > 0)
									{
										dr["CMaxRegisterAddress1"] = capInterface.CMaxRegisterAddress1;
										dr["CMaxRegisterAddress2"] = capInterface.CMaxRegisterAddress2;
										dr["CMaxScale"] = capInterface.CMaxScale;
									}
								}

								gaugeTable.Rows.Add(dr);

							}
							else
							{
								if (gp.TCPModbusInterfaceArray != null)
								{
									if (gp.TCPModbusInterfaceArray[1] != null)
										gp.TCPModbusInterfaceArray[1].Enable = false;

									if (gp.TCPModbusInterfaceArray.Length > 2 && gp.TCPModbusInterfaceArray[2] != null)
										gp.TCPModbusInterfaceArray[2].Enable = false;
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
			alarmTable = new DataTable();

			alarmTable.Columns.Add("EquipmentID", typeof(string));
			alarmTable.Columns.Add("ProcessID", typeof(string));
			alarmTable.Columns.Add("AlarmMonitorType", typeof(int));
			alarmTable.Columns.Add("AlarmType", typeof(string));
			alarmTable.Columns.Add("AlarmText", typeof(string));
			alarmTable.Columns.Add("AlarmPriority", typeof(int));
			alarmTable.Columns.Add("Comparator", typeof(string));
			alarmTable.Columns.Add("Limit", typeof(float));
			alarmTable.Columns.Add("EquipmentName", typeof(string));
			alarmTable.Columns.Add("GaugeName", typeof(string));
			alarmTable.Columns.Add("AlarmName", typeof(string));
			alarmTable.Columns.Add("GaugeSort", typeof(int));
			alarmTable.Columns.Add("ModbusDataType", typeof(string));
			alarmTable.Columns.Add("RegisterAddress1", typeof(ushort));

			foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
			{
				if (TLIConfiguration.VesselGaugePoints.ContainsKey(eu.EquipmentID))
					foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[eu.EquipmentID].Values)
					{
						if(TLIConfiguration.VesselAlarmPoints.ContainsKey(eu.EquipmentID))
							if(TLIConfiguration.VesselAlarmPoints[eu.EquipmentID].ContainsKey(gp.ProcessID))
								foreach (AlarmPoint ap in TLIConfiguration.VesselAlarmPoints[eu.EquipmentID][gp.ProcessID].Values)
								{
									dr = alarmTable.NewRow();

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
												currentBase = 40000;
											else
												currentBase = 30000;

											dr["ModbusDataType"] = ModbusDataType.GetModbusDataTypeString(ap.TCPModbusInterface.ModbusDataType);
											dr["RegisterAddress1"] = ap.TCPModbusInterface.RegisterAddress1;
										}
									}

									alarmTable.Rows.Add(dr);
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

				if (editGaugeRow == null)
					return false;

				if (cboAddressRange.SelectedItem.ToString().Contains("3"))
				{
					iMinRange = 30001;
					iMaxRange = 40000;
				}
				else
				{
					iMinRange = 40001;
					iMaxRange = 50000;
				}

				sProcessID = editGaugeRow.Cells["ProcessID"].Value.ToString();
				iRegisterAddress1 = Convert.ToUInt16(editGaugeRow.Cells["RegisterAddress1"].Value);

				if (iRegisterAddress1 < iMinRange || iRegisterAddress1 > iMaxRange)
				{
					MessageBox.Show("Invalid Register LW.  Value must be between " + iMinRange.ToString() + " - " + iMaxRange + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}

				foreach (DataRow dr in gaugeTable.Rows)
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

				foreach (DataRow dr in alarmTable.Rows)
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

				if (editGaugeRow.Cells["ModbusDataType"].Value.ToString() == ModbusDataType.Float32String)
				{
					iRegisterAddress2 = Convert.ToUInt16(editGaugeRow.Cells["RegisterAddress2"].Value);

					if (iRegisterAddress2 < iMinRange || iRegisterAddress2 > iMaxRange)
					{
						MessageBox.Show("Invalid Register HW.  Value must be between " + iMinRange.ToString() + " - " + iMaxRange + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}

					foreach (DataRow dr in gaugeTable.Rows)
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

					foreach (DataRow dr in alarmTable.Rows)
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

				if (editAlarmRow == null)
					return false;

				if (cboAddressRange.SelectedItem.ToString().Contains("3"))
				{
					iMinRange = 30001;
					iMaxRange = 40000;
				}
				else
				{
					iMinRange = 40001;
					iMaxRange = 50000;
				}

				sProcessID = editAlarmRow.Cells["ProcessID"].Value.ToString();
				sAlarmMonitorType = editAlarmRow.Cells["AlarmMonitorType"].Value.ToString();
				sAlarmType = editAlarmRow.Cells["AlarmType"].Value.ToString();
				sAlarmText = editAlarmRow.Cells["AlarmText"].Value.ToString();
				sAlarmPriority = editAlarmRow.Cells["AlarmPriority"].Value.ToString();
				sComparator = editAlarmRow.Cells["Comparator"].Value.ToString();
				sLimit = editAlarmRow.Cells["Limit"].Value.ToString();

				iRegisterAddress1 = Convert.ToUInt16(editAlarmRow.Cells["RegisterAddress1"].Value);

				if (iRegisterAddress1 < iMinRange || iRegisterAddress1 > iMaxRange)
				{
					MessageBox.Show("Invalid register value.  Value must be between " + iMinRange.ToString() + " - " + iMaxRange + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}

				foreach (DataRow dr in gaugeTable.Rows)
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

				foreach (DataRow dr in alarmTable.Rows)
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
			int index;
			GaugePoint gp;

			try
			{
				foreach (DataRow dr in gaugeTable.Rows)
				{
					sEquipmentID = dr["EquipmentID"].ToString();
					sProcessID = dr["ProcessID"].ToString();
					index = Convert.ToInt32(dr["ModbusInterfaceIndex"]);

					if (TLIConfiguration.VesselGaugePoints.ContainsKey(sEquipmentID))
						if (TLIConfiguration.VesselGaugePoints[sEquipmentID].ContainsKey(sProcessID))
						{
							gp = TLIConfiguration.VesselGaugePoints[sEquipmentID][sProcessID];

							if (gp.TCPModbusInterfaceArray == null)
								gp.TCPModbusInterfaceArray = new ModbusInterface[3];

							//if (gp.TCPModbusInterfaceArray.Length < 3)
							//	gp.TCPModbusInterfaceArray = Util.ExtendArray(gp.TCPModbusInterfaceArray, 3);

							if (gp.TCPModbusInterfaceArray[index] == null)
								gp.TCPModbusInterfaceArray[index] = new ModbusInterface();

							if (dr["RegisterAddress1"] != DBNull.Value &&
								dr["RegisterAddress1"].ToString() != "" &&
								dr["RegisterAddress1"].ToString() != "0")
							{
								gp.TCPModbusInterfaceArray[index].Enable = true;
								gp.TCPModbusInterfaceArray[index].ModbusDataType = ModbusDataType.GetModbusDataTypeID(dr["ModbusDataType"].ToString());
								gp.TCPModbusInterfaceArray[index].RegisterAddress1 = Convert.ToUInt16(dr["RegisterAddress1"]);
								gp.TCPModbusInterfaceArray[index].Scale = Convert.ToSingle(dr["Scale"] == DBNull.Value ? 1 : dr["Scale"]);

								if (gp.TCPModbusInterfaceArray[index].ModbusDataType == ModbusDataType.Float32)
									gp.TCPModbusInterfaceArray[index].RegisterAddress2 = Convert.ToUInt16(dr["RegisterAddress2"]);
								else
									gp.TCPModbusInterfaceArray[index].RegisterAddress2 = 0;

								if (dr["CMaxRegisterAddress1"] != DBNull.Value &&
									dr["CMaxRegisterAddress1"].ToString() != "" &&
									dr["CMaxRegisterAddress1"].ToString() != "0")
								{
									gp.TCPModbusInterfaceArray[index].CMaxRegisterAddress1 = Convert.ToUInt16(dr["CMaxRegisterAddress1"]);
									gp.TCPModbusInterfaceArray[index].CMaxRegisterAddress2 = Convert.ToUInt16(dr["CMaxRegisterAddress2"]);
									gp.TCPModbusInterfaceArray[index].CMaxScale = Convert.ToSingle(dr["CMaxScale"] == DBNull.Value ? 1 : dr["CMaxScale"]);
								}
								else
                                {
									gp.TCPModbusInterfaceArray[index].CMaxRegisterAddress1 = 0;
									gp.TCPModbusInterfaceArray[index].CMaxRegisterAddress2 = 0;
									gp.TCPModbusInterfaceArray[index].CMaxScale = 0;
								}
							}
							else
								gp.TCPModbusInterfaceArray[index].Enable = false;
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
				foreach (DataRow dr in alarmTable.Rows)
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
									if (ap.TCPModbusInterface == null)
										ap.TCPModbusInterface = new ModbusInterface();

									if (dr["RegisterAddress1"] != DBNull.Value &&
										dr["RegisterAddress1"].ToString() != "" &&
										dr["RegisterAddress1"].ToString() != "0")
									{
										ap.TCPModbusInterface.Enable = true;
										ap.TCPModbusInterface.ModbusDataType = ModbusDataType.Int16;
										ap.TCPModbusInterface.RegisterAddress1 = Convert.ToUInt16(dr["RegisterAddress1"]);
										ap.TCPModbusInterface.RegisterAddress2 = 0;
										ap.TCPModbusInterface.Scale = 1;
									}
									else
										ap.TCPModbusInterface.Enable = false;
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

		private void CopySerialGaugeValues()
		{
			DataRow dr;
			gaugeTable.Rows.Clear();

			foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
			{
				if (TLIConfiguration.VesselGaugePoints.ContainsKey(eu.EquipmentID))
				{
					foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[eu.EquipmentID].Values)
					{
						if (gp.GaugeType != GaugeType.ChannelStateAlarmMonitor)
						{
							dr = gaugeTable.NewRow();

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
										if (gp.ModbusInterfaceArray[0].RegisterAddress1 > 40000)
											currentBase = 40000;
										else
											currentBase = 30000;

										dr["ModbusDataType"] = ModbusDataType.GetModbusDataTypeString(gp.ModbusInterfaceArray[0].ModbusDataType);
										dr["RegisterAddress1"] = gp.ModbusInterfaceArray[0].RegisterAddress1;
										dr["Scale"] = gp.ModbusInterfaceArray[0].Scale;

										if (gp.ModbusInterfaceArray[0].ModbusDataType == ModbusDataType.Float32)
											dr["RegisterAddress2"] = gp.ModbusInterfaceArray[0].RegisterAddress2;
									}
								}
							}

							gaugeTable.Rows.Add(dr);

							// Add sounding values and % capacity

							if ((eu.EquipmentType == EquipmentType.Cargo ||
								eu.EquipmentType == EquipmentType.Ballast ||
								eu.EquipmentType == EquipmentType.Fuel ||
								eu.EquipmentType == EquipmentType.Misc) &&
								(gp.GaugeType == GaugeType.Level || gp.GaugeType == GaugeType.Ullage))
							{
								// Volume
								dr = gaugeTable.NewRow();

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
												currentBase = 40000;
											else
												currentBase = 30000;

											dr["ModbusDataType"] = ModbusDataType.GetModbusDataTypeString(gp.ModbusInterfaceArray[1].ModbusDataType);
											dr["RegisterAddress1"] = gp.ModbusInterfaceArray[1].RegisterAddress1;
											dr["Scale"] = gp.ModbusInterfaceArray[1].Scale;

											if (gp.ModbusInterfaceArray[1].ModbusDataType == ModbusDataType.Float32)
												dr["RegisterAddress2"] = gp.ModbusInterfaceArray[1].RegisterAddress2;
										}
									}
								}

								gaugeTable.Rows.Add(dr);

								// % Capacity
								dr = gaugeTable.NewRow();

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
												currentBase = 40000;
											else
												currentBase = 30000;

											dr["ModbusDataType"] = ModbusDataType.GetModbusDataTypeString(gp.ModbusInterfaceArray[2].ModbusDataType);
											dr["RegisterAddress1"] = gp.ModbusInterfaceArray[2].RegisterAddress1;
											dr["Scale"] = gp.ModbusInterfaceArray[2].Scale;

											if (gp.ModbusInterfaceArray[2].ModbusDataType == ModbusDataType.Float32)
												dr["RegisterAddress2"] = gp.ModbusInterfaceArray[2].RegisterAddress2;
										}
									}
								}

								gaugeTable.Rows.Add(dr);
							}
						}
					}
				}
			}
		}

		private void CopySerialAlarmValues()
		{
			DataRow dr;
			alarmTable.Rows.Clear();

			foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
			{
				if (TLIConfiguration.VesselGaugePoints.ContainsKey(eu.EquipmentID))
					foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[eu.EquipmentID].Values)
					{
						if (TLIConfiguration.VesselAlarmPoints.ContainsKey(eu.EquipmentID))
							if (TLIConfiguration.VesselAlarmPoints[eu.EquipmentID].ContainsKey(gp.ProcessID))
								foreach (AlarmPoint ap in TLIConfiguration.VesselAlarmPoints[eu.EquipmentID][gp.ProcessID].Values)
								{
									dr = alarmTable.NewRow();

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
											if (ap.ModbusInterface.RegisterAddress1 > 40000)
												currentBase = 40000;
											else
												currentBase = 30000;

											dr["ModbusDataType"] = ModbusDataType.GetModbusDataTypeString(ap.ModbusInterface.ModbusDataType);
											dr["RegisterAddress1"] = ap.ModbusInterface.RegisterAddress1;
										}
									}

									alarmTable.Rows.Add(dr);
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
			editGaugeRow = (Xceed.Grid.DataRow)sender;
		}

		private void BeginningAlarmEdit(object sender, CancelEventArgs e)
		{
			editAlarmRow = (Xceed.Grid.DataRow)sender;
		}

		private void EditGaugeBegun(object sender, EventArgs e)
		{
			bool bFirstRegister = true;
			ushort iMaxRegister;

			if (editGaugeRow.Cells["RegisterAddress1"].Value == DBNull.Value ||
				editGaugeRow.Cells["RegisterAddress1"].Value.ToString() == "")
			{
				if (cboAddressRange.SelectedItem.ToString().Contains("3"))
					iMaxRegister = 30001;
				else
					iMaxRegister = 40001;

				foreach (DataRow dr in gaugeTable.Rows)
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

				foreach (DataRow dr in alarmTable.Rows)
				{
					if(dr["RegisterAddress1"] != DBNull.Value)
						if (Convert.ToUInt16(dr["RegisterAddress1"]) >= iMaxRegister)
						{
							iMaxRegister = Convert.ToUInt16(dr["RegisterAddress1"]);
							bFirstRegister = false;
						}
				}

				if(bFirstRegister)
					editGaugeRow.Cells["RegisterAddress1"].Value = iMaxRegister;
				else
					editGaugeRow.Cells["RegisterAddress1"].Value = iMaxRegister + 1;

				editGaugeRow.Cells["Scale"].Value = 1;
			}
		}

		private void EditAlarmBegun(object sender, EventArgs e)
		{
			bool bFirstRegister = true;
			ushort iMaxRegister;

			if (editAlarmRow.Cells["RegisterAddress1"].Value == DBNull.Value ||
				editAlarmRow.Cells["RegisterAddress1"].Value.ToString() == "")
			{
				if (cboAddressRange.SelectedItem.ToString().Contains("3"))
					iMaxRegister = 30001;
				else
					iMaxRegister = 40001;

				foreach (DataRow dr in gaugeTable.Rows)
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

				foreach (DataRow dr in alarmTable.Rows)
				{
					if (dr["RegisterAddress1"] != DBNull.Value)
						if (Convert.ToUInt16(dr["RegisterAddress1"]) >= iMaxRegister)
						{
							iMaxRegister = Convert.ToUInt16(dr["RegisterAddress1"]);
							bFirstRegister = false;
						}
				}

				if (bFirstRegister)
					editAlarmRow.Cells["RegisterAddress1"].Value = iMaxRegister;
				else
					editAlarmRow.Cells["RegisterAddress1"].Value = iMaxRegister + 1;
			}
		}

		private void EndingGaugeEdit(object sender, CancelEventArgs e)
		{
			if (Disposing)
				return;

			if (editGaugeRow != null)
			{
				if (editGaugeRow.Cells["CMaxRegisterAddress1"].Value == DBNull.Value) {
					editGaugeRow.Cells["CMaxRegisterAddress1"].Value = DBNull.Value;
					editGaugeRow.Cells["CMaxRegisterAddress2"].Value = DBNull.Value;
					editGaugeRow.Cells["CMaxScale"].Value = DBNull.Value;
				}
				if (editGaugeRow.Cells["RegisterAddress1"].Value == DBNull.Value)
				{
					editGaugeRow.Cells["ModbusDataType"].Value = DBNull.Value;
					editGaugeRow.Cells["RegisterAddress1"].Value = DBNull.Value;
					editGaugeRow.Cells["RegisterAddress2"].Value = DBNull.Value;
					editGaugeRow.Cells["Scale"].Value = DBNull.Value;
					editGaugeRow = null;
					return;
				}

				if (!e.Cancel)
				{
					gcGauge.EnforceNonBlankCell(editGaugeRow.Cells["ModbusDataType"], "Data Type", e);
					gcGauge.EnforceNonBlankCell(editGaugeRow.Cells["RegisterAddress1"], "Register LW", e);
					gcGauge.EnforceNonBlankCell(editGaugeRow.Cells["Scale"], "Scale", e);
				
					if (editGaugeRow.Cells["ModbusDataType"].Value.ToString() == ModbusDataType.GetModbusDataTypeString(ModbusDataType.Float32))
						editGaugeRow.Cells["RegisterAddress2"].Value = Convert.ToUInt16(editGaugeRow.Cells["RegisterAddress1"].Value) + 1;
					else
						editGaugeRow.Cells["RegisterAddress2"].Value = DBNull.Value;

					int.TryParse(editGaugeRow.Cells["CMaxRegisterAddress1"].Value.ToString(), out int reg1);
					if (reg1 > 0)
                    {
						editGaugeRow.Cells["CMaxRegisterAddress2"].Value = Convert.ToUInt16(editGaugeRow.Cells["CMaxRegisterAddress1"].Value) + 1;
						if(editGaugeRow.Cells["CMaxScale"].Value == DBNull.Value)
							editGaugeRow.Cells["CMaxScale"].Value = 1;
					}
				}

				if (!e.Cancel && !ValidateGaugeEditRow())
					e.Cancel = true;
			}
			
			editGaugeRow = null;
		}

		private void EndingAlarmEdit(object sender, CancelEventArgs e)
		{
			if (Disposing)
				return;

			if (editAlarmRow != null)
			{
				if (editAlarmRow.Cells["RegisterAddress1"].Value == DBNull.Value)
				{
					editAlarmRow.Cells["RegisterAddress1"].Value = DBNull.Value;
					editAlarmRow = null;
					return;
				}

				if (!e.Cancel) gcAlarm.EnforceNonBlankCell(editAlarmRow.Cells["RegisterAddress1"], "Register", e);

				if (!e.Cancel && !ValidateAlarmEditRow())
					e.Cancel = true;
			}

			editAlarmRow = null;
		}

		private void SelectedRowChanged(object sender, EventArgs e)
        {
			//Xceed.Grid.DataRow x = (Xceed.Grid.DataRow)sender;
			Console.WriteLine("SELECT : ");
        }

		private void CboAddressRange_SelectedIndexChanged(object sender, EventArgs e)
		{
			int iOffset;

			if (cboAddressRange.SelectedItem.ToString().Contains("3"))
			{
				currentBase = 30000;
				iOffset = -10000;
			}
			else
			{
				currentBase = 40000;
				iOffset = 10000;
			}

			foreach (DataRow dr in gaugeTable.Rows)
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

			foreach (DataRow dr in alarmTable.Rows)
			{
				if (dr["RegisterAddress1"] != DBNull.Value &&
					dr["RegisterAddress1"].ToString() != "" &&
					dr["RegisterAddress1"].ToString() != "0")
				{
					dr["RegisterAddress1"] = Convert.ToUInt16(dr["RegisterAddress1"]) + iOffset;
				}
			}
		}

		private void CmdCopy_Click(object sender, EventArgs e)
		{
			DialogResult dr;
			dr = MessageBox.Show("Are you sure that you want to copy all register values from the Serial interface?", "Copy Serial Interface", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (dr == DialogResult.Yes)
			{
				CopySerialGaugeValues();
				CopySerialAlarmValues();
			}
		}

		private void CmdOk_Click(object sender, EventArgs e)
		{
			if (SaveGaugeValues() && SaveAlarmValues())// && SaveReceivingValues())
			{
				TLIConfiguration.Vessel.IncludeSystemStatusModbusTCP = chkIncludeSystemStatus.Checked;

				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void CmdClearGauge_Click(object sender, EventArgs e)
		{
			DialogResult drlt;
			drlt = MessageBox.Show("Are you sure that you want to clear all register values?", "Clear Registers", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (drlt == DialogResult.Yes)
			{
				foreach (DataRow dr in gaugeTable.Rows)
				{
					dr["ModbusDataType"] = DBNull.Value;
					dr["RegisterAddress1"] = DBNull.Value;
					dr["RegisterAddress2"] = DBNull.Value;
					dr["Scale"] = DBNull.Value;
				}

				foreach (DataRow dr in alarmTable.Rows)
				{
					dr["ModbusDataType"] = DBNull.Value;
					dr["RegisterAddress1"] = DBNull.Value;
				}
			}
		}

		private void CmdCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}