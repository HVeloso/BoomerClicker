using System.Globalization;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CurrentPointsUI : MonoBehaviour
{
    private TextMeshProUGUI _currentPointsTextMesh;

    private void OnEnable()
    {
        RegisterEvent();
    }

    private void OnDisable()
    {
        UnregisterEvent();
    }

    private void Awake()
    {
        _currentPointsTextMesh = GetComponent<TextMeshProUGUI>();
    }

    private void RegisterEvent()
    {
        PointsWallet.PointsChanged += UpdateUI;
    }

    private void UnregisterEvent()
    {
        PointsWallet.PointsChanged -= UpdateUI;
    }

    private void UpdateUI(decimal value)
    {
        string textFormat = CheckNumberHasDecimals(value) ? "N2" : "N0";

        _currentPointsTextMesh.text = value.ToString(textFormat);
    }

    private bool CheckNumberHasDecimals(decimal value)
    {
        // If TRUE the number has decimals
        // If FALSE the number has not decimals

        return value % 1 != 0;
    }
}
