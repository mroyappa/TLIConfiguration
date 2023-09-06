using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

/*
 * CLASS SUMMARY:	ModbusAutoAssign
 * 
 * ModbusAutoAssign was the original implemenation idea for assigning Modbus registers to a vessel configuration. This idea
 * was abandoned before finsished in favor of the current user-assigned method.
 * 
 */

namespace TLIConfiguration
{
	public partial class ModbusAutoAssign : Form
	{
		public ModbusAutoAssign()
		{
			InitializeComponent();
		}
	}
}