namespace TLIConfiguration
{
	partial class EquipmentUnitEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EquipmentUnitEdit));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpEquipmentUnit = new System.Windows.Forms.TabPage();
            this.grpStopGaugeAnnunciation = new System.Windows.Forms.GroupBox();
            this.cmdAddAlarmAnnunciation = new System.Windows.Forms.Button();
            this.alarmGrid = new CustomXceedGridControl();
            this.dataRow1 = new Xceed.Grid.DataRow();
            this.columnManagerRow2 = new Xceed.Grid.ColumnManagerRow();
            this.cboAlarmAnnunciation = new System.Windows.Forms.ComboBox();
            this.lblAlarmAnnunciation = new System.Windows.Forms.Label();
            this.grpMTDE = new System.Windows.Forms.GroupBox();
            this.chkMTDEFuelTank = new System.Windows.Forms.CheckBox();
            this.lblMTDEFuelTank = new System.Windows.Forms.Label();
            this.txtMTDEName = new System.Windows.Forms.TextBox();
            this.lblMTDEName = new System.Windows.Forms.Label();
            this.chkMTDEEnabled = new System.Windows.Forms.CheckBox();
            this.lblMTDEEnabled = new System.Windows.Forms.Label();
            this.txtMTDEOrder = new System.Windows.Forms.TextBox();
            this.lblMTDEOrder = new System.Windows.Forms.Label();
            this.grpIndependentAlarm = new System.Windows.Forms.GroupBox();
            this.chkIndependentHighLevelAlarm = new System.Windows.Forms.CheckBox();
            this.lblIndependentHighLevelAlarmPercentage = new System.Windows.Forms.Label();
            this.txtIndependentHighLevelAlarmPercentage = new System.Windows.Forms.TextBox();
            this.lblIndependentHighLevelAlarm = new System.Windows.Forms.Label();
            this.txtIndependentOverfillAlarmPercentage = new System.Windows.Forms.TextBox();
            this.lblIndependentOverfillAlarmPercentage = new System.Windows.Forms.Label();
            this.chkIndependentOverfillAlarm = new System.Windows.Forms.CheckBox();
            this.lblIndependentOverfillAlarm = new System.Windows.Forms.Label();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.chkExportEnable = new System.Windows.Forms.CheckBox();
            this.lblExportOrder = new System.Windows.Forms.Label();
            this.txtExportOrder = new System.Windows.Forms.TextBox();
            this.lblExportEnable = new System.Windows.Forms.Label();
            this.txtSummaryLocationY = new System.Windows.Forms.TextBox();
            this.lblSummaryLocationY = new System.Windows.Forms.Label();
            this.lblSummaryLocationX = new System.Windows.Forms.Label();
            this.txtSummaryLocationX = new System.Windows.Forms.TextBox();
            this.lblSummaryLocation = new System.Windows.Forms.Label();
            this.cboEquipmentLocation = new System.Windows.Forms.ComboBox();
            this.lblEquipmentLocation = new System.Windows.Forms.Label();
            this.cboEquipmentType = new System.Windows.Forms.ComboBox();
            this.lblEquipmentType = new System.Windows.Forms.Label();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.lblEnabled = new System.Windows.Forms.Label();
            this.txtEquipment = new System.Windows.Forms.TextBox();
            this.lblEquipment = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOk = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.mtdeAddrDropdown = new System.Windows.Forms.ComboBox();
            this.tabControl.SuspendLayout();
            this.tpEquipmentUnit.SuspendLayout();
            this.grpStopGaugeAnnunciation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alarmGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataRow1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnManagerRow2)).BeginInit();
            this.grpMTDE.SuspendLayout();
            this.grpIndependentAlarm.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpEquipmentUnit);
            this.tabControl.Location = new System.Drawing.Point(0, 1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(578, 590);
            this.tabControl.TabIndex = 0;
            // 
            // tpEquipmentUnit
            // 
            this.tpEquipmentUnit.Controls.Add(this.grpStopGaugeAnnunciation);
            this.tpEquipmentUnit.Controls.Add(this.grpMTDE);
            this.tpEquipmentUnit.Controls.Add(this.grpIndependentAlarm);
            this.tpEquipmentUnit.Controls.Add(this.grpGeneral);
            this.tpEquipmentUnit.Location = new System.Drawing.Point(4, 22);
            this.tpEquipmentUnit.Name = "tpEquipmentUnit";
            this.tpEquipmentUnit.Padding = new System.Windows.Forms.Padding(3);
            this.tpEquipmentUnit.Size = new System.Drawing.Size(570, 564);
            this.tpEquipmentUnit.TabIndex = 0;
            this.tpEquipmentUnit.Text = "Equipment Unit";
            this.tpEquipmentUnit.UseVisualStyleBackColor = true;
            // 
            // grpStopGaugeAnnunciation
            // 
            this.grpStopGaugeAnnunciation.Controls.Add(this.cmdAddAlarmAnnunciation);
            this.grpStopGaugeAnnunciation.Controls.Add(this.alarmGrid);
            this.grpStopGaugeAnnunciation.Controls.Add(this.cboAlarmAnnunciation);
            this.grpStopGaugeAnnunciation.Controls.Add(this.lblAlarmAnnunciation);
            this.grpStopGaugeAnnunciation.Location = new System.Drawing.Point(9, 302);
            this.grpStopGaugeAnnunciation.Name = "grpStopGaugeAnnunciation";
            this.grpStopGaugeAnnunciation.Size = new System.Drawing.Size(550, 254);
            this.grpStopGaugeAnnunciation.TabIndex = 4;
            this.grpStopGaugeAnnunciation.TabStop = false;
            this.grpStopGaugeAnnunciation.Text = "Stop Gauge Annunciations";
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
            // alarmGrid
            // 
            this.alarmGrid.AllowDelete = true;
            this.alarmGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.alarmGrid.ClipCurrentCellSelection = false;
            this.alarmGrid.DataRowTemplate = this.dataRow1;
            this.alarmGrid.DeletedRowColor = System.Drawing.Color.Empty;
            this.alarmGrid.ExpandToFitColumn = null;
            this.alarmGrid.FillDataMemberDelegate = null;
            this.alarmGrid.FixedHeaderRows.Add(this.columnManagerRow2);
            this.alarmGrid.InsertedRowColor = System.Drawing.Color.Empty;
            this.alarmGrid.Location = new System.Drawing.Point(24, 45);
            this.alarmGrid.Name = "alarmGrid";
            this.alarmGrid.ResetDataMemberDelegate = null;
            this.alarmGrid.ShowFocusRectangle = false;
            this.alarmGrid.Size = new System.Drawing.Size(520, 203);
            this.alarmGrid.TabIndex = 2;
            this.alarmGrid.UIStyle = Xceed.UI.UIStyle.WindowsClassic;
            this.alarmGrid.UIVirtualizationMode = Xceed.Grid.UIVirtualizationMode.Cells;
            this.alarmGrid.UpdateDataMemberDelegate = null;
            this.alarmGrid.UpdatedRowColor = System.Drawing.Color.Empty;
            // 
            // cboAlarmAnnunciation
            // 
            this.cboAlarmAnnunciation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlarmAnnunciation.FormattingEnabled = true;
            this.cboAlarmAnnunciation.Location = new System.Drawing.Point(145, 18);
            this.cboAlarmAnnunciation.Name = "cboAlarmAnnunciation";
            this.cboAlarmAnnunciation.Size = new System.Drawing.Size(127, 21);
            this.cboAlarmAnnunciation.TabIndex = 0;
            this.toolTip.SetToolTip(this.cboAlarmAnnunciation, "Select alarm Annunciations to be used when the stop gauge is active.");
            // 
            // lblAlarmAnnunciation
            // 
            this.lblAlarmAnnunciation.AutoSize = true;
            this.lblAlarmAnnunciation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarmAnnunciation.Location = new System.Drawing.Point(21, 22);
            this.lblAlarmAnnunciation.Name = "lblAlarmAnnunciation";
            this.lblAlarmAnnunciation.Size = new System.Drawing.Size(81, 13);
            this.lblAlarmAnnunciation.TabIndex = 13;
            this.lblAlarmAnnunciation.Text = "Annunciation";
            // 
            // grpMTDE
            // 
            this.grpMTDE.Controls.Add(this.mtdeAddrDropdown);
            this.grpMTDE.Controls.Add(this.label1);
            this.grpMTDE.Controls.Add(this.chkMTDEFuelTank);
            this.grpMTDE.Controls.Add(this.lblMTDEFuelTank);
            this.grpMTDE.Controls.Add(this.txtMTDEName);
            this.grpMTDE.Controls.Add(this.lblMTDEName);
            this.grpMTDE.Controls.Add(this.chkMTDEEnabled);
            this.grpMTDE.Controls.Add(this.lblMTDEEnabled);
            this.grpMTDE.Controls.Add(this.txtMTDEOrder);
            this.grpMTDE.Controls.Add(this.lblMTDEOrder);
            this.grpMTDE.Location = new System.Drawing.Point(11, 220);
            this.grpMTDE.Name = "grpMTDE";
            this.grpMTDE.Size = new System.Drawing.Size(549, 76);
            this.grpMTDE.TabIndex = 3;
            this.grpMTDE.TabStop = false;
            this.grpMTDE.Text = "MTDE";
            // 
            // chkMTDEFuelTank
            // 
            this.chkMTDEFuelTank.AutoSize = true;
            this.chkMTDEFuelTank.Location = new System.Drawing.Point(330, 21);
            this.chkMTDEFuelTank.Name = "chkMTDEFuelTank";
            this.chkMTDEFuelTank.Size = new System.Drawing.Size(15, 14);
            this.chkMTDEFuelTank.TabIndex = 24;
            this.toolTip.SetToolTip(this.chkMTDEFuelTank, "Used to flag a tank as a fuel tank on the MTDE.");
            this.chkMTDEFuelTank.UseVisualStyleBackColor = true;
            // 
            // lblMTDEFuelTank
            // 
            this.lblMTDEFuelTank.AutoSize = true;
            this.lblMTDEFuelTank.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMTDEFuelTank.Location = new System.Drawing.Point(236, 22);
            this.lblMTDEFuelTank.Name = "lblMTDEFuelTank";
            this.lblMTDEFuelTank.Size = new System.Drawing.Size(64, 13);
            this.lblMTDEFuelTank.TabIndex = 23;
            this.lblMTDEFuelTank.Text = "Fuel Tank";
            // 
            // txtMTDEName
            // 
            this.txtMTDEName.Location = new System.Drawing.Point(145, 41);
            this.txtMTDEName.Name = "txtMTDEName";
            this.txtMTDEName.Size = new System.Drawing.Size(48, 20);
            this.txtMTDEName.TabIndex = 1;
            this.txtMTDEName.Text = "1";
            this.txtMTDEName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.txtMTDEName, "Tank number used to identify the tank in the MTDE display. \r\n\r\nNote:  Port, Starb" +
        "oard, Center, and Ballast designations will all be included based on the Vessel " +
        "Location value.");
            // 
            // lblMTDEName
            // 
            this.lblMTDEName.AutoSize = true;
            this.lblMTDEName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMTDEName.Location = new System.Drawing.Point(21, 45);
            this.lblMTDEName.Name = "lblMTDEName";
            this.lblMTDEName.Size = new System.Drawing.Size(83, 13);
            this.lblMTDEName.TabIndex = 22;
            this.lblMTDEName.Text = "Tank Number";
            // 
            // chkMTDEEnabled
            // 
            this.chkMTDEEnabled.AutoSize = true;
            this.chkMTDEEnabled.Location = new System.Drawing.Point(145, 21);
            this.chkMTDEEnabled.Name = "chkMTDEEnabled";
            this.chkMTDEEnabled.Size = new System.Drawing.Size(15, 14);
            this.chkMTDEEnabled.TabIndex = 0;
            this.toolTip.SetToolTip(this.chkMTDEEnabled, "Includes the tank in the list of tanks displayed on the MTDE.");
            this.chkMTDEEnabled.UseVisualStyleBackColor = true;
            this.chkMTDEEnabled.CheckedChanged += new System.EventHandler(this.chkMTDEEnabled_CheckedChanged);
            // 
            // lblMTDEEnabled
            // 
            this.lblMTDEEnabled.AutoSize = true;
            this.lblMTDEEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMTDEEnabled.Location = new System.Drawing.Point(21, 22);
            this.lblMTDEEnabled.Name = "lblMTDEEnabled";
            this.lblMTDEEnabled.Size = new System.Drawing.Size(53, 13);
            this.lblMTDEEnabled.TabIndex = 20;
            this.lblMTDEEnabled.Text = "Enabled";
            // 
            // txtMTDEOrder
            // 
            this.txtMTDEOrder.Location = new System.Drawing.Point(330, 42);
            this.txtMTDEOrder.Name = "txtMTDEOrder";
            this.txtMTDEOrder.Size = new System.Drawing.Size(48, 20);
            this.txtMTDEOrder.TabIndex = 2;
            this.txtMTDEOrder.Text = "1";
            this.txtMTDEOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.txtMTDEOrder, "Ordinal value indicating the placement of the tank in the MTDE display order.");
            // 
            // lblMTDEOrder
            // 
            this.lblMTDEOrder.AutoSize = true;
            this.lblMTDEOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMTDEOrder.Location = new System.Drawing.Point(235, 45);
            this.lblMTDEOrder.Name = "lblMTDEOrder";
            this.lblMTDEOrder.Size = new System.Drawing.Size(38, 13);
            this.lblMTDEOrder.TabIndex = 18;
            this.lblMTDEOrder.Text = "Order";
            // 
            // grpIndependentAlarm
            // 
            this.grpIndependentAlarm.Controls.Add(this.chkIndependentHighLevelAlarm);
            this.grpIndependentAlarm.Controls.Add(this.lblIndependentHighLevelAlarmPercentage);
            this.grpIndependentAlarm.Controls.Add(this.txtIndependentHighLevelAlarmPercentage);
            this.grpIndependentAlarm.Controls.Add(this.lblIndependentHighLevelAlarm);
            this.grpIndependentAlarm.Controls.Add(this.txtIndependentOverfillAlarmPercentage);
            this.grpIndependentAlarm.Controls.Add(this.lblIndependentOverfillAlarmPercentage);
            this.grpIndependentAlarm.Controls.Add(this.chkIndependentOverfillAlarm);
            this.grpIndependentAlarm.Controls.Add(this.lblIndependentOverfillAlarm);
            this.grpIndependentAlarm.Location = new System.Drawing.Point(11, 138);
            this.grpIndependentAlarm.Name = "grpIndependentAlarm";
            this.grpIndependentAlarm.Size = new System.Drawing.Size(549, 76);
            this.grpIndependentAlarm.TabIndex = 2;
            this.grpIndependentAlarm.TabStop = false;
            this.grpIndependentAlarm.Text = "Independent Alarms";
            // 
            // chkIndependentHighLevelAlarm
            // 
            this.chkIndependentHighLevelAlarm.AutoSize = true;
            this.chkIndependentHighLevelAlarm.Location = new System.Drawing.Point(145, 47);
            this.chkIndependentHighLevelAlarm.Name = "chkIndependentHighLevelAlarm";
            this.chkIndependentHighLevelAlarm.Size = new System.Drawing.Size(15, 14);
            this.chkIndependentHighLevelAlarm.TabIndex = 2;
            this.toolTip.SetToolTip(this.chkIndependentHighLevelAlarm, "Indicates that an independent high level alarm sensor is being used for alarming." +
        "");
            this.chkIndependentHighLevelAlarm.UseVisualStyleBackColor = true;
            this.chkIndependentHighLevelAlarm.CheckedChanged += new System.EventHandler(this.chkIndependentHighLevelAlarm_CheckedChanged);
            // 
            // lblIndependentHighLevelAlarmPercentage
            // 
            this.lblIndependentHighLevelAlarmPercentage.AutoSize = true;
            this.lblIndependentHighLevelAlarmPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndependentHighLevelAlarmPercentage.Location = new System.Drawing.Point(289, 48);
            this.lblIndependentHighLevelAlarmPercentage.Name = "lblIndependentHighLevelAlarmPercentage";
            this.lblIndependentHighLevelAlarmPercentage.Size = new System.Drawing.Size(117, 13);
            this.lblIndependentHighLevelAlarmPercentage.TabIndex = 22;
            this.lblIndependentHighLevelAlarmPercentage.Text = "Volume Percentage";
            // 
            // txtIndependentHighLevelAlarmPercentage
            // 
            this.txtIndependentHighLevelAlarmPercentage.Location = new System.Drawing.Point(412, 44);
            this.txtIndependentHighLevelAlarmPercentage.Name = "txtIndependentHighLevelAlarmPercentage";
            this.txtIndependentHighLevelAlarmPercentage.Size = new System.Drawing.Size(127, 20);
            this.txtIndependentHighLevelAlarmPercentage.TabIndex = 3;
            this.txtIndependentHighLevelAlarmPercentage.Text = "95";
            this.txtIndependentHighLevelAlarmPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.txtIndependentHighLevelAlarmPercentage, "Percentage of tank volume at which the high level alarm will be sounded.");
            // 
            // lblIndependentHighLevelAlarm
            // 
            this.lblIndependentHighLevelAlarm.AutoSize = true;
            this.lblIndependentHighLevelAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndependentHighLevelAlarm.Location = new System.Drawing.Point(21, 48);
            this.lblIndependentHighLevelAlarm.Name = "lblIndependentHighLevelAlarm";
            this.lblIndependentHighLevelAlarm.Size = new System.Drawing.Size(103, 13);
            this.lblIndependentHighLevelAlarm.TabIndex = 20;
            this.lblIndependentHighLevelAlarm.Text = "High Level Alarm";
            // 
            // txtIndependentOverfillAlarmPercentage
            // 
            this.txtIndependentOverfillAlarmPercentage.Location = new System.Drawing.Point(412, 18);
            this.txtIndependentOverfillAlarmPercentage.Name = "txtIndependentOverfillAlarmPercentage";
            this.txtIndependentOverfillAlarmPercentage.Size = new System.Drawing.Size(127, 20);
            this.txtIndependentOverfillAlarmPercentage.TabIndex = 1;
            this.txtIndependentOverfillAlarmPercentage.Text = "98";
            this.txtIndependentOverfillAlarmPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.txtIndependentOverfillAlarmPercentage, "Percentage of tank volume at which the overfill alarm will be sounded.");
            // 
            // lblIndependentOverfillAlarmPercentage
            // 
            this.lblIndependentOverfillAlarmPercentage.AutoSize = true;
            this.lblIndependentOverfillAlarmPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndependentOverfillAlarmPercentage.Location = new System.Drawing.Point(288, 22);
            this.lblIndependentOverfillAlarmPercentage.Name = "lblIndependentOverfillAlarmPercentage";
            this.lblIndependentOverfillAlarmPercentage.Size = new System.Drawing.Size(117, 13);
            this.lblIndependentOverfillAlarmPercentage.TabIndex = 18;
            this.lblIndependentOverfillAlarmPercentage.Text = "Volume Percentage";
            // 
            // chkIndependentOverfillAlarm
            // 
            this.chkIndependentOverfillAlarm.AutoSize = true;
            this.chkIndependentOverfillAlarm.Location = new System.Drawing.Point(145, 21);
            this.chkIndependentOverfillAlarm.Name = "chkIndependentOverfillAlarm";
            this.chkIndependentOverfillAlarm.Size = new System.Drawing.Size(15, 14);
            this.chkIndependentOverfillAlarm.TabIndex = 0;
            this.toolTip.SetToolTip(this.chkIndependentOverfillAlarm, "Indicates that an independent overfill alarm sensor is being used for alarming.");
            this.chkIndependentOverfillAlarm.UseVisualStyleBackColor = true;
            this.chkIndependentOverfillAlarm.CheckedChanged += new System.EventHandler(this.chkIndependentOverfillAlarm_CheckedChanged);
            // 
            // lblIndependentOverfillAlarm
            // 
            this.lblIndependentOverfillAlarm.AutoSize = true;
            this.lblIndependentOverfillAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndependentOverfillAlarm.Location = new System.Drawing.Point(21, 22);
            this.lblIndependentOverfillAlarm.Name = "lblIndependentOverfillAlarm";
            this.lblIndependentOverfillAlarm.Size = new System.Drawing.Size(82, 13);
            this.lblIndependentOverfillAlarm.TabIndex = 12;
            this.lblIndependentOverfillAlarm.Text = "Overfill Alarm";
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.chkExportEnable);
            this.grpGeneral.Controls.Add(this.lblExportOrder);
            this.grpGeneral.Controls.Add(this.txtExportOrder);
            this.grpGeneral.Controls.Add(this.lblExportEnable);
            this.grpGeneral.Controls.Add(this.txtSummaryLocationY);
            this.grpGeneral.Controls.Add(this.lblSummaryLocationY);
            this.grpGeneral.Controls.Add(this.lblSummaryLocationX);
            this.grpGeneral.Controls.Add(this.txtSummaryLocationX);
            this.grpGeneral.Controls.Add(this.lblSummaryLocation);
            this.grpGeneral.Controls.Add(this.cboEquipmentLocation);
            this.grpGeneral.Controls.Add(this.lblEquipmentLocation);
            this.grpGeneral.Controls.Add(this.cboEquipmentType);
            this.grpGeneral.Controls.Add(this.lblEquipmentType);
            this.grpGeneral.Controls.Add(this.chkEnable);
            this.grpGeneral.Controls.Add(this.lblEnabled);
            this.grpGeneral.Controls.Add(this.txtEquipment);
            this.grpGeneral.Controls.Add(this.lblEquipment);
            this.grpGeneral.Location = new System.Drawing.Point(10, 6);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(549, 126);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            // 
            // chkExportEnable
            // 
            this.chkExportEnable.AutoSize = true;
            this.chkExportEnable.Location = new System.Drawing.Point(145, 73);
            this.chkExportEnable.Name = "chkExportEnable";
            this.chkExportEnable.Size = new System.Drawing.Size(15, 14);
            this.chkExportEnable.TabIndex = 7;
            this.toolTip.SetToolTip(this.chkExportEnable, "Enables ASCII export of gauging data for third-party applications.");
            this.chkExportEnable.UseVisualStyleBackColor = true;
            this.chkExportEnable.CheckedChanged += new System.EventHandler(this.chkExportEnable_CheckedChanged);
            // 
            // lblExportOrder
            // 
            this.lblExportOrder.AutoSize = true;
            this.lblExportOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExportOrder.Location = new System.Drawing.Point(289, 74);
            this.lblExportOrder.Name = "lblExportOrder";
            this.lblExportOrder.Size = new System.Drawing.Size(78, 13);
            this.lblExportOrder.TabIndex = 14;
            this.lblExportOrder.Text = "Export Order";
            // 
            // txtExportOrder
            // 
            this.txtExportOrder.Location = new System.Drawing.Point(412, 70);
            this.txtExportOrder.Name = "txtExportOrder";
            this.txtExportOrder.Size = new System.Drawing.Size(127, 20);
            this.txtExportOrder.TabIndex = 8;
            this.txtExportOrder.Text = "1";
            this.txtExportOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.txtExportOrder, "Ordinal value indicating the placement of the gauging data in the ASCII export.");
            // 
            // lblExportEnable
            // 
            this.lblExportEnable.AutoSize = true;
            this.lblExportEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExportEnable.Location = new System.Drawing.Point(22, 74);
            this.lblExportEnable.Name = "lblExportEnable";
            this.lblExportEnable.Size = new System.Drawing.Size(93, 13);
            this.lblExportEnable.TabIndex = 12;
            this.lblExportEnable.Text = "Export Enabled";
            // 
            // txtSummaryLocationY
            // 
            this.txtSummaryLocationY.Location = new System.Drawing.Point(223, 97);
            this.txtSummaryLocationY.Name = "txtSummaryLocationY";
            this.txtSummaryLocationY.Size = new System.Drawing.Size(27, 20);
            this.txtSummaryLocationY.TabIndex = 6;
            this.txtSummaryLocationY.Text = "0";
            this.txtSummaryLocationY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSummaryLocationY
            // 
            this.lblSummaryLocationY.AutoSize = true;
            this.lblSummaryLocationY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummaryLocationY.Location = new System.Drawing.Point(201, 101);
            this.lblSummaryLocationY.Name = "lblSummaryLocationY";
            this.lblSummaryLocationY.Size = new System.Drawing.Size(19, 13);
            this.lblSummaryLocationY.TabIndex = 11;
            this.lblSummaryLocationY.Text = "Y:";
            // 
            // lblSummaryLocationX
            // 
            this.lblSummaryLocationX.AutoSize = true;
            this.lblSummaryLocationX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummaryLocationX.Location = new System.Drawing.Point(145, 101);
            this.lblSummaryLocationX.Name = "lblSummaryLocationX";
            this.lblSummaryLocationX.Size = new System.Drawing.Size(19, 13);
            this.lblSummaryLocationX.TabIndex = 7;
            this.lblSummaryLocationX.Text = "X:";
            // 
            // txtSummaryLocationX
            // 
            this.txtSummaryLocationX.Location = new System.Drawing.Point(167, 97);
            this.txtSummaryLocationX.Name = "txtSummaryLocationX";
            this.txtSummaryLocationX.Size = new System.Drawing.Size(27, 20);
            this.txtSummaryLocationX.TabIndex = 5;
            this.txtSummaryLocationX.Text = "0";
            this.txtSummaryLocationX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSummaryLocation
            // 
            this.lblSummaryLocation.AutoSize = true;
            this.lblSummaryLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummaryLocation.Location = new System.Drawing.Point(22, 101);
            this.lblSummaryLocation.Name = "lblSummaryLocation";
            this.lblSummaryLocation.Size = new System.Drawing.Size(110, 13);
            this.lblSummaryLocation.TabIndex = 8;
            this.lblSummaryLocation.Text = "Summary Location";
            // 
            // cboEquipmentLocation
            // 
            this.cboEquipmentLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEquipmentLocation.FormattingEnabled = true;
            this.cboEquipmentLocation.Location = new System.Drawing.Point(412, 43);
            this.cboEquipmentLocation.Name = "cboEquipmentLocation";
            this.cboEquipmentLocation.Size = new System.Drawing.Size(127, 21);
            this.cboEquipmentLocation.TabIndex = 3;
            this.toolTip.SetToolTip(this.cboEquipmentLocation, "Relative location of the equipment unit on the vessel.  Fore, Aft, Port, Starboar" +
        "d, Center.");
            this.cboEquipmentLocation.SelectedIndexChanged += new System.EventHandler(this.cboEquipmentLocation_SelectedIndexChanged);
            // 
            // lblEquipmentLocation
            // 
            this.lblEquipmentLocation.AutoSize = true;
            this.lblEquipmentLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipmentLocation.Location = new System.Drawing.Point(289, 47);
            this.lblEquipmentLocation.Name = "lblEquipmentLocation";
            this.lblEquipmentLocation.Size = new System.Drawing.Size(97, 13);
            this.lblEquipmentLocation.TabIndex = 5;
            this.lblEquipmentLocation.Text = "Vessel Location";
            // 
            // cboEquipmentType
            // 
            this.cboEquipmentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEquipmentType.FormattingEnabled = true;
            this.cboEquipmentType.Location = new System.Drawing.Point(145, 17);
            this.cboEquipmentType.Name = "cboEquipmentType";
            this.cboEquipmentType.Size = new System.Drawing.Size(127, 21);
            this.cboEquipmentType.TabIndex = 2;
            this.toolTip.SetToolTip(this.cboEquipmentType, "Ballast, Cargo, Draft, Fuel / Aux, List, Manifold, Trim.");
            this.cboEquipmentType.SelectedIndexChanged += new System.EventHandler(this.cboEquipmentType_SelectedIndexChanged);
            // 
            // lblEquipmentType
            // 
            this.lblEquipmentType.AutoSize = true;
            this.lblEquipmentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipmentType.Location = new System.Drawing.Point(22, 21);
            this.lblEquipmentType.Name = "lblEquipmentType";
            this.lblEquipmentType.Size = new System.Drawing.Size(98, 13);
            this.lblEquipmentType.TabIndex = 3;
            this.lblEquipmentType.Text = "Equipment Type";
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(412, 20);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(15, 14);
            this.chkEnable.TabIndex = 1;
            this.toolTip.SetToolTip(this.chkEnable, "Enables the equipment unit in the vessel configuration.");
            this.chkEnable.UseVisualStyleBackColor = true;
            this.chkEnable.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
            // 
            // lblEnabled
            // 
            this.lblEnabled.AutoSize = true;
            this.lblEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnabled.Location = new System.Drawing.Point(289, 21);
            this.lblEnabled.Name = "lblEnabled";
            this.lblEnabled.Size = new System.Drawing.Size(53, 13);
            this.lblEnabled.TabIndex = 2;
            this.lblEnabled.Text = "Enabled";
            // 
            // txtEquipment
            // 
            this.txtEquipment.Location = new System.Drawing.Point(145, 43);
            this.txtEquipment.MaxLength = 12;
            this.txtEquipment.Name = "txtEquipment";
            this.txtEquipment.Size = new System.Drawing.Size(127, 20);
            this.txtEquipment.TabIndex = 0;
            this.toolTip.SetToolTip(this.txtEquipment, "Equipment (tank) name.");
            // 
            // lblEquipment
            // 
            this.lblEquipment.AutoSize = true;
            this.lblEquipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipment.Location = new System.Drawing.Point(22, 47);
            this.lblEquipment.Name = "lblEquipment";
            this.lblEquipment.Size = new System.Drawing.Size(39, 13);
            this.lblEquipment.TabIndex = 1;
            this.lblEquipment.Text = "Name";
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(487, 592);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(406, 592);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(75, 23);
            this.cmdOk.TabIndex = 0;
            this.cmdOk.Text = "Ok";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.CmdOk_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "csv";
            this.openFileDialog.FileName = "SoundingTable";
            this.openFileDialog.Filter = "Comma Delimited CSV Files |*.csv";
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(409, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Address";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // mtdeAddrDropdown
            // 
            this.mtdeAddrDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mtdeAddrDropdown.FormattingEnabled = true;
            this.mtdeAddrDropdown.Location = new System.Drawing.Point(490, 19);
            this.mtdeAddrDropdown.Name = "mtdeAddrDropdown";
            this.mtdeAddrDropdown.Size = new System.Drawing.Size(48, 21);
            this.mtdeAddrDropdown.TabIndex = 15;
            this.toolTip.SetToolTip(this.mtdeAddrDropdown, "Relative location of the equipment unit on the vessel.  Fore, Aft, Port, Starboar" +
        "d, Center.");
            // 
            // EquipmentUnitEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 621);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EquipmentUnitEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Equipment Unit";
            this.Load += new System.EventHandler(this.EquipmentUnitEdit_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EquipmentUnitEdit_KeyPress);
            this.tabControl.ResumeLayout(false);
            this.tpEquipmentUnit.ResumeLayout(false);
            this.grpStopGaugeAnnunciation.ResumeLayout(false);
            this.grpStopGaugeAnnunciation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alarmGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataRow1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnManagerRow2)).EndInit();
            this.grpMTDE.ResumeLayout(false);
            this.grpMTDE.PerformLayout();
            this.grpIndependentAlarm.ResumeLayout(false);
            this.grpIndependentAlarm.PerformLayout();
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tpEquipmentUnit;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOk;
		private System.Windows.Forms.GroupBox grpGeneral;
		private System.Windows.Forms.Label lblEquipment;
		private System.Windows.Forms.TextBox txtEquipment;
		private System.Windows.Forms.Label lblEnabled;
		private System.Windows.Forms.CheckBox chkEnable;
		private System.Windows.Forms.Label lblEquipmentType;
		private System.Windows.Forms.ComboBox cboEquipmentType;
		private System.Windows.Forms.ComboBox cboEquipmentLocation;
		private System.Windows.Forms.Label lblEquipmentLocation;
		private System.Windows.Forms.Label lblSummaryLocationX;
		private System.Windows.Forms.Label lblSummaryLocation;
		private System.Windows.Forms.TextBox txtSummaryLocationY;
		private System.Windows.Forms.TextBox txtSummaryLocationX;
		private System.Windows.Forms.Label lblSummaryLocationY;
		private System.Windows.Forms.GroupBox grpIndependentAlarm;
		private System.Windows.Forms.Label lblIndependentOverfillAlarm;
		private System.Windows.Forms.TextBox txtIndependentOverfillAlarmPercentage;
		private System.Windows.Forms.Label lblIndependentOverfillAlarmPercentage;
		private System.Windows.Forms.CheckBox chkIndependentOverfillAlarm;
		private System.Windows.Forms.Label lblIndependentHighLevelAlarmPercentage;
		private System.Windows.Forms.TextBox txtIndependentHighLevelAlarmPercentage;
		private System.Windows.Forms.Label lblIndependentHighLevelAlarm;
		private System.Windows.Forms.GroupBox grpMTDE;
		private System.Windows.Forms.TextBox txtMTDEOrder;
		private System.Windows.Forms.Label lblMTDEOrder;
		private System.Windows.Forms.CheckBox chkIndependentHighLevelAlarm;
		private System.Windows.Forms.Label lblMTDEEnabled;
		private System.Windows.Forms.CheckBox chkMTDEEnabled;
		private System.Windows.Forms.GroupBox grpStopGaugeAnnunciation;
		private System.Windows.Forms.Button cmdAddAlarmAnnunciation;
		private CustomXceedGridControl alarmGrid;
		private Xceed.Grid.DataRow dataRow1;
		private Xceed.Grid.ColumnManagerRow columnManagerRow2;
		private System.Windows.Forms.ComboBox cboAlarmAnnunciation;
		private System.Windows.Forms.Label lblAlarmAnnunciation;
		private System.Windows.Forms.TextBox txtMTDEName;
		private System.Windows.Forms.Label lblMTDEName;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.CheckBox chkExportEnable;
		private System.Windows.Forms.Label lblExportOrder;
		private System.Windows.Forms.TextBox txtExportOrder;
		private System.Windows.Forms.Label lblExportEnable;
		private System.Windows.Forms.CheckBox chkMTDEFuelTank;
		private System.Windows.Forms.Label lblMTDEFuelTank;
		private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox mtdeAddrDropdown;
    }
}