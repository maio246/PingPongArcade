namespace PingPongGame.Validations
{
    using System;

    public static class GameKeyAuthenticator
    {
        public static bool IsDifficultyLevelKey(ConsoleKeyInfo key) => char.IsDigit(key.KeyChar);

        public static bool IsArrowKey(ConsoleKey key) => key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.W || key == ConsoleKey.S;

        public static bool IsArrowKey(ConsoleKeyInfo keyPressed) => keyPressed.Key == ConsoleKey.UpArrow || keyPressed.Key == ConsoleKey.DownArrow || keyPressed.Key == ConsoleKey.W || keyPressed.Key == ConsoleKey.S;
    }
}
