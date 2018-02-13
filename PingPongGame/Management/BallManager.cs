namespace PingPongGame.Management
{
    using PingPongGame.Exceptions;
    using PingPongGame.GlobalConstants;
    using System;
    using System.Drawing;

    public static class BallManager
    {
        public static Point MoveBall(Point pongBall, Point movementDirection)
        {
            PlayerLossException innerException;

            var playerLossMessage = string.Empty;

            if (pongBall.Y + movementDirection.Y <= 0)
            {
                playerLossMessage = string.Format(GlobalConstants.PlayerLossMessage, (int)PlayerSideIndex.LeftFieldSide);
                innerException = new PlayerLossException(playerLossMessage);

                throw new GameOverException(GlobalConstants.GameOverMessage, innerException);
            }
            else if (pongBall.Y + movementDirection.Y >= Console.WindowWidth - 1)
            {
                playerLossMessage = string.Format(GlobalConstants.PlayerLossMessage, (int)PlayerSideIndex.RightFieldSide);
                innerException = new PlayerLossException(playerLossMessage);

                throw new GameOverException(GlobalConstants.GameOverMessage, innerException);
            }

            pongBall.X += movementDirection.X;
            pongBall.Y += movementDirection.Y;

            return pongBall;
        }
    }
}
