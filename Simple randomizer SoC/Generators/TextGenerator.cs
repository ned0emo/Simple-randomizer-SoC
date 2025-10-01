using Simple_randomizer_SoC.Models.AppConfig;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Simple_randomizer_SoC.Generators
{
    public class TextGenerator : IGenerator<AdditionalConfig>
    {
        private readonly ProbabilityChecker _translateProbabilityChecker = new ProbabilityChecker();
        private readonly ProbabilityChecker _shuffleProbabilityChecker = new ProbabilityChecker();
        private readonly Random _rnd = new Random();

        private const string _prefix = "<xml_fix_tag>";
        private const string _postfix = "</xml_fix_tag>";

        private AdditionalConfig _config;
        private string _outPath;

        public void UpdateData(AdditionalConfig config, string baseOutPath, bool randomProbability)
        {
            _config = config;
            _outPath = baseOutPath;
            _translateProbabilityChecker.SetProbability(randomProbability ? _rnd.Next(100) + 1 : config.BrokenTranslateProbability);
            _shuffleProbabilityChecker.SetProbability(randomProbability ? _rnd.Next(100) + 1 : config.ShuffleProbability);
        }

        public async Task Generate()
        {
            var outPath = _outPath + "\\config\\text\\";

            var isRussian = _config.Language.ToLower() == "ru";

            Dictionary<string, XmlDocument> docs = null;
            if (_config.UseBrokenTranslate && isRussian)
            {
                docs = await ApplyTranslate();
                if (_config.ShuffleText) ShuffleText(docs);
            }
            else if (_config.ShuffleText)
            {
                docs = new Dictionary<string, XmlDocument>();
                var dir = new DirectoryInfo(MyEnvironment.configPath + "\\text\\" + (isRussian ? "rus" : "eng"));
                foreach (var file in dir.GetFiles())
                {
                    var text = await MyFile.Read(file.FullName);
                    var mainDoc = new XmlDocument();
                    try
                    {
                        mainDoc.LoadXml(text);
                    }
                    catch
                    {
                        mainDoc.LoadXml(_prefix + text + _postfix);
                    }

                    docs[file.Name] = mainDoc;
                }

                ShuffleText(docs);
            }

            if (docs != null && docs.Count > 0)
            {
                if (isRussian) outPath += "rus\\";
                else outPath += "eng";
                Directory.CreateDirectory(outPath);

                foreach (var doc in docs)
                {
                    var text = doc.Value.OuterXml;
                    await MyFile.Write(outPath + doc.Key, text.Replace(_prefix, "").Replace(_postfix, ""));
                }
            }
        }

        private async Task<Dictionary<string, XmlDocument>> ApplyTranslate()
        {
            var result = new Dictionary<string, XmlDocument>();

            var dir = new DirectoryInfo(MyEnvironment.configPath + "\\text\\rus");
            var dirBroken = new DirectoryInfo(MyEnvironment.configPath + "\\text\\rus_broken");

            var mainTextById = new Dictionary<string, XmlElement>();
            var brokenTextById = new Dictionary<string, XmlElement>();

            foreach (var file in dirBroken.GetFiles())
            {
                string mainText;
                if (File.Exists(MyEnvironment.configPath + "\\text\\rus\\" + file.Name))
                {
                    mainText = await MyFile.Read(MyEnvironment.configPath + "\\text\\rus\\" + file.Name);
                }
                else
                {
                    continue;
                }
                var brokenText = await MyFile.Read(file.FullName);

                var mainDoc = new XmlDocument();
                try
                {
                    mainDoc.LoadXml(mainText);
                }
                catch
                {
                    mainDoc.LoadXml(_prefix + mainText + _postfix);
                }
                var brokenDoc = new XmlDocument();
                try
                {
                    brokenDoc.LoadXml(brokenText);
                }
                catch
                {
                    brokenDoc.LoadXml(_prefix + brokenText + _postfix);
                }

                result.Add(file.Name, mainDoc);

                foreach (XmlElement el in mainDoc.GetElementsByTagName("string"))
                {
                    if (el.HasAttribute("id"))
                    {
                        var child = el.GetElementsByTagName("text");
                        if (child.Count > 0)
                        {
                            mainTextById[el.GetAttribute("id")] = (XmlElement)child[0];
                        }
                    }
                }

                foreach (XmlElement el in brokenDoc.GetElementsByTagName("string"))
                {
                    if (el.HasAttribute("id"))
                    {
                        var child = el.GetElementsByTagName("text");
                        if (child.Count > 0)
                        {
                            brokenTextById[el.GetAttribute("id")] = (XmlElement)child[0];
                        }
                    }
                }
            }

            foreach (var mainText in mainTextById)
            {
                _translateProbabilityChecker.DoOrSkip(_rnd, () =>
                {
                    if (brokenTextById.ContainsKey(mainText.Key))
                    {
                        mainText.Value.InnerText = brokenTextById[mainText.Key].InnerText;
                    }
                });
            }

            return result;
        }

        private void ShuffleText(Dictionary<string, XmlDocument> docs)
        {
            var elementsByLength = new Dictionary<int, List<XmlElement>>();

            foreach (var doc in docs.Values)
            {
                foreach (XmlElement el in doc.GetElementsByTagName("text"))
                {
                    _shuffleProbabilityChecker.DoOrSkip(_rnd, () =>
                    {
                        var length = el.InnerText.Length / 5 * 5;
                        if (elementsByLength.TryGetValue(length, out var list))
                        {
                            list.Add(el);
                        }
                        else
                        {
                            elementsByLength[length] = new List<XmlElement> { el };
                        }
                    });
                }
            }

            foreach (var elsWithLen in elementsByLength)
            {
                var list = elsWithLen.Value;
                if (list.Count < 2) continue;

                for (int i = 0; i < list.Count; i++)
                {
                    var rndIndex = _rnd.Next(list.Count);
                    if (rndIndex == i) continue;

                    (list[rndIndex].InnerText, list[i].InnerText) = (list[i].InnerText, list[rndIndex].InnerText);
                }
            }
        }

        public string StatusText()
        {
            return Localization.Get("textGen");
        }
    }
}
