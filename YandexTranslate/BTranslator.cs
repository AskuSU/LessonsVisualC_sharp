using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexLinguistics.NET;

namespace YandexTranslate
{
    class BTranslator
    {
        Translator tr;

        const string translatorKey = "trnsl.1.1.20190320T115430Z.9fa4c616e8fc4159.070949d62cb50d697ad46f9909cb4a5daae35061";

        public string[] LangIsMas = new string[] {  "",
                                                    "русский",
                                                    "английский",
                                                    "польский",
                                                    "украинский",
                                                    "немецкий",
                                                    "французский",
                                                    "испанский",
                                                    "итальянский",
                                                    "турецкий",
                                                    "азербайджанский",
                                                    "белорусский",
                                                    "болгарский",
                                                    "чешский",
                                                    "румынский",
                                                    "сербский",
                                                    "каталанский",
                                                    "датский",
                                                    "греческий",
                                                    "эстонский",
                                                    "финский",
                                                    "венгерский",
                                                    "литовский",
                                                    "латышский",
                                                    "македонский",
                                                    "голландский",
                                                    "норвежский",
                                                    "португальский",
                                                    "словацкий",
                                                    "словенский",
                                                    "албанский",
                                                    "шведский",
                                                    "хорватский",
                                                    "армянский"};

        public BTranslator()
        {
            tr = new Translator(translatorKey);

        }

        public LangPair GetLangPair(string inputLang, string outputLang)
        {
            LangPair lp = new LangPair();

            for (int i = 0; i < LangIsMas.Length / 2; i++)
            {
                if (inputLang.ToLower() == LangIsMas[i])
                {
                    lp.InputLang = (Lang)i;
                }

                if (outputLang.ToLower() == LangIsMas[i])
                {
                    lp.OutputLang = (Lang)i;
                }
            }

            return lp;
        }

        public string Translator(string wordToTranslate, LangPair langPair)
        {
            return tr.Translate(wordToTranslate, langPair).Text;
        }

    }
}
