using Simple_randomizer_SoC.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simple_randomizer_SoC.Model
{
    public class LtxData
    {
        public List<string> Includes { get; set; } = new List<string>();
        public List<LtxSection> Sections { get; set; } = new List<LtxSection>();

        public override string ToString()
        {
            return (Includes.Count == 0 ? "" : Includes.Aggregate((i1, i2) => i1 + "\r\n" + i2)) + "\r\n" +
                (Sections.Count == 0 ? "" : Sections.Select(s => s.ToString()).Aggregate((s1, s2) => s1 + "\r\n" + s2));
        }

        public static async Task<LtxData> Parse(StreamReader streamReader)
        {
            var ltxData = new LtxData();

            string line;
            LtxSection currentSection = null;
            while ((line = await streamReader.ReadLineAsync()) != null)
            {
                if (line.Contains(";"))
                {
                    line = line.Substring(0, line.IndexOf(";"));
                }

                line = line.Trim();

                if (string.IsNullOrWhiteSpace(line)) continue;

                if (line.StartsWith("#include"))
                {
                    ltxData.Includes.Add(line);
                    continue;
                }

                if (line.StartsWith("["))
                {
                    var section = new LtxSection();
                    if (line.Contains(":"))
                    {
                        var split = line.Split(':');
                        if (split.Length > 2)
                        {
                            throw new CustomException("Строка секции содержит больше одного символа ':'");
                        }

                        section.Name = split[0];
                        section.ParentName = split[1];
                    }
                    else
                    {
                        section.Name = line;
                    }

                    ltxData.Sections.Add(section);
                    currentSection = section;

                    continue;
                }

                if (currentSection != null)
                {
                    //var param = new LtxParam();

                    if (line.Contains("="))
                    {
                        var eqIndex = line.IndexOf("=");
                        var paramData = new List<string>() { line.Substring(0, eqIndex), line.Substring(eqIndex + 1, line.Length - eqIndex - 1) };

                        var paramName = paramData[0].Trim();
                        List<string> paramValues;

                        if (paramData[1].Contains(","))
                            paramValues = paramData[1].Split(',').Select(p => p.Trim()).ToList();
                        else
                            paramValues = new List<string>() { paramData[1].Trim() };

                        currentSection.HasAnyParam = true;
                        currentSection.Params[paramName] = paramValues;
                    }
                    else
                    {
                        currentSection.Params[line] = new List<string>();
                    }
                }
            }

            return ltxData;
        }
    }
}
