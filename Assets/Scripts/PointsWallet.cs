using System;
using UnityEngine;

public class PointsWallet : MonoBehaviour
{
    private decimal _currentPoints;

    public decimal CurrentPoints
    {
        get {  return _currentPoints; }
        private set
        {
            if (_currentPoints != value)
            {
                _currentPoints = value;
                PointsChanged?.Invoke(_currentPoints);
            }
        }
    }

    public static event Action<decimal> PointsChanged;

    private void OnEnable()
    {
        RegisterEvent();
    }

    private void OnDisable()
    {
        UnregisterEvent();
    }

    private void Start()
    {
        CurrentPoints = 0;
    }
    
    private void RegisterEvent()
    {
        ClickGeneratePoints.PointsGenerated += AddPoints;
    }

    private void UnregisterEvent()
    {
        ClickGeneratePoints.PointsGenerated += AddPoints;
    }

    private void AddPoints(decimal points)
    {
        CurrentPoints += points;
    }
}
