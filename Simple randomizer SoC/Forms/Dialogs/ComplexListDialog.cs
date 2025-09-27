using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_randomizer_SoC.Forms.Dialogs
{
    public partial class ComplexListDialog<T> : Form where T : class, new()
    {
        private readonly Type _typeInfo;
        private readonly bool _nullable;
        private readonly Func<T, bool> _rowValidator;

        public ComplexListDialog(string title, List<T> data, List<string> columnNames, bool nullable = false, Func<T, bool> rowValidator = null)
        {
            InitializeComponent();
            this.Text = title;
            DialogResult = DialogResult.Cancel;

            var table = new DataTable();

            _typeInfo = data.GetType().GetGenericArguments()[0];
            _nullable = nullable;
            _rowValidator = rowValidator;

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
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public List<T> GetData()
        {
            var result = new List<T>();

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
                        if (_nullable)
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
                if (_rowValidator != null && !_rowValidator(t)) continue;

                result.Add(t);
            }

            return result;
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
