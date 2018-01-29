namespace PingPongGame.Visualisation
{
    using PingPongGame.GlobalConstants;
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public static class ConsolePrinter
    {
        private static Random rdn = new Random();

        public static void StartScreen()
        {
            var firstMessageOffset = Constants.PlayerRocketSizeMessage.Length / 2;
            var secondMessageOffset = Constants.DifficultyChoiceMessage.Length / 2;

            Console.SetCursorPosition(Constants.ScreenWidthMiddle - firstMessageOffset, Constants.ScreenHeightMiddle);
            Console.Write(Constants.PlayerRocketSizeMessage);

            Console.SetCursorPosition(Constants.ScreenWidthMiddle - secondMessageOffset, Constants.ScreenHeightMiddle + 1);
            Console.Write(Constants.DifficultyChoiceMessage);
            Console.CursorVisible = true;
        }

        public static void PrintPlayerScore(int playerScore)
        {
            Console.SetCursorPosition(Constants.ScreenWidthMiddle / 2, 0);
            Console.Write(Constants.PlayerScoreLabel + playerScore);
        }

        public static void PrintPlayerRocket(List<Point> playerRocket)
        {
            foreach (Point element in playerRocket)
            {
                Console.SetCursorPosition(element.Y, element.X);
                Console.Write(Constants.PlayerRocketElement);
            }
        }

        public static void PrintPongBall(Point pongBall)
        {
            Console.SetCursorPosition(pongBall.Y, pongBall.X);
            Console.Write(Constants.PingPongBallElement);
        }

        public static void PrintGameOverScreen(string message)
        {
            Console.SetCursorPosition(Constants.ScreenWidthMiddle - (message.Length / 2), Constants.ScreenHeightMiddle - 1);
            Console.Write(message);
            Console.SetCursorPosition(Constants.ScreenWidthMiddle - (Constants.ContinueGameMessage.Length / 2), Constants.ScreenHeightMiddle);
            Console.Write(Constants.ContinueGameMessage);
        }
    }
}
