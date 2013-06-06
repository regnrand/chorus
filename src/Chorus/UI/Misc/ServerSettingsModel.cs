using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Windows.Forms;
using Chorus.Utilities;
using Chorus.VcsDrivers;
using Chorus.VcsDrivers.Mercurial;
using Palaso.Code;
using Palaso.Network;
using Palaso.Progress;

namespace Chorus.UI.Misc
{
	public class ServerSettingsModel
	{
		public readonly Dictionary<string, string> Servers = new Dictionary<string, string>();
		private string _pathToRepo;
		private string _email;

		public ServerSettingsModel()
		{
			const string languageDepotLabel = "LanguageDepot.org";
			Servers.Add(languageDepotLabel, "resumable.languagedepot.org");
			Servers.Add("LanguageDepot.org [Safe Mode]", "hg-public.languagedepot.org");
			Servers.Add("LanguageDepot.org [private]", "hg-private.languagedepot.org");
			Servers.Add("LanguageForge", "hg.languageforge.org");

			Servers.Add("Custom Location...", "");
			SelectedServerLabel = languageDepotLabel;
		}

		public virtual void InitFromUri(string url)
		{
			SetServerLabelFromUrl(url);
			Password = UrlHelper.GetPassword(url);
			if (String.IsNullOrEmpty(LanguageId))
			{
				//For legacy configurations pull the ProjectName out of the url
				ProjectId = UrlHelper.GetPathAfterHost(url);
			}
			AccountName = UrlHelper.GetUserName(url);
			CustomUrl = UrlHelper.GetPathOnly(url);
			//CustomUrlSelected = true;
		}

		private void SetServerLabelFromUrl(string url)
		{
			var host = UrlHelper.GetHost(url).ToLower();
			var pair = Servers.FirstOrDefault((p) => p.Value.ToLower() == host);
			if (pair.Key == null)
			{
				SelectedServerLabel = Servers.Last().Key;
			}
			else
			{
				SelectedServerLabel = pair.Key;
			}
		}

		public string Email
		{
			get { return _email; }
			set { CheckValidEmail(value); }
		}

		private void CheckValidEmail(string email)
		{
			//Validating e-mails according to the RFC is far too troublesome to implement, just use the .NET constructor
			//and catch since the parser is not exposed, even though it pains me to do so.
			try
			{
				var test = new MailAddress(email);
				_email = email;
			}
			catch
			{
				MessageBox.Show("Your e-mail address is not valid, please check it and re-enter.", "Invalid e-mail address");
			}
		}

		public string NameOfProjectOnRepository
		{
			get
			{
				if (!HaveNeededAccountInfo)
					return string.Empty;
				return ProjectId;
			}
		}

		public string LanguageId { get; set; }

		public string ProjectType { get; set; }

		public string ProjectId { get; set; }

		public string URL
		{
			get
			{
				if (CustomUrlSelected)
				{
					return CustomUrl;
				}
				else
				{
					return "http://" +
						   HttpUtilityFromMono.UrlEncode((string)AccountName) + ":" +
						   HttpUtilityFromMono.UrlEncode((string)Password) + "@" + SelectedServerPath + "/" +
						   HttpUtilityFromMono.UrlEncode(ProjectId);
				}
			}
		}

		public string CustomUrl { get; set; }

		public bool HaveNeededAccountInfo
		{
			get
			{
				if (!NeedUrlField)
				{
					return true;
				}
				else
				{
					try
					{
						return !string.IsNullOrEmpty(ProjectId) &&
							   !string.IsNullOrEmpty(AccountName) &&
							   !string.IsNullOrEmpty(Password);
					}
					catch (Exception)
					{
						return false;
					}
				}
			}
		}

		public string Password { get; set; }
		public string AccountName { get; set; }

		public bool HaveGoodUrl
		{
			get { return HaveNeededAccountInfo; }
		}

		public string SelectedServerPath
		{
			get
			{
				string path;
				if(Servers.TryGetValue(SelectedServerLabel, out path))
				{
					return path;
				}
				throw new ApplicationException("Somehow SelectedServerLabel was empty, when called from SelectedServerPath.");
			}
		}

		public string SelectedServerLabel
		{
			get; set;
		}

		public bool NeedUrlField
		{
			get { return CustomUrlSelected; }
		}

		public bool CustomUrlSelected
		{
			get
			{
				string server;
				if (!Servers.TryGetValue(SelectedServerLabel, out server))
				{
					SelectedServerLabel = Servers.Keys.First();
				}
				return Servers[SelectedServerLabel] == string.Empty;
			}
		}

		/// <summary>
		/// Save the settings in the folder's .hg, creating the folder and settings if necessary.
		/// This is only available if you previously called InitFromProjectPath().  It isn't used
		/// in the GetCloneFromInternet scenario.
		/// </summary>
		public void SaveSettings()
		{
			if(string.IsNullOrEmpty(_pathToRepo))
			{
				throw new ArgumentException("SaveSettings() only works if you InitFromProjectPath()");
			}

			var repo = HgRepository.CreateOrUseExisting(_pathToRepo, new NullProgress());

			// Use safer SetTheOnlyAddressOfThisType method, as it won't clobber a shared network setting, if that was the clone source.
			repo.SetTheOnlyAddressOfThisType(new HttpRepositoryPath(AliasName, URL, false));
			repo.SetProjectId(ProjectId);
		}

		public string AliasName
		{
			get
			{
				if (CustomUrlSelected)
				{
					Uri uri;
					if (Uri.TryCreate(URL, UriKind.Absolute, out uri) && !String.IsNullOrEmpty(uri.Host))
					{
						return uri.Host;
					}
					else
					{
						return "custom";
					}
				}
				else
				{
					return SelectedServerLabel.Replace(" ","");
				}
			}
		}

		/// <summary>
		/// Use this to make use of, say, the contents of the clipboard (if it looks like a url)
		/// </summary>
		public void SetUrlToUseIfSettingsAreEmpty(string url)
		{
			if (!HaveGoodUrl)
			{
				InitFromUri(url);
			}
		}

		public virtual void InitFromProjectPath(string path)
		{
			RequireThat.Directory(path).Exists();

			var repo = HgRepository.CreateOrUseExisting(path, new NullProgress());
			_pathToRepo = repo.PathToRepo;
			LanguageId = repo.LanguageCode;
			ProjectType = repo.ProjectType;
			ProjectId = repo.ProjectId;
			var address = repo.GetDefaultNetworkAddress<HttpRepositoryPath>();
			if (address != null)
			{
				InitFromUri(address.URI);
			}

			//otherwise, just leave everything in the default state
		}
	}
}