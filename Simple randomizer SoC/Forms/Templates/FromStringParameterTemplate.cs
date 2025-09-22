using Simple_randomizer_SoC.Models.Parameters;
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
    public partial class FromListParameterTemplate : UserControl
    {
        private readonly FromListParameter fromListParameter;
        private readonly ListEditComponent listEditComponent = new ListEditComponent();

        public FromListParameterTemplate(FromListParameter fromListParameter)
        {
            InitializeComponent();

            this.fromListParameter = fromListParameter;
        }
    }
}
