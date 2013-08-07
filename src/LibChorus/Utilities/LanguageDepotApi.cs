using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using Chorus.VcsDrivers;
using Jayrock.Json;
using Jayrock.Json.Conversion;

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
			private int _id;
			public HttpWebResponse CreateProject(Uri address, string projectName,
												 string projectPassword, string projectType,
												 string languageId, string email)
			{
				var call = new JsonObject();
				call["id"] = ++_id;
				call["method"] = "addProjectWithPassword";
				var password = String.IsNullOrEmpty(projectPassword)
									? GenerateUnspecifiedPassword(projectName)
									: projectPassword;
				call["params"] = new JsonArray(new List<String> { projectName, email, password, projectType, languageId });
				string callString = JsonConvert.ExportToString(call);
				byte[] callBytes = Encoding.UTF8.GetBytes(callString);

				var request = WebRequest.Create(RedirectAddressToApi(address));
				request.Method = "POST";
				request.ContentType = "application/json; charset=UTF-8";
				request.ContentLength = callBytes.Length;

				using (var stream = request.GetRequestStream())
				{
					stream.Write(callBytes, 0, callBytes.Length);
				}
				return (HttpWebResponse)request.GetResponse();
			}
		}

		public static LanguageDepotApiResponse CreateProject(Uri address, string projectName,
															 string projectPassword, string projectType,
															 string languageId, string email)
		{
			if (!CheckValidEmail(email))
			{
				return null;
			}
			using (var response = Server.CreateProject(address, projectName, projectPassword, projectType, languageId, email))
			using (var stream = response.GetResponseStream())
			{
				return LanguageDepotApiResponse.From(stream);
			}
		}

		private static bool CheckValidEmail(string email)
		{
			//Validating e-mails according to the RFC is far too troublesome to implement, just use the .NET constructor
			//and catch since the parser is not exposed, even though it pains me to do so.
			try
			{
				if (String.IsNullOrEmpty(email))
				{
					return true;
				}
				//creation will succeed if address is valid, otherwise it will throw (no better way in the MS api)
#pragma warning disable 168
				var test = new MailAddress(email);
#pragma warning restore 168
				return true;
			}
			catch
			{
				return false;
			}
		}

		internal static Uri RedirectAddressToApi(Uri address)
		{
			const string apiPage = "LanguageDepotAPI.php";
			const string apiPath = @"api/admin/V01/LanguageDepot/" + apiPage;
			var redirectedUri = new UriBuilder(address);
			if (redirectedUri.Path.ToLowerInvariant().EndsWith(apiPage.ToLowerInvariant()))
				return redirectedUri.Uri; // no change
			var builder = new UriBuilder(Uri.UriSchemeHttp, redirectedUri.Host, 80, apiPath);
			return builder.Uri;
		}


		/// <summary>
		/// If the project does not specify a password, create one that can be determined by the projectName
		/// </summary>
		/// <param name="projectName"></param>
		/// <returns></returns>
		public static string GenerateUnspecifiedPassword(string projectName)
		{
			return "unspecified-" + projectName;
		}

		//public static void ParseAddress(HttpRepositoryPath address, out Uri serverAddress, out string projectId)
		//{
		//    var apiPage = @"src/LanguageDepot/LanguageDepotAPI.php";
		//    var addressUri = new UriBuilder(address.URI);
		//    var builder = new UriBuilder(Uri.UriSchemeHttp, addressUri.Host, 80, apiPage);
		//    if (!String.IsNullOrEmpty(address.UserName))
		//    {
		//        builder.UserName = address.UserName;
		//        builder.Password = address.Password;
		//    }
		//    else
		//    {
		//        builder.UserName = @"FLExUser";
		//        builder.Password = @"inscrutable";
		//    }
		//    serverAddress = builder.Uri;
		//    projectId = addressUri.Path.Substring(addressUri.Path.LastIndexOf('/') + 1);
		//}
	}

	internal interface ILanguageDepotServer
	{
		HttpWebResponse CreateProject(Uri address, string projectName,
									  string projectPassword, string projectType,
									  string projectId, string email);
	}
}
