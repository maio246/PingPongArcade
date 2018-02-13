using System;
using System.Runtime.Serialization;

namespace PingPongGame.Exceptions
{
    public class PlayerLossException : Exception
    {
        public PlayerLossException()
        {
        }

        public PlayerLossException(string message) : base(message)
        {
        }
    }
}
