using System;

namespace Rectangles
{
	public static class RectanglesTask
	{
		// Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
		public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
			return (r1.Left + r1.Width >= r2.Left && r1.Left <= r2.Left
				|| r2.Left + r2.Width >= r1.Left && r2.Left <= r1.Left)
				&& (r2.Top <= r1.Top + r1.Height && r1.Top <= r2.Top
				|| r1.Top <= r2.Top + r2.Height && r2.Top <= r1.Top);
		}

		// Площадь пересечения прямоугольников
		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
			if (AreIntersected(r1, r2))
			{
				var minimumRight = Math.Min(r1.Right, r2.Right);
				var maximumLeft = Math.Max(r1.Left, r2.Left);
				var minimumBottom = Math.Min(r1.Bottom, r2.Bottom);
				var maximumTop = Math.Max(r1.Top, r2.Top);
				var xAxisIntersection = Math.Max(minimumRight - maximumLeft, 0);
				var yAxisIntersection = Math.Max(minimumBottom - maximumTop, 0);
				return xAxisIntersection * yAxisIntersection;
			}
			return 0;
		}

		// Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
		// Иначе вернуть -1
		// Если прямоугольники совпадают, можно вернуть номер любого из них.
		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
			if (ComparingRectangles(r1, r2)) return 0;
			if (ComparingRectangles(r2, r1)) return 1;
			return -1;
		}

		public static bool ComparingRectangles(Rectangle r1, Rectangle r2)
		{
			return (r1.Left >= r2.Left) && (r1.Right <= r2.Right) && (r1.Top >= r2.Top) && (r1.Bottom <= r2.Bottom);
		}
	}
}