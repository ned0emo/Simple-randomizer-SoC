using Simple_randomizer_SoC.Models.AppConfig;
using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Simple_randomizer_SoC.Generators
{
    public class DialogGenerator : IGenerator<DialogConfig>
    {
        const string exitDialogId = "1917";
        const string npcPhraseIdPrefix = "228";
        const string playerPhraseIdPrefix = "1337";

        private static readonly Regex commentFinder = new Regex("<!--.*-->\\s*");

        private readonly ProbabilityChecker _probabilityChecker = new ProbabilityChecker();

        private readonly Random rnd = new Random();

        private string _outPath = null;
        private DialogConfig _config = null;

        public async Task Generate()
        {
            var path = MyEnvironment.configPath + "\\gameplay_dialogs";
            var outPath = _outPath + "\\gameplay\\";

            var outDocs = new Dictionary<string, XmlDocument>();

            //как в диалогах, так и в фразах
            var preconditionsSet = new HashSet<string>();
            var infosSet = new HashSet<string>();
            //только во фразах
            var textsSet = new HashSet<string>();
            var actionsSet = new HashSet<string>();

            var dialogs = new List<XmlElement>();

            var files = new DirectoryInfo(path).GetFiles();
            foreach (var file in files)
            {
                var text = await MyFile.Read(file.FullName);
                var doc = new XmlDocument();
                doc.LoadXml(commentFinder.Replace(text, ""));
                outDocs.Add(file.Name, doc);

                var docDialogs = doc.GetElementsByTagName("dialog");
                foreach (XmlElement dialog in docDialogs)
                {
                    if (_probabilityChecker.Skip(rnd)) continue;

                    dialogs.Add(dialog);

                    //заполняет infos, actions, texts, preconditions непустыми строками с Trim
                    readNode(dialog.ChildNodes);
                }
            }

            //как в диалогах, так и в фразах
            var preconditions = new List<string>();
            preconditions.AddRange(preconditionsSet);
            var infos = new List<string>();
            infos.AddRange(infosSet);
            //только во фразах
            var texts = new List<string>();
            texts.AddRange(textsSet);
            var actions = new List<string>();
            actions.AddRange(actionsSet);

            if (texts.Count == 0) return;

            foreach (var dialog in dialogs)
            {
                var doc = dialog.OwnerDocument;
                dialog.InnerText = "";
                var phraseList = doc.CreateElement("phrase_list");

                List<string> currentHasInfos = new List<string>();

                //условия и дествия всего диалога

                if (infos.Count > 0)
                {
                    if (rnd.Next(1000) < 383)
                    {
                        var hasInfos = CollectionUtils.GetRandomElements(infos, rnd.Next(1, 4), rnd);
                        for (int i = 0; i < hasInfos.Count; i++)
                        {
                            var info = hasInfos[i];
                            currentHasInfos.Add(info);
                            var hasInfoNode = doc.CreateNode(XmlNodeType.Element, "has_info", null);
                            hasInfoNode.InnerText = info;
                            phraseList.AppendChild(hasInfoNode);
                        }
                    }

                    if (rnd.Next(1000) < 376)
                    {
                        var acceptedInfos = infos.Where(i => !currentHasInfos.Contains(i)).ToList();
                        var selectedInfos = CollectionUtils.GetRandomElements(acceptedInfos, rnd.Next(1, 3), rnd);

                        for (int i = 0; i < acceptedInfos.Count; i++)
                        {
                            var dontHasInfoNode = doc.CreateNode(XmlNodeType.Element, "dont_has_info", null);
                            dontHasInfoNode.InnerText = acceptedInfos[i];
                            phraseList.AppendChild(dontHasInfoNode);
                        }
                    }
                }

                if (rnd.Next(1000) < 181 && preconditions.Count > 0)
                {
                    var preconditionNode = doc.CreateNode(XmlNodeType.Element, "precondition", null);
                    preconditionNode.InnerText = CollectionUtils.GetRandomElement(preconditions, rnd);
                    phraseList.AppendChild(preconditionNode);
                }

                //ветка выхода из диалога
                var savePhrase = doc.CreateNode(XmlNodeType.Element, "phrase", null);
                var saveId = doc.CreateAttribute("id");
                saveId.Value = exitDialogId;
                savePhrase.Attributes.Append(saveId);

                var saveText = doc.CreateNode(XmlNodeType.Element, "text", null);
                saveText.InnerText = "Выйти из диалога/Exit the dialog";
                savePhrase.AppendChild(saveText);

                var saveAction = doc.CreateNode(XmlNodeType.Element, "action", null);
                saveAction.InnerText = "dialogs.break_dialog";
                savePhrase.AppendChild(saveAction);

                phraseList.AppendChild(savePhrase);

                //иногда ветки игрока и НПС свапаются, хз почему
                //втеки фраз игрока
                var playerPhraseCount = rnd.Next(3, 16);
                var npcPhraseCount = rnd.Next(3, 16);

                for (int p = 0; p < playerPhraseCount; p++)
                {
                    var phraseNode = doc.CreateNode(XmlNodeType.Element, "phrase", null);
                    var id = doc.CreateAttribute("id");
                    //вроде, диалог обяз начинается с 0 id
                    id.Value = p == 0 ? "0" : (playerPhraseIdPrefix + p);
                    //id.Value = playerPhraseIdPrefix + p;
                    phraseNode.Attributes.Append(id);

                    var textNode = doc.CreateNode(XmlNodeType.Element, "text", null);
                    textNode.InnerText =
                        //ИД фразы перед текстом диалога для отладки
                        //id.Value +
                        CollectionUtils.GetRandomElement(texts, rnd);
                    phraseNode.AppendChild(textNode);

                    if (rnd.Next(1000) < 132 && actions.Count > 0)
                    {
                        var actionNode = doc.CreateNode(XmlNodeType.Element, "action", null);
                        actionNode.InnerText = CollectionUtils.GetRandomElement(actions, rnd);
                        phraseNode.AppendChild(actionNode);
                    }

                    if (rnd.Next(1000) < 183 && infos.Count > 0)
                    {
                        var giveInfoNode = doc.CreateNode(XmlNodeType.Element, "give_info", null);
                        giveInfoNode.InnerText = CollectionUtils.GetRandomElement(infos, rnd);
                        phraseNode.AppendChild(giveInfoNode);
                    }

                    if (rnd.Next(1000) < 957)
                    {
                        var nextCount = rnd.Next(1, Math.Min(7, npcPhraseCount));
                        var list = new List<int>();
                        for (int i = 0; i < npcPhraseCount; i++)
                        {
                            list.Add(i);
                        }
                        for (int n = 0; n < nextCount; n++)
                        {
                            var nextNode = doc.CreateNode(XmlNodeType.Element, "next", null);
                            var nextIdIndex = rnd.Next(list.Count);
                            nextNode.InnerText = npcPhraseIdPrefix + list[nextIdIndex];
                            list.RemoveAt(nextIdIndex);
                            phraseNode.AppendChild(nextNode);
                        }
                    }

                    //выхход из диалога будет отображен всегда???
                    var saveNode = doc.CreateNode(XmlNodeType.Element, "next", null);
                    saveNode.InnerText = exitDialogId;
                    phraseNode.AppendChild(saveNode);

                    phraseList.AppendChild(phraseNode);
                }

                //ветки фраз НПС
                for (int p = 0; p < npcPhraseCount; p++)
                {
                    var phraseNode = doc.CreateNode(XmlNodeType.Element, "phrase", null);
                    var id = doc.CreateAttribute("id");
                    id.Value = npcPhraseIdPrefix + p;
                    phraseNode.Attributes.Append(id);

                    var textNode = doc.CreateNode(XmlNodeType.Element, "text", null);
                    textNode.InnerText =
                        //ИД фразы перед текстом диалога для отладки
                        //id.Value +
                        CollectionUtils.GetRandomElement(texts, rnd);
                    phraseNode.AppendChild(textNode);

                    if (rnd.Next(1000) < 34 && preconditions.Count > 0)
                    {
                        var preconditionNode = doc.CreateNode(XmlNodeType.Element, "precondition", null);
                        preconditionNode.InnerText = CollectionUtils.GetRandomElement(preconditions, rnd);
                        phraseNode.AppendChild(preconditionNode);
                    }

                    if (rnd.Next(1000) < 132 && actions.Count > 0)
                    {
                        var actionNode = doc.CreateNode(XmlNodeType.Element, "action", null);
                        actionNode.InnerText = CollectionUtils.GetRandomElement(actions, rnd);
                        phraseNode.AppendChild(actionNode);
                    }

                    if (infos.Count > 0)
                    {
                        if (rnd.Next(1000) < 183)
                        {
                            var giveInfoNode = doc.CreateNode(XmlNodeType.Element, "give_info", null);
                            giveInfoNode.InnerText = CollectionUtils.GetRandomElement(infos, rnd);
                            phraseNode.AppendChild(giveInfoNode);
                        }

                        if (rnd.Next(1000) < 270)
                        {
                            var dontHasInfoNode = doc.CreateNode(XmlNodeType.Element, "dont_has_info", null);
                            dontHasInfoNode.InnerText = CollectionUtils.GetRandomElement(infos, rnd);
                            phraseNode.AppendChild(dontHasInfoNode);
                        }

                        if (rnd.Next(1000) < 165)
                        {
                            var hasInfoNode = doc.CreateNode(XmlNodeType.Element, "has_info", null);
                            hasInfoNode.InnerText = CollectionUtils.GetRandomElement(infos, rnd);
                            phraseNode.AppendChild(hasInfoNode);
                        }
                    }

                    if (rnd.Next(1000) < 957)
                    {
                        var nextNode = doc.CreateNode(XmlNodeType.Element, "next", null);
                        var nextIdIndex = rnd.Next(1, playerPhraseCount);
                        nextNode.InnerText = playerPhraseIdPrefix + nextIdIndex;
                        phraseNode.AppendChild(nextNode);
                    }
                    else
                    {
                        var saveNode = doc.CreateNode(XmlNodeType.Element, "next", null);
                        saveNode.InnerText = exitDialogId;
                        phraseNode.AppendChild(saveNode);
                    }

                    phraseList.AppendChild(phraseNode);
                }
                dialog.AppendChild(phraseList);
            }

            await Task.Run(() =>
            {
                Directory.CreateDirectory(outPath);
                foreach (var doc in outDocs)
                {
                    using (var sw = new StreamWriter(outPath + doc.Key, false, Encoding.Default))
                    {
                        doc.Value.Save(sw);
                    }
                }
            });

            void readNode(XmlNodeList nodeList)
            {
                foreach (XmlNode node in nodeList)
                {
                    var innerText = node.InnerText.Trim();
                    if (innerText.Length == 0) continue;

                    switch (node.Name)
                    {
                        case "precondition":
                            if (!_config.PreconditionExceptions.Contains(innerText)) preconditionsSet.Add(innerText);
                            break;
                        case "has_info":
                        case "dont_has_info":
                        case "give_info":
                            if (!_config.InfoExceptions.Contains(innerText)) infosSet.Add(innerText);
                            break;
                        case "action":
                            if (!_config.ActionExceptions.Contains(innerText)) actionsSet.Add(innerText);
                            break;
                        case "text":
                            textsSet.Add(innerText);
                            break;
                        case "next":
                            readNode(node.ChildNodes);
                            break;
                        case "dialog":
                            readNode(node.ChildNodes);
                            break;
                        case "phrase":
                            readNode(node.ChildNodes);
                            break;
                        default:
                            readNode(node.ChildNodes);
                            break;
                    }
                }
            }
        }

        public void UpdateData(DialogConfig config, string baseOutPath, bool randomProbability)
        {
            _config = config;
            _outPath = baseOutPath;
            _probabilityChecker.SetProbability(randomProbability ? rnd.Next(100) + 1 : config.ReplaceProbability);
        }
    }
}
