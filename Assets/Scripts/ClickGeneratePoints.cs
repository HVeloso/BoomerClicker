using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClickGeneratePoints : MonoBehaviour
{
    [SerializeField] private float _starterPointsPerClick;

    private decimal _pointsPerClick;
    private Button _clickButton;

    public static event Action<decimal> PointsGenerated;

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
        _clickButton = GetComponent<Button>();

        _pointsPerClick = (decimal)_starterPointsPerClick;
    }

    private void RegisterEvent()
    {
        _clickButton.onClick.AddListener(OnClick);
    }

    private void UnregisterEvent()
    {
        _clickButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        PointsGenerated?.Invoke(_pointsPerClick);
    }
}
