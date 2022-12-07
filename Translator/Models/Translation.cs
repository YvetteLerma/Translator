using System;
namespace Translator.Models
{
	public class Translation
	{
		public Translation()
		{
		}

		public string SourceLanguage { get; set; }
		public string TargetLanguage { get; set; }
		public string TextToTranslate { get; set; }
		public string TranslatedLanguage { get; set; }
	}
}

