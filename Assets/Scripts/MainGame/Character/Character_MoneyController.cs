using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character_MoneyController : MonoBehaviour
{
    private int _startMoney;
    private int _spendedMoney;
    public int startMoney => _startMoney;
    public int spendedMoney => _spendedMoney;
    public Action<int, int> OnMoneyChange;
    private bool _isPlaying = false;
    public Action OnAllMoneyWasted;

    public void SetStartMoney(int startMoney)
    {
        _startMoney = startMoney;
        InvokeMoneyChange();
        _isPlaying = true;
    }

    public void BuyItem(ScriptableItem item)
    {
        _spendedMoney += item.cost;
        InvokeMoneyChange();
        if (_isPlaying && _spendedMoney >= _startMoney)
        {
            OnAllMoneyWasted?.Invoke();
            _isPlaying = false;
        }
    }

    private void InvokeMoneyChange()
    {
        int delta = _startMoney - _spendedMoney;
        OnMoneyChange?.Invoke(delta >= 0 ? delta : 0, _startMoney);
    }
}
