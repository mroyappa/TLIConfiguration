using System;
using System.Text;
using System.Collections.Generic;
using ICBObjectModel.Enumerations;

/*
 * FILE SUMMARY:	UnitConversions.cs
 * 
 * The ICBObjectModel.UnitConversions namespace contains numerous unit conversion methods used
 * throughout the application.  These methods handle display conversions for faceplates as well as
 * simple unit to unit mathmatical computations.
 * 
 */

namespace ICBObjectModel.UnitConversions
{
	public class UnitConversions
	{
		public static float DataExportLengthConversion(float fValue, int iUnits, int iMeasurementSystem)
		{
			switch (iUnits)
			{
				case Units.Inches:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return UnitConversions.MillimetersToMeters(UnitConversions.InchesToMillimeters(fValue));
						else
							return UnitConversions.InchesToDecimalFeetInches(fValue);
					}
				case Units.Millimeters:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return UnitConversions.MillimetersToMeters(fValue);
						else
							return UnitConversions.InchesToDecimalFeetInches(UnitConversions.MillimetersToInches(fValue));
					}
				case Units.Meters:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return fValue;
						else
							return UnitConversions.InchesToDecimalFeetInches(UnitConversions.MillimetersToInches(UnitConversions.MetersToMilliMeters(fValue)));
					}
				default:
					{
						return UnitConversions.InchesToDecimalFeetInches(fValue);
					}
			}
		}

		public static float LevelConversion(float fValue, int iUnits, int iMeasurementSystem)
		{
			switch (iUnits)
			{
				case Units.Inches:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return MillimetersToMeters(InchesToMillimeters(fValue));
						else
							return fValue;
					}
				case Units.Millimeters:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return fValue;
						else
							return MillimetersToInches(fValue);
					}
				case Units.Meters:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return MetersToMilliMeters(fValue);
						else
							return MillimetersToInches(MetersToMilliMeters(fValue));
					}
				default:
					{
						return fValue;
					}
			}
		}



		public static float LevelAlarmLimitString(float fValue, int iUnits, int iMeasurementSystem)
		{
			switch (iUnits)
			{
				case Units.Inches:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return (MillimetersToMeters(InchesToMillimeters(fValue)));
						else
							return InchesToDecimalFeetInches(fValue);
					}
				case Units.Millimeters:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return MillimetersToMeters(fValue);
						else
							return InchesToDecimalFeetInches(MillimetersToInches(fValue));
					}
				default:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return MillimetersToMeters(fValue);
						else
							return InchesToDecimalFeetInches(fValue);
					}
			}
		}

		public static string LevelGaugeTickConversion(float fValue, int iUnits, int iMeasurementSystem)
		{
			switch (iUnits)
			{
				case Units.Inches:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return MillimetersToMeters(InchesToMillimeters(fValue)).ToString("f2");
						else
							return InchesToFeetInches(fValue);
					}
				case Units.Millimeters:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return MillimetersToMeters(fValue).ToString("f2");
						else
							return InchesToFeetInches(MillimetersToInches(fValue));
					}
				case Units.Meters:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return fValue.ToString("f2");
						else
							return InchesToFeetInches(MillimetersToInches(MetersToMilliMeters(fValue)));
					}
				default:
					{
						return InchesToFeetInches(fValue);
					}
			}
		}

		public static string LevelDraftConversion(float fValue, int iUnits, int iMeasurementSystem)
		{
			switch (iUnits)
			{
				case Units.Inches:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return MillimetersToMeters(InchesToMillimeters(fValue)).ToString("f2") + " m";
						else
							return InchesToFeetInches(fValue);
					}
				case Units.Millimeters:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return MillimetersToMeters(fValue).ToString("f2") + " m";
						else
							return InchesToFeetInches(MillimetersToInches(fValue));
					}
				case Units.Meters:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return fValue.ToString("f2") + " m";
						else
							return InchesToFeetInches(MillimetersToInches(MetersToMilliMeters(fValue)));
					}
				default:
					{
						return InchesToFeetInches(fValue);
					}
			}
		}

		public static string LevelConversionString(float fValue, int iUnits, int iMeasurementSystem)
		{
			switch (iUnits)
			{
				case Units.Inches:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return MillimetersToMeters(InchesToMillimeters(fValue)).ToString("f2") + " m";
						else
							return InchesToFeetQuarterInches(fValue);
					}
				case Units.Millimeters:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return MillimetersToMeters(fValue).ToString("f2") + " m";
						else
							return InchesToFeetQuarterInches(MillimetersToInches(fValue));
					}
				default:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return MillimetersToMeters(fValue).ToString("f2") + " m";
						else
							return InchesToFeetQuarterInches(fValue);
					}
			}
		}

		public static string LevelConversionPrintString(float fValue, int iUnits, int iMeasurementSystem)
		{
			switch (iUnits)
			{
				case Units.Inches:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return MillimetersToMeters(InchesToMillimeters(fValue)).ToString("f2") + " m";
						else
							return InchesToFeetDecimalQuarterInches(fValue);
					}
				case Units.Millimeters:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return MillimetersToMeters(fValue).ToString("f2") + " m";
						else
							return InchesToFeetDecimalQuarterInches(MillimetersToInches(fValue));
					}
				default:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return MillimetersToMeters(fValue).ToString("f2") + " m";
						else
							return InchesToFeetDecimalQuarterInches(fValue);
					}
			}
		}

		public static string PressureGaugeTickConversion(float fValue, int iUnits, int iMeasurementSystem)
		{
			switch (iUnits)
			{
				case Units.Bar:
					{
						return fValue.ToString("f0");
					}
				case Units.MilliBars:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return fValue.ToString("f0");
						else
							return MBARToPSI(fValue).ToString("f1");
					}
				case Units.Millimeters:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return MillimetersMercuryToMBAR(fValue).ToString("f0");
						else
							return MilliemetersMercuryToPSI(fValue).ToString("f1");
					}
				case Units.PSI:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return PSIToMBAR(fValue).ToString("f0");
						else
							return fValue.ToString("f1");
					}
				default:
					return fValue.ToString("f1");
			}
		}

		public static string PressureConversion(float fValue, int iUnits, int iMeasurementSystem)
		{
			switch (iUnits)
			{
				case Units.Bar:
					{
						return fValue.ToString("f1") + " BAR";
					}
				case Units.MilliBars:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return fValue.ToString("f0") + " mBAR";
						else
							return MBARToPSI(fValue).ToString("f1") + " PSI";
					}
				case Units.Millimeters:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return MillimetersMercuryToMBAR(fValue).ToString("f0") + " mBAR";
						else
							return MilliemetersMercuryToPSI(fValue).ToString("f1") + " PSI";
					}
				case Units.PSI:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return PSIToMBAR(fValue).ToString("f0") + " mBAR";
						else
							return fValue.ToString("f1") + " PSI";
					}
				default:
					return fValue.ToString("f1") + " PSI";
			}
		}

		public static string PressureConversionUnitsOnly(int iUnits, int iMeasurementSystem)
		{
			switch (iUnits)
			{
				case Units.Bar:
					{
						return "BAR";
					}
				case Units.MilliBars:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return "mBAR";
						else
							return "PSI";
					}
				case Units.Millimeters:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return "mBAR";
						else
							return "PSI";
					}
				case Units.PSI:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return "mBAR";
						else
							return "PSI";
					}
				default:
					return "PSI";
			}
		}

		public static string TemperatureConversion(float fValue, int iUnits, int iMeasurementSystem)
		{
			switch (iUnits)
			{
				case Units.Fahrenheit:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return FahrenheitToCelsius(fValue).ToString("f0") + "°C";
						else
							return fValue.ToString("f0") + "°F";
					}
				case Units.Celsius:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return fValue.ToString("f0") + "°C";
						else
							return CelsiusToFahrenheit(fValue).ToString("f0") + "°F";
					}
				default:
					return fValue.ToString("f0") + "°F";
			}
		}

		public static string TemperaturePrintConversion(float fValue, int iUnits, int iMeasurementSystem)
		{
			switch (iUnits)
			{
				case Units.Fahrenheit:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return FahrenheitToCelsius(fValue).ToString("f0") + " C";
						else
							return fValue.ToString("f0") + " F";
					}
				case Units.Celsius:
					{
						if (MeasurementSystem.Metric == iMeasurementSystem)
							return fValue.ToString("f0") + " C";
						else
							return CelsiusToFahrenheit(fValue).ToString("f0") + " F";
					}
				default:
					return fValue.ToString("f0") + " F";
			}
		}

		public static string InchesToFeetQuarterInches(int iValue)
		{ return InchesToFeetQuarterInches(Convert.ToSingle(iValue)); }
		public static string InchesToFeetQuarterInches(float fValue)
		{
			string sFeetInches;
			int iFeet;
			float fInches, fInchRemainder;

			iFeet = (int)Math.Floor((double)(fValue / 12));
			fInches = (fValue / 12) - iFeet;
			fInchRemainder = (fInches * 12) - Convert.ToSingle(Math.Floor((double)(fInches * 12)));
			fInches = Convert.ToSingle(Math.Floor((double)(fInches * 12)));

			sFeetInches = "0' ";

			if (fInchRemainder < 0.125F)
				sFeetInches = iFeet.ToString() + "' " + fInches.ToString("f0") + "''";
			else if (fInchRemainder >= 0.125F && fInchRemainder <= 0.375F)
				sFeetInches = iFeet.ToString() + "' " + fInches.ToString("f0") + "¼''";
			else if (fInchRemainder > 0.375F && fInchRemainder <= 0.625F)
				sFeetInches = iFeet.ToString() + "' " + fInches.ToString("f0") + "½''";
			else if (fInchRemainder > 0.625F && fInchRemainder <= 0.875F)
				sFeetInches = iFeet.ToString() + "' " + fInches.ToString("f0") + "¾''";
			else if (fInchRemainder > 0.875)
			{
				if (fInches == 11)
				{
					iFeet++;
					sFeetInches = iFeet.ToString() + "' 0''";
				}
				else
					sFeetInches = iFeet.ToString() + "' " + (fInches + 1).ToString("f0") + "''";
			}

			return sFeetInches;
		}

		public static string InchesToFeetDecimalQuarterInches(float fValue)
		{
			string sFeetInches;
			int iFeet;
			float fInches, fInchRemainder;

			iFeet = (int)Math.Floor((double)(fValue / 12));
			fInches = (fValue / 12) - iFeet;
			fInchRemainder = (fInches * 12) - Convert.ToSingle(Math.Floor((double)(fInches * 12)));
			fInches = Convert.ToSingle(Math.Floor((double)(fInches * 12)));

			sFeetInches = "0' ";

			if (fInchRemainder < 0.125F)
				sFeetInches = iFeet.ToString() + "' " + fInches.ToString("f0") + "''";
			else if (fInchRemainder >= 0.125F && fInchRemainder <= 0.375F)
				sFeetInches = iFeet.ToString() + "' " + fInches.ToString("f0") + ".25''";
			else if (fInchRemainder > 0.375F && fInchRemainder <= 0.625F)
				sFeetInches = iFeet.ToString() + "' " + fInches.ToString("f0") + ".50''";
			else if (fInchRemainder > 0.625F && fInchRemainder <= 0.875F)
				sFeetInches = iFeet.ToString() + "' " + fInches.ToString("f0") + ".75''";
			else if (fInchRemainder > 0.875)
			{
				if (fInches == 11)
				{
					iFeet++;
					sFeetInches = iFeet.ToString() + "' 0''";
				}
				else
					sFeetInches = iFeet.ToString() + "' " + (fInches + 1).ToString("f0") + "''";
			}

			return sFeetInches;
		}

		public static string InchesToFeetInches(float fValue)
		{
			string sFeetInches;
			int iFeet;
			float fInches, fInchRemainder;

			iFeet = (int)Math.Floor((double)(fValue / 12));
			fInches = (fValue / 12) - iFeet;
			fInchRemainder = (fInches * 12) - Convert.ToSingle(Math.Floor((double)(fInches * 12)));
			fInches = Convert.ToSingle(Math.Floor((double)(fInches * 12)));

			if (fInchRemainder > 0.75)
			{
				if (fInches == 11)
				{
					iFeet++;
					sFeetInches = iFeet.ToString() + "' 0''";
				}
				else
					sFeetInches = iFeet.ToString() + "' " + (fInches + 1).ToString("f0") + "''";
			}
			else
				sFeetInches = iFeet.ToString() + "' " + fInches.ToString("f0") + "''";

			return sFeetInches;
		}

		#region Basic Conversions
		public static float FeetToInches(float fFeet)
		{
			return fFeet * 12;
		}

		public static float InchesToMillimeters(float fInches)
		{
			return fInches * 25.4F;
		}

		public static float InchesToDecimalFeetInches(float fInches)
		{
			return fInches / 12.0F;
		}

		public static float MetersToMilliMeters(float fMeters)
		{
			return fMeters * 1000;
		}

		public static float MillimetersToMeters(float fMillimeters)
		{
			return fMillimeters * 0.001F;
		}

		public static float MillimetersToInches(float fMillimeters)
		{
			return fMillimeters * 0.03937007F;
		}

		public static float CelsiusToFahrenheit(float fCelsius)
		{
			return (Convert.ToSingle(fCelsius * 9.0F / 5.0F)) + 32;
		}

		public static float FahrenheitToCelsius(float fFahrenheit)
		{
			return Convert.ToSingle((fFahrenheit - 32) * 5.0F / 9.0F);
		}

		public static float BARToMBAR(float fBAR)
		{
			return fBAR * 1000;
		}

		public static float BARToPSI(float fBAR)
		{
			return fBAR * 14.503861F;
		}

		public static float BARToMillimetersMercury(float fBAR)
		{
			return fBAR * 750.062F;
		}

		public static float MBARToBAR(float fMBAR)
		{
			return fMBAR * 0.001F;
		}

		public static float PSIToMBAR(float fPSI)
		{
			return fPSI * 68.9475F;
		}

		public static float PSIToMillimetersMercury(float fPSI)
		{
			return fPSI * 51.7149F;
		}

		public static float MBARToPSI(float fMBAR)
		{
			return fMBAR * 0.0145F;
		}

		public static float MBARToMillimetersMercury(float fMBAR)
		{
			return fMBAR * 0.750062F;
		}

		public static float MillimetersMercuryToMBAR(float fMillimetersMercury)
		{
			return fMillimetersMercury * 1.333224F;
		}

		public static float MilliemetersMercuryToPSI(float fMillimetersMercury)
		{
			return fMillimetersMercury * 0.0193368F;
		}

		public static float DegreesToRadians(float fDegrees)
		{
			return fDegrees * 0.0174532925F;
		}

		public static float RadiansToDegress(float fRadians)
		{
			return fRadians * 57.2957795F;
		}

		#endregion
	}
}
