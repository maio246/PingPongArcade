namespace PingPongGame.Management
{
    using PingPongGame.Exceptions;
    using PingPongGame.Validations;
    using PingPongGame.Visualisation;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Threading;

    public static class GamePlayManager
    {
        public static bool PlayersCountChoiceScreen()
        {
            ConsolePrinter.SinglePlayerScreen();
            ConsoleKeyInfo arrowKeyChoice = new ConsoleKeyInfo((char)38, ConsoleKey.UpArrow, false, false, false);

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

                arrowKeyChoice = playersChoise;
                playersChoise = Console.ReadKey();
            }

            return arrowKeyChoice.Key == ConsoleKey.UpArrow ? false : true;
        }

        public static ConsoleKeyInfo ChooseDifficulty()
        {
            while (true)
            {
                List<Point> playerRocket = new List<Point>();

                ConsolePrinter.StartScreen();

                ConsoleKeyInfo difficultyLevelKey = Console.ReadKey();

                if (!GameKeyAuthenticator.IsDifficultyLevelKey(difficultyLevelKey))
                {
                    Console.Clear();
                    continue;
                }

                return difficultyLevelKey;
            }
        }

        public static void GamePlay(int parsedDifficultyKey, bool areTwoPlayersSelected)
        {
            var changeDirection = false;

            var ballMovementSpeed = (5 * parsedDifficultyKey) + 50;
            var baseScore = ballMovementSpeed;

            //default ball starting position
            var pongBall = new Point(Console.BufferHeight / 2, 1);

            //default forward and up direction of the pong ball
            var ballDirection = DirectionManager.GetStartingDirection();

            while (true)
            {
                //read players key input
                ReadPlayersInputKey(areTwoPlayersSelected);

                var isHittingFirstPlayerRocket = BallBounceValidator.IsHittingPlayerRocket(pongBall, ballDirection, PlayerRocketManager.LeftPlayerRocket);
                var isHittingSecondPlayerRocket = BallBounceValidator.IsHittingPlayerRocket(pongBall, ballDirection, PlayerRocketManager.LeftPlayerRocket);

                if ((isHittingFirstPlayerRocket || isHittingSecondPlayerRocket) && changeDirection)
                {
                    ballMovementSpeed -= (int)0.5;

                    if (!areTwoPlayersSelected)
                    {
                        HighScoreManager.IncreasePlayerScore(baseScore);
                    }

                    ballDirection = DirectionManager.GetDiagonalDirection(pongBall, ballDirection);
                }
                else if (BallBounceValidator.IsHittingBorder(pongBall, ballDirection, areTwoPlayersSelected))
                {
                    ballDirection = DirectionManager.GetDiagonalDirection(pongBall, ballDirection);
                }
                else if (BallBounceValidator.IsHittingEdge(pongBall, ballDirection, areTwoPlayersSelected))
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
                    break;
                }

                changeDirection = true;

                ConsolePrinter.PrintPlayerRocket(PlayerRocketManager.LeftPlayerRocket);
                ConsolePrinter.PrintPongBall(pongBall);

                if (areTwoPlayersSelected)
                {
                    ConsolePrinter.PrintPlayerRocket(PlayerRocketManager.RightPlayerRocket);
                }
                else
                {
                    ConsolePrinter.PrintPlayerScore(HighScoreManager.GetPlayerScore);
                }

                Thread.Sleep(ballMovementSpeed);
            }
        }

        private static void ReadPlayersInputKey(bool areTwoPlayersSelected)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo movementDirectionKey = Console.ReadKey(true);

                Console.CursorVisible = false;
                if (GameKeyAuthenticator.IsArrowKey(movementDirectionKey))
                {
                    var newDirection = DirectionManager.GetNextDirection(movementDirectionKey);

                    var elementToDelete = new Point(0, 0);

                    if (areTwoPlayersSelected)
                    {
                        if (movementDirectionKey.Key == ConsoleKey.W || movementDirectionKey.Key == ConsoleKey.S)
                        {
                            elementToDelete = PlayerRocketManager.GetElementToDelete(PlayerRocketManager.LeftPlayerRocket, newDirection);
                            PlayerRocketManager.UpdateLeftPlayerRocket(newDirection);
                            ConsolePrinter.DeleteElement(elementToDelete.Y, elementToDelete.X);
                        }
                        else
                        {
                            elementToDelete = PlayerRocketManager.GetElementToDelete(PlayerRocketManager.RightPlayerRocket, newDirection);
                            PlayerRocketManager.UpdateRightPlayerRocket(newDirection);
                            ConsolePrinter.DeleteElement(elementToDelete.Y, elementToDelete.X);
                        }
                    }
                    else if (!areTwoPlayersSelected)
                    {
                        elementToDelete = PlayerRocketManager.GetElementToDelete(PlayerRocketManager.LeftPlayerRocket, newDirection);
                        PlayerRocketManager.UpdateLeftPlayerRocket(newDirection);
                        ConsolePrinter.DeleteElement(elementToDelete.Y, elementToDelete.X);
                    }
                }
            }
        }

        public static void GameOverMenu()
        {
            while (true)
            {
                var playerChoice = Console.ReadKey();

                if (playerChoice.Key == ConsoleKey.Spacebar)
                {
                    Console.Clear();
                    break;
                }
                if (playerChoice.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
