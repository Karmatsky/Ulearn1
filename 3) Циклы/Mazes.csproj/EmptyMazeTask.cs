namespace Mazes
{
    public static class EmptyMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            Move(robot, Direction.Right, width - 3);
            Move(robot, Direction.Down, height - 3);
        }

        private static void Move(Robot robot, Direction direction, int stepsCount)
        {
            for (var j = 0; j < stepsCount; j++)
                robot.MoveTo(direction);
        }
    }
}