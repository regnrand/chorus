﻿namespace Chorus.UI.Sync
{
	partial class SyncStartControl
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
			this._useSharedFolderButton = new System.Windows.Forms.Button();
			this._useInternetButton = new System.Windows.Forms.Button();
			this._useUSBButton = new System.Windows.Forms.Button();
			this._updateDisplayTimer = new System.Windows.Forms.Timer(this.components);
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this._usbStatusLabel = new Chorus.UI.BetterLabel();
			this._internetStatusLabel = new Chorus.UI.BetterLabel();
			this._sharedFolderLabel = new Chorus.UI.BetterLabel();
			this.betterLabel1 = new Chorus.UI.BetterLabel();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			//
			// _useSharedFolderButton
			//
			this._useSharedFolderButton.Enabled = false;
			this._useSharedFolderButton.Image = global::Chorus.Properties.Resources.networkFolder29x32;
			this._useSharedFolderButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._useSharedFolderButton.Location = new System.Drawing.Point(3, 183);
			this._useSharedFolderButton.Name = "_useSharedFolderButton";
			this._useSharedFolderButton.Size = new System.Drawing.Size(167, 39);
			this._useSharedFolderButton.TabIndex = 0;
			this._useSharedFolderButton.Text = "&Shared Network Folder";
			this._useSharedFolderButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this._useSharedFolderButton.UseVisualStyleBackColor = true;
			this._useSharedFolderButton.Click += new System.EventHandler(this._useSharedFolderButton_Click);
			//
			// _useInternetButton
			//
			this._useInternetButton.Image = global::Chorus.Properties.Resources.internet29x32;
			this._useInternetButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._useInternetButton.Location = new System.Drawing.Point(3, 93);
			this._useInternetButton.Name = "_useInternetButton";
			this._useInternetButton.Size = new System.Drawing.Size(167, 39);
			this._useInternetButton.TabIndex = 0;
			this._useInternetButton.Text = "&Internet";
			this._useInternetButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this._useInternetButton.UseVisualStyleBackColor = true;
			this._useInternetButton.Click += new System.EventHandler(this._useInternetButton_Click);
			//
			// _useUSBButton
			//
			this._useUSBButton.Image = global::Chorus.Properties.Resources.Usb32x28;
			this._useUSBButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._useUSBButton.Location = new System.Drawing.Point(3, 3);
			this._useUSBButton.Name = "_useUSBButton";
			this._useUSBButton.Size = new System.Drawing.Size(167, 39);
			this._useUSBButton.TabIndex = 0;
			this._useUSBButton.Text = "&USB Flash Drive";
			this._useUSBButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this._useUSBButton.UseVisualStyleBackColor = true;
			this._useUSBButton.Click += new System.EventHandler(this._useUSBButton_Click);
			//
			// _updateDisplayTimer
			//
			this._updateDisplayTimer.Enabled = true;
			this._updateDisplayTimer.Interval = 500;
			this._updateDisplayTimer.Tick += new System.EventHandler(this.OnUpdateDisplayTick);
			//
			// tableLayoutPanel1
			//
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this._useUSBButton, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this._usbStatusLabel, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this._internetStatusLabel, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this._sharedFolderLabel, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this._useInternetButton, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this._useSharedFolderButton, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.betterLabel1, 0, 6);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 7;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(330, 292);
			this.tableLayoutPanel1.TabIndex = 2;
			//
			// _usbStatusLabel
			//
			this._usbStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._usbStatusLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._usbStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._usbStatusLabel.ForeColor = System.Drawing.Color.DimGray;
			this._usbStatusLabel.Location = new System.Drawing.Point(3, 48);
			this._usbStatusLabel.Multiline = true;
			this._usbStatusLabel.Name = "_usbStatusLabel";
			this._usbStatusLabel.ReadOnly = true;
			this._usbStatusLabel.Size = new System.Drawing.Size(324, 39);
			this._usbStatusLabel.TabIndex = 1;
			this._usbStatusLabel.TabStop = false;
			this._usbStatusLabel.Text = "usb";
			//
			// _internetStatusLabel
			//
			this._internetStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._internetStatusLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._internetStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._internetStatusLabel.ForeColor = System.Drawing.Color.DimGray;
			this._internetStatusLabel.Location = new System.Drawing.Point(3, 138);
			this._internetStatusLabel.Multiline = true;
			this._internetStatusLabel.Name = "_internetStatusLabel";
			this._internetStatusLabel.ReadOnly = true;
			this._internetStatusLabel.Size = new System.Drawing.Size(324, 39);
			this._internetStatusLabel.TabIndex = 1;
			this._internetStatusLabel.TabStop = false;
			this._internetStatusLabel.Text = "internet";
			//
			// _sharedFolderLabel
			//
			this._sharedFolderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._sharedFolderLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._sharedFolderLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this._sharedFolderLabel.ForeColor = System.Drawing.Color.DimGray;
			this._sharedFolderLabel.Location = new System.Drawing.Point(3, 228);
			this._sharedFolderLabel.Multiline = true;
			this._sharedFolderLabel.Name = "_sharedFolderLabel";
			this._sharedFolderLabel.ReadOnly = true;
			this._sharedFolderLabel.Size = new System.Drawing.Size(324, 39);
			this._sharedFolderLabel.TabIndex = 1;
			this._sharedFolderLabel.TabStop = false;
			this._sharedFolderLabel.Text = "shared";
			//
			// betterLabel1
			//
			this.betterLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.betterLabel1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.betterLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.betterLabel1.Location = new System.Drawing.Point(3, 273);
			this.betterLabel1.Multiline = true;
			this.betterLabel1.Name = "betterLabel1";
			this.betterLabel1.ReadOnly = true;
			this.betterLabel1.Size = new System.Drawing.Size(324, 16);
			this.betterLabel1.TabIndex = 2;
			this.betterLabel1.TabStop = false;
			//
			// SyncStartControl
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "SyncStartControl";
			this.Size = new System.Drawing.Size(330, 292);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button _useUSBButton;
		private System.Windows.Forms.Button _useInternetButton;
		private System.Windows.Forms.Button _useSharedFolderButton;
		private System.Windows.Forms.Timer _updateDisplayTimer;
		private BetterLabel _usbStatusLabel;
		private BetterLabel _internetStatusLabel;
		private BetterLabel _sharedFolderLabel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ToolTip toolTip1;
		private BetterLabel betterLabel1;
	}
}