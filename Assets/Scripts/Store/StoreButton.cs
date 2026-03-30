using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameTextMesh;
    [SerializeField] private TextMeshProUGUI _pointsPerSecondTextMesh;
    [SerializeField] private TextMeshProUGUI _priceTextMesh;
    [Space]
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

    private void Refresh()
    {
        _nameTextMesh.text = _storeItem.Data.GeneratorName;
        _pointsPerSecondTextMesh.text = $"Points: {_storeItem.Data.PointsPerSeconds}";
        _priceTextMesh.text = $"${_storeItem.Data.BasePrice}";
    }

    private void OnStoreButtonClicked()
    {
        if (_buyCommand.Execute())
        {
            // Sucessful
        }
        else
        {
            // Fail
        }
    }
}
