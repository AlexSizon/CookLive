namespace MiniGames.Interfaces
{
    public interface IMiniGame
    {
        public void StartGame();
        public void GetMiniGameResult();
        public void ResetGame();
        public void MiniGameFailed();
    }
}