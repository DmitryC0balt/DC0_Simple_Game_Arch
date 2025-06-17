using Scripts.RootServices.GameState;
using Scripts.RootServices.MonoCash;
using Scripts.RootServices.ServiceLocator;
using UnityEngine;

namespace Scripts.Root
{
    public class GameRoot : MonoBehaviour
    {
        /// <summary>
        /// 
        /// </summary>


        private GameServiceLocator _serviceLocator = new();
        private GameStateService _stateService = new();
        private MonoCashService _cashService = new();


        #region GAME_SERVICE_LOCATOR

        public void AddService(IGameServiceProvider service) => _serviceLocator.AddService(service);

        public void RemoveService(IGameServiceProvider service) => _serviceLocator.RemoveService(service);

        public Service GetService<Service>() => _serviceLocator.GetService<Service>();

        #endregion



        #region GAME_STATE_SERVICE

        public void AddStateListener(IGameStateProvider listener) => _stateService.AddListener(listener);

        public void RemoveStateListener(IGameStateProvider listener) => _stateService.RemoveListener(listener);

        [ContextMenu("Start game")]
        public void OnStartGame() => _stateService.OnStartGame();

        [ContextMenu("Stop game")]
        public void OnStopGame() => _stateService.OnStopGame();

        [ContextMenu("Pause")]
        public void OnPauseGame() => _stateService.OnPauseGame();

        [ContextMenu("Resume")]
        public void OnResumeGame() => _stateService.OnResumeGame();

        #endregion



        #region MONO_CASH_SERVICE

        public void AddCashListener(ICashProvider listener) => _cashService.AddListener(listener);

        public void RemoveCashListener(ICashProvider listener) => _cashService.RemoveListener(listener);

        private void Update() => _cashService.OnProcess();

        private void FixedUpdate() => _cashService.OnFixedProcess();

        private void LateUpdate() => _cashService.OnPostProcess();

        #endregion
    }
}