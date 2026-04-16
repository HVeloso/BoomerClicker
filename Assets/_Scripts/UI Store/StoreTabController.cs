using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StoreTabController : MonoBehaviour
{
    [SerializeField] private bool _startOpensState;

    [SerializeField] private GameObject _tabContent;
    [SerializeField] private List<GameObject> _othersContents;

    private Button _myButton;

    private void OnEnable()
    {
        _myButton.onClick.AddListener(OpenContent);
    }

    private void OnDisable()
    {
        _myButton.onClick.RemoveListener(OpenContent);
    }

    private void Awake()
    {
        _myButton = GetComponent<Button>();
        if (_startOpensState) OpenContent();
    }

    private void OpenContent()
    {
        _tabContent.SetActive(true);
        _othersContents.ForEach(x => x.SetActive(false));
    }
}
