using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Simple_randomizer_SoC.Enums
{
    public enum ParameterType
    {
        FromList,
        IntRange,
        FloatRange,
        Shuffle,
        Copy
    }

    public abstract class ParameterTypeDataSource
    {
        public static object Get()
        {
            return Enum.GetValues(typeof(ParameterType)).Cast<ParameterType>().Select(p => new
            {
                Value = p,
                Description = Localization.Get(p.ToString())
            }).ToList();
        }
    }
}
