using System;

[Serializable]
public struct PointsGeneratorModifier
{
    public string Target { get; private set; }
    public ModifierType Type { get; private set; }
    public float Value { get; private set; }

    public PointsGeneratorModifier(string targetGenerator, ModifierType modifierType, float modValue)
    {
        Target = targetGenerator;
        Type = modifierType;
        Value = modValue;
    }
}
