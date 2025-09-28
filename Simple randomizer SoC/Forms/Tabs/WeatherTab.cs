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
    public partial class WeatherTab : UserControl
    {
        private readonly WeatherConfig _config;
        private readonly DataListEditor listEditComponent = Singleton<DataListEditor>.Instance;
        private readonly ParametersEditor parametersEditor = Singleton<ParametersEditor>.Instance;

        public WeatherTab(WeatherConfig config)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            _config = config;

            rainProbabilityInput.Value = config.RainProbability;
            thunderProbabilityInput.Value = config.ThunderProbability;
            weatherProbabilityInput.Value = config.StatProbability;
        }

        private async void weatherSectionsButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.OpenEditThenSave<SimpleListDialog, string>(new SimpleListDialog("Секции погоды", _config.Sections), _config);
        }

        private async void weatherParametersButton_Click(object sender, EventArgs e)
        {
            await parametersEditor.ParametersEditAndSave("Параметры для генерации погоды", _config.Parameters, _config);
        }

        private void rainProbabilityInput_ValueChanged(object sender, EventArgs e)
        {
            _config.RainProbability = (int)rainProbabilityInput.Value;
        }

        private void thunderProbabilityInput_ValueChanged(object sender, EventArgs e)
        {
            _config.ThunderProbability = (int)thunderProbabilityInput.Value;
        }

        private void weatherProbabilityInput_ValueChanged(object sender, EventArgs e)
        {
            _config.StatProbability = (int)weatherProbabilityInput.Value;
        }
    }
}
