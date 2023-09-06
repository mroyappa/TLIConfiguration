namespace TLIConfiguration
{
	partial class RedundantAMUPointExceptions
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RedundantAMUPointExceptions));
			this.cmdOk = new System.Windows.Forms.Button();
			this.customXceedGridControl = new CustomXceedGridControl();
			this.dataRowTemplate1 = new Xceed.Grid.DataRow();
			this.columnManagerRow1 = new Xceed.Grid.ColumnManagerRow();
			this.group1 = new Xceed.Grid.Group();
			this.groupManagerRow1 = new Xceed.Grid.GroupManagerRow();
			((System.ComponentModel.ISupportInitialize)(this.customXceedGridControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataRowTemplate1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.columnManagerRow1)).BeginInit();
			this.SuspendLayout();
			// 
			// cmdOk
			// 
			this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdOk.Location = new System.Drawing.Point(435, 445);
			this.cmdOk.Name = "cmdOk";
			this.cmdOk.Size = new System.Drawing.Size(75, 23);
			this.cmdOk.TabIndex = 0;
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
			this.customXceedGridControl.GroupTemplates.Add(this.group1);
			this.customXceedGridControl.InsertedRowColor = System.Drawing.Color.Empty;
			this.customXceedGridControl.Location = new System.Drawing.Point(11, 12);
			this.customXceedGridControl.Name = "customXceedGridControl";
			this.customXceedGridControl.ResetDataMemberDelegate = null;
			this.customXceedGridControl.ShowFocusRectangle = false;
			this.customXceedGridControl.Size = new System.Drawing.Size(503, 427);
			this.customXceedGridControl.TabIndex = 8;
			this.customXceedGridControl.UIStyle = Xceed.UI.UIStyle.WindowsClassic;
			this.customXceedGridControl.UIVirtualizationMode = Xceed.Grid.UIVirtualizationMode.Cells;
			this.customXceedGridControl.UpdateDataMemberDelegate = null;
			this.customXceedGridControl.UpdatedRowColor = System.Drawing.Color.Empty;
			// 
			// group1
			// 
			this.group1.HeaderRows.Add(this.groupManagerRow1);
			// 
			// RedundantAMUPointExceptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(525, 474);
			this.Controls.Add(this.customXceedGridControl);
			this.Controls.Add(this.cmdOk);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "RedundantAMUPointExceptions";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AMU Channel Exceptions";
			this.Load += new System.EventHandler(this.RedundantAMUPointExceptions_Load);
			((System.ComponentModel.ISupportInitialize)(this.customXceedGridControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataRowTemplate1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.columnManagerRow1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button cmdOk;
		private CustomXceedGridControl customXceedGridControl;
		private Xceed.Grid.DataRow dataRowTemplate1;
		private Xceed.Grid.ColumnManagerRow columnManagerRow1;
		private Xceed.Grid.Group group1;
		private Xceed.Grid.GroupManagerRow groupManagerRow1;
	}
}