using System;
using System.Collections.Generic;
using System.IO;
using Chorus.merge;
using Chorus.merge.text;
using Chorus.Utilities;
using Chorus.VcsDrivers.Mercurial;

namespace Chorus.FileTypeHanders
{
	public class TextFileTypeHandler : IChorusFileTypeHandler
	{
		public bool CanDiffFile(string pathToFile)
		{
			return false;//todo
		}

		public bool CanMergeFile(string pathToFile)
		{
			return (Path.GetExtension(pathToFile) == ".txt");
		}

		public bool CanPresentFile(string pathToFile)
		{
			return false;//todo
		}

		public void Do3WayMerge(MergeOrder order)
		{
			using (TempFile lcd = new TempFile()) //this one gets used, not left for the caller
			{
				TempFile ourPartial = new TempFile();
				TempFile theirPartial = new TempFile();
				// Debug.Fail("hi");

				//Debug.Fail("(Not really a failure) chorus merge : "+pathToOurs);
				TextMerger.Merge(order.pathToCommonAncestor, order.pathToOurs, order.pathToTheirs,
											 lcd.Path, ourPartial.Path,
											 theirPartial.Path);

//  this was for partial merging
//                // insert a single comma-delimited line
//                //listing {user's path, path to ourPartial, paht to theirPartial}
//                StreamWriter f = File.AppendText(Path.Combine(Path.GetTempPath(), "chorusMergePaths.txt"));
//                f.Write(order.pathToOurs);
//                f.Write("," + ourPartial.Path);
//                f.WriteLine("," + theirPartial.Path);
//                f.Close();
//                f.Dispose();

				switch (order.MergeSituation.ConflictHandlingMode)
				{
					case MergeOrder.ConflictHandlingModeChoices.WeWin:
						File.Copy(ourPartial.Path, order.pathToOurs, true);
						ourPartial.Dispose();
						theirPartial.Dispose();
						break;
					case MergeOrder.ConflictHandlingModeChoices.TheyWin:
						File.Copy(theirPartial.Path, order.pathToOurs, true);
						ourPartial.Dispose();
						theirPartial.Dispose();
						break;
					case MergeOrder.ConflictHandlingModeChoices.LcdPlusPartials:
						//Make the result of the merge be the LCD (It's critical that the calling process
						//will be following this up RIGHT AWAY by appending the partials to their respective
						//branches! Otherwise conflicting changes will be lost to both parties.
						File.Copy(lcd.Path, order.pathToOurs, true);
						//leave the other two temp files for the caller to work with and delete
						break;
					default:
						throw new ArgumentException(
							"The text merge dispatcher does not understand this conflictHandlingMode");
				}

			}
		}

		public IEnumerable<IChangeReport> Find2WayDifferences(FileInRevision fileInRevision, string pathToParent, string pathToChild)
		{
			throw new NotImplementedException(string.Format("The TextFileTypeHandler does not yet do diffs"));
		}

		public IChangePresenter GetChangePresenter(IChangeReport report, HgRepository repository)
		{
			return new DefaultChangePresenter(report);
		}



		public IEnumerable<IChangeReport> DescribeInitialContents(FileInRevision fileInRevision, TempFile file)
		{
			return new IChangeReport[] { new DefaultChangeReport(fileInRevision.FullPath, "Added") };
		}

	}
}