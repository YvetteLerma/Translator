using System;
using Translator.Models;

namespace Translator
{
	public interface IAPIClient
	{
        public Translation Translate(Translation translation);

    }
}

