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
        _currentPointsTextMesh.text = value.ToString();
    }
}
