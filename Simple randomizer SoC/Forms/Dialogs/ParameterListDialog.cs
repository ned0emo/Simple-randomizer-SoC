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

        public ParameterContainer ParameterContainer { get; } = new ParameterContainer();

        public ParameterListDialog(string title, ParameterContainer parameterContainer)
        {
            InitializeComponent();
            Text = title;

            foreach (var p in parameterContainer.FromListParameters)
            {
                AddFromListRow(p);
            }

            foreach (var p in parameterContainer.IntRangeParameters)
            {
                AddIntRangeRow(p);
            }

            foreach (var p in parameterContainer.FloatRangeParameters)
            {
                AddFloatRangeRow(p);
            }

            foreach (var p in parameterContainer.ShuffleParameters)
            {
                AddShuffleParameter(p);
            }

            foreach (var p in parameterContainer.CopyParameters)
            {
                AddCopyParameter(p);
            }

            foreach (var p in parameterContainer.CustomListParameters)
            {
                AddCustomListParameter(p);
            }

            DialogResult = DialogResult.Cancel;
        }

        private void AddFromListRow(FromListParameter parameter)
        {
            try
            {
                fromListPanel.SuspendLayout();
                ParameterContainer.FromListParameters.Add(parameter);

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
                    listEditComponent.OpenEdit<SimpleListDialog, string>(new SimpleListDialog("Настройка списка элементов параметра " + parameter.Name, parameter.Values));
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

                    ParameterContainer.FromListParameters.Remove(parameter);
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
                ParameterContainer.IntRangeParameters.Add(parameter);

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

                    ParameterContainer.IntRangeParameters.Remove(parameter);
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
                ParameterContainer.FloatRangeParameters.Add(parameter);

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
                    parameter.MinValue = (double)minInput.Value;
                };

                var maxInput = new NonScrollNumeric();
                maxInput.Maximum = 1000000;
                maxInput.Minimum = -1000000;
                maxInput.DecimalPlaces = 5;
                maxInput.Increment = 0.1m;
                maxInput.Value = (decimal)parameter.MaxValue;
                maxInput.ValueChanged += (s, e) =>
                {
                    parameter.MaxValue = (double)maxInput.Value;
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

                    ParameterContainer.FloatRangeParameters.Remove(parameter);
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

        private void AddCustomListParameter(CustomListParameter parameter)
        {
            try
            {
                customListPanel.SuspendLayout();
                ParameterContainer.CustomListParameters.Add(parameter);

                var nameControl = new TextBox();
                nameControl.Text = parameter.Name;
                nameControl.Dock = DockStyle.Top;
                nameControl.TextChanged += (s, e) =>
                {
                    parameter.Name = nameControl.Text.Trim();
                };

                var editButton = new Button();
                editButton.Text = "Редактировать";
                editButton.AutoSize = true;
                editButton.Click += (s, e) =>
                {
                    var dialog = new OrderableParameterListDialog("Редкатирование параметра " + parameter.Name, parameter.ParameterContainer);
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        parameter.ParameterContainer.Update(dialog.ParameterContainer);
                    }
                };

                var removeButton = new Button();
                removeButton.Text = "Удалить";

                var rc = customListPanel.RowCount;
                var rs = new RowStyle();

                customListPanel.RowCount++;
                customListPanel.RowStyles.Add(rs);

                customListPanel.Controls.Add(nameControl, 0, rc);
                customListPanel.Controls.Add(editButton, 1, rc);
                customListPanel.Controls.Add(removeButton, 2, rc);

                removeButton.Click += (s, e) =>
                {
                    customListPanel.Controls.Remove(nameControl);
                    customListPanel.Controls.Remove(editButton);
                    customListPanel.Controls.Remove(removeButton);

                    customListPanel.RowCount--;
                    customListPanel.RowStyles.Remove(rs);

                    editButton.Dispose();
                    nameControl.Dispose();
                    removeButton.Dispose();

                    ParameterContainer.CustomListParameters.Remove(parameter);
                };
            }
            catch (Exception ex)
            {
                new InfoForm("Ошибка", ex).ShowDialog();
            }
            finally
            {
                customListPanel.ResumeLayout();
            }
        }

        private void AddShuffleParameter(ShuffleParameter parameter)
        {
            try
            {
                shufflePanel.SuspendLayout();
                ParameterContainer.ShuffleParameters.Add(parameter);

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

                    ParameterContainer.ShuffleParameters.Remove(parameter);
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
                ParameterContainer.CopyParameters.Add(parameter);

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

                    ParameterContainer.CopyParameters.Remove(parameter);
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
                        var flp = new FromListParameter()
                        {
                            Name = dialog.ParameterName,
                            ParameterType = type,
                            ValuesCount = dialog.ValuesCount,
                        };
                        AddFromListRow(flp);
                        break;
                    case ParameterType.IntRange:
                        var irp = new IntRangeParameter()
                        {
                            Name = dialog.ParameterName,
                            ParameterType = type,
                            ValuesCount = dialog.ValuesCount,
                        };
                        AddIntRangeRow(irp);
                        break;
                    case ParameterType.FloatRange:
                        var frp = new FloatRangeParameter()
                        {
                            Name = dialog.ParameterName,
                            ParameterType = type,
                            ValuesCount = dialog.ValuesCount,
                        };
                        AddFloatRangeRow(frp);
                        break;
                    case ParameterType.CustomList:
                        var clp = new CustomListParameter()
                        {
                            Name = dialog.ParameterName,
                            ParameterType = type
                        };
                        AddCustomListParameter(clp);
                        break;
                    case ParameterType.Shuffle:
                        var sp = new ShuffleParameter()
                        {
                            Name = dialog.ParameterName,
                            ParameterType = type
                        };
                        AddShuffleParameter(sp);
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
            if (ParameterContainer.IntRangeParameters.Any(p => !p.Validate()))
            {
                MessageBox.Show("Не все поля целочисленных параметров заполнены корректно", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ParameterContainer.FloatRangeParameters.Any(p => !p.Validate()))
            {
                MessageBox.Show("Не все поля параметров с плавающей точкой заполнены корректно", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ParameterContainer.FromListParameters.Any(p => !p.Validate()))
            {
                MessageBox.Show("Не все поля параметров, выбираемых из списка, заполнены корректно", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ParameterContainer.ShuffleParameters.Any(s => !s.Validate()))
            {
                MessageBox.Show("Не все поля параметров для перемешивания заполнены корректно", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ParameterContainer.CopyParameters.Any(s => !s.Validate()))
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
