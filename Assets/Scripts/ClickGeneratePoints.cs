using UnityEngine.UI;

public class ClickGeneratePoints : PointsBaseGenerator
{
    private readonly Button _clickButton;

    public ClickGeneratePoints(Button clickButton, decimal pointsPerSecond)
    {
        _pointsToGenerate = pointsPerSecond;
        _clickButton = clickButton;

        _clickButton.onClick.AddListener(GeneratePoints);
    }

    ~ClickGeneratePoints()
    {
        _clickButton.onClick.AddListener(GeneratePoints);
    }
}
