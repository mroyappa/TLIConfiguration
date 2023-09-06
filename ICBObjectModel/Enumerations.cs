using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;

/*
 * FILE SUMMARY:	Enumerations.cs
 * 
 * The ICBObjectModel.Enumerations namespace is a catch-all location for all system enumerations.  This
 * namespace contains enums and classes which quantify system entities such as Units, Equipment Types, 
 * Gauge Types, etc.
 * 
 */

namespace ICBObjectModel.Enumerations
{
	public class NullValue
	{
		public static DateTime DateTimeNull = DateTime.MinValue;
		public const int IntNull = -1;
		public const string StringNull = "";

		public static string NullToEmpty(string s)
		{
			if (s == null) return ""; else return s;
		}
	}

	public class VesselType : TypeConverter
	{
		public const int Tug = 1;
		public const int Barge = 2;
		public const int Platform = 3;
		public const int Tanker = 4;

#if !WindowsCE
		public override bool  GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			return new StandardValuesCollection(new string[] { "Barge", "Platform", "Tanker", "Tug" });
		}
#endif

		public static string GetVesselTypeString(int iVesselType)
		{
			switch (iVesselType)
			{
				case 1:
					return "Tug";
				case 2:
					return "Barge";
				case 3:
					return "Platform";
				case 4:
					return "Tanker";
				default:
					return "Barge";
			}
		}
	}

	public class IOType : TypeConverter
	{
		public const int AMU = 0;
		public const int TAU = 1;
		public const int GS311USB = 3;
		public const int ModularBubbler = 4;
		public const int Modbus = 5;

		public const string AMUString = "AMU";
		public const string TAUString = "TAU";
		public const string GS311USBString = "GS311USB";
		public const string ModularBubblerString = "Modular Bubbler";
		public const string ModbusString = "Modbus";
		
#if !WindowsCE
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			return new StandardValuesCollection(new string[] { "AMU", "TAU", "Modbus", "Modular Bubbler" });
		}
#endif

		public static string GetIOTypeString(int iIOType)
		{
			switch (iIOType)
			{
				case 0:
					return "AMU";
				case 1:
					return "TAU";
				case 2:
					return "GS311USB";
				case 4:
					return "Modular Bubbler";
				case 5:
					return "Modbus";
				default:
					return "AMU";
			}
		}
	}

	public class TAUChannelGroupType : TypeConverter
	{
		public const int TBD_1 = 0;
		public const int LEVEL_1 = 1;
		public const int LEVEL_2 = 2;
		public const int IG_PRESSURE = 3;
		public const int TEMPERATURE_1 = 4;
		public const int TEMPERATURE_2 = 5;
		public const int TEMPERATURE_3 = 6;
		public const int TBD_2 = 7;
		public const int ULLAGE_HATCH = 8;
		public const int LEVEL_FULL = 9;
		public const int TBD_3 = 10;
		public const int ULLAGE_1 = 11;
		public const int ULLAGE_2 = 12;

#if !WindowsCE
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}
		
		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			return new StandardValuesCollection(new string[] { "Level 1", "Level 2", "IG Pressure", "Temp TOP", "Temp MID", "Temp BOT", "Ullage 1", "Ullage 2" });
		}
#endif

		public static string GetChannelGroupTypeString(int iChannelGroupType)
		{
			switch (iChannelGroupType)
			{
				case 1:
					return "Level 1";
				case 2:
					return "Level 2";
				case 3:
					return "IG Pressure";
				case 4:
					return "Temp TOP";
				case 5:
					return "Temp MID";
				case 6:
					return "Temp BOT";
				case 11:
					return "Ullage 1";
				case 12:
					return "Ullage 2";
				default:
					return "Level 1";
			}
		}

		public static int GetChannelGroupTypeID(string sChannelGroupTypeString)
		{
			switch (sChannelGroupTypeString)
			{
				case "Level 1":
					return LEVEL_1;
				case "Level 2":
					return LEVEL_2;
				case "IG Pressure":
					return IG_PRESSURE;
				case "Temp TOP":
					return TEMPERATURE_1;
				case "Temp MID":
					return TEMPERATURE_2;
				case "Temp BOT":
					return TEMPERATURE_3;
				case "Ullage 1":
					return ULLAGE_1;
				case "Ullage 2":
					return ULLAGE_2;
				default:
					return LEVEL_1;
			}
		}
	}

	public class TAUChannelStateType : TypeConverter
	{
		public static int SCU_STATE = 0;
		public static int TEMPERATURE_LOCATIONS = 1;

#if !WindowsCE
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			return new StandardValuesCollection(new string[] { "SCU State", "Active Temps" });
		}
