using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TLIConfiguration
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Xceed.Grid.Licenser.LicenseKey = "GRD36YCWDXZWG4NYNXA";

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			if (args.Length == 1 && System.IO.File.Exists(args[0]))
				Application.Run(new TLIConfiguration(args[0]));
			else
				Application.Run(new TLIConfiguration(""));
		}

		static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			Exception ex = (Exception)e.ExceptionObject;
			Util.AddLogFileEntry("Unhandled App Domain Exception (App Domain)", ex);

			MessageBox.Show("An unhandled exception has occured and been logged (App Domain).", "Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
		}

		static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			Util.AddLogFileEntry("Unhandled Thread Exception (Thread Exception)", e.Exception);

			MessageBox.Show("An unhandled exception has occured and been logged (Thread Exception).", "Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
		}
	}
}