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
        public async void OpenEdit<TDialog, TRow>(TDialog dialog) where TDialog : Form, IListDialog<TRow>
        {
            try
            {
                await Task.Yield();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var collection = dialog.RawData;
                    collection.Clear();
                    foreach (var d in dialog.Data)
                    {
                        collection.Add(d);
                    }
                }
            }
            catch (Exception ex)
            {
                new InfoForm("Ошибка", ex).ShowDialog();
            }
        }

        public async Task OpenEditThenSave<TDialog, TRow>(TDialog dialog, IConfig config) where TDialog : Form, IListDialog<TRow>
        {
            try
            {
                await Task.Yield();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var collection = dialog.RawData;
                    collection.Clear();
                    foreach (var d in dialog.Data)
                    {
                        collection.Add(d);
                    }
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
