using System;
using System.Drawing;

namespace Fractals
{
    internal static class DragonFractalTask
    {
        public static double GetXCoordinate(double x, double y, double angle)
        {
            return (x * Math.Cos(angle) - y * Math.Sin(angle)) / Math.Sqrt(2);
        }

        public static double GetYCoordinate(double x, double y, double angle)
        {
            return (x * Math.Sin(angle) + y * Math.Cos(angle)) / Math.Sqrt(2);
        }

        public static void DrawDragonFractal(Pixels pixels, int countIterations, int seed)
        {
            var x = 1.0;
            var y = 0.0;
            var initRandom = new Random(seed);

            for (int i = 0; i < countIterations; ++i)
            {
                var oldX = x;
                var pi4 = Math.PI / 4;
                var pi34 = Math.PI * 3 / 4;
                if (initRandom.Next(2) == 0)
                {
                    x = GetXCoordinate(x, y, pi4);
                    y = GetYCoordinate(oldX, y, pi4);
                }

                else
                {
                    x = GetXCoordinate(x, y, pi34) + 1;
                    y = GetYCoordinate(oldX, y, pi34);
                }
                pixels.SetPixel(x, y);
            }
        }
    }
}
