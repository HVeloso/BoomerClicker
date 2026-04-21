using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModifierItemButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameTextMesh;
    [SerializeField] private TextMeshProUGUI _priceTextMesh;
    [SerializeField] private TextMeshProUGUI _modTargetNameTextMesh;
    [SerializeField] private TextMeshProUGUI _modValueTextMesh;
    [Space]
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private Button _storeButton;

    private BuyModifierCommand _buyCommand;
    private ModifierStoreItem _storeItem;

    private void OnEnable()
    {
        _storeButton.onClick.AddListener(OnStoreButtonClicked);
    }

    private void OnDisable()
    {
        _storeButton.onClick.RemoveListener(OnStoreButtonClicked);
    }

    public void Initialize(ModifierStoreItem soreItem, BuyModifierCommand command)
    {
        _storeItem = soreItem;
        _buyCommand = command;

        Refresh();
    }
    
    private void Refresh()
    {
        _nameTextMesh.text = _storeItem.Data.Name;
        _priceTextMesh.text = $"${_storeItem.CurrentPrice:N2}";
        _modTargetNameTextMesh.text = _storeItem.Data.Target;
        _modValueTextMesh.text = $"+ {GetModValue()}";
    }

    private string GetModValue()
    {
        if (_storeItem.Data.Type == ModifierType.Percentage)
        {
            float modValue = _storeItem.Data.Value * 100f;
            return $"{modValue}%";
        }

        return _storeItem.Data.Value.ToString("N0");
    }

    private void OnStoreButtonClicked()
    {
        if (_buyCommand.Execute()) Refresh();
    }
    
    public void OnCurrentPointsChanged(decimal currentPoints)
    {
        if (currentPoints < _storeItem.CurrentPrice) DeactiveItem();
        else ActiveItem();
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
