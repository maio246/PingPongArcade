namespace PingPongGame
{
    using PingPongGame.Exceptions;
    using PingPongGame.Management;
    using PingPongGame.Validations;
    using PingPongGame.Visualisation;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Threading;

    public class StartUp
    {
        private static bool changeDirection;
        private static int ballMovementSpeed;

        public static void Main()
        {
            Console.CursorVisible = false;

            ConsolePrinter.SinglePlayerScreen();
            ConsoleKeyInfo playersChoise = Console.ReadKey();

            while (playersChoise.Key != ConsoleKey.Enter)
            {
                if (playersChoise.Key == ConsoleKey.DownArrow)
                {
                    ConsolePrinter.MultiPlayerScreen();
                }
                else if (playersChoise.Key == ConsoleKey.UpArrow)
                {
                    ConsolePrinter.SinglePlayerScreen();
                }

                playersChoise = Console.ReadKey();
            }

            ChooseDifficulty:

            HighScoreManager.ResetPlayerPoints();
            List<Point> playerRocket = new List<Point>();

            Environment.SetEnvironment();
            ConsolePrinter.StartScreen();

            ConsoleKeyInfo difficultyLevelKey = Console.ReadKey();

            if (!GameKeyAuthenticator.IsDifficultyLevelKey(difficultyLevelKey))
            {
                Console.Clear();
                goto ChooseDifficulty;
            }


            var parsedDifficultyKey = int.Parse(difficultyLevelKey.KeyChar.ToString());
            playerRocket = PlayerRocketManager.CreatePlayerRocket(parsedDifficultyKey);

            ballMovementSpeed = (5 * parsedDifficultyKey) + 50;

            Console.Clear();
            Console.CursorVisible = false;
            changeDirection = false;

            //default forward and up direction of the pong ball
            var ballDirection = DirectionManager.GetStartingDirection();

            //default ball starting position
            var pongBall = new Point(Console.BufferHeight / 2, 1);

            Console.Clear();
            ConsolePrinter.PrintFieldBorders(false);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo movementDirectionKey = Console.ReadKey();

                    if (GameKeyAuthenticator.IsArrowKey(movementDirectionKey))
                    {
                        var newDirection = DirectionManager.GetNextDirection(movementDirectionKey);
                        var elementToDelete = PlayerRocketManager.GetElementToDelete(playerRocket, newDirection);

                        playerRocket = PlayerRocketManager.UpdateRocket(playerRocket, newDirection);
                        ConsolePrinter.DeleteElement(elementToDelete.Y, elementToDelete.X);
                    }
                }

                if (BallBounceValidator.IsHittingPlayerRocket(pongBall, ballDirection, playerRocket) && changeDirection)
                {
                    ballMovementSpeed -= (int)0.5;
                    HighScoreManager.IncreasePlayerScore(ballMovementSpeed);
                    ballDirection = DirectionManager.GetDiagonalDirection(pongBall, ballDirection);
                }
                else if (BallBounceValidator.IsHittingBorder(pongBall, ballDirection))
                {
                    ballDirection = DirectionManager.GetDiagonalDirection(pongBall, ballDirection);
                }
                else if (BallBounceValidator.IsHittingEdge(pongBall, ballDirection))
                {
                    ballDirection = DirectionManager.GetReversedDiagonalDirection(pongBall, ballDirection);
                }

                try
                {
                    ConsolePrinter.DeleteElement(pongBall.Y, pongBall.X);
                    pongBall = BallManager.MoveBall(pongBall, ballDirection);
                }
                catch (GameOverException ex)
                {
                    ConsolePrinter.PrintGameOverScreen(ex.Message);
                    goto GameOver;
                }

                changeDirection = true;

                ConsolePrinter.PrintPlayerScore(HighScoreManager.GetPlayerScore());
                ConsolePrinter.PrintPongBall(pongBall);
                ConsolePrinter.PrintPlayerRocket(playerRocket);

                Thread.Sleep(ballMovementSpeed);
            }

            GameOver:

            var playerChoice = Console.ReadKey();

            if (playerChoice.Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                goto ChooseDifficulty;
            }
            else
            {
                goto GameOver;
            }
        }
    }
}
