using System;
using System.Collections.Generic;
using UnityEngine;

public class PassiveGeneratorStore : MonoBehaviour
{
    [SerializeField] private List<PassiveGeneratorData> _passiveGeneratorsDatas;
    [SerializeField] private GameObject _storeButtonPrefab;
    [Space]
    [SerializeField] private PointsWallet _playerWallet;
    [Space]
    [SerializeField] private RectTransform _storeButtonsHolder;

    private readonly List<GeneratorStoreItem> _storeItems = new();

    public static event Action<PassiveGeneratorData> GeneratorBought;

    private void Awake()
    {
        InitializeStoreButtons();
    }

    private void InitializeStoreButtons()
    {
        foreach (PassiveGeneratorData generatorData in _passiveGeneratorsDatas)
        {
            GeneratorStoreItem storeItem = new(generatorData);
            storeItem.Purchased += OnItemPurchased;

            GameObject storeButtonObj = Instantiate(_storeButtonPrefab, _storeButtonsHolder);
            StoreButton storeButton = storeButtonObj.GetComponent<StoreButton>();

            BuyGeneratorCommand command = new(_playerWallet, storeItem);
            storeButton.Initialize(storeItem, command);
        }
    }

    private void OnItemPurchased(GeneratorStoreItem item)
    {
        GeneratorBought?.Invoke(item.Data);
    }
}
