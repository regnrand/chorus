using System.Collections.Generic;
using LibChorus.TestUtilities;
using NUnit.Framework;
using Palaso.Progress.LogBox;

namespace Chorus.Tests
{
	[TestFixture]
	public class CommandLineTests
	{
		[Test]
		public void Launch_WithLocalAndTargetAddressButBadCredentials_GivesErrorAndReturns1()
		{
			using (var setup = new RepositorySetup("pedro"))
			{
				var arguments = new List<string>();
				arguments.Add(setup.ProjectFolder.Path);
				arguments.Add("--targetAddress");
				arguments.Add(@"http://automatedtest:badPassword@hg-public.languagedepot.org/testchorussync");
				var progress = new StringBuilderProgress();
				var result = Program.RunCommandLineSendReceive(arguments.ToArray(), progress);
				Assert.True(progress.ToString().Contains("The server rejected the project name, user name, or password"));
				Assert.AreEqual(1, result,"Expected an exitcode of 1 to indicate that there was an error.");
			}
		}

		[Test, Ignore("we would need to clone from the repo")]
		[Category("SkipOnBuildServer")]
		public void Launch_WithLocalAndTargetAddressButBadCredentials_Succeeds()
		{
			using (var setup = new RepositorySetup("pedro"))
			{
				var arguments = new List<string>();
				arguments.Add(setup.ProjectFolder.Path);
				arguments.Add("--targetAddress");
				arguments.Add(@"http://automatedtest:testingd@hg-public.languagedepot.org/testchorussync");
				var progress = new StringBuilderProgress();
				var result = Program.RunCommandLineSendReceive(arguments.ToArray(), progress);
				Assert.True(progress.ToString().Contains("what"));
				Assert.AreEqual(0, result, "Expected an exitcode of 0 to indicate that the operation succeeded");
			}
		}
	}
}
