using System;
using UnityEngine;

public class PointsWallet : MonoBehaviour
{
    private decimal _currentPoints;
    
    public decimal CurrentPoints
    {
        get { return _currentPoints; }
        private set
        {
            if (_currentPoints == value) return;

            _currentPoints = value;
            PointsChanged?.Invoke(_currentPoints);
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
        PointsBaseGenerator.PointsGenerated += AddPoints;
    }

    private void UnregisterEvent()
    {
        PointsBaseGenerator.PointsGenerated -= AddPoints;
    }

    private void AddPoints(decimal points)
    {
        CurrentPoints += points;
    }

    public bool TrySpendPoints(decimal points)
    {
        if (points > _currentPoints) return false;

        CurrentPoints -= points;
        return true;
    }
}
