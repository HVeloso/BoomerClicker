using System;

public abstract class PointsBaseGenerator
{
    protected decimal _pointsToGenerate;
    public static event Action<decimal> PointsGenerated;

    protected void GeneratePoints()
    {
        PointsGenerated?.Invoke(_pointsToGenerate);
    }
}
