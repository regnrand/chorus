using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace Chorus.UI.Misc
{
	/// <summary>
	/// This dialog lets the user change the project id, used during internet Send Receive with Language Depot
	/// </summary>
	public partial class ChangeProjectIDDialog
	{
		private Label _ISOlabel;
		private TextBox _projectID;
		private Label _projectType;
		private RichTextBox richTextBox1;
		private ServerSettingsModel _model;
		public ChangeProjectIDDialog(ServerSettingsModel model)
		{
			_model = model;
			Init();
		}

		private void Init()
		{
			InitializeComponent();
			_projectID.Text = _model.LanguageId;
			_projectType.Text = @"-" + _model.ProjectType;
			// Clear all text from the RichTextBox;
			richTextBox1.Clear();
			richTextBox1.SelectedText = "Normally, you should not change this. Reasons to change it include:" + Environment.NewLine + Environment.NewLine;
			// Indent bulleted text 10 pixels away from the bullet.
			richTextBox1.BulletIndent = 10;
			// Specify that the following items are to be added to a bulleted list.
			richTextBox1.SelectionBullet = true;
			// Set the color of the item text.
			richTextBox1.SelectedText = "The program has not properly understood the ISO 639-3 (Ethnologue) code for this language" + Environment.NewLine;
			richTextBox1.SelectedText = "This language (dialect) does not have its own ISO 639-3 code." + Environment.NewLine;
			richTextBox1.SelectionBullet = false;
		}

		private void _okButton_Click(object sender, EventArgs e)
		{
			_model.ProjectId = String.Format(@"{0}-{1}", _projectID.Text, _model.ProjectType);
			_model.SaveSettings();
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}