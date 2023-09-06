namespace TLIConfiguration
{
	partial class SerialModbus
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerialModbus));
			this.tc = new System.Windows.Forms.TabControl();
			this.tpGauge = new System.Windows.Forms.TabPage();
			this.gcGauge = new CustomXceedGridControl();
			this.dataRowTemplate1 = new Xceed.Grid.DataRow();
			this.columnManagerRow1 = new Xceed.Grid.ColumnManagerRow();
			this.cmdCopy = new System.Windows.Forms.Button();
			this.cmdClearGauge = new System.Windows.Forms.Button();
			this.grpConfiguration = new System.Windows.Forms.GroupBox();
			this.lblAddressRange = new System.Windows.Forms.Label();
			this.cboAddressRange = new System.Windows.Forms.ComboBox();
			this.tpAlarm = new System.Windows.Forms.TabPage();
			this.gcAlarm = new CustomXceedGridControl();
			this.dataRow1 = new Xceed.Grid.DataRow();
			this.columnManagerRow2 = new Xceed.Grid.ColumnManagerRow();
			this.cmdOk = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.chkIncludeSystemStatus = new System.Windows.Forms.CheckBox();
			this.toolTipProvider = new System.Windows.Forms.ToolTip(this.components);
			this.tc.SuspendLayout();
			this.tpGauge.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcGauge)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataRowTemplate1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.columnManagerRow1)).BeginInit();
			this.grpConfiguration.SuspendLayout();
			this.tpAlarm.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcAlarm)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataRow1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.columnManagerRow2)).BeginInit();
			this.SuspendLayout();
			// 
			// tc
			// 
			this.tc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tc.Controls.Add(this.tpGauge);
			this.tc.Controls.Add(this.tpAlarm);
			this.tc.Location = new System.Drawing.Point(0, 1);
			this.tc.Name = "tc";
			this.tc.SelectedIndex = 0;
			this.tc.Size = new System.Drawing.Size(734, 648);
			this.tc.TabIndex = 0;
			// 
			// tpGauge
			// 
			this.tpGauge.Controls.Add(this.gcGauge);
			this.tpGauge.Controls.Add(this.cmdCopy);
			this.tpGauge.Controls.Add(this.cmdClearGauge);
			this.tpGauge.Controls.Add(this.grpConfiguration);
			this.tpGauge.Location = new System.Drawing.Point(4, 22);
			this.tpGauge.Name = "tpGauge";
			this.tpGauge.Padding = new System.Windows.Forms.Padding(3);
			this.tpGauge.Size = new System.Drawing.Size(726, 622);
			this.tpGauge.TabIndex = 0;
			this.tpGauge.Text = "Gauging";
			this.tpGauge.UseVisualStyleBackColor = true;
			// 
			// gcGauge
			// 
			this.gcGauge.AllowDelete = true;
			this.gcGauge.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gcGauge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.gcGauge.ClipCurrentCellSelection = false;
			this.gcGauge.DataRowTemplate = this.dataRowTemplate1;
			this.gcGauge.DeletedRowColor = System.Drawing.Color.Empty;
			this.gcGauge.ExpandToFitColumn = null;
			this.gcGauge.FillDataMemberDelegate = null;
			this.gcGauge.FixedHeaderRows.Add(this.columnManagerRow1);
			this.gcGauge.InsertedRowColor = System.Drawing.Color.Empty;
			this.gcGauge.Location = new System.Drawing.Point(8, 66);
			this.gcGauge.Name = "gcGauge";
			this.gcGauge.ResetDataMemberDelegate = null;
			this.gcGauge.ScrollBars = Xceed.Grid.GridScrollBars.Vertical;
			this.gcGauge.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
			this.gcGauge.SelectionForeColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.gcGauge.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.gcGauge.ShowFocusRectangle = false;
			this.gcGauge.Size = new System.Drawing.Size(706, 521);
			this.gcGauge.TabIndex = 11;
			this.gcGauge.UIStyle = Xceed.UI.UIStyle.WindowsClassic;
			this.gcGauge.UIVirtualizationMode = Xceed.Grid.UIVirtualizationMode.Cells;
			this.gcGauge.UpdateDataMemberDelegate = null;
			this.gcGauge.UpdatedRowColor = System.Drawing.Color.Empty;
			this.gcGauge.AddingDataRow += new Xceed.Grid.AddingDataRowEventHandler(this.AddingGaugeDataRow);
			// 
			// cmdCopy
			// 
			this.cmdCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cmdCopy.Location = new System.Drawing.Point(8, 593);
			this.cmdCopy.Name = "cmdCopy";
			this.cmdCopy.Size = new System.Drawing.Size(117, 23);
			this.cmdCopy.TabIndex = 9;
			this.cmdCopy.Text = "Copy TCP Interface";
			this.cmdCopy.UseVisualStyleBackColor = true;
			this.cmdCopy.Click += new System.EventHandler(this.CmdCopy_Click);
			// 
			// cmdClearGauge
			// 
			this.cmdClearGauge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdClearGauge.Location = new System.Drawing.Point(641, 593);
			this.cmdClearGauge.Name = "cmdClearGauge";
			this.cmdClearGauge.Size = new System.Drawing.Size(75, 23);
			this.cmdClearGauge.TabIndex = 8;
			this.cmdClearGauge.Text = "Clear";
			this.cmdClearGauge.UseVisualStyleBackColor = true;
			this.cmdClearGauge.Click += new System.EventHandler(this.CmdClearGauge_Click);
			// 
			// grpConfiguration
			// 
			this.grpConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grpConfiguration.Controls.Add(this.lblAddressRange);
			this.grpConfiguration.Controls.Add(this.cboAddressRange);
			this.grpConfiguration.Location = new System.Drawing.Point(8, 6);
			this.grpConfiguration.Name = "grpConfiguration";
			this.grpConfiguration.Size = new System.Drawing.Size(706, 52);
			this.grpConfiguration.TabIndex = 7;
			this.grpConfiguration.TabStop = false;
			this.grpConfiguration.Text = "Configuration";
			// 
			// lblAddressRange
			// 
			this.lblAddressRange.AutoSize = true;
			this.lblAddressRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAddressRange.Location = new System.Drawing.Point(8, 23);
			this.lblAddressRange.Name = "lblAddressRange";
			this.lblAddressRange.Size = new System.Drawing.Size(93, 13);
			this.lblAddressRange.TabIndex = 10;
			this.lblAddressRange.Text = "Address Range";
			// 
			// cboAddressRange
			// 
			this.cboAddressRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAddressRange.FormattingEnabled = true;
			this.cboAddressRange.Location = new System.Drawing.Point(136, 19);
			this.cboAddressRange.Name = "cboAddressRange";
			this.cboAddressRange.Size = new System.Drawing.Size(121, 21);
			this.cboAddressRange.TabIndex = 8;
			// 
			// tpAlarm
			// 
			this.tpAlarm.Controls.Add(this.gcAlarm);
			this.tpAlarm.Location = new System.Drawing.Point(4, 22);
			this.tpAlarm.Name = "tpAlarm";
			this.tpAlarm.Padding = new System.Windows.Forms.Padding(3);
			this.tpAlarm.Size = new System.Drawing.Size(726, 622);
			this.tpAlarm.TabIndex = 1;
			this.tpAlarm.Text = "Alarming";
			this.tpAlarm.UseVisualStyleBackColor = true;
			// 
			// gcAlarm
			// 
			this.gcAlarm.AllowDelete = true;
			this.gcAlarm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gcAlarm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.gcAlarm.ClipCurrentCellSelection = false;
			this.gcAlarm.DataRowTemplate = this.dataRow1;
			this.gcAlarm.DeletedRowColor = System.Drawing.Color.Empty;
			this.gcAlarm.ExpandToFitColumn = null;
			this.gcAlarm.FillDataMemberDelegate = null;
			this.gcAlarm.FixedHeaderRows.Add(this.columnManagerRow2);
			this.gcAlarm.InsertedRowColor = System.Drawing.Color.Empty;
			this.gcAlarm.Location = new System.Drawing.Point(10, 6);
			this.gcAlarm.Name = "gcAlarm";
			this.gcAlarm.ResetDataMemberDelegate = null;
			this.gcAlarm.ScrollBars = Xceed.Grid.GridScrollBars.Vertical;
			this.gcAlarm.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
			this.gcAlarm.SelectionForeColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.gcAlarm.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.gcAlarm.ShowFocusRectangle = false;
			this.gcAlarm.Size = new System.Drawing.Size(706, 610);
			this.gcAlarm.TabIndex = 12;
			this.gcAlarm.UIStyle = Xceed.UI.UIStyle.WindowsClassic;
			this.gcAlarm.UIVirtualizationMode = Xceed.Grid.UIVirtualizationMode.Cells;
			this.gcAlarm.UpdateDataMemberDelegate = null;
			this.gcAlarm.UpdatedRowColor = System.Drawing.Color.Empty;
			this.gcAlarm.AddingDataRow += new Xceed.Grid.AddingDataRowEventHandler(this.AddingAlarmDataRow);
			// 
			// cmdOk
			// 
			this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdOk.Location = new System.Drawing.Point(566, 655);
			this.cmdOk.Name = "cmdOk";
			this.cmdOk.Size = new System.Drawing.Size(75, 23);
			this.cmdOk.TabIndex = 1;
			this.cmdOk.Text = "Ok";
			this.cmdOk.UseVisualStyleBackColor = true;
			this.cmdOk.Click += new System.EventHandler(this.CmdOk_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdCancel.Location = new System.Drawing.Point(647, 655);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 2;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.UseVisualStyleBackColor = true;
			this.cmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
			// 
			// chkIncludeSystemStatus
			// 
			this.chkIncludeSystemStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkIncludeSystemStatus.AutoSize = true;
			this.chkIncludeSystemStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkIncludeSystemStatus.Location = new System.Drawing.Point(14, 658);
			this.chkIncludeSystemStatus.Name = "chkIncludeSystemStatus";
			this.chkIncludeSystemStatus.Size = new System.Drawing.Size(209, 17);
			this.chkIncludeSystemStatus.TabIndex = 3;
			this.chkIncludeSystemStatus.Text = "Include System Status Registers";
			this.toolTipProvider.SetToolTip(this.chkIncludeSystemStatus, "Enabling this feature adds a set of status registers to the end of the configured" +
					" registry set.  See Modbus Export for configuration.");
			this.chkIncludeSystemStatus.UseVisualStyleBackColor = true;
			// 
			// toolTipProvider
			// 
			this.toolTipProvider.AutoPopDelay = 10000;
			this.toolTipProvider.InitialDelay = 500;
			this.toolTipProvider.IsBalloon = true;
			this.toolTipProvider.ReshowDelay = 100;
			// 
			// SerialModbus
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(732, 684);
			this.Controls.Add(this.chkIncludeSystemStatus);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOk);
			this.Controls.Add(this.tc);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimizeBox = false;
			this.Name = "SerialModbus";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Serial Modbus Configuration";
			this.Load += new System.EventHandler(this.SerialModbus_Load);
			this.tc.ResumeLayout(false);
			this.tpGauge.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gcGauge)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataRowTemplate1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.columnManagerRow1)).EndInit();
			this.grpConfiguration.ResumeLayout(false);
			this.grpConfiguration.PerformLayout();
			this.tpAlarm.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gcAlarm)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataRow1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.columnManagerRow2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl tc;
		private System.Windows.Forms.TabPage tpGauge;
		private System.Windows.Forms.TabPage tpAlarm;
		private System.Windows.Forms.Button cmdOk;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.GroupBox grpConfiguration;
		private System.Windows.Forms.ComboBox cboAddressRange;
		private System.Windows.Forms.Label lblAddressRange;
		private System.Windows.Forms.Button cmdCopy;
		private System.Windows.Forms.Button cmdClearGauge;
		private CustomXceedGridControl gcGauge;
		private Xceed.Grid.DataRow dataRowTemplate1;
		private Xceed.Grid.ColumnManagerRow columnManagerRow1;
		private CustomXceedGridControl gcAlarm;
		private Xceed.Grid.DataRow dataRow1;
		private Xceed.Grid.ColumnManagerRow columnManagerRow2;
		private System.Windows.Forms.CheckBox chkIncludeSystemStatus;
		private System.Windows.Forms.ToolTip toolTipProvider;
	}
}