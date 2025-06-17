namespace Scripts.RootServices.GameState
{
    public interface IStopGameListener : IGameStateProvider
    {
        void OnStopGame();
    }
}