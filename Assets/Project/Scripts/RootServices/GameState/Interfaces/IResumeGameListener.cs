namespace Scripts.RootServices.GameState
{
    public interface IResumeGameListener : IGameStateProvider
    {
        void OnResumeGame();
    }
}