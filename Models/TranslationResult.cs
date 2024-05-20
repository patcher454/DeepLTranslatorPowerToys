using System.Collections.Generic;
using System.Text.Json.Serialization;
using Community.PowerToys.Run.Plugin.DeepLTranslator.Enums;

namespace Community.PowerToys.Run.Plugin.DeepLTranslator.Models
{
    public class TranslationResult
    {
        [JsonIgnore]
        public string TargetLangCode { get; set; }

        [JsonPropertyName("translations")]
        public List<Translation> Translations { get; set; }
    }
}