#endif

		public static string GetChannelStateTypeString(int iChannelStateType)
		{
			switch (iChannelStateType)
			{
				case 0:
					return "SCU State";
				case 1:
					return "Active Temps";
				default:
					return "SCU State";
			}
		}

		public static int GetChannelStateTypeID(string sChannelStateTypeString)
		{
			switch (sChannelStateTypeString)
			{
				case "SCU State":
					return SCU_STATE;
				case "Active Temps":
					return TEMPERATURE_LOCATIONS;
				default:
					return SCU_STATE;
			}
		}
	}

	public class MeasurementSystem : TypeConverter
	{
		public const int English = 1;
		public const int Metric = 2;

#if !WindowsCE
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			return new StandardValuesCollection(new string[] { "English", "Metric" });
		}
#endif
	}

	public class Units : TypeConverter
	{
		public const int Inches = 1;
		public const int Millimeters = 2;
		public const int Fahrenheit = 3;
		public const int Celsius = 4;
		public const int MilliBars = 5;
		public const int BBL = 6;
		public const int Gallons = 7;
		public const int Degrees = 8;
		public const int PSI = 9;
		public const int Kiloliters = 10;
		public const int CubicMeters = 11;
		public const int Liters = 12;
		public const int Meters = 13;
		public const int LongTons = 14;
		public const int Discrete = 15;
		public const int DiscreteAlt = 16;
		public const int Bar = 17;

		public static string UnitsString(int iUnits)
		{
			switch (iUnits)
			{
				case BBL:
					return "BBL";
				case Celsius:
					return "Celsius";
				case Degrees:
					return "Degrees";
				case Fahrenheit:
					return "Fahrenheit";
				case Gallons:
					return "Gallons";
				case Inches:
					return "Inches";
				case MilliBars:
					return "MilliBars";
				case Millimeters:
					return "Millimeters";
				case PSI:
					return "PSI";
				case Kiloliters:
					return "Kiloliters";
				case CubicMeters:
					return "Cubic Meters";
				case Liters:
					return "Liters";
				case Meters:
					return "Meters";
				case LongTons:
					return "Long Tons";
				case Discrete:
					return "Discrete";
				case DiscreteAlt:
					return "Discrete Alt";
				case Bar:
					return "Bar";
				default:
					return "Inches";
			}
		}

		public static string UnitsShortString(int iUnits)
		{
			switch (iUnits)
			{
				case Units.Inches:
					return "In";
				case Millimeters:
					return "mm";
				case Fahrenheit:
					return "F";
				case Celsius:
					return "C";
				case MilliBars:
					return "mBAR";
				case BBL:
					return "BBL";
				case Gallons:
					return "GAL";
				case Degrees:
					return "Degrees";
				case PSI:
					return "PSI";
				case Kiloliters:
					return "KL";
				case CubicMeters:
					return "m³";
				case Liters:
					return "L";
				case Meters:
					return "m";
				case LongTons:
					return "LTON";
				case Discrete:
					return "Discrete";
				case DiscreteAlt:
					return "Discrete Alt";
				case Bar:
					return "Bar";
				default:
					return "";
			}
		}

		public static int UnitsID(string sUnitsString)
		{
			switch (sUnitsString)
			{
				case "BBL":
					return BBL;
				case "Celsius":
					return Celsius;
				case "Degrees":
					return Degrees;
				case "Fahrenheit":
					return Fahrenheit;
				case "Gallons":
					return Gallons;
				case "Inches":
					return Inches;
				case "MilliBars":
					return MilliBars;
				case "Millimeters":
					return Millimeters;
				case "PSI":
					return PSI;
				case "Kiloliters":
					return Kiloliters;
				case "Cubic Meters":
					return CubicMeters;
				case "Liters":
					return Liters;
				case "Meters":
					return Meters;
				case "Long Tons":
					return LongTons;
				case "Discrete":
					return Discrete;
				case "Discrete Alt":
					return DiscreteAlt;
				case "Bar":
					return Bar;
				default:
					return Inches;
			}
		}

#if !WindowsCE
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			return new StandardValuesCollection(new string[] { "Bar", "BBL", "Celsius", "Cubic Meters", "Degrees", "Discrete", "Discrete Alt", "Fahrenheit", "Gallons", "Inches", "Kiloliters", "Liters", "Long Tons", "MilliBars", "Millimeters", "PSI" });
		}
#endif
	}

	public class EquipmentType : TypeConverter
	{
		public const int Cargo = 1;
		public const int Ballast = 2;
		public const int Fuel = 3;
		public const int Draft = 4;
		public const int Trim = 5;
		public const int List = 6;
//		public const int PushButton = 7;
		public const int Manifold = 8;
		public const int Misc = 9;

		public static int EquipmentTypeID(string sEquipmentTypeString)
		{
			switch (sEquipmentTypeString)
			{
				case "Cargo":
					return 1;
				case "Ballast":
					return 2;
				case "Fuel / Aux":
					return 3;
				case "Draft":
					return 4;
				case "Trim":
					return 5;
				case "List":
					return 6;
				case "Manifold":
					return 8;
				case "Misc":
					return 9;
				default:
					return 1;
			}
		}

#if !WindowsCE
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			return new StandardValuesCollection(new string[] { "Ballast", "Cargo", "Draft", "Fuel / Aux", "List", "Manifold", "Misc", "Trim" });
		}
#endif
	}

	public class EquipmentLocation : TypeConverter
	{
		public const string Fore = "F";
		public const string Aft = "A";
		public const string Port = "P";
		public const string Center = "C";
		public const string Starboard = "S";

		public static string GetEquipmentLocation(string sEquipmentLocationString)
		{
			switch (sEquipmentLocationString)
			{
				case "Fore":
					return "F";
				case "Aft":
					return "A";
				case "Port":
					return "P";
				case "Center":
					return "C";
				case "Starboard":
					return "S";
				default: return "P";
			}
		}

#if !WindowsCE
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			return new StandardValuesCollection(new string[] { "Aft", "Center", "Fore", "Port", "Starboard" });
		}
#endif
	}

	public class GaugeType : TypeConverter
	{
		public const int Level = 1;
		public const int Pressure = 2;
		public const int Temperature = 3;
		public const int Ullage = 4;
//		public const int PushButton = 5;
		public const int ChannelStateAlarmMonitor = 6;
		public const int AverageTemperature = 7;
		public const int List = 8;
		public const int Trim = 9;
		public const int PowerFail = 5;
		public const int HogSag = 0;

		public static int GetGaugeTypeID(string sGaugeTypeString)
		{
			switch (sGaugeTypeString)
			{
				case "Level":
					return Level;
				case "Pressure":
					return Pressure;
				case "Temperature":
					return Temperature;
				case "Ullage":
					return Ullage;
				case "Channel State Alarm Monitor":
					return ChannelStateAlarmMonitor;
				case "Average Temperature":
					return AverageTemperature;
				case "List":
					return List;
				case "Trim":
					return Trim;
				case "Power Fail":
					return PowerFail;
				case "Hog / Sag":
					return HogSag;
				default: return Level;
			}
		}

		public static string GaugeTypeString(int iGaugeType)
		{
			switch (iGaugeType)
			{
				case Level:
					return "Level";
				case Pressure:
					return "Pressure";
				case Temperature:
					return "Temperature";
				case Ullage:
					return "Ullage";
				case ChannelStateAlarmMonitor:
					return "Channel State Alarm Monitor";
				case AverageTemperature:
					return "Average Temperature";
				case List:
					return "List";
				case Trim:
					return "Trim";
				case PowerFail:
					return "Power Fail";
				case HogSag:
					return "Hog / Sag";
				default: return "Level";
			}
		}

		public static int GetModbusGaugeSort(int iGaugeType, int iGaugeNumber)
		{
			switch (iGaugeType)
			{
				case GaugeType.Ullage:
					return 1;
				case GaugeType.Level:
					return 1;
				case 99:			// Sounding
					return 2;
				case GaugeType.AverageTemperature:
					return 3;
				case GaugeType.Temperature:
					{
						switch (iGaugeNumber)
						{
							case 1:
								return 4;
							case 2:
								return 5;
							case 3:
								return 6;
							default:
								return 4;
						}
					}
				case GaugeType.Pressure:
					return 7;
				case GaugeType.Trim:
					return 8;
				case GaugeType.List:
					return 9;
				case GaugeType.PowerFail:
					return 10;
				case GaugeType.HogSag:
					return 11;
				default:
					return 1;
			}
		}

#if !WindowsCE
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			return new StandardValuesCollection(new string[] { "Average Temperature", "Channel State Alarm Monitor", "Hog / Sag", "Level", "List", "Power Fail", "Pressure", "Temperature", "Trim", "Ullage" });
		}
