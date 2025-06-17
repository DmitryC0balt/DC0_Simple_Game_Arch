using System.Collections.Generic;

namespace Scripts.RootServices.MonoCash
{
    public class MonoCashService
    {
        private List<ICashProvider> _listenersList = new();

        public void AddListener(ICashProvider listener)
        {
            _listenersList.Add(listener);
        }


        public void RemoveListener(ICashProvider listener)
        {
            _listenersList.Remove(listener);
        }


        public void OnProcess()
        {
            foreach (var listener in _listenersList)
            {
                if (listener is IProcessListener processListener)
                {
                    processListener.OnProcess();
                }
            }
        }


        public void OnFixedProcess()
        {
            foreach (var listener in _listenersList)
            {
                if (listener is IFixedProcessListener fixedProcessListener)
                {
                    fixedProcessListener.OnFixedProcess();
                }
            }
        }


        public void OnPostProcess()
        {
            foreach (var listener in _listenersList)
            {
                if (listener is IPostProcessListener postProcessListener)
                {
                    postProcessListener.OnPostProcess();
                }
            }
            
        }
    }
}