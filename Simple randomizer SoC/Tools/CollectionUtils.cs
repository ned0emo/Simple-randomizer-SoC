using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Tools
{
    public class CollectionUtils
    {
        public static T GetRandomElement<T>(T[] arr)
        {
            return arr.Length == 0 ? default : arr[GlobalRandom.Rnd.Next(arr.Length)];
        }

        public static T GetRandomElement<T>(List<T> list)
        {
            return list.Count == 0 ? default : list[GlobalRandom.Rnd.Next(list.Count)];
        }

        public static KeyValuePair<T, V> GetRandomElement<T, V>(Dictionary<T, V> dict)
        {
            return dict.Count == 0 ? default : dict.ToList()[GlobalRandom.Rnd.Next(dict.Count)];
        }

        public static List<T> GetRandomElements<T>(T[] arr, int count)
        {
            if (count >= arr.Length) return arr.ToList();
            if (count == 0) return new List<T>();
            if (count < 0) throw new ArgumentOutOfRangeException("count");

            var indexList = new List<int>();
            for (int i = 0; i < count; i++) indexList.Add(i);

            var result = new List<T>();
            while (count-- > 0)
            {
                var index = indexList[GlobalRandom.Rnd.Next(indexList.Count)];
                indexList.Remove(index);

                result.Add(arr[index]);
            }

            return result;
        }

        public static List<T> GetRandomElements<T>(List<T> list, int count)
        {
            if (count >= list.Count) return list.ToList();
            if (count == 0) return new List<T>();
            if (count < 0) throw new ArgumentOutOfRangeException("count");

            var result = new List<T>();
            while (count-- > 0)
            {
                var index = GlobalRandom.Rnd.Next(list.Count);
                result.Add(list[index]);
                list.RemoveAt(index);
            }

            return result;
        }
    }
}
