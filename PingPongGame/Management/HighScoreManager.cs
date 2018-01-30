using System;

namespace PingPongGame.Management
{
    public static class HighScoreManager
    {
        private static int playerScore = 0;

        public static int GetPlayerScore() => playerScore;

        public static void IncreasePlayerScore(int ballMovementSpeed) => playerScore += (ballMovementSpeed * 1);

        public static void ResetPlayerPoints() => playerScore = 0;
    }
}
