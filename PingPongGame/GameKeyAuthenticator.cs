namespace PingPongGame
{
    using System;

    public static class GameKeyAuthenticator
    {
        public static bool IsDifficultyLevelKey(ConsoleKeyInfo key) => char.IsDigit(key.KeyChar);

        public static bool IsArrowKey(ConsoleKey key) => key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow;

        public static bool IsArrowKey(ConsoleKeyInfo keyPressed) => keyPressed.Key == ConsoleKey.UpArrow || keyPressed.Key == ConsoleKey.DownArrow;

        //for future implementations maybe :)
        //public static bool IsMenuKey(ConsoleKeyInfo key) => key.KeyChar == 'Y' || key.KeyChar == 'y' || key.KeyChar == 'N' || key.KeyChar == 'n';
    }
}
