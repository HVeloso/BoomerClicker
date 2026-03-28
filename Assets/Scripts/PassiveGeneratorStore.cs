using System;
using System.Collections.Generic;
using UnityEngine;

public class PassiveGeneratorStore : MonoBehaviour
{
    [SerializeField] private List<PassiveGeneratorData> _passiveGeneratorsDatas;
    [SerializeField] private GameObject _storeButtonPrefab;
    [Space]
    [SerializeField] private PointsWallet _playerWallet;
    [SerializeField] private PointsGeneratorHandler _generatorHandler;
    [Space]
    [SerializeField] private RectTransform _storeButtonsHolder;
    private List<StoreButton> _storeButtons;

    private void Awake()
    {
        InitializeStoreButtons();
    }

    private void InitializeStoreButtons()
    {
        _storeButtons = new();

        for (int idx = 0; idx < _passiveGeneratorsDatas.Count; idx++)
        {
            PassiveGeneratorData generatorData = _passiveGeneratorsDatas[idx];

            GameObject storeButtonObj = Instantiate(_storeButtonPrefab, _storeButtonsHolder);
            StoreButton storeButton = storeButtonObj.GetComponent<StoreButton>();

            storeButton.UpdateButtonTexts(generatorData.name,
                idx,
                generatorData.PointsPerSeconds,
                0,
                generatorData.BasePrice);

            storeButton.RegisterEvent(OnStoreButtonClicked);

            _storeButtons.Add(storeButton);
        }
    }

    private void OnStoreButtonClicked(int buttonId)
    {
        if (buttonId < 0 || buttonId >= _passiveGeneratorsDatas.Count)
            throw new Exception($"Invalid id. Id: {buttonId} | Current Count: {_passiveGeneratorsDatas.Count}");

        PassiveGeneratorData generatorData = _passiveGeneratorsDatas[buttonId];
        if (!_playerWallet.TrySpendPoints(generatorData.BasePrice)) return;

        _generatorHandler.AddPassiveGenerator(generatorData);
    }
}
