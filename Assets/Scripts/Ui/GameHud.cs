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
      [SerializeField] private TextMeshProUGUI _coinCount;
   
      private SceneLoader _sceneLoader;
      private WorldData _worldData;
      private GameStateMachine _gameStateMachine;

      public void Initialize(GameStateMachine gameStateMachine,SceneLoader sceneLoader,WorldData worldData,Car car)
      {
         _gameStateMachine = gameStateMachine;
         _sceneLoader = sceneLoader;
         _worldData = worldData;
         _losePanel.Initialize(_sceneLoader,_gameStateMachine);
         UpdateCoinsCount(_worldData.PlayerProgress.CountCoins);
         car.ScoreChanged += UpdateCoinsCount;
      }

      private void UpdateCoinsCount(int count)
      {
         _coinCount.text = $"Coins : {count}";
      }
   

   
   }
}