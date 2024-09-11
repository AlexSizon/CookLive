namespace MiniGames.Interfaces
{
    public interface IMiniGame
    {
        public void Start();
        public void GetMiniGameResult();
        public void Reset();
        public void Enable();
        public void Disable();
    }
}