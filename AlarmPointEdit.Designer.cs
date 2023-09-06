namespace TLIConfiguration
{
	partial class AlarmPointEdit
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlarmPointEdit));
			this.grpGeneral = new System.Windows.Forms.GroupBox();
			this.txtAlarmText = new System.Windows.Forms.TextBox();
			this.lblAlarmText = new System.Windows.Forms.Label();
			this.cboAlarmPriority = new System.Windows.Forms.ComboBox();
			this.lblAlarmPriority = new System.Windows.Forms.Label();
			this.cboAlarmType = new System.Windows.Forms.ComboBox();
			this.lblAlarmType = new System.Windows.Forms.Label();
			this.cboAlarmMonitorType = new System.Windows.Forms.ComboBox();
			this.lblAlarmMonitorType = new System.Windows.Forms.Label();
			this.chkEnable = new System.Windows.Forms.CheckBox();
			this.txtDisplayName = new System.Windows.Forms.TextBox();
			this.lblEnabled = new System.Windows.Forms.Label();
			this.lblDisplayName = new System.Windows.Forms.Label();
			this.grpEngineering = new System.Windows.Forms.GroupBox();
			this.chkAutoClear = new System.Windows.Forms.CheckBox();
			this.cboComparator = new System.Windows.Forms.ComboBox();
			this.lblAutoClearEnable = new System.Windows.Forms.Label();
			this.txtAlarmDeadband = new System.Windows.Forms.TextBox();
			this.lblAlarmDeadband = new System.Windows.Forms.Label();
			this.txtDebounceTimer = new System.Windows.Forms.TextBox();
			this.lblComparator = new System.Windows.Forms.Label();
			this.lblDebounceTimer = new System.Windows.Forms.Label();
			this.lblLimit = new System.Windows.Forms.Label();
			this.txtLimit = new System.Windows.Forms.TextBox();
			this.grpAlarmAnnunciation = new System.Windows.Forms.GroupBox();
			this.cmdAddAlarmAnnunciation = new System.Windows.Forms.Button();
			this.cboAlarmAnnunciation = new System.Windows.Forms.ComboBox();
			this.lblAlarmAnnunciation = new System.Windows.Forms.Label();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOk = new System.Windows.Forms.Button();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.alarmGrid = new CustomXceedGridControl();
			this.dataRowTemplate1 = new Xceed.Grid.DataRow();
			this.columnManagerRow1 = new Xceed.Grid.ColumnManagerRow();
			this.txtTrailingDebounceTimer = new System.Windows.Forms.TextBox();
			this.lblTrailingDebounceTimer = new System.Windows.Forms.Label();
			this.grpGeneral.SuspendLayout();
			this.grpEngineering.SuspendLayout();
			this.grpAlarmAnnunciation.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.alarmGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataRowTemplate1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.columnManagerRow1)).BeginInit();
			this.SuspendLayout();
			// 
			// grpGeneral
			// 
			this.grpGeneral.Controls.Add(this.txtAlarmText);
			this.grpGeneral.Controls.Add(this.lblAlarmText);
			this.grpGeneral.Controls.Add(this.cboAlarmPriority);
			this.grpGeneral.Controls.Add(this.lblAlarmPriority);
			this.grpGeneral.Controls.Add(this.cboAlarmType);
			this.grpGeneral.Controls.Add(this.lblAlarmType);
			this.grpGeneral.Controls.Add(this.cboAlarmMonitorType);
			this.grpGeneral.Controls.Add(this.lblAlarmMonitorType);
			this.grpGeneral.Controls.Add(this.chkEnable);
			this.grpGeneral.Controls.Add(this.txtDisplayName);
			this.grpGeneral.Controls.Add(this.lblEnabled);
			this.grpGeneral.Controls.Add(this.lblDisplayName);
			this.grpGeneral.Location = new System.Drawing.Point(12, 12);
			this.grpGeneral.Name = "grpGeneral";
			this.grpGeneral.Size = new System.Drawing.Size(574, 126);
			this.grpGeneral.TabIndex = 0;
			this.grpGeneral.TabStop = false;
			this.grpGeneral.Text = "General";
			// 
			// txtAlarmText
			// 
			this.txtAlarmText.Location = new System.Drawing.Point(161, 97);
			this.txtAlarmText.Name = "txtAlarmText";
			this.txtAlarmText.Size = new System.Drawing.Size(382, 20);
			this.txtAlarmText.TabIndex = 6;
			this.toolTip.SetToolTip(this.txtAlarmText, "Information displayed to the end user when the alarm is sounded.");
			// 
			// lblAlarmText
			// 
			this.lblAlarmText.AutoSize = true;
			this.lblAlarmText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAlarmText.Location = new System.Drawing.Point(21, 102);
			this.lblAlarmText.Name = "lblAlarmText";
			this.lblAlarmText.Size = new System.Drawing.Size(32, 13);
			this.lblAlarmText.TabIndex = 13;
			this.lblAlarmText.Text = "Text";
			// 
			// cboAlarmPriority
			// 
			this.cboAlarmPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAlarmPriority.FormattingEnabled = true;
			this.cboAlarmPriority.Location = new System.Drawing.Point(161, 70);
			this.cboAlarmPriority.Name = "cboAlarmPriority";
			this.cboAlarmPriority.Size = new System.Drawing.Size(127, 21);
			this.cboAlarmPriority.TabIndex = 4;
			this.toolTip.SetToolTip(this.cboAlarmPriority, "The ordinal priority of the alarm.  Alarm priority is significant when the applic" +
					"ation has \r\nmultiple active alarms and must determine which alarm to jump the MT" +
					"DE or UI to.");
			this.cboAlarmPriority.SelectedIndexChanged += new System.EventHandler(this.cboAlarmPriority_SelectedIndexChanged);
			// 
			// lblAlarmPriority
			// 
			this.lblAlarmPriority.AutoSize = true;
			this.lblAlarmPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAlarmPriority.Location = new System.Drawing.Point(21, 74);
			this.lblAlarmPriority.Name = "lblAlarmPriority";
			this.lblAlarmPriority.Size = new System.Drawing.Size(46, 13);
			this.lblAlarmPriority.TabIndex = 9;
			this.lblAlarmPriority.Text = "Priority";
			// 
			// cboAlarmType
			// 
			this.cboAlarmType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAlarmType.FormattingEnabled = true;
			this.cboAlarmType.Location = new System.Drawing.Point(416, 43);
			this.cboAlarmType.Name = "cboAlarmType";
			this.cboAlarmType.Size = new System.Drawing.Size(127, 21);
			this.cboAlarmType.TabIndex = 3;
			this.toolTip.SetToolTip(this.cboAlarmType, resources.GetString("cboAlarmType.ToolTip"));
			// 
			// lblAlarmType
			// 
			this.lblAlarmType.AutoSize = true;
			this.lblAlarmType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAlarmType.Location = new System.Drawing.Point(293, 47);
			this.lblAlarmType.Name = "lblAlarmType";
			this.lblAlarmType.Size = new System.Drawing.Size(70, 13);
			this.lblAlarmType.TabIndex = 7;
			this.lblAlarmType.Text = "Alarm Type";
			// 
			// cboAlarmMonitorType
			// 
			this.cboAlarmMonitorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAlarmMonitorType.FormattingEnabled = true;
			this.cboAlarmMonitorType.Location = new System.Drawing.Point(161, 17);
			this.cboAlarmMonitorType.Name = "cboAlarmMonitorType";
			this.cboAlarmMonitorType.Size = new System.Drawing.Size(127, 21);
			this.cboAlarmMonitorType.TabIndex = 0;
			this.toolTip.SetToolTip(this.cboAlarmMonitorType, resources.GetString("cboAlarmMonitorType.ToolTip"));
			this.cboAlarmMonitorType.SelectedIndexChanged += new System.EventHandler(this.cboAlarmMonitorType_SelectedIndexChanged);
			// 
			// lblAlarmMonitorType
			// 
			this.lblAlarmMonitorType.AutoSize = true;
			this.lblAlarmMonitorType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAlarmMonitorType.Location = new System.Drawing.Point(21, 22);
			this.lblAlarmMonitorType.Name = "lblAlarmMonitorType";
			this.lblAlarmMonitorType.Size = new System.Drawing.Size(81, 13);
			this.lblAlarmMonitorType.TabIndex = 5;
			this.lblAlarmMonitorType.Text = "Monitor Type";
			// 
			// chkEnable
			// 
			this.chkEnable.AutoSize = true;
			this.chkEnable.Location = new System.Drawing.Point(416, 21);
			this.chkEnable.Name = "chkEnable";
			this.chkEnable.Size = new System.Drawing.Size(15, 14);
			this.chkEnable.TabIndex = 1;
			this.toolTip.SetToolTip(this.chkEnable, "Enables the alarm to be evaluated and sounded.");
			this.chkEnable.UseVisualStyleBackColor = true;
			this.chkEnable.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
			// 
			// txtDisplayName
			// 
			this.txtDisplayName.Location = new System.Drawing.Point(161, 43);
			this.txtDisplayName.Name = "txtDisplayName";
			this.txtDisplayName.Size = new System.Drawing.Size(127, 20);
			this.txtDisplayName.TabIndex = 2;
			this.toolTip.SetToolTip(this.txtDisplayName, "Alarm Point name.");
			// 
			// lblEnabled
			// 
			this.lblEnabled.AutoSize = true;
			this.lblEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnabled.Location = new System.Drawing.Point(293, 22);
			this.lblEnabled.Name = "lblEnabled";
			this.lblEnabled.Size = new System.Drawing.Size(53, 13);
			this.lblEnabled.TabIndex = 4;
			this.lblEnabled.Text = "Enabled";
			// 
			// lblDisplayName
			// 
			this.lblDisplayName.AutoSize = true;
			this.lblDisplayName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDisplayName.Location = new System.Drawing.Point(21, 47);
			this.lblDisplayName.Name = "lblDisplayName";
			this.lblDisplayName.Size = new System.Drawing.Size(39, 13);
			this.lblDisplayName.TabIndex = 3;
			this.lblDisplayName.Text = "Name";
			// 
			// grpEngineering
			// 
			this.grpEngineering.Controls.Add(this.txtTrailingDebounceTimer);
			this.grpEngineering.Controls.Add(this.lblTrailingDebounceTimer);
			this.grpEngineering.Controls.Add(this.chkAutoClear);
			this.grpEngineering.Controls.Add(this.cboComparator);
			this.grpEngineering.Controls.Add(this.lblAutoClearEnable);
			this.grpEngineering.Controls.Add(this.txtAlarmDeadband);
			this.grpEngineering.Controls.Add(this.lblAlarmDeadband);
			this.grpEngineering.Controls.Add(this.txtDebounceTimer);
			this.grpEngineering.Controls.Add(this.lblComparator);
			this.grpEngineering.Controls.Add(this.lblDebounceTimer);
			this.grpEngineering.Controls.Add(this.lblLimit);
			this.grpEngineering.Controls.Add(this.txtLimit);
			this.grpEngineering.Location = new System.Drawing.Point(12, 144);
			this.grpEngineering.Name = "grpEngineering";
			this.grpEngineering.Size = new System.Drawing.Size(574, 99);
			this.grpEngineering.TabIndex = 1;
			this.grpEngineering.TabStop = false;
			this.grpEngineering.Text = "Engineering";
			// 
			// chkAutoClear
			// 
			this.chkAutoClear.AutoSize = true;
			this.chkAutoClear.Location = new System.Drawing.Point(161, 47);
			this.chkAutoClear.Name = "chkAutoClear";
			this.chkAutoClear.Size = new System.Drawing.Size(15, 14);
			this.chkAutoClear.TabIndex = 4;
			this.toolTip.SetToolTip(this.chkAutoClear, "Enables automatic acknowledgment of the alarm, after the gauge point has exited a" +
					"n alarmed state.");
			this.chkAutoClear.UseVisualStyleBackColor = true;
			// 
			// cboComparator
			// 
			this.cboComparator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboComparator.FormattingEnabled = true;
			this.cboComparator.Location = new System.Drawing.Point(433, 18);
			this.cboComparator.Name = "cboComparator";
			this.cboComparator.Size = new System.Drawing.Size(127, 21);
			this.cboComparator.TabIndex = 1;
			this.toolTip.SetToolTip(this.cboComparator, "The comparison operator used to evaluate the alarm limit with the current gauge p" +
					"oint to sound the alarm.");
			// 
			// lblAutoClearEnable
			// 
			this.lblAutoClearEnable.AutoSize = true;
			this.lblAutoClearEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAutoClearEnable.Location = new System.Drawing.Point(21, 48);
			this.lblAutoClearEnable.Name = "lblAutoClearEnable";
			this.lblAutoClearEnable.Size = new System.Drawing.Size(66, 13);
			this.lblAutoClearEnable.TabIndex = 15;
			this.lblAutoClearEnable.Text = "Auto Clear";
			// 
			// txtAlarmDeadband
			// 
			this.txtAlarmDeadband.Location = new System.Drawing.Point(433, 44);
			this.txtAlarmDeadband.Name = "txtAlarmDeadband";
			this.txtAlarmDeadband.Size = new System.Drawing.Size(127, 20);
			this.txtAlarmDeadband.TabIndex = 3;
			this.txtAlarmDeadband.Text = "0";
			this.txtAlarmDeadband.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip.SetToolTip(this.txtAlarmDeadband, "When Auto Clear is enabled, auto deadband is the amount past the alarm limit that" +
					" the\r\ngauge point value must reach before the alarm is auto acknowledged.");
			// 
			// lblAlarmDeadband
			// 
			this.lblAlarmDeadband.AutoSize = true;
			this.lblAlarmDeadband.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAlarmDeadband.Location = new System.Drawing.Point(292, 48);
			this.lblAlarmDeadband.Name = "lblAlarmDeadband";
			this.lblAlarmDeadband.Size = new System.Drawing.Size(95, 13);
			this.lblAlarmDeadband.TabIndex = 20;
			this.lblAlarmDeadband.Text = "Auto Deadband";
			// 
			// txtDebounceTimer
			// 
			this.txtDebounceTimer.Location = new System.Drawing.Point(161, 70);
			this.txtDebounceTimer.Name = "txtDebounceTimer";
			this.txtDebounceTimer.Size = new System.Drawing.Size(127, 20);
			this.txtDebounceTimer.TabIndex = 2;
			this.txtDebounceTimer.Text = "0";
			this.txtDebounceTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip.SetToolTip(this.txtDebounceTimer, resources.GetString("txtDebounceTimer.ToolTip"));
			// 
			// lblComparator
			// 
			this.lblComparator.AutoSize = true;
			this.lblComparator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblComparator.Location = new System.Drawing.Point(292, 22);
			this.lblComparator.Name = "lblComparator";
			this.lblComparator.Size = new System.Drawing.Size(71, 13);
			this.lblComparator.TabIndex = 20;
			this.lblComparator.Text = "Comparator";
			// 
			// lblDebounceTimer
			// 
			this.lblDebounceTimer.AutoSize = true;
			this.lblDebounceTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDebounceTimer.Location = new System.Drawing.Point(20, 74);
			this.lblDebounceTimer.Name = "lblDebounceTimer";
			this.lblDebounceTimer.Size = new System.Drawing.Size(65, 13);
			this.lblDebounceTimer.TabIndex = 19;
			this.lblDebounceTimer.Text = "Debounce";
			// 
			// lblLimit
			// 
			this.lblLimit.AutoSize = true;
			this.lblLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLimit.Location = new System.Drawing.Point(21, 22);
			this.lblLimit.Name = "lblLimit";
			this.lblLimit.Size = new System.Drawing.Size(33, 13);
			this.lblLimit.TabIndex = 19;
			this.lblLimit.Text = "Limit";
			// 
			// txtLimit
			// 
			this.txtLimit.Location = new System.Drawing.Point(161, 18);
			this.txtLimit.Name = "txtLimit";
			this.txtLimit.Size = new System.Drawing.Size(127, 20);
			this.txtLimit.TabIndex = 0;
			this.txtLimit.Text = "0";
			this.txtLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip.SetToolTip(this.txtLimit, "The value at which the gauge point will be evaluated against to sound the alarm. " +
					" \r\n\r\nNote:  This value is to be specified in the same units specified for Gaugin" +
					"g Units in the Gauge Point setup.");
			// 
			// grpAlarmAnnunciation
			// 
			this.grpAlarmAnnunciation.Controls.Add(this.cmdAddAlarmAnnunciation);
			this.grpAlarmAnnunciation.Controls.Add(this.alarmGrid);
			this.grpAlarmAnnunciation.Controls.Add(this.cboAlarmAnnunciation);
			this.grpAlarmAnnunciation.Controls.Add(this.lblAlarmAnnunciation);
			this.grpAlarmAnnunciation.Location = new System.Drawing.Point(12, 249);
			this.grpAlarmAnnunciation.Name = "grpAlarmAnnunciation";
			this.grpAlarmAnnunciation.Size = new System.Drawing.Size(574, 254);
			this.grpAlarmAnnunciation.TabIndex = 2;
			this.grpAlarmAnnunciation.TabStop = false;
			this.grpAlarmAnnunciation.Text = "Alarm Annunciations";
			// 
			// cmdAddAlarmAnnunciation
			// 
			this.cmdAddAlarmAnnunciation.Location = new System.Drawing.Point(292, 17);
			this.cmdAddAlarmAnnunciation.Name = "cmdAddAlarmAnnunciation";
			this.cmdAddAlarmAnnunciation.Size = new System.Drawing.Size(75, 23);
			this.cmdAddAlarmAnnunciation.TabIndex = 1;
			this.cmdAddAlarmAnnunciation.Text = "Add";
			this.cmdAddAlarmAnnunciation.UseVisualStyleBackColor = true;
			this.cmdAddAlarmAnnunciation.Click += new System.EventHandler(this.cmdAddAlarmAnnunciation_Click);
			// 
			// cboAlarmAnnunciation
			// 
			this.cboAlarmAnnunciation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAlarmAnnunciation.FormattingEnabled = true;
			this.cboAlarmAnnunciation.Location = new System.Drawing.Point(152, 18);
			this.cboAlarmAnnunciation.Name = "cboAlarmAnnunciation";
			this.cboAlarmAnnunciation.Size = new System.Drawing.Size(127, 21);
			this.cboAlarmAnnunciation.TabIndex = 0;
			this.toolTip.SetToolTip(this.cboAlarmAnnunciation, "Select alarm Annunciations to be used when the alarm is active.");
			// 
			// lblAlarmAnnunciation
			// 
			this.lblAlarmAnnunciation.AutoSize = true;
			this.lblAlarmAnnunciation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAlarmAnnunciation.Location = new System.Drawing.Point(21, 22);
			this.lblAlarmAnnunciation.Name = "lblAlarmAnnunciation";
			this.lblAlarmAnnunciation.Size = new System.Drawing.Size(116, 13);
			this.lblAlarmAnnunciation.TabIndex = 13;
			this.lblAlarmAnnunciation.Text = "Alarm Annunciation";
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(511, 509);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 4;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.UseVisualStyleBackColor = true;
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOk
			// 
			this.cmdOk.Location = new System.Drawing.Point(430, 509);
			this.cmdOk.Name = "cmdOk";
			this.cmdOk.Size = new System.Drawing.Size(75, 23);
			this.cmdOk.TabIndex = 3;
			this.cmdOk.Text = "Ok";
			this.cmdOk.UseVisualStyleBackColor = true;
			this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
			// 
			// toolTip
			// 
			this.toolTip.AutoPopDelay = 30000;
			this.toolTip.InitialDelay = 500;
			this.toolTip.IsBalloon = true;
			this.toolTip.ReshowDelay = 100;
			// 
			// alarmGrid
			// 
			this.alarmGrid.AllowDelete = true;
			this.alarmGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.alarmGrid.ClipCurrentCellSelection = false;
			this.alarmGrid.DataRowTemplate = this.dataRowTemplate1;
			this.alarmGrid.DeletedRowColor = System.Drawing.Color.Empty;
			this.alarmGrid.ExpandToFitColumn = null;
			this.alarmGrid.FillDataMemberDelegate = null;
			this.alarmGrid.FixedHeaderRows.Add(this.columnManagerRow1);
			this.alarmGrid.InsertedRowColor = System.Drawing.Color.Empty;
			this.alarmGrid.Location = new System.Drawing.Point(24, 45);
			this.alarmGrid.Name = "alarmGrid";
			this.alarmGrid.ResetDataMemberDelegate = null;
			this.alarmGrid.ShowFocusRectangle = false;
			this.alarmGrid.Size = new System.Drawing.Size(536, 203);
			this.alarmGrid.TabIndex = 14;
			this.alarmGrid.UIStyle = Xceed.UI.UIStyle.WindowsClassic;
			this.alarmGrid.UIVirtualizationMode = Xceed.Grid.UIVirtualizationMode.Cells;
			this.alarmGrid.UpdateDataMemberDelegate = null;
			this.alarmGrid.UpdatedRowColor = System.Drawing.Color.Empty;
			// 
			// txtTrailingDebounceTimer
			// 
			this.txtTrailingDebounceTimer.Location = new System.Drawing.Point(433, 70);
			this.txtTrailingDebounceTimer.Name = "txtTrailingDebounceTimer";
			this.txtTrailingDebounceTimer.Size = new System.Drawing.Size(127, 20);
			this.txtTrailingDebounceTimer.TabIndex = 21;
			this.txtTrailingDebounceTimer.Text = "0";
			this.txtTrailingDebounceTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip.SetToolTip(this.txtTrailingDebounceTimer, "Amount of time (in milliseconds) that the gauge point must be out of alarm before" +
					" the alarm is ended.");
			// 
			// lblTrailingDebounceTimer
			// 
			this.lblTrailingDebounceTimer.AutoSize = true;
			this.lblTrailingDebounceTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTrailingDebounceTimer.Location = new System.Drawing.Point(293, 74);
			this.lblTrailingDebounceTimer.Name = "lblTrailingDebounceTimer";
			this.lblTrailingDebounceTimer.Size = new System.Drawing.Size(111, 13);
			this.lblTrailingDebounceTimer.TabIndex = 22;
			this.lblTrailingDebounceTimer.Text = "Trailing Debounce";
			// 
			// AlarmPointEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(598, 539);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOk);
			this.Controls.Add(this.grpAlarmAnnunciation);
			this.Controls.Add(this.grpEngineering);
			this.Controls.Add(this.grpGeneral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AlarmPointEdit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Alarm Point";
			this.Load += new System.EventHandler(this.AlarmPointEdit_Load);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AlarmPointEdit_KeyPress);
			this.grpGeneral.ResumeLayout(false);
			this.grpGeneral.PerformLayout();
			this.grpEngineering.ResumeLayout(false);
			this.grpEngineering.PerformLayout();
			this.grpAlarmAnnunciation.ResumeLayout(false);
			this.grpAlarmAnnunciation.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.alarmGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataRowTemplate1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.columnManagerRow1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grpGeneral;
		private System.Windows.Forms.Label lblAlarmPriority;
		private System.Windows.Forms.ComboBox cboAlarmType;
		private System.Windows.Forms.Label lblAlarmType;
		private System.Windows.Forms.ComboBox cboAlarmMonitorType;
		private System.Windows.Forms.Label lblAlarmMonitorType;
		private System.Windows.Forms.CheckBox chkEnable;
		private System.Windows.Forms.TextBox txtDisplayName;
		private System.Windows.Forms.Label lblEnabled;
		private System.Windows.Forms.Label lblDisplayName;
		private System.Windows.Forms.TextBox txtAlarmText;
		private System.Windows.Forms.Label lblAlarmText;
		private System.Windows.Forms.ComboBox cboAlarmPriority;
		private System.Windows.Forms.GroupBox grpEngineering;
		private System.Windows.Forms.ComboBox cboComparator;
		private System.Windows.Forms.Label lblAutoClearEnable;
		private System.Windows.Forms.TextBox txtAlarmDeadband;
		private System.Windows.Forms.Label lblAlarmDeadband;
		private System.Windows.Forms.TextBox txtDebounceTimer;
		private System.Windows.Forms.Label lblComparator;
		private System.Windows.Forms.Label lblDebounceTimer;
		private System.Windows.Forms.Label lblLimit;
		private System.Windows.Forms.TextBox txtLimit;
		private System.Windows.Forms.CheckBox chkAutoClear;
		private System.Windows.Forms.GroupBox grpAlarmAnnunciation;
		private System.Windows.Forms.ComboBox cboAlarmAnnunciation;
		private System.Windows.Forms.Label lblAlarmAnnunciation;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOk;
		private CustomXceedGridControl alarmGrid;
		private Xceed.Grid.DataRow dataRowTemplate1;
		private Xceed.Grid.ColumnManagerRow columnManagerRow1;
		private System.Windows.Forms.Button cmdAddAlarmAnnunciation;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.TextBox txtTrailingDebounceTimer;
		private System.Windows.Forms.Label lblTrailingDebounceTimer;
	}
}