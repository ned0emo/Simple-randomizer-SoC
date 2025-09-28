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
    public partial class SimpleListDialog : Form, IListDialog<string>
    {
        public Func<string, bool> RowValidator { get; set; }
        public Action<string> OnValidationError { get; set; }
        public bool Nullable { get; set; } = false;
        public List<string> Data { get; } = new List<string>();
        public ICollection<string> RawData { get; }

        public SimpleListDialog(string title, ICollection<string> data)
        {
            InitializeComponent();
            this.Text = title;
            DialogResult = DialogResult.Cancel;
            RawData = data;

            foreach (var d in data)
            {
                simpleListDataGrid.Rows.Add(d);
            }
        }

        private void simpleListSaveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Data.Clear();

            var length = simpleListDataGrid.Rows.Count - 1;
            for (int i = 0; i < length; i++)
            {
                var str = simpleListDataGrid.Rows[i].Cells[0].Value.ToString().Trim();

                if (RowValidator != null && !RowValidator(str))
                {
                    if (OnValidationError == null) continue;

                    OnValidationError(str);
                    return;
                }

                Data.Add(simpleListDataGrid.Rows[i].Cells[0].Value.ToString().Trim());
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void simpleListCancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
