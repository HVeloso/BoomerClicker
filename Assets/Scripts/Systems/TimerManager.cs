using System;
using System.Collections;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    private readonly WaitForSeconds _waitOneSecond = new(1f);

    public static event Action SecondHasPassed;

    private IEnumerator _calculateSecond;

    private void Awake()
    {
        _calculateSecond = CalculateSecond();
    }

    private void OnEnable()
    {
        StartCoroutine(_calculateSecond);
    }

    private void OnDisable()
    {
        StopCoroutine(_calculateSecond);
    }

    private IEnumerator CalculateSecond()
    {
        while(true)
        {
            yield return _waitOneSecond;
            SecondHasPassed?.Invoke();
        }
    }
}
