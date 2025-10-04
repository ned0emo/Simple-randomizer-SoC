using Simple_randomizer_SoC.Forms.Dialogs;
using Simple_randomizer_SoC.Models.AppConfig;
using Simple_randomizer_SoC.Models.Common;
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

namespace Simple_randomizer_SoC.Forms.Templates
{
    public partial class DeathItemsControl : UserControl, ILocalizable
    {
        private readonly DeathItemsParameters _parameters;
        private readonly DeathItemsConfig _config;
        private readonly List<ItemThreeCount> _ammoList;
        private readonly string _titleResx;

        private readonly DataListEditor _dataListEditor = Singleton<DataListEditor>.Instance;

        public DeathItemsControl(string titleResx, DeathItemsParameters parameters, DeathItemsConfig config, List<ItemThreeCount> ammoList)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            titleLabel.Text = Localization.Get(titleResx);

            _parameters = parameters;
            _config = config;
            _ammoList = ammoList;
            _titleResx = titleResx;
        }

        private async void editListButton_Click(object sender, EventArgs e)
        {
            if (_ammoList == null)
            {
                await _dataListEditor.OpenEditThenSave(new SimpleListDialog(Localization.Get("deadNpcItems") + titleLabel.Text, _parameters.Items), _config);
            }
            else
            {
                _parameters.Items.Clear();
                var dialog = new ComplexListDialog<ItemThreeCount>(Localization.Get("deadNpcAmmo"), _ammoList,
                    new List<string> {
                        Localization.Get("ammoType"),
                        Localization.Get("minMultiplier"),
                        Localization.Get("maxMultiplier"),
                        Localization.Get("maxWeaponToSpawnAmmo") });
                dialog.DataPreprocessor = r => { if (r.Name != null) r.Name = r.Name.Trim(); return r; };
                dialog.RowValidator = r => r.Count1 > 0 && r.Count2 >= r.Count1 && r.Count3 > 0 && r != null;

                await _dataListEditor.OpenEditThenSave<ComplexListDialog<ItemThreeCount>, ItemThreeCount>(dialog, _config);
            }
        }

        private async void difficultyCountButton_Click(object sender, EventArgs e)
        {
            var dialog = new ComplexListDialog<ItemMinMax>(Localization.Get("countByDifficulty"), _parameters.ItemCountsByDifficulty,
                new List<string> {
                    Localization.Get("difficultyLevel"),
                    Localization.Get("minCount"),
                    Localization.Get("maxCount") });
            dialog.RowValidator = (r) => r.MinCount <= r.MaxCount;

            await _dataListEditor.OpenEditThenSave<ComplexListDialog<ItemMinMax>, ItemMinMax>(dialog, _config);
        }

        private async void levelCountButton_Click(object sender, EventArgs e)
        {
            var dialog = new ComplexListDialog<ItemMinMax>(Localization.Get("multiplierByLevel"), _parameters.ItemCountsByLevel,
                new List<string> {
                    Localization.Get("level"),
                    Localization.Get("minMultiplier"),
                    Localization.Get("maxMultiplier") });
            dialog.RowValidator = (r) => r.MinCount <= r.MaxCount;

            await _dataListEditor.OpenEditThenSave<ComplexListDialog<ItemMinMax>, ItemMinMax>(dialog, _config);
        }

        private async void communityProbabilityButton_Click(object sender, EventArgs e)
        {
            var dialog = new ComplexListDialog<ItemProbability>(Localization.Get("probabilityByCommunity"), _parameters.ItemProbabilitiesByCommunity,
                new List<string> {
                    Localization.Get("community"),
                    Localization.Get("minProbability0to1"),
                    Localization.Get("maxProbability0to1") });
            dialog.RowValidator = (r) => r.MinProbability <= r.MaxProbability && r.MinProbability >= 0 && r.MaxProbability <= 1;

            await _dataListEditor.OpenEditThenSave<ComplexListDialog<ItemProbability>, ItemProbability>(dialog, _config);
        }

        public void Localize()
        {
            itemsLabel.Text = Localization.Get("itemsList");
            countByDifficultyLabel.Text = Localization.Get("countByDifficulty");
            multiplierByLevelLabel.Text = Localization.Get("multiplierByLevel");
            probabilityByCommunityLabel.Text = Localization.Get("probabilityByCommunity");
            editListButton.Text = Localization.Get("editList");
            difficultyCountButton.Text = Localization.Get("editList");
            levelCountButton.Text = Localization.Get("editList");
            communityProbabilityButton.Text = Localization.Get("editList");
            titleLabel.Text = Localization.Get(_titleResx);
        }
    }
}
