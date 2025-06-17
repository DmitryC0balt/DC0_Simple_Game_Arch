namespace Scripts.RootServices.GameState
{
    public interface IPauseGameListener : IGameStateProvider
    {
        void OnPauseGame();
    }
}