namespace Scripts.RootServices.MonoCash
{
    public interface IProcessListener : ICashProvider
    {
        void OnProcess();
    }
}