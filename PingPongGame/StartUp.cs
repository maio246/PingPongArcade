namespace PingPongGame
{
    using PingPongGame.Management;
    using PingPongGame.Visualisation;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            while (true)
            {
                Console.CursorVisible = false;

                EnvironmentSettings.SetEnvironment();
                HighScoreManager.ResetPlayerPoints();

                var areTwoPlayersSelected = GamePlayManager.PlayersCountChoiceScreen();

                ConsoleKeyInfo difficultyLevelKey = GamePlayManager.ChooseDifficulty();
                Console.CursorVisible = false;

                var parsedDifficultyKey = int.Parse(difficultyLevelKey.KeyChar.ToString());

                PlayerRocketManager.CreatePlayerRockets(parsedDifficultyKey, areTwoPlayersSelected);

                Console.Clear();
                ConsolePrinter.PrintFieldBorders(areTwoPlayersSelected);

                GamePlayManager.GamePlay(parsedDifficultyKey, areTwoPlayersSelected);

                GamePlayManager.GameOverMenu();
            }
        }
    }
}
