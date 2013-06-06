namespace Chorus.UI.Misc
{
	partial class ServerSettingsControl
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

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this._projectIdLabel = new System.Windows.Forms.Label();
			this._projectId = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this._serverCombo = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this._customAddressLabel = new System.Windows.Forms.Label();
			this._customAddress = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			//
			// _projectIdLabel
			//
			this._projectIdLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this._projectIdLabel.AutoSize = true;
			this._projectIdLabel.Location = new System.Drawing.Point(23, 40);
			this._projectIdLabel.Name = "_projectIdLabel";
			this._projectIdLabel.Size = new System.Drawing.Size(54, 13);
			this._projectIdLabel.TabIndex = 26;
			this._projectIdLabel.Text = "Project ID";
			//
			// _projectId
			//
			this._projectId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this._projectId.Location = new System.Drawing.Point(83, 36);
			this._projectId.Name = "_projectId";
			this._projectId.Size = new System.Drawing.Size(263, 20);
			this._projectId.TabIndex = 0;
			this.toolTip1.SetToolTip(this._projectId, "Usually the Ethnologue code, e.g. \'tpi\'");
			this._projectId.TextChanged += new System.EventHandler(this._projectId_TextChanged);
			//
			// tableLayoutPanel1
			//
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this._serverCombo, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this._projectIdLabel, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this._projectId, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this._customAddress, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this._customAddressLabel, 0, 2);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33111F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33111F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33777F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(349, 96);
			this.tableLayoutPanel1.TabIndex = 30;
			//
			// _serverCombo
			//
			this._serverCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this._serverCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._serverCombo.FormattingEnabled = true;
			this._serverCombo.Location = new System.Drawing.Point(83, 5);
			this._serverCombo.Name = "_serverCombo";
			this._serverCombo.Size = new System.Drawing.Size(263, 21);
			this._serverCombo.TabIndex = 6;
			//
			// label1
			//
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(39, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 27;
			this.label1.Text = "Server";
			//
			// _customAddressLabel
			//
			this._customAddressLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this._customAddressLabel.AutoSize = true;
			this._customAddressLabel.Location = new System.Drawing.Point(32, 72);
			this._customAddressLabel.Name = "_customAddressLabel";
			this._customAddressLabel.Size = new System.Drawing.Size(45, 13);
			this._customAddressLabel.TabIndex = 28;
			this._customAddressLabel.Text = "Address";
			//
			// _customAddress
			//
			this._customAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this._customAddress.Location = new System.Drawing.Point(83, 69);
			this._customAddress.Name = "_customAddress";
			this._customAddress.Size = new System.Drawing.Size(263, 20);
			this._customAddress.TabIndex = 29;
			this.toolTip1.SetToolTip(this._customAddress, "Usually the Ethnologue code, e.g. \'tpi\'");
			//
			// ServerSettingsControl
			//
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.tableLayoutPanel1);
			this.MinimumSize = new System.Drawing.Size(363, 200);
			this.Name = "ServerSettingsControl";
			this.Size = new System.Drawing.Size(363, 200);
			this.Load += new System.EventHandler(this.OnLoad);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label _projectIdLabel;
		private System.Windows.Forms.TextBox _projectId;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ComboBox _serverCombo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox _customAddress;
		private System.Windows.Forms.Label _customAddressLabel;
	}
}
