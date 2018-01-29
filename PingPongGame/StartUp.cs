namespace PingPongGame
{
    using System;
    using System.Drawing;
    using System.Threading;
    using System.Collections.Generic;
    using PingPongGame.Management;
    using PingPongGame.Exceptions;
    using PingPongGame.Visualisation;

    public class StartUp
    {
        private static bool changeDirection;

        public static void Main()
        {
            ChooseDifficulty:

            Environment.SetEnvironment();
            List<Point> playerRocket = new List<Point>();

            ConsolePrinter.StartScreen();

            ConsoleKeyInfo difficultyLevelKey = Console.ReadKey();

            if (!GameKeyAuthenticator.IsDifficultyLevelKey(difficultyLevelKey))
            {
                Console.Clear();
                goto ChooseDifficulty;
            }

            var keyToString = int.Parse(difficultyLevelKey.KeyChar.ToString());
            playerRocket = PlayerRocketManager.CreatePlayerRocket(keyToString);

            Console.Clear();
            Console.CursorVisible = false;
            changeDirection = false;

            //default forward and up direction of the pong ball
            var ballDirection = DirectionManager.GetStartingDirection();

            //default ball starting position
            var pongBall = new Point(Console.BufferHeight / 2, 1);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo movementDirectionKey = Console.ReadKey();

                    if (GameKeyAuthenticator.IsArrowKey(movementDirectionKey))
                    {
                        var newDirection = DirectionManager.GetNextDirection(movementDirectionKey);

                        playerRocket = PlayerRocketManager.UpdateRocket(playerRocket, newDirection);
                    }

                    Console.Clear();
                }

                if (BallManager.IsHittingPlayerRocket(pongBall, ballDirection, playerRocket) && changeDirection)
                {
                    HighScoreManager.IncreasePlayerScore();
                    ballDirection = DirectionManager.GetDiagonalDirection(pongBall, ballDirection);
                }
                else if (BallManager.IsHittingBorder(pongBall, ballDirection))
                {
                    ballDirection = DirectionManager.GetDiagonalDirection(pongBall, ballDirection);
                }
                else if (BallManager.IsHittingEdge(pongBall, ballDirection))
                {
                    ballDirection = DirectionManager.GetReversedDiagonalDirection(pongBall, ballDirection);
                }

                try
                {
                    pongBall = BallManager.MoveBall(pongBall, ballDirection);
                }
                catch (GameOverException ex)
                {
                    ConsolePrinter.PrintGameOverScreen(ex.Message);
                    goto GameOver;
                }

                changeDirection = true;
                Console.Clear();
                ConsolePrinter.PrintPlayerScore(HighScoreManager.GetPlayerScore());
                ConsolePrinter.PrintPongBall(pongBall);
                ConsolePrinter.PrintPlayerRocket(playerRocket);

                Thread.Sleep(50);
            }

            GameOver:

            var playerChoice = Console.ReadKey();

            if (playerChoice.Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                goto ChooseDifficulty;
            }
        }
    }
}
