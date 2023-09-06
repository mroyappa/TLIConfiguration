namespace TLIConfiguration
{
	partial class ModularBubblerEZTEdit
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModularBubblerEZTEdit));
			this.cboModularBubblerAddress = new System.Windows.Forms.ComboBox();
			this.lblModularBubblerAddress = new System.Windows.Forms.Label();
			this.customXceedGridControl = new CustomXceedGridControl();
			this.dataRowTemplate1 = new Xceed.Grid.DataRow();
			this.columnManagerRow1 = new Xceed.Grid.ColumnManagerRow();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOk = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.customXceedGridControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataRowTemplate1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.columnManagerRow1)).BeginInit();
			this.SuspendLayout();
			// 
			// cboModularBubblerAddress
			// 
			this.cboModularBubblerAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboModularBubblerAddress.FormattingEnabled = true;
			this.cboModularBubblerAddress.Location = new System.Drawing.Point(166, 20);
			this.cboModularBubblerAddress.Name = "cboModularBubblerAddress";
			this.cboModularBubblerAddress.Size = new System.Drawing.Size(81, 21);
			this.cboModularBubblerAddress.TabIndex = 13;
			this.cboModularBubblerAddress.SelectedIndexChanged += new System.EventHandler(this.cboModularBubblerAddress_SelectedIndexChanged);
			// 
			// lblModularBubblerAddress
			// 
			this.lblModularBubblerAddress.AutoSize = true;
			this.lblModularBubblerAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblModularBubblerAddress.Location = new System.Drawing.Point(12, 24);
			this.lblModularBubblerAddress.Name = "lblModularBubblerAddress";
			this.lblModularBubblerAddress.Size = new System.Drawing.Size(148, 13);
			this.lblModularBubblerAddress.TabIndex = 12;
			this.lblModularBubblerAddress.Text = "Modular Bubbler Address";
			// 
			// customXceedGridControl
			// 
			this.customXceedGridControl.AllowDelete = true;
			this.customXceedGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.customXceedGridControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.customXceedGridControl.ClipCurrentCellSelection = false;
			this.customXceedGridControl.DataRowTemplate = this.dataRowTemplate1;
			this.customXceedGridControl.DeletedRowColor = System.Drawing.Color.Empty;
			this.customXceedGridControl.ExpandToFitColumn = null;
			this.customXceedGridControl.FillDataMemberDelegate = null;
			this.customXceedGridControl.FixedHeaderRows.Add(this.columnManagerRow1);
			this.customXceedGridControl.InsertedRowColor = System.Drawing.Color.Empty;
			this.customXceedGridControl.Location = new System.Drawing.Point(11, 47);
			this.customXceedGridControl.Name = "customXceedGridControl";
			this.customXceedGridControl.ResetDataMemberDelegate = null;
			this.customXceedGridControl.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.customXceedGridControl.ShowFocusRectangle = false;
			this.customXceedGridControl.Size = new System.Drawing.Size(1356, 189);
			this.customXceedGridControl.TabIndex = 11;
			this.customXceedGridControl.UIStyle = Xceed.UI.UIStyle.WindowsClassic;
			this.customXceedGridControl.UIVirtualizationMode = Xceed.Grid.UIVirtualizationMode.Cells;
			this.customXceedGridControl.UpdateDataMemberDelegate = null;
			this.customXceedGridControl.UpdatedRowColor = System.Drawing.Color.Empty;
			this.customXceedGridControl.AddingDataRow += new Xceed.Grid.AddingDataRowEventHandler(this.customXceedGridControl_AddingDataRow);
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(1292, 242);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 15;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.UseVisualStyleBackColor = true;
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOk
			// 
			this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdOk.Location = new System.Drawing.Point(1211, 242);
			this.cmdOk.Name = "cmdOk";
			this.cmdOk.Size = new System.Drawing.Size(75, 23);
			this.cmdOk.TabIndex = 14;
			this.cmdOk.Text = "Ok";
			this.cmdOk.UseVisualStyleBackColor = true;
			this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
			// 
			// ModularBubblerEZTEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1379, 277);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOk);
			this.Controls.Add(this.cboModularBubblerAddress);
			this.Controls.Add(this.lblModularBubblerAddress);
			this.Controls.Add(this.customXceedGridControl);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ModularBubblerEZTEdit";
			this.Text = "Modular Bubbler EZT Configuration";
			this.Load += new System.EventHandler(this.ModularBubblerEZTEdit_Load);
			((System.ComponentModel.ISupportInitialize)(this.customXceedGridControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataRowTemplate1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.columnManagerRow1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cboModularBubblerAddress;
		private System.Windows.Forms.Label lblModularBubblerAddress;
		private CustomXceedGridControl customXceedGridControl;
		private Xceed.Grid.DataRow dataRowTemplate1;
		private Xceed.Grid.ColumnManagerRow columnManagerRow1;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOk;
	}
}