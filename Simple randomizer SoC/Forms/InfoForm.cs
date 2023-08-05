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
        public InfoForm(ResourceManager rm, string rmInfoId = "", string errMessage = "", string postfix = "")
        {
            InitializeComponent();
            string infoMessage;

            try
            {
                this.Text = rm.GetString("infoFornName");
                infoMessage = rm.GetString(rmInfoId);
            }
            catch
            {
                this.Text = "Внимание/Warning";
                infoMessage = "Ошибка/Error";
            }

            if (rmInfoId.Length < 1) infoMessage = "";

            label1.Text = infoMessage + $" {postfix}";
            if(errMessage.Length > 0)
            {
                textBox1.Visible = true;
                textBox1.Height += 100;
                Height += 100;
                button1.Location = new Point(button1.Location.X, button1.Location.Y + 100);

                textBox1.Text = errMessage;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
