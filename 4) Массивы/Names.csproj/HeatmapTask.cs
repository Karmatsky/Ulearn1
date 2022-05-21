using System;

namespace Names
{
    internal static class HeatmapTask
    {
        private static string[] GetLabels(int startNumber, int elementsNumber)
        {
            var arr = new string[elementsNumber];
            for (var j = 0; j < arr.Length; j++)
                arr[j] = (j + startNumber).ToString();
            return arr;
        }

        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            var month = GetLabels(1, 12);
            var day = GetLabels(2, 30);
            var monthDay = new double[30, 12];
            foreach (var name in names)
                if (name.BirthDate.Day != 1)
                    monthDay[name.BirthDate.Day - 2, name.BirthDate.Month - 1]++;
            return new HeatmapData("Карта интенсивности", monthDay, day, month);
        }
    }
}