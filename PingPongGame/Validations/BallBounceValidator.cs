namespace PingPongGame.Validations
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public static class BallBounceValidator
    {
        public static bool IsHittingPlayerRocket(Point pongBall, Point ballDirection, List<Point> playerRocket) =>
    playerRocket.Any(element => element.X == pongBall.X + ballDirection.X && element.Y == pongBall.Y + ballDirection.Y);

        public static bool IsHittingBorder(Point pongBall, Point ballDirection)
        {

            var isHittingTopSide = pongBall.X + ballDirection.X <= 0
                                        && pongBall.Y + ballDirection.Y > 1
                                        && pongBall.Y + ballDirection.Y < Console.WindowWidth - 1;

            var isHittingBottomSide = pongBall.X + ballDirection.X >= Console.WindowHeight - 2
                                        && pongBall.Y + ballDirection.Y > 1
                                        && pongBall.Y + ballDirection.Y < Console.WindowWidth - 1;

            var isHittingRightSide = pongBall.Y + ballDirection.Y >= Console.WindowWidth - 2
                                        && pongBall.X + ballDirection.X > 1
                                        && pongBall.X + ballDirection.X < Console.WindowHeight - 1;

            return isHittingTopSide || isHittingBottomSide || isHittingRightSide;
        }

        public static bool IsHittingEdge(Point pongBall, Point ballDirection)
        {
            var steppingAtTheTopEdges =
                pongBall.X + ballDirection.X == 1
                && (pongBall.Y + ballDirection.Y == 1
                        || pongBall.Y + ballDirection.Y == Console.WindowWidth - 1);

            var steppingAtBottomEdges =
                pongBall.X + ballDirection.X == Console.WindowHeight - 2
                && (pongBall.Y + ballDirection.Y == 1
                        || pongBall.Y + ballDirection.Y == Console.WindowWidth - 1);

            return steppingAtTheTopEdges && steppingAtBottomEdges;
        }

    }
}
