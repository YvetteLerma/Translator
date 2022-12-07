using System;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using RestSharp;
using Translator.Models;

namespace Translator
{
	public class APIClient : IAPIClient
	{
        private readonly string _conn;

		public APIClient(string conn)
		{
            _conn = conn;
		}

		public Translation Translate(Translation translation)
		{
            //string key = File.ReadAllText("appsettings.json");
            //string apiKey = JObject.Parse(key).GetValue("DefaultKey").ToString();

            //Console.WriteLine("Didnt pay too much attention in Spanish Class? That's okay, type below what you would like to translate.");
            //string translatedText = Console.ReadLine();
            
            var client = new RestClient("https://google-translate1.p.rapidapi.com/language/translate/v2");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("Accept-Encoding", "application/gzip");
            request.AddHeader("X-RapidAPI-Key", $"{_conn}");
            request.AddHeader("X-RapidAPI-Host", "google-translate1.p.rapidapi.com");
            request.AddParameter("application/x-www-form-urlencoded", $"q={translation.TextToTranslate}&target=es&source=en", ParameterType.RequestBody);
            IRestResponse apiCall = client.Execute(request);

            translation.TranslatedLanguage = JObject.Parse(apiCall.Content)["data"]["translations"][0]["translatedText"].ToString();

            return translation;
        }
	}
}

