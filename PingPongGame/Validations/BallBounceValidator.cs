namespace PingPongGame.Validations
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public static class BallBounceValidator
    {
        public static bool IsHittingPlayerRocket(Point pongBall, Point ballDirection, List<Point> playerRocket) =>
            playerRocket.Any(element => (element.X == pongBall.X + ballDirection.X
                            && element.Y == pongBall.Y + ballDirection.Y) 
                            || element.X == Math.Abs(pongBall.X - ballDirection.X)
                            && element.Y == Math.Abs(pongBall.Y - ballDirection.Y));

        public static bool IsHittingBorder(Point pongBall, Point ballDirection, bool areTwoPlayersSelected)
        {

            bool isHittingTopSide = pongBall.X + ballDirection.X <= 0
                                        && pongBall.Y + ballDirection.Y > 1
                                        && pongBall.Y + ballDirection.Y < Console.WindowWidth - 1;

            bool isHittingBottomSide = pongBall.X + ballDirection.X >= Console.WindowHeight - 3
                                        && pongBall.Y + ballDirection.Y > 1
                                        && pongBall.Y + ballDirection.Y < Console.WindowWidth - 1;

            if (!areTwoPlayersSelected)
            {
                bool isHittingRightSide = pongBall.Y + ballDirection.Y >= Console.WindowWidth - 2
                                            && pongBall.X + ballDirection.X > 1
                                            && pongBall.X + ballDirection.X < Console.WindowHeight - 2;

                return isHittingTopSide || isHittingBottomSide || isHittingRightSide;
            }

            return isHittingTopSide || isHittingBottomSide;
        }

        public static bool IsHittingEdge(Point pongBall, Point ballDirection, bool areTwoPlayersSelected)
        {
            var steppingAtTheTopEdges =
                pongBall.X + ballDirection.X == 1
                && (pongBall.Y + ballDirection.Y == 1 || pongBall.Y + ballDirection.Y == Console.WindowWidth - 1);

            var steppingAtTheBottomEdges =
                pongBall.X + ballDirection.X == Console.WindowHeight - 3
                && (pongBall.Y + ballDirection.Y == 1 || pongBall.Y + ballDirection.Y == Console.WindowWidth - 1);

            return steppingAtTheTopEdges && steppingAtTheBottomEdges;
        }

    }
}
