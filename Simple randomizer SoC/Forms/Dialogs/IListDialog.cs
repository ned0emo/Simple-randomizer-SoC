using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Forms.Dialogs
{
    public interface IListDialog<T>
    {
        Func<T, bool> RowValidator { get; set; }
        Action<T> OnValidationError { get; set; }
        Func<T, T> DataPreprocessor { get; set; }
        bool Nullable { get; set; }
        List<T> Data { get; }
        ICollection<T> RawData { get; }
    }
}
