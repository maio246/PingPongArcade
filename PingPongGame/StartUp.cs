namespace PingPongGame
{
    using PingPongGame.GlobalConstants;
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

                var areTwoPlayersSelected = GamePlayManager.PlayersCountChoiceScreen();

                ConsoleKeyInfo difficultyLevelKey = GamePlayManager.ChooseDifficulty();
                Console.CursorVisible = false;

                var parsedDifficultyKey = int.Parse(difficultyLevelKey.KeyChar.ToString());

                ConsolePrinter.PrintFieldBorders(areTwoPlayersSelected);

                GamePlayManager.GamePlay(parsedDifficultyKey, areTwoPlayersSelected);

                GamePlayManager.GameOverMenu();
            }
        }
    }
}
