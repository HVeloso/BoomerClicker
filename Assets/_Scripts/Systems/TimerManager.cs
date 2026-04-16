using System;
using System.Collections;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    private const float SecondsToTickEvent = 1f;

    public static event Action SecondHasPassed;

    private IEnumerator _calculateSecond;

    private void Awake()
    {
        _calculateSecond = CalculateSecond();
    }

    private void OnEnable()
    {
        if (_calculateSecond != null)
            StartCoroutine(_calculateSecond);
    }

    private void OnDisable()
    {
        if (_calculateSecond != null)
            StopCoroutine(_calculateSecond);
    }

    private IEnumerator CalculateSecond(float timer = 0)
    {
        while (true)
        {
            timer += Time.deltaTime;
            
            while (timer >= SecondsToTickEvent)
            {
                timer -= SecondsToTickEvent;
                SecondHasPassed?.Invoke();
            }

            yield return null;
        }
    }
}
