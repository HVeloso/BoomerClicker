using System;
using System.Collections.Generic;

public abstract class PointsBaseGenerator
{
    protected decimal _basePointsPerSecond;
    protected decimal _pointsToGenerate;

    protected readonly List<PointsGeneratorModifier> _modifiers = new();

    public static event Action<decimal> PointsGenerated;

    public PointsBaseGenerator(decimal pointsPerSecond)
    {
        _basePointsPerSecond = pointsPerSecond;
        RecalculateModifiers();
    }

    protected void GeneratePoints()
    {
        PointsGenerated?.Invoke(_pointsToGenerate);
    }

    public void AddModifier(PointsGeneratorModifier modifier)
    {
        _modifiers.Add(modifier);
        RecalculateModifiers();
    }
    
    protected virtual void RecalculateModifiers()
    {
        decimal totalFlat = 0;
        decimal totalPercentage = 0;
        
        foreach (PointsGeneratorModifier modifier in _modifiers)
        {
            if (modifier.Type == ModifierType.Percentage) totalPercentage = (decimal)modifier.Value;
            else if (modifier.Type == ModifierType.Flat) totalFlat = (decimal)modifier.Value;
        }
        
        _pointsToGenerate = (_basePointsPerSecond + totalFlat) * (1 + totalPercentage);
    }
}
