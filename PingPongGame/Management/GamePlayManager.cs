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

            ConsoleKeyInfo playersChoise = Console.ReadKey(true);

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
                playersChoise = Console.ReadKey(true);
            }

            return arrowKeyChoice.Key == ConsoleKey.UpArrow ? false : true;
        }

        public static ConsoleKeyInfo ChooseDifficulty()
        {
            while (true)
            {
                List<Point> playerRocket = new List<Point>();

                ConsolePrinter.StartScreen();

                ConsoleKeyInfo difficultyLevelKey = Console.ReadKey(true);

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
            PlayerRocketManager.CreatePlayerRockets(parsedDifficultyKey, areTwoPlayersSelected);

            if (!areTwoPlayersSelected)
            {
                HighScoreManager.ResetPlayerPoints();
            }

            var changeDirection = false;

            var ballMovementSpeed = (5 * parsedDifficultyKey) + 50;
            var baseScore = ballMovementSpeed;

            //default ball starting position
            var pongBall = new Point(Console.BufferHeight / 2, 1);

            //default forward and up direction of the pong ball
            var ballDirection = DirectionManager.GetStartingDirection();

            while (true)
            {
                ReadPlayersInputKey(areTwoPlayersSelected);

                var isHittingFirstPlayerRocket = BallBounceValidator.IsHittingPlayerRocket(pongBall, ballDirection, PlayerRocketManager.LeftPlayerRocket);
                bool isHittingSecondPlayerRocket = false;

                if (areTwoPlayersSelected)
                {
                    isHittingSecondPlayerRocket = BallBounceValidator.IsHittingPlayerRocket(pongBall, ballDirection, PlayerRocketManager.RightPlayerRocket);
                }

                if ((isHittingFirstPlayerRocket || isHittingSecondPlayerRocket) && changeDirection)
                {
                    ballMovementSpeed -= (int)0.5;

                    if (!areTwoPlayersSelected)
                    {
                        HighScoreManager.IncreasePlayerScore(baseScore);
                    }
                    else if (BallBounceValidator.IsHittingEdge(pongBall, ballDirection, areTwoPlayersSelected))
                    {
                        ballDirection = DirectionManager.GetReversedDiagonalDirection(pongBall, ballDirection);
                    }

                    ballDirection = DirectionManager.GetDiagonalDirection(pongBall, ballDirection);
                }
                else if (BallBounceValidator.IsHittingBorder(pongBall, ballDirection, areTwoPlayersSelected))
                {
                    ballDirection = DirectionManager.GetDiagonalDirection(pongBall, ballDirection);
                }

                try
                {
                    ConsolePrinter.DeleteElement(pongBall.Y, pongBall.X);
                    pongBall = BallManager.MoveBall(pongBall, ballDirection);
                }
                catch (GameOverException ex)
                {
                    if (areTwoPlayersSelected)
                    {
                    ConsolePrinter.PrintGameOverScreen(ex.Message, ex.InnerException.Message);
                    }
                    else
                    {
                        ConsolePrinter.PrintGameOverScreen(ex.Message);
                    }

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

        public static void GameOverMenu()
        {
            while (true)
            {
                var playerChoice = Console.ReadKey(true);

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
                            elementToDelete = UpdateLeftRocket(true, newDirection);
                        }
                        else
                        {
                            elementToDelete = UpdateLeftRocket(false, newDirection);
                        }
                    }
                    else if (!areTwoPlayersSelected)
                    {
                        elementToDelete = UpdateLeftRocket(true, newDirection);
                    }
                }
            }
        }

        private static Point UpdateLeftRocket(bool isLeftRocketForUpdate, Point newDirection)
        {
            Point elementToDelete = new Point(0, 0);
            if (!isLeftRocketForUpdate)
            {
                elementToDelete = PlayerRocketManager.GetElementToDelete(PlayerRocketManager.RightPlayerRocket, newDirection);
                PlayerRocketManager.UpdateRightPlayerRocket(newDirection);
            }
            else
            {
                elementToDelete = PlayerRocketManager.GetElementToDelete(PlayerRocketManager.LeftPlayerRocket, newDirection);
                PlayerRocketManager.UpdateLeftPlayerRocket(newDirection);
            }

            ConsolePrinter.DeleteElement(elementToDelete.Y, elementToDelete.X);
            return elementToDelete;
        }

    }
}
