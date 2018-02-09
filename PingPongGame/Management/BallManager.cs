namespace PingPongGame.Management
{
    using PingPongGame.Exceptions;
    using PingPongGame.GlobalConstants;
    using System.Drawing;

    public static class BallManager
    {
        public static Point MoveBall(Point pongBall, Point movementDirection)
        {
            if (pongBall.Y + movementDirection.Y <= 0)
            {
                throw new GameOverException(GlobalConstants.GameOverMessage);
            }

            pongBall.X += movementDirection.X;
            pongBall.Y += movementDirection.Y;

            return pongBall;
        }
    }
}
