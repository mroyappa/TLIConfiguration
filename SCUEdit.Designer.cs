namespace TLIConfiguration
{
	partial class SCUEdit 
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCUEdit));
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOk = new System.Windows.Forms.Button();
			this.customXceedGridControl = new CustomXceedGridControl();
			this.dataRowTemplate1 = new Xceed.Grid.DataRow();
			this.columnManagerRow1 = new Xceed.Grid.ColumnManagerRow();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.customXceedGridControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataRowTemplate1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.columnManagerRow1)).BeginInit();
			this.SuspendLayout();
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(1166, 477);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(75, 23);
			this.cmdCancel.TabIndex = 8;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.UseVisualStyleBackColor = true;
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOk
			// 
			this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdOk.Location = new System.Drawing.Point(1085, 477);
			this.cmdOk.Name = "cmdOk";
			this.cmdOk.Size = new System.Drawing.Size(75, 23);
			this.cmdOk.TabIndex = 7;
			this.cmdOk.Text = "Ok";
			this.cmdOk.UseVisualStyleBackColor = true;
			this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
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
			this.customXceedGridControl.Location = new System.Drawing.Point(11, 12);
			this.customXceedGridControl.Name = "customXceedGridControl";
			this.customXceedGridControl.ResetDataMemberDelegate = null;
			this.customXceedGridControl.ShowFocusRectangle = false;
			this.customXceedGridControl.Size = new System.Drawing.Size(1230, 459);
			this.customXceedGridControl.TabIndex = 5;
			this.toolTip.SetToolTip(this.customXceedGridControl, "SCU Configuration - Configuration data for SCUs used for gauging in a Configurabl" +
					"e TLI installation.");
			this.customXceedGridControl.UIStyle = Xceed.UI.UIStyle.WindowsClassic;
			this.customXceedGridControl.UIVirtualizationMode = Xceed.Grid.UIVirtualizationMode.Cells;
			this.customXceedGridControl.UpdateDataMemberDelegate = null;
			this.customXceedGridControl.UpdatedRowColor = System.Drawing.Color.Empty;
			this.customXceedGridControl.AddingDataRow += new Xceed.Grid.AddingDataRowEventHandler(this.AddingDataRow);
			// 
			// toolTip
			// 
			this.toolTip.AutoPopDelay = 10000;
			this.toolTip.InitialDelay = 500;
			this.toolTip.IsBalloon = true;
			this.toolTip.ReshowDelay = 100;
			// 
			// SCUEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(1254, 505);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOk);
			this.Controls.Add(this.customXceedGridControl);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SCUEdit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SCU Configuration";
			this.Load += new System.EventHandler(this.SCUEdit_Load);
			((System.ComponentModel.ISupportInitialize)(this.customXceedGridControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataRowTemplate1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.columnManagerRow1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private CustomXceedGridControl customXceedGridControl;
		private Xceed.Grid.DataRow dataRowTemplate1;
		private Xceed.Grid.ColumnManagerRow columnManagerRow1;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOk;
		private System.Windows.Forms.ToolTip toolTip;
	}
}