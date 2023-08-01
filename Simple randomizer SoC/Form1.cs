using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TreasuresSoC
{
    public partial class Form1 : Form
    {
        readonly string[] fullAfStats = { "burn_immunity", "strike_immunity",
            "shock_immunity", "telepatic_immunity", "chemical_burn_immunity", "explosion_immunity",
            "fire_wound_immunity"};
        readonly string[] fullAfStats2 = { "radiation_restore_speed", "health_restore_speed",
            "power_restore_speed", "bleeding_restore_speed" };
        readonly string[] fullOutfitStats = { "burn_protection", "strike_protection", "shock_protection",
            "wound_protection", "radiation_protection", "telepatic_protection", "chemical_burn_protection",
            "explosion_protection", "fire_wound_protection"};
        readonly string[] fullOutfitImmunities = { "burn_immunity", "strike_immunity", "shock_immunity",
            "wound_immunity", "radiation_immunity", "telepatic_immunity", "chemical_burn_immunity",
            "explosion_immunity", "fire_wound_immunity"};

        //список имен файлов
        //дублировать в textBoxList, сохраняя порядок
        //также прописать в функции загрузки списков loadLists()
        readonly string[] nameList = {"other", "af", "ammo", "item", "model",
            "outfit", "sound", "weapon", "npcexception", "community", "icons",
            "names", "skybox", "thunderbolt", "weapon_snd_reload", "weapon_snd_shoot"};
        readonly List<string> errList;
        readonly List<string> loadedDataList;
        readonly List<TextBox> textBoxList;
        readonly List<CheckBox> generateTypeCheckBoxList;
        readonly List<CheckBox> npcCheckBoxList;
        readonly List<CheckBox> npcCheckBoxWithoutTextBoxList;
        readonly List<Label> recommendLabelList;
        readonly Random rnd;

        public bool isSaved = false;

        string defaultGamedataPath = "./rndata/default/gamedata";
        string originalConfPath = "./rndata/default/gamedata/config";

        public Form1()
        {
            errList = new List<string>();
            loadedDataList = new List<string>();
            rnd = new Random();

            InitializeComponent();

            textBoxList = new List<TextBox>() { otherTextBox, afTextBox, ammoTextBox, itemTextBox,
                modelTextBox, armorTextBox, soundTextBox, weaponTextBox,
                npcExecptTextBox, communityTextBox, iconsTextBox, namesTextBox, skyTextBox, 
                thunderTextBox, reloadSoundsTextBox, shootSoundsTextBox};

            generateTypeCheckBoxList = new List<CheckBox>() { treasureCheckBox, afCheckBox,
                weaponCheckBox, armorCheckBox, npcCheckBox, weatherCheckBox };

            recommendLabelList = new List<Label>() { recommendLabel1, recommendLabel2, recommendLabel3, recommendLabel4 };

            npcCheckBoxList = new List<CheckBox>() { modelsCheckBox, soundsCheckBox, iconsCheckBox, namesCheckBox };
            npcCheckBoxWithoutTextBoxList = new List<CheckBox>() { suppliesCheckBox, rankCheckBox, reputationCheckBox };
            foreach (CheckBox cb in npcCheckBoxList)
            {
                cb.Checked = true;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string changedLists = "";
            List<string> files = new List<string>();
            List<string> info = new List<string>();
            List<int> indexes = new List<int>();

            //проходим по всем спискам и ищем отличия от кешированных данных
            for (int i = 0; i < loadedDataList.Count; i++)
            {
                if (loadedDataList[i] != textBoxList[i].Text)
                {
                    changedLists += nameList[i] + ", ";
                    files.Add(nameList[i]);
                    info.Add(textBoxList[i].Text);
                    indexes.Add(i);
                }
            }

            if (files.Count < 1)
            {
                return;
            }

            new SaveForm(files, info, this).ShowDialog();

            if (isSaved)
            {
                for (int i = 0; i < indexes.Count; i++)
                {
                    loadedDataList[indexes[i]] = textBoxList[indexes[i]].Text;
                }
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            loadLists(false);
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            bool isNeedCreate = false;

            foreach (CheckBox cb in generateTypeCheckBoxList)
            {
                if (cb.Checked)
                {
                    isNeedCreate = true;
                    break;
                }
            }

            if (!isNeedCreate) return;

            string newGamedataPath = $"./gamedata {DateTime.Now:dd.MM.yyyy HH.mm.ss}";
            string confDir;
            //создание директорий
            try
            {
                confDir = Directory.CreateDirectory($"{newGamedataPath}/config").FullName;
                Directory.CreateDirectory($"{newGamedataPath}/config/scripts");
                Directory.CreateDirectory($"{newGamedataPath}/scripts");
                Directory.CreateDirectory($"{newGamedataPath}/spawns");
            }
            catch
            {
                new InfoForm("Ошибка создания директории gamedata. Проверьте права доступа на запись. Операция прервана.").ShowDialog();
                return;
            }

            var outfitList = createCleanList(armorTextBox.Text);
            var afList = createCleanList(afTextBox.Text);
            var itemList = createCleanList(itemTextBox.Text);
            var otherList = createCleanList(otherTextBox.Text);
            var exceptionList = createCleanList(npcExecptTextBox.Text);
            var ammoList = createCleanList(ammoTextBox.Text, true);

            var tmpWeaponList = createCleanList(weaponTextBox.Text, true);
            List<string> treasureWeaponList = new List<string>();
            List<string> npcWeaponList = new List<string>();
            List<string> brokenWeapons = new List<string>();

            for (int i = 0; i < tmpWeaponList.Length; i++)
            {
                if (!tmpWeaponList[i].Contains(" "))
                {
                    brokenWeapons.Add(tmpWeaponList[i]);
                    continue;
                }

                treasureWeaponList.Add(tmpWeaponList[i].Substring(0, tmpWeaponList[i].IndexOf(' ')));
                npcWeaponList.Add(tmpWeaponList[i]);
            }

            if (brokenWeapons.Count > 0)
            {
                string brokenWeaponString = "";
                foreach (string weapon in brokenWeapons)
                {
                    brokenWeaponString += weapon + " ||| ";
                }
                new InfoForm($"Некоторое оружие имеет неправильное форматировании. " +
                    $"Рекомендуется проверить форматирование всего списка оружия. " +
                    $"Обнаруженные проблемы:\n{brokenWeaponString}").ShowDialog();
            }

            //тайники
            try
            {
                if (treasureCheckBox.Checked)
                {
                    StreamReader treasureReader = new StreamReader($"{originalConfPath}/misc/treasure_manager.ltx");
                    List<string> treasureStringList = new List<string>(treasureReader.ReadToEnd().Split('\n'));
                    treasureReader.Close();

                    for (int j = 0; j < treasureStringList.Count; j++)
                    {
                        if (treasureStringList[j].Contains("items"))
                        {
                            string newItems = "";
                            int itemCount = rnd.Next(1, 7);

                            for (int i = 0; i < itemCount; i++)
                            {
                                int whichItemType = rnd.Next(100);

                                if (whichItemType < 5)
                                {
                                    newItems += generateItem(outfitList, 1);
                                }
                                else if (whichItemType < 15)
                                {
                                    newItems += generateItem(treasureWeaponList.ToArray(), 1);
                                }
                                else if (whichItemType < 20)
                                {
                                    newItems += generateItem(afList, 2);
                                }
                                else if (whichItemType < 70)
                                {
                                    newItems += generateItem(itemList, 8);
                                }
                                else if (whichItemType < 95)
                                {
                                    newItems += generateItem(ammoList, 6);
                                }
                                else
                                {
                                    newItems += generateItem(otherList, 2);
                                }

                                if (i < itemCount - 1)
                                {
                                    newItems += ", ";
                                }
                            }

                            treasureStringList[j] = "items = " + newItems + '\n';
                        }
                    }

                    string treasureString = "";

                    for (int i = 0; i < treasureStringList.Count; i++)
                    {
                        treasureString += treasureStringList[i];
                    }

                    Directory.CreateDirectory($"{confDir}/misc");
                    FileStream outputFile = new FileStream($"{confDir}/misc/treasure_manager.ltx", FileMode.Create);

                    byte[] buffer = Encoding.Default.GetBytes(treasureString);
                    outputFile.Write(buffer, 0, buffer.Length);
                    outputFile.Close();
                }
            }
            catch
            {
                new InfoForm("Ошибка генерации тайников. Операция прервана.").ShowDialog();
                return;
            }
            //артефакты
            try
            {
                if (afCheckBox.Checked)
                {
                    StreamReader artReader = new StreamReader($"{originalConfPath}/misc/artefacts.ltx");
                    List<string> artefactsStringList = new List<string>(artReader.ReadToEnd().Replace("af_base", "\a").Split('\a'));
                    artReader.Close();

                    string artString = "";

                    for (int i = 2; i < artefactsStringList.Count; i++)
                    {
                        int statsNum = rnd.Next(1, 6);
                        List<Tuple<string, double>> afStats = generateAfStats(statsNum);

                        artefactsStringList[i] = replaceStat(artefactsStringList[i], "cost", rnd.Next(5000) + 1);
                        artefactsStringList[i] = replaceStat(artefactsStringList[i], "inv_weight", (rnd.NextDouble() + 0.3) * 2);

                        //Замена статов на пустые для последующего добавления новых
                        foreach (string stat in fullAfStats)
                        {
                            artefactsStringList[i] = replaceStat(artefactsStringList[i], stat, 1.0);
                        }
                        foreach (string stat in fullAfStats2)
                        {
                            artefactsStringList[i] = replaceStat(artefactsStringList[i], stat, 0.0);
                        }

                        foreach (Tuple<string, double> stat in afStats)
                        {
                            artefactsStringList[i] = replaceStat(artefactsStringList[i], stat.Item1, stat.Item2);
                        }
                    }

                    foreach (string it in artefactsStringList)
                    {
                        artString += it + "af_base";
                    }

                    Directory.CreateDirectory($"{confDir}/misc");
                    FileStream outputFile = new FileStream($"{confDir}/misc/artefacts.ltx", FileMode.Create);
                    byte[] buffer = Encoding.Default.GetBytes(artString);
                    outputFile.Write(buffer, 0, buffer.Length);
                    outputFile.Close();
                }
            }
            catch
            {
                new InfoForm("Ошибка генерации характеристик артефактов. Операция прервана.").ShowDialog();
                return;
            }
            //оружие
            try
            {
                if (weaponCheckBox.Checked)
                {
                    string[] weapons = Directory.GetFiles("./rndata/default/gamedata/config/weapons");
                    Directory.CreateDirectory($"{confDir}/weapons");

                    var reloadSoundsList = createCleanList(reloadSoundsTextBox.Text, true);
                    var shootSoundsList = createCleanList(shootSoundsTextBox.Text, true);

                    foreach (string it in weapons)
                    {
                        StreamReader weaponReader = new StreamReader(it);
                        string currWeapon = weaponReader.ReadToEnd().Replace(";snd", ";");
                        weaponReader.Close();
                        int magSize = rnd.Next(50) + 1;

                        currWeapon =
                            replaceStat(currWeapon, "cost", rnd.Next(10000) + 1);
                        currWeapon =
                            replaceStat(currWeapon, "ammo_limit", magSize);
                        currWeapon =
                            replaceStat(currWeapon, "ammo_elapsed", magSize);
                        currWeapon =
                            replaceStat(currWeapon, "ammo_mag_size", magSize);
                        currWeapon =
                            replaceStat(currWeapon, "inv_weight", Math.Round(rnd.NextDouble() * 7 + 0.2, 2));
                        currWeapon =
                            replaceStat(currWeapon, "fire_dispersion_base", Math.Round(rnd.NextDouble() * 0.8, 3));
                        currWeapon =
                            replaceStat(currWeapon, "hit_power", Math.Round(rnd.NextDouble() * 1.2 + 0.01, 2));
                        currWeapon =
                            replaceStat(currWeapon, "hit_impulse", rnd.Next(400) + 50);
                        currWeapon =
                            replaceStat(currWeapon, "fire_distance", rnd.Next(1000) + 10);
                        currWeapon =
                            replaceStat(currWeapon, "bullet_speed", rnd.Next(1000) + 10);
                        currWeapon =
                            replaceStat(currWeapon, "rpm", rnd.Next(1000) + 10);
                        currWeapon =
                            replaceStat(currWeapon, "silencer_hit_power", Math.Round(rnd.NextDouble() * 1.2 + 0.01, 2));
                        currWeapon =
                            replaceStat(currWeapon, "silencer_hit_impulse", rnd.Next(400) + 50);
                        currWeapon =
                            replaceStat(currWeapon, "silencer_fire_distance", rnd.Next(1000) + 10);
                        currWeapon =
                            replaceStat(currWeapon, "silencer_bullet_speed", rnd.Next(1000) + 10);
                        currWeapon =
                            replaceStat(currWeapon, "snd_shoot", shootSoundsList[rnd.Next(shootSoundsList.Length)]);
                        currWeapon =
                            replaceStat(currWeapon, "snd_shoot1", shootSoundsList[rnd.Next(shootSoundsList.Length)]);
                        currWeapon =
                            replaceStat(currWeapon, "snd_shoot2", shootSoundsList[rnd.Next(shootSoundsList.Length)]);
                        currWeapon =
                            replaceStat(currWeapon, "snd_shoot3", shootSoundsList[rnd.Next(shootSoundsList.Length)]);
                        currWeapon =
                            replaceStat(currWeapon, "snd_empty", shootSoundsList[rnd.Next(shootSoundsList.Length)]);
                        currWeapon =
                            replaceStat(currWeapon, "snd_reload", $"{reloadSoundsList[rnd.Next(reloadSoundsList.Length)]}, " +
                            $"{Math.Round(rnd.NextDouble() + 0.01, 2)}, {Math.Round(rnd.NextDouble() + 0.01, 2)}");

                        byte[] buffer = Encoding.Default.GetBytes(currWeapon);

                        using (FileStream outputFile = new FileStream(it.Replace("./rndata/default/gamedata/config", confDir), FileMode.Create))
                        {
                            outputFile.Write(buffer, 0, buffer.Length);
                            outputFile.Close();
                        }
                    }
                }
            }
            catch
            {
                new InfoForm("Ошбка генерации характеристик оружия. Операция прервана.").ShowDialog();
                return;
            }
            //бронь
            try
            {
                if (armorCheckBox.Checked)
                {
                    Directory.CreateDirectory($"{confDir}/misc");
                    StreamReader outfitReader = new StreamReader("./rndata/default/gamedata/config/misc/outfit.ltx");
                    List<string> outfitFullList = new List<string>(outfitReader.ReadToEnd().Replace("outfit_base", "\a").Split('\a'));
                    outfitReader.Close();
                    string outfitStr = "";

                    for (int i = 3; i < outfitFullList.Count; i++)
                    {
                        int plusMaxWeight = rnd.Next(-15, 21);

                        outfitFullList[i] = replaceStat(outfitFullList[i], "inv_weight", rnd.Next(10) + 1);
                        outfitFullList[i] = replaceStat(outfitFullList[i], "cost", rnd.Next(10000) + 1);

                        foreach (string stat in fullOutfitStats)
                        {
                            outfitFullList[i] = replaceStat(outfitFullList[i], stat, Math.Round(rnd.NextDouble() * 1.4 - 0.7, 2));
                        }

                        foreach (string immun in fullOutfitImmunities)
                        {
                            outfitFullList[i] = replaceStat(outfitFullList[i], immun, Math.Round(rnd.NextDouble() / 20, 3));
                        }

                        if (outfitFullList[i].Contains("additional_inventory_weight"))
                        {
                            outfitFullList[i] = replaceStat(outfitFullList[i], "additional_inventory_weight", plusMaxWeight);
                        }
                        else
                        {
                            outfitFullList[i] = outfitFullList[i].Insert(outfitFullList[i].IndexOf("[sect"), $"additional_inventory_weight = {plusMaxWeight}\n");
                        }

                        if (outfitFullList[i].Contains("additional_inventory_weight2"))
                        {
                            outfitFullList[i] = replaceStat(outfitFullList[i], "additional_inventory_weight2", plusMaxWeight + 10);
                        }
                        else
                        {
                            outfitFullList[i] = outfitFullList[i].Insert(outfitFullList[i].IndexOf("[sect"), $"additional_inventory_weight2 = {plusMaxWeight + 10}\n");
                        }
                    }

                    foreach (string it in outfitFullList)
                    {
                        outfitStr += it + "outfit_base";
                    }

                    byte[] buffer = Encoding.Default.GetBytes(outfitStr);

                    using (FileStream outputFile = new FileStream($"{confDir}/misc/outfit.ltx", FileMode.Create))
                    {
                        outputFile.Write(buffer, 0, buffer.Length);
                        outputFile.Close();
                    }
                }
            }
            catch
            {
                new InfoForm("Ошибка генерации характеристик брони. Операция прервана.").ShowDialog();
                return;
            }
            //нпс
            try
            {
                if (npcCheckBox.Checked)
                {
                    Directory.CreateDirectory($"{confDir}/gameplay");

                    string[] communityList = createCleanList(communityTextBox.Text);
                    string[] models = createCleanList(modelTextBox.Text);
                    string[] icons = createCleanList(iconsTextBox.Text);
                    string[] sounds = createCleanList(soundTextBox.Text);
                    var names = new List<string>(createCleanList(namesTextBox.Text));
                    if (onlyGenerateCheckBox.Checked)
                    {
                        names.RemoveAll(el => !el.Contains("GENERATE_NAME"));
                    }

                    foreach (string it in Directory.GetFiles($"./rndata/default/gamedata/config/gameplay"))
                    {
                        StreamReader sr = new StreamReader(it);
                        List<string> npcDescList = new List<string>(sr.ReadToEnd().Replace("<specific_character", "\a").Split('\a'));
                        sr.Close();

                        for (int i = 1; i < npcDescList.Count; i++)
                        {
                            bool isException = false;

                            foreach (string except in exceptionList)
                            {
                                if (npcDescList[i].Contains(except))
                                {
                                    isException = true;
                                    break;
                                }
                            }

                            if (isException)
                            {
                                continue;
                            }

                            if (npcDescList[i].Contains("<community>") && communityCheckBox.Checked && communityList.Length > 0)
                            {
                                string community = communityList[rnd.Next(communityList.Length)];
                                string tmp = npcDescList[i].Substring(npcDescList[i].IndexOf("<community>"));

                                npcDescList[i] = npcDescList[i].Replace(tmp.Substring(0, tmp.IndexOf("</comm") + 12), $"<community>{community}</community>");
                            }

                            if (npcDescList[i].Contains("<rank>") && rankCheckBox.Checked)
                            {
                                string tmp = npcDescList[i].Substring(npcDescList[i].IndexOf("<rank>"));

                                npcDescList[i] = npcDescList[i].Replace(tmp.Substring(0, tmp.IndexOf("</rank>") + 7), $"<rank>{rnd.Next(1000)}</rank>");
                            }

                            if (npcDescList[i].Contains("<reputation>") && reputationCheckBox.Checked)
                            {
                                string tmp = npcDescList[i].Substring(npcDescList[i].IndexOf("<reputation>"));

                                npcDescList[i] = npcDescList[i].Replace(tmp.Substring(0, tmp.IndexOf("</reputation>") + 13), $"<reputation>{rnd.Next(2001) - 1000}</reputation>");
                            }

                            if (npcDescList[i].Contains("<visual>") && modelsCheckBox.Checked && models.Length > 0)
                            {
                                string model = models[rnd.Next(models.Length)];
                                string tmp = npcDescList[i].Substring(npcDescList[i].IndexOf("<visual>"));
                                npcDescList[i] = npcDescList[i].Replace(tmp.Substring(0, tmp.IndexOf('\n')), $"<visual>{model}</visual>");
                            }

                            if (npcDescList[i].Contains("<icon>") && iconsCheckBox.Checked && icons.Length > 0)
                            {
                                string icon = icons[rnd.Next(icons.Length)];
                                string tmp = npcDescList[i].Substring(npcDescList[i].IndexOf("<icon>"));
                                npcDescList[i] = npcDescList[i].Replace(tmp.Substring(0, tmp.IndexOf('\n')), $"<icon>{icon}</icon>");
                            }

                            if (npcDescList[i].Contains("<name>") && namesCheckBox.Checked
                                && (!onlyGenerateCheckBox.Checked || npcDescList[i].Contains("GENERATE_NAME")) && icons.Length > 0)
                            {
                                string name = names[rnd.Next(names.Count)];
                                string tmp = npcDescList[i].Substring(npcDescList[i].IndexOf("<name>"));
                                npcDescList[i] = npcDescList[i].Replace(tmp.Substring(0, tmp.IndexOf('\n')), $"<name>{name}</name>");
                            }

                            if (npcDescList[i].Contains("<snd_config>") && soundsCheckBox.Checked && sounds.Length > 0)
                            {
                                string sound = sounds[rnd.Next(sounds.Length)];
                                string tmp = npcDescList[i].Substring(npcDescList[i].IndexOf("<snd_config>"));
                                npcDescList[i] = npcDescList[i].Replace(tmp.Substring(0, tmp.IndexOf('\n')), $"<snd_config>{sound}</snd_config>");
                            }

                            if (npcDescList[i].Contains("[spawn]") && npcWeaponList.Count > 0 && suppliesCheckBox.Checked)
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

                                int weapNum = rnd.Next(npcWeaponList.Count);

                                string[] currWeapAmmo = npcWeaponList[weapNum].Split(' ');
                                string weapon = currWeapAmmo[0];
                                string ammo = currWeapAmmo[rnd.Next(currWeapAmmo.Length - 1) + 1];

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

                        for (int i = 0; i < npcDescList.Count - 1; i++)
                        {
                            outStr += npcDescList[i] + "<specific_character";
                        }
                        outStr += npcDescList[npcDescList.Count - 1];

                        FileStream outputFile = new FileStream($"{it.Replace("./rndata/default/gamedata/config", confDir)}", FileMode.Create);
                        byte[] buffer = Encoding.Default.GetBytes(outStr);
                        outputFile.Write(buffer, 0, buffer.Length);
                        outputFile.Close();
                    }
                }
            }
            catch
            {
                new InfoForm("Ошибка генераци НПС. Операция прервана.").ShowDialog();
                return;
            }
            //погода
            try
            {
                if (weatherCheckBox.Checked)
                {
                    Directory.CreateDirectory($"{confDir}/weathers");

                    var thunderList = createCleanList(thunderTextBox.Text);
                    var skyTextureList = createCleanList(skyTextBox.Text);
                    var weathers = Directory.GetFiles("./rndata/default/gamedata/config/weathers");

                    foreach (string weatherPath in weathers)
                    {
                        StreamReader sr = new StreamReader(weatherPath);
                        List<string> weatherList = new List<string>(sr.ReadToEnd().Split(']'));
                        sr.Close();

                        string newWeather = weatherList[0] + "]" + weatherList[1];
                        for (int i = 2; i < weatherList.Count; i++)
                        {
                            string currentWeather = weatherList[i];

                            if ((int)thunderNumericUpDown.Value > rnd.Next(100))
                            {
                                currentWeather = replaceStat(currentWeather, "thunderbolt", thunderList[rnd.Next(thunderList.Length)]);
                            }
                            if ((int)rainNumericUpDown.Value > rnd.Next(100))
                            {
                                currentWeather = replaceStat(currentWeather, "rain_density", Math.Round(rnd.NextDouble(), 2));
                            }

                            currentWeather = replaceStat(currentWeather, "sky_rotation", rnd.Next(360));
                            currentWeather = replaceStat(currentWeather, "far_plane", rnd.Next(100, 3001));
                            currentWeather = replaceStat(currentWeather, "fog_distance", rnd.Next(100, 3001));
                            currentWeather = replaceStat(currentWeather, "fog_density", Math.Round(rnd.NextDouble(), 2));
                            currentWeather = replaceStat(currentWeather, "bolt_period", $"{Math.Round(rnd.NextDouble() * 10 + 2, 1)}f");
                            currentWeather = replaceStat(currentWeather, "bolt_duration", $"{Math.Round(rnd.NextDouble() * 3.9 + 0.1, 2)}f");
                            currentWeather = replaceStat(currentWeather, "wind_velocity", Math.Round(rnd.NextDouble() * 100, 1));
                            currentWeather
                                = replaceStat(currentWeather, "sky_color", $"{Math.Round(rnd.NextDouble(), 2)}, {Math.Round(rnd.NextDouble(), 2)}, {Math.Round(rnd.NextDouble(), 2)}");
                            currentWeather
                                = replaceStat(currentWeather, "clouds_color", $"{Math.Round(rnd.NextDouble(), 3)}, {Math.Round(rnd.NextDouble(), 3)}, {Math.Round(rnd.NextDouble(), 3)}, {Math.Round(rnd.NextDouble(), 1)}, {Math.Round(rnd.NextDouble() + 1, 1)}");
                            currentWeather
                                = replaceStat(currentWeather, "fog_color", $"{Math.Round(rnd.NextDouble(), 3)}, {Math.Round(rnd.NextDouble(), 3)}, {Math.Round(rnd.NextDouble(), 3)}");
                            currentWeather
                                = replaceStat(currentWeather, "rain_color", $"{Math.Round(rnd.NextDouble(), 3)}, {Math.Round(rnd.NextDouble(), 3)}, {Math.Round(rnd.NextDouble(), 3)}");
                            currentWeather
                                = replaceStat(currentWeather, "ambient", $"{Math.Round(rnd.NextDouble() * 0.2 + 0.01, 4)}, {Math.Round(rnd.NextDouble() * 0.2 + 0.01, 4)}, {Math.Round(rnd.NextDouble() * 0.2 + 0.01, 4)}");
                            currentWeather
                                = replaceStat(currentWeather, "hemi_color", $"{Math.Round(rnd.NextDouble(), 3)}, {Math.Round(rnd.NextDouble(), 3)}, {Math.Round(rnd.NextDouble(), 3)}, {Math.Round(rnd.NextDouble(), 1)}");
                            currentWeather
                                = replaceStat(currentWeather, "sun_color", $"{Math.Round(rnd.NextDouble(), 3)}, {Math.Round(rnd.NextDouble(), 3)}, {Math.Round(rnd.NextDouble(), 3)}");
                            currentWeather = replaceStat(currentWeather, "sun_dir", $"{Math.Round(rnd.NextDouble() * 39 - 40, 1)}, {rnd.Next(200, 301)}");
                            currentWeather = replaceStat(currentWeather, "sky_texture", skyTextureList[rnd.Next(skyTextureList.Length)]);

                            newWeather += "]" + currentWeather;
                        }

                        FileStream outputFile = new FileStream(weatherPath.Replace("./rndata/default/gamedata", newGamedataPath), FileMode.Create);
                        byte[] buffer = Encoding.Default.GetBytes(newWeather);
                        outputFile.Write(buffer, 0, buffer.Length);
                        outputFile.Close();
                    }
                }
            }
            catch
            {
                new InfoForm("Ошибка генерации погоды. Операция прервана.").ShowDialog();
                return;
            }
            //доп функции
            string message = "";
            try
            {
                if (advancedGulagCheckBox.Checked)
                {
                    message = advancedGulagCheckBox.Text;
                    File.Copy($"{defaultGamedataPath}/scripts/smart_terrain.script", $"{newGamedataPath}/scripts/smart_terrain.script");
                    File.Copy($"{defaultGamedataPath}/scripts/xr_gulag.script", $"{newGamedataPath}/scripts/xr_gulag.script");
                }

                if (equipWeaponEverywhereCheckBox.Checked)
                {
                    message = equipWeaponEverywhereCheckBox.Text;
                    File.Copy($"{defaultGamedataPath}/scripts/sr_no_weapon.script", $"{newGamedataPath}/scripts/sr_no_weapon.script");
                }

                if (barAlarmCheckBox.Checked)
                {
                    message = barAlarmCheckBox.Text;
                    File.Copy($"{defaultGamedataPath}/config/scripts/bar_territory_zone.ltx", $"{newGamedataPath}/config/scripts/bar_territory_zone.ltx");
                }

                if (giveKnifeCheckBox.Checked)
                {
                    message = giveKnifeCheckBox.Text;
                    File.Copy($"{defaultGamedataPath}/spawns/all.spawn", $"{newGamedataPath}/spawns/all.spawn");
                }

                if (disableFreedomAngryCheckBox.Checked)
                {
                    message = disableFreedomAngryCheckBox.Text;
                    File.Copy($"{defaultGamedataPath}/scripts/gulag_military.script", $"{newGamedataPath}/scripts/gulag_military.script");
                }

                if (respawnCheckBox.Checked)
                {
                    message = respawnCheckBox.Text;
                    File.Copy($"{defaultGamedataPath}/scripts/se_respawn.script", $"{newGamedataPath}/scripts/se_respawn.script");
                }

                if (gScriptCheckBox.Checked)
                {
                    message = gScriptCheckBox.Text;
                    File.Copy($"{defaultGamedataPath}/scripts/_g.script", $"{newGamedataPath}/scripts/_g.script");
                }

                if (translateCheckBox.Checked)
                {
                    if (shuffleTextCheckBox.Checked)
                    {
                        shuffleAndCopyText(newGamedataPath);
                    }
                    else
                    {
                        string oldPath = $"{defaultGamedataPath}/config/text/rus";
                        string newPath = $"{newGamedataPath}/config/text/rus";
                        message = translateCheckBox.Text;
                        Directory.CreateDirectory($"{newGamedataPath}/config/text/rus");

                        foreach (string file in Directory.GetFiles(oldPath))
                        {
                            string tmpFile = file.Replace('\\', '/');
                            File.Copy(tmpFile, newPath + tmpFile.Substring(tmpFile.LastIndexOf('/')));
                        }
                    }
                }
            }
            catch
            {
                new InfoForm("Ошибка при копировании дополнителных настроек. Операция прервана." + $"\n({message})").ShowDialog();
                return;
            }

            new InfoForm("Сохранено").ShowDialog();
        }

        //загрузка списков по умолчанию
        private void loadDefaultButton_Click(object sender, EventArgs e)
        {
            loadLists(true);
        }

        //загрузка списков редактируемых или дефолтных
        private void loadLists(bool isDefault)
        {
            //заполнения текстовых полей
            //type, а не fileName, потому что при загрузке дефолтных списокв
            //добавляется слово default/
            void fillTextBox(string type, TextBox textBox)
            {
                try
                {
                    using (StreamReader sr = new StreamReader($"./rndata/{type}.txt"))
                    {
                        textBox.Text = sr.ReadToEnd();
                        sr.Close();
                    }
                }
                catch
                {
                    errList.Add(type);
                }
            }

            errList.Clear();

            if (isDefault)
            {
                //дефолтным не нужно перезаполнять список loadedDataList
                //чтоб оставались отличия от кеша для проверки на необходимость сохранения
                fillTextBox("default/community", communityTextBox);
                fillTextBox("default/other", otherTextBox);
                fillTextBox("default/af", afTextBox);
                fillTextBox("default/ammo", ammoTextBox);
                fillTextBox("default/item", itemTextBox);
                fillTextBox("default/model", modelTextBox);
                fillTextBox("default/outfit", armorTextBox);
                fillTextBox("default/sound", soundTextBox);
                fillTextBox("default/weapon", weaponTextBox);
                fillTextBox("default/npcexception", npcExecptTextBox);
                fillTextBox("default/icons", iconsTextBox);
                fillTextBox("default/names", namesTextBox);
                fillTextBox("default/skybox", skyTextBox);
                fillTextBox("default/thunderbolt", thunderTextBox);
                fillTextBox("default/weapon_snd_reload", reloadSoundsTextBox);
                fillTextBox("default/weapon_snd_shoot", shootSoundsTextBox);
            }
            else
            {
                loadedDataList.Clear();

                fillTextBox("community", communityTextBox);
                fillTextBox("other", otherTextBox);
                fillTextBox("af", afTextBox);
                fillTextBox("ammo", ammoTextBox);
                fillTextBox("item", itemTextBox);
                fillTextBox("model", modelTextBox);
                fillTextBox("outfit", armorTextBox);
                fillTextBox("sound", soundTextBox);
                fillTextBox("weapon", weaponTextBox);
                fillTextBox("npcexception", npcExecptTextBox);
                fillTextBox("icons", iconsTextBox);
                fillTextBox("names", namesTextBox);
                fillTextBox("skybox", skyTextBox);
                fillTextBox("thunderbolt", thunderTextBox);
                fillTextBox("weapon_snd_reload", reloadSoundsTextBox);
                fillTextBox("weapon_snd_shoot", shootSoundsTextBox);

                foreach (TextBox tb in textBoxList)
                {
                    loadedDataList.Add(tb.Text);
                }
            }

            if (errList.Count > 0)
            {
                string errMessage = "Не удалось загрузить следующие файлы:\n\n";

                foreach (string file in errList)
                {
                    errMessage += file + ".txt, ";
                }

                new InfoForm(errMessage).ShowDialog();
            }
        }

        //загрузка списков при старте приложения
        private void Form1_Shown(object sender, EventArgs e)
        {
            loadLists(false);
        }

        private void allCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CheckBox cb in generateTypeCheckBoxList)
            {
                cb.Checked = allCheckBox.Checked;
            }

            if (!npcCheckBox.Enabled)
            {
                npcCheckBox.Checked = false;
            }
        }

        //Предмет и количество для добавления в тайник
        private string generateItem(string[] itemList, int maxItemCount)
        {
            int itemPackCount = 1;
            string item = itemList[rnd.Next(itemList.Length)];

            //Для патронов
            if (item.Contains(" "))
            {
                try
                {
                    itemPackCount = Convert.ToInt32(item.Split(' ')[1]);
                }
                catch
                {
                }
                item = item.Split(' ')[0];
            }

            int count = rnd.Next(1, maxItemCount + 1) * itemPackCount;

            return item + ", " + count;
        }

        //замена целочисленного стата файла
        string replaceStat(string item, string statName, int statValue)
        {
            if (item.Contains(statName))
            {
                string tmp = item.Substring(item.IndexOf(statName));
                return item.Replace(tmp.Substring(0, tmp.IndexOf('\n')), statName + " = " + statValue);
            }

            return item;
        }

        //замена дробного стата файла
        string replaceStat(string item, string statName, double statValue)
        {
            if (item.Contains(statName))
            {
                string tmp = item.Substring(item.IndexOf(statName));
                return item.Replace(tmp.Substring(0, tmp.IndexOf('\n')), statName + " = " + statValue);
            }

            return item;
        }

        //замена строкового стата файла
        string replaceStat(string item, string statName, string statValue)
        {
            if (item.Contains(statName))
            {
                string tmp = item.Substring(item.IndexOf(statName));
                return item.Replace(tmp.Substring(0, tmp.IndexOf('\n')), statName + " = " + statValue);
            }

            return item;
        }

        //генерация статов артов
        List<Tuple<string, double>> generateAfStats(int statsNum)
        {
            List<string> statsList = new List<string>(fullAfStats);
            statsList.AddRange(fullAfStats2);
            List<Tuple<string, double>> tmpString = new List<Tuple<string, double>>();

            for (int i = 0; i < statsNum; i++)
            {
                double rndStat = 0.0;
                int rndInd = rnd.Next(0, statsList.Count);
                string currStat = statsList[rndInd];
                statsList.RemoveAt(rndInd);

                if (currStat == "radiation_restore_speed")
                {
                    rndStat = Math.Round(rnd.NextDouble() * 0.01 - 0.005, 4);
                }
                else if (currStat == "health_restore_speed")
                {
                    rndStat = Math.Round(rnd.NextDouble() * 0.002 - 0.001, 4);
                }
                else if (currStat == "power_restore_speed")
                {
                    rndStat = Math.Round(rnd.NextDouble() * 0.02 - 0.01, 3);
                }
                else if (currStat == "bleeding_restore_speed")
                {
                    rndStat = Math.Round(rnd.NextDouble() * 0.04 - 0.02, 3);
                }
                else
                {
                    rndStat = Math.Round(rnd.NextDouble() * 0.6 - 0.3 + 1.0, 2);
                }

                tmpString.Add(new Tuple<string, double>(currStat, rndStat));
            }

            return tmpString;
        }

        //дополнительный множитель
        /*int multiplier(int probability, int multValue)
        {
            if (rnd.Next(100) < probability)
            {
                return multValue;
            }

            return 1;
        }*/

        //надпись "рекомендуется" при активации рандома группировок
        private void communityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Label label in recommendLabelList)
            {
                label.Visible = communityCheckBox.Checked;
            }
            if (communityCheckBox.Checked)
            {
                advancedGulagCheckBox.Checked = true;
                advancedGulagCheckBox.Enabled = false;
            }
            else
            {
                advancedGulagCheckBox.Checked = false;
                advancedGulagCheckBox.Enabled = true;
            }
        }

        //Справка
        private void weaponGuideButton_Click(object sender, EventArgs e)
        {
            new GuideForm(0).ShowDialog();
        }

        private void itemGuideButton_Click(object sender, EventArgs e)
        {
            new GuideForm(1).ShowDialog();
        }

        private void npcGuideButton_Click(object sender, EventArgs e)
        {
            new GuideForm(2).ShowDialog();
        }

        //Создание списка из текстбоксов
        private string[] createCleanList(string str, bool isNeedSpaces = false)
        {
            if (isNeedSpaces)
            {
                string woSpacesStr = Regex.Replace(str, "[\\t\\v\\r\\f]", "");
                woSpacesStr = Regex.Replace(woSpacesStr, "\\ {2,}", " ");
                return Regex.Replace(woSpacesStr, "\\n{2,}", "\n").Split('\n');
            }
            else
            {
                string woSpacesStr = Regex.Replace(str, "[\\t\\v\\r\\f\\ ]", "");
                return Regex.Replace(woSpacesStr, "\\n{2,}", "\n").Split('\n');
            }
        }

        //Отключение перемешивания текста при отключении перевода
        private void translateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (translateCheckBox.Checked)
            {
                shuffleTextCheckBox.Enabled = true;
            }
            else
            {
                shuffleTextCheckBox.Checked = false;
                shuffleTextCheckBox.Enabled = false;
            }
        }

        //Перемешивание текста
        private void shuffleAndCopyText(string newGamedataPath)
        {
            string oldPath = $"{defaultGamedataPath}/config/text/rus";
            string newPath = $"{newGamedataPath}/config/text/rus";
            Directory.CreateDirectory($"{newGamedataPath}/config/text/rus");

            Dictionary<string, string> tmpFilesDataMap = new Dictionary<string, string>();
            Dictionary<string, List<string>> classifiedTextByLengthMap = new Dictionary<string, List<string>>();

            //Составление карты текста по длине
            foreach (string file in Directory.GetFiles(oldPath))
            {
                StreamReader sr = new StreamReader(file, Encoding.Default);
                var textData = new List<string>(sr.ReadToEnd().Replace("<text>", "\a").Split('\a'));
                sr.Close();

                string newTextData = textData[0];
                textData.RemoveAt(0);

                foreach (string textSection in textData)
                {
                    string text = textSection.Substring(0, textSection.IndexOf("</text>"));
                    string roundedLength = (text.Length / 5 * 5).ToString();
                    newTextData += "\a" + textSection.Replace(text + "</text>", roundedLength + "</text>");

                    if (!classifiedTextByLengthMap.Keys.Contains(roundedLength))
                    {
                        classifiedTextByLengthMap[roundedLength] = new List<string>();
                    }
                    classifiedTextByLengthMap[roundedLength].Add(text);
                }

                tmpFilesDataMap[file] = newTextData;
            }

            //Замена текста в игровых файлах
            foreach (string file in tmpFilesDataMap.Keys)
            {
                var textData = new List<string>(tmpFilesDataMap[file].Split('\a'));
                string newTextData = textData[0];
                textData.RemoveAt(0);

                foreach (string textSection in textData)
                {
                    string roundedLength = textSection.Substring(0, textSection.IndexOf("</text>"));
                    int index = rnd.Next(classifiedTextByLengthMap[roundedLength].Count);
                    newTextData += "<text>" + textSection.Replace(roundedLength + "</text>", classifiedTextByLengthMap[roundedLength][index] + "</text>");
                    classifiedTextByLengthMap[roundedLength].RemoveAt(index);
                }

                string tmpFile = file.Replace('\\', '/');
                FileStream outputFile = new FileStream(newPath + tmpFile.Substring(tmpFile.LastIndexOf('/')), FileMode.Create);
                byte[] buffer = Encoding.Default.GetBytes(newTextData);
                outputFile.Write(buffer, 0, buffer.Length);
                outputFile.Close();
            }
        }

        //Чекбоксы вкладки неписей
        private void modelsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            modelTextBox.Enabled = modelsCheckBox.Checked;
        }

        private void soundsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            soundTextBox.Enabled = soundsCheckBox.Checked;
        }

        private void iconsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            iconsTextBox.Enabled = iconsCheckBox.Checked;
        }

        private void namesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            namesTextBox.Enabled = namesCheckBox.Checked;
            onlyGenerateCheckBox.Enabled = namesCheckBox.Checked;
            if (!namesCheckBox.Checked)
            {
                onlyGenerateCheckBox.Checked = false;
            }
        }

        private void npcCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            communityCheckBox.Enabled = npcCheckBox.Checked;
            if (!npcCheckBox.Checked)
            {
                communityCheckBox.Checked = false;
            }

            foreach (CheckBox cb in npcCheckBoxWithoutTextBoxList)
            {
                cb.Enabled = npcCheckBox.Checked;
                cb.Checked = npcCheckBox.Checked;
            }

            linkLabel1.Enabled = npcCheckBox.Checked;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl.SelectedTab = tabPage9;
        }
    }
}
