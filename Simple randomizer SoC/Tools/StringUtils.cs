using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Tools
{
    internal abstract class StringUtils
    {
        private static readonly Regex breaklinesSplitter = new Regex("[\\r\\n]+");
        private static readonly Regex breaklinesSideWhiteSpacesSplitter = new Regex("\\s*[\\r\\n]+\\s*");
        private static readonly Regex whitespaceSplitter = new Regex("\\s+");

        public static string RemoveLineBreaking(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            char[] buffer = new char[input.Length];
            int index = 0;

            foreach (char c in input)
            {
                if (c != '\n' && c != '\r') buffer[index++] = c;
            }

            return new string(buffer, 0, index);
        }

        public static List<string> Split(string input, string separator)
        {
            var result = new List<string>();
            if (string.IsNullOrEmpty(input)) return result;
            if (string.IsNullOrEmpty(separator)) return new List<string> { input };

            int separatorLength = separator.Length;
            int startIndex = 0;
            int index;

            while ((index = input.IndexOf(separator, startIndex, StringComparison.Ordinal)) != -1)
            {
                result.Add(input.Substring(startIndex, index - startIndex));
                startIndex = index + separatorLength;
            }

            result.Add(input.Substring(startIndex));
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Regex.Split(input, "[\\r\\n]+")</returns>
        public static string[] SplitBreaklines(string input, bool withSideWhiteSpace = false)
        {
            if (withSideWhiteSpace)
            {
                return breaklinesSideWhiteSpacesSplitter.Split(input.Trim());
            }
            else
            {
                return breaklinesSplitter.Split(input.Trim());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inupt"></param>
        /// <returns>Regex.Split(input, "\\s+")</returns>
        public static string[] WhiteSpaceSplit(string inupt)
        {
            return whitespaceSplitter.Split(inupt);
        }
    }
}
