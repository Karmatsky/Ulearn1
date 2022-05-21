namespace Mazes
{
    public static class SnakeMazeTask
    {
        public static void MoveOut(Robot snake, int width, int height)
        {
            while (!snake.Finished)
            {
                Move(snake, width - 3, Direction.Right);
                Move(snake, 2, Direction.Down);
                Move(snake, width - 3, Direction.Left);
                if (!snake.Finished)
                    Move(snake, 2, Direction.Down);
            }
        }

        private static void Move(Robot snake, int width, Direction direction)
        {
            for (var j = 0; j < width; j++)
                snake.MoveTo(direction);
        }
    }
}