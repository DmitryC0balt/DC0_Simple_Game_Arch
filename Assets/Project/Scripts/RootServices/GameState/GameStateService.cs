using System.Collections.Generic;

namespace Scripts.RootServices.GameState
{
    public class GameStateService
    {
        private List<IGameStateProvider> _listenersList = new();
        private GameStateEnum _currentState = GameStateEnum.STOPPED;

        public void AddListener(IGameStateProvider listener)
        {
            _listenersList.Add(listener);
        }


        public void RemoveListener(IGameStateProvider listener)
        {
            _listenersList.Remove(listener);
        }


        public void OnStartGame()
        {
            if (_currentState != GameStateEnum.STOPPED) return;

            _currentState = GameStateEnum.STARTED;

            foreach (var listener in _listenersList)
            {
                if (listener is IStartGameListener startGameListener)
                {
                    startGameListener.OnStartGame();
                }
            }
        }


        public void OnStopGame()
        {
            if (_currentState != GameStateEnum.PAUSED) return;

            _currentState = GameStateEnum.STOPPED;

            foreach (var listener in _listenersList)
            {
                if (listener is IStopGameListener stopGameListener)
                {
                    stopGameListener.OnStopGame();
                }
            }
        }


        public void OnPauseGame()
        {
            if (_currentState != GameStateEnum.STARTED) return;

            _currentState = GameStateEnum.PAUSED;

            foreach (var listener in _listenersList)
            {
                if (listener is IPauseGameListener pauseGameListener)
                {
                    pauseGameListener.OnPauseGame();
                }
            }
        }


        public void OnResumeGame()
        {
            if (_currentState != GameStateEnum.PAUSED) return;

            _currentState = GameStateEnum.STARTED;

            foreach (var listener in _listenersList)
            {
                if (listener is IResumeGameListener resumeGameListener)
                {
                    resumeGameListener.OnResumeGame();
                }
            }
        }
    }


    public enum GameStateEnum
    {
        STARTED,
        PAUSED,
        STOPPED
    }
}