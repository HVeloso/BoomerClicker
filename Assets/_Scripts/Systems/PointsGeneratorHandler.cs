using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsGeneratorHandler : MonoBehaviour
{
    [SerializeField][Min(0)] private float _pointsPerClick;
    [SerializeField] private Button _clickButton;

    private ClickGeneratePoints _mainPointsGenerator;
    private Dictionary<string, PassivePointsGenerator> _pointsGenerator;

    public static Action<decimal> PointsPerSecondChanged;

    private void OnEnable()
    {
        TimerManager.SecondHasPassed += OnSecondHasPassed;
        PassiveGeneratorStore.GeneratorBought += AddPassiveGenerator;
    }

    private void OnDisable()
    {
        TimerManager.SecondHasPassed -= OnSecondHasPassed;
        PassiveGeneratorStore.GeneratorBought -= AddPassiveGenerator;
    }

    private void Awake()
    {
        _mainPointsGenerator = new(_clickButton, (decimal)_pointsPerClick);
        _pointsGenerator = new();
    }

    private void AddPassiveGenerator(PassiveGeneratorData generatorData)
    {
        string generatorName = generatorData.GeneratorName;

        if (_pointsGenerator.TryGetValue(generatorName, out PassivePointsGenerator generator))
        {
            generator.AddInstance();
        }
        else
        {
            PassivePointsGenerator newGenerator = new(generatorData.GeneratorName, generatorData.PointsPerSeconds);
            _pointsGenerator.Add(generatorName, newGenerator);
        }

        PointsPerSecondChanged?.Invoke(CalculateTotalPoinsPerSecond());
    }

    private void OnSecondHasPassed()
    {
        foreach ((string _, var value) in _pointsGenerator)
        {
            value.GeneratePassivePoints();
        }
    }

    private decimal CalculateTotalPoinsPerSecond()
    {
        decimal total = 0;

        foreach (PassivePointsGenerator generator in _pointsGenerator.Values)
        {
            total += generator.PoinsToGenerate;
        }

        return total;
    }
}
