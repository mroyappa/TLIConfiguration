using System;
using System.Text;
using System.Collections.Generic;
using ICBObjectModel;
using ICBObjectModel.Enumerations;

/*
 * CLASS SUMMARY:	VesselConfigurationExport
 * 
 * VesselConfigurationExport is the class which creates the Excel Vessel configuration document.
 * 
 */

namespace TLIConfiguration
{
	public class VesselConfigurationExport
	{
		private ExcelXml m_ExcelExport;

		private SortedDictionary<string, string> m_CargoEquipment;
		private SortedDictionary<string, string> m_ManifoldEquipment;
		private SortedDictionary<string, string> m_BallastEquipment;
		private SortedDictionary<string, string> m_ServiceEquipment;
		private SortedDictionary<string, string> m_MiscEquipment;
		private SortedDictionary<string, string> m_DraftEquipment;
		private SortedDictionary<string, string> m_TrimListEquipment;
		private SortedList<int, string> m_LoadComputerExportOrder;

		public VesselConfigurationExport()
		{
			SortObjects();
		}

		public void BuildExcelExport(string sFilename)
		{
			m_ExcelExport = new ExcelXml(sFilename, "TLI Configuration");

			BuildVesselConfigWorksheet();
			BuildAMUWorksheet();
			BuildTAUWorksheet();
			BuildModularBubblerWorksheet();
			BuildLoadComputerExportOrderWorksheet();
			BuildCargoUllageWorksheet();
			BuildCargoTemperatureWorksheet();
			BuildCargoPressureWorksheet();
			BuildPumpManifoldWorksheet();
			BuildBallastWorksheet();
			BuildServiceWorksheet();
			BuildMiscWorksheet();
			BuildAlarmWorkSheet();

			m_ExcelExport.Close();
		}

		private void BuildVesselConfigWorksheet()
		{
			m_ExcelExport.NewWorkSheet("Vessel");

			// General
			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("General", ExcelXml.STYLE_BOLD);
			m_ExcelExport.EndRow();

			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("Vessel", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Vessel Type", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Owner", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Class", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Yard", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Yard No", ExcelXml.STYLE_UL);
			m_ExcelExport.EndRow();

			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell(TLIConfiguration.Vessel.VesselName);
			m_ExcelExport.AddTextCell(VesselType.GetVesselTypeString(TLIConfiguration.Vessel.VesselType));
			m_ExcelExport.AddTextCell(TLIConfiguration.Vessel.Owner);
			m_ExcelExport.AddTextCell(TLIConfiguration.Vessel.Class);
			m_ExcelExport.AddTextCell(TLIConfiguration.Vessel.Yard);
			m_ExcelExport.AddTextCell(TLIConfiguration.Vessel.YardNo);
			m_ExcelExport.EndRow();

			m_ExcelExport.AddEmptyRow();

			// System Configuration
			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("System Configuration", ExcelXml.STYLE_BOLD);
			m_ExcelExport.EndRow();

			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("Trend Arrow Enabled", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Trend Arrow Timeout", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Measurement System", ExcelXml.STYLE_UL);
			m_ExcelExport.EndRow();

			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell(TLIConfiguration.Vessel.FaceplateTrendEnable.ToString());
			m_ExcelExport.AddTextCell(TLIConfiguration.Vessel.FaceplateTrendTimeout.ToString());
			m_ExcelExport.AddTextCell(TLIConfiguration.Vessel.MeasurementSystemString);
			m_ExcelExport.EndRow();

			m_ExcelExport.AddEmptyRow();

			// Setup Information
			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("Setup Information", ExcelXml.STYLE_BOLD);
			m_ExcelExport.EndRow();

			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("Configured By", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Configuration Date", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Commissioning Engineer", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Warranty Expiration", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Configuration History", ExcelXml.STYLE_UL);
			m_ExcelExport.EndRow();

			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell(TLIConfiguration.Vessel.ConfiguredBy);
			m_ExcelExport.AddTextCell(TLIConfiguration.Vessel.Configured.ToString("MM/dd/yyyy"));
			m_ExcelExport.AddTextCell(TLIConfiguration.Vessel.CommissioningEngineer);
			m_ExcelExport.AddTextCell(TLIConfiguration.Vessel.WarrantyExpiration.ToString("MM/dd/yyyy"));
			m_ExcelExport.AddTextCell(TLIConfiguration.Vessel.ConfigurationHistory);
			m_ExcelExport.EndRow();

			m_ExcelExport.AddEmptyRow();

			// Alarm Annunciations
			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("Alarm Annunciations", ExcelXml.STYLE_BOLD);
			m_ExcelExport.EndRow();

			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("Annunciation", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("AMU", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Channel", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Enabled", ExcelXml.STYLE_UL);
			m_ExcelExport.EndRow();

			foreach (AlarmAnnunciation aa in TLIConfiguration.Vessel.AlarmAnnunciation)
			{
				m_ExcelExport.NewRow();
				m_ExcelExport.AddTextCell(aa.AlarmAnnunciationName);
				m_ExcelExport.AddTextCell(aa.AMUOutputAddress.ToString());
				m_ExcelExport.AddTextCell(aa.AMUOutputDigitalChannel.ToString());
				m_ExcelExport.AddTextCell(aa.AMUOutputEnable.ToString());
				m_ExcelExport.EndRow();
			}

			m_ExcelExport.AddEmptyRow();

			//Alarm Priorities
			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("Alarm Priorities", ExcelXml.STYLE_BOLD);
			m_ExcelExport.EndRow();

			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("Priority", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Description", ExcelXml.STYLE_UL);
			m_ExcelExport.EndRow();

			foreach(AlarmPriority ap in TLIConfiguration.Vessel.AlarmPriority)
			{
				m_ExcelExport.NewRow();
				m_ExcelExport.AddTextCell(ap.Priority.ToString());
				m_ExcelExport.AddTextCell(ap.Description);
				m_ExcelExport.EndRow();
			}

			m_ExcelExport.AddEmptyRow();

			//AMUs
			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("AMUs", ExcelXml.STYLE_BOLD);
			m_ExcelExport.EndRow();

			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("Address", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Description", ExcelXml.STYLE_UL);
			m_ExcelExport.EndRow();

			foreach (AMU amu in TLIConfiguration.Vessel.AMUArray)
			{
				m_ExcelExport.NewRow();
				m_ExcelExport.AddTextCell(amu.AMUAddress.ToString());
				m_ExcelExport.AddTextCell(amu.Description);
				m_ExcelExport.EndRow();
			}

			m_ExcelExport.AddEmptyRow();

			//Products
			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("Products", ExcelXml.STYLE_BOLD);
			m_ExcelExport.EndRow();

			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("Name", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Specific Gravity", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Cargo", ExcelXml.STYLE_UL);
			m_ExcelExport.EndRow();

			foreach (Product p in TLIConfiguration.Vessel.Product)
			{
				m_ExcelExport.NewRow();
				m_ExcelExport.AddTextCell(p.ProductName);
				m_ExcelExport.AddTextCell(p.SpecificGravity.ToString("f2"));
				m_ExcelExport.AddTextCell(p.Cargo.ToString());
				m_ExcelExport.EndRow();
			}

			m_ExcelExport.AddEmptyRow();

			//TAUs
			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("TAUs", ExcelXml.STYLE_BOLD);
			m_ExcelExport.EndRow();

			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("Address", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Description", ExcelXml.STYLE_UL);
			m_ExcelExport.EndRow();

			foreach (TAU tau in TLIConfiguration.Vessel.TAUArray)
			{
				m_ExcelExport.NewRow();
				m_ExcelExport.AddTextCell(tau.TAUAddress.ToString());
				m_ExcelExport.AddTextCell(tau.Description);
				m_ExcelExport.EndRow();
			}

			m_ExcelExport.AddEmptyRow();

			//SCUs
			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("SCUs", ExcelXml.STYLE_BOLD);
			m_ExcelExport.EndRow();

			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("Tank Name", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("TAU", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("SCU Channel", ExcelXml.STYLE_UL);
			m_ExcelExport.EndRow();

			foreach (SCU scu in TLIConfiguration.Vessel.SCUArray)
			{
				m_ExcelExport.NewRow();
				m_ExcelExport.AddTextCell(scu.TankName);
				m_ExcelExport.AddTextCell(scu.TAUAddress.ToString());
				m_ExcelExport.AddTextCell(scu.SCUChannel.ToString());
				m_ExcelExport.EndRow();
			}

			m_ExcelExport.AddEmptyRow();

			//Modular Bubblers
			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("Modular Bubblers", ExcelXml.STYLE_BOLD);
			m_ExcelExport.EndRow();

			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("Address", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Description", ExcelXml.STYLE_UL);
			m_ExcelExport.EndRow();

			foreach (ModularBubbler modularBubbler in TLIConfiguration.Vessel.ModularBubblerArray)
			{
				m_ExcelExport.NewRow();
				m_ExcelExport.AddTextCell(modularBubbler.ModularBubblerAddress.ToString());
				m_ExcelExport.AddTextCell(modularBubbler.Description);
				m_ExcelExport.EndRow();
			}

			m_ExcelExport.AddEmptyRow();

			//Modular Bubbler Channels
			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("Modular Bubbler Channels", ExcelXml.STYLE_BOLD);
			m_ExcelExport.EndRow();

			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("Bubbler Address", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Channel", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Board Type", ExcelXml.STYLE_UL);
			m_ExcelExport.EndRow();

			foreach (ModularBubblerChannel modularBubblerChannel in TLIConfiguration.Vessel.ModularBubberChannelArray)
			{
				m_ExcelExport.NewRow();
				m_ExcelExport.AddTextCell(modularBubblerChannel.ModularBubblerAddress.ToString());
				m_ExcelExport.AddTextCell(modularBubblerChannel.Channel.ToString());
				m_ExcelExport.AddTextCell(modularBubblerChannel.BoardType.ToString());
				m_ExcelExport.EndRow();
			}

			m_ExcelExport.AddEmptyRow();
			m_ExcelExport.EndWorkSheet();
		}

		private void BuildAMUWorksheet()
		{
			EquipmentUnit eu;
			GaugePoint gp;

			foreach (AMU amu in TLIConfiguration.Vessel.AMUArray)
			{
				m_ExcelExport.NewWorkSheet("AMU" + amu.AMUAddress.ToString());

				m_ExcelExport.NewRow();
				m_ExcelExport.AddTextCell("AMU" + amu.AMUAddress.ToString(), ExcelXml.STYLE_BOLD);
				m_ExcelExport.EndRow();

				m_ExcelExport.AddEmptyRow();

				m_ExcelExport.NewRow();
				m_ExcelExport.AddTextCell("Channel", ExcelXml.STYLE_UL);
				m_ExcelExport.AddTextCell("Description", ExcelXml.STYLE_UL);
				m_ExcelExport.AddTextCell("Alarm Points", ExcelXml.STYLE_UL);
				m_ExcelExport.EndRow();

				for(int iChannel = 1; iChannel <= 32; iChannel++)
				{
					m_ExcelExport.NewRow();
					m_ExcelExport.AddTextCell(iChannel.ToString());

					if(FindGaugePointByAMUAddress(amu.AMUAddress, iChannel, out eu, out gp))
					{
						m_ExcelExport.AddTextCell(eu.EquipmentTypeString + " " + eu.Equipment + " " + gp.DisplayName);

						if(TLIConfiguration.VesselAlarmPoints.ContainsKey(eu.EquipmentID))
							if (TLIConfiguration.VesselAlarmPoints[eu.EquipmentID].ContainsKey(gp.ProcessID))
								foreach (AlarmPoint ap in TLIConfiguration.VesselAlarmPoints[eu.EquipmentID][gp.ProcessID].Values)
									m_ExcelExport.AddTextCell(ap.AlarmText);
					}

					m_ExcelExport.EndRow();
				}

				m_ExcelExport.EndWorkSheet();
			}
		}

		private void BuildTAUWorksheet()
		{
			EquipmentUnit eu;
			GaugePoint gp;

			foreach (TAU tau in TLIConfiguration.Vessel.TAUArray)
			{
				m_ExcelExport.NewWorkSheet("TAU" + tau.TAUAddress.ToString());

				m_ExcelExport.NewRow();
				m_ExcelExport.AddTextCell("TAU" + tau.TAUAddress.ToString(), ExcelXml.STYLE_BOLD);
				m_ExcelExport.EndRow();

				m_ExcelExport.AddEmptyRow();

				m_ExcelExport.NewRow();
				m_ExcelExport.AddTextCell("Channel", ExcelXml.STYLE_UL);
				m_ExcelExport.AddTextCell("Channel Type", ExcelXml.STYLE_UL);
				m_ExcelExport.AddTextCell("Description", ExcelXml.STYLE_UL);
				m_ExcelExport.AddTextCell("Alarm Points", ExcelXml.STYLE_UL);
				m_ExcelExport.EndRow();

				for (int iChannel = 1; iChannel <= 32; iChannel++)
				{
					// LEVEL 1
					m_ExcelExport.NewRow();
					m_ExcelExport.AddTextCell(iChannel.ToString());
					m_ExcelExport.AddTextCell(TAUChannelGroupType.GetChannelGroupTypeString(TAUChannelGroupType.LEVEL_1));

					if (FindGaugePointByTAUAddress(tau.TAUAddress, iChannel, TAUChannelGroupType.LEVEL_1, out eu, out gp))
					{
						m_ExcelExport.AddTextCell(eu.EquipmentTypeString + " " + eu.Equipment + " " + gp.DisplayName);

						if (TLIConfiguration.VesselAlarmPoints.ContainsKey(eu.EquipmentID))
							if (TLIConfiguration.VesselAlarmPoints[eu.EquipmentID].ContainsKey(gp.ProcessID))
								foreach (AlarmPoint ap in TLIConfiguration.VesselAlarmPoints[eu.EquipmentID][gp.ProcessID].Values)
									m_ExcelExport.AddTextCell(ap.AlarmText);
					}

					m_ExcelExport.EndRow();


					// LEVEL 2
					m_ExcelExport.NewRow();
					m_ExcelExport.AddTextCell(iChannel.ToString());
					m_ExcelExport.AddTextCell(TAUChannelGroupType.GetChannelGroupTypeString(TAUChannelGroupType.LEVEL_2));

					if (FindGaugePointByTAUAddress(tau.TAUAddress, iChannel, TAUChannelGroupType.LEVEL_2, out eu, out gp))
					{
						m_ExcelExport.AddTextCell(eu.EquipmentTypeString + " " + eu.Equipment + " " + gp.DisplayName);

						if (TLIConfiguration.VesselAlarmPoints.ContainsKey(eu.EquipmentID))
							if (TLIConfiguration.VesselAlarmPoints[eu.EquipmentID].ContainsKey(gp.ProcessID))
								foreach (AlarmPoint ap in TLIConfiguration.VesselAlarmPoints[eu.EquipmentID][gp.ProcessID].Values)
									m_ExcelExport.AddTextCell(ap.AlarmText);
					}

					m_ExcelExport.EndRow();


					// IG PRESSURE
					m_ExcelExport.NewRow();
					m_ExcelExport.AddTextCell(iChannel.ToString());
					m_ExcelExport.AddTextCell(TAUChannelGroupType.GetChannelGroupTypeString(TAUChannelGroupType.IG_PRESSURE));

					if (FindGaugePointByTAUAddress(tau.TAUAddress, iChannel, TAUChannelGroupType.IG_PRESSURE, out eu, out gp))
					{
						m_ExcelExport.AddTextCell(eu.EquipmentTypeString + " " + eu.Equipment + " " + gp.DisplayName);

						if (TLIConfiguration.VesselAlarmPoints.ContainsKey(eu.EquipmentID))
							if (TLIConfiguration.VesselAlarmPoints[eu.EquipmentID].ContainsKey(gp.ProcessID))
								foreach (AlarmPoint ap in TLIConfiguration.VesselAlarmPoints[eu.EquipmentID][gp.ProcessID].Values)
									m_ExcelExport.AddTextCell(ap.AlarmText);
					}

					m_ExcelExport.EndRow();


					// TEMP 1
					m_ExcelExport.NewRow();
					m_ExcelExport.AddTextCell(iChannel.ToString());
					m_ExcelExport.AddTextCell(TAUChannelGroupType.GetChannelGroupTypeString(TAUChannelGroupType.TEMPERATURE_1));

					if (FindGaugePointByTAUAddress(tau.TAUAddress, iChannel, TAUChannelGroupType.TEMPERATURE_1, out eu, out gp))
					{
						m_ExcelExport.AddTextCell(eu.EquipmentTypeString + " " + eu.Equipment + " " + gp.DisplayName);

						if (TLIConfiguration.VesselAlarmPoints.ContainsKey(eu.EquipmentID))
							if (TLIConfiguration.VesselAlarmPoints[eu.EquipmentID].ContainsKey(gp.ProcessID))
								foreach (AlarmPoint ap in TLIConfiguration.VesselAlarmPoints[eu.EquipmentID][gp.ProcessID].Values)
									m_ExcelExport.AddTextCell(ap.AlarmText);
					}

					m_ExcelExport.EndRow();


					// TEMP2
					m_ExcelExport.NewRow();
					m_ExcelExport.AddTextCell(iChannel.ToString());
					m_ExcelExport.AddTextCell(TAUChannelGroupType.GetChannelGroupTypeString(TAUChannelGroupType.TEMPERATURE_2));

					if (FindGaugePointByTAUAddress(tau.TAUAddress, iChannel, TAUChannelGroupType.TEMPERATURE_2, out eu, out gp))
					{
						m_ExcelExport.AddTextCell(eu.EquipmentTypeString + " " + eu.Equipment + " " + gp.DisplayName);

						if (TLIConfiguration.VesselAlarmPoints.ContainsKey(eu.EquipmentID))
							if (TLIConfiguration.VesselAlarmPoints[eu.EquipmentID].ContainsKey(gp.ProcessID))
								foreach (AlarmPoint ap in TLIConfiguration.VesselAlarmPoints[eu.EquipmentID][gp.ProcessID].Values)
									m_ExcelExport.AddTextCell(ap.AlarmText);
					}

					m_ExcelExport.EndRow();


					// TEMP 3
					m_ExcelExport.NewRow();
					m_ExcelExport.AddTextCell(iChannel.ToString());
					m_ExcelExport.AddTextCell(TAUChannelGroupType.GetChannelGroupTypeString(TAUChannelGroupType.TEMPERATURE_3));

					if (FindGaugePointByTAUAddress(tau.TAUAddress, iChannel, TAUChannelGroupType.TEMPERATURE_3, out eu, out gp))
					{
						m_ExcelExport.AddTextCell(eu.EquipmentTypeString + " " + eu.Equipment + " " + gp.DisplayName);

						if (TLIConfiguration.VesselAlarmPoints.ContainsKey(eu.EquipmentID))
							if (TLIConfiguration.VesselAlarmPoints[eu.EquipmentID].ContainsKey(gp.ProcessID))
								foreach (AlarmPoint ap in TLIConfiguration.VesselAlarmPoints[eu.EquipmentID][gp.ProcessID].Values)
									m_ExcelExport.AddTextCell(ap.AlarmText);
					}

					m_ExcelExport.EndRow();


					// ULLAGE 1
					m_ExcelExport.NewRow();
					m_ExcelExport.AddTextCell(iChannel.ToString());
					m_ExcelExport.AddTextCell(TAUChannelGroupType.GetChannelGroupTypeString(TAUChannelGroupType.ULLAGE_1));

					if (FindGaugePointByTAUAddress(tau.TAUAddress, iChannel, TAUChannelGroupType.ULLAGE_1, out eu, out gp))
					{
						m_ExcelExport.AddTextCell(eu.EquipmentTypeString + " " + eu.Equipment + " " + gp.DisplayName);

						if (TLIConfiguration.VesselAlarmPoints.ContainsKey(eu.EquipmentID))
							if (TLIConfiguration.VesselAlarmPoints[eu.EquipmentID].ContainsKey(gp.ProcessID))
								foreach (AlarmPoint ap in TLIConfiguration.VesselAlarmPoints[eu.EquipmentID][gp.ProcessID].Values)
									m_ExcelExport.AddTextCell(ap.AlarmText);
					}

					m_ExcelExport.EndRow();


					// ULLAGE 2
					m_ExcelExport.NewRow();
					m_ExcelExport.AddTextCell(iChannel.ToString());
					m_ExcelExport.AddTextCell(TAUChannelGroupType.GetChannelGroupTypeString(TAUChannelGroupType.ULLAGE_2));

					if (FindGaugePointByTAUAddress(tau.TAUAddress, iChannel, TAUChannelGroupType.ULLAGE_2, out eu, out gp))
					{
						m_ExcelExport.AddTextCell(eu.EquipmentTypeString + " " + eu.Equipment + " " + gp.DisplayName);

						if (TLIConfiguration.VesselAlarmPoints.ContainsKey(eu.EquipmentID))
							if (TLIConfiguration.VesselAlarmPoints[eu.EquipmentID].ContainsKey(gp.ProcessID))
								foreach (AlarmPoint ap in TLIConfiguration.VesselAlarmPoints[eu.EquipmentID][gp.ProcessID].Values)
									m_ExcelExport.AddTextCell(ap.AlarmText);
					}

					m_ExcelExport.EndRow();
				}

				m_ExcelExport.EndWorkSheet();
			}
		}

		private void BuildModularBubblerWorksheet()
		{
			EquipmentUnit eu;
			GaugePoint gp;

			foreach (ModularBubbler bub in TLIConfiguration.Vessel.ModularBubblerArray)
			{
				m_ExcelExport.NewWorkSheet("Modular Bubbler" + bub.ModularBubblerAddress.ToString());

				m_ExcelExport.NewRow();
				m_ExcelExport.AddTextCell("Modular Bubbler" + bub.ModularBubblerAddress.ToString(), ExcelXml.STYLE_BOLD);
				m_ExcelExport.EndRow();

				m_ExcelExport.AddEmptyRow();

				m_ExcelExport.NewRow();
				m_ExcelExport.AddTextCell("Channel", ExcelXml.STYLE_UL);
				m_ExcelExport.AddTextCell("Description", ExcelXml.STYLE_UL);
				m_ExcelExport.AddTextCell("Alarm Points", ExcelXml.STYLE_UL);
				m_ExcelExport.EndRow();

				for (int iChannel = 1; iChannel <= 8; iChannel++)
				{
					m_ExcelExport.NewRow();
					m_ExcelExport.AddTextCell(iChannel.ToString());

					if (FindGaugePointByBUBAddress(bub.ModularBubblerAddress, iChannel, out eu, out gp))
					{
						m_ExcelExport.AddTextCell(eu.EquipmentTypeString + " " + eu.Equipment + " " + gp.DisplayName);

						if (TLIConfiguration.VesselAlarmPoints.ContainsKey(eu.EquipmentID))
							if (TLIConfiguration.VesselAlarmPoints[eu.EquipmentID].ContainsKey(gp.ProcessID))
								foreach (AlarmPoint ap in TLIConfiguration.VesselAlarmPoints[eu.EquipmentID][gp.ProcessID].Values)
									m_ExcelExport.AddTextCell(ap.AlarmText);
					}

					m_ExcelExport.EndRow();
				}

				m_ExcelExport.EndWorkSheet();
			}
		}

		private void BuildLoadComputerExportOrderWorksheet()
		{
			if (m_LoadComputerExportOrder.Count > 0)
			{
				m_ExcelExport.NewWorkSheet("Load CPU Export");

				m_ExcelExport.NewRow();
				m_ExcelExport.AddTextCell("Load Computer Export Order", ExcelXml.STYLE_BOLD);
				m_ExcelExport.EndRow();

				m_ExcelExport.AddEmptyRow();

				m_ExcelExport.NewRow();
				m_ExcelExport.AddTextCell("Order", ExcelXml.STYLE_UL);
				m_ExcelExport.AddTextCell("Equipment", ExcelXml.STYLE_UL);
				m_ExcelExport.EndRow();

				foreach (KeyValuePair<int, string> kvpOrderEUPair in m_LoadComputerExportOrder)
				{
					m_ExcelExport.NewRow();
					m_ExcelExport.AddTextCell(kvpOrderEUPair.Key.ToString());
					m_ExcelExport.AddTextCell(kvpOrderEUPair.Value);
					m_ExcelExport.EndRow();
				}

				m_ExcelExport.EndWorkSheet();
			}
		}

		private void BuildCargoUllageWorksheet()
		{
			EquipmentUnit eu;
			GaugePoint gp;

			if (m_CargoEquipment.Count > 0)
			{
				m_ExcelExport.NewWorkSheet("Cargo Ullage");

				InsertEquipmentWorkSheetHeaderRow();

				foreach (string sEquipmentID in m_CargoEquipment.Keys)
					if (TLIConfiguration.VesselEquipment.ContainsKey(sEquipmentID))
						if (FindGaugePointByGaugeType(sEquipmentID, GaugeType.Ullage, out eu, out gp))
							InsertEquipmentUnitRow(ref eu, ref gp);
						else if (FindGaugePointByGaugeType(sEquipmentID, GaugeType.Level, out eu, out gp))
							InsertEquipmentUnitRow(ref eu, ref gp);


				m_ExcelExport.EndWorkSheet();
			}
		}

		private void BuildCargoTemperatureWorksheet()
		{
			EquipmentUnit eu;
			GaugePoint gp;

			if (m_CargoEquipment.Count > 0)
			{
				m_ExcelExport.NewWorkSheet("Cargo Temperature");

				InsertEquipmentWorkSheetHeaderRow();

				foreach (string sEquipmentID in m_CargoEquipment.Keys)
					if (TLIConfiguration.VesselEquipment.ContainsKey(sEquipmentID))
					{
						if (FindGaugePointByGaugeType(sEquipmentID, GaugeType.AverageTemperature, out eu, out gp))
							InsertEquipmentUnitRow(ref eu, ref gp);

						if (FindGaugePointByGaugeType(sEquipmentID, GaugeType.Temperature, 1, out eu, out gp))
							InsertEquipmentUnitRow(ref eu, ref gp);

						if (FindGaugePointByGaugeType(sEquipmentID, GaugeType.Temperature, 2, out eu, out gp))
							InsertEquipmentUnitRow(ref eu, ref gp);

						if (FindGaugePointByGaugeType(sEquipmentID, GaugeType.Temperature, 3, out eu, out gp))
							InsertEquipmentUnitRow(ref eu, ref gp);
					}


				m_ExcelExport.EndWorkSheet();
			}
		}

		private void BuildCargoPressureWorksheet()
		{
			EquipmentUnit eu;
			GaugePoint gp;

			if (m_CargoEquipment.Count > 0)
			{
				m_ExcelExport.NewWorkSheet("Cargo Pressure");

				InsertEquipmentWorkSheetHeaderRow();

				foreach (string sEquipmentID in m_CargoEquipment.Keys)
					if (TLIConfiguration.VesselEquipment.ContainsKey(sEquipmentID))
						if (FindGaugePointByGaugeType(sEquipmentID, GaugeType.Pressure, out eu, out gp))
							InsertEquipmentUnitRow(ref eu, ref gp);


				m_ExcelExport.EndWorkSheet();
			}
		}

		private void BuildPumpManifoldWorksheet()
		{
			EquipmentUnit eu;
			GaugePoint gp;

			if (m_ManifoldEquipment.Count > 0)
			{
				m_ExcelExport.NewWorkSheet("Pump & Manifold");

				InsertEquipmentWorkSheetHeaderRow();

				foreach (string sEquipmentID in m_ManifoldEquipment.Keys)
					if (TLIConfiguration.VesselEquipment.ContainsKey(sEquipmentID))
						if (FindGaugePointByGaugeType(sEquipmentID, GaugeType.Pressure, out eu, out gp))
							InsertEquipmentUnitRow(ref eu, ref gp);


				m_ExcelExport.EndWorkSheet();
			}
		}

		private void BuildBallastWorksheet()
		{
			EquipmentUnit eu;
			GaugePoint gp;

			if (m_BallastEquipment.Count > 0)
			{
				m_ExcelExport.NewWorkSheet("Ballast");

				InsertEquipmentWorkSheetHeaderRow();

				foreach (string sEquipmentID in m_BallastEquipment.Keys)
					if (TLIConfiguration.VesselEquipment.ContainsKey(sEquipmentID))
						if (FindGaugePointByGaugeType(sEquipmentID, GaugeType.Level, out eu, out gp))
							InsertEquipmentUnitRow(ref eu, ref gp);


				m_ExcelExport.EndWorkSheet();
			}
		}

		private void BuildServiceWorksheet()
		{
			EquipmentUnit eu;
			GaugePoint gp;

			if (m_ServiceEquipment.Count > 0)
			{
				m_ExcelExport.NewWorkSheet("Service");

				InsertEquipmentWorkSheetHeaderRow();

				foreach (string sEquipmentID in m_ServiceEquipment.Keys)
					if (TLIConfiguration.VesselEquipment.ContainsKey(sEquipmentID))
						if (FindGaugePointByGaugeType(sEquipmentID, GaugeType.Level, out eu, out gp))
							InsertEquipmentUnitRow(ref eu, ref gp);


				m_ExcelExport.EndWorkSheet();
			}
		}

		private void BuildMiscWorksheet()
		{
			EquipmentUnit eu;
			GaugePoint gp;

			if (m_MiscEquipment.Count > 0)
			{
				m_ExcelExport.NewWorkSheet("Misc");

				InsertEquipmentWorkSheetHeaderRow();

				foreach (string sEquipmentID in m_MiscEquipment.Keys)
					if (TLIConfiguration.VesselEquipment.ContainsKey(sEquipmentID))
					{
						if (FindGaugePointByGaugeType(sEquipmentID, GaugeType.Ullage, out eu, out gp))
							InsertEquipmentUnitRow(ref eu, ref gp);
						
						if (FindGaugePointByGaugeType(sEquipmentID, GaugeType.Level, out eu, out gp))
							InsertEquipmentUnitRow(ref eu, ref gp);

						if (FindGaugePointByGaugeType(sEquipmentID, GaugeType.ChannelStateAlarmMonitor, out eu, out gp))
							InsertEquipmentUnitRow(ref eu, ref gp);

						if (FindGaugePointByGaugeType(sEquipmentID, GaugeType.AverageTemperature, out eu, out gp))
							InsertEquipmentUnitRow(ref eu, ref gp);

						if (FindGaugePointByGaugeType(sEquipmentID, GaugeType.Temperature, 1, out eu, out gp))
							InsertEquipmentUnitRow(ref eu, ref gp);

						if (FindGaugePointByGaugeType(sEquipmentID, GaugeType.Temperature, 2, out eu, out gp))
							InsertEquipmentUnitRow(ref eu, ref gp);

						if (FindGaugePointByGaugeType(sEquipmentID, GaugeType.Temperature, 3, out eu, out gp))
							InsertEquipmentUnitRow(ref eu, ref gp);

						if (FindGaugePointByGaugeType(sEquipmentID, GaugeType.Pressure, out eu, out gp))
							InsertEquipmentUnitRow(ref eu, ref gp);

						if (FindGaugePointByGaugeType(sEquipmentID, GaugeType.PowerFail, out eu, out gp))
							InsertEquipmentUnitRow(ref eu, ref gp);
					}


				m_ExcelExport.EndWorkSheet();
			}
		}

		private void BuildAlarmWorkSheet()
		{
			m_ExcelExport.NewWorkSheet("Alarms");

			InsertAlarmPointWorksheetHeaderRow();

			foreach (string sEquipmentID in m_CargoEquipment.Keys)
				if(TLIConfiguration.VesselGaugePoints.ContainsKey(sEquipmentID))
					foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[sEquipmentID].Values)
						if(TLIConfiguration.VesselEquipment.ContainsKey(sEquipmentID))
							if(TLIConfiguration.VesselAlarmPoints.ContainsKey(sEquipmentID))
								if(TLIConfiguration.VesselAlarmPoints[sEquipmentID].ContainsKey(gp.ProcessID))
									foreach (AlarmPoint ap in TLIConfiguration.VesselAlarmPoints[sEquipmentID][gp.ProcessID].Values)
										InsertAlarmPointRow(TLIConfiguration.VesselEquipment[sEquipmentID], gp, ap);

			foreach (string sEquipmentID in m_ManifoldEquipment.Keys)
				if (TLIConfiguration.VesselGaugePoints.ContainsKey(sEquipmentID))
					foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[sEquipmentID].Values)
						if (TLIConfiguration.VesselEquipment.ContainsKey(sEquipmentID))
							if (TLIConfiguration.VesselAlarmPoints.ContainsKey(sEquipmentID))
								if (TLIConfiguration.VesselAlarmPoints[sEquipmentID].ContainsKey(gp.ProcessID))
									foreach (AlarmPoint ap in TLIConfiguration.VesselAlarmPoints[sEquipmentID][gp.ProcessID].Values)
										InsertAlarmPointRow(TLIConfiguration.VesselEquipment[sEquipmentID], gp, ap);

			foreach (string sEquipmentID in m_BallastEquipment.Keys)
				if (TLIConfiguration.VesselGaugePoints.ContainsKey(sEquipmentID))
					foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[sEquipmentID].Values)
						if (TLIConfiguration.VesselEquipment.ContainsKey(sEquipmentID))
							if (TLIConfiguration.VesselAlarmPoints.ContainsKey(sEquipmentID))
								if (TLIConfiguration.VesselAlarmPoints[sEquipmentID].ContainsKey(gp.ProcessID))
									foreach (AlarmPoint ap in TLIConfiguration.VesselAlarmPoints[sEquipmentID][gp.ProcessID].Values)
										InsertAlarmPointRow(TLIConfiguration.VesselEquipment[sEquipmentID], gp, ap);

			foreach (string sEquipmentID in m_ServiceEquipment.Keys)
				if (TLIConfiguration.VesselGaugePoints.ContainsKey(sEquipmentID))
					foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[sEquipmentID].Values)
						if (TLIConfiguration.VesselEquipment.ContainsKey(sEquipmentID))
							if (TLIConfiguration.VesselAlarmPoints.ContainsKey(sEquipmentID))
								if (TLIConfiguration.VesselAlarmPoints[sEquipmentID].ContainsKey(gp.ProcessID))
									foreach (AlarmPoint ap in TLIConfiguration.VesselAlarmPoints[sEquipmentID][gp.ProcessID].Values)
										InsertAlarmPointRow(TLIConfiguration.VesselEquipment[sEquipmentID], gp, ap);

			foreach (string sEquipmentID in m_DraftEquipment.Keys)
				if (TLIConfiguration.VesselGaugePoints.ContainsKey(sEquipmentID))
					foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[sEquipmentID].Values)
						if (TLIConfiguration.VesselEquipment.ContainsKey(sEquipmentID))
							if (TLIConfiguration.VesselAlarmPoints.ContainsKey(sEquipmentID))
								if (TLIConfiguration.VesselAlarmPoints[sEquipmentID].ContainsKey(gp.ProcessID))
									foreach (AlarmPoint ap in TLIConfiguration.VesselAlarmPoints[sEquipmentID][gp.ProcessID].Values)
										InsertAlarmPointRow(TLIConfiguration.VesselEquipment[sEquipmentID], gp, ap);

			foreach (string sEquipmentID in m_TrimListEquipment.Keys)
				if (TLIConfiguration.VesselGaugePoints.ContainsKey(sEquipmentID))
					foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[sEquipmentID].Values)
						if (TLIConfiguration.VesselEquipment.ContainsKey(sEquipmentID))
							if (TLIConfiguration.VesselAlarmPoints.ContainsKey(sEquipmentID))
								if (TLIConfiguration.VesselAlarmPoints[sEquipmentID].ContainsKey(gp.ProcessID))
									foreach (AlarmPoint ap in TLIConfiguration.VesselAlarmPoints[sEquipmentID][gp.ProcessID].Values)
										InsertAlarmPointRow(TLIConfiguration.VesselEquipment[sEquipmentID], gp, ap);

			m_ExcelExport.EndWorkSheet();
		}

		private void InsertEquipmentWorkSheetHeaderRow()
		{
			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("Tank Name", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Gauge Name", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("I/O Type", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Address", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Channel", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Channel Type", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Gauging Units", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Sounding Units", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Faceplate Disabled", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Data Collection Enabled", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Raw Max", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Raw Min", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("High Scale Value", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Low Scale Value", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Faceplate Max", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Faceplate Min", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Gauge Height", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Raw Deadband", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Digital Filter", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Offset", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Modbus Enabled", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Gauge Value LW", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Gauge Value HW", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Sounding Value LW", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Sounding Value HW", ExcelXml.STYLE_UL);
			m_ExcelExport.EndRow();
		}

		private void InsertEquipmentUnitRow(ref EquipmentUnit eu, ref GaugePoint gp)
		{
			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell(eu.Equipment);
			m_ExcelExport.AddTextCell(gp.DisplayName);
			m_ExcelExport.AddTextCell(IOType.GetIOTypeString(gp.IOType));
			m_ExcelExport.AddTextCell(gp.IOType == IOType.AMU ? gp.AMUAddress.ToString() : gp.IOType == IOType.TAU ? gp.TAUAddress.ToString() : gp.BUBAddress.ToString());
			m_ExcelExport.AddTextCell(gp.IOType == IOType.AMU ? gp.AMUChannel.ToString() : gp.IOType == IOType.TAU ? gp.TAUChannel.ToString() : gp.BUBChannel.ToString());
			m_ExcelExport.AddTextCell(gp.IOType == IOType.AMU ? "" : gp.IOType == IOType.TAU ? TAUChannelGroupType.GetChannelGroupTypeString(gp.TAUChannelGroupType) : "");
			m_ExcelExport.AddTextCell(Units.UnitsString(gp.Units));
			m_ExcelExport.AddTextCell(Units.UnitsString(gp.Units2));
			m_ExcelExport.AddTextCell(gp.DisableFaceplateGraph.ToString());
			m_ExcelExport.AddTextCell(gp.AMUEnable == true || gp.TAUEnable == true ? "True" : "False");
			m_ExcelExport.AddTextCell(gp.RawMax.ToString());
			m_ExcelExport.AddTextCell(gp.RawMin.ToString());
			m_ExcelExport.AddTextCell(gp.EngineeringMax.ToString());
			m_ExcelExport.AddTextCell(gp.EngineeringMin.ToString());
			m_ExcelExport.AddTextCell(gp.FullScaleValue.ToString());
			m_ExcelExport.AddTextCell(gp.LowScaleValue.ToString());
			m_ExcelExport.AddTextCell(gp.PhysicalOffset.ToString());
			m_ExcelExport.AddTextCell(gp.ValueDeadband.ToString());
			m_ExcelExport.AddTextCell(gp.DigitalFilter.ToString());
			m_ExcelExport.AddTextCell(gp.LinearOffset.ToString());

			if (gp.ModbusInterfaceArray != null)
			{
				if (gp.ModbusInterfaceArray[0] != null)
				{
					m_ExcelExport.AddTextCell(gp.ModbusInterfaceArray[0].Enable.ToString());
					m_ExcelExport.AddTextCell(gp.ModbusInterfaceArray[0].Enable ? gp.ModbusInterfaceArray[0].RegisterAddress1.ToString() : "");
					m_ExcelExport.AddTextCell(gp.ModbusInterfaceArray[0].Enable ? gp.ModbusInterfaceArray[0].RegisterAddress2.ToString() : "");
				}

				if (gp.ModbusInterfaceArray[1] != null)
				{
					m_ExcelExport.AddTextCell(gp.ModbusInterfaceArray[1].Enable ? gp.ModbusInterfaceArray[1].RegisterAddress1.ToString() : "");
					m_ExcelExport.AddTextCell(gp.ModbusInterfaceArray[1].Enable ? gp.ModbusInterfaceArray[1].RegisterAddress2.ToString() : "");
				}
			}
			else
			{
				m_ExcelExport.AddTextCell("False");
			}

			m_ExcelExport.EndRow();
		}

		private void InsertAlarmPointWorksheetHeaderRow()
		{
			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell("Tank Name", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Gauge Name", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Alarm Name", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Enabled", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Monitor Type", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Alarm Type", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Priority", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Text", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Limit", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Comparator", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Debounce Timer", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Auto Deadband", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Auto Clear", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Modbus Enabled", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Input Register Address", ExcelXml.STYLE_UL);
			m_ExcelExport.AddTextCell("Annunciations", ExcelXml.STYLE_UL);
			m_ExcelExport.EndRow();
		}

		private void InsertAlarmPointRow(EquipmentUnit eu,GaugePoint gp, AlarmPoint ap)
		{
			m_ExcelExport.NewRow();
			m_ExcelExport.AddTextCell(eu.Equipment);
			m_ExcelExport.AddTextCell(gp.DisplayName);
			m_ExcelExport.AddTextCell(ap.DisplayName);
			m_ExcelExport.AddTextCell(ap.Enable.ToString());
			m_ExcelExport.AddTextCell(ap.AlarmMonitorTypeString);
			m_ExcelExport.AddTextCell(ap.AlarmTypeString);
			m_ExcelExport.AddTextCell(ap.AlarmPriority.ToString());
			m_ExcelExport.AddTextCell(ap.AlarmText);
			m_ExcelExport.AddTextCell(ap.Limit.ToString());
			m_ExcelExport.AddTextCell(ap.ComparatorString);
			m_ExcelExport.AddTextCell(ap.DebounceTimer.ToString());
			m_ExcelExport.AddTextCell(ap.AlarmDeadband.ToString());
			m_ExcelExport.AddTextCell(ap.AutoClearEnable.ToString());

			if (ap.ModbusInterface != null)
			{
				m_ExcelExport.AddTextCell(ap.ModbusInterface.Enable.ToString());
				m_ExcelExport.AddTextCell(ap.ModbusInterface.RegisterAddress1.ToString());
			}
			else
			{
				m_ExcelExport.AddTextCell("False");
				m_ExcelExport.AddTextCell("");
			}

			foreach (string sAnnunciation in ap.AlarmAnnunciation)
				m_ExcelExport.AddTextCell(sAnnunciation);

			m_ExcelExport.EndRow();
		}

		private void SortObjects()
		{
			m_CargoEquipment = new SortedDictionary<string, string>();
			m_ManifoldEquipment = new SortedDictionary<string, string>();
			m_BallastEquipment = new SortedDictionary<string, string>();
			m_ServiceEquipment = new SortedDictionary<string, string>();
			m_MiscEquipment = new SortedDictionary<string, string>();
			m_DraftEquipment = new SortedDictionary<string, string>();
			m_TrimListEquipment = new SortedDictionary<string, string>();
			m_LoadComputerExportOrder = new SortedList<int, string>();

			foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
			{
				if (eu.EquipmentType == EquipmentType.Cargo)
					m_CargoEquipment.Add(eu.EquipmentID, eu.Equipment);
				else if (eu.EquipmentType == EquipmentType.Manifold)
					m_ManifoldEquipment.Add(eu.EquipmentID, eu.Equipment);
				else if (eu.EquipmentType == EquipmentType.Ballast)
					m_BallastEquipment.Add(eu.EquipmentID, eu.Equipment);
				else if (eu.EquipmentType == EquipmentType.Fuel)
					m_ServiceEquipment.Add(eu.EquipmentID, eu.Equipment);
				else if (eu.EquipmentType == EquipmentType.Misc)
					m_MiscEquipment.Add(eu.EquipmentID, eu.Equipment);
				else if (eu.EquipmentType == EquipmentType.Draft)
					m_ServiceEquipment.Add(eu.EquipmentID, eu.Equipment);
				else if (eu.EquipmentType == EquipmentType.Trim || eu.EquipmentType == EquipmentType.List)
					m_TrimListEquipment.Add(eu.EquipmentID, eu.Equipment);

				if (eu.ExportEnable)
					m_LoadComputerExportOrder.Add(eu.ExportOrder, eu.EquipmentTypeString + " " + eu.Equipment);
			}
		}

		private bool FindGaugePointByAMUAddress(int iAMUAddress, int iChannel, out EquipmentUnit equipmentUnit, out GaugePoint gaugePoint)
		{
			equipmentUnit = null;
			gaugePoint = null;

			foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
			{
				if (TLIConfiguration.VesselGaugePoints.ContainsKey(eu.EquipmentID))
				{
					foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[eu.EquipmentID].Values)
					{
						if (gp.AMUAddress == iAMUAddress && gp.AMUChannel == iChannel)
						{
							equipmentUnit = eu;
							gaugePoint = gp;
							return true;
						}
					}
				}
			}

			return false;
		}

		private bool FindGaugePointByTAUAddress(int iTAUAddress, int iChannel, int iChannelType, out EquipmentUnit equipmentUnit, out GaugePoint gaugePoint)
		{
			equipmentUnit = null;
			gaugePoint = null;

			foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
			{
				if (TLIConfiguration.VesselGaugePoints.ContainsKey(eu.EquipmentID))
				{
					foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[eu.EquipmentID].Values)
					{
						if (gp.TAUAddress == iTAUAddress && gp.TAUChannel == iChannel && gp.TAUChannelGroupType == iChannelType)
						{
							equipmentUnit = eu;
							gaugePoint = gp;
							return true;
						}
					}
				}
			}

			return false;
		}

		private bool FindGaugePointByBUBAddress(int iMODBUBAddress, int iChannel, out EquipmentUnit equipmentUnit, out GaugePoint gaugePoint)
		{
			equipmentUnit = null;
			gaugePoint = null;

			foreach (EquipmentUnit eu in TLIConfiguration.VesselEquipment.Values)
			{
				if (TLIConfiguration.VesselGaugePoints.ContainsKey(eu.EquipmentID))
				{
					foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[eu.EquipmentID].Values)
					{
						if (gp.BUBAddress == iMODBUBAddress && gp.BUBChannel == iChannel)
						{
							equipmentUnit = eu;
							gaugePoint = gp;
							return true;
						}
						else if (gp.BUBSecondaryChannelEnable && gp.BUBAddress == iMODBUBAddress && gp.BUBSecondaryChannel == iChannel)
						{
							equipmentUnit = eu;
							gaugePoint = gp;
							return true;
						}
					}
				}
			}

			return false;
		}

