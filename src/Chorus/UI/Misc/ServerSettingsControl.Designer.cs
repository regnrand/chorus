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
			this._customAddress = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this._serverCombo = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this._customAddressLabel = new System.Windows.Forms.Label();
			this._changeProjectLink = new System.Windows.Forms.LinkLabel();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			//
			// _projectIdLabel
			//
			this._projectIdLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this._projectIdLabel.AutoSize = true;
			this._projectIdLabel.Location = new System.Drawing.Point(23, 43);
			this._projectIdLabel.Name = "_projectIdLabel";
			this._projectIdLabel.Size = new System.Drawing.Size(54, 13);
			this._projectIdLabel.TabIndex = 26;
			this._projectIdLabel.Text = "Project ID";
			//
			// _projectId
			//
			this._projectId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this._projectId.BackColor = System.Drawing.SystemColors.HighlightText;
			this._projectId.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._projectId.Location = new System.Drawing.Point(83, 43);
			this._projectId.Name = "_projectId";
			this._projectId.ReadOnly = true;
			this._projectId.Size = new System.Drawing.Size(216, 13);
			this._projectId.TabIndex = 0;
			this.toolTip1.SetToolTip(this._projectId, "Usually the Ethnologue code, e.g. \'tpi\'");
			//
			// _customAddress
			//
			this._customAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this._customAddress.Location = new System.Drawing.Point(83, 73);
			this._customAddress.Name = "_customAddress";
			this._customAddress.Size = new System.Drawing.Size(216, 20);
			this._customAddress.TabIndex = 29;
			this.toolTip1.SetToolTip(this._customAddress, "The full address of the custom url for this project");
			this._customAddress.TextChanged += new System.EventHandler(this.CustomAddressTextChanged);
			//
			// tableLayoutPanel1
			//
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this._serverCombo, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this._projectIdLabel, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this._projectId, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this._customAddress, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this._customAddressLabel, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this._changeProjectLink, 2, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33111F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33111F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33777F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(374, 100);
			this.tableLayoutPanel1.TabIndex = 30;
			//
			// _serverCombo
			//
			this._serverCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this._serverCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._serverCombo.FormattingEnabled = true;
			this._serverCombo.Location = new System.Drawing.Point(83, 6);
			this._serverCombo.Name = "_serverCombo";
			this._serverCombo.Size = new System.Drawing.Size(216, 21);
			this._serverCombo.TabIndex = 6;
			//
			// label1
			//
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(39, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 27;
			this.label1.Text = "Server";
			//
			// _customAddressLabel
			//
			this._customAddressLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this._customAddressLabel.AutoSize = true;
			this._customAddressLabel.Location = new System.Drawing.Point(32, 76);
			this._customAddressLabel.Name = "_customAddressLabel";
			this._customAddressLabel.Size = new System.Drawing.Size(45, 13);
			this._customAddressLabel.TabIndex = 28;
			this._customAddressLabel.Text = "Address";
			//
			// _changeProjectLink
			//
			this._changeProjectLink.AutoSize = true;
			this._changeProjectLink.Dock = System.Windows.Forms.DockStyle.Fill;
			this._changeProjectLink.Location = new System.Drawing.Point(305, 33);
			this._changeProjectLink.Name = "_changeProjectLink";
			this._changeProjectLink.Size = new System.Drawing.Size(66, 33);
			this._changeProjectLink.TabIndex = 30;
			this._changeProjectLink.TabStop = true;
			this._changeProjectLink.Text = "Change...";
			this._changeProjectLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._changeProjectLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ChangeProjectLinkClicked);
			//
			// ServerSettingsControl
			//
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.tableLayoutPanel1);
			this.MinimumSize = new System.Drawing.Size(363, 200);
			this.Name = "ServerSettingsControl";
			this.Size = new System.Drawing.Size(422, 200);
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
		private System.Windows.Forms.LinkLabel _changeProjectLink;
	}
}
