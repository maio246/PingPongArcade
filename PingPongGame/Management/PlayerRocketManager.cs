namespace PingPongGame.Management
{
    using System;
    using System.Linq;
    using System.Drawing;
    using System.Collections.Generic;
    using PingPongGame.GlobalConstants;

    public static class PlayerRocketManager
    {
        public static List<Point> LeftPlayerRocket;
        public static List<Point> RightPlayerRocket;

        public static void CreatePlayerRockets(int size, bool areTwoPlayersSelected)
        {
            CreateLeftPlayerRocket(size);

            if (areTwoPlayersSelected)
                CreateRightPlayerRocket(size);

        }

        public static void UpdateLeftPlayerRocket(Point newDirection)
        {
            var isHittingWall = LeftPlayerRocket.Any(point => point.X + newDirection.X == Console.WindowHeight - 2 
                                                            || point.X + newDirection.X < 0);
            if (!isHittingWall)
            {
                LeftPlayerRocket = LeftPlayerRocket.Select(element => new Point()
                {
                    X = element.X + newDirection.X,
                    Y = element.Y
                }).ToList();
            }
        }

        public static void UpdateRightPlayerRocket(Point newDirection)
        {
            var isHittingWall = RightPlayerRocket.Any(point => point.X + newDirection.X == Console.WindowHeight - 2
                                                            || point.X + newDirection.X < 0);
            if (!isHittingWall)
            {
                RightPlayerRocket = RightPlayerRocket.Select(element => new Point()
                {
                    X = element.X + newDirection.X,
                    Y = element.Y
                }).ToList();
            }
        }

        public static Point GetElementToDelete(List<Point> playerRocket, Point newDirection)
            => newDirection.X == 1 ? playerRocket.First() : playerRocket.Last();

        private static void CreateLeftPlayerRocket(int size)
        {
            var firstPlayerRocket = new List<Point>();
            var rocketOffset = (GlobalConstants.ScreenHeightMiddle) - (size / 2);

            for (int i = 0; i < size; i++)
            {
                firstPlayerRocket.Add(new Point(rocketOffset + i, 0));
            }

            LeftPlayerRocket = firstPlayerRocket;
        }

        private static void CreateRightPlayerRocket(int size)
        {
            var rocket = new List<Point>();
            var rocketOffset = (GlobalConstants.ScreenHeightMiddle) - (size / 2);

            for (int i = 0; i < size; i++)
            {
                rocket.Add(new Point(rocketOffset + i, Console.WindowWidth - 1));
            }

            RightPlayerRocket = rocket;
        }
    }
}
