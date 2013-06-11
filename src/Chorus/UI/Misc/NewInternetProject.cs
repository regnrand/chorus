using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace Chorus.UI.Misc
{
	public partial class NewInternetProject : Form
	{
		private readonly ServerSettingsModel _model;

		public NewInternetProject()
		{
			InitializeComponent();
		}

		public NewInternetProject(ServerSettingsModel model)
		{
			_model = model;
			Init();
		}

		private void Init()
		{
			InitializeComponent();
			UpdateFromModel();
		}

		private void UpdateFromModel()
		{
			foreach (var pair in _model.Servers)
			{
				_serverCombobox.Items.Add(pair.Key);
			}
			if (_model.SelectedServerLabel != null)
			{
				_serverCombobox.SelectedItem = _model.SelectedServerLabel;
			}
			else
			{
				_serverCombobox.SelectedIndex = 0;
			}
			_serverCombobox.SelectedIndexChanged += OnSelectedIndexChanged;
			_projectID.Text = String.Format("Project:\t{0}-{1}", _model.LanguageId, _model.ProjectType);
			_password.Text = _model.Password;
			_requirePassword.Checked = _model.Password != "";
			_password.Enabled = _requirePassword.Checked;
			_email.Text = _model.Email;
			Invalidate();
		}

		private void OnChangeLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			using (var settingsDialog = new ChangeProjectIDDialog(_model))
			{
				var result = settingsDialog.ShowDialog(this);
				if (result == DialogResult.OK)
				{
					UpdateFromModel();
				}
			}
		}

		private void OnSelectedIndexChanged(object sender, EventArgs e)
		{
			_model.SelectedServerLabel = (string)_serverCombobox.SelectedItem;
		}

		private void _okButton_Click(object sender, EventArgs e)
		{
			_model.Email = _email.Text;
			_model.Password = _requirePassword.Checked ? _password.Text : "";
			_model.ProjectId = _projectID.Text;
			_model.SaveSettings();
			DialogResult = DialogResult.OK;
			Close();
		}

		private void _requirePassword_CheckedChanged(object sender, EventArgs e)
		{
			_password.Enabled = _requirePassword.Checked;
			_password.Text = !_requirePassword.Checked ? "" : _model.Password;
		}
	}
}
