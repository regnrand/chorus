using Chorus.Utilities;
using NUnit.Framework;

namespace LibChorus.Tests.utilities
{
	[TestFixture]
	public class UrlHelperTests
	{
		[Test]
		public void EscapeUrlForUseInXmlAttribute_Empty_ReturnEmpty()
		{
			Assert.AreEqual(string.Empty, UrlHelper.GetEscapedUrl(string.Empty));
		}

		[Test]
		public void EscapeUrlForUseInXmlAttribute_HasQueryPortionWithAmpersand_ProperlyEscaped()
		{
			var x = UrlHelper.GetEscapedUrl("lift://somefile.lift?label=blah&somethingelse=3");
			Assert.AreEqual("lift://somefile.lift?label=blah&amp;somethingelse=3", x);
		}

		[Test]
		public void EscapeUrlForUseInXmlAttribute_HasQueryPortionWithSingleQuote_ProperlyEscaped()
		{
			var x = UrlHelper.GetEscapedUrl("lift://somefile.lift?label=it's");
			Assert.AreEqual("lift://somefile.lift?label=it&apos;s", x);
		}

		[Test]
		public void GetPathOnly_HasPathAndQuery_ReturnsPathOnly()
		{
			var x = UrlHelper.GetPathOnly("lift://somefile.lift?label=it's");
			Assert.AreEqual("lift://somefile.lift", x);
		}

		[Test]
		public void GetPassword_HasPathOnly_ReturnsEmptyString()
		{
			Assert.AreEqual(string.Empty, UrlHelper.GetPassword("http://there.com/detail"));
		}
		[Test]
		public void GetPassword_EmptyPath_ReturnsEmptyString()
		{
			Assert.AreEqual(string.Empty, UrlHelper.GetPassword(""));
		}

		[Test]
		public void GetPassword_HasFakeUserOnly_ReturnsEmptyString()
		{
			Assert.AreEqual(string.Empty, UrlHelper.GetPassword("http://" + UrlHelper.ChorusUserName + "@there.com/detail"));
		}

		[Test]
		public void GetPassword_HasPathAndPass_ReturnsPassword()
		{
			Assert.AreEqual("pass", UrlHelper.GetPassword("http://" + UrlHelper.ChorusUserName + ":pass@there.com/detail"));
		}

		[Test]
		public void GetValueFromQueryStringOfRef_HasNoSpaceInName_StillGetsValue()
		{
			Assert.AreEqual("2", UrlHelper.GetValueFromQueryStringOfRef(@"lift://somefile.lift?one=1&two=2", "two", string.Empty));
		}

		[Test]
		public void GetValueFromQueryStringOfRef_HasEscapedSpaceInName_StillGetsValue()
		{
			Assert.AreEqual("2", UrlHelper.GetValueFromQueryStringOfRef(@"lift://some%20file.lift?one=1&two=2", "two", string.Empty));
			Assert.AreEqual("2", UrlHelper.GetValueFromQueryStringOfRef(@"lift://some %20 file.lift?one=1&two=2", "two", string.Empty));
		}

	}
}