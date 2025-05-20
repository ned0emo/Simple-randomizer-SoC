using Simple_randomizer_SoC;
using Simple_randomizer_SoC.Tools;
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

            if (errorMessage.Length > 0)
            {
                textBox1.Visible = true;
                textBox1.Height += 150;
                Height += 150;
                button1.Location = new Point(button1.Location.X, button1.Location.Y + 100);

                textBox1.Text = errorMessage;
            }
        }

        public InfoForm(string errorTitle, Exception ex)
        {
            InitializeComponent();

            this.Text = Localization.Get("infoFornName");

            label1.Text = errorTitle;

            textBox1.Visible = true;
            textBox1.Height += 150;
            Height += 150;
            button1.Location = new Point(button1.Location.X, button1.Location.Y + 100);

            if (ex is CustomException)
            {
                textBox1.Text = ex.Message;
            }
            else
            {
                textBox1.Text = ex.Message + "\r\n" +
                    ex.InnerException?.Message + "\r\n" +
                    ex.StackTrace;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
