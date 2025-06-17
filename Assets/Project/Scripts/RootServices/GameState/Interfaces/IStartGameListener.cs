namespace Scripts.RootServices.GameState
{
    public interface IStartGameListener : IGameStateProvider
    {
        void OnStartGame();
    }
}