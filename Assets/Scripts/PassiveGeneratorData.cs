using UnityEngine;

[CreateAssetMenu( fileName = "Generator", menuName = "Base Generator")]
public class PassiveGeneratorData : ScriptableObject
{
    [SerializeField] private string _generatorName;
    [SerializeField][Min(0)] private float _pointsPerSeconds;
    [SerializeField][Min(0)] private float _price;

    public string GeneratorName => _generatorName;
    public decimal PointsPerSeconds => (decimal)_pointsPerSeconds;
    public decimal BasePrice => (decimal)_price;
}
