using Simple_randomizer_SoC.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_randomizer_SoC.Forms.Dialogs
{
    public partial class AddOrderableParameterDialog : Form
    {
        private readonly HashSet<int> existingOrders;

        public ParameterType ParameterType { get; private set; } = ParameterType.FromList;
        public int Order { get; private set; } = 0;

        public AddOrderableParameterDialog(HashSet<int> existingOrders)
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;

            typeSelect.DataSource = ParameterTypeDataSource.GetLess();

            this.existingOrders = existingOrders;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (existingOrders.Contains(Order))
            {
                MessageBox.Show("Указанный номер по порядку уже существует", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        
        private void typeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParameterType = (ParameterType)typeSelect.SelectedValue;
        }

        private void countInput_ValueChanged(object sender, EventArgs e)
        {
            Order = (int)orderInput.Value;
        }
    }
}
