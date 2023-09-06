namespace TLIConfiguration
{
	partial class AddGaugePoint
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBoxGaugePoint = new System.Windows.Forms.GroupBox();
			this.txtDisplayName = new System.Windows.Forms.TextBox();
			this.cboGaugeNumber = new System.Windows.Forms.ComboBox();
			this.lblDisplayName = new System.Windows.Forms.Label();
			this.cboGaugeType = new System.Windows.Forms.ComboBox();
			this.lblGaugeNumber = new System.Windows.Forms.Label();
			this.lblGaugeType = new System.Windows.Forms.Label();
			this.cmdOk = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.groupBoxGaugePoint.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxGaugePoint
			// 
			this.groupBoxGaugePoint.Controls.Add(this.txtDisplayName);
			this.groupBoxGaugePoint.Controls.Add(this.cboGaugeNumber);
			this.groupBoxGaugePoint.Controls.Add(this.lblDisplayName);
			this.groupBoxGaugePoint.Controls.Add(this.cboGaugeType);
			this.groupBoxGaugePoint.Controls.Add(this.lblGaugeNumber);
			this.groupBoxGaugePoint.Controls.Add(this.lblGaugeType);
			this.groupBoxGaugePoint.Location = new System.Drawing.Point(7, 2);
			this.groupBoxGaugePoint.Name = "groupBoxGaugePoint";
			this.groupBoxGaugePoint.Size = new System.Drawing.Size(236, 96);
			this.groupBoxGaugePoint.TabIndex = 0;
			this.groupBoxGaugePoint.TabStop = false;
			// 
			// txtDisplayName
			// 
			this.txtDisplayName.Location = new System.Drawing.Point(87, 67);
			this.txtDisplayName.Name = "txtDisplayName";
			this.txtDisplayName.Size = new System.Drawing.Size(139, 20);
			this.txtDisplayName.TabIndex = 2;
			// 
			// cboGaugeNumber
			// 
			this.cboGaugeNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboGaugeNumber.FormattingEnabled = true;
			this.cboGaugeNumber.Location = new System.Drawing.Point(87, 41);
			this.cboGaugeNumber.Name = "cboGaugeNumber";
			this.cboGaugeNumber.Size = new System.Drawing.Size(139, 21);
			this.cboGaugeNumber.TabIndex = 1;
			// 
			// lblDisplayName
			// 
			this.lblDisplayName.AutoSize = true;
			this.lblDisplayName.Location = new System.Drawing.Point(6, 71);
			this.lblDisplayName.Name = "lblDisplayName";
			this.lblDisplayName.Size = new System.Drawing.Size(72, 13);
			this.lblDisplayName.TabIndex = 3;
			this.lblDisplayName.Text = "Display Name";
			// 
			// cboGaugeType
			// 
			this.cboGaugeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboGaugeType.FormattingEnabled = true;
			this.cboGaugeType.Location = new System.Drawing.Point(87, 15);
			this.cboGaugeType.Name = "cboGaugeType";
			this.cboGaugeType.Size = new System.Drawing.Size(139, 21);
			this.cboGaugeType.TabIndex = 0;
			// 
			// lblGaugeNumber
			// 
			this.lblGaugeNumber.AutoSize = true;
			this.lblGaugeNumber.Location = new System.Drawing.Point(6, 45);
			this.lblGaugeNumber.Name = "lblGaugeNumber";
			this.lblGaugeNumber.Size = new System.Drawing.Size(44, 13);
			this.lblGaugeNumber.TabIndex = 2;
			this.lblGaugeNumber.Text = "Number";
			// 
			// lblGaugeType
			// 
			this.lblGaugeType.AutoSize = true;
			this.lblGaugeType.Location = new System.Drawing.Point(6, 19);
			this.lblGaugeType.Name = "lblGaugeType";
			this.lblGaugeType.Size = new System.Drawing.Size(31, 13);
			this.lblGaugeType.TabIndex = 1;
			this.lblGaugeType.Text = "Type";
			// 
			// cmdOk
			// 
			this.cmdOk.Location = new System.Drawing.Point(87, 104);
			this.cmdOk.Name = "cmdOk";
			this.cmdOk.Size = new System.Drawing.Size(75, 23);
			this.cmdOk.TabIndex = 1;
			this.cmdOk.Text = "Ok";
			this.cmdOk.UseVisualStyleBackColor = true;
			this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.Location = new System.Drawing.Point(168, 104);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 2;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.UseVisualStyleBackColor = true;
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// AddGaugePoint
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(250, 132);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOk);
			this.Controls.Add(this.groupBoxGaugePoint);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "AddGaugePoint";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AddGaugePoint";
			this.Load += new System.EventHandler(this.AddGaugePoint_Load);
			this.groupBoxGaugePoint.ResumeLayout(false);
			this.groupBoxGaugePoint.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBoxGaugePoint;
		private System.Windows.Forms.Label lblDisplayName;
		private System.Windows.Forms.Label lblGaugeNumber;
		private System.Windows.Forms.Label lblGaugeType;
		private System.Windows.Forms.TextBox txtDisplayName;
		private System.Windows.Forms.ComboBox cboGaugeType;
		private System.Windows.Forms.ComboBox cboGaugeNumber;
		private System.Windows.Forms.Button cmdOk;
		private System.Windows.Forms.Button cmdCancel;
	}
}