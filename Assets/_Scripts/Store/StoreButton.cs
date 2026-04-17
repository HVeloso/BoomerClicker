using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StoreButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameTextMesh;
    [SerializeField] private TextMeshProUGUI _pointsPerSecondTextMesh;
    [SerializeField] private TextMeshProUGUI _priceTextMesh;
    [SerializeField] private TextMeshProUGUI _quantityTextMesh;
    [Space]
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private Button _storeButton;

    private BuyGeneratorCommand _buyCommand;
    private GeneratorStoreItem _storeItem;

    private void OnEnable()
    {
        _storeButton.onClick.AddListener(OnStoreButtonClicked);
    }

    private void OnDisable()
    {
        _storeButton.onClick.RemoveListener(OnStoreButtonClicked);
    }

    public void Initialize(GeneratorStoreItem storeItem, BuyGeneratorCommand command)
    {
        _storeItem = storeItem;
        _buyCommand = command;

        Refresh();
    }

    public void OnCurrentPointsChanged(decimal currentPoints)
    {
        if (currentPoints < _storeItem.CurrentPrice) DeactiveItem();
        else ActiveItem();
    }

    private void OnStoreButtonClicked()
    {
        if (_buyCommand.Execute()) Refresh();
    }

    private void Refresh()
    {
        _nameTextMesh.text = _storeItem.Data.GeneratorName;
        _pointsPerSecondTextMesh.text = $"Points: {_storeItem.Data.PointsPerSeconds:N0}";
        _priceTextMesh.text = $"${_storeItem.CurrentPrice:N2}";
        _quantityTextMesh.text = $"x{_storeItem.BoughtQuantity}";
    }

    private void ActiveItem()
    {
        _storeButton.interactable = true;

        Color bgColor = _backgroundImage.color;
        bgColor.a = 1;
        _backgroundImage.color = bgColor;
    }

    private void DeactiveItem()
    {
        _storeButton.interactable = false;

        Color bgColor = _backgroundImage.color;
        bgColor.a = 0.5f;
        _backgroundImage.color = bgColor;
    }
}
