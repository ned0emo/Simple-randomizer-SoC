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
        public SaveForm(string files, ResourceManager rm)
        {
            InitializeComponent();
            string info;
            try
            {
                info = rm.GetString("overwritingFiles");
                this.Name = rm.GetString("saveFormName");
                cancelButton.Text = rm.GetString("cancel");
            }
            catch
            {
                info = "Перезапись/Overwrite:";
                this.Name = "Сохранение/Saving";
                cancelButton.Text = "Cancel";
            }
            infoMessageLabel.Text = $"{info}\n{files}";
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
