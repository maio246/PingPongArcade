namespace PingPongGame
{
    using PingPongGame.GlobalConstants;
    using System;
    using System.Threading;

    public static class Environment
    {
        public static void SetEnvironment()
        {
            Console.Title = GlobalConstants.GlobalConstants.GameTitle;
            Console.CursorVisible = false;
            Console.BufferHeight = Console.WindowHeight;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
        }

    }
}
