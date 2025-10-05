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
            if (e is HandledMouseEventArgs handledEventArgs)
            {
                handledEventArgs.Handled = true;
            }
        }

        public static MouseEventHandler NonScrollEvent = (s, e) =>
        {
            if (e is HandledMouseEventArgs handledEventArgs)
            {
                handledEventArgs.Handled = true;
            }
        };
    }
}
