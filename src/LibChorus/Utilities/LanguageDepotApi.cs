using System;
using System.Net;
using Chorus.VcsDrivers;

namespace Chorus.Utilities
{
	/// <summary>
	/// methods for interacting with the LanguageDepot server
	/// </summary>
	public class LanguageDepotApi
	{
		internal static ILanguageDepotServer Server = new LanguageDepotApiServer();

		internal class LanguageDepotApiServer : ILanguageDepotServer
		{
			public HttpWebResponse CreateProject(HttpRepositoryPath address)
			{
				var restURL = BuildRequestURL(address);
				var request = (HttpWebRequest)WebRequest.Create(restURL);
				request.Method = "GET";
				request.Accept = "text/xml";
				request.ContentType = "text/xml";

				return (HttpWebResponse)request.GetResponse();
			}
		}

		public static LanguageDepotApiResponse CreateProject(HttpRepositoryPath address)
		{
			using (var response = Server.CreateProject(address))
			using (var stream = response.GetResponseStream())
			{
				return LanguageDepotApiResponse.From(stream);
			}
			return null;
		}

		private static Uri BuildRequestURL(HttpRepositoryPath address)
		{
			var apiPage = @"LanguageDepotAPI" + "/" + @"addProjectWithPassword";
			var parameters =
			String.Format("?projectName={0};email={1};password={2};type={3};language={4}", "fake", "fake@fake.fake",
						  address.Password, "flex", address.URI.Substring(address.URI.LastIndexOf('/') + 1));
			var builder = new UriBuilder(Uri.UriSchemeHttp, address.Name, 80, apiPage, parameters);
			builder.UserName = "";
			builder.Password = "";
			return builder.Uri;
		}
	}

	internal interface ILanguageDepotServer
	{
		HttpWebResponse CreateProject(HttpRepositoryPath address);
	}
}
