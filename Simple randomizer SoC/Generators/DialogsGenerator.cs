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
    internal class DialogsGenerator
    {
        const string exitDialogId = "1917";
        const string npcPhraseIdPrefix = "228";
        const string playerPhraseIdPrefix = "1337";

        string[] incorrectInfos;
        string[] incorrectActions;

        bool isDataLoaded = false;

        string newConfigPath;

        public void UpdateData(string incorrectInfos, string incorrectActions, string newConfigPath)
        {
            this.incorrectInfos = Regex.Split(incorrectInfos, "[\\r\\n]+");
            this.incorrectActions = Regex.Split(incorrectActions, "[\\r\\n]+");
            this.newConfigPath = newConfigPath;

            isDataLoaded = true;
        }

        public async Task Generate()
        {
            if (!isDataLoaded)
            {
                throw new CustomException("Данные для генерации диалогов не загружены. Операция прервана");
            }

            var docs = new Dictionary<XmlDocument, string>();

            //как в диалогах, так и в фразах
            var preconditions = new HashSet<string>();
            var infos = new HashSet<string>();

            //только во фразах
            var texts = new HashSet<string>();
            var actions = new HashSet<string>();

            var files = Directory.GetFiles(Environment.configPath + "\\gameplay_dialogs");
            foreach (var file in files)
            {
                var data = File.ReadAllText(file);

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(data);
                docs.Add(xmlDocument, Path.GetFileName(file));

                //заполняет infos, actions, texts, preconditions непустыми строками с Trim
                readNode(xmlDocument.ChildNodes, xmlDocument.Name);
            }

            //удаление исключений
            infos.RemoveWhere(i => incorrectInfos.Contains(i.Trim()));
            actions.RemoveWhere(a => incorrectActions.Contains(a.Trim()));

            var rnd = new Random();

            foreach (var doc in docs.Keys)
            {
                foreach (XmlNode node in doc.ChildNodes)
                {
                    if (node.Name == "game_dialogs")
                    {
                        foreach (XmlNode dialog in node.ChildNodes)
                        {
                            if (!(dialog is XmlElement)) continue;

                            dialog.InnerText = "";
                            var phraseList = doc.CreateNode(XmlNodeType.Element, "phrase_list", null);

                            List<string> currentHasInfos = new List<string>();

                            //условия и дествия всего диалога
                            if (rnd.Next(1000) < 383)
                            {
                                var hasInfosCount = rnd.Next(1, 4);
                                for (int i = 0; i < hasInfosCount; i++)
                                {
                                    var info = infos.ElementAt(rnd.Next(infos.Count));
                                    currentHasInfos.Add(info);
                                    var hasInfoNode = doc.CreateNode(XmlNodeType.Element, "has_info", null);
                                    hasInfoNode.InnerText = info;
                                    phraseList.AppendChild(hasInfoNode);
                                }
                            }

                            if (rnd.Next(1000) < 376)
                            {
                                var dontHasInfosCount = rnd.Next(1, 3);
                                var acceptedInfos = infos.Where(i => !currentHasInfos.Contains(i));
                                for (int i = 0; i < dontHasInfosCount; i++)
                                {
                                    var dontHasInfoNode = doc.CreateNode(XmlNodeType.Element, "dont_has_info", null);
                                    dontHasInfoNode.InnerText = acceptedInfos.ElementAt(rnd.Next(acceptedInfos.Count()));
                                    phraseList.AppendChild(dontHasInfoNode);
                                }
                            }

                            if (rnd.Next(1000) < 181)
                            {
                                var preconditionNode = doc.CreateNode(XmlNodeType.Element, "precondition", null);
                                preconditionNode.InnerText = preconditions.ElementAt(rnd.Next(preconditions.Count));
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
                                    texts.ElementAt(rnd.Next(texts.Count));
                                phraseNode.AppendChild(textNode);

                                if (rnd.Next(1000) < 132)
                                {
                                    var actionNode = doc.CreateNode(XmlNodeType.Element, "action", null);
                                    actionNode.InnerText = actions.ElementAt(rnd.Next(actions.Count));
                                    phraseNode.AppendChild(actionNode);
                                }

                                if (rnd.Next(1000) < 183)
                                {
                                    var giveInfoNode = doc.CreateNode(XmlNodeType.Element, "give_info", null);
                                    giveInfoNode.InnerText = infos.ElementAt(rnd.Next(infos.Count));
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
                                    texts.ElementAt(rnd.Next(texts.Count));
                                phraseNode.AppendChild(textNode);

                                if (rnd.Next(1000) < 34)
                                {
                                    var preconditionNode = doc.CreateNode(XmlNodeType.Element, "precondition", null);
                                    preconditionNode.InnerText = preconditions.ElementAt(rnd.Next(preconditions.Count));
                                    phraseNode.AppendChild(preconditionNode);
                                }

                                if (rnd.Next(1000) < 132)
                                {
                                    var actionNode = doc.CreateNode(XmlNodeType.Element, "action", null);
                                    actionNode.InnerText = actions.ElementAt(rnd.Next(actions.Count));
                                    phraseNode.AppendChild(actionNode);
                                }

                                if (rnd.Next(1000) < 183)
                                {
                                    var giveInfoNode = doc.CreateNode(XmlNodeType.Element, "give_info", null);
                                    giveInfoNode.InnerText = infos.ElementAt(rnd.Next(infos.Count));
                                    phraseNode.AppendChild(giveInfoNode);
                                }

                                if (rnd.Next(1000) < 270)
                                {
                                    var dontHasInfoNode = doc.CreateNode(XmlNodeType.Element, "dont_has_info", null);
                                    dontHasInfoNode.InnerText = infos.ElementAt(rnd.Next(infos.Count));
                                    phraseNode.AppendChild(dontHasInfoNode);
                                }

                                if (rnd.Next(1000) < 165)
                                {
                                    var hasInfoNode = doc.CreateNode(XmlNodeType.Element, "has_info", null);
                                    hasInfoNode.InnerText = infos.ElementAt(rnd.Next(infos.Count));
                                    phraseNode.AppendChild(hasInfoNode);
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
                    }
                }

                await MyFile.Write(newConfigPath + "\\gameplay\\" + docs[doc], doc.OuterXml.Replace("><", ">\r\n<"));
            }

            //рекурсивное чтение XML
            void readNode(XmlNodeList nodeList, string parentNodeName)
            {
                foreach (XmlNode node in nodeList)
                {
                    var innerText = node.InnerText.Trim();
                    if (innerText.Length == 0) continue;

                    switch (node.Name)
                    {
                        case "precondition":
                            preconditions.Add(innerText);
                            break;
                        case "has_info":
                            infos.Add(innerText);
                            break;
                        case "dont_has_info":
                            infos.Add(innerText);
                            break;
                        case "action":
                            actions.Add(innerText);
                            break;
                        case "text":
                            texts.Add(innerText);
                            break;
                        case "give_info":
                            infos.Add(innerText);
                            break;
                        case "next":
                            readNode(node.ChildNodes, node.Name);
                            break;
                        case "dialog":
                            readNode(node.ChildNodes, node.Name);
                            break;
                        case "phrase":
                            readNode(node.ChildNodes, node.Name);
                            break;
                        default:
                            readNode(node.ChildNodes, node.Name);
                            break;
                    }
                }
            }
        }
    }
}
