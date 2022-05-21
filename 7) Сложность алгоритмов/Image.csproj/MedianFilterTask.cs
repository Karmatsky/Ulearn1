using System.Linq;
using System.Collections.Generic;

namespace Recognizer
{
	internal static class MedianFilterTask
	{
		public static double[,] MedianFilter(double[,] original)
		{
			var height = original.GetLength(1);
			var width = original.GetLength(0);
			var picture = new double[width, height];
			for (var x = 0; x < width; x++)
				for (var y = 0; y < height; y++)
					picture[x, y] = GetPosition(original, x, y, width, height);
			return picture;
		}
		public static double GetPosition(double[,] original, int x, int y, int width, int height)
		{
			var startX = x - 1;
			var endX = x + 1;
			var startY = y - 1;
			var endY = y + 1;
			if (x == 0)
				startX = 0;
			if (x == width - 1)
				endX = width - 1;
			if (y == 0)
				startY = 0;
			if (y == height - 1)
				endY = height - 1;
			return GetMedian(original, startX, endX, startY, endY);
		}

		public static double GetMedian(double[,] original, int startX, int endX, int startY, int endY)
		{
			var l = new List<double>();
			for (var x = startX; x <= endX; x++)
				for (var y = startY; x <= endY; y++)
					l.Add(original[x, y]);

			l.Sort();
			if (l.Count % 2 == 0)
				return (l[l.Count / 2 - 1] + l[l.Count / 2]) / 2;
			return l[l.Count / 2];
		}
	}
}