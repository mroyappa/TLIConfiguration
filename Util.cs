using System;
using System.IO;
using System.Net;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using System.Windows.Forms;
using ICBObjectModel;
using ICBObjectModel.Enumerations;

/*
 * CLASS SUMMARY:	Util
 *
 * This is a general purpose class with a handful of statically defined methods used for file I/O, exception logging, etc.
 * 
 */

namespace TLIConfiguration
{
	public class Util
	{

		public static string GetPath()
		{
			string sPath;
			
			sPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
			return sPath;
		}

		public static bool AddLogFileEntry(string sLocation, Exception e)
		{
			lock (typeof(Util))	// Safe for threading
			{
				try
				{
					string sPath = GetPath() + "\\ExceptionLog";

					if (!Directory.Exists(sPath))
						Directory.CreateDirectory(sPath);

					StreamWriter sw = new StreamWriter(sPath + "\\" + DateTime.Now.ToString("yyyy_MM_dd") + "_exception_log.txt", true);

					System.Diagnostics.Debug.WriteLine("EXCEPTION:	" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
					sw.WriteLine("EXCEPTION:	" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
					System.Diagnostics.Debug.WriteLine("LOCATION:		" + sLocation);
					sw.WriteLine("LOCATION:	" + sLocation);
					System.Diagnostics.Debug.WriteLine("MESSAGE:		" + e.Message);
					sw.WriteLine("MESSAGE:	" + e.Message);
					sw.WriteLine("STACK TRACE:	" + e.StackTrace);
					sw.WriteLine("");
					sw.Close();
				}
				catch (Exception ex)
				{
					string s;
					s = "s";
				}
			}

			return true;
		}

		public static T[] ExtendArray<T>(T[] array, int iLength) where T : new()
		{
			List<T> list = new List<T>();
			list.AddRange(array);

			while (list.Count < iLength)
				list.Add(new T());

			return list.ToArray();
		}
	}
}
