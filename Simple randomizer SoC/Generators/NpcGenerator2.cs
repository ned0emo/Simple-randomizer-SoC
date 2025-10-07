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
    public class NpcGenerator2 : IGenerator<NpcConfig>
    {
        private readonly ProbabilityChecker probabilityChecker = new ProbabilityChecker();

        private static readonly Regex suppliesSplitter = new Regex("\\\\n");
        private static readonly Regex suppliesItemFinder = new Regex("^\\s*\\S+(?=[,\\s])");
        private static readonly Regex commentFinder = new Regex("<!--.*-->\\s*|\\s*;.*");

        private readonly Random rnd = new Random();

        private NpcConfig _config = null;
        private string _baseOutPath = null;

        public void UpdateData(string baseOutPath, bool randomProbability)
        {
            _baseOutPath = baseOutPath;
            probabilityChecker.SetProbability(randomProbability ? rnd.Next(100) + 1 : _config.Probability);
        }

        public async Task Generate()
        {
            var path = MyEnvironment.configPath + "\\gameplay";
            var outPath = _baseOutPath + "\\config\\gameplay\\";
            var scriptsOutPath = _baseOutPath + "\\scripts\\";

            var outDocs = new Dictionary<string, XmlDocument>();

            var names = new List<string>();
            if (_config.UseGenerateNames)
            {
                names.AddRange(_config.GenerateNames);
            }
            if (_config.UseUniqueNames)
            {
                names.AddRange(_config.UniqueNames);
            }

            var singleWeaponList = new List<WeaponAmmo>();
            if (_config.SingleWeapon)
            {
                singleWeaponList.AddRange(_config.MainWeapons);
                singleWeaponList.AddRange(_config.AdditionalWeapons);
            }

            var useMainWeapons = singleWeaponList.Count == 0 && _config.UseMainWeapons && _config.MainWeapons.Count > 0;
            var useAdditionalWeapons = singleWeaponList.Count == 0 && _config.UseAdditionalWeapons && _config.AdditionalWeapons.Count > 0;

            var files = new DirectoryInfo(path).GetFiles();
            foreach (var file in files)
            {
                var text = await MyFile.Read(file.FullName);
                var doc = new XmlDocument();
                doc.LoadXml(commentFinder.Replace(text, ""));

                var characters = doc.GetElementsByTagName("specific_character");

                foreach (XmlElement character in characters)
                {
                    if (character.HasAttribute("id") && _config.Exceptions.Contains(character.GetAttribute("id"))) continue;

                    if (names.Count > 0)
                    {
                        probabilityChecker.DoOrSkip(rnd, () =>
                        {
                            var node = GetOrAddElement("name", character, doc);
                            node.InnerText = CollectionUtils.GetRandomElement(names, rnd);
                        });
                    }

                    if (_config.UseIcons && _config.Icons.Count > 0)
                    {
                        probabilityChecker.DoOrSkip(rnd, () =>
                        {
                            var node = GetOrAddElement("icon", character, doc);
                            node.InnerText = CollectionUtils.GetRandomElement(_config.Icons, rnd);
                        });
                    }

                    if (_config.UseSounds && _config.Sounds.Count > 0)
                    {
                        probabilityChecker.DoOrSkip(rnd, () =>
                        {
                            var node = GetOrAddElement("snd_config", character, doc);
                            node.InnerText = CollectionUtils.GetRandomElement(_config.Sounds, rnd);
                        });
                    }

                    if (_config.UseCommunities && _config.Communities.Count > 0)
                    {
                        probabilityChecker.DoOrSkip(rnd, () =>
                        {
                            var node = GetOrAddElement("community", character, doc);
                            node.InnerText = CollectionUtils.GetRandomElement(_config.Communities, rnd);
                        });
                    }

                    if (_config.UseRank && _config.RankParameter.SimpleValidate())
                    {
                        probabilityChecker.DoOrSkip(rnd, () =>
                        {
                            var node = GetOrAddElement("rank", character, doc);
                            node.InnerText = _config.RankParameter.GenerateValues(rnd)[0].ToString();
                        });
                    }

                    if (_config.UseMoney && _config.MoneyParameter.SimpleValidate())
                    {
                        probabilityChecker.DoOrSkip(rnd, () =>
                        {
                            var node = GetOrAddElement("money", character, doc);
                            node.SetAttribute("min", _config.MoneyParameter.MinValue.ToString());
                            node.SetAttribute("max", _config.MoneyParameter.MaxValue.ToString());
                            if (!node.HasAttribute("infinitive"))
                            {
                                node.SetAttribute("infinitive", "0");
                            }
                        });
                    }

                    if (_config.UseModels && _config.Models.Count > 0)
                    {
                        probabilityChecker.DoOrSkip(rnd, () =>
                        {
                            var node = GetOrAddElement("visual", character, doc);
                            node.InnerText = CollectionUtils.GetRandomElement(_config.Models, rnd);
                        });
                    }

                    if (singleWeaponList.Count > 0)
                    {
                        probabilityChecker.DoOrSkip(rnd, () =>
                        {
                            var node = GetOrAddElement("supplies", character, doc);
                            var supplies = suppliesSplitter.Split(node.InnerText);

                            var newSupplies = PrepareSupplies(node);

                            var weapon = CollectionUtils.GetRandomElement(singleWeaponList, rnd);
                            newSupplies.Add(weapon.Weapon);
                            newSupplies.Add(weapon.GetRandomAmmo(rnd));

                            node.InnerText = newSupplies.Aggregate((s1, s2) => s1 + " \\n\r\n" + s2) + "\r\n";
                        });
                    }
                    else if (useMainWeapons && useAdditionalWeapons)
                    {
                        probabilityChecker.DoOrSkip(rnd, () =>
                        {
                            var node = GetOrAddElement("supplies", character, doc);
                            var supplies = suppliesSplitter.Split(node.InnerText);

                            var newSupplies = PrepareSupplies(node);

                            var weapon1 = CollectionUtils.GetRandomElement(_config.MainWeapons, rnd);
                            newSupplies.Add(weapon1.Weapon);
                            newSupplies.Add(weapon1.GetRandomAmmo(rnd));

                            var weapon2 = CollectionUtils.GetRandomElement(_config.AdditionalWeapons, rnd);
                            newSupplies.Add(weapon2.Weapon);
                            newSupplies.Add(weapon2.GetRandomAmmo(rnd));

                            node.InnerText = newSupplies.Aggregate((s1, s2) => s1 + " \\n\r\n" + s2) + "\r\n";
                        });
                    }
                    else if (useMainWeapons)
                    {
                        probabilityChecker.DoOrSkip(rnd, () =>
                        {
                            var node = GetOrAddElement("supplies", character, doc);
                            var supplies = suppliesSplitter.Split(node.InnerText);

                            var newSupplies = PrepareSupplies(node);

                            var weapon1 = CollectionUtils.GetRandomElement(_config.MainWeapons, rnd);
                            newSupplies.Add(weapon1.Weapon);
                            newSupplies.Add(weapon1.GetRandomAmmo(rnd));

                            node.InnerText = newSupplies.Aggregate((s1, s2) => s1 + " \\n\r\n" + s2) + "\r\n";
                        });
                    }
                    else if (useAdditionalWeapons)
                    {
                        probabilityChecker.DoOrSkip(rnd, () =>
                        {
                            var node = GetOrAddElement("supplies", character, doc);
                            var supplies = suppliesSplitter.Split(node.InnerText);

                            var newSupplies = PrepareSupplies(node);

                            var weapon2 = CollectionUtils.GetRandomElement(_config.AdditionalWeapons, rnd);
                            newSupplies.Add(weapon2.Weapon);
                            newSupplies.Add(weapon2.GetRandomAmmo(rnd));

                            node.InnerText = newSupplies.Aggregate((s1, s2) => s1 + " \\n\r\n" + s2) + "\r\n";
                        });
                    }
                }

                outDocs.Add(file.Name, doc);
            }

            var settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "\t",
                NewLineChars = Environment.NewLine,
                OmitXmlDeclaration = true
            };

            Directory.CreateDirectory(outPath);
            foreach (var doc in outDocs)
            {
                using (var sw = new StreamWriter(outPath + doc.Key, false, Encoding.Default))
                using (var xw = XmlWriter.Create(sw, settings))
                {
                    doc.Value.Save(xw);
                }
            }

            if (_config.UseCommunities || _config.ExtendCampsSettlement)
            {
                Directory.CreateDirectory(scriptsOutPath);
                await MyFile.CopyFileAsync(MyEnvironment.scriptsPath + "\\smart_terrain.script", scriptsOutPath + "smart_terrain.script");
                await MyFile.CopyFileAsync(MyEnvironment.scriptsPath + "\\xr_gulag.script", scriptsOutPath + "xr_gulag.script");
            }
        }

        private XmlElement GetOrAddElement(string nodeName, XmlElement parent, XmlDocument document, string defalutValue = "")
        {
            var nodes = parent.GetElementsByTagName(nodeName);
            if (nodes.Count == 0)
            {
                var node = document.CreateElement(nodeName);
                parent.AppendChild(node);
                node.InnerText = defalutValue;

                return node;
            }
            else
            {
                return (XmlElement)nodes[0];
            }
        }

        private HashSet<string> PrepareSupplies(XmlElement node)
        {
            var supplies = suppliesSplitter.Split(node.InnerText);

            var newSupplies = new HashSet<string> { " [spawn]" };

            foreach (var sup in supplies)
            {
                if (sup.Contains("#include"))
                {
                    newSupplies.Add(sup.Trim());
                    continue;
                }

                var match = suppliesItemFinder.Match(sup);
                if (match.Groups.Count > 0)
                {
                    var item = match.Groups[0].Value.Trim();

                    if (_config.KeepingSupplies.Contains(item))
                    {
                        newSupplies.Add(item);
                    }
                }
            }

            return newSupplies;
        }

        public string StatusText()
        {
            return Localization.Get("npcTab");
        }

        public void UpdateConfig(NpcConfig config)
        {
            _config = config;
        }
    }
}