#endif
	}

	public class AlarmMonitorType : TypeConverter
	{
		public const int AnalogValue = 1;
		public const int AnalogValue2 = 2;
		public const int DigitalValue = 3;
		public const int ChannelCondition = 4;
		public const int ChannelAlarmState = 5;

		public static int AlarmMonitorTypeID(string sAlarmMonitorTypeString)
		{
			switch (sAlarmMonitorTypeString)
			{
				case "Analog Value":
					return 1;
				case "Sounding":
					return 2;
				case "Digital Value":
					return 3;
				case "Channel Condition":
					return 4;
				case "Channel Alarm State":
					return 5;
				default: return 1;
			}
		}

#if !WindowsCE
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			return new StandardValuesCollection(new string[] { "Analog Value", "Channel Alarm State", "Channel Condition", "Digital Value", "Sounding" });
		}
#endif
	}

	public class AlarmType : TypeConverter
	{
		public const string Alarm = "A";
		public const string Warning = "W";
		public const string HighAlarm = "HA";
		public const string HighWarning = "HW";
		public const string LowAlarm = "LA";
		public const string LowWarning = "LW";
//		public const string PushButton = "PB";

#if !WindowsCE
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			return new StandardValuesCollection(new string[] { "Alarm", "High Alarm", "High Warning", "Low Alarm", "Low Warning", "Warning" });
		}
#endif
	}

	public class Comparator : TypeConverter
	{
		public const string EqualTo = "ET";
		public const string GreaterThan = "GT";
		public const string GreaterThanOrEqualTo = "GTE";
		public const string LessThan = "LT";
		public const string LessThanOrEqualTo = "LTE";

#if !WindowsCE
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			return new StandardValuesCollection(new string[] { "Equal To", "Greater Than", "Greater Than Or Equal To", "Less Than", "Less Than Or Equal To"});
		}
#endif
	}

	public class ModbusEncoding
	{
		public const string RTU = "RTU";
		public const string ASCII = "ASCII";
	}

	public class DFGFloat : TypeConverter
	{
		public const int Standard = 0;
		public const int Ammonia = 1;

		public static int DFGFloatID(string sDFGFloatString)
		{
			switch (sDFGFloatString)
			{
				case "Standard":
					return 0;
				case "Ammonia":
					return 1;
				default:
					return 0;
			}
		}

		public static string DFGFloatString(int iDFGFloatID)
		{
			switch (iDFGFloatID)
			{
				case 0:
					return "Standard";
				case 1:
					return "Ammonia";
				default:
					return "Standard";
			}
		}

#if !WindowsCE
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			return new StandardValuesCollection(new string[] { "Ammonia", "Standard" });
		}
#endif
	}

	public enum ModbusCommunicationInterface
	{
		Serial,
		Ethernet
	}

	public enum SystemStatusValues
	{
		SYSTEM_FAULT_ACTIVE,
		ALARM_ACTIVE,
		LOAD_CPU_BIDIRECTIONAL_CONNECTED,
		LOAD_CPU_CORRECTION_ENABLED
	}
}