		private bool FindGaugePointByGaugeType(string sEquipmentID, int iGaugeType, out EquipmentUnit equipmentUnit, out GaugePoint gaugePoint)
		{
			equipmentUnit = null;
			gaugePoint = null;

			if(TLIConfiguration.VesselEquipment.ContainsKey(sEquipmentID))
			{
				if (TLIConfiguration.VesselGaugePoints.ContainsKey(sEquipmentID))
				{
					foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[sEquipmentID].Values)
					{
						if (gp.GaugeType == iGaugeType)
						{
							equipmentUnit = TLIConfiguration.VesselEquipment[sEquipmentID];
							gaugePoint = gp;
							return true;
						}
					}
				}
			}

			return false;
		}

		private bool FindGaugePointByGaugeType(string sEquipmentID, int iGaugeType, int iGaugeNumber, out EquipmentUnit equipmentUnit, out GaugePoint gaugePoint)
		{
			equipmentUnit = null;
			gaugePoint = null;

			if (TLIConfiguration.VesselEquipment.ContainsKey(sEquipmentID))
			{
				if (TLIConfiguration.VesselGaugePoints.ContainsKey(sEquipmentID))
				{
					foreach (GaugePoint gp in TLIConfiguration.VesselGaugePoints[sEquipmentID].Values)
					{
						if (gp.GaugeType == iGaugeType && gp.GaugeNumber == iGaugeNumber)
						{
							equipmentUnit = TLIConfiguration.VesselEquipment[sEquipmentID];
							gaugePoint = gp;
							return true;
						}
					}
				}
			}

			return false;
		}
	}
}
