using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private bool isRulesLoaded;

        /// <summary>
        /// Для работы с неписями после инициализации класса необходимо вызвать не только
        /// updateData, но и updateRules. Для получения инфы с чекбоксов
        /// </summary>
        public NpcGenerator(FileHandler file) : base(file)
        {
            isRulesLoaded = false;
        }

        /// <summary>
        /// Обновление списков
        /// </summary>
        public void updateData(string communities, string models, string icons,
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

        public void updateRules(bool communitiesEnabled, bool modelsEnabled, bool iconsEnabled,
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

        public async Task<int> generate()
        {
            errorMessage = "";
            warningMessage = "";

            if (!isDataLoaded)
            {
                errorMessage = "Данные для генерации НПС не были получены. Требуется вызов \"updateData\"";
                return STATUS_ERROR;
            }

            if (!isRulesLoaded)
            {
                errorMessage = "Правила для генерации НПС не были получены. Требуется вызов \"updateRules\"";
                return STATUS_ERROR;
            }

            try
            {
                var communityList = createCleanList(communities);
                var modelList = createCleanList(models);
                var iconList = createCleanList(icons);
                var soundList = createCleanList(sounds);
                var exceptionList = createCleanList(exceptions);

                var weaponList = new List<string>(createCleanList(weapons, true));
                var brokenWeaponsCount = weaponList.RemoveAll(el => !el.Contains(' '));
                if(brokenWeaponsCount > 0)
                {
                    warningMessage = $"Некоторые строки с оружием имеют неправильное форматирование. Количесвто - {brokenWeaponsCount}";
                }

                var nameList = new List<string>(createCleanList(names));
                if (onlyGenerateNames)
                {
                    nameList.RemoveAll(el => !el.Contains("GENERATE_NAME"));
                }

                foreach (string it in file.getFiles($"{Environment.configPath}/gameplay"))
                {
                    var npcDescList = (await file.readFile(it)).Replace("<specific_character", "\a").Split('\a');

                    for (int i = 1; i < npcDescList.Length; i++)
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
                            npcDescList[i] = replaceXmlValue(npcDescList[i], "community", communityList[rnd.Next(communityList.Length)]);
                        }

                        if (ranksEnabled)
                        {
                            npcDescList[i] = replaceXmlValue(npcDescList[i], "rank", rnd.Next(1000).ToString());
                        }

                        if (reputationEnabled)
                        {
                            npcDescList[i] = replaceXmlValue(npcDescList[i], "reputation", (rnd.Next(2001) - 1000).ToString());
                        }

                        if (modelsEnabled && modelList.Length > 0)
                        {
                            npcDescList[i] = replaceXmlValue(npcDescList[i], "visual", modelList[rnd.Next(modelList.Length)]);
                        }

                        if (iconsEnabled && iconList.Length > 0)
                        {
                            npcDescList[i] = replaceXmlValue(npcDescList[i], "icon", iconList[rnd.Next(iconList.Length)]);
                        }

                        if (namesEnabled && (!onlyGenerateNames || npcDescList[i].Contains("GENERATE_NAME")) && nameList.Count > 0)
                        {
                            npcDescList[i] = replaceXmlValue(npcDescList[i], "name", nameList[rnd.Next(nameList.Count)]);
                        }

                        if (soundsEnabled && soundList.Length > 0)
                        {
                            npcDescList[i] = replaceXmlValue(npcDescList[i], "snd_config", soundList[rnd.Next(soundList.Length)]);
                        }

                        if (suppliesEnabled && npcDescList[i].Contains("[spawn]") && weaponList.Count > 0)
                        {
                            string supplies = npcDescList[i].Substring(npcDescList[i].IndexOf("[spawn]"), npcDescList[i].IndexOf("</supplies>") - npcDescList[i].IndexOf("[spawn]"));
                            List<string> suppList = new List<string>(supplies.Split('\n'));

                            for (int j = 0; j < suppList.Count; j++)
                            {
                                if (suppList[j].Contains("wpn_") || suppList[j].Contains("ammo_"))
                                {
                                    suppList.RemoveAt(j--);
                                }
                            }

                            int weapNum = rnd.Next(weaponList.Count);

                            string[] currentWeaponAndAmmo = weaponList[weapNum].Split(' ');
                            string weapon = currentWeaponAndAmmo[0];
                            string ammo = currentWeaponAndAmmo[rnd.Next(currentWeaponAndAmmo.Length - 1) + 1];

                            suppList.Insert(1, weapon + " \\n\n");
                            suppList.Insert(1, ammo.Replace("\n", "").Replace("\r", "") + " \\n\n");

                            string newSupplies = "";
                            foreach (string supp in suppList)
                            {
                                newSupplies += supp;
                            }

                            npcDescList[i] = npcDescList[i].Replace(supplies, newSupplies);
                        }
                    }

                    string outStr = "";

                    for (int i = 0; i < npcDescList.Length - 1; i++)
                    {
                        outStr += npcDescList[i] + "<specific_character";
                    }
                    outStr += npcDescList.Last();

                    await file.writeFile(it.Replace(Environment.configPath, newConfigPath), outStr);
                }

                return STATUS_OK;
            }
            catch (Exception ex)
            {
                errorMessage = $"Ошибка генерации НПС. Операция прервана\r\n{ex.Message}\n{ex.StackTrace}";
                return STATUS_ERROR;
            }
        }
    }
}
