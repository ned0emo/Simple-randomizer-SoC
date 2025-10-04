using RandomizerSoC;
using Simple_randomizer_SoC.Forms.Dialogs;
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
    public partial class FormClosingControl : UserControl
    {
        public FormClosingControl()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            mainLabel.Text = Localization.Get("programClosing");
            forceCloseButton.Text = Localization.Get("forceCloseButton");

            EnableButton();
        }

        private void forceCloseButton_Click(object sender, EventArgs e)
        {
            ((MainForm)ParentForm).IsForceClosed = true;
            ParentForm.Close();
        }

        private async void EnableButton()
        {
            await Task.Delay(5000);
            if (!IsDisposed)
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() =>
                    {
                        forceCloseButton.Enabled = true;
                    }));
                }
                else
                {
                    forceCloseButton.Enabled = true;
                }
            }
        }
    }
}
