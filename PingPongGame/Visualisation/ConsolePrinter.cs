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
            var firstMessageOffset = GlobalConstants.PlayerRocketSizeMessage.Length / 2;
            var secondMessageOffset = GlobalConstants.DifficultyChoiceMessage.Length / 2;

            Console.Clear();
            Console.SetCursorPosition(GlobalConstants.ScreenWidthMiddle - firstMessageOffset, GlobalConstants.ScreenHeightMiddle);
            Console.Write(GlobalConstants.PlayerRocketSizeMessage);

            Console.SetCursorPosition(GlobalConstants.ScreenWidthMiddle - secondMessageOffset, GlobalConstants.ScreenHeightMiddle + 1);
            Console.Write(GlobalConstants.DifficultyChoiceMessage);
            Console.CursorVisible = true;
        }

        public static void SinglePlayerScreen()
        {
            var firstMessageOffset = GlobalConstants.SelectedSingplePlayerMessage.Length / 2;
            var secondMessageOffset = GlobalConstants.MultiplayerMessage.Length / 2;

            Console.Clear();
            Console.SetCursorPosition(GlobalConstants.ScreenWidthMiddle - firstMessageOffset, GlobalConstants.ScreenHeightMiddle);
            Console.Write(GlobalConstants.SelectedSingplePlayerMessage);
            Console.SetCursorPosition(GlobalConstants.ScreenWidthMiddle - secondMessageOffset, GlobalConstants.ScreenHeightMiddle + 2);
            Console.Write(GlobalConstants.MultiplayerMessage);
        }

        public static void MultiPlayerScreen()
        {
            var firstMessageOffset = GlobalConstants.SingplePlayerMessage.Length / 2;
            var secondMessageOffset = GlobalConstants.SelectedMultiplayerMessage.Length / 2;

            Console.Clear();
            Console.SetCursorPosition(GlobalConstants.ScreenWidthMiddle - firstMessageOffset, GlobalConstants.ScreenHeightMiddle);
            Console.Write(GlobalConstants.SingplePlayerMessage);
            Console.SetCursorPosition(GlobalConstants.ScreenWidthMiddle - secondMessageOffset, GlobalConstants.ScreenHeightMiddle + 2);
            Console.Write(GlobalConstants.SelectedMultiplayerMessage);
        }

        public static void PrintFieldBorders(bool hasSecondPlayer)
        {
            for (int col = 0; col < Console.WindowWidth - 1; col += 5)
            {
                for (int innerCol = 1; innerCol <= 5; innerCol++)
                {
                    if (col + innerCol < Console.WindowWidth)
                    {
                        Console.SetCursorPosition(col + innerCol, 0);
                        Console.Write(GlobalConstants.TopBottomBorderElement);

                        Console.SetCursorPosition(col + innerCol, Console.WindowHeight - 2);
                        Console.Write(GlobalConstants.TopBottomBorderElement);
                    }

                    if (col + innerCol < Console.WindowHeight - 2 && hasSecondPlayer)
                    {
                        Console.SetCursorPosition(Console.WindowWidth - 1, col + innerCol);
                        Console.Write(GlobalConstants.RightBorderElement);
                    }
                }
            }

        }

        public static void DeleteElement(int y, int x)
        {
            Console.SetCursorPosition(y, x);
            Console.Write(" ");
        }

        public static void PrintPlayerScore(int playerScore)
        {
            Console.SetCursorPosition(GlobalConstants.ScreenWidthMiddle / 2, 1);
            Console.Write(GlobalConstants.PlayerScoreLabel + playerScore);
        }

        public static void PrintPlayerRocket(List<Point> playerRocket)
        {
            foreach (Point element in playerRocket)
            {
                Console.SetCursorPosition(element.Y, element.X);
                Console.Write(GlobalConstants.PlayerRocketElement);
            }
        }

        public static void PrintPongBall(Point pongBall)
        {
            Console.SetCursorPosition(pongBall.Y, pongBall.X);
            Console.Write(GlobalConstants.PingPongBallElement);
        }

        public static void PrintGameOverScreen(string message)
        {
            Console.SetCursorPosition(GlobalConstants.ScreenWidthMiddle - (message.Length / 2), GlobalConstants.ScreenHeightMiddle - 1);
            Console.Write(message);
            Console.SetCursorPosition(GlobalConstants.ScreenWidthMiddle - (GlobalConstants.ContinueGameMessage.Length / 2), GlobalConstants.ScreenHeightMiddle);
            Console.Write(GlobalConstants.ContinueGameMessage);
        }
    }
}
