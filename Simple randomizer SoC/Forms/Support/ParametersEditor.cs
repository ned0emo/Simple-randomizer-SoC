using Simple_randomizer_SoC.Forms.Dialogs;
using Simple_randomizer_SoC.Models.AppConfig;
using Simple_randomizer_SoC.Models.Parameters;
using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_randomizer_SoC.Forms.Support
{
    public class ParametersEditor
    {
        public async Task ParametersEditAndSave(string title, ParameterContainer parameterContainer, IConfig config)
        {
            var dialog = new ParameterListDialog(title, parameterContainer);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                parameterContainer.Update(dialog.ParameterContainer);
                await ConfigHandler.Save(config);
            }
        }

        public void ParametersEdit(string title, ParameterContainer parameterContainer)
        {
            var dialog = new ParameterListDialog(title, parameterContainer);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                parameterContainer.Update(dialog.ParameterContainer);
            }
        }
    }
}
