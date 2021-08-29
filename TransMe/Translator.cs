using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TransMe
{
    class Translator
    {
        public async Task<string> Translate(string word)
        {
            if (null == word)
            {
                return "";
            }

            var toLanguage = "zh";
            var fromLanguage = "en";
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={Uri.EscapeDataString(word)}";
            var webClient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            var result = await webClient.DownloadStringTaskAsync(url);
            try
            {
                return Parse(result);
            }
            catch
            {
                return "Error";
            }

        }

        private string Parse(string result)
        {
            // Ref: https://github.com/wadereye/GoogleTranslateFreeApi/blob/master/GoogleTranslateFreeApi/GoogleTranslator.cs
            JToken tmp = JsonConvert.DeserializeObject<JToken>(result);
            string originalTextTranscription = null, translatedTextTranscription = null;

            GetMainTranslationInfo(tmp[0], out var translation,
                ref originalTextTranscription, ref translatedTextTranscription);
            var mainTranslationInfo = tmp[0];
            return string.Join('\n', translation);

        }

        protected static void GetMainTranslationInfo(JToken translationInfo, out string[] translate,
            ref string originalTextTranscription, ref string translatedTextTranscription)
        {
            List<string> translations = new List<string>();

            foreach (var item in translationInfo)
            {
                if (item.Count() >= 5)
                    translations.Add(item.First.Value<string>());
                else
                {
                    var transcriptionInfo = item;
                    int elementsCount = transcriptionInfo.Count();

                    if (elementsCount == 3)
                    {
                        translatedTextTranscription = (string)transcriptionInfo[elementsCount - 1];
                    }
                    else
                    {
                        if (transcriptionInfo[elementsCount - 2] != null)
                            translatedTextTranscription = (string)transcriptionInfo[elementsCount - 2];
                        else
                            translatedTextTranscription = (string)transcriptionInfo[elementsCount - 1];

                        originalTextTranscription = (string)transcriptionInfo[elementsCount - 1];
                    }
                }
            }

            translate = translations.ToArray();
        }

    }
}
