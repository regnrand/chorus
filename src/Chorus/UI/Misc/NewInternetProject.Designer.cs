namespace Chorus.UI.Misc
{
	partial class NewInternetProject
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
			this._description = new System.Windows.Forms.TextBox();
			this._emailLabel = new System.Windows.Forms.Label();
			this._email = new System.Windows.Forms.TextBox();
			this._requirePassword = new System.Windows.Forms.CheckBox();
			this._password = new System.Windows.Forms.TextBox();
			this._projectID = new System.Windows.Forms.RichTextBox();
			this._changeProjectId = new System.Windows.Forms.LinkLabel();
			this._cancelButton = new System.Windows.Forms.Button();
			this._okButton = new System.Windows.Forms.Button();
			this.serverLabel = new System.Windows.Forms.Label();
			this._serverCombobox = new System.Windows.Forms.ComboBox();
			this._customUrlLabel = new System.Windows.Forms.Label();
			this._customUrl = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			//
			// _description
			//
			this._description.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._description.Location = new System.Drawing.Point(16, 7);
			this._description.Multiline = true;
			this._description.Name = "_description";
			this._description.ReadOnly = true;
			this._description.Size = new System.Drawing.Size(324, 33);
			this._description.TabIndex = 0;
			this._description.TabStop = false;
			this._description.Text = "In order to start sharing this project on Language Depot, we need to ask you a fe" +
	"w things:";
			//
			// _emailLabel
			//
			this._emailLabel.AutoSize = true;
			this._emailLabel.Location = new System.Drawing.Point(13, 97);
			this._emailLabel.Name = "_emailLabel";
			this._emailLabel.Size = new System.Drawing.Size(121, 13);
			this._emailLabel.TabIndex = 1;
			this._emailLabel.Text = "Technical Leader Email:";
			//
			// _email
			//
			this._email.Location = new System.Drawing.Point(16, 114);
			this._email.Name = "_email";
			this._email.Size = new System.Drawing.Size(249, 20);
			this._email.TabIndex = 2;
			//
			// _requirePassword
			//
			this._requirePassword.AutoSize = true;
			this._requirePassword.Location = new System.Drawing.Point(16, 150);
			this._requirePassword.Name = "_requirePassword";
			this._requirePassword.Size = new System.Drawing.Size(339, 17);
			this._requirePassword.TabIndex = 3;
			this._requirePassword.Text = "Require anyone getting this project to have the following password";
			this._requirePassword.UseVisualStyleBackColor = true;
			this._requirePassword.CheckedChanged += new System.EventHandler(this._requirePassword_CheckedChanged);
			//
			// _password
			//
			this._password.Location = new System.Drawing.Point(16, 173);
			this._password.Name = "_password";
			this._password.Size = new System.Drawing.Size(249, 20);
			this._password.TabIndex = 4;
			//
			// _projectID
			//
			this._projectID.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._projectID.Location = new System.Drawing.Point(16, 209);
			this._projectID.Multiline = false;
			this._projectID.Name = "_projectID";
			this._projectID.ReadOnly = true;
			this._projectID.Size = new System.Drawing.Size(148, 17);
			this._projectID.TabIndex = 6;
			this._projectID.Text = "Project:";
			//
			// _changeProjectId
			//
			this._changeProjectId.AutoSize = true;
			this._changeProjectId.Location = new System.Drawing.Point(171, 209);
			this._changeProjectId.Name = "_changeProjectId";
			this._changeProjectId.Size = new System.Drawing.Size(53, 13);
			this._changeProjectId.TabIndex = 7;
			this._changeProjectId.TabStop = true;
			this._changeProjectId.Text = "Change...";
			this._changeProjectId.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnChangeLinkClicked);
			//
			// _cancelButton
			//
			this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._cancelButton.Location = new System.Drawing.Point(284, 251);
			this._cancelButton.Name = "_cancelButton";
			this._cancelButton.Size = new System.Drawing.Size(75, 23);
			this._cancelButton.TabIndex = 8;
			this._cancelButton.Text = "Cancel";
			this._cancelButton.UseVisualStyleBackColor = true;
			//
			// _okButton
			//
			this._okButton.Location = new System.Drawing.Point(203, 251);
			this._okButton.Name = "_okButton";
			this._okButton.Size = new System.Drawing.Size(75, 23);
			this._okButton.TabIndex = 9;
			this._okButton.Text = "OK";
			this._okButton.UseVisualStyleBackColor = true;
			this._okButton.Click += new System.EventHandler(this._okButton_Click);
			//
			// serverLabel
			//
			this.serverLabel.AutoSize = true;
			this.serverLabel.Location = new System.Drawing.Point(13, 41);
			this.serverLabel.Name = "serverLabel";
			this.serverLabel.Size = new System.Drawing.Size(96, 13);
			this.serverLabel.TabIndex = 10;
			this.serverLabel.Text = "Choose the server:";
			//
			// _serverCombobox
			//
			this._serverCombobox.FormattingEnabled = true;
			this._serverCombobox.Location = new System.Drawing.Point(16, 57);
			this._serverCombobox.Name = "_serverCombobox";
			this._serverCombobox.Size = new System.Drawing.Size(249, 21);
			this._serverCombobox.TabIndex = 11;
			//
			// _customUrlLabel
			//
			this._customUrlLabel.AutoSize = true;
			this._customUrlLabel.Location = new System.Drawing.Point(16, 97);
			this._customUrlLabel.Name = "_customUrlLabel";
			this._customUrlLabel.Size = new System.Drawing.Size(123, 13);
			this._customUrlLabel.TabIndex = 12;
			this._customUrlLabel.Text = "Enter Custom Server Url:";
			this._customUrlLabel.Visible = false;
			//
			// _customUrl
			//
			this._customUrl.Location = new System.Drawing.Point(16, 114);
			this._customUrl.Name = "_customUrl";
			this._customUrl.Size = new System.Drawing.Size(249, 20);
			this._customUrl.TabIndex = 13;
			this._customUrl.Visible = false;
			//
			// NewInternetProject
			//
			this.AcceptButton = this._okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this._cancelButton;
			this.ClientSize = new System.Drawing.Size(371, 286);
			this.Controls.Add(this._customUrl);
			this.Controls.Add(this._customUrlLabel);
			this.Controls.Add(this._serverCombobox);
			this.Controls.Add(this.serverLabel);
			this.Controls.Add(this._okButton);
			this.Controls.Add(this._cancelButton);
			this.Controls.Add(this._changeProjectId);
			this.Controls.Add(this._projectID);
			this.Controls.Add(this._password);
			this.Controls.Add(this._requirePassword);
			this.Controls.Add(this._email);
			this.Controls.Add(this._emailLabel);
			this.Controls.Add(this._description);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewInternetProject";
			this.ShowIcon = false;
			this.Text = "New Language Depot Project";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox _description;
		private System.Windows.Forms.Label _emailLabel;
		private System.Windows.Forms.TextBox _email;
		private System.Windows.Forms.CheckBox _requirePassword;
		private System.Windows.Forms.TextBox _password;
		private System.Windows.Forms.RichTextBox _projectID;
		private System.Windows.Forms.LinkLabel _changeProjectId;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Label serverLabel;
		private System.Windows.Forms.ComboBox _serverCombobox;
		private System.Windows.Forms.Label _customUrlLabel;
		private System.Windows.Forms.TextBox _customUrl;
	}
}