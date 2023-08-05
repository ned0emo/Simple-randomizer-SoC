using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomizerSoC
{
    public partial class GuideForm : Form
    {
        public GuideForm(string text)
        {
            InitializeComponent();

            guideLabel.Text = text;
            this.Text = "Справка/Help";

            this.Height = guideLabel.Height + 70;
            this.Width = guideLabel.Width + 70;
        }
    }
}
