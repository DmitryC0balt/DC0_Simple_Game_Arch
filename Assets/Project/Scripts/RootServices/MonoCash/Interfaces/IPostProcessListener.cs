namespace Scripts.RootServices.MonoCash
{
    public interface IPostProcessListener : ICashProvider
    {
        void OnPostProcess();
    }
}