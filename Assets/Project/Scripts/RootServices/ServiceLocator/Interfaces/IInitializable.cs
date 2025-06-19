namespace Scripts.RootServices.ServiceLocator
{
    public interface IInitializable : IGameServiceProvider
    {
        void OnInitialization();
    }
}