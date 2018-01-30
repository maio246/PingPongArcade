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

        public static void PrintFieldBorders()
        {
            //for (int col = Console.WindowWidth - 1; col >= Console.WindowWidth / 2; col--)
            //{
            //    Console.SetCursorPosition(col, 0);
            //    Console.Write(Constants.TopBottomBorderElement);

            //    Console.SetCursorPosition(col - 1, 0);
            //    Console.Write(Constants.TopBottomBorderElement);

            //    Console.SetCursorPosition(col, Console.WindowHeight - 2);
            //    Console.Write(Constants.TopBottomBorderElement);

            //    Console.SetCursorPosition(col - 1, Console.WindowHeight - 2);
            //    Console.Write(Constants.TopBottomBorderElement);

            //    if (col < Console.WindowHeight - 1)
            //    {
            //        Console.SetCursorPosition(Console.WindowWidth - 1, col);
            //        Console.Write(Constants.RightBorderElement);
            //    }

            //}

            for (int col = 0; col < Console.WindowWidth - 1; col += 5)
            {

                for (int innerCol = 1; innerCol <= 5; innerCol++)
                {
                    if (col + innerCol < Console.WindowWidth)
                    {
                        Console.SetCursorPosition(col + innerCol, 0);
                        Console.Write(Constants.TopBottomBorderElement);

                        Console.SetCursorPosition(col + innerCol, Console.WindowHeight - 2);
                        Console.Write(Constants.TopBottomBorderElement);
                    }

                    if (col + innerCol < Console.WindowHeight - 2)
                    {
                        Console.SetCursorPosition(Console.WindowWidth - 1, col + innerCol);
                        Console.Write(Constants.RightBorderElement);
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
            Console.SetCursorPosition(Constants.ScreenWidthMiddle / 2, 1);
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
