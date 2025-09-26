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
    public partial class OrderableParameterListDialog : Form
    {
        private readonly DataListEditor listEditComponent = Singleton<DataListEditor>.Instance;
        private readonly Dictionary<int, OrderableParameterBase> parameterByOrder = new Dictionary<int, OrderableParameterBase>();
        private readonly Dictionary<OrderableParameterBase, NonScrollNumeric> orderInputByParameter = new Dictionary<OrderableParameterBase, NonScrollNumeric>();

        public ParameterOrderableContainer ParameterContainer { get; } = new ParameterOrderableContainer();

        public OrderableParameterListDialog(string title, ParameterOrderableContainer parameterContainer)
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

            //parameterContainer.ForEachParameter((p) => parameterByOrder.Add(p.Order, p));

            DialogResult = DialogResult.Cancel;
        }

        private void AddFromListRow(OrderableFromListParameter parameter)
        {
            try
            {
                fromListPanel.SuspendLayout();

                ParameterContainer.FromListParameters.Add(parameter);

                var orderControl = new NonScrollNumeric();
                orderControl.Value = parameter.Order;
                orderControl.Dock = DockStyle.Top;
                orderControl.ValueChanged += (s, e) =>
                {
                    OrderInputHandler(parameter, (int)orderControl.Value);
                };

                parameterByOrder[parameter.Order] = parameter;
                orderInputByParameter[parameter] = orderControl;

                var setListButton = new Button();
                setListButton.Text = "Настроить список";
                setListButton.Click += (s, e) =>
                {
                    listEditComponent.SimpleListEdit("Настройка списка элементов", parameter.Values);
                };

                var removeButton = new Button();
                removeButton.Text = "Удалить";

                var rc = fromListPanel.RowCount;
                var rs = new RowStyle();

                fromListPanel.RowCount++;
                fromListPanel.RowStyles.Add(rs);

                fromListPanel.Controls.Add(setListButton, 0, rc);
                fromListPanel.Controls.Add(orderControl, 1, rc);
                fromListPanel.Controls.Add(removeButton, 2, rc);

                removeButton.Click += (s, e) =>
                {
                    fromListPanel.Controls.Remove(orderControl);
                    fromListPanel.Controls.Remove(setListButton);
                    fromListPanel.Controls.Remove(removeButton);

                    fromListPanel.RowCount--;
                    fromListPanel.RowStyles.Remove(rs);

                    orderControl.Dispose();
                    setListButton.Dispose();
                    removeButton.Dispose();

                    ParameterContainer.FromListParameters.Remove(parameter);
                    var orders = parameterByOrder.Where(pbo => pbo.Value == parameter).Select(kvp => kvp.Key).ToList();
                    if (orders.Count > 0)
                    {
                        parameterByOrder.Remove(orders[0]);
                    }
                    orderInputByParameter.Remove(parameter);
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

        private void AddIntRangeRow(OrderableIntRangeParameter parameter)
        {
            try
            {
                intRangePanel.SuspendLayout();
                ParameterContainer.IntRangeParameters.Add(parameter);

                var orderControl = new NonScrollNumeric();
                orderControl.Value = parameter.Order;
                orderControl.Dock = DockStyle.Top;
                orderControl.ValueChanged += (s, e) =>
                {
                    OrderInputHandler(parameter, (int)orderControl.Value);
                };

                parameterByOrder[parameter.Order] = parameter;
                orderInputByParameter[parameter] = orderControl;

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

                intRangePanel.Controls.Add(minInput, 0, rc);
                intRangePanel.Controls.Add(maxInput, 1, rc);
                intRangePanel.Controls.Add(orderControl, 2, rc);
                intRangePanel.Controls.Add(removeButton, 3, rc);

                removeButton.Click += (s, e) =>
                {
                    intRangePanel.Controls.Remove(orderControl);
                    intRangePanel.Controls.Remove(minInput);
                    intRangePanel.Controls.Remove(maxInput);
                    intRangePanel.Controls.Remove(removeButton);

                    intRangePanel.RowCount--;
                    intRangePanel.RowStyles.Remove(rs);

                    orderControl.Dispose();
                    minInput.Dispose();
                    maxInput.Dispose();
                    removeButton.Dispose();

                    ParameterContainer.IntRangeParameters.Remove(parameter);
                    var orders = parameterByOrder.Where(pbo => pbo.Value == parameter).Select(kvp => kvp.Key).ToList();
                    if (orders.Count > 0)
                    {
                        parameterByOrder.Remove(orders[0]);
                    }
                    orderInputByParameter.Remove(parameter);
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

        private void AddFloatRangeRow(OrderableFloatRangeParameter parameter)
        {
            try
            {
                floatRangePanel.SuspendLayout();
                ParameterContainer.FloatRangeParameters.Add(parameter);

                var orderControl = new NonScrollNumeric();
                orderControl.Value = parameter.Order;
                orderControl.Dock = DockStyle.Top;
                orderControl.ValueChanged += (s, e) =>
                {
                    OrderInputHandler(parameter, (int)orderControl.Value);
                };

                parameterByOrder[parameter.Order] = parameter;
                orderInputByParameter[parameter] = orderControl;

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

                floatRangePanel.Controls.Add(minInput, 0, rc);
                floatRangePanel.Controls.Add(maxInput, 1, rc);
                floatRangePanel.Controls.Add(precisionInput, 2, rc);
                floatRangePanel.Controls.Add(orderControl, 3, rc);
                floatRangePanel.Controls.Add(removeButton, 4, rc);

                removeButton.Click += (s, e) =>
                {
                    floatRangePanel.Controls.Remove(orderControl);
                    floatRangePanel.Controls.Remove(minInput);
                    floatRangePanel.Controls.Remove(maxInput);
                    floatRangePanel.Controls.Remove(precisionInput);
                    floatRangePanel.Controls.Remove(removeButton);

                    floatRangePanel.RowCount--;
                    floatRangePanel.RowStyles.Remove(rs);

                    orderControl.Dispose();
                    minInput.Dispose();
                    maxInput.Dispose();
                    removeButton.Dispose();
                    precisionInput.Dispose();

                    ParameterContainer.FloatRangeParameters.Remove(parameter);
                    var orders = parameterByOrder.Where(pbo => pbo.Value == parameter).Select(kvp => kvp.Key).ToList();
                    if (orders.Count > 0)
                    {
                        parameterByOrder.Remove(orders[0]);
                    }
                    orderInputByParameter.Remove(parameter);
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

        private void AddParameterButtonClick(object sender, EventArgs e)
        {
            var dialog = new AddOrderableParameterDialog(parameterByOrder.Keys.ToHashSet());
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var type = dialog.ParameterType;

                switch (type)
                {
                    case ParameterType.FromList:
                        var parameter = new OrderableFromListParameter()
                        {
                            ParameterType = type,
                            Order = dialog.Order,
                        };
                        AddFromListRow(parameter);
                        //parameterByOrder.Add(dialog.Order, parameter);
                        break;
                    case ParameterType.IntRange:
                        var parameter2 = new OrderableIntRangeParameter()
                        {
                            ParameterType = type,
                            Order = dialog.Order,
                        };
                        AddIntRangeRow(parameter2);
                        //parameterByOrder.Add(dialog.Order, parameter2);
                        break;
                    case ParameterType.FloatRange:
                        var parameter3 = new OrderableFloatRangeParameter()
                        {
                            ParameterType = type,
                            Order = dialog.Order,
                        };
                        AddFloatRangeRow(parameter3);
                        //parameterByOrder.Add(dialog.Order, parameter3);
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

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OrderInputHandler(OrderableParameterBase parameter, int newOrder)
        {
            var oldOrder = parameter.Order;
            //если порядок не изменился, то выходим
            if (oldOrder == newOrder) return;

            lock (parameterByOrder)
            {
                //если при изменении порядка новое значение уже есть в словаре других порядков
                if (parameterByOrder.ContainsKey(newOrder))
                {
                    //получаем значение параметра по новому порядку
                    var otherParam = parameterByOrder[newOrder];
                    //если это зхначение не того же параметра
                    if (parameter != otherParam)
                    {
                        //меняем их местами
                        parameterByOrder[oldOrder] = otherParam;
                        parameterByOrder[newOrder] = parameter;

                        orderInputByParameter[otherParam].Value = oldOrder;
                    }
                }
                //в ином случае удаляем запись по старому порядку и вписываем параметр в новый порядок
                else
                {
                    parameterByOrder.Remove(oldOrder);
                    parameterByOrder[newOrder] = parameter;
                }
            }

            parameter.Order = newOrder;
        }
    }
}
