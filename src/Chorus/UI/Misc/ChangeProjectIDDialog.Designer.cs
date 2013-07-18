using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chorus.UI.Misc
{
	public partial class ChangeProjectIDDialog : Form
	{
		public ChangeProjectIDDialog()
		{
			InitializeComponent();
		}

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
			this._ISOlabel = new System.Windows.Forms.Label();
			this._projectID = new System.Windows.Forms.TextBox();
			this._projectType = new System.Windows.Forms.Label();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this._cancel = new System.Windows.Forms.Button();
			this._okButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			//
			// _ISOlabel
			//
			this._ISOlabel.AutoSize = true;
			this._ISOlabel.Location = new System.Drawing.Point(13, 107);
			this._ISOlabel.Name = "_ISOlabel";
			this._ISOlabel.Size = new System.Drawing.Size(83, 13);
			this._ISOlabel.TabIndex = 3;
			this._ISOlabel.Text = "ISO 639-3 Code";
			//
			// _projectID
			//
			this._projectID.Location = new System.Drawing.Point(104, 104);
			this._projectID.Name = "_projectID";
			this._projectID.Size = new System.Drawing.Size(31, 20);
			this._projectID.TabIndex = 4;
			//
			// _projectType
			//
			this._projectType.AutoSize = true;
			this._projectType.Location = new System.Drawing.Point(136, 107);
			this._projectType.Name = "_projectType";
			this._projectType.Size = new System.Drawing.Size(25, 13);
			this._projectType.TabIndex = 5;
			this._projectType.Text = "-xxx";
			//
			// richTextBox1
			//
			this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBox1.Location = new System.Drawing.Point(13, 13);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(379, 88);
			this.richTextBox1.TabIndex = 6;
			this.richTextBox1.Text = "Do not localize, programmatically filled in for bullet style purposes";
			//
			// _cancel
			//
			this._cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._cancel.Location = new System.Drawing.Point(333, 180);
			this._cancel.Name = "_cancel";
			this._cancel.Size = new System.Drawing.Size(75, 23);
			this._cancel.TabIndex = 7;
			this._cancel.Text = "Cancel";
			this._cancel.UseVisualStyleBackColor = true;
			//
			// _okButton
			//
			this._okButton.Location = new System.Drawing.Point(243, 180);
			this._okButton.Name = "_okButton";
			this._okButton.Size = new System.Drawing.Size(75, 23);
			this._okButton.TabIndex = 8;
			this._okButton.Text = "OK";
			this._okButton.UseVisualStyleBackColor = true;
			this._okButton.Click += new System.EventHandler(this._okButton_Click);
			//
			// ChangeProjectIDDialog
			//
			this.AcceptButton = this._okButton;
			this.CancelButton = this._cancel;
			this.ClientSize = new System.Drawing.Size(420, 215);
			this.Controls.Add(this._okButton);
			this.Controls.Add(this._cancel);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this._projectType);
			this.Controls.Add(this._projectID);
			this.Controls.Add(this._ISOlabel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ChangeProjectIDDialog";
			this.ShowIcon = false;
			this.Text = "Change Project ID";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Button _cancel;
		private Button _okButton;
	}
}
