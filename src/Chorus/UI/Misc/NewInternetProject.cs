using System;
using System.Windows.Forms;

namespace Chorus.UI.Misc
{
	/// <summary>
	/// This form takes the user input required to initiate a new Send/Receive repository on the internet
	/// </summary>
	public partial class NewInternetProject : Form
	{
		private readonly ServerSettingsModel _model;

		/// <summary>
		/// Default constructor (for designer)
		/// </summary>
		public NewInternetProject()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Primary constructor, takes the settings model both for initializing the dialog and saving the
		/// user changes
		/// </summary>
		/// <param name="model"></param>
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
			_serverCombobox.SelectedIndexChanged -= OnSelectedIndexChanged;
			_serverCombobox.Items.Clear();
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
			_serverCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
			_serverCombobox.SelectedIndexChanged += OnSelectedIndexChanged;
			if (_model.CustomUrlSelected)
			{
				_email.Visible = false;
				_password.Visible = false;
				_requirePassword.Visible = false;
				_projectID.Visible = false;
				_changeProjectId.Visible = false;
				_customUrlLabel.Visible = true;
				_customUrl.Visible = true;
			}
			else
			{
				_email.Visible = true;
				_password.Visible = true;
				_requirePassword.Visible = true;
				_projectID.Visible = true;
				_changeProjectId.Visible = true;
				_customUrlLabel.Visible = false;
				_customUrl.Visible = false;
			}
			_projectID.Text = String.Format("Project:\t{0}-{1}", _model.LanguageId, _model.ProjectType);
			_password.Text = _model.Password;
			_requirePassword.Checked = _model.Password != "";
			_password.Enabled = _requirePassword.Checked;
			_email.Text = _model.Email;
			Invalidate();
		}

		private void OnChangeLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			StoreFieldsInModel();
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
			StoreFieldsInModel();
			UpdateFromModel();
		}

		private void _okButton_Click(object sender, EventArgs e)
		{
			StoreFieldsInModel();
			_model.SaveSettings();
			DialogResult = DialogResult.OK;
			Close();
		}

		private void StoreFieldsInModel()
		{
			_model.SelectedServerLabel = (string)_serverCombobox.SelectedItem;
			if (_model.CustomUrlSelected)
			{
				_model.CustomUrl = _customUrl.Text;
			}
			_model.Email = _email.Text;
			_model.Password = _requirePassword.Checked ? _password.Text : "";
			if (String.IsNullOrWhiteSpace(_model.ProjectId))
			{
				// The projectId isn't set directly in this dialog, but the default one constructed
				// from the languageId and projectType needs to be stored in the model
				_model.ProjectId = String.Format(@"{0}-{1}", _model.LanguageId, _model.ProjectType);
			}
		}

		private void _requirePassword_CheckedChanged(object sender, EventArgs e)
		{
			_password.Enabled = _requirePassword.Checked;
			_password.Text = !_requirePassword.Checked ? "" : _model.Password;
		}
	}
}
