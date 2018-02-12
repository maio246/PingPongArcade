using System;

namespace PingPongGame.Management
{
    public static class HighScoreManager
    {
        private static int playerScore = 0;

        public static int GetPlayerScore
        {
            get
            {
                return playerScore;
            }
        }

        public static void IncreasePlayerScore(int points) => playerScore += points;

        public static void ResetPlayerPoints() => playerScore = 0;
    }
}
