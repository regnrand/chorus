using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Chorus.VcsDrivers;
using Chorus.VcsDrivers.Mercurial;
using Chorus.sync;
using Palaso.Progress.LogBox;

namespace Chorus
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static int Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			SetUpErrorHandling();

		//	throw new ApplicationException("test");

			//is mercurial set up?
			var s = HgRepository.GetEnvironmentReadinessMessage("en");
			if (!string.IsNullOrEmpty(s))
			{
				MessageBox.Show(s, "Chorus", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return 1;
			}

			//did they give us a path on the command line?
			string pathToRepository =null;
			if(args.Length > 0)
			{
				if (args[0] == "-h" || args[0] == "?" || args[0] == "-?")
				{
					WriteHelpToConsole();
					return 0;
				}

				if (args.Length == 1)
				{
					//just open up the UI on this repository
					pathToRepository = args[0];
				}
				else if (args.Length == 3)
				{
					//Go for an unattended send/receive
					return RunCommandLineSendReceive(args, new ConsoleProgress());
				}
				else
				{
					WriteHelpToConsole();
					return 1;
				}
			}

			if (string.IsNullOrEmpty(pathToRepository) || !Directory.Exists(pathToRepository))
			{
				//do we have a valid path from last time?
				pathToRepository = Properties.Settings.Default.PathToRepository;
			}

			if (string.IsNullOrEmpty(pathToRepository) || !Directory.Exists(pathToRepository))
			{
				//can they find a repository for us?
				pathToRepository = Runner.BrowseForRepository();
			}
			if (string.IsNullOrEmpty(pathToRepository) || !Directory.Exists(pathToRepository))
			{
				return 1; //give up
			}


			Properties.Settings.Default.PathToRepository = pathToRepository;
			Properties.Settings.Default.Save();
			new Runner().Run(pathToRepository, new Arguments(args));

			Properties.Settings.Default.Save();
			return 0;
		}

		/// <summary>
		/// Allows someone to type "chorus.exe myrepoPath --targetAddress http://me:pass@somewhere/project
		/// </summary>
		/// <returns>0 if success, else 1</returns>
		internal static int RunCommandLineSendReceive(string[] args, IProgress progress)
		{
			Palaso.Reporting.ErrorReport.IsOkToInteractWithUser = false;
			string pathToRepository = args[0];
			if (args[1].ToLower() == "--remoteaddress" || args.Length > 2)
			{
				try
				{
					var syncTarget = args[2];
					var projectFolderConfiguration = new ProjectFolderConfiguration(pathToRepository);
					var sync = new sync.Synchronizer(pathToRepository, projectFolderConfiguration, progress);
					var options = new SyncOptions()
									{
										CheckinDescription = "Via command line",
										DoMergeWithOthers = true,
										DoPullFromOthers = true,
										DoSendToOthers = true,
										RepositorySourcesToTry =
											new List<RepositoryAddress>(new[] {RepositoryAddress.Create("remote", syncTarget)})
									};

					SyncResults results = sync.SyncNow(options);
					return results.Succeeded ? 0 : 1;
				}
				catch (Exception error)
				{
					Console.WriteLine(error.Message);
					return 1;
				}
				return 0;
			}
			else
			{
				WriteHelpToConsole();
				return 1;
			}
		}

		private static void WriteHelpToConsole()
		{
			Console.WriteLine("Chorus pathToRepository (--remoteAddress syncTarget)");
			Console.WriteLine(@"example: Chorus c:\foo\myproject");
			Console.WriteLine(@"example: Chorus c:\foo\myproject --remoteAddress  http:smith:myPassword@languagedepot.org");
		}

		private static void SetUpErrorHandling()
		{
			try
			{
//				Palaso.Reporting.ErrorReport.AddProperty("EmailAddress", "issues@wesay.org");
//				Palaso.Reporting.ErrorReport.AddStandardProperties();
//				Palaso.Reporting.ExceptionHandler.Init();

			/* until we decide to require palaso.dll, we can at least make use of it if it happens
			 * to be there (as it is with WeSay)
			 */
				Assembly asm = Assembly.LoadFrom("Palaso.dll");
				Type errorReportType = asm.GetType("Palaso.Reporting.ErrorReport");
				PropertyInfo emailAddress = errorReportType.GetProperty("EmailAddress");
				emailAddress.SetValue(null,"issues@wesay.org",null);
				errorReportType.GetMethod("AddStandardProperties").Invoke(null, null);
				asm.GetType("Palaso.Reporting.ExceptionHandler").GetMethod("Init").Invoke(null, null);
			}
			catch(Exception)
			{
				//ah well
			}
		}


		internal class Runner
		{
			public void Run(string pathToRepository, Arguments arguments)
			{

				BrowseForRepositoryEvent browseForRepositoryEvent = new BrowseForRepositoryEvent();
				browseForRepositoryEvent.Subscribe(BrowseForRepository);
				using (var bootStrapper = new BootStrapper(pathToRepository))
				{
					Application.Run(bootStrapper.CreateShell(browseForRepositoryEvent, arguments));
				}
			}

			public  void BrowseForRepository(string dummy)
			{
				var s = BrowseForRepository();
				if (!string.IsNullOrEmpty(s) && Directory.Exists(s))
				{
					//NB: if this was run from a Visual Studio debug session, these settings
					//are going to be saved in a different place, so on
					//restart, we won't really open the one we wanted.
					//We'll instead open the last project that was opened when
					//running outside of Visual Studio.
					Properties.Settings.Default.PathToRepository = s;
					Properties.Settings.Default.Save();
					Application.Restart();
				}
			}

			public static string BrowseForRepository()
			{
				var dlg = new FolderBrowserDialog();
				dlg.Description = "Select a chorus-enabled project to open:";
				dlg.ShowNewFolderButton = false;
				if (DialogResult.OK != dlg.ShowDialog())
					return null;
				return dlg.SelectedPath;
			}
		}
	}
}