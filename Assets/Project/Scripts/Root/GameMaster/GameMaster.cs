using System.Collections.Generic;
using System.Threading.Tasks;
using Scripts.RootServices.GameState;
using Scripts.RootServices.MonoCash;
using Scripts.RootServices.ServiceLocator;
using UnityEngine;

namespace Scripts.Root
{
    public class GameMaster : MonoBehaviour
    {
        [SerializeField] private GameRoot _gameRoot;

        [Space(5)]
        [SerializeField] private bool _services;
        [SerializeField] private List<ServiceFormular> _serviceList;


        [Space(5)]
        [SerializeField] private bool _gameTasks;
        [SerializeField] private List<GameTask> _gameTasksList;

        [Space(5)]
        [SerializeField] private bool _advancedGameTasks;
        [SerializeField] private List<AdvancedGameTask> _advancedGameTasksList;


        async void Start()
        {
            await LoadGameRoot();


            if (_services)
            {

                foreach (var service in _serviceList)
                {

                    if (service.isActive)
                    {

                        if (service.provider is IGameServiceProvider gameServiceProvider)
                        {
                            _gameRoot.AddService(gameServiceProvider);
                        }

                        if (service.provider is IGameStateProvider gameStateProvider)
                        {
                            _gameRoot.AddStateListener(gameStateProvider);
                        }

                        if (service.provider is ICashProvider cashProvider)
                        {
                            _gameRoot.AddCashListener(cashProvider);
                        }

                    }

                }

            }


            if (_gameTasks)
            {
                foreach (var task in _gameTasksList)
                {
                    await task.RunTask();
                }
            }


            if (_advancedGameTasks)
            {
                foreach (var task in _advancedGameTasksList)
                {
                    await task.RunTask(_gameRoot);
                }
            }
        }


        private Task LoadGameRoot()
        {
            _gameRoot = GetComponent<GameRoot>();
            return Task.CompletedTask;
        }
    }


    [System.Serializable]
    public struct ServiceFormular
    {
        [SerializeField] private GameObject _provider;
        [SerializeField] private bool _isActive;


        public object provider => _provider;
        public bool isActive => _isActive;
    }
}