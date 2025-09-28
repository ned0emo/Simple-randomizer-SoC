using Simple_randomizer_SoC.Models.AppConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_randomizer_SoC.Forms.Tabs
{
    public partial class SoundTextureTab : UserControl
    {
        private readonly SoundTextureConfig _config;

        public SoundTextureTab(SoundTextureConfig config)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            _config = config;
        }
    }
}
