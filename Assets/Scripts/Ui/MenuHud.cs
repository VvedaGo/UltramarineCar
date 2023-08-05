using Infrastructure.GameStateMachine;
using Infrastructure.Services;
using StaticData;
using TMPro;
using UnityEngine;

namespace Ui
{
    public class MenuHud:MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _bestScore;
        [SerializeField] private TextMeshProUGUI _coinsCount;
       
        private SceneLoader _sceneLoader;
        private GameStateMachine _gameSateMachine;
        private WorldData _worldData;

        public void Initialize(SceneLoader sceneLoader,GameStateMachine gameStateMachine,WorldData worldData)
        {
            _sceneLoader = sceneLoader;
            _gameSateMachine = gameStateMachine;
            _worldData = worldData;
            SetBestScore(_worldData.PlayerProgress.MaxScore);
            SetCoinsCount(_worldData.PlayerProgress.CountCoins);
        }

        private void SetBestScore(int score)
        {
            _bestScore.text = $"Best Score : {score}";
        }

        private void SetCoinsCount(int count)
        {
            _coinsCount.text = $"Coins : {count}";
        }

        public void Play()
        {
            _sceneLoader.Load("GameScene",GameSceneLoaded);
        }

        private void GameSceneLoaded()
        {
            _gameSateMachine.Enter<GameLoadInfoState>();
        }
    }
}