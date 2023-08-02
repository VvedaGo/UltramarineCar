using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class UiController : MonoBehaviour
    {
        [SerializeField] private GameObject _losePanel;
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private Car _car;

        private void Awake()
        {
            _car.ScoreChanged += SetScore;
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void MainMenu()
        {
            SceneManager.LoadScene("MenuScene");
        }

        public void OpenLosePanel()
        {
            _losePanel.SetActive(true);
        }

        public void SetScore(int score)
        {
            _score.text = $"Score : {score}";
        }
    }
}
