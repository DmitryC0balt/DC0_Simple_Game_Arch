namespace Scripts.RootServices.MonoCash
{
    public interface IFixedProcessListener : ICashProvider
    {
        void OnFixedProcess();
    }
}