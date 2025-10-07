using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Linq;

namespace Simple_randomizer_SoC.Enums
{
    public enum ParameterType
    {
        FromList,
        IntRange,
        FloatRange,
        Shuffle,
        Copy,
        CustomList
    }

    public abstract class ParameterTypeDataSource
    {
        private static readonly List<ParameterType> lessList =
            new List<ParameterType>() { ParameterType.FromList, ParameterType.IntRange, ParameterType.FloatRange };

        private static readonly List<ParameterType> fullList = Enum.GetValues(typeof(ParameterType)).Cast<ParameterType>().ToList();

        public static object Get()
        {
            return fullList
            .Select(p => new
            {
                Value = p,
                Description = Localization.Get(p.ToString())
            }).ToList();
        }

        public static object GetLess()
        {
            return lessList
            .Select(p => new
            {
                Value = p,
                Description = Localization.Get(p.ToString())
            }).ToList();
        }
    }
}
