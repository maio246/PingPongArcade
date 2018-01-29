namespace PingPongGame.Management
{
    using PingPongGame.Exceptions;
    using PingPongGame.GlobalConstants;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public static class BallManager
    {
        public static Point MoveBall(Point pongBall, Point movementDirection)
        {
            if (pongBall.Y + movementDirection.Y <= 0)
            {
                throw new GameOverException(Constants.GameOverMessage);
            }

            pongBall.X += movementDirection.X;
            pongBall.Y += movementDirection.Y;

            return pongBall;
        }

        public static bool IsHittingPlayerRocket(Point pongBall, Point ballDirection, List<Point> playerRocket) => 
            playerRocket.Any(element => element.X == pongBall.X + ballDirection.X && element.Y == pongBall.Y + ballDirection.Y);

        public static bool IsHittingBorder(Point pongBall, Point ballDirection)
        {

            var isHittingTopSide = pongBall.X + ballDirection.X < 0
                                        && pongBall.Y + ballDirection.Y > 1
                                        && pongBall.Y + ballDirection.Y < Console.WindowWidth;

            var isHittingBottomSide = pongBall.X + ballDirection.X == Console.WindowHeight
                                        && pongBall.Y + ballDirection.Y > 1
                                        && pongBall.Y + ballDirection.Y < Console.WindowWidth;

            var isHittingRightSide = pongBall.Y + ballDirection.Y == Console.WindowWidth
                                        && pongBall.X + ballDirection.X > 0
                                        && pongBall.X + ballDirection.X < Console.WindowHeight;

            return isHittingTopSide || isHittingBottomSide || isHittingRightSide;
        }

        public static bool IsHittingEdge(Point pongBall, Point ballDirection)
        {
            var steppingAtTheTopEdges =
                pongBall.X + ballDirection.X == 0
                && (pongBall.Y + ballDirection.Y == 1
                        || pongBall.Y + ballDirection.Y == Console.WindowWidth);

            var steppingAtBottomEdges =
                pongBall.X + ballDirection.X == Console.WindowHeight
                && (pongBall.Y + ballDirection.Y == 1
                        || pongBall.Y + ballDirection.Y == Console.WindowWidth);

            return steppingAtTheTopEdges && steppingAtBottomEdges;
        }
    }
}
