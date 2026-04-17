using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ClickTabPositionController : MonoBehaviour
{
    [SerializeField] private Vector3 _positionWhenOpen;
    [SerializeField] private Vector3 _positionWhenClose;

    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        StoreMenusController.MenuOpenStateChanged += OnMenuOpenStateChanged;
    }

    private void OnDisable()
    {
        StoreMenusController.MenuOpenStateChanged -= OnMenuOpenStateChanged;
    }

    private void OnMenuOpenStateChanged(bool isOpen)
    {
        Vector3 postion = isOpen ?
            _positionWhenOpen :
            _positionWhenClose;

        _rectTransform.localPosition = postion;
    }
}
