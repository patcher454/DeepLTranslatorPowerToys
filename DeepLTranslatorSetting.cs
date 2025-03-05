using Community.PowerToys.Run.Plugin.DeepLTranslator.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community.PowerToys.Run.Plugin.DeepLTranslator
{
    public class DeepLTranslatorSetting
    {
        public string DeeplAPIKey { get; set; } = string.Empty;

        public bool RemoveLeftSpaces { get; set; } = false;

        public int DefaultTargetLanguageCode { get; set; } = (int)LangCodeEnums.Code.EN;
    }
}
