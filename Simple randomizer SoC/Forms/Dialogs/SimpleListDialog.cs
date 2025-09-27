using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_randomizer_SoC.Forms.Dialogs
{
    public partial class SimpleListDialog : Form
    {
        public SimpleListDialog(string title, List<string> data)
        {
            InitializeComponent();
            this.Text = title;
            DialogResult = DialogResult.Cancel;

            foreach (var d in data)
            {
                simpleListDataGrid.Rows.Add(d);
            }
        }
        public SimpleListDialog(string title, HashSet<string> data)
        {
            InitializeComponent();
            this.Text = title;
            DialogResult = DialogResult.Cancel;

            foreach (var d in data)
            {
                simpleListDataGrid.Rows.Add(d);
            }
        }

        private void simpleListSaveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void simpleListCancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public List<string> GetData()
        {
            var result = new List<string>();

            var length = simpleListDataGrid.Rows.Count - 1;
            for (int i = 0; i < length; i++)
            {
                result.Add(simpleListDataGrid.Rows[i].Cells[0].Value.ToString().Trim());
            }

            return result;
        }
    }
}
