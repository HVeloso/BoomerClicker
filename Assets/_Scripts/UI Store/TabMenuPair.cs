using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct TabMenuPair
{
    [SerializeField] private Button _tabButton;
    [SerializeField] private GameObject _contentContainer;

    public readonly Button TabButton => _tabButton;
    public readonly GameObject ContentContainer => _contentContainer;
}
