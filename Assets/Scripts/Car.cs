using System;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private CarTriggerObserver _triggerObserver;
    [SerializeField] private CarMover _carMover;
    [SerializeField] private CarRotator _carRotator;
    [SerializeField] private WayBuilder _builder;
    private int _score;
    public Action<int> ScoreChanged;
    private void Awake()
    {
        _triggerObserver.Crash += Crash;
        _triggerObserver.OnScoreUp += AddScore;
        _triggerObserver.EnterOnCentre += EndTile;
    }

    private void EndTile()
    {
        _builder.EndTile();
    }
    private void Crash()
    {
        _carMover.enabled = false;
        _carRotator.enabled = false;
        FindObjectOfType<UiController>().OpenLosePanel();
    }

    public void AddScore(int score)
    {
        _score += score;
        ScoreChanged?.Invoke(_score);
    }
}
