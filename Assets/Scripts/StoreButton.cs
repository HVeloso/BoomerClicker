using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreButton : MonoBehaviour
{
    public int ButtonId { get; private set; }

    [SerializeField] private TextMeshProUGUI _nameTextMesh;
    [SerializeField] private TextMeshProUGUI _pointsPerSecondTextMesh;
    [SerializeField] private TextMeshProUGUI _generatorsQuantityTextMesh;
    [SerializeField] private TextMeshProUGUI _priceTextMesh;
    [Space]
    [SerializeField] private Button _storeButton;

    public decimal Price { get; private set; }

    private Action<int> StoreButtonClicked;

    private void OnEnable()
    {
        _storeButton.onClick.AddListener(OnStoreButtonClicked);
    }

    private void OnDisable()
    {
        _storeButton.onClick.RemoveListener(OnStoreButtonClicked);
    }

    public void UpdateButtonTexts(string name, int id, decimal points, int quantity, decimal price)
    {
        ButtonId = id;

        _nameTextMesh.text = name;
        _pointsPerSecondTextMesh.text = $"Points: {points}";
        _generatorsQuantityTextMesh.text = $"x{quantity}";

        _priceTextMesh.text = $"${price}";
        Price = price;
    }

    public void UpdateQuantity(int quantity)
    {
        _generatorsQuantityTextMesh.text = quantity.ToString();
    }

    public void UpdatePrice(decimal price)
    {
        _priceTextMesh.text = price.ToString();
        Price = price;
    }

    public void RegisterEvent(Action<int> onClick)
    {
        StoreButtonClicked += onClick;
    }

    public void UnregisterEvent(Action<int> onClick)
    {
        StoreButtonClicked -= onClick;
    }

    private void OnStoreButtonClicked()
    {
        StoreButtonClicked?.Invoke(ButtonId);
    }
}
