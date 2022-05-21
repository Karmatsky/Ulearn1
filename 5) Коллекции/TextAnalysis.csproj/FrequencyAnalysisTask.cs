using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    internal static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string, string>();
            var dictionary = new Dictionary<string, Dictionary<string, int>>();
            for (var i = 0; i < text.Count; i++)
            {
                if (text[i].Count > 1)
                    for (var j = 0; j + 1 < text[i].Count; j++)
                        ApplyIfMoreOne(text, dictionary, i, j);
                if (text[i].Count > 2)
                    for (var j = 0; j + 2 < text[i].Count; j++)
                        ApplyIfMoreTwo(text, dictionary, i, j);
            }

            return dictionary.ToDictionary(item => item.Key,
                item => item.Value.OrderByDescending(x => x.Value).ThenBy(s => s.Key, StringComparer.Ordinal).First()
                    .Key);
        }

        static void ApplyIfMoreTwo(List<List<string>> text,
            Dictionary<string, Dictionary<string, int>> list, int i, int j)
        {
            if (!list.ContainsKey(text[i][j] + " " + text[i][j + 1]))
                list[text[i][j] + " " + text[i][j + 1]] = new Dictionary<string, int> { { text[i][j + 2], 1 } };
            else if (!list[text[i][j] + " " + text[i][j + 1]].ContainsKey(text[i][j + 2]))
                list[text[i][j] + " " + text[i][j + 1]][text[i][j + 2]] = 1;
            else
                list[text[i][j] + " " + text[i][j + 1]][text[i][j + 2]]++;
        }

        static void ApplyIfMoreOne(List<List<string>> text,
            Dictionary<string, Dictionary<string, int>> list, int i, int j)
        {
            if (!list.ContainsKey(text[i][j]))
                list[text[i][j]] = new Dictionary<string, int> { { text[i][j + 1], 1 } };
            else if (!list[text[i][j]].ContainsKey(text[i][j + 1]))
                list[text[i][j]][text[i][j + 1]] = 1;
            else
                list[text[i][j]][text[i][j + 1]]++;
        }
    }
}