using System;
using UnityEngine;

namespace Game.Car
{
    public class Car : MonoBehaviour
    {
        [SerializeField] private CarTriggerObserver _triggerObserver;
        [SerializeField] private RoadDetector _roadDetector;
        [SerializeField] private CarMover _carMover;
        [SerializeField] private CarRotator _carRotator;
        
        private WayBuilder _builder;
        private int _score;
        private int _coinsCount;
        public Action<int> ScoreChanged;
        public Action<int> CoinsChanged;
        public Action Lose;
        
        public void Initialize(WayBuilder builder)
        {
            _builder = builder;
            _triggerObserver.Crash += Crash;
            _triggerObserver.OnScoreUp += AddScore;
            _triggerObserver.OnCoinUp += AddCoin;
            _triggerObserver.EnterOnCentre += EndTile;
            _roadDetector.FromRoad += Crash;
        }
        private void EndTile()
        {
            _builder.EndTile();
        }
        private void Crash()
        {
            _carMover.enabled = false;
            _carRotator.enabled = false;
            Lose?.Invoke();
           // FindObjectOfType<UiController>().OpenLosePanel();
        }

        public void AddScore(int score)
        {
            _score += score;
            ScoreChanged?.Invoke(_score);
        }

        public void AddCoin(int count)
        {
            _coinsCount += count;
            CoinsChanged?.Invoke(_coinsCount);
        }
    }
}
