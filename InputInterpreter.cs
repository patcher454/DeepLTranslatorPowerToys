using Community.PowerToys.Run.Plugin.DeepLTranslator.Enums;


using Wox.Plugin;

namespace Community.PowerToys.Run.Plugin.DeepLTranslator
{
    public class InputInterpreter
    {
        public static (LangCodeEnums.Code, string) Parse(Query query)
        {
            var splited = SplitSearch(query);

            if (splited.Length == 2)
            {
                string targetLangCode = splited[0];
                string text = splited[1];

                if (!string.IsNullOrEmpty(targetLangCode) && !string.IsNullOrEmpty(text))
                {
                    var target = LangCodeEnums.Parse(targetLangCode);
                    return (target, text);
                }
            }

            return (LangCodeEnums.Code.UNK, string.Empty);
        }

        private static string[] SplitSearch(Query query)
        {
            int secondSearchStartIndex = query.Search.IndexOf(' ');
            return new string[]
            {
                query.Search.Substring(0, secondSearchStartIndex),
                query.Search.Substring(secondSearchStartIndex, query.Search.Length - secondSearchStartIndex),
            };
        }
    }
}
