using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using Community.PowerToys.Run.Plugin.DeepLTranslator.Enums;
using Community.PowerToys.Run.Plugin.DeepLTranslator.Models;

namespace Community.PowerToys.Run.Plugin.DeepLTranslator.Job
{
    public class JobHttp
    {
        private static HttpClient httpClient;

        private static string oldAPIKey;

        public static async Task<TranslationResult> Translation(LangCodeEnums.Code targetCode, string text, string apiKey)
        {
            if (httpClient == null || oldAPIKey != apiKey)
            {
                Init(apiKey);
            }

            if (httpClient != null)
            {
                try
                {
                    object body = new
                    {
                        text = new string[] { text },
                        target_lang = LangCodeEnums.ToString(targetCode)
                    };

                    using StringContent jsonContent = new(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync("translate", jsonContent);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseString = await response.Content.ReadAsStringAsync();
                        if (responseString != null)
                        {
                            var result = JsonSerializer.Deserialize<TranslationResult>(responseString);
                            if (result != null)
                            {
                                result.TargetLangCode = LangCodeEnums.ToString(targetCode);
                                return result;
                            }
                        }
                    }

                    if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    {
                        return new TranslationResult
                        {
                            Translations =
                            [
                                new Translation
                                {
                                    DetectedSourceLanguage = LangCodeEnums.ToString(LangCodeEnums.Code.UNK),
                                    Text = Properties.Resources.invalid_api_key
                                }
                            ],
                            TargetLangCode = LangCodeEnums.ToString(LangCodeEnums.Code.UNK)
                        };
                    }
                }
                catch (Exception)
                {
                }
            }

            return new TranslationResult
            {
                Translations =
                [
                    new Translation
                    {
                        DetectedSourceLanguage = LangCodeEnums.ToString(LangCodeEnums.Code.UNK),
                        Text = Properties.Resources.error_message_during_translation
                    }
                ],
                TargetLangCode = LangCodeEnums.ToString(LangCodeEnums.Code.UNK)
            };
        }

        private static void Init(string apiKey)
        {
            oldAPIKey = apiKey;

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://api-free.deepl.com/v2/");
            httpClient.DefaultRequestHeaders.Add("Authorization", apiKey);
        }
    }
}
