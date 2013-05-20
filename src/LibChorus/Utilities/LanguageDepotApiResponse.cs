
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
			var jsonRpcResponse = JsonConvert.Import<JsonObject>(inputString);
			var methodResponse = jsonRpcResponse["response"] as JsonObject;
			if (methodResponse != null)
			{
				response.Identifier = methodResponse["identifier"] as string;
				response.StatusCode = int.Parse(methodResponse["status"] as string);
				response.ErrorMessage = methodResponse["message"] as string;
			}
			return response;
		}
	}
}