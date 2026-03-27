using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ToggleObjectPosition : MonoBehaviour
{
    [SerializeField] private List<Vector3> _positions;
    private int _positionIndex;

    private RectTransform _objectTransform;

    private void Awake()
    {
        _objectTransform = GetComponent<RectTransform>();
        _positionIndex = 0;
    }

    public void TogglePosition()
    {
        UpdateIndex();
        SetPosition();
    }

    private void UpdateIndex()
    {
        _positionIndex++;
        _positionIndex = (_positionIndex + _positions.Count) % _positions.Count;
    }

    private void SetPosition()
    {
        _objectTransform.localPosition = _positions[_positionIndex];
    }
}
