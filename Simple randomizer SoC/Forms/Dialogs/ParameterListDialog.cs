using RandomizerSoC;
using Simple_randomizer_SoC.Enums;
using Simple_randomizer_SoC.Forms.Templates;
using Simple_randomizer_SoC.Models.AppConfig;
using Simple_randomizer_SoC.Models.Parameters;
using Simple_randomizer_SoC.Tools;
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
        private readonly DataListEditor listEditComponent = Singleton<DataListEditor>.Instance;

        public List<FromListParameter> FromListParameters { get; } = new List<FromListParameter>();
        public List<IntRangeParameter> IntRangeParameters { get; } = new List<IntRangeParameter>();
        public List<FloatRangeParameter> FloatRangeParameters { get; } = new List<FloatRangeParameter>();
        public List<ShuffleParameter> ShuffleParameters { get; } = new List<ShuffleParameter>();
        public List<CopyParameter> CopyParameters { get; } = new List<CopyParameter>();

        public ParameterListDialog(List<FromListParameter> fromListParameters,
            List<IntRangeParameter> intRangeParameters, List<FloatRangeParameter> floatRangeParameters,
            List<ShuffleParameter> shuffleParameters, List<CopyParameter> copyParameters)
        {
            InitializeComponent();

            foreach (var p in fromListParameters)
            {
                AddFromListRow(p);
            }

            foreach (var p in intRangeParameters)
            {
                AddIntRangeRow(p);
            }

            foreach (var p in floatRangeParameters)
            {
                AddFloatRangeRow(p);
            }

            foreach (var p in shuffleParameters)
            {
                AddShuffleParameter(p);
            }

            foreach (var p in copyParameters)
            {
                AddCopyParameter(p);
            }

            DialogResult = DialogResult.Cancel;
        }

        private void AddFromListRow(FromListParameter parameter)
        {
            try
            {
                fromListPanel.SuspendLayout();
                FromListParameters.Add(parameter);

                var nameControl = new TextBox();
                nameControl.Text = parameter.Name;
                nameControl.Dock = DockStyle.Top;
                nameControl.TextChanged += (s, e) =>
                {
                    parameter.Name = nameControl.Text.Trim();
                };

                var countControl = new NonScrollNumeric();
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
                    listEditComponent.SimpleListEdit("Настройка списка элементов параметра " + parameter.Name, parameter.Values);
                };

                var removeButton = new Button();
                removeButton.Text = "Удалить";

                var rc = fromListPanel.RowCount;
                var rs = new RowStyle();

                fromListPanel.RowCount++;
                fromListPanel.RowStyles.Add(rs);

                fromListPanel.Controls.Add(nameControl, 0, rc);
                fromListPanel.Controls.Add(countControl, 1, rc);
                fromListPanel.Controls.Add(setListButton, 2, rc);
                fromListPanel.Controls.Add(removeButton, 3, rc);

                removeButton.Click += (s, e) =>
                {
                    fromListPanel.Controls.Remove(nameControl);
                    fromListPanel.Controls.Remove(countControl);
                    fromListPanel.Controls.Remove(setListButton);
                    fromListPanel.Controls.Remove(removeButton);

                    fromListPanel.RowCount--;
                    fromListPanel.RowStyles.Remove(rs);

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

        private void AddIntRangeRow(IntRangeParameter parameter)
        {
            try
            {
                intRangePanel.SuspendLayout();
                IntRangeParameters.Add(parameter);

                var nameControl = new TextBox();
                nameControl.Text = parameter.Name;
                nameControl.Dock = DockStyle.Top;
                nameControl.TextChanged += (s, e) =>
                {
                    parameter.Name = nameControl.Text.Trim();
                };

                var countControl = new NonScrollNumeric();
                countControl.Value = parameter.ValuesCount;
                countControl.Dock = DockStyle.Top;
                countControl.ValueChanged += (s, e) =>
                {
                    parameter.ValuesCount = (int)countControl.Value;
                };

                var minInput = new NonScrollNumeric();
                minInput.Maximum = 1000000000;
                minInput.Minimum = -1000000000;
                minInput.Value = parameter.MinValue;
                minInput.ValueChanged += (s, e) =>
                {
                    parameter.MinValue = (int)minInput.Value;
                };

                var maxInput = new NonScrollNumeric();
                maxInput.Maximum = 1000000000;
                maxInput.Minimum = -1000000000;
                maxInput.Value = parameter.MaxValue;
                maxInput.ValueChanged += (s, e) =>
                {
                    parameter.MaxValue = (int)maxInput.Value;
                };

                var removeButton = new Button();
                removeButton.Text = "Удалить";

                var rc = intRangePanel.RowCount;
                var rs = new RowStyle();

                intRangePanel.RowCount++;
                intRangePanel.RowStyles.Add(rs);

                intRangePanel.Controls.Add(nameControl, 0, rc);
                intRangePanel.Controls.Add(countControl, 1, rc);
                intRangePanel.Controls.Add(minInput, 2, rc);
                intRangePanel.Controls.Add(maxInput, 3, rc);
                intRangePanel.Controls.Add(removeButton, 4, rc);

                removeButton.Click += (s, e) =>
                {
                    intRangePanel.Controls.Remove(nameControl);
                    intRangePanel.Controls.Remove(countControl);
                    intRangePanel.Controls.Remove(minInput);
                    intRangePanel.Controls.Remove(maxInput);
                    intRangePanel.Controls.Remove(removeButton);

                    intRangePanel.RowCount--;
                    intRangePanel.RowStyles.Remove(rs);

                    nameControl.Dispose();
                    countControl.Dispose();
                    minInput.Dispose();
                    maxInput.Dispose();
                    removeButton.Dispose();

                    IntRangeParameters.Remove(parameter);
                };
            }
            catch (Exception ex)
            {
                new InfoForm("Ошибка", ex).ShowDialog();
            }
            finally
            {
                intRangePanel.ResumeLayout();
            }
        }

        private void AddFloatRangeRow(FloatRangeParameter parameter)
        {
            try
            {
                floatRangePanel.SuspendLayout();
                FloatRangeParameters.Add(parameter);

                var nameControl = new TextBox();
                nameControl.Text = parameter.Name;
                nameControl.Dock = DockStyle.Top;
                nameControl.TextChanged += (s, e) =>
                {
                    parameter.Name = nameControl.Text.Trim();
                };

                var countControl = new NonScrollNumeric();
                countControl.Value = parameter.ValuesCount;
                countControl.Dock = DockStyle.Top;
                countControl.ValueChanged += (s, e) =>
                {
                    parameter.ValuesCount = (int)countControl.Value;
                };

                var minInput = new NonScrollNumeric();
                minInput.Maximum = 1000000;
                minInput.Minimum = -1000000;
                minInput.DecimalPlaces = 5;
                minInput.Increment = 0.1m;
                minInput.Value = (decimal)parameter.MinValue;
                minInput.ValueChanged += (s, e) =>
                {
                    parameter.MinValue = (float)minInput.Value;
                };

                var maxInput = new NonScrollNumeric();
                maxInput.Maximum = 1000000;
                maxInput.Minimum = -1000000;
                maxInput.DecimalPlaces = 5;
                maxInput.Increment = 0.1m;
                maxInput.Value = (decimal)parameter.MaxValue;
                maxInput.ValueChanged += (s, e) =>
                {
                    parameter.MaxValue = (float)maxInput.Value;
                };

                var precisionInput = new NonScrollNumeric();
                precisionInput.Maximum = 5;
                precisionInput.Minimum = 1;
                precisionInput.Value = parameter.Precision;
                precisionInput.Dock = DockStyle.Top;
                precisionInput.AutoSize = true;
                precisionInput.ValueChanged += (s, e) =>
                {
                    parameter.Precision = (int)precisionInput.Value;
                };

                var removeButton = new Button();
                removeButton.Text = "Удалить";

                var rc = floatRangePanel.RowCount;
                var rs = new RowStyle();

                floatRangePanel.RowCount++;
                floatRangePanel.RowStyles.Add(rs);

                floatRangePanel.Controls.Add(nameControl, 0, rc);
                floatRangePanel.Controls.Add(countControl, 1, rc);
                floatRangePanel.Controls.Add(minInput, 2, rc);
                floatRangePanel.Controls.Add(maxInput, 3, rc);
                floatRangePanel.Controls.Add(precisionInput, 4, rc);
                floatRangePanel.Controls.Add(removeButton, 5, rc);

                removeButton.Click += (s, e) =>
                {
                    floatRangePanel.Controls.Remove(nameControl);
                    floatRangePanel.Controls.Remove(countControl);
                    floatRangePanel.Controls.Remove(minInput);
                    floatRangePanel.Controls.Remove(maxInput);
                    floatRangePanel.Controls.Remove(precisionInput);
                    floatRangePanel.Controls.Remove(removeButton);

                    floatRangePanel.RowCount--;
                    floatRangePanel.RowStyles.Remove(rs);

                    nameControl.Dispose();
                    countControl.Dispose();
                    minInput.Dispose();
                    maxInput.Dispose();
                    removeButton.Dispose();
                    precisionInput.Dispose();

                    FloatRangeParameters.Remove(parameter);
                };
            }
            catch (Exception ex)
            {
                new InfoForm("Ошибка", ex).ShowDialog();
            }
            finally
            {
                floatRangePanel.ResumeLayout();
            }
        }

        private void AddShuffleParameter(ShuffleParameter parameter)
        {
            try
            {
                shufflePanel.SuspendLayout();
                ShuffleParameters.Add(parameter);

                var nameControl = new TextBox();
                nameControl.Text = parameter.Name;
                nameControl.Dock = DockStyle.Top;
                nameControl.TextChanged += (s, e) =>
                {
                    parameter.Name = nameControl.Text.Trim();
                };

                var removeButton = new Button();
                removeButton.Text = "Удалить";

                var rc = shufflePanel.RowCount;
                var rs = new RowStyle();

                shufflePanel.RowCount++;
                shufflePanel.RowStyles.Add(rs);

                shufflePanel.Controls.Add(nameControl, 0, rc);
                shufflePanel.Controls.Add(removeButton, 1, rc);

                removeButton.Click += (s, e) =>
                {
                    shufflePanel.Controls.Remove(nameControl);
                    shufflePanel.Controls.Remove(removeButton);

                    shufflePanel.RowCount--;
                    shufflePanel.RowStyles.Remove(rs);

                    nameControl.Dispose();
                    removeButton.Dispose();

                    ShuffleParameters.Remove(parameter);
                };
            }
            catch (Exception ex)
            {
                new InfoForm("Ошибка", ex).ShowDialog();
            }
            finally
            {
                shufflePanel.ResumeLayout();
            }
        }

        private void AddCopyParameter(CopyParameter parameter)
        {
            try
            {
                copyPanel.SuspendLayout();
                CopyParameters.Add(parameter);

                var nameControl = new TextBox();
                nameControl.Text = parameter.Name;
                nameControl.Dock = DockStyle.Top;
                nameControl.TextChanged += (s, e) =>
                {
                    parameter.Name = nameControl.Text.Trim();
                };

                var copyNameControl = new TextBox();
                copyNameControl.Text = parameter.CopyFrom;
                copyNameControl.Dock = DockStyle.Top;
                copyNameControl.TextChanged += (s, e) =>
                {
                    parameter.CopyFrom = copyNameControl.Text.Trim();
                };

                var removeButton = new Button();
                removeButton.Text = "Удалить";

                var rc = copyPanel.RowCount;
                var rs = new RowStyle();

                copyPanel.RowCount++;
                copyPanel.RowStyles.Add(rs);

                copyPanel.Controls.Add(nameControl, 0, rc);
                copyPanel.Controls.Add(copyNameControl, 1, rc);
                copyPanel.Controls.Add(removeButton, 2, rc);

                removeButton.Click += (s, e) =>
                {
                    copyPanel.Controls.Remove(nameControl);
                    copyPanel.Controls.Remove(copyNameControl);
                    copyPanel.Controls.Remove(removeButton);

                    copyPanel.RowCount--;
                    copyPanel.RowStyles.Remove(rs);

                    nameControl.Dispose();
                    copyNameControl.Dispose();
                    removeButton.Dispose();

                    CopyParameters.Remove(parameter);
                };
            }
            catch (Exception ex)
            {
                new InfoForm("Ошибка", ex).ShowDialog();
            }
            finally
            {
                copyPanel.ResumeLayout();
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
                        AddFromListRow(parameter);
                        break;
                    case ParameterType.IntRange:
                        var parameter2 = new IntRangeParameter()
                        {
                            Name = dialog.ParameterName,
                            ParameterType = type,
                            ValuesCount = dialog.ValuesCount,
                        };
                        AddIntRangeRow(parameter2);
                        break;
                    case ParameterType.FloatRange:
                        var parameter3 = new FloatRangeParameter()
                        {
                            Name = dialog.ParameterName,
                            ParameterType = type,
                            ValuesCount = dialog.ValuesCount,
                        };
                        AddFloatRangeRow(parameter3);
                        break;
                    case ParameterType.Shuffle:
                        var p = new ShuffleParameter()
                        {
                            Name = dialog.ParameterName,
                            ParameterType = type
                        };
                        AddShuffleParameter(p);
                        break;
                    case ParameterType.Copy:
                        var cp = new CopyParameter()
                        {
                            Name = dialog.ParameterName,
                            ParameterType = type
                        };
                        AddCopyParameter(cp);
                        break;
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (IntRangeParameters.Any(p => !p.Validate()))
            {
                MessageBox.Show("Не все поля целочисленных параметров заполнены корректно", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (FloatRangeParameters.Any(p => !p.Validate()))
            {
                MessageBox.Show("Не все поля параметров с плавающей точкой заполнены корректно", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (FromListParameters.Any(p => !p.Validate()))
            {
                MessageBox.Show("Не все поля параметров, выбираемых из списка, заполнены корректно", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ShuffleParameters.Any(s => !s.Validate()))
            {
                MessageBox.Show("Не все поля параметров для перемешивания заполнены корректно", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CopyParameters.Any(s => !s.Validate()))
            {
                MessageBox.Show("Не все поля параметров для копирования заполнены корректно", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
