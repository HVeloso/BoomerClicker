using Unity.VisualScripting;

public class PassivePointsGenerator : PointsBaseGenerator
{
    public string GeneratorName {  get; private set; }
    public int NumberOfInstances {  get; private set; }

    private readonly decimal _basePointsPerSecond;

    public PassivePointsGenerator(string generatorName, decimal pointsPerSecond)
    {
        NumberOfInstances = 1;
        GeneratorName = generatorName;
        _basePointsPerSecond = pointsPerSecond;

        RecalculatePointsPerSecond();
    }

    public void GeneratePassivePoints()
    {
        GeneratePoints();
    }

    public void AddInstance()
    {
        NumberOfInstances++;
        RecalculatePointsPerSecond();
    }

    private void RecalculatePointsPerSecond()
    {
        _pointsToGenerate = _basePointsPerSecond * NumberOfInstances;
    }
}
