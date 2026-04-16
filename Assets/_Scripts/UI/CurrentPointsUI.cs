using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;

public class CurrentPointsUI : MonoBehaviour
{
    [Header("Ui Text Components")]
    [SerializeField] private TextMeshProUGUI _currentPointsTextMesh;
    [SerializeField] private TextMeshProUGUI _poinstPerSecondTextMesh;

    private void OnEnable()
    {
        PointsWallet.PointsChanged += UpdateCurrentPointsUI;
        PointsGeneratorHandler.PointsPerSecondChanged += UpdatePointsPerSecondUI;
    }

    private void OnDisable()
    {
        PointsWallet.PointsChanged -= UpdateCurrentPointsUI;
        PointsGeneratorHandler.PointsPerSecondChanged -= UpdatePointsPerSecondUI;
    }

    private void UpdateCurrentPointsUI(decimal value)
    {
        string format = GetTextFormat(value);
        _currentPointsTextMesh.text = value.ToString(format);
    }

    private void UpdatePointsPerSecondUI(decimal value)
    {
        string format = GetTextFormat(value);
        _poinstPerSecondTextMesh.text = $"{value.ToString(format)} /s";
    }

    private string GetTextFormat(decimal value)
    {
        bool hasDecimal = value % 1 != 0;
        return hasDecimal ? "N2" : "N0";
    }
}
