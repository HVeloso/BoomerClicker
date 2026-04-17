using System;
using System.Collections.Generic;
using UnityEngine;

public class StoreMenusController : MonoBehaviour
{
    [SerializeField] private List<TabMenuPair> _storeTabPairs;
    private GameObject _currentContentOpened = null;
    
    public static event Action<bool> MenuOpenStateChanged;

    private void Start()
    {
        RegisterSlaoQ();
    }

    private void RegisterSlaoQ()
    {
        foreach (TabMenuPair pair in _storeTabPairs)
        {
            pair.TabButton.onClick.AddListener(
                () => OnTabClicked(pair.ContentContainer));
        }
    }

    private void OnTabClicked(GameObject content)
    {
        if (_currentContentOpened == content)
        {
            _currentContentOpened.SetActive(false);
            _currentContentOpened = null;
            CheckChangeOfStatus();
            return;
        }
        
        if (_currentContentOpened != null)
            _currentContentOpened.SetActive(false);

        _currentContentOpened = content;
        _currentContentOpened.SetActive(true);
        CheckChangeOfStatus();
    }

    private void CheckChangeOfStatus()
    {
        MenuOpenStateChanged?.Invoke(_currentContentOpened != null);
    }
}
