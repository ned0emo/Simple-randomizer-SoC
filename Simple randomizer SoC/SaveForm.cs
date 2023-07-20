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

namespace TreasuresSoC
{
    public partial class SaveForm : Form
    {
        List<string> files;
        List<string> info;
        Form1 parent;

        public SaveForm(List<string> files, List<string> info, Form1 parent)
        {
            this.files = files;
            this.info = info;
            this.parent = parent;

            InitializeComponent();
            infoMessageLabel.Text = "Следующие файлы будут перезаписаны:\n";

            foreach (string file in files)
            {
                infoMessageLabel.Text += file + ".txt, ";
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            parent.isSaved = false;
            this.Close();
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

            parent.isSaved = true;
            this.Close();
        }
    }
}
