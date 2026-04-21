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

        RecalculateModifiers();
    }

    public void GeneratePassivePoints()
    {
        GeneratePoints();
    }

    public void AddInstance()
    {
        NumberOfInstances++;
        RecalculateModifiers();
    }

    protected override void RecalculateModifiers()
    {
        base.RecalculateModifiers();
        _pointsToGenerate *= NumberOfInstances;
    }
}
