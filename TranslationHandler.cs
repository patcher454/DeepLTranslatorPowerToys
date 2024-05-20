using System;
using System.Collections.Generic;

using Community.PowerToys.Run.Plugin.DeepLTranslator.Enums;
using Community.PowerToys.Run.Plugin.DeepLTranslator.Job;
using Community.PowerToys.Run.Plugin.DeepLTranslator.Models;

namespace Community.PowerToys.Run.Plugin.DeepLTranslator
{
    public class TranslationHandler
    {
        public static IEnumerable<TranslationResult> Convert(LangCodeEnums.Code targetCode, string text, DeepLTranslatorSetting settings)
        {
            var results = new List<TranslationResult>();
            try
            {
                results.Add(JobHttp.Translation(targetCode, text, settings.DeeplAPIKey).GetAwaiter().GetResult());
            }
            catch (Exception)
            {
                return new List<TranslationResult>();
            }

            return results;
        }
    }
}
