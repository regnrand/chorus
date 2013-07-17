using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;


namespace Chorus.UI.Misc
{
	///<summary>
	/// This control lets the user identify the server to use with send/receive,
	/// including projectId. Normally used with Either ServerSEetingsDialog,
	/// or in conjunction with TargetFolderControl in GetCloneFromInterentDialog
	///</summary>
	public partial class ServerSettingsControl : UserControl
	{
		public event EventHandler DisplayUpdated;

		private ServerSettingsModel _model;

		public ServerSettingsControl()
		{
			InitializeComponent();
		}

		public ServerSettingsModel Model
		{
			get { return _model; }
			set
			{
				_model = value;
				if (value == null)
					return;
				foreach (KeyValuePair<string, string> pair in Model.Servers)
				{
					_serverCombo.Items.Add(pair.Key);
				}
				_serverCombo.SelectedIndexChanged += OnSelectedIndexChanged;
				if (!String.IsNullOrEmpty(_model.ProjectId))
				{
					_projectId.Text = _model.ProjectId;
				}
				else
				{
					_projectId.Text = String.Format("{0}-{1}", _model.LanguageId, _model.ProjectType);
				}
			}
		}

		private void OnSelectedIndexChanged(object sender, EventArgs e)
		{
			if (Model.SelectedServerLabel != (string)_serverCombo.SelectedItem)
			{
				Model.SelectedServerLabel = (string)_serverCombo.SelectedItem;

				UpdateDisplay();
			}
		}

		private void UpdateDisplay()
		{
			_serverCombo.SelectedItem = Model.SelectedServerLabel;

			_projectId.Text = Model.ProjectId;

			_customAddress.Visible = Model.NeedUrlField;
			_customAddressLabel.Visible = Model.NeedUrlField;

			if (DisplayUpdated != null)
				DisplayUpdated.Invoke(this, null);
		}

		private void CustomAddressTextChanged(object sender, EventArgs e)
		{
			Model.CustomUrl = _customAddress.Text.Trim();
			UpdateDisplay();
		}

		private void OnLoad(object sender, EventArgs e)
		{
			if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
				return;

			UpdateDisplay();
		}

		private void ChangeProjectLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			using (var settingsDialog = new ChangeProjectIDDialog(_model))
			{
				var result = settingsDialog.ShowDialog(this);
				if (result == DialogResult.OK)
				{
					UpdateDisplay();
				}
			}
		}
	}
}
