using Simple_randomizer_SoC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomizerSoC
{
    public partial class InfoForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorTitle"></param>
        /// <param name="errorMessage"></param>
        public InfoForm(string errorTitle, string errorMessage = "")
        {
            InitializeComponent();

            this.Text = Localization.Get("infoFornName");

            label1.Text = errorTitle;

            if(errorMessage.Length > 0)
            {
                textBox1.Visible = true;
                textBox1.Height += 100;
                Height += 100;
                button1.Location = new Point(button1.Location.X, button1.Location.Y + 100);

                textBox1.Text = errorMessage;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
