using System;
using System.Linq;

namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            var label = new string[31];
            for (var j = 0; j < label.Length; j++)
            {
                label[j] = (j + 1).ToString();
            }
            var birthC = new double[31];
            foreach (var day in names)
            {
                if (day.Name == name && day.BirthDate.Day != 1)
                    birthC[day.BirthDate.Day - 1]++;
            }
            return new HistogramData($"Рождаемость с именем {name}", label, birthC);
        }
    }
}