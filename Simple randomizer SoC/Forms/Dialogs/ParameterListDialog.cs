using RandomizerSoC;
using Simple_randomizer_SoC.Enums;
using Simple_randomizer_SoC.Models.AppConfig;
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

namespace Simple_randomizer_SoC.Forms.Dialogs
{
    public partial class ParameterListDialog : Form
    {
        private readonly ListEditComponent listEditComponent = new ListEditComponent();

        public List<FromListParameter> FromListParameters { get; } = new List<FromListParameter>();
        public List<IntRangeParameter> IntRangeParameters { get; } = new List<IntRangeParameter>();
        public List<FloatRangeParameter> FloatRangeParameters { get; } = new List<FloatRangeParameter>();

        public ParameterListDialog(List<FromListParameter> fromListParameters,
            List<IntRangeParameter> intRangeParameters, List<FloatRangeParameter> floatRangeParameters)
        {
            InitializeComponent();

            FromListParameters.AddRange(fromListParameters);
            IntRangeParameters.AddRange(intRangeParameters);
            FloatRangeParameters.AddRange(floatRangeParameters);

            foreach (var p in fromListParameters)
            {
                AddFromListRow(p);
            }

            DialogResult = DialogResult.Cancel;
        }

        private void AddFromListRow(FromListParameter parameter)
        {
            try
            {
                fromListPanel.SuspendLayout();

                var nameControl = new TextBox();
                nameControl.Text = parameter.Name;
                nameControl.Dock = DockStyle.Top;
                nameControl.TextChanged += (s, e) =>
                {
                    parameter.Name = nameControl.Text.Trim();
                };

                var countControl = new NumericUpDown();
                countControl.Value = parameter.ValuesCount;
                countControl.Dock = DockStyle.Top;
                countControl.ValueChanged += (s, e) =>
                {
                    parameter.ValuesCount = (int)countControl.Value;
                };

                var setListButton = new Button();
                setListButton.Text = "Настроить список";
                setListButton.Click += (s, e) =>
                {
                    listEditComponent.HandleSimpleListEdit("Настройка списка элементов параметра " + parameter.Name, parameter.Values);
                };

                var removeButton = new Button();
                removeButton.Text = "Удалить";


                fromListPanel.RowCount++;
                fromListPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                fromListPanel.Controls.Add(nameControl, 0, fromListPanel.RowCount - 1);
                fromListPanel.Controls.Add(countControl, 1, fromListPanel.RowCount - 1);
                fromListPanel.Controls.Add(setListButton, 2, fromListPanel.RowCount - 1);
                fromListPanel.Controls.Add(removeButton, 3, fromListPanel.RowCount - 1);

                removeButton.Click += (s, e) =>
                {
                    fromListPanel.Controls.Remove(nameControl);
                    fromListPanel.Controls.Remove(countControl);
                    fromListPanel.Controls.Remove(setListButton);
                    fromListPanel.Controls.Remove(removeButton);

                    fromListPanel.RowCount--;

                    nameControl.Dispose();
                    countControl.Dispose();
                    setListButton.Dispose();
                    removeButton.Dispose();

                    FromListParameters.Remove(parameter);
                };
            }
            catch (Exception ex)
            {
                new InfoForm("Ошибка", ex).ShowDialog();
            }
            finally
            {
                fromListPanel.ResumeLayout();
            }
        }

        private void AddParameterButtonClick(object sender, EventArgs e)
        {
            var dialog = new AddParameterDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var type = dialog.ParameterType;

                switch (type)
                {
                    case ParameterType.FromList:
                        var parameter = new FromListParameter()
                        {
                            Name = dialog.ParameterName,
                            ParameterType = type,
                            ValuesCount = dialog.ValuesCount,
                        };
                        FromListParameters.Add(parameter);
                        AddFromListRow(parameter);
                        break;
                    case ParameterType.IntRange:
                        break;
                    case ParameterType.FloatRange:
                        break;
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
