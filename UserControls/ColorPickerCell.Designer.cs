using System;
using System.Windows.Forms;

namespace TLIConfiguration
{
	partial class ColorPickerCell
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// colorPicker
			// 
			//this.colorPicker.Location = new System.Drawing.Point(-9, -6);
			//this.colorPicker.Name = "colorPicker";
			//this.colorPicker.Size = new System.Drawing.Size(209, 39);
			//this.colorPicker.TabIndex = 10;
			//this.colorPicker.TextDisplayed = false;
			// 
			// ColorPickerCell
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.Controls.Add(this.colorPicker);
			this.Name = "ColorPickerCell";
			this.Size = new System.Drawing.Size(173, 22);
			this.Click += new System.EventHandler(this.onclick);
			this.ResumeLayout(false);

		}

		private void onclick(object sender, EventArgs e)
		{
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                //Console.WriteLine("COLORS : " + colorPicker.Color.ToString());
                Value = colorPicker.Color;
            }
        }

        #endregion

        //private ColorPicker.ColorPicker colorPicker;
        private ColorDialog colorPicker;


	}
}
