namespace PingPongGame
{
    using PingPongGame.GlobalConstants;
    using System;

    public static class Environment
    {
        public static void SetEnvironment()
        {
            Console.Title = Constants.GameTitle;
            Console.CursorVisible = false;
            Console.WindowHeight = Console.WindowHeight;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
        }
    }
}
