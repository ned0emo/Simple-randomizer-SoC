using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_randomizer_SoC.Tools
{
    public class CollectionUtils
    {

        public static T GetRandomElement<T>(List<T> list, Random rnd)
        {
            return list.Count == 0 ? default : list[rnd.Next(list.Count)];
        }

        public static List<T> GetRandomElements<T>(List<T> list, int count, Random rnd)
        {
            if (count >= list.Count) return list;
            if (count == 0) return new List<T>();
            if (count < 0) throw new ArgumentOutOfRangeException("count");

            var indexList = new List<int>();
            for (int i = 0; i < list.Count; i++) indexList.Add(i);

            var result = new List<T>();
            while (count-- > 0)
            {
                var index = indexList[rnd.Next(indexList.Count)];
                indexList.Remove(index);

                result.Add(list[index]);
            }

            return result;
        }
    }
}
