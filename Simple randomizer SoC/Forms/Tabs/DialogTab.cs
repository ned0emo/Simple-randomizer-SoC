using Simple_randomizer_SoC.Forms.Dialogs;
using Simple_randomizer_SoC.Forms.Templates;
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
    public partial class DialogTab : UserControl, ILocalizable
    {
        private readonly DialogConfig _config;
        private readonly DataListEditor listEditComponent = Singleton<DataListEditor>.Instance;

        public DialogTab(DialogConfig config)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            _config = config;

            probabilityInput.Value = config.ReplaceProbability;
            probabilityInput.MouseWheel += NonScrollNumeric.NonScrollEvent;
        }

        private void probabilityInput_ValueChanged(object sender, EventArgs e)
        {
            _config.ReplaceProbability = (int)probabilityInput.Value;
        }

        private async void infoExceptionsButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.OpenEditThenSave(new SimpleListDialog(Localization.Get("dialogInfoExceptions"), _config.InfoExceptions), _config);
        }

        private async void actionExceptionsButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.OpenEditThenSave(new SimpleListDialog(Localization.Get("dialogActionExceptions"), _config.ActionExceptions), _config);
        }

        private async void preconditionExceptionsButton_Click(object sender, EventArgs e)
        {
            await listEditComponent.OpenEditThenSave(new SimpleListDialog(Localization.Get("dialogPreconditionExceptions"), _config.PreconditionExceptions), _config);
        }

        public void Localize()
        {
            titleLabel.Text = Localization.Get("dialogsTitle");
            infoExceptionsLabel.Text = Localization.Get("dialogInfoExceptions");
            actionExceptionsLabel.Text = Localization.Get("dialogActionExceptions");
            preconditionExceptionaLabel.Text = Localization.Get("dialogPreconditionExceptions");
            probabilityLabel.Text = Localization.Get("dialogProbability");
            infoExceptionsButton.Text = Localization.Get("editList");
            actionExceptionsButton.Text = Localization.Get("editList");
            preconditionExceptionsButton.Text = Localization.Get("editList");
        }
    }
}
