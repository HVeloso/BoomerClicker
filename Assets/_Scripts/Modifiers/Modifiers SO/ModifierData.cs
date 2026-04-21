using UnityEngine;

[CreateAssetMenu(fileName = "Modifier", menuName = "Generator Modifier")]
public class ModifierData : ScriptableObject
{
    [SerializeField] private string _modifierName;
    [SerializeField][Min(0)] private float _price;
    [Space]
    [SerializeField] private string _targetGenerator;
    [SerializeField] private ModifierType _modifierType;
    [SerializeField][Min(0)] private float _modifierValue;
    
    public string Name => _modifierName;
    public decimal Price => (decimal)_price;
    public string Target => _targetGenerator;
    public ModifierType Type => _modifierType;
    public float Value => _modifierValue;

    public PointsGeneratorModifier GetModifier()
    {
        return new(_targetGenerator, _modifierType, _modifierValue);
    }
}
