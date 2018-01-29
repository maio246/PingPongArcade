namespace PingPongGame.Management
{
    public static class HighScoreManager
    {
        private static int playerScore = 0;

        public static int GetPlayerScore() => playerScore;

        public static void IncreasePlayerScore() => playerScore += 50;
    }
}
