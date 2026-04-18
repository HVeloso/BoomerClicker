public class PassivePointsGenerator : PointsBaseGenerator
{
    public string GeneratorName { get; private set; }
    public int NumberOfInstances {  get; private set; }
    public decimal PoinsToGenerate => _pointsToGenerate;

    public PassivePointsGenerator(string generatorName, decimal pointsPerSecond)
        : base(pointsPerSecond)
    {
        NumberOfInstances = 1;
        GeneratorName = generatorName;

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
