﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Media;
using System.Text;
using System.Windows.Forms;
using Chorus.clone;
using Chorus.Utilities;
using System.Linq;
using Chorus.VcsDrivers;
using Chorus.VcsDrivers.Mercurial;

namespace Chorus.UI.Clone
{
	public partial class GetCloneFromInternetDialog : Form
	{
		private readonly string _parentDirectoryToPutCloneIn;
		private CloneFromUsb _model;
		private IProgress _progress;
		private readonly BackgroundWorker _backgroundWorker;
		private enum State { AskingUserForURL, MakingClone, Success, Error }

		private InternetRepositoryInfoControl _sourceAndTargetControl;
		private StatusProgress _statusProgress;
		private State _state;
		private string _failureMessage;

		public GetCloneFromInternetDialog(string parentDirectoryToPutCloneIn)
		{
			_parentDirectoryToPutCloneIn = parentDirectoryToPutCloneIn;
			Font = SystemFonts.MessageBoxFont;

			InitializeComponent();

			_backgroundWorker = new BackgroundWorker();
			_backgroundWorker.WorkerSupportsCancellation = true;
			_backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_backgroundWorker_RunWorkerCompleted);
			_backgroundWorker.DoWork += new DoWorkEventHandler(_backgroundWorker_DoWork);

			_statusProgress = new StatusProgress();
			_progress = new MultiProgress(new IProgress[]{new TextBoxProgress(_progressLog), _statusProgress});

			_progress.ShowVerbose = true;
			_showVerboseLog.Checked = true;

			_sourceAndTargetControl = new InternetRepositoryInfoControl(parentDirectoryToPutCloneIn);
			_sourceAndTargetControl.Bounds = new Rectangle(0, 0, Width, Height);
			_sourceAndTargetControl.Dock = DockStyle.Fill;
			this.Controls.Add(_sourceAndTargetControl);
			_sourceAndTargetControl._downloadButton.Click+=new EventHandler(OnDownloadClick);
		}

		private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (_statusProgress.ErrorEncountered)
				UpdateDisplay(State.Error);
			else
				UpdateDisplay(State.Success);
		}

		void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				//review: do we need to get these out of the DoWorkEventArgs instead?
				HgRepository.Clone(URL, PathToNewProject, _progress);
				using (SoundPlayer player = new SoundPlayer(Properties.Resources.finishedSound))
				{
					player.Play();
				}

			}
			catch (Exception error)
			{
				_progress.WriteError(error.Message);
				using (SoundPlayer player = new SoundPlayer(Properties.Resources.errorSound))
				{
					player.Play();
				}
				_failureMessage = error.Message;
			}
		}

		public CloneFromUsb Model { get { return _model; } }

		private void UpdateDisplay(State newState)
		{
			_state = newState;
			switch (_state)
			{
				case State.AskingUserForURL:
					_statusLabel.Visible = false;
					_statusImage.Visible   =false;
					_progressLog.Visible = false;
					_okButton.Visible = false;
					_progressBar.Visible = false;
					_showVerboseLog.Visible = false;
					_sourceAndTargetControl.Visible = true;
					_cancelTaskButton.Visible = false;

					break;
				case State.MakingClone:
					_sourceAndTargetControl.Visible = false;
					_statusImage.Visible = false;
					_progressBar.Visible = true;
					_progressBar.Style = ProgressBarStyle.Marquee;
					_statusLabel.Visible = true;
					_statusLabel.Text = "Copying project";
					_progressLog.Visible = true;
					_showVerboseLog.Visible = true;
					_progress.ShowVerbose = _showVerboseLog.Checked;
					_cancelTaskButton.Visible = true;
					_cancelButton.Enabled = false;
					break;
				case State.Success:
					_cancelButton.Enabled = false;
					_cancelTaskButton.Visible = false;
					_statusLabel.Visible = true;
					_statusLabel.Text = "Done.";
					_progressBar.Visible = false;
					_sourceAndTargetControl.Visible = false;
					_statusLabel.Left = _statusImage.Right + 10;
					_statusImage.Visible = true;
					_statusImage.ImageKey="Success";
					_statusLabel.Text = string.Format("Finished copying {0} to this computer at {1}", Path.GetFileName(_sourceAndTargetControl.TargetDestination), _parentDirectoryToPutCloneIn);
					_okButton.Visible = true;
					_cancelButton.Enabled = false;
					_showVerboseLog.Visible = true;
					_progressLog.Visible = true;
					break;
				case State.Error:
					_cancelButton.Enabled = true;
					_cancelTaskButton.Visible = false;
					_statusLabel.Visible = true;
					_statusLabel.Text = "Failed.";
					_progressBar.Visible = false;
					_sourceAndTargetControl.Visible = false;
					_statusLabel.Left = _statusImage.Right + 10;
					_statusImage.ImageKey = "Error";
					_statusImage.Visible = true;
					_statusLabel.Text = _failureMessage;
					_showVerboseLog.Visible = true;
					_progressLog.Visible = true;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private void OnLoad(object sender, EventArgs e)
		{
			UpdateDisplay(State.AskingUserForURL);
		}

		private void _okButton_Click(object sender, EventArgs e)
		{
		   DialogResult = DialogResult.OK;
			Close();
		}

		public string PathToNewProject
		{
			get { return _sourceAndTargetControl.TargetDestination; }
		}

		private void _cancelButton_Click(object sender, EventArgs e)
		{
			if (_state == State.MakingClone)
			{
//                lock (this)
//                {
//                    if (!_backgroundWorker.IsBusy)
//                        return;
//
//                    _backgroundWorker.CancelAsync();//the hg call will know nothing of this
//                    _progress.CancelRequested = true; //but it will be monitoring this
//                }
			}
			else
			{
				DialogResult = DialogResult.Cancel;
				Close();
			}
		}

		private void OnDownloadClick(object sender, EventArgs e)
		{
			lock (this)
			{
				if(_backgroundWorker.IsBusy)
					return;
				UpdateDisplay(State.MakingClone);
				_backgroundWorker.RunWorkerAsync(new object[] {URL, PathToNewProject, _progress});
			}

		}


		public string URL
		{
			get { return _sourceAndTargetControl.URL; }
			set { _sourceAndTargetControl.URL = value; }
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (_state == State.MakingClone)
			{
				lock (this)
				{
					if (!_backgroundWorker.IsBusy)
						return;

					_backgroundWorker.CancelAsync();//the hg call will know nothing of this
					_progress.CancelRequested = true; //but it will be monitoring this
				}
			}
		}
	}
}