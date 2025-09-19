using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Generators
{
    class NpcGenerator : BaseGenerator
    {
        private string newConfigPath;

        private string communities;
        private string models;
        private string icons;
        private string sounds;
        private string names;
        private string weapons;
        private string exceptions;

        private bool communitiesEnabled;
        private bool modelsEnabled;
        private bool iconsEnabled;
        private bool soundsEnabled;
        private bool namesEnabled;
        private bool suppliesEnabled;
        private bool ranksEnabled;
        private bool reputationEnabled;

        private bool onlyGenerateNames;

        /// <summary>
        /// Для работы с неписями после инициализации класса необходимо вызвать не только
        /// updateData, но и updateRules. Для получения инфы с чекбоксов
        /// </summary>
        private bool isRulesLoaded = false;

        /// <summary>
        /// Обновление списков
        /// </summary>
        public void UpdateData(string communities, string models, string icons,
            string sounds, string names, string weapons, string exceptions, string newConfigPath)
        {
            this.communities = communities;
            this.models = models;
            this.icons = icons;
            this.sounds = sounds;
            this.names = names;
            this.weapons = weapons;
            this.exceptions = exceptions;
            this.newConfigPath = newConfigPath;

            isDataLoaded = true;
        }

        public void UpdateRules(bool communitiesEnabled, bool modelsEnabled, bool iconsEnabled,
            bool soundsEnabled, bool namesEnabled, bool suppliesEnabled, bool ranksEnabled,
            bool reputationEnabled, bool onlyGenerateNames)
        {
            this.communitiesEnabled = communitiesEnabled;
            this.modelsEnabled = modelsEnabled;
            this.iconsEnabled = iconsEnabled;
            this.soundsEnabled = soundsEnabled;
            this.namesEnabled = namesEnabled;
            this.suppliesEnabled = suppliesEnabled;
            this.ranksEnabled = ranksEnabled;
            this.reputationEnabled = reputationEnabled;
            this.onlyGenerateNames = onlyGenerateNames;

            isRulesLoaded = true;
        }

        public async Task Generate()
        {
            if (!isDataLoaded)
            {
                throw new CustomException(Localization.Get("npcDataError"));
            }

            if (!isRulesLoaded)
            {
                throw new CustomException(Localization.Get("npcRulesError"));
            }

            var communityList = CreateCleanList(communities);
            var modelList = CreateCleanList(models);
            var iconList = CreateCleanList(icons);
            var soundList = CreateCleanList(sounds);
            var exceptionList = CreateCleanList(exceptions);

            var weaponList = new List<string>(CreateCleanList(weapons, true));
            var brokenWeaponsCount = weaponList.RemoveAll(el => !el.Contains(' '));
            if (brokenWeaponsCount > 0)
            {
                Console.WriteLine($"Некоторые строки с оружием имеют неправильное форматирование. Количесвто - {brokenWeaponsCount}");
            }

            var nameList = new List<string>(CreateCleanList(names));
            if (onlyGenerateNames)
            {
                nameList.RemoveAll(el => !el.Contains("GENERATE_NAME"));
            }

            foreach (string it in await MyFile.GetFiles($"{Environment.configPath}/gameplay"))
            {
                var npcDescList = StringUtils.Split(await MyFile.Read(it), "<specific_character");

                for (int i = 1; i < npcDescList.Count; i++)
                {
                    bool isException = false;

                    foreach (string exception in exceptionList)
                    {
                        if (npcDescList[i].Contains($"id=\"{exception}\""))
                        {
                            isException = true;
                            break;
                        }
                    }

                    if (isException) continue;

                    if (communitiesEnabled && communityList.Length > 0)
                    {
                        doOrSkip(() => npcDescList[i] = ReplaceXmlValue(npcDescList[i], "community", communityList[GlobalRandom.Rnd.Next(communityList.Length)]));
                    }

                    if (ranksEnabled)
                    {
                        doOrSkip(() => npcDescList[i] = ReplaceXmlValue(npcDescList[i], "rank", GlobalRandom.Rnd.Next(1000).ToString()));
                    }

                    if (reputationEnabled)
                    {
                        doOrSkip(() => npcDescList[i] = ReplaceXmlValue(npcDescList[i], "reputation", (GlobalRandom.Rnd.Next(2001) - 1000).ToString()));
                    }

                    if (modelsEnabled && modelList.Length > 0)
                    {
                        doOrSkip(() => npcDescList[i] = ReplaceXmlValue(npcDescList[i], "visual", modelList[GlobalRandom.Rnd.Next(modelList.Length)]));
                    }

                    if (iconsEnabled && iconList.Length > 0)
                    {
                        doOrSkip(() => npcDescList[i] = ReplaceXmlValue(npcDescList[i], "icon", iconList[GlobalRandom.Rnd.Next(iconList.Length)]));
                    }

                    if (namesEnabled && (!onlyGenerateNames || npcDescList[i].Contains("GENERATE_NAME")) && nameList.Count > 0)
                    {
                        doOrSkip(() => npcDescList[i] = ReplaceXmlValue(npcDescList[i], "name", nameList[GlobalRandom.Rnd.Next(nameList.Count)]));
                    }

                    if (soundsEnabled && soundList.Length > 0)
                    {
                        doOrSkip(() => npcDescList[i] = ReplaceXmlValue(npcDescList[i], "snd_config", soundList[GlobalRandom.Rnd.Next(soundList.Length)]));
                    }

                    if (suppliesEnabled && !skipReplacing() && npcDescList[i].Contains("[spawn]") && weaponList.Count > 0)
                    {
                        string supplies = npcDescList[i].Substring(npcDescList[i].IndexOf("[spawn]"), npcDescList[i].IndexOf("</supplies>") - npcDescList[i].IndexOf("[spawn]"));
                        List<string> suppList = new List<string>(StringUtils.SplitBreaklines(supplies));

                        for (int j = 0; j < suppList.Count; j++)
                        {
                            if (suppList[j].Contains("wpn_") || suppList[j].Contains("ammo_"))
                            {
                                suppList.RemoveAt(j--);
                            }
                        }

                        int weapNum = GlobalRandom.Rnd.Next(weaponList.Count);

                        string[] currentWeaponAndAmmo = StringUtils.WhiteSpaceSplit(weaponList[weapNum]);
                        string weapon = currentWeaponAndAmmo[0];
                        string ammo = currentWeaponAndAmmo[GlobalRandom.Rnd.Next(currentWeaponAndAmmo.Length - 1) + 1];

                        suppList.Insert(1, weapon + " \\n");
                        suppList.Insert(1, StringUtils.RemoveLineBreaking(ammo) + " \\n");

                        npcDescList[i] = npcDescList[i].Replace(supplies, suppList.Aggregate((a, b) => a + "\n" + b));
                    }
                }

                await MyFile.Write(it.Replace(Environment.configPath, newConfigPath),
                    npcDescList.Aggregate((a, b) => a + "<specific_character" + b));
            }
        }
    }
}
