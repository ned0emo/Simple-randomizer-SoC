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
    public partial class DeathItemsControl : UserControl
    {
        private readonly DeathItemsParameters _parameters;
        private readonly DeathItemsConfig _config;
        private readonly List<ItemThreeCount> _ammoList;

        private readonly DataListEditor _dataListEditor = Singleton<DataListEditor>.Instance;

        public DeathItemsControl(string title, DeathItemsParameters parameters, DeathItemsConfig config, List<ItemThreeCount> ammoList)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            titleLabel.Text = title;

            _parameters = parameters;
            _config = config;
            _ammoList = ammoList;
        }

        private async void editListButton_Click(object sender, EventArgs e)
        {
            if (_ammoList == null)
            {
                await _dataListEditor.OpenEditThenSave(new SimpleListDialog("Предметы в рюкзкае убитого НПС: " + titleLabel.Text, _parameters.Items), _config);
            }
            else
            {
                _parameters.Items.Clear();
                var dialog = new ComplexListDialog<ItemThreeCount>("Патроны убитого НПС", _ammoList,
                    new List<string> { "Тип патронов", "Мин. множитель", "Макс. множитель", "Макс. количество оружия для появления патронов у убитого НПС" });
                dialog.DataPreprocessor = r => { if (r.Name != null) r.Name = r.Name.Trim(); return r; };
                dialog.RowValidator = r => r.Count1 > 0 && r.Count2 >= r.Count1 && r.Count3 > 0 && r != null;

                await _dataListEditor.OpenEditThenSave<ComplexListDialog<ItemThreeCount>, ItemThreeCount>(dialog, _config);
            }
        }

        private async void difficultyCountButton_Click(object sender, EventArgs e)
        {
            var dialog = new ComplexListDialog<ItemMinMax>("Количество предметов в завистимости от сложности", _parameters.ItemCountsByDifficulty,
                new List<string> { "Уровень сложности", "Минимальное количество", "Максимальное количество" });
            dialog.RowValidator = (r) => r.MinCount <= r.MaxCount;

            await _dataListEditor.OpenEditThenSave<ComplexListDialog<ItemMinMax>, ItemMinMax>(dialog, _config);
        }

        private async void levelCountButton_Click(object sender, EventArgs e)
        {
            var dialog = new ComplexListDialog<ItemMinMax>("Множитель предметов в завистимости от локации", _parameters.ItemCountsByLevel,
                new List<string> { "Локация", "Минимальный множитель", "Максимальный множитель" });
            dialog.RowValidator = (r) => r.MinCount <= r.MaxCount;

            await _dataListEditor.OpenEditThenSave<ComplexListDialog<ItemMinMax>, ItemMinMax>(dialog, _config);
        }

        private async void communityProbabilityButton_Click(object sender, EventArgs e)
        {
            var dialog = new ComplexListDialog<ItemProbability>("Вероятность появления предметов в зависимости от группировки", _parameters.ItemProbabilitiesByCommunity,
                new List<string> { "Группировка", "Минимальная вероятность (от 0 до 1)", "Максимальная вероятность (от 0 до 1)" });
            dialog.RowValidator = (r) => r.MinProbability <= r.MaxProbability && r.MinProbability >= 0 && r.MaxProbability <= 1;

            await _dataListEditor.OpenEditThenSave<ComplexListDialog<ItemProbability>, ItemProbability>(dialog, _config);
        }
    }
}
