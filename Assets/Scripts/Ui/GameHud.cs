using Game.Car;
using Infrastructure.GameStateMachine;
using Infrastructure.Services;
using StaticData;
using TMPro;
using UnityEngine;

namespace Ui
{
   public class GameHud : MonoBehaviour
   {
      [SerializeField] private LosePanel _losePanel;
      [SerializeField] private RelivePanel _relivePanel;
      [SerializeField] private TextMeshProUGUI _coinCount;
      [SerializeField] private TextMeshProUGUI _scoreCount;
   
      private SceneLoader _sceneLoader;
      private WorldData _worldData;
      private GameStateMachine _gameStateMachine;
      private Car _car;

      public void Initialize(GameStateMachine gameStateMachine,SceneLoader sceneLoader,WorldData worldData,Car car)
      {
         _gameStateMachine = gameStateMachine;
         _sceneLoader = sceneLoader;
         _worldData = worldData;
         _losePanel.Initialize(_sceneLoader,_gameStateMachine);
         
         UpdateCoinsCount(_worldData.PlayerProgress.CountCoins);

         _car = car;
         _car.ScoreChanged += UpdateCoinsCount;
         _car.CoinsChanged += UpdateScore;
         _car.Lose += Lose;
      }

      private void UpdateCoinsCount(int count)
      {
         _coinCount.text = $"Coins : {count}";
      }
      private void UpdateScore(int score)
      {
         _scoreCount.text = $"Score : {score}";
      }

      private void Lose()
      {
         _relivePanel.Open();
         _relivePanel.StartTimer();
      }

      public void Relive()
      {
         _car.Relive();
      }
   

   
   }
}