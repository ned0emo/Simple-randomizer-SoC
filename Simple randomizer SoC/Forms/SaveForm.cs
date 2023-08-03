using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomizerSoC
{
    public partial class SaveForm : Form
    {
        List<string> files;
        List<string> info;

        public SaveForm(List<string> files, List<string> info)
        {
            this.files = files;
            this.info = info;

            InitializeComponent();
            infoMessageLabel.Text = "Следующие файлы будут перезаписаны:\n";

            foreach (string file in files)
            {
                infoMessageLabel.Text += file + ".txt, ";
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < files.Count; i++)
            {
                using (FileStream fs = new FileStream($".\\rndata\\{files[i]}.txt", FileMode.Create))
                {
                    byte[] buffer = Encoding.Default.GetBytes(info[i]);
                    fs.Write(buffer, 0, buffer.Length);
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
