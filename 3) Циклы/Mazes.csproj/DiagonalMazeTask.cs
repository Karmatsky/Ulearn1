using System;

namespace Mazes
{
	public static class DiagonalMazeTask
	{
		public static void MoveSide(Robot robot, int steps, Direction direction)
		{
			for (int i = 0; i < steps; i++)
				robot.MoveTo(direction);
		}

		public static void StairsMove(Robot robot, int steps, bool mazeIsHorizontal)
		{
			if (mazeIsHorizontal)
			{
				robot.MoveTo(Direction.Down);
				MoveSide(robot, steps, Direction.Right);
			}
			else
			{
				robot.MoveTo(Direction.Right);
				MoveSide(robot, steps, Direction.Down);
			}
		}

		public static void MoveOut(Robot robot, int width, int height)
		{
			int stepLength = (Math.Max(width, height) - 3) / (Math.Min(width, height) - 2);

			if (width > height)
				MoveSide(robot, stepLength, Direction.Right);
			else
				MoveSide(robot, stepLength, Direction.Down);

			for (int i = 0; i < Math.Min(width, height) - 3; i++)
				StairsMove(robot, stepLength, width > height);
		}
	}
}