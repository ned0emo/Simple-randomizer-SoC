using RandomizerSoC;
using Simple_randomizer_SoC.Forms.Dialogs;
using Simple_randomizer_SoC.Models.AppConfig;
using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_randomizer_SoC.Forms
{
    public class DataListEditor
    {
        public void SimpleListEdit(string dialogName, List<string> list)
        {
            try
            {
                var dialog = new SimpleListDialog(dialogName, list);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    list.Clear();
                    list.AddRange(dialog.GetData());
                }
            }
            catch (Exception ex)
            {
                new InfoForm("Ошибка", ex).ShowDialog();
            }
        }

        public async Task SimpleListEditAndSave(string dialogName, List<string> list, IConfig config)
        {
            try
            {
                var dialog = new SimpleListDialog(dialogName, list);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    list.Clear();
                    list.AddRange(dialog.GetData());
                    await ConfigHandler.Save(config);
                }
            }
            catch (Exception ex)
            {
                new InfoForm("Ошибка", ex).ShowDialog();
            }
        }

        public async void ComplexListEdit<T>(string dialogName, List<T> list, List<string> columnNames) where T : class, new()
        {
            try
            {
                var dialog = new ComplexListDialog<T>(dialogName, list, columnNames);
                await Task.Yield();

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    list.Clear();
                    list.AddRange(dialog.GetData());
                }
            }
            catch (Exception ex)
            {
                new InfoForm("Ошибка", ex).ShowDialog();
            }
        }

        public async Task ComplexListEditAndSave<T>(string dialogName, List<T> list, List<string> columnNames, IConfig config) where T : class, new()
        {
            try
            {
                var dialog = new ComplexListDialog<T>(dialogName, list, columnNames);
                await Task.Yield();

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    list.Clear();
                    list.AddRange(dialog.GetData());
                    await ConfigHandler.Save(config);
                }
            }
            catch (Exception ex)
            {
                new InfoForm("Ошибка", ex).ShowDialog();
            }
        }
    }
}
