namespace PingPongGame.GlobalConstants
{
    using System;

    public static class EnvironmentSettings
    {
        public static void SetEnvironment()
        {
            Console.Title = GlobalConstants.GameTitle;
            Console.CursorVisible = false;
            Console.BufferHeight = Console.WindowHeight;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
        }
    }
}
