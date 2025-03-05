using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Community.PowerToys.Run.Plugin.DeepLTranslator.Enums.LangCodeEnums;

namespace Community.PowerToys.Run.Plugin.DeepLTranslator.Enums
{
    public class LangCodeEnums
    {
        public enum Code
        {
            AR,      // Arabic
            BG,      // Bulgarian
            CS,      // Czech
            DA,      // Danish
            DE,      // German
            EL,      // Greek
            EN,      // English (unspecified variant for backward compatibility; please select EN-GB or EN-US instead)
            EN_GB,   // English (British)
            EN_US,   // English (American)
            ES,      // Spanish
            ET,      // Estonian
            FI,      // Finnish
            FR,      // French
            HU,      // Hungarian
            ID,      // Indonesian
            IT,      // Italian
            JA,      // Japanese
            KO,      // Korean
            LT,      // Lithuanian
            LV,      // Latvian
            NB,      // Norwegian Bokmål
            NL,      // Dutch
            PL,      // Polish
            PT,      // Portuguese (unspecified variant for backward compatibility; please select PT-BR or PT-PT instead)
            PT_BR,   // Portuguese (Brazilian)
            PT_PT,   // Portuguese (all Portuguese varieties excluding Brazilian Portuguese)
            RO,      // Romanian
            RU,      // Russian
            SK,      // Slovak
            SL,      // Slovenian
            SV,      // Swedish
            TR,      // Turkish
            UK,      // Ukrainian
            ZH,      // Chinese (simplified)
            UNK,     // Unknown
        }

        public static Code Parse(int code)
        {
            if (code >= 0 && code < (int)Code.UNK)
            {
                return (Code)code;
            }
            return Code.UNK;
        }

        public static Code Parse(string codeString)
        {
            switch (codeString)
            {
                case "gb":
                case "GB":
                case "EN-GB":
                case "EN_GB":
                    return Code.EN_GB;

                case "us":
                case "US":
                case "EN-US":
                case "EN_US":
                    return Code.EN_US;

                case "br":
                case "BR":
                case "PT-BR":
                case "PT_BR":
                    return Code.PT_BR;

                case "pt":
                case "PT":
                case "PT-PT":
                case "PT_PT":
                    return Code.PT_PT;
                default:
                    try
                    {
                        return Enum.Parse<Code>(codeString.ToUpperInvariant());
                    }
                    catch (Exception)
                    {
                        return Code.UNK;
                    }
            }
        }

        public static string ToString(Code code)
        {
            switch (code)
            {
                case Code.EN_GB:
                    return "EN-GB";
                case Code.EN_US:
                    return "EN-US";
                case Code.PT_BR:
                    return "PT-BR";
                case Code.PT_PT:
                    return "PT-PT";
                default:
                    return code.ToString();
            }
        }
    }
}
