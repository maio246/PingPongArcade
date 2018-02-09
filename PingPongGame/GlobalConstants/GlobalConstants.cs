namespace PingPongGame.GlobalConstants
{
    using System;

    public static class GlobalConstants
    {
        public static string PlayerRocketElement = "█";
        public static string PingPongBallElement = "@";
        public static string TopBottomBorderElement = "-";
        public static string RightBorderElement = "|";


        public static string GameTitle = "Ping Pong Arcade";

        public static int FieldWidth = Console.WindowWidth / 5;

        public static string SingplePlayerMessage = "Single Player";
        public static string MultiplayerMessage = "Multiplayer";

        public static string SelectedSingplePlayerMessage = "<Single Player>";
        public static string SelectedMultiplayerMessage = "<Multiplayer>";

        public static string PlayerRocketSizeMessage = "Please choose difficulty:";
        public static string DifficultyChoiceMessage = "press button from 1 to 9: ";

        public static string PlayerScoreLabel = "Score: ";

        public static string GameOverMessage = "Game Over!";
        public static string ContinueGameMessage = "Press 'Space' key if you want to play again!";

        public static int ScreenHeightMiddle = Console.WindowHeight / 2;
        public static int ScreenWidthMiddle = Console.WindowWidth / 2;
    }
}
