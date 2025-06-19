namespace Scripts.RootServices.ServiceLocator
{
    public interface IDestroyable : IGameServiceProvider
    {
        void OnDestroy();
    }
}