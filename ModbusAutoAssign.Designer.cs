namespace TLIConfiguration
{
	partial class ModbusAutoAssign
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
			this.grpGauges = new System.Windows.Forms.GroupBox();
			this.chkGaugeCargoUllage = new System.Windows.Forms.CheckBox();
			this.chkGaugeCargoVolume = new System.Windows.Forms.CheckBox();
			this.chkGaugePumpManifold = new System.Windows.Forms.CheckBox();
			this.chkGaugeAuxiliaryVolume = new System.Windows.Forms.CheckBox();
			this.chkGaugeTemperatureBot = new System.Windows.Forms.CheckBox();
			this.chkGaugeAuxiliaryLevel = new System.Windows.Forms.CheckBox();
			this.chkGaugeTemperatureTop = new System.Windows.Forms.CheckBox();
			this.chkGaugeBallastVolume = new System.Windows.Forms.CheckBox();
			this.chkGaugePressure = new System.Windows.Forms.CheckBox();
			this.chkGaugeTemperatureMid = new System.Windows.Forms.CheckBox();
			this.chkGaugeAverageTemperature = new System.Windows.Forms.CheckBox();
			this.chkGaugeBallastLevel = new System.Windows.Forms.CheckBox();
			this.chkGaugeList = new System.Windows.Forms.CheckBox();
			this.chkGaugeTrim = new System.Windows.Forms.CheckBox();
			this.chkGaugeDraft = new System.Windows.Forms.CheckBox();
			this.grpAlarm = new System.Windows.Forms.GroupBox();
			this.chkAlarmCargoOverfill = new System.Windows.Forms.CheckBox();
			this.chkAlarmPump = new System.Windows.Forms.CheckBox();
			this.chkAlarmPressure = new System.Windows.Forms.CheckBox();
			this.chkAlarmTemperatureBot = new System.Windows.Forms.CheckBox();
			this.chkAlarmTemperatureMid = new System.Windows.Forms.CheckBox();
			this.chkAlarmAuxilliaryOverfill = new System.Windows.Forms.CheckBox();
			this.chkAlarmBallastHighLevel = new System.Windows.Forms.CheckBox();
			this.chkAlarmBallastOverfill = new System.Windows.Forms.CheckBox();
			this.chkAlarmCargoHighLevel = new System.Windows.Forms.CheckBox();
			this.chkAlarmTemperatureTop = new System.Windows.Forms.CheckBox();
			this.chkAlarmAverageTemperature = new System.Windows.Forms.CheckBox();
			this.chkAlarmAuxilliaryHighLevel = new System.Windows.Forms.CheckBox();
			this.cboGaugeDataType = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdOk = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.grpGauges.SuspendLayout();
			this.grpAlarm.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpGauges
			// 
			this.grpGauges.Controls.Add(this.cboGaugeDataType);
			this.grpGauges.Controls.Add(this.label1);
			this.grpGauges.Controls.Add(this.chkGaugeDraft);
			this.grpGauges.Controls.Add(this.chkGaugeTrim);
			this.grpGauges.Controls.Add(this.chkGaugeList);
			this.grpGauges.Controls.Add(this.chkGaugeBallastLevel);
			this.grpGauges.Controls.Add(this.chkGaugeAverageTemperature);
			this.grpGauges.Controls.Add(this.chkGaugeTemperatureMid);
			this.grpGauges.Controls.Add(this.chkGaugePressure);
			this.grpGauges.Controls.Add(this.chkGaugeBallastVolume);
			this.grpGauges.Controls.Add(this.chkGaugeTemperatureTop);
			this.grpGauges.Controls.Add(this.chkGaugeAuxiliaryLevel);
			this.grpGauges.Controls.Add(this.chkGaugeTemperatureBot);
			this.grpGauges.Controls.Add(this.chkGaugeAuxiliaryVolume);
			this.grpGauges.Controls.Add(this.chkGaugePumpManifold);
			this.grpGauges.Controls.Add(this.chkGaugeCargoVolume);
			this.grpGauges.Controls.Add(this.chkGaugeCargoUllage);
			this.grpGauges.Location = new System.Drawing.Point(12, 12);
			this.grpGauges.Name = "grpGauges";
			this.grpGauges.Size = new System.Drawing.Size(502, 224);
			this.grpGauges.TabIndex = 0;
			this.grpGauges.TabStop = false;
			this.grpGauges.Text = "Gauges";
			// 
			// chkGaugeCargoUllage
			// 
			this.chkGaugeCargoUllage.AutoSize = true;
			this.chkGaugeCargoUllage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkGaugeCargoUllage.Location = new System.Drawing.Point(6, 57);
			this.chkGaugeCargoUllage.Name = "chkGaugeCargoUllage";
			this.chkGaugeCargoUllage.Size = new System.Drawing.Size(99, 17);
			this.chkGaugeCargoUllage.TabIndex = 1;
			this.chkGaugeCargoUllage.Text = "Cargo Ullage";
			this.chkGaugeCargoUllage.UseVisualStyleBackColor = true;
			// 
			// chkGaugeCargoVolume
			// 
			this.chkGaugeCargoVolume.AutoSize = true;
			this.chkGaugeCargoVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkGaugeCargoVolume.Location = new System.Drawing.Point(6, 80);
			this.chkGaugeCargoVolume.Name = "chkGaugeCargoVolume";
			this.chkGaugeCargoVolume.Size = new System.Drawing.Size(104, 17);
			this.chkGaugeCargoVolume.TabIndex = 2;
			this.chkGaugeCargoVolume.Text = "Cargo Volume";
			this.chkGaugeCargoVolume.UseVisualStyleBackColor = true;
			// 
			// chkGaugePumpManifold
			// 
			this.chkGaugePumpManifold.AutoSize = true;
			this.chkGaugePumpManifold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkGaugePumpManifold.Location = new System.Drawing.Point(203, 149);
			this.chkGaugePumpManifold.Name = "chkGaugePumpManifold";
			this.chkGaugePumpManifold.Size = new System.Drawing.Size(164, 17);
			this.chkGaugePumpManifold.TabIndex = 3;
			this.chkGaugePumpManifold.Text = "Pump/Manifold Pressure";
			this.chkGaugePumpManifold.UseVisualStyleBackColor = true;
			// 
			// chkGaugeAuxiliaryVolume
			// 
			this.chkGaugeAuxiliaryVolume.AutoSize = true;
			this.chkGaugeAuxiliaryVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkGaugeAuxiliaryVolume.Location = new System.Drawing.Point(203, 126);
			this.chkGaugeAuxiliaryVolume.Name = "chkGaugeAuxiliaryVolume";
			this.chkGaugeAuxiliaryVolume.Size = new System.Drawing.Size(118, 17);
			this.chkGaugeAuxiliaryVolume.TabIndex = 4;
			this.chkGaugeAuxiliaryVolume.Text = "Auxiliary Volume";
			this.chkGaugeAuxiliaryVolume.UseVisualStyleBackColor = true;
			// 
			// chkGaugeTemperatureBot
			// 
			this.chkGaugeTemperatureBot.AutoSize = true;
			this.chkGaugeTemperatureBot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkGaugeTemperatureBot.Location = new System.Drawing.Point(6, 172);
			this.chkGaugeTemperatureBot.Name = "chkGaugeTemperatureBot";
			this.chkGaugeTemperatureBot.Size = new System.Drawing.Size(123, 17);
			this.chkGaugeTemperatureBot.TabIndex = 5;
			this.chkGaugeTemperatureBot.Text = "Cargo Temp BOT";
			this.chkGaugeTemperatureBot.UseVisualStyleBackColor = true;
			// 
			// chkGaugeAuxiliaryLevel
			// 
			this.chkGaugeAuxiliaryLevel.AutoSize = true;
			this.chkGaugeAuxiliaryLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkGaugeAuxiliaryLevel.Location = new System.Drawing.Point(203, 103);
			this.chkGaugeAuxiliaryLevel.Name = "chkGaugeAuxiliaryLevel";
			this.chkGaugeAuxiliaryLevel.Size = new System.Drawing.Size(108, 17);
			this.chkGaugeAuxiliaryLevel.TabIndex = 6;
			this.chkGaugeAuxiliaryLevel.Text = "Auxiliary Level";
			this.chkGaugeAuxiliaryLevel.UseVisualStyleBackColor = true;
			// 
			// chkGaugeTemperatureTop
			// 
			this.chkGaugeTemperatureTop.AutoSize = true;
			this.chkGaugeTemperatureTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkGaugeTemperatureTop.Location = new System.Drawing.Point(6, 126);
			this.chkGaugeTemperatureTop.Name = "chkGaugeTemperatureTop";
			this.chkGaugeTemperatureTop.Size = new System.Drawing.Size(123, 17);
			this.chkGaugeTemperatureTop.TabIndex = 7;
			this.chkGaugeTemperatureTop.Text = "Cargo Temp TOP";
			this.chkGaugeTemperatureTop.UseVisualStyleBackColor = true;
			// 
			// chkGaugeBallastVolume
			// 
			this.chkGaugeBallastVolume.AutoSize = true;
			this.chkGaugeBallastVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkGaugeBallastVolume.Location = new System.Drawing.Point(203, 80);
			this.chkGaugeBallastVolume.Name = "chkGaugeBallastVolume";
			this.chkGaugeBallastVolume.Size = new System.Drawing.Size(109, 17);
			this.chkGaugeBallastVolume.TabIndex = 8;
			this.chkGaugeBallastVolume.Text = "Ballast Volume";
			this.chkGaugeBallastVolume.UseVisualStyleBackColor = true;
			// 
			// chkGaugePressure
			// 
			this.chkGaugePressure.AutoSize = true;
			this.chkGaugePressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkGaugePressure.Location = new System.Drawing.Point(6, 195);
			this.chkGaugePressure.Name = "chkGaugePressure";
			this.chkGaugePressure.Size = new System.Drawing.Size(112, 17);
			this.chkGaugePressure.TabIndex = 9;
			this.chkGaugePressure.Text = "Cargo Pressure";
			this.chkGaugePressure.UseVisualStyleBackColor = true;
			// 
			// chkGaugeTemperatureMid
			// 
			this.chkGaugeTemperatureMid.AutoSize = true;
			this.chkGaugeTemperatureMid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkGaugeTemperatureMid.Location = new System.Drawing.Point(6, 149);
			this.chkGaugeTemperatureMid.Name = "chkGaugeTemperatureMid";
			this.chkGaugeTemperatureMid.Size = new System.Drawing.Size(121, 17);
			this.chkGaugeTemperatureMid.TabIndex = 10;
			this.chkGaugeTemperatureMid.Text = "Cargo Temp MID";
			this.chkGaugeTemperatureMid.UseVisualStyleBackColor = true;
			// 
			// chkGaugeAverageTemperature
			// 
			this.chkGaugeAverageTemperature.AutoSize = true;
			this.chkGaugeAverageTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkGaugeAverageTemperature.Location = new System.Drawing.Point(6, 103);
			this.chkGaugeAverageTemperature.Name = "chkGaugeAverageTemperature";
			this.chkGaugeAverageTemperature.Size = new System.Drawing.Size(145, 17);
			this.chkGaugeAverageTemperature.TabIndex = 11;
			this.chkGaugeAverageTemperature.Text = "Cargo Average Temp";
			this.chkGaugeAverageTemperature.UseVisualStyleBackColor = true;
			// 
			// chkGaugeBallastLevel
			// 
			this.chkGaugeBallastLevel.AutoSize = true;
			this.chkGaugeBallastLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkGaugeBallastLevel.Location = new System.Drawing.Point(203, 57);
			this.chkGaugeBallastLevel.Name = "chkGaugeBallastLevel";
			this.chkGaugeBallastLevel.Size = new System.Drawing.Size(99, 17);
			this.chkGaugeBallastLevel.TabIndex = 12;
			this.chkGaugeBallastLevel.Text = "Ballast Level";
			this.chkGaugeBallastLevel.UseVisualStyleBackColor = true;
			// 
			// chkGaugeList
			// 
			this.chkGaugeList.AutoSize = true;
			this.chkGaugeList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkGaugeList.Location = new System.Drawing.Point(388, 103);
			this.chkGaugeList.Name = "chkGaugeList";
			this.chkGaugeList.Size = new System.Drawing.Size(46, 17);
			this.chkGaugeList.TabIndex = 13;
			this.chkGaugeList.Text = "List";
			this.chkGaugeList.UseVisualStyleBackColor = true;
			// 
			// chkGaugeTrim
			// 
			this.chkGaugeTrim.AutoSize = true;
			this.chkGaugeTrim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkGaugeTrim.Location = new System.Drawing.Point(388, 80);
			this.chkGaugeTrim.Name = "chkGaugeTrim";
			this.chkGaugeTrim.Size = new System.Drawing.Size(50, 17);
			this.chkGaugeTrim.TabIndex = 14;
			this.chkGaugeTrim.Text = "Trim";
			this.chkGaugeTrim.UseVisualStyleBackColor = true;
			// 
			// chkGaugeDraft
			// 
			this.chkGaugeDraft.AutoSize = true;
			this.chkGaugeDraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkGaugeDraft.Location = new System.Drawing.Point(388, 57);
			this.chkGaugeDraft.Name = "chkGaugeDraft";
			this.chkGaugeDraft.Size = new System.Drawing.Size(54, 17);
			this.chkGaugeDraft.TabIndex = 15;
			this.chkGaugeDraft.Text = "Draft";
			this.chkGaugeDraft.UseVisualStyleBackColor = true;
			// 
			// grpAlarm
			// 
			this.grpAlarm.Controls.Add(this.chkAlarmAuxilliaryHighLevel);
			this.grpAlarm.Controls.Add(this.chkAlarmAverageTemperature);
			this.grpAlarm.Controls.Add(this.chkAlarmTemperatureTop);
			this.grpAlarm.Controls.Add(this.chkAlarmCargoHighLevel);
			this.grpAlarm.Controls.Add(this.chkAlarmBallastOverfill);
			this.grpAlarm.Controls.Add(this.chkAlarmBallastHighLevel);
			this.grpAlarm.Controls.Add(this.chkAlarmAuxilliaryOverfill);
			this.grpAlarm.Controls.Add(this.chkAlarmTemperatureMid);
			this.grpAlarm.Controls.Add(this.chkAlarmTemperatureBot);
			this.grpAlarm.Controls.Add(this.chkAlarmPressure);
			this.grpAlarm.Controls.Add(this.chkAlarmPump);
			this.grpAlarm.Controls.Add(this.chkAlarmCargoOverfill);
			this.grpAlarm.Location = new System.Drawing.Point(12, 242);
			this.grpAlarm.Name = "grpAlarm";
			this.grpAlarm.Size = new System.Drawing.Size(502, 194);
			this.grpAlarm.TabIndex = 1;
			this.grpAlarm.TabStop = false;
			this.grpAlarm.Text = "Alarms";
			// 
			// chkAlarmCargoOverfill
			// 
			this.chkAlarmCargoOverfill.AutoSize = true;
			this.chkAlarmCargoOverfill.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkAlarmCargoOverfill.Location = new System.Drawing.Point(6, 27);
			this.chkAlarmCargoOverfill.Name = "chkAlarmCargoOverfill";
			this.chkAlarmCargoOverfill.Size = new System.Drawing.Size(103, 17);
			this.chkAlarmCargoOverfill.TabIndex = 0;
			this.chkAlarmCargoOverfill.Text = "Cargo Overfill";
			this.chkAlarmCargoOverfill.UseVisualStyleBackColor = true;
			// 
			// chkAlarmPump
			// 
			this.chkAlarmPump.AutoSize = true;
			this.chkAlarmPump.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkAlarmPump.Location = new System.Drawing.Point(203, 119);
			this.chkAlarmPump.Name = "chkAlarmPump";
			this.chkAlarmPump.Size = new System.Drawing.Size(203, 17);
			this.chkAlarmPump.TabIndex = 1;
			this.chkAlarmPump.Text = "Pump/Manifold Pressure HI/LO";
			this.chkAlarmPump.UseVisualStyleBackColor = true;
			// 
			// chkAlarmPressure
			// 
			this.chkAlarmPressure.AutoSize = true;
			this.chkAlarmPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkAlarmPressure.Location = new System.Drawing.Point(6, 165);
			this.chkAlarmPressure.Name = "chkAlarmPressure";
			this.chkAlarmPressure.Size = new System.Drawing.Size(151, 17);
			this.chkAlarmPressure.TabIndex = 2;
			this.chkAlarmPressure.Text = "Cargo Pressure HI/LO";
			this.chkAlarmPressure.UseVisualStyleBackColor = true;
			// 
			// chkAlarmTemperatureBot
			// 
			this.chkAlarmTemperatureBot.AutoSize = true;
			this.chkAlarmTemperatureBot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkAlarmTemperatureBot.Location = new System.Drawing.Point(6, 142);
			this.chkAlarmTemperatureBot.Name = "chkAlarmTemperatureBot";
			this.chkAlarmTemperatureBot.Size = new System.Drawing.Size(162, 17);
			this.chkAlarmTemperatureBot.TabIndex = 3;
			this.chkAlarmTemperatureBot.Text = "Cargo Temp BOT HI/LO";
			this.chkAlarmTemperatureBot.UseVisualStyleBackColor = true;
			// 
			// chkAlarmTemperatureMid
			// 
			this.chkAlarmTemperatureMid.AutoSize = true;
			this.chkAlarmTemperatureMid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkAlarmTemperatureMid.Location = new System.Drawing.Point(6, 119);
			this.chkAlarmTemperatureMid.Name = "chkAlarmTemperatureMid";
			this.chkAlarmTemperatureMid.Size = new System.Drawing.Size(160, 17);
			this.chkAlarmTemperatureMid.TabIndex = 4;
			this.chkAlarmTemperatureMid.Text = "Cargo Temp MID HI/LO";
			this.chkAlarmTemperatureMid.UseVisualStyleBackColor = true;
			// 
			// chkAlarmAuxilliaryOverfill
			// 
			this.chkAlarmAuxilliaryOverfill.AutoSize = true;
			this.chkAlarmAuxilliaryOverfill.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkAlarmAuxilliaryOverfill.Location = new System.Drawing.Point(203, 71);
			this.chkAlarmAuxilliaryOverfill.Name = "chkAlarmAuxilliaryOverfill";
			this.chkAlarmAuxilliaryOverfill.Size = new System.Drawing.Size(120, 17);
			this.chkAlarmAuxilliaryOverfill.TabIndex = 5;
			this.chkAlarmAuxilliaryOverfill.Text = "Auxilliary Overfill";
			this.chkAlarmAuxilliaryOverfill.UseVisualStyleBackColor = true;
			// 
			// chkAlarmBallastHighLevel
			// 
			this.chkAlarmBallastHighLevel.AutoSize = true;
			this.chkAlarmBallastHighLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkAlarmBallastHighLevel.Location = new System.Drawing.Point(203, 48);
			this.chkAlarmBallastHighLevel.Name = "chkAlarmBallastHighLevel";
			this.chkAlarmBallastHighLevel.Size = new System.Drawing.Size(129, 17);
			this.chkAlarmBallastHighLevel.TabIndex = 6;
			this.chkAlarmBallastHighLevel.Text = "Ballast High Level";
			this.chkAlarmBallastHighLevel.UseVisualStyleBackColor = true;
			// 
			// chkAlarmBallastOverfill
			// 
			this.chkAlarmBallastOverfill.AutoSize = true;
			this.chkAlarmBallastOverfill.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkAlarmBallastOverfill.Location = new System.Drawing.Point(203, 27);
			this.chkAlarmBallastOverfill.Name = "chkAlarmBallastOverfill";
			this.chkAlarmBallastOverfill.Size = new System.Drawing.Size(108, 17);
			this.chkAlarmBallastOverfill.TabIndex = 7;
			this.chkAlarmBallastOverfill.Text = "Ballast Overfill";
			this.chkAlarmBallastOverfill.UseVisualStyleBackColor = true;
			// 
			// chkAlarmCargoHighLevel
			// 
			this.chkAlarmCargoHighLevel.AutoSize = true;
			this.chkAlarmCargoHighLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkAlarmCargoHighLevel.Location = new System.Drawing.Point(6, 50);
			this.chkAlarmCargoHighLevel.Name = "chkAlarmCargoHighLevel";
			this.chkAlarmCargoHighLevel.Size = new System.Drawing.Size(124, 17);
			this.chkAlarmCargoHighLevel.TabIndex = 8;
			this.chkAlarmCargoHighLevel.Text = "Cargo High Level";
			this.chkAlarmCargoHighLevel.UseVisualStyleBackColor = true;
			// 
			// chkAlarmTemperatureTop
			// 
			this.chkAlarmTemperatureTop.AutoSize = true;
			this.chkAlarmTemperatureTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkAlarmTemperatureTop.Location = new System.Drawing.Point(6, 96);
			this.chkAlarmTemperatureTop.Name = "chkAlarmTemperatureTop";
			this.chkAlarmTemperatureTop.Size = new System.Drawing.Size(162, 17);
			this.chkAlarmTemperatureTop.TabIndex = 9;
			this.chkAlarmTemperatureTop.Text = "Cargo Temp TOP HI/LO";
			this.chkAlarmTemperatureTop.UseVisualStyleBackColor = true;
			// 
			// chkAlarmAverageTemperature
			// 
			this.chkAlarmAverageTemperature.AutoSize = true;
			this.chkAlarmAverageTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkAlarmAverageTemperature.Location = new System.Drawing.Point(6, 73);
			this.chkAlarmAverageTemperature.Name = "chkAlarmAverageTemperature";
			this.chkAlarmAverageTemperature.Size = new System.Drawing.Size(184, 17);
			this.chkAlarmAverageTemperature.TabIndex = 10;
			this.chkAlarmAverageTemperature.Text = "Cargo Average Temp HI/LO";
			this.chkAlarmAverageTemperature.UseVisualStyleBackColor = true;
			// 
			// chkAlarmAuxilliaryHighLevel
			// 
			this.chkAlarmAuxilliaryHighLevel.AutoSize = true;
			this.chkAlarmAuxilliaryHighLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkAlarmAuxilliaryHighLevel.Location = new System.Drawing.Point(203, 94);
			this.chkAlarmAuxilliaryHighLevel.Name = "chkAlarmAuxilliaryHighLevel";
			this.chkAlarmAuxilliaryHighLevel.Size = new System.Drawing.Size(141, 17);
			this.chkAlarmAuxilliaryHighLevel.TabIndex = 11;
			this.chkAlarmAuxilliaryHighLevel.Text = "Auxilliary High Level";
			this.chkAlarmAuxilliaryHighLevel.UseVisualStyleBackColor = true;
			// 
			// cboGaugeDataType
			// 
			this.cboGaugeDataType.FormattingEnabled = true;
			this.cboGaugeDataType.Location = new System.Drawing.Point(116, 23);
			this.cboGaugeDataType.Name = "cboGaugeDataType";
			this.cboGaugeDataType.Size = new System.Drawing.Size(121, 21);
			this.cboGaugeDataType.TabIndex = 17;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(3, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 13);
			this.label1.TabIndex = 18;
			this.label1.Text = "Gauge Data Type";
			// 
			// cmdOk
			// 
			this.cmdOk.Location = new System.Drawing.Point(358, 443);
			this.cmdOk.Name = "cmdOk";
			this.cmdOk.Size = new System.Drawing.Size(75, 23);
			this.cmdOk.TabIndex = 2;
			this.cmdOk.Text = "Ok";
			this.cmdOk.UseVisualStyleBackColor = true;
			// 
			// cmdCancel
			// 
			this.cmdCancel.Location = new System.Drawing.Point(439, 443);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 3;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.UseVisualStyleBackColor = true;
			// 
			// ModbusAutoAssign
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(526, 472);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOk);
			this.Controls.Add(this.grpAlarm);
			this.Controls.Add(this.grpGauges);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ModbusAutoAssign";
			this.Text = "Auto Assign Registers";
			this.grpGauges.ResumeLayout(false);
			this.grpGauges.PerformLayout();
			this.grpAlarm.ResumeLayout(false);
			this.grpAlarm.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grpGauges;
		private System.Windows.Forms.CheckBox chkGaugeBallastLevel;
		private System.Windows.Forms.CheckBox chkGaugeAverageTemperature;
		private System.Windows.Forms.CheckBox chkGaugeTemperatureMid;
		private System.Windows.Forms.CheckBox chkGaugePressure;
		private System.Windows.Forms.CheckBox chkGaugeBallastVolume;
		private System.Windows.Forms.CheckBox chkGaugeTemperatureTop;
		private System.Windows.Forms.CheckBox chkGaugeAuxiliaryLevel;
		private System.Windows.Forms.CheckBox chkGaugeTemperatureBot;
		private System.Windows.Forms.CheckBox chkGaugeAuxiliaryVolume;
		private System.Windows.Forms.CheckBox chkGaugePumpManifold;
		private System.Windows.Forms.CheckBox chkGaugeCargoVolume;
		private System.Windows.Forms.CheckBox chkGaugeCargoUllage;
		private System.Windows.Forms.CheckBox chkGaugeDraft;
		private System.Windows.Forms.CheckBox chkGaugeTrim;
		private System.Windows.Forms.CheckBox chkGaugeList;
		private System.Windows.Forms.ComboBox cboGaugeDataType;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox grpAlarm;
		private System.Windows.Forms.CheckBox chkAlarmAuxilliaryHighLevel;
		private System.Windows.Forms.CheckBox chkAlarmAverageTemperature;
		private System.Windows.Forms.CheckBox chkAlarmTemperatureTop;
		private System.Windows.Forms.CheckBox chkAlarmCargoHighLevel;
		private System.Windows.Forms.CheckBox chkAlarmBallastOverfill;
		private System.Windows.Forms.CheckBox chkAlarmBallastHighLevel;
		private System.Windows.Forms.CheckBox chkAlarmAuxilliaryOverfill;
		private System.Windows.Forms.CheckBox chkAlarmTemperatureMid;
		private System.Windows.Forms.CheckBox chkAlarmTemperatureBot;
		private System.Windows.Forms.CheckBox chkAlarmPressure;
		private System.Windows.Forms.CheckBox chkAlarmPump;
		private System.Windows.Forms.CheckBox chkAlarmCargoOverfill;
		private System.Windows.Forms.Button cmdOk;
		private System.Windows.Forms.Button cmdCancel;
	}
}