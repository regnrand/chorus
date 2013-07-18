using System;
using System.Collections.Generic;
using System.IO;
using Chorus.UI.Misc;
using Chorus.sync;
using Chorus.Utilities;
using NUnit.Framework;
using System.Linq;
using Palaso.TestUtilities;

namespace Chorus.Tests.UI.Settings
{
	[TestFixture]
	public class SettingsModelTests
	{
		[Test]
		public void DoesClearServerSettingsRemoveServerSettings()
		{
			using (var testFolder = new TemporaryFolder("SettingsModelTest" + DateTime.Now.Ticks))
			{
				var settings = new ServerSettingsModel();
				settings.InitFromProjectPath(testFolder.Path);
				settings.ProjectId = "proj";
				settings.LanguageId = "tst";
				settings.ProjectType = "dict";
				settings.SaveSettings();
				Assert.IsNotNull(settings.SelectedServerLabel, @"No settings to begin with, test invalidated by some change.");
				settings.ProjectExistsOnServer = false;
				Assert.IsNull(settings.ProjectId, @"Settings not cleared.");
				Assert.IsNull(settings.SelectedServerLabel, @"Settings not cleared.");
			}
		}
	}
}