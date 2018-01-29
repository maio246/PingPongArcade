namespace PingPongGame.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class GameOverException : Exception
    {
        public GameOverException()
        {
        }

        public GameOverException(string message) : base(message)
        {
        }
    }
}