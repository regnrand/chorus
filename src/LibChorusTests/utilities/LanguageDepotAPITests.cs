using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using Jayrock.Json;
using System.Text;
using Chorus.Utilities;
using Chorus.VcsDrivers;
using NUnit.Framework;

namespace LibChorus.Tests.utilities
{
	[TestFixture]
	class LanguageDepotAPITests
	{
		private LanguageDepotApiTestServer testServer;
		[SetUp]
		public void Setup()
		{
			testServer = new LanguageDepotApiTestServer();
			LanguageDepotApi.Server = testServer;
		}

		[Test]
		public void CreateProjectReturnsExpectedId()
		{
			LanguageDepotApiResponse whatIsIt = new LanguageDepotApiResponse();
			whatIsIt.Identifier = "testy";
			whatIsIt.ErrorMessage = "All broken";
			whatIsIt.StatusCode = 200;

			testServer.ResponseCode = HttpStatusCode.OK;

			var sb = new StringBuilder();
			var sw = new StringWriter(sb);
			using (var writer = new JsonTextWriter(sw))
			{
				writer.WriteStartObject();
				writer.WriteMember("status");
				writer.WriteNumber(200);
				writer.WriteMember("message");
				writer.WriteNull();
				writer.WriteMember("identifier");
				writer.WriteString("lang-flex");
				writer.WriteEndObject();
			}
			testServer.ResponseData = sb.ToString();
			var address = new HttpRepositoryPath("test", "http://user:password@hg-test.languagedepot.org/ignored", true);
			var result = LanguageDepotApi.CreateProject(address);
			Assert.True(result.StatusCode == 200, "Create project should have returned true with this data");
			Assert.AreEqual("lang-flex", result.Identifier, "given data should have returned lang-flex as the identifier");
		}

		[Test]
		public void ProjectExistsReturnsFailureMessage()
		{
			testServer.ResponseCode = HttpStatusCode.Unauthorized;
			testServer.ResponseData = "{\"status\":401, \"message\":\"Cannot create project: the projectID $id already exists\", \"identifier\":null}";
			var address = new HttpRepositoryPath("test", "http://user:password@hg-test.languagedepot.org/ignored", true);
			var result = LanguageDepotApi.CreateProject(address);
			Assert.False(result.StatusCode == 200, "Create project should have returned false and an error message with this data");
			Assert.True(result.ErrorMessage.Contains("already exists"), "error code should have been returned with already exists");
		}

		internal class LanguageDepotApiTestServer : ILanguageDepotServer
		{
			public HttpStatusCode ResponseCode = HttpStatusCode.OK;
			public string ResponseData = null;
			public HttpWebResponse CreateProject(HttpRepositoryPath address)
			{
				return new TestHttpWebResponse(ResponseCode, ResponseData);
			}
		}

		internal class TestHttpWebResponse : HttpWebResponse
		{
			private System.IO.Stream responseStream;
			private HttpStatusCode code;
#pragma warning disable 612,618 //Using the obsolete constructor lets us imitate a real response in a helpful way
			internal TestHttpWebResponse(HttpStatusCode statusCode, String data) : base(MakeDefaultSI(statusCode), new StreamingContext())
#pragma warning restore 612,618
			{
				code = statusCode;
				responseStream = new MemoryStream(Encoding.UTF8.GetBytes(data));
			}

			/// <summary>
			/// All this is required to make a fake HttpWebResponse in order
			/// </summary>
			/// <param name="statusCode"></param>
			/// <returns></returns>
			private static SerializationInfo MakeDefaultSI(HttpStatusCode statusCode)
			{
				var si = new SerializationInfo(typeof(HttpWebResponse), new FormatterConverter());
				var headers = new WebHeaderCollection();
				var uri = new UriBuilder(Uri.UriSchemeHttp, "test", 80, "test").Uri;
				si.AddValue("m_HttpResponseHeaders", headers);
				si.AddValue("m_Uri", uri);
				si.AddValue("m_Certificate", null);
				si.AddValue("m_Version", HttpVersion.Version11);
				si.AddValue("m_StatusCode", statusCode);
				si.AddValue("m_ContentLength", 0);
				si.AddValue("m_Verb", "GET");
				si.AddValue("m_StatusDescription", "BORK");
				si.AddValue("m_MediaType", null);
				return si;
			}

			public override Stream GetResponseStream()
			{
				return responseStream;
			}
		}
	}
}
