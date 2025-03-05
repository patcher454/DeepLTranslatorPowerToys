using Community.PowerToys.Run.Plugin.DeepLTranslator.Enums;


using Wox.Plugin;

namespace Community.PowerToys.Run.Plugin.DeepLTranslator
{
    public class InputInterpreter
    {
        public static (LangCodeEnums.Code, string) Parse(Query query, LangCodeEnums.Code defaultLangCode)
        {
            if (string.IsNullOrWhiteSpace(query.Search))
                return (LangCodeEnums.Code.UNK, string.Empty);

            var parts = query.Search.Split(new[] { ' ' }, 2);

            if (parts.Length == 2)
            {
                string targetLangCode = parts[0];
                string text = parts[1];

                if (!string.IsNullOrEmpty(targetLangCode) && !string.IsNullOrEmpty(text))
                {
                    var target = LangCodeEnums.Parse(targetLangCode);
                    if (target == LangCodeEnums.Code.UNK)
                    {
                        return (defaultLangCode, query.Search);
                    }
                    return (target, text);
                }
            }

            if (parts.Length == 1)
            {
                string text = parts[0];
                if (!string.IsNullOrEmpty(text))
                {
                    return (defaultLangCode, text);
                }
            }

            return (LangCodeEnums.Code.UNK, string.Empty);
        }
    }
}
