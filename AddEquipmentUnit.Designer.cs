namespace TLIConfiguration
{
	partial class AddEquipmentUnit
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
			this.lblEquipmentName = new System.Windows.Forms.Label();
			this.lblEquipmentType = new System.Windows.Forms.Label();
			this.lblEquipmentLocation = new System.Windows.Forms.Label();
			this.txtEquipmentName = new System.Windows.Forms.TextBox();
			this.cboEquipmentType = new System.Windows.Forms.ComboBox();
			this.cboEquipmentLocation = new System.Windows.Forms.ComboBox();
			this.groupBoxEquipmentUnit = new System.Windows.Forms.GroupBox();
			this.cmdOk = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.groupBoxEquipmentUnit.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblEquipmentName
			// 
			this.lblEquipmentName.AutoSize = true;
			this.lblEquipmentName.Location = new System.Drawing.Point(6, 19);
			this.lblEquipmentName.Name = "lblEquipmentName";
			this.lblEquipmentName.Size = new System.Drawing.Size(35, 13);
			this.lblEquipmentName.TabIndex = 0;
			this.lblEquipmentName.Text = "Name";
			// 
			// lblEquipmentType
			// 
			this.lblEquipmentType.AutoSize = true;
			this.lblEquipmentType.Location = new System.Drawing.Point(6, 45);
			this.lblEquipmentType.Name = "lblEquipmentType";
			this.lblEquipmentType.Size = new System.Drawing.Size(31, 13);
			this.lblEquipmentType.TabIndex = 2;
			this.lblEquipmentType.Text = "Type";
			// 
			// lblEquipmentLocation
			// 
			this.lblEquipmentLocation.AutoSize = true;
			this.lblEquipmentLocation.Location = new System.Drawing.Point(6, 71);
			this.lblEquipmentLocation.Name = "lblEquipmentLocation";
			this.lblEquipmentLocation.Size = new System.Drawing.Size(48, 13);
			this.lblEquipmentLocation.TabIndex = 3;
			this.lblEquipmentLocation.Text = "Location";
			// 
			// txtEquipmentName
			// 
			this.txtEquipmentName.Location = new System.Drawing.Point(87, 15);
			this.txtEquipmentName.MaxLength = 12;
			this.txtEquipmentName.Name = "txtEquipmentName";
			this.txtEquipmentName.Size = new System.Drawing.Size(139, 20);
			this.txtEquipmentName.TabIndex = 0;
			// 
			// cboEquipmentType
			// 
			this.cboEquipmentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboEquipmentType.FormattingEnabled = true;
			this.cboEquipmentType.Location = new System.Drawing.Point(87, 41);
			this.cboEquipmentType.Name = "cboEquipmentType";
			this.cboEquipmentType.Size = new System.Drawing.Size(139, 21);
			this.cboEquipmentType.TabIndex = 1;
			// 
			// cboEquipmentLocation
			// 
			this.cboEquipmentLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboEquipmentLocation.FormattingEnabled = true;
			this.cboEquipmentLocation.Location = new System.Drawing.Point(87, 67);
			this.cboEquipmentLocation.Name = "cboEquipmentLocation";
			this.cboEquipmentLocation.Size = new System.Drawing.Size(139, 21);
			this.cboEquipmentLocation.TabIndex = 2;
			// 
			// groupBoxEquipmentUnit
			// 
			this.groupBoxEquipmentUnit.Controls.Add(this.lblEquipmentType);
			this.groupBoxEquipmentUnit.Controls.Add(this.cboEquipmentLocation);
			this.groupBoxEquipmentUnit.Controls.Add(this.txtEquipmentName);
			this.groupBoxEquipmentUnit.Controls.Add(this.cboEquipmentType);
			this.groupBoxEquipmentUnit.Controls.Add(this.lblEquipmentName);
			this.groupBoxEquipmentUnit.Controls.Add(this.lblEquipmentLocation);
			this.groupBoxEquipmentUnit.Location = new System.Drawing.Point(7, 2);
			this.groupBoxEquipmentUnit.Name = "groupBoxEquipmentUnit";
			this.groupBoxEquipmentUnit.Size = new System.Drawing.Size(236, 96);
			this.groupBoxEquipmentUnit.TabIndex = 8;
			this.groupBoxEquipmentUnit.TabStop = false;
			// 
			// cmdOk
			// 
			this.cmdOk.Location = new System.Drawing.Point(87, 104);
			this.cmdOk.Name = "cmdOk";
			this.cmdOk.Size = new System.Drawing.Size(75, 23);
			this.cmdOk.TabIndex = 9;
			this.cmdOk.Text = "Ok";
			this.cmdOk.UseVisualStyleBackColor = true;
			this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.Location = new System.Drawing.Point(168, 104);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 10;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.UseVisualStyleBackColor = true;
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// AddEquipmentUnit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(250, 130);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOk);
			this.Controls.Add(this.groupBoxEquipmentUnit);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "AddEquipmentUnit";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Paste Equipment Unit";
			this.Load += new System.EventHandler(this.AddEquipmentUnit_Load);
			this.groupBoxEquipmentUnit.ResumeLayout(false);
			this.groupBoxEquipmentUnit.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblEquipmentName;
		private System.Windows.Forms.Label lblEquipmentType;
		private System.Windows.Forms.Label lblEquipmentLocation;
		private System.Windows.Forms.TextBox txtEquipmentName;
		private System.Windows.Forms.ComboBox cboEquipmentType;
		private System.Windows.Forms.ComboBox cboEquipmentLocation;
		private System.Windows.Forms.GroupBox groupBoxEquipmentUnit;
		private System.Windows.Forms.Button cmdOk;
		private System.Windows.Forms.Button cmdCancel;
	}
}