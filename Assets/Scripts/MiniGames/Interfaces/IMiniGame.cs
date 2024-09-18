using System;

namespace MiniGames.Interfaces
{
    public interface IMiniGame
    {
        public void StartGame();
        public void ResetGame();
        public void MiniGameFailed(Action onFailed=null);
        public void MiniGamePassed(Action onPassed = null);
    }
}