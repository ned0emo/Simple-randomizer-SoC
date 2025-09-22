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
    public partial class AddParameterDialog : Form
    {
        public string ParameterName { get; private set; } = null;
        public ParameterType ParameterType { get; private set; } = ParameterType.FromList;
        public int ValuesCount { get; private set; } = 0;

        public AddParameterDialog()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;

            typeSelect.DataSource = ParameterTypeDataSource.Get();
            //typeSelect.DisplayMember = "Description";
            //typeSelect.ValueMember = "Value";
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ParameterName))
            {
                MessageBox.Show("Не все поля заполнены", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ParameterName = ParameterName.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            ParameterName = nameTextBox.Text;
        }

        private void typeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParameterType = (ParameterType)typeSelect.SelectedValue;
        }

        private void countInput_ValueChanged(object sender, EventArgs e)
        {
            ValuesCount = (int)countInput.Value;
        }
    }
}
