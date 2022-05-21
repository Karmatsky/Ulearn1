using System;
using System.Collections.Generic;
using System.Drawing;

namespace RoutePlanning
{
    public static class PathFinderTask
    {
        public static int[] FindBestCheckpointsOrder(Point[] checkpoints)
        {
            double shortDistance= double.PositiveInfinity;
            int[] order = new int[checkpoints.Length];
            int[] bestOrder = new int[checkpoints.Length];
            MakeTrivialPermutation(order, 1, checkpoints, ref shortDistance, bestOrder);
            return bestOrder;
        }

        private static int[] MakeTrivialPermutation(int[] order, int position, Point[] checkpoints,
            ref double shortDistance,  int[] bestOrder)
        {
            var currentOrder = new int[position];
            Array.Copy(order, currentOrder, position);
            var pathLength = PointExtensions.GetPathLength(checkpoints, currentOrder);

            if (pathLength < shortDistance)
            {
                if (position == order.Length)
                {
                    shortDistance = pathLength;
                    bestOrder = (int[])order.Clone();
                    return order;
                }


                for (int i = 1; i < order.Length; i++)
                {
                    var index = Array.IndexOf(order, i, 0, position);
                    if (index != -1)
                        continue;
                    order[position] = i;
                    MakeTrivialPermutation(order, position + 1, checkpoints, ref shortDistance, bestOrder);
                }
            }
            return order;
        }

    }
}