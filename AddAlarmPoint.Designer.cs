namespace TLIConfiguration
{
	partial class AddAlarmPoint
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
			this.txtAlarmPriority = new System.Windows.Forms.TextBox();
			this.cboAlarmType = new System.Windows.Forms.ComboBox();
			this.lblAlarmPriority = new System.Windows.Forms.Label();
			this.cboAlarmMonitorType = new System.Windows.Forms.ComboBox();
			this.lblAlarmType = new System.Windows.Forms.Label();
			this.lblAlarmMonitorType = new System.Windows.Forms.Label();
			this.lblAlarmGroup = new System.Windows.Forms.Label();
			this.txtAlarmGroup = new System.Windows.Forms.TextBox();
			this.lblAlarmText = new System.Windows.Forms.Label();
			this.txtAlarmText = new System.Windows.Forms.TextBox();
			this.lblDisplayName = new System.Windows.Forms.Label();
			this.txtDisplayName = new System.Windows.Forms.TextBox();
			this.cmdOk = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.groupBoxGaugePoint.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxGaugePoint
			// 
			this.groupBoxGaugePoint.Controls.Add(this.txtDisplayName);
			this.groupBoxGaugePoint.Controls.Add(this.lblDisplayName);
			this.groupBoxGaugePoint.Controls.Add(this.txtAlarmText);
			this.groupBoxGaugePoint.Controls.Add(this.lblAlarmText);
			this.groupBoxGaugePoint.Controls.Add(this.txtAlarmGroup);
			this.groupBoxGaugePoint.Controls.Add(this.lblAlarmGroup);
			this.groupBoxGaugePoint.Controls.Add(this.txtAlarmPriority);
			this.groupBoxGaugePoint.Controls.Add(this.cboAlarmType);
			this.groupBoxGaugePoint.Controls.Add(this.lblAlarmPriority);
			this.groupBoxGaugePoint.Controls.Add(this.cboAlarmMonitorType);
			this.groupBoxGaugePoint.Controls.Add(this.lblAlarmType);
			this.groupBoxGaugePoint.Controls.Add(this.lblAlarmMonitorType);
			this.groupBoxGaugePoint.Location = new System.Drawing.Point(7, 2);
			this.groupBoxGaugePoint.Name = "groupBoxGaugePoint";
			this.groupBoxGaugePoint.Size = new System.Drawing.Size(236, 175);
			this.groupBoxGaugePoint.TabIndex = 1;
			this.groupBoxGaugePoint.TabStop = false;
			// 
			// txtAlarmPriority
			// 
			this.txtAlarmPriority.Location = new System.Drawing.Point(87, 67);
			this.txtAlarmPriority.Name = "txtAlarmPriority";
			this.txtAlarmPriority.Size = new System.Drawing.Size(139, 20);
			this.txtAlarmPriority.TabIndex = 2;
			this.txtAlarmPriority.Text = "1";
			this.txtAlarmPriority.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cboAlarmType
			// 
			this.cboAlarmType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAlarmType.FormattingEnabled = true;
			this.cboAlarmType.Location = new System.Drawing.Point(87, 41);
			this.cboAlarmType.Name = "cboAlarmType";
			this.cboAlarmType.Size = new System.Drawing.Size(139, 21);
			this.cboAlarmType.TabIndex = 1;
			// 
			// lblAlarmPriority
			// 
			this.lblAlarmPriority.AutoSize = true;
			this.lblAlarmPriority.Location = new System.Drawing.Point(6, 71);
			this.lblAlarmPriority.Name = "lblAlarmPriority";
			this.lblAlarmPriority.Size = new System.Drawing.Size(38, 13);
			this.lblAlarmPriority.TabIndex = 3;
			this.lblAlarmPriority.Text = "Priority";
			// 
			// cboAlarmMonitorType
			// 
			this.cboAlarmMonitorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAlarmMonitorType.FormattingEnabled = true;
			this.cboAlarmMonitorType.Location = new System.Drawing.Point(87, 15);
			this.cboAlarmMonitorType.Name = "cboAlarmMonitorType";
			this.cboAlarmMonitorType.Size = new System.Drawing.Size(139, 21);
			this.cboAlarmMonitorType.TabIndex = 0;
			// 
			// lblAlarmType
			// 
			this.lblAlarmType.AutoSize = true;
			this.lblAlarmType.Location = new System.Drawing.Point(6, 45);
			this.lblAlarmType.Name = "lblAlarmType";
			this.lblAlarmType.Size = new System.Drawing.Size(31, 13);
			this.lblAlarmType.TabIndex = 2;
			this.lblAlarmType.Text = "Type";
			// 
			// lblAlarmMonitorType
			// 
			this.lblAlarmMonitorType.AutoSize = true;
			this.lblAlarmMonitorType.Location = new System.Drawing.Point(6, 19);
			this.lblAlarmMonitorType.Name = "lblAlarmMonitorType";
			this.lblAlarmMonitorType.Size = new System.Drawing.Size(69, 13);
			this.lblAlarmMonitorType.TabIndex = 1;
			this.lblAlarmMonitorType.Text = "Monitor Type";
			// 
			// lblAlarmGroup
			// 
			this.lblAlarmGroup.AutoSize = true;
			this.lblAlarmGroup.Location = new System.Drawing.Point(6, 97);
			this.lblAlarmGroup.Name = "lblAlarmGroup";
			this.lblAlarmGroup.Size = new System.Drawing.Size(36, 13);
			this.lblAlarmGroup.TabIndex = 4;
			this.lblAlarmGroup.Text = "Group";
			// 
			// txtAlarmGroup
			// 
			this.txtAlarmGroup.Location = new System.Drawing.Point(87, 93);
			this.txtAlarmGroup.Name = "txtAlarmGroup";
			this.txtAlarmGroup.Size = new System.Drawing.Size(139, 20);
			this.txtAlarmGroup.TabIndex = 3;
			this.txtAlarmGroup.Text = "Alarm";
			// 
			// lblAlarmText
			// 
			this.lblAlarmText.AutoSize = true;
			this.lblAlarmText.Location = new System.Drawing.Point(6, 123);
			this.lblAlarmText.Name = "lblAlarmText";
			this.lblAlarmText.Size = new System.Drawing.Size(28, 13);
			this.lblAlarmText.TabIndex = 6;
			this.lblAlarmText.Text = "Text";
			// 
			// txtAlarmText
			// 
			this.txtAlarmText.Location = new System.Drawing.Point(87, 119);
			this.txtAlarmText.Name = "txtAlarmText";
			this.txtAlarmText.Size = new System.Drawing.Size(139, 20);
			this.txtAlarmText.TabIndex = 4;
			// 
			// lblDisplayName
			// 
			this.lblDisplayName.AutoSize = true;
			this.lblDisplayName.Location = new System.Drawing.Point(6, 149);
			this.lblDisplayName.Name = "lblDisplayName";
			this.lblDisplayName.Size = new System.Drawing.Size(72, 13);
			this.lblDisplayName.TabIndex = 8;
			this.lblDisplayName.Text = "Display Name";
			// 
			// txtDisplayName
			// 
			this.txtDisplayName.Location = new System.Drawing.Point(87, 145);
			this.txtDisplayName.Name = "txtDisplayName";
			this.txtDisplayName.Size = new System.Drawing.Size(139, 20);
			this.txtDisplayName.TabIndex = 5;
			// 
			// cmdOk
			// 
			this.cmdOk.Location = new System.Drawing.Point(87, 183);
			this.cmdOk.Name = "cmdOk";
			this.cmdOk.Size = new System.Drawing.Size(75, 23);
			this.cmdOk.TabIndex = 2;
			this.cmdOk.Text = "Ok";
			this.cmdOk.UseVisualStyleBackColor = true;
			this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.Location = new System.Drawing.Point(168, 183);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 3;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.UseVisualStyleBackColor = true;
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// AddAlarmPoint
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(250, 214);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOk);
			this.Controls.Add(this.groupBoxGaugePoint);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "AddAlarmPoint";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Alarm Point";
			this.Load += new System.EventHandler(this.AddAlarmPoint_Load);
			this.groupBoxGaugePoint.ResumeLayout(false);
			this.groupBoxGaugePoint.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBoxGaugePoint;
		private System.Windows.Forms.TextBox txtAlarmPriority;
		private System.Windows.Forms.ComboBox cboAlarmType;
		private System.Windows.Forms.Label lblAlarmPriority;
		private System.Windows.Forms.ComboBox cboAlarmMonitorType;
		private System.Windows.Forms.Label lblAlarmType;
		private System.Windows.Forms.Label lblAlarmMonitorType;
		private System.Windows.Forms.TextBox txtAlarmGroup;
		private System.Windows.Forms.Label lblAlarmGroup;
		private System.Windows.Forms.TextBox txtAlarmText;
		private System.Windows.Forms.Label lblAlarmText;
		private System.Windows.Forms.TextBox txtDisplayName;
		private System.Windows.Forms.Label lblDisplayName;
		private System.Windows.Forms.Button cmdOk;
		private System.Windows.Forms.Button cmdCancel;
	}
}