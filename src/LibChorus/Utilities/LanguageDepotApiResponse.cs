
using System.IO;
using Jayrock.Json;
using Jayrock.Json.Conversion;

namespace Chorus.Utilities
{
	public class LanguageDepotApiResponse
	{
		public string Identifier { get; set; }
		public int StatusCode { get; set; }
		public string ErrorMessage { get; set; }

		internal static LanguageDepotApiResponse From(Stream stream)
		{
			var reader = new StreamReader(stream);
			var inputString = reader.ReadToEnd();
			var response = new LanguageDepotApiResponse();
			var jsonObject = JsonConvert.Import<JsonObject>(inputString);
			response.Identifier = jsonObject["identifier"] as string;
			response.StatusCode = ((JsonNumber)jsonObject["status"]).ToInt32();
			response.ErrorMessage = jsonObject["message"] as string;
			return response;
		}
	}
}
