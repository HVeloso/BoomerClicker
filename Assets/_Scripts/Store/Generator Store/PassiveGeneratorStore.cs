using System;
using System.Collections.Generic;
using UnityEngine;

public class PassiveGeneratorStore : MonoBehaviour
{
    [SerializeField] private PointsWallet _playerWallet;
    [Space]
    [SerializeField] private List<PassiveGeneratorData> _passiveGeneratorsDatas;
    [Space]
    [SerializeField] private GameObject _storeButtonPrefab;
    [SerializeField] private RectTransform _storeButtonsHolder;

    private readonly List<GeneratorItemButton> _storeButtons = new();

    public static event Action<PassiveGeneratorData> GeneratorBought;

    private void OnEnable()
    {
        PointsWallet.PointsChanged += OnPointsChanged;
    }

    private void OnDisable()
    {
        PointsWallet.PointsChanged -= OnPointsChanged;
    }

    private void Awake()
    {
        // Alterar isso pra quando o jogador abrir a loja.
        InitializeStoreButtons();
    }

    private void InitializeStoreButtons()
    {
        foreach (PassiveGeneratorData generatorData in _passiveGeneratorsDatas)
        {
            GameObject storeButtonObj = Instantiate(_storeButtonPrefab, _storeButtonsHolder);
            GeneratorItemButton storeButton = storeButtonObj.GetComponent<GeneratorItemButton>();

            GeneratorStoreItem storeItem = new(generatorData);
            storeItem.Purchased += OnItemPurchased;

            BuyGeneratorCommand command = new(_playerWallet, storeItem);
            storeButton.Initialize(storeItem, command);

            _storeButtons.Add(storeButton);
            storeButton.OnCurrentPointsChanged(_playerWallet.CurrentPoints);
        }
    }

    private void OnItemPurchased(GeneratorStoreItem item)
    {
        GeneratorBought?.Invoke(item.Data);
    }

    private void OnPointsChanged(decimal value)
    {
        _storeButtons.ForEach(x => x.OnCurrentPointsChanged(value));
    }
}
