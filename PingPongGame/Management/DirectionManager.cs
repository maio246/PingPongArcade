namespace PingPongGame.Management
{
    using System;
    using System.Drawing;

    public static class DirectionManager
    {
        private static Point[] diagonalDirections = new Point[]
        {
            new Point(-1, -1), //backwards and up
            new Point(1, -1),  // backwards and down
            new Point(1, 1),   // forward and down
            new Point(-1, 1)   //forward and up
        };

        public static Point GetNextDirection(ConsoleKeyInfo keyPressed)
        {
            if (keyPressed.Key == ConsoleKey.DownArrow)
            {
                return new Point(1, 0);
            }

            return new Point(-1, 0);
        }

        public static Point GetStartingDirection() => diagonalDirections[3];

        public static Point GetDiagonalDirection(Point pongBall, Point previousDirection)
        {
            //backwards and up
            if (previousDirection == diagonalDirections[0])
            {
                //...to forward and up
                if (pongBall.Y == 1)
                {
                    return diagonalDirections[3];
                }
                //...to backwards and down
                return diagonalDirections[1];
            }
            //backwards and down to forward and down
            else if (previousDirection == diagonalDirections[1] && pongBall.Y == 1)
            {
                return diagonalDirections[2];
            }
            //forward and down
            else if (previousDirection == diagonalDirections[2])
            {
                //...to forward and up
                if (previousDirection.Y != Console.WindowWidth)
                {
                    return diagonalDirections[3];
                }
                
                //...to backwards and down
                return diagonalDirections[1];
            }
            //forward and up
            else
            {
                //...to forward and down
                if (pongBall.X == 0 && pongBall.Y != Console.WindowWidth)
                {
                    return diagonalDirections[2];
                }

                //...to backwards and up
                return diagonalDirections[0];
            }
        }

        public static Point GetReversedDiagonalDirection(Point pongBall, Point ballDirection) => new Point(ballDirection.Y, ballDirection.X);
    }
}
