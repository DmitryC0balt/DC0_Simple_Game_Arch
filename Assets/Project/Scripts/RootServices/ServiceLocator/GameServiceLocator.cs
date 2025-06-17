using System.Collections.Generic;

namespace Scripts.RootServices.ServiceLocator
{
    public class GameServiceLocator
    {
        private List<IGameServiceProvider> _serviceList = new();

        public void AddService(IGameServiceProvider service)
        {
            _serviceList.Add(service);
        }


        public void RemoveService(IGameServiceProvider service)
        {
            _serviceList.Remove(service);
        }


        public Service GetService<Service>()
        {
            foreach (var service in _serviceList)
            {
                if (service is Service targetService)
                {
                    return targetService;
                }
            }

            throw new System.Exception("There is no service");
        }

    }
}