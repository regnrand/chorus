using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
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
			public HttpWebResponse CreateProject(HttpRepositoryPath address, string email)
			{
				var call = new JsonObject();
				call["id"] = ++_id;
				call["method"] = "addProjectWithPassword";
				string callString = JsonConvert.ExportToString(call);
				byte[] callBytes = Encoding.UTF8.GetBytes(callString);
				Uri addressUri;
				string projectId;
				ParseAddress(address, out addressUri, out projectId);
				call["params"] = new JsonArray(new List<String> { address.Name, email, address.Password, "flex", projectId });
				WebRequest request = WebRequest.Create(addressUri);
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

		public static LanguageDepotApiResponse CreateProject(HttpRepositoryPath address, string email)
		{
			using (var response = Server.CreateProject(address, email))
			using (var stream = response.GetResponseStream())
			{
				return LanguageDepotApiResponse.From(stream);
			}
		}

		public static void ParseAddress(HttpRepositoryPath address, out Uri serverAddress, out string projectId)
		{
			var apiPage = @"src/LanguageDepot/LanguageDepotAPI.php";
			var addressUri = new UriBuilder(address.URI);
			var builder = new UriBuilder(Uri.UriSchemeHttp, addressUri.Host, 80, apiPage);
			serverAddress = builder.Uri;
			projectId = addressUri.Path.Substring(addressUri.Path.LastIndexOf('/') + 1);
		}
	}

	internal interface ILanguageDepotServer
	{
		HttpWebResponse CreateProject(HttpRepositoryPath address, string email);
	}
}
