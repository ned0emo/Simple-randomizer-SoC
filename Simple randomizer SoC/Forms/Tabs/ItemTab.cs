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
    public partial class ItemTab : UserControl
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
            await listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog("Секции артефактов", config.ArtefactSections), config);
        }

        private async void artefactParametersButton_Click(object sender, EventArgs e)
        {
            await parametersEditor.ParametersEditAndSave("Стандартные параметры артефактов", config.StandardArtefactParameters, config);
        }

        private async void artefactStatParametersButton_Click(object sender, EventArgs e)
        {
            await parametersEditor.ParametersEditAndSave("Параметры характеристик артефактов, с базовым значением 0.0", config.StatArtefactParameters0, config);
        }

        private async void artefactStatParameters1Button_Click(object sender, EventArgs e)
        {
            await parametersEditor.ParametersEditAndSave("Параметры характеристик артефактов, с базовым значением 1.0", config.StatArtefactParameters1, config);
        }

        private async void armorSectionsButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog("Секции брони", config.ArmorSections), config);
        }

        private async void armorImmunitySectionsButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog("Секции износа брони", config.ArmorImmunitySections), config);
        }

        private async void armorParametersButton_Click(object sender, EventArgs e)
        {
            await parametersEditor.ParametersEditAndSave("Параметры брони", config.ArmorParameters, config);
        }

        private async void armorImmunityParametersButton_Click(object sender, EventArgs e)
        {
            await parametersEditor.ParametersEditAndSave("Параметры износа брони", config.ArmorImmunityParameters, config);
        }

        private async void itemSectionsButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog("Секции расходников", config.ConsumableSections), config);
        }

        private async void itemParametersButton_Click(object sender, EventArgs e)
        {
            await parametersEditor.ParametersEditAndSave("Параметры расходников", config.ConsumableParameters, config);
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
    }
}
