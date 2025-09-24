using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_randomizer_SoC.Forms.Templates
{
    public class NonScrollNumeric : NumericUpDown
    {
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            var handledEventArgs = e as HandledMouseEventArgs;
            if (handledEventArgs != null)
            {
                handledEventArgs.Handled = true;
            }
        }
    }
}
