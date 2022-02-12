using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuyTimer : MonoBehaviour
{
    private int _maxTime = 0;
    private int _currentTime;
    public Action<int, int> OnTimeChange;
    public Action OnTimeRunOut;
    public void InitTimer(int maxTime)
    {
        _maxTime = 60;
        _maxTime = maxTime;
        _currentTime = maxTime;
        OnTimeChange?.Invoke(_currentTime, _maxTime);
        StartTimer();
    }

    public void StartTimer()
    {
        StartCoroutine(Tick());
    }

    private IEnumerator Tick()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            _currentTime -= 1;
            OnTimeChange?.Invoke(_currentTime, _maxTime);
            if (_currentTime <= 0)
            {
                OnTimeRunOut?.Invoke();
                break;
            }
        }

    }
}
