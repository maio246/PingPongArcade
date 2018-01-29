namespace PingPongGame.GlobalConstants
{
    using System;

    public static class Constants
    {
        public static string PlayerRocketElement = "█";
        public static string PingPongBallElement = "@";

        public static string GameTitle = "Ping Pong Arcade";

        public static string PlayerRocketSizeMessage = "Press button from 1 to 9";
        public static string DifficultyChoiceMessage = "to select the difficulty: ";

        public static string PlayerScoreLabel = "Score: ";

        public static string GameOverMessage = "Game Over!";
        public static string ContinueGameMessage = "Press 'Space' key if you want to play again!";

        public static int ScreenHeightMiddle = Console.WindowHeight / 2;
        public static int ScreenWidthMiddle = Console.WindowWidth / 2;
    }
}
