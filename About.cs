using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

/*
 * CLASS SUMMARY:	About
 * 
 * This is the application About (information) form which details the current version.
 * 
 */

namespace TLIConfiguration
{
	public partial class About : Form
	{
		public About()
		{
			InitializeComponent();
		}

		private void About_Load(object sender, EventArgs e)
		{
			lblVersion.Text = "Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("iexplore", "http://www.prismsystems.com");
		}
	}
}