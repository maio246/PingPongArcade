namespace PingPongGame
{
    using System;

    public static class EnvironmentSettings
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
