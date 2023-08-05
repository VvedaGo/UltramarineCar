using Infrastructure.GameStateMachine;
using Infrastructure.Services;
using TMPro;
using UnityEngine;

namespace Ui
{
    public class LosePanel:MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentScore;
        [SerializeField] private TextMeshProUGUI _bestScore;
        private SceneLoader _sceneLoader;
        private GameStateMachine _gameStateMachine;

        public void Initialize(SceneLoader sceneLoader,GameStateMachine gameStateMachine)
        {
            _sceneLoader = sceneLoader;
            _gameStateMachine = gameStateMachine;
        }
        public void LoadBestScore(int count)
        {
            _bestScore.text = $"Best Score : {count}";
        }

        public void LoadCurrentScore(int score)
        {
            _currentScore.text = $"Your Score : {score}";
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void ReLife()
        {
        
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        public void LookAdToReLife()
        {
        
        }

        public void MainMenu()
        {
        
        }
    }
}