using System;
using System.Collections.Generic;
using UnityEngine;

public class ModifierStoreController : MonoBehaviour
{
    [SerializeField] private PointsWallet _playerWallet;
    [Space]
    [SerializeField] private List<ModifierData> _modifiersDatas;
    [Space]
    [SerializeField] private GameObject _modifierButtonPrefab;
    [SerializeField] private RectTransform _modifierButtonsHolder;

    private readonly List<ModifierItemButton> _storeButtons = new();

    public static event Action<PointsGeneratorModifier> ModifierBought;
    
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
        foreach (ModifierData generatorData in _modifiersDatas)
        {
            GameObject storeButtonObj = Instantiate(_modifierButtonPrefab, _modifierButtonsHolder);
            ModifierItemButton storeButton = storeButtonObj.GetComponent<ModifierItemButton>();

            ModifierStoreItem storeItem = new(generatorData);
            storeItem.Purchased += OnItemPurchased;

            BuyModifierCommand command = new(_playerWallet, storeItem);
            storeButton.Initialize(storeItem, command);

            _storeButtons.Add(storeButton);
            storeButton.OnCurrentPointsChanged(_playerWallet.CurrentPoints);
        }
    }

    private void OnItemPurchased(ModifierStoreItem item)
    {
        ModifierBought?.Invoke(item.Data.GetModifier());
    }

    private void OnPointsChanged(decimal value)
    {
        _storeButtons.ForEach(x => x.OnCurrentPointsChanged(value));
    }
}
