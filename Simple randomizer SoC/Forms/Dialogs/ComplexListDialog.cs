using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_randomizer_SoC.Forms.Dialogs
{
    public partial class ComplexListDialog<T> : Form, IListDialog<T> where T : class, new()
    {
        private readonly Type _typeInfo;

        public Func<T, bool> RowValidator { get; set; }
        public Action<T> OnValidationError { get; set; }
        public bool Nullable { get; set; } = false;
        public List<T> Data { get; } = new List<T>();
        public ICollection<T> RawData { get; }
        public Func<T, T> DataPreprocessor { get; set; }

        public ComplexListDialog(string title, ICollection<T> data, List<string> columnNames)
        {
            InitializeComponent();
            this.Text = title;
            DialogResult = DialogResult.Cancel;
            RawData = data;

            var table = new DataTable();

            _typeInfo = data.GetType().GetGenericArguments()[0];

            foreach (var f in _typeInfo.GetRuntimeFields())
            {
                var c = table.Columns.Add(f.Name, f.FieldType);
            }

            foreach (var d in data)
            {
                var row = table.NewRow();

                int i = 0;
                foreach (var f in _typeInfo.GetRuntimeFields())
                {
                    row[i++] = f.GetValue(d);
                }

                table.Rows.Add(row);
            }

            var colCount = table.Columns.Count;
            if (colCount > 2)
            {
                if (colCount >= 5)
                {
                    Width = 800;
                }
                else
                {
                    Width = colCount * 160;
                }
            }

            dataGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            dataGrid.DataSource = table;
            dataGrid.AutoGenerateColumns = true;
            for (int i = 0; i < columnNames.Count; i++)
            {
                dataGrid.Columns[i].HeaderText = columnNames[i];
            }

            foreach (DataGridViewColumn c in dataGrid.Columns)
            {
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Data.Clear();
            var length = dataGrid.Rows.Count - 1;
            for (int i = 0; i < length; i++)
            {
                var t = new T();
                bool skip = false;

                foreach (var f in _typeInfo.GetRuntimeFields())
                {
                    var cellValue = dataGrid.Rows[i].Cells[f.Name].Value;

                    if (cellValue is DBNull)
                    {
                        if (Nullable)
                        {
                            f.SetValue(t, null);
                        }
                        else
                        {
                            skip = true;
                            break;
                        }
                    }

                    if (f.FieldType == typeof(int))
                    {
                        f.SetValue(t, (int)cellValue);
                    }
                    else if (f.FieldType == typeof(float))
                    {
                        f.SetValue(t, (float)cellValue);
                    }
                    else if (f.FieldType == typeof(double))
                    {
                        f.SetValue(t, (double)cellValue);
                    }
                    else if (f.FieldType == typeof(bool))
                    {
                        f.SetValue(t, (bool)cellValue);
                    }
                    else
                    {
                        f.SetValue(t, cellValue.ToString().Trim());
                    }
                }

                if (skip) continue;

                if (DataPreprocessor != null) t = DataPreprocessor(t);

                if (RowValidator != null && !RowValidator(t))
                {
                    if (OnValidationError == null) continue;

                    OnValidationError(t);
                    return;
                }

                Data.Add(t);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void dataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is FormatException)
            {
                MessageBox.Show("Строка имеет неверный формат", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
