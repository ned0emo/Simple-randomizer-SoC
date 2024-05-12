using Simple_randomizer_SoC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomizerSoC
{
    public partial class SaveForm : Form
    {
        public SaveForm(string files)
        {
            InitializeComponent();
            string info;
            try
            {
                info = Localization.Get("overwritingFiles");
                this.Name = Localization.Get("saveFormName");
                cancelButton.Text = Localization.Get("cancel");
            }
            catch
            {
                info = "Перезапись/Overwrite:";
                this.Name = "Сохранение/Saving";
                cancelButton.Text = "Cancel";
            }
            infoMessageLabel.Text = $"{info}\n{files}";
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
