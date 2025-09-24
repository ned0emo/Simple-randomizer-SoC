using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_randomizer_SoC.Forms.Templates
{
    public class NumberTextBox : MaskedTextBox
    {
        public NumberTextBox() {
            this.Mask = "00000.00000";
            this.Validating += DecimalTextBox_Validating;
        }

        public float Value
        {
            get
            {
                return float.TryParse(Text, out float result) ? result : 0;
            }
            set
            {
                this.Text = value.ToString("0.00000");
            }
        }

        private void DecimalTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Text) && !float.TryParse(this.Text, out _))
            {
                MessageBox.Show("Введите корректное дробное число");
                e.Cancel = true;
            }
        }
    }
}
