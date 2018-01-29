namespace PingPongGame.Management
{
    using System;
    using System.Linq;
    using System.Drawing;
    using System.Collections.Generic;
    using PingPongGame.GlobalConstants;

    public static class PlayerRocketManager
    {
        public static List<Point> CreatePlayerRocket(int size)
        {
            var rocket = new List<Point>();
            var rocketOffset = (Constants.ScreenHeightMiddle) - (size / 2);

            for (int i = 0; i < size; i++)
            {
                rocket.Add(new Point(rocketOffset + i, 0));
            }

            return rocket;
        }

        public static List<Point> UpdateRocket(List<Point> playerRocket, Point newDirection)
        {
            var isHittingWall = playerRocket.Any(point => point.X + newDirection.X == Console.WindowHeight || point.X + newDirection.X < 0);
            if (isHittingWall)
            {
                return playerRocket;
            }

            return playerRocket.Select(element => new Point()
            {
                X = element.X + newDirection.X,
                Y = element.Y
            }).ToList();
        }


    }
}
