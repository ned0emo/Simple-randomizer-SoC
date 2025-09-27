using Simple_randomizer_SoC.Forms.Support;
using Simple_randomizer_SoC.Models.AppConfig;
using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_randomizer_SoC.Forms.Tabs
{
    public partial class NpcTab : UserControl
    {
        private readonly NpcConfig _config;
        private readonly DataListEditor listEditComponent = Singleton<DataListEditor>.Instance;

        public NpcTab(NpcConfig config)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            _config = config;

            modelCheckBox.Checked = config.UseModels;
            soundCheckBox.Checked = config.UseSounds;
            iconCheckBox.Checked = config.UseIcons;
            generateNameCheckBox.Checked = config.UseGenerateNames;
            uniqueNameCheckBox.Checked = config.UseUniqueNames;
            communityCheckBox.Checked = config.UseCommunities;
            mainWeaponCheckBox.Checked = config.UseMainWeapons;
            additionalWeaponCheckBox.Checked = config.UseAdditionalWeapons;
            singleWeaponCheckBox.Checked = config.SingleWeapon;
            extendCampCheckBox.Checked = config.ExtendCampsSettlement || config.UseCommunities;

            rankCheckBox.Checked = config.UseRank;
            minRankInput.Value = config.RankParameter.MinValue;
            maxRankInput.Value = config.RankParameter.MaxValue;

            moneyCheckBox.Checked = config.UseMoney;
            minMoneyInput.Value = config.MoneyParameter.MinValue;
            maxMoneyInput.Value = config.MoneyParameter.MaxValue;

            npcProbabilityInput.Value = config.Probability;
        }

        private async void modelButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.SimpleListEditAndSave("Модели НПС", _config.Models, _config);
        }

        private async void soundButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.SimpleListEditAndSave("Озвучка НПС", _config.Sounds, _config);
        }

        private async void iconButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.SimpleListEditAndSave("Миниатюры НПС", _config.Icons, _config);
        }

        private async void generateNameButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.SimpleListEditAndSave("Генерируемые имена НПС", _config.GenerateNames, _config);
        }

        private async void uniqueNameButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.SimpleListEditAndSave("Уникальные имена НПС", _config.UniqueNames, _config);
        }

        private async void communityButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.SimpleListEditAndSave("Группировки", _config.Communities, _config);
        }

        private async void exceptionButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.SimpleListEditAndSave("НПС, исключенные из генерации", _config.Exceptions, _config);
        }

        private async void mainWeaponButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.ComplexListEditAndSave("Основное оружие НПС", _config.MainWeapons,
                new List<string> { "Оружие", "Используемые патроны 1", "Используемые патроны 2", "Используемые патроны 3", "Используемые патроны 4", "Используемые патроны 5" },
                _config, true, (weaponAmmo) => weaponAmmo.Validate());
        }

        private async void additionalWeaponButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.ComplexListEditAndSave("Дополнительное оружие НПС", _config.AdditionalWeapons,
                new List<string> { "Оружие", "Используемые патроны 1", "Используемые патроны 2", "Используемые патроны 3", "Используемые патроны 4", "Используемые патроны 5" },
                _config, true, (weaponAmmo) => weaponAmmo.Validate());
        }

        private async void keepSupplieButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.SimpleListEditAndSave("Предметы, которые не нужно убирать при генерации НПС", _config.KeepingSupplies, _config);
        }

        private void singleWeaponCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.SingleWeapon = singleWeaponCheckBox.Checked;
            if (singleWeaponCheckBox.Checked)
            {
                mainWeaponCheckBox.Checked = true;
                mainWeaponCheckBox.Enabled = false;
                additionalWeaponCheckBox.Checked = true;
                additionalWeaponCheckBox.Enabled = false;
            }
            else
            {
                mainWeaponCheckBox.Enabled = true;
                additionalWeaponCheckBox.Enabled = true;
            }
        }

        private void communityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.UseCommunities = communityCheckBox.Checked;
            if (communityCheckBox.Checked)
            {
                extendCampCheckBox.Checked = true;
                extendCampCheckBox.Enabled = false;
            }
            else
            {
                extendCampCheckBox.Enabled = true;
            }
        }

        private void minRankInput_ValueChanged(object sender, EventArgs e)
        {
            _config.RankParameter.MinValue = (int)minRankInput.Value;
        }

        private void maxRankInput_ValueChanged(object sender, EventArgs e)
        {
            _config.RankParameter.MaxValue = (int)maxRankInput.Value;
        }

        private void minMoneyInput_ValueChanged(object sender, EventArgs e)
        {
            _config.MoneyParameter.MinValue = (int)minMoneyInput.Value;
        }

        private void maxMoneyInput_ValueChanged(object sender, EventArgs e)
        {
            _config.MoneyParameter.MaxValue = (int)maxMoneyInput.Value;
        }

        private void npcProbabilityInput_ValueChanged(object sender, EventArgs e)
        {
            _config.Probability = (int)npcProbabilityInput.Value;
        }

        private void generateNameCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.UseGenerateNames = generateNameCheckBox.Checked;
        }

        private void uniqueNameCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.UseUniqueNames = uniqueNameCheckBox.Checked;
        }

        private void mainWeaponCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.UseMainWeapons = mainWeaponCheckBox.Checked;
        }

        private void additionalWeaponCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.UseAdditionalWeapons = additionalWeaponCheckBox.Checked;
        }

        private void extendCampCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.ExtendCampsSettlement = extendCampCheckBox.Checked;
        }

        private void rankCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.UseRank = rankCheckBox.Checked;
        }

        private void moneyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.UseMoney = moneyCheckBox.Checked;
        }
    }
}
