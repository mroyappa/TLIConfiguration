namespace TLIConfiguration
{
	partial class VesselPropertiesEdit
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VesselPropertiesEdit));
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOk = new System.Windows.Forms.Button();
			this.grpGeneral = new System.Windows.Forms.GroupBox();
			this.lblYardNo = new System.Windows.Forms.Label();
			this.txtYardNo = new System.Windows.Forms.TextBox();
			this.lblYard = new System.Windows.Forms.Label();
			this.txtOwner = new System.Windows.Forms.TextBox();
			this.txtYard = new System.Windows.Forms.TextBox();
			this.lblOwner = new System.Windows.Forms.Label();
			this.cboVesselType = new System.Windows.Forms.ComboBox();
			this.lblVesselType = new System.Windows.Forms.Label();
			this.txtVessel = new System.Windows.Forms.TextBox();
			this.lblVessel = new System.Windows.Forms.Label();
			this.txtClass = new System.Windows.Forms.TextBox();
			this.lblClass = new System.Windows.Forms.Label();
			this.grpApplicationSetup = new System.Windows.Forms.GroupBox();
			this.lblSystemWarning = new System.Windows.Forms.Label();
			this.txtFaceplateTrendTimeout = new System.Windows.Forms.TextBox();
			this.lblFaceplateTrendTimeout = new System.Windows.Forms.Label();
			this.txtSystemWarning = new System.Windows.Forms.TextBox();
			this.chkFaceplateTrendEnable = new System.Windows.Forms.CheckBox();
			this.lblFaceplateTrendEnable = new System.Windows.Forms.Label();
			this.cboMeasurementSystem = new System.Windows.Forms.ComboBox();
			this.lblMeasurementSystem = new System.Windows.Forms.Label();
			this.grpSetup = new System.Windows.Forms.GroupBox();
			this.txtConfigurationHistory = new System.Windows.Forms.TextBox();
			this.lblConfigurationHistory = new System.Windows.Forms.Label();
			this.dtWarrantyExpiration = new System.Windows.Forms.DateTimePicker();
			this.lblWarrantyExpiration = new System.Windows.Forms.Label();
			this.txtCommissioningEngineer = new System.Windows.Forms.TextBox();
			this.lblCommissioningEngineer = new System.Windows.Forms.Label();
			this.dtConfigured = new System.Windows.Forms.DateTimePicker();
			this.lblConfigured = new System.Windows.Forms.Label();
			this.txtConfiguredBy = new System.Windows.Forms.TextBox();
			this.lblConfiguredBy = new System.Windows.Forms.Label();
			this.grpDraftSensorPlacement = new System.Windows.Forms.GroupBox();
			this.chkDCEnabled = new System.Windows.Forms.CheckBox();
			this.lblDCEnabled = new System.Windows.Forms.Label();
			this.txtDCForeAftSensorDistance = new System.Windows.Forms.TextBox();
			this.lblDCForeAftSensorDistance = new System.Windows.Forms.Label();
			this.txtDCAftSensorMarkDistance = new System.Windows.Forms.TextBox();
			this.lblDCAftSensorMarkDistance = new System.Windows.Forms.Label();
			this.txtDCForeSensorMarkDistance = new System.Windows.Forms.TextBox();
			this.lblDCForeSensorMarkDistance = new System.Windows.Forms.Label();
			this.txtDCStarboardPortSensorDistance = new System.Windows.Forms.TextBox();
			this.lblDCStarboardPortSensorDistance = new System.Windows.Forms.Label();
			this.txtDCStarboardSensorMarkDistance = new System.Windows.Forms.TextBox();
			this.lblDCStarboardSensorMarkDistance = new System.Windows.Forms.Label();
			this.txtDCPortSensorMarkDistance = new System.Windows.Forms.TextBox();
			this.lblDCPortSensorMarkDistance = new System.Windows.Forms.Label();
			this.lblDistanceBetween1 = new System.Windows.Forms.Label();
			this.cboDCUnits = new System.Windows.Forms.ComboBox();
			this.lblDCUnits = new System.Windows.Forms.Label();
			this.grpGeneral.SuspendLayout();
			this.grpApplicationSetup.SuspendLayout();
			this.grpSetup.SuspendLayout();
			this.grpDraftSensorPlacement.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(542, 576);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 5;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.UseVisualStyleBackColor = true;
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOk
			// 
			this.cmdOk.Location = new System.Drawing.Point(461, 576);
			this.cmdOk.Name = "cmdOk";
			this.cmdOk.Size = new System.Drawing.Size(75, 23);
			this.cmdOk.TabIndex = 4;
			this.cmdOk.Text = "Ok";
			this.cmdOk.UseVisualStyleBackColor = true;
			this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
			// 
			// grpGeneral
			// 
			this.grpGeneral.Controls.Add(this.lblYardNo);
			this.grpGeneral.Controls.Add(this.txtYardNo);
			this.grpGeneral.Controls.Add(this.lblYard);
			this.grpGeneral.Controls.Add(this.txtOwner);
			this.grpGeneral.Controls.Add(this.txtYard);
			this.grpGeneral.Controls.Add(this.lblOwner);
			this.grpGeneral.Controls.Add(this.cboVesselType);
			this.grpGeneral.Controls.Add(this.lblVesselType);
			this.grpGeneral.Controls.Add(this.txtVessel);
			this.grpGeneral.Controls.Add(this.lblVessel);
			this.grpGeneral.Controls.Add(this.txtClass);
			this.grpGeneral.Controls.Add(this.lblClass);
			this.grpGeneral.Location = new System.Drawing.Point(12, 12);
			this.grpGeneral.Name = "grpGeneral";
			this.grpGeneral.Size = new System.Drawing.Size(612, 101);
			this.grpGeneral.TabIndex = 0;
			this.grpGeneral.TabStop = false;
			this.grpGeneral.Text = "General";
			// 
			// lblYardNo
			// 
			this.lblYardNo.AutoSize = true;
			this.lblYardNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblYardNo.Location = new System.Drawing.Point(318, 73);
			this.lblYardNo.Name = "lblYardNo";
			this.lblYardNo.Size = new System.Drawing.Size(53, 13);
			this.lblYardNo.TabIndex = 18;
			this.lblYardNo.Text = "Yard No";
			// 
			// txtYardNo
			// 
			this.txtYardNo.Location = new System.Drawing.Point(478, 69);
			this.txtYardNo.Name = "txtYardNo";
			this.txtYardNo.Size = new System.Drawing.Size(127, 20);
			this.txtYardNo.TabIndex = 5;
			// 
			// lblYard
			// 
			this.lblYard.AutoSize = true;
			this.lblYard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblYard.Location = new System.Drawing.Point(22, 73);
			this.lblYard.Name = "lblYard";
			this.lblYard.Size = new System.Drawing.Size(33, 13);
			this.lblYard.TabIndex = 18;
			this.lblYard.Text = "Yard";
			// 
			// txtOwner
			// 
			this.txtOwner.Location = new System.Drawing.Point(183, 43);
			this.txtOwner.Name = "txtOwner";
			this.txtOwner.Size = new System.Drawing.Size(127, 20);
			this.txtOwner.TabIndex = 2;
			// 
			// txtYard
			// 
			this.txtYard.Location = new System.Drawing.Point(183, 69);
			this.txtYard.Name = "txtYard";
			this.txtYard.Size = new System.Drawing.Size(127, 20);
			this.txtYard.TabIndex = 4;
			// 
			// lblOwner
			// 
			this.lblOwner.AutoSize = true;
			this.lblOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblOwner.Location = new System.Drawing.Point(22, 47);
			this.lblOwner.Name = "lblOwner";
			this.lblOwner.Size = new System.Drawing.Size(43, 13);
			this.lblOwner.TabIndex = 16;
			this.lblOwner.Text = "Owner";
			// 
			// cboVesselType
			// 
			this.cboVesselType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboVesselType.FormattingEnabled = true;
			this.cboVesselType.Location = new System.Drawing.Point(478, 17);
			this.cboVesselType.Name = "cboVesselType";
			this.cboVesselType.Size = new System.Drawing.Size(127, 21);
			this.cboVesselType.TabIndex = 1;
			// 
			// lblVesselType
			// 
			this.lblVesselType.AutoSize = true;
			this.lblVesselType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblVesselType.Location = new System.Drawing.Point(318, 21);
			this.lblVesselType.Name = "lblVesselType";
			this.lblVesselType.Size = new System.Drawing.Size(76, 13);
			this.lblVesselType.TabIndex = 15;
			this.lblVesselType.Text = "Vessel Type";
			// 
			// txtVessel
			// 
			this.txtVessel.Location = new System.Drawing.Point(183, 17);
			this.txtVessel.Name = "txtVessel";
			this.txtVessel.Size = new System.Drawing.Size(127, 20);
			this.txtVessel.TabIndex = 0;
			// 
			// lblVessel
			// 
			this.lblVessel.AutoSize = true;
			this.lblVessel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblVessel.Location = new System.Drawing.Point(22, 21);
			this.lblVessel.Name = "lblVessel";
			this.lblVessel.Size = new System.Drawing.Size(44, 13);
			this.lblVessel.TabIndex = 14;
			this.lblVessel.Text = "Vessel";
			// 
			// txtClass
			// 
			this.txtClass.Location = new System.Drawing.Point(478, 43);
			this.txtClass.Name = "txtClass";
			this.txtClass.Size = new System.Drawing.Size(127, 20);
			this.txtClass.TabIndex = 3;
			// 
			// lblClass
			// 
			this.lblClass.AutoSize = true;
			this.lblClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblClass.Location = new System.Drawing.Point(318, 47);
			this.lblClass.Name = "lblClass";
			this.lblClass.Size = new System.Drawing.Size(37, 13);
			this.lblClass.TabIndex = 18;
			this.lblClass.Text = "Class";
			// 
			// grpApplicationSetup
			// 
			this.grpApplicationSetup.Controls.Add(this.lblSystemWarning);
			this.grpApplicationSetup.Controls.Add(this.txtFaceplateTrendTimeout);
			this.grpApplicationSetup.Controls.Add(this.lblFaceplateTrendTimeout);
			this.grpApplicationSetup.Controls.Add(this.txtSystemWarning);
			this.grpApplicationSetup.Controls.Add(this.chkFaceplateTrendEnable);
			this.grpApplicationSetup.Controls.Add(this.lblFaceplateTrendEnable);
			this.grpApplicationSetup.Controls.Add(this.cboMeasurementSystem);
			this.grpApplicationSetup.Controls.Add(this.lblMeasurementSystem);
			this.grpApplicationSetup.Location = new System.Drawing.Point(12, 119);
			this.grpApplicationSetup.Name = "grpApplicationSetup";
			this.grpApplicationSetup.Size = new System.Drawing.Size(612, 144);
			this.grpApplicationSetup.TabIndex = 1;
			this.grpApplicationSetup.TabStop = false;
			this.grpApplicationSetup.Text = "System  Configuration";
			// 
			// lblSystemWarning
			// 
			this.lblSystemWarning.AutoSize = true;
			this.lblSystemWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSystemWarning.Location = new System.Drawing.Point(22, 67);
			this.lblSystemWarning.Name = "lblSystemWarning";
			this.lblSystemWarning.Size = new System.Drawing.Size(98, 13);
			this.lblSystemWarning.TabIndex = 30;
			this.lblSystemWarning.Text = "System Warning";
			// 
			// txtFaceplateTrendTimeout
			// 
			this.txtFaceplateTrendTimeout.Location = new System.Drawing.Point(478, 17);
			this.txtFaceplateTrendTimeout.Name = "txtFaceplateTrendTimeout";
			this.txtFaceplateTrendTimeout.Size = new System.Drawing.Size(127, 20);
			this.txtFaceplateTrendTimeout.TabIndex = 1;
			this.txtFaceplateTrendTimeout.Text = "15000";
			this.txtFaceplateTrendTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblFaceplateTrendTimeout
			// 
			this.lblFaceplateTrendTimeout.AutoSize = true;
			this.lblFaceplateTrendTimeout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblFaceplateTrendTimeout.Location = new System.Drawing.Point(318, 21);
			this.lblFaceplateTrendTimeout.Name = "lblFaceplateTrendTimeout";
			this.lblFaceplateTrendTimeout.Size = new System.Drawing.Size(125, 13);
			this.lblFaceplateTrendTimeout.TabIndex = 21;
			this.lblFaceplateTrendTimeout.Text = "Trend Arrow Timeout";
			// 
			// txtSystemWarning
			// 
			this.txtSystemWarning.Location = new System.Drawing.Point(184, 67);
			this.txtSystemWarning.Multiline = true;
			this.txtSystemWarning.Name = "txtSystemWarning";
			this.txtSystemWarning.Size = new System.Drawing.Size(418, 68);
			this.txtSystemWarning.TabIndex = 3;
			// 
			// chkFaceplateTrendEnable
			// 
			this.chkFaceplateTrendEnable.AutoSize = true;
			this.chkFaceplateTrendEnable.Location = new System.Drawing.Point(183, 20);
			this.chkFaceplateTrendEnable.Name = "chkFaceplateTrendEnable";
			this.chkFaceplateTrendEnable.Size = new System.Drawing.Size(15, 14);
			this.chkFaceplateTrendEnable.TabIndex = 0;
			this.chkFaceplateTrendEnable.UseVisualStyleBackColor = true;
			this.chkFaceplateTrendEnable.CheckedChanged += new System.EventHandler(this.chkFaceplateTrendEnable_CheckedChanged);
			// 
			// lblFaceplateTrendEnable
			// 
			this.lblFaceplateTrendEnable.AutoSize = true;
			this.lblFaceplateTrendEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblFaceplateTrendEnable.Location = new System.Drawing.Point(22, 21);
			this.lblFaceplateTrendEnable.Name = "lblFaceplateTrendEnable";
			this.lblFaceplateTrendEnable.Size = new System.Drawing.Size(126, 13);
			this.lblFaceplateTrendEnable.TabIndex = 20;
			this.lblFaceplateTrendEnable.Text = "Trend Arrow Enabled";
			// 
			// cboMeasurementSystem
			// 
			this.cboMeasurementSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboMeasurementSystem.FormattingEnabled = true;
			this.cboMeasurementSystem.Location = new System.Drawing.Point(183, 40);
			this.cboMeasurementSystem.Name = "cboMeasurementSystem";
			this.cboMeasurementSystem.Size = new System.Drawing.Size(127, 21);
			this.cboMeasurementSystem.TabIndex = 2;
			// 
			// lblMeasurementSystem
			// 
			this.lblMeasurementSystem.AutoSize = true;
			this.lblMeasurementSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMeasurementSystem.Location = new System.Drawing.Point(22, 44);
			this.lblMeasurementSystem.Name = "lblMeasurementSystem";
			this.lblMeasurementSystem.Size = new System.Drawing.Size(126, 13);
			this.lblMeasurementSystem.TabIndex = 20;
			this.lblMeasurementSystem.Text = "Measurement System";
			// 
			// grpSetup
			// 
			this.grpSetup.Controls.Add(this.txtConfigurationHistory);
			this.grpSetup.Controls.Add(this.lblConfigurationHistory);
			this.grpSetup.Controls.Add(this.dtWarrantyExpiration);
			this.grpSetup.Controls.Add(this.lblWarrantyExpiration);
			this.grpSetup.Controls.Add(this.txtCommissioningEngineer);
			this.grpSetup.Controls.Add(this.lblCommissioningEngineer);
			this.grpSetup.Controls.Add(this.dtConfigured);
			this.grpSetup.Controls.Add(this.lblConfigured);
			this.grpSetup.Controls.Add(this.txtConfiguredBy);
			this.grpSetup.Controls.Add(this.lblConfiguredBy);
			this.grpSetup.Location = new System.Drawing.Point(12, 269);
			this.grpSetup.Name = "grpSetup";
			this.grpSetup.Size = new System.Drawing.Size(612, 144);
			this.grpSetup.TabIndex = 2;
			this.grpSetup.TabStop = false;
			this.grpSetup.Text = "Setup Information";
			// 
			// txtConfigurationHistory
			// 
			this.txtConfigurationHistory.Location = new System.Drawing.Point(183, 69);
			this.txtConfigurationHistory.Multiline = true;
			this.txtConfigurationHistory.Name = "txtConfigurationHistory";
			this.txtConfigurationHistory.Size = new System.Drawing.Size(422, 68);
			this.txtConfigurationHistory.TabIndex = 4;
			// 
			// lblConfigurationHistory
			// 
			this.lblConfigurationHistory.AutoSize = true;
			this.lblConfigurationHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblConfigurationHistory.Location = new System.Drawing.Point(22, 73);
			this.lblConfigurationHistory.Name = "lblConfigurationHistory";
			this.lblConfigurationHistory.Size = new System.Drawing.Size(125, 13);
			this.lblConfigurationHistory.TabIndex = 27;
			this.lblConfigurationHistory.Text = "Configuration History";
			// 
			// dtWarrantyExpiration
			// 
			this.dtWarrantyExpiration.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
			this.dtWarrantyExpiration.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtWarrantyExpiration.Location = new System.Drawing.Point(478, 43);
			this.dtWarrantyExpiration.Name = "dtWarrantyExpiration";
			this.dtWarrantyExpiration.Size = new System.Drawing.Size(127, 20);
			this.dtWarrantyExpiration.TabIndex = 3;
			// 
			// lblWarrantyExpiration
			// 
			this.lblWarrantyExpiration.AutoSize = true;
			this.lblWarrantyExpiration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblWarrantyExpiration.Location = new System.Drawing.Point(318, 47);
			this.lblWarrantyExpiration.Name = "lblWarrantyExpiration";
			this.lblWarrantyExpiration.Size = new System.Drawing.Size(118, 13);
			this.lblWarrantyExpiration.TabIndex = 26;
			this.lblWarrantyExpiration.Text = "Warranty Expiration";
			// 
			// txtCommissioningEngineer
			// 
			this.txtCommissioningEngineer.Location = new System.Drawing.Point(183, 43);
			this.txtCommissioningEngineer.Name = "txtCommissioningEngineer";
			this.txtCommissioningEngineer.Size = new System.Drawing.Size(127, 20);
			this.txtCommissioningEngineer.TabIndex = 2;
			// 
			// lblCommissioningEngineer
			// 
			this.lblCommissioningEngineer.AutoSize = true;
			this.lblCommissioningEngineer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCommissioningEngineer.Location = new System.Drawing.Point(22, 47);
			this.lblCommissioningEngineer.Name = "lblCommissioningEngineer";
			this.lblCommissioningEngineer.Size = new System.Drawing.Size(143, 13);
			this.lblCommissioningEngineer.TabIndex = 23;
			this.lblCommissioningEngineer.Text = "Commissioning Engineer";
			// 
			// dtConfigured
			// 
			this.dtConfigured.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
			this.dtConfigured.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtConfigured.Location = new System.Drawing.Point(478, 17);
			this.dtConfigured.Name = "dtConfigured";
			this.dtConfigured.Size = new System.Drawing.Size(127, 20);
			this.dtConfigured.TabIndex = 1;
			// 
			// lblConfigured
			// 
			this.lblConfigured.AutoSize = true;
			this.lblConfigured.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblConfigured.Location = new System.Drawing.Point(318, 21);
			this.lblConfigured.Name = "lblConfigured";
			this.lblConfigured.Size = new System.Drawing.Size(113, 13);
			this.lblConfigured.TabIndex = 22;
			this.lblConfigured.Text = "Configuration Date";
			// 
			// txtConfiguredBy
			// 
			this.txtConfiguredBy.Location = new System.Drawing.Point(183, 17);
			this.txtConfiguredBy.Name = "txtConfiguredBy";
			this.txtConfiguredBy.Size = new System.Drawing.Size(127, 20);
			this.txtConfiguredBy.TabIndex = 0;
			// 
			// lblConfiguredBy
			// 
			this.lblConfiguredBy.AutoSize = true;
			this.lblConfiguredBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblConfiguredBy.Location = new System.Drawing.Point(22, 21);
			this.lblConfiguredBy.Name = "lblConfiguredBy";
			this.lblConfiguredBy.Size = new System.Drawing.Size(86, 13);
			this.lblConfiguredBy.TabIndex = 20;
			this.lblConfiguredBy.Text = "Configured By";
			// 
			// grpDraftSensorPlacement
			// 
			this.grpDraftSensorPlacement.Controls.Add(this.chkDCEnabled);
			this.grpDraftSensorPlacement.Controls.Add(this.lblDCEnabled);
			this.grpDraftSensorPlacement.Controls.Add(this.txtDCForeAftSensorDistance);
			this.grpDraftSensorPlacement.Controls.Add(this.lblDCForeAftSensorDistance);
			this.grpDraftSensorPlacement.Controls.Add(this.txtDCAftSensorMarkDistance);
			this.grpDraftSensorPlacement.Controls.Add(this.lblDCAftSensorMarkDistance);
			this.grpDraftSensorPlacement.Controls.Add(this.txtDCForeSensorMarkDistance);
			this.grpDraftSensorPlacement.Controls.Add(this.lblDCForeSensorMarkDistance);
			this.grpDraftSensorPlacement.Controls.Add(this.txtDCStarboardPortSensorDistance);
			this.grpDraftSensorPlacement.Controls.Add(this.lblDCStarboardPortSensorDistance);
			this.grpDraftSensorPlacement.Controls.Add(this.txtDCStarboardSensorMarkDistance);
			this.grpDraftSensorPlacement.Controls.Add(this.lblDCStarboardSensorMarkDistance);
			this.grpDraftSensorPlacement.Controls.Add(this.txtDCPortSensorMarkDistance);
			this.grpDraftSensorPlacement.Controls.Add(this.lblDCPortSensorMarkDistance);
			this.grpDraftSensorPlacement.Controls.Add(this.lblDistanceBetween1);
			this.grpDraftSensorPlacement.Controls.Add(this.cboDCUnits);
			this.grpDraftSensorPlacement.Controls.Add(this.lblDCUnits);
			this.grpDraftSensorPlacement.Location = new System.Drawing.Point(12, 419);
			this.grpDraftSensorPlacement.Name = "grpDraftSensorPlacement";
			this.grpDraftSensorPlacement.Size = new System.Drawing.Size(612, 151);
			this.grpDraftSensorPlacement.TabIndex = 3;
			this.grpDraftSensorPlacement.TabStop = false;
			this.grpDraftSensorPlacement.Text = "Draft Sensor Placement";
			// 
			// chkDCEnabled
			// 
			this.chkDCEnabled.AutoSize = true;
			this.chkDCEnabled.Location = new System.Drawing.Point(183, 20);
			this.chkDCEnabled.Name = "chkDCEnabled";
			this.chkDCEnabled.Size = new System.Drawing.Size(15, 14);
			this.chkDCEnabled.TabIndex = 35;
			this.chkDCEnabled.UseVisualStyleBackColor = true;
			// 
			// lblDCEnabled
			// 
			this.lblDCEnabled.AutoSize = true;
			this.lblDCEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDCEnabled.Location = new System.Drawing.Point(22, 21);
			this.lblDCEnabled.Name = "lblDCEnabled";
			this.lblDCEnabled.Size = new System.Drawing.Size(147, 13);
			this.lblDCEnabled.TabIndex = 36;
			this.lblDCEnabled.Text = "Draft Correction Enabled";
			// 
			// txtDCForeAftSensorDistance
			// 
			this.txtDCForeAftSensorDistance.Location = new System.Drawing.Point(478, 121);
			this.txtDCForeAftSensorDistance.Name = "txtDCForeAftSensorDistance";
			this.txtDCForeAftSensorDistance.Size = new System.Drawing.Size(127, 20);
			this.txtDCForeAftSensorDistance.TabIndex = 6;
			this.txtDCForeAftSensorDistance.Text = "0";
			this.txtDCForeAftSensorDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblDCForeAftSensorDistance
			// 
			this.lblDCForeAftSensorDistance.AutoSize = true;
			this.lblDCForeAftSensorDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDCForeAftSensorDistance.Location = new System.Drawing.Point(318, 125);
			this.lblDCForeAftSensorDistance.Name = "lblDCForeAftSensorDistance";
			this.lblDCForeAftSensorDistance.Size = new System.Drawing.Size(126, 13);
			this.lblDCForeAftSensorDistance.TabIndex = 34;
			this.lblDCForeAftSensorDistance.Text = "Fore and Aft Sensors";
			// 
			// txtDCAftSensorMarkDistance
			// 
			this.txtDCAftSensorMarkDistance.Location = new System.Drawing.Point(478, 95);
			this.txtDCAftSensorMarkDistance.Name = "txtDCAftSensorMarkDistance";
			this.txtDCAftSensorMarkDistance.Size = new System.Drawing.Size(127, 20);
			this.txtDCAftSensorMarkDistance.TabIndex = 4;
			this.txtDCAftSensorMarkDistance.Text = "0";
			this.txtDCAftSensorMarkDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblDCAftSensorMarkDistance
			// 
			this.lblDCAftSensorMarkDistance.AutoSize = true;
			this.lblDCAftSensorMarkDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDCAftSensorMarkDistance.Location = new System.Drawing.Point(318, 99);
			this.lblDCAftSensorMarkDistance.Name = "lblDCAftSensorMarkDistance";
			this.lblDCAftSensorMarkDistance.Size = new System.Drawing.Size(140, 13);
			this.lblDCAftSensorMarkDistance.TabIndex = 32;
			this.lblDCAftSensorMarkDistance.Text = "Aft Sensor / Draft Mark";
			// 
			// txtDCForeSensorMarkDistance
			// 
			this.txtDCForeSensorMarkDistance.Location = new System.Drawing.Point(478, 69);
			this.txtDCForeSensorMarkDistance.Name = "txtDCForeSensorMarkDistance";
			this.txtDCForeSensorMarkDistance.Size = new System.Drawing.Size(127, 20);
			this.txtDCForeSensorMarkDistance.TabIndex = 2;
			this.txtDCForeSensorMarkDistance.Text = "0";
			this.txtDCForeSensorMarkDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblDCForeSensorMarkDistance
			// 
			this.lblDCForeSensorMarkDistance.AutoSize = true;
			this.lblDCForeSensorMarkDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDCForeSensorMarkDistance.Location = new System.Drawing.Point(318, 73);
			this.lblDCForeSensorMarkDistance.Name = "lblDCForeSensorMarkDistance";
			this.lblDCForeSensorMarkDistance.Size = new System.Drawing.Size(149, 13);
			this.lblDCForeSensorMarkDistance.TabIndex = 30;
			this.lblDCForeSensorMarkDistance.Text = "Fore Sensor / Draft Mark";
			// 
			// txtDCStarboardPortSensorDistance
			// 
			this.txtDCStarboardPortSensorDistance.Location = new System.Drawing.Point(184, 121);
			this.txtDCStarboardPortSensorDistance.Name = "txtDCStarboardPortSensorDistance";
			this.txtDCStarboardPortSensorDistance.Size = new System.Drawing.Size(127, 20);
			this.txtDCStarboardPortSensorDistance.TabIndex = 5;
			this.txtDCStarboardPortSensorDistance.Text = "0";
			this.txtDCStarboardPortSensorDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblDCStarboardPortSensorDistance
			// 
			this.lblDCStarboardPortSensorDistance.AutoSize = true;
			this.lblDCStarboardPortSensorDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDCStarboardPortSensorDistance.Location = new System.Drawing.Point(23, 125);
			this.lblDCStarboardPortSensorDistance.Name = "lblDCStarboardPortSensorDistance";
			this.lblDCStarboardPortSensorDistance.Size = new System.Drawing.Size(138, 13);
			this.lblDCStarboardPortSensorDistance.TabIndex = 28;
			this.lblDCStarboardPortSensorDistance.Text = "Stbd. and Port Sensors";
			// 
			// txtDCStarboardSensorMarkDistance
			// 
			this.txtDCStarboardSensorMarkDistance.Location = new System.Drawing.Point(183, 69);
			this.txtDCStarboardSensorMarkDistance.Name = "txtDCStarboardSensorMarkDistance";
			this.txtDCStarboardSensorMarkDistance.Size = new System.Drawing.Size(127, 20);
			this.txtDCStarboardSensorMarkDistance.TabIndex = 1;
			this.txtDCStarboardSensorMarkDistance.Text = "0";
			this.txtDCStarboardSensorMarkDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblDCStarboardSensorMarkDistance
			// 
			this.lblDCStarboardSensorMarkDistance.AutoSize = true;
			this.lblDCStarboardSensorMarkDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDCStarboardSensorMarkDistance.Location = new System.Drawing.Point(22, 73);
			this.lblDCStarboardSensorMarkDistance.Name = "lblDCStarboardSensorMarkDistance";
			this.lblDCStarboardSensorMarkDistance.Size = new System.Drawing.Size(154, 13);
			this.lblDCStarboardSensorMarkDistance.TabIndex = 26;
			this.lblDCStarboardSensorMarkDistance.Text = "Stbd. Sensor / Draft Mark";
			// 
			// txtDCPortSensorMarkDistance
			// 
			this.txtDCPortSensorMarkDistance.Location = new System.Drawing.Point(183, 95);
			this.txtDCPortSensorMarkDistance.Name = "txtDCPortSensorMarkDistance";
			this.txtDCPortSensorMarkDistance.Size = new System.Drawing.Size(127, 20);
			this.txtDCPortSensorMarkDistance.TabIndex = 3;
			this.txtDCPortSensorMarkDistance.Text = "0";
			this.txtDCPortSensorMarkDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblDCPortSensorMarkDistance
			// 
			this.lblDCPortSensorMarkDistance.AutoSize = true;
			this.lblDCPortSensorMarkDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDCPortSensorMarkDistance.Location = new System.Drawing.Point(22, 99);
			this.lblDCPortSensorMarkDistance.Name = "lblDCPortSensorMarkDistance";
			this.lblDCPortSensorMarkDistance.Size = new System.Drawing.Size(147, 13);
			this.lblDCPortSensorMarkDistance.TabIndex = 24;
			this.lblDCPortSensorMarkDistance.Text = "Port Sensor / Draft Mark";
			// 
			// lblDistanceBetween1
			// 
			this.lblDistanceBetween1.AutoSize = true;
			this.lblDistanceBetween1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDistanceBetween1.Location = new System.Drawing.Point(22, 47);
			this.lblDistanceBetween1.Name = "lblDistanceBetween1";
			this.lblDistanceBetween1.Size = new System.Drawing.Size(209, 13);
			this.lblDistanceBetween1.TabIndex = 23;
			this.lblDistanceBetween1.Text = "Distance Between (along keel line):";
			// 
			// cboDCUnits
			// 
			this.cboDCUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDCUnits.FormattingEnabled = true;
			this.cboDCUnits.Location = new System.Drawing.Point(478, 17);
			this.cboDCUnits.Name = "cboDCUnits";
			this.cboDCUnits.Size = new System.Drawing.Size(127, 21);
			this.cboDCUnits.TabIndex = 0;
			// 
			// lblDCUnits
			// 
			this.lblDCUnits.AutoSize = true;
			this.lblDCUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDCUnits.Location = new System.Drawing.Point(318, 21);
			this.lblDCUnits.Name = "lblDCUnits";
			this.lblDCUnits.Size = new System.Drawing.Size(36, 13);
			this.lblDCUnits.TabIndex = 22;
			this.lblDCUnits.Text = "Units";
			// 
			// VesselPropertiesEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(634, 606);
			this.Controls.Add(this.grpDraftSensorPlacement);
			this.Controls.Add(this.grpSetup);
			this.Controls.Add(this.grpApplicationSetup);
			this.Controls.Add(this.grpGeneral);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "VesselPropertiesEdit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Vessel Properties";
			this.Load += new System.EventHandler(this.VesselPropertiesEdit_Load);
			this.grpGeneral.ResumeLayout(false);
			this.grpGeneral.PerformLayout();
			this.grpApplicationSetup.ResumeLayout(false);
			this.grpApplicationSetup.PerformLayout();
			this.grpSetup.ResumeLayout(false);
			this.grpSetup.PerformLayout();
			this.grpDraftSensorPlacement.ResumeLayout(false);
			this.grpDraftSensorPlacement.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOk;
		private System.Windows.Forms.GroupBox grpGeneral;
		private System.Windows.Forms.Label lblVessel;
		private System.Windows.Forms.TextBox txtYard;
		private System.Windows.Forms.Label lblYard;
		private System.Windows.Forms.TextBox txtClass;
		private System.Windows.Forms.Label lblClass;
		private System.Windows.Forms.TextBox txtOwner;
		private System.Windows.Forms.Label lblOwner;
		private System.Windows.Forms.ComboBox cboVesselType;
		private System.Windows.Forms.Label lblVesselType;
		private System.Windows.Forms.TextBox txtVessel;
		private System.Windows.Forms.TextBox txtYardNo;
		private System.Windows.Forms.Label lblYardNo;
		private System.Windows.Forms.GroupBox grpApplicationSetup;
		private System.Windows.Forms.Label lblMeasurementSystem;
		private System.Windows.Forms.ComboBox cboMeasurementSystem;
		private System.Windows.Forms.TextBox txtFaceplateTrendTimeout;
		private System.Windows.Forms.Label lblFaceplateTrendTimeout;
		private System.Windows.Forms.CheckBox chkFaceplateTrendEnable;
		private System.Windows.Forms.Label lblFaceplateTrendEnable;
		private System.Windows.Forms.GroupBox grpSetup;
		private System.Windows.Forms.TextBox txtConfiguredBy;
		private System.Windows.Forms.Label lblConfiguredBy;
		private System.Windows.Forms.Label lblConfigured;
		private System.Windows.Forms.DateTimePicker dtWarrantyExpiration;
		private System.Windows.Forms.Label lblWarrantyExpiration;
		private System.Windows.Forms.TextBox txtCommissioningEngineer;
		private System.Windows.Forms.Label lblCommissioningEngineer;
		private System.Windows.Forms.DateTimePicker dtConfigured;
		private System.Windows.Forms.TextBox txtConfigurationHistory;
		private System.Windows.Forms.Label lblConfigurationHistory;
		private System.Windows.Forms.TextBox txtSystemWarning;
		private System.Windows.Forms.Label lblSystemWarning;
		private System.Windows.Forms.GroupBox grpDraftSensorPlacement;
		private System.Windows.Forms.ComboBox cboDCUnits;
		private System.Windows.Forms.Label lblDCUnits;
		private System.Windows.Forms.TextBox txtDCStarboardPortSensorDistance;
		private System.Windows.Forms.Label lblDCStarboardPortSensorDistance;
		private System.Windows.Forms.TextBox txtDCStarboardSensorMarkDistance;
		private System.Windows.Forms.Label lblDCStarboardSensorMarkDistance;
		private System.Windows.Forms.TextBox txtDCPortSensorMarkDistance;
		private System.Windows.Forms.Label lblDCPortSensorMarkDistance;
		private System.Windows.Forms.Label lblDistanceBetween1;
		private System.Windows.Forms.TextBox txtDCForeAftSensorDistance;
		private System.Windows.Forms.Label lblDCForeAftSensorDistance;
		private System.Windows.Forms.TextBox txtDCAftSensorMarkDistance;
		private System.Windows.Forms.Label lblDCAftSensorMarkDistance;
		private System.Windows.Forms.TextBox txtDCForeSensorMarkDistance;
		private System.Windows.Forms.Label lblDCForeSensorMarkDistance;
		private System.Windows.Forms.CheckBox chkDCEnabled;
		private System.Windows.Forms.Label lblDCEnabled;
	}
}