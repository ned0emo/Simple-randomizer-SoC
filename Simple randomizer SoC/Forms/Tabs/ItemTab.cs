using RandomizerSoC;
using Simple_randomizer_SoC.Forms.Dialogs;
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
    public partial class ItemTab : UserControl, ILocalizable
    {
        private readonly ItemConfig config;
        private readonly DataListEditor listEditComponent = Singleton<DataListEditor>.Instance;
        private readonly ParametersEditor parametersEditor = Singleton<ParametersEditor>.Instance;

        public ItemTab(ItemConfig config)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            this.config = config;

            artefactProbabilityInput.Value = config.ArtefactProbability;
            armorProbabilityInput.Value = config.ArmorProbability;
            itemProbabilityInput.Value = config.ConsumableProbability;

            minArtefactStatCountInput.Value = config.MinArtefactStatCount;
            maxArtefactStatCountInput.Value = config.MaxArtefactStatCount;
        }

        private async void artefactSectionsButton_Click(object sender, EventArgs e)
        {
            var dialog = new ComplexListDialog<ArtefactStats>("Секции артефактов", config.ArtefactSections, new List<string> { "Артефакт", "Секция характеристик" });
            dialog.RowValidator = (afStat) => !string.IsNullOrWhiteSpace(afStat.Name) && !string.IsNullOrWhiteSpace(afStat.AbsorbationSection);

            await listEditComponent.OpenEditThenSave<ComplexListDialog<ArtefactStats>, ArtefactStats>(dialog, config);
        }

        private async void artefactParametersButton_Click(object sender, EventArgs e)
        {
            await parametersEditor.ParametersEditAndSave(Localization.Get("artefactsStandardParamsShort"), config.StandardArtefactParameters, config);
        }

        private async void artefactStatParametersButton_Click(object sender, EventArgs e)
        {
            await parametersEditor.ParametersEditAndSave(Localization.Get("artefactsParams0Full"), config.StatArtefactParameters0, config);
        }

        private async void artefactStatParameters1Button_Click(object sender, EventArgs e)
        {
            await parametersEditor.ParametersEditAndSave(Localization.Get("artefactsParams1Full"), config.StatArtefactParameters1, config);
        }

        private async void armorSectionsButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog(Localization.Get("armorSections"), config.ArmorSections), config);
        }

        private async void armorImmunitySectionsButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog(Localization.Get("armorImmunitySectionsShort"), config.ArmorImmunitySections), config);
        }

        private async void armorParametersButton_Click(object sender, EventArgs e)
        {
            await parametersEditor.ParametersEditAndSave(Localization.Get("armorParams"), config.ArmorParameters, config);
        }

        private async void armorImmunityParametersButton_Click(object sender, EventArgs e)
        {
            await parametersEditor.ParametersEditAndSave(Localization.Get("armorImmunityParamsShort"), config.ArmorImmunityParameters, config);
        }

        private async void itemSectionsButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog(Localization.Get("consumablesSections"), config.ConsumableSections), config);
        }

        private async void itemParametersButton_Click(object sender, EventArgs e)
        {
            await parametersEditor.ParametersEditAndSave(Localization.Get("consumablesParamsShort"), config.ConsumableParameters, config);
        }

        private void artefactProbabilityInput_ValueChanged(object sender, EventArgs e)
        {
            config.ArtefactProbability = (int)artefactProbabilityInput.Value;
        }

        private void armorProbabilityInput_ValueChanged(object sender, EventArgs e)
        {
            config.ArmorProbability = (int)armorProbabilityInput.Value;
        }

        private void itemProbabilityInput_ValueChanged(object sender, EventArgs e)
        {
            config.ConsumableProbability = (int)itemProbabilityInput.Value;
        }

        private void minArtefactStatCountInput_ValueChanged(object sender, EventArgs e)
        {
            config.MinArtefactStatCount = (int)minArtefactStatCountInput.Value;
        }

        private void maxArtefactStatCountInput_ValueChanged(object sender, EventArgs e)
        {
            config.MaxArtefactStatCount = (int)maxArtefactStatCountInput.Value;
        }

        public void Localize()
        {
            titleLabel.Text = Localization.Get("itemsTitle");
            artefcatsGenerateSectionsLabel.Text = Localization.Get("artefactsGenerateSection");
            artefcatsStandardParamsLabel.Text = Localization.Get("artefactsStandardParams");
            artefactsStatsLabel.Text = Localization.Get("artefcatsStats");
            artefactStatParameters0Button.Text = Localization.Get("artefactsParams0");
            artefactStatParameters1Button.Text = Localization.Get("artefactsParams1");
            minArtefactsStatsLabel.Text = Localization.Get("minArtefactStats");
            maxArtefactsStatsLabel.Text = Localization.Get("maxArtefactStats");

            armorGenerateSectionsLabel.Text = Localization.Get("armorGenerateSections");
            armorImmunitySectionsLabel.Text = Localization.Get("armorImmunitySections");
            armorMainStatsLabel.Text = Localization.Get("armorMainParams");
            armorImmunityStatsLabel.Text = Localization.Get("armorImmunityParams");

            consumablesGenerateSectionsLabel.Text = Localization.Get("consumablesGenerateSections");
            consumablesStatsLabel.Text = Localization.Get("consumablesParams");

            artefactsProbabilityLabel.Text = Localization.Get("artefactsProbability");
            armorProbabilityLabel.Text = Localization.Get("armorProbability");
            consumablesProbabilityLabel.Text = Localization.Get("consumablesProbability");

            artefactSectionsButton.Text = Localization.Get("editList");
            artefactParametersButton.Text = Localization.Get("editList");
            armorParametersButton.Text = Localization.Get("editList");
            armorSectionsButton.Text = Localization.Get("editList");
            armorImmunitySectionsButton.Text = Localization.Get("editList");
            armorParametersButton.Text = Localization.Get("editList");
            armorImmunityParametersButton.Text = Localization.Get("editList");
            itemSectionsButton.Text = Localization.Get("editList");
            itemParametersButton.Text = Localization.Get("editList");
        }
    }
}
