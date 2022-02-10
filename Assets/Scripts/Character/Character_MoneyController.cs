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

    public void SetStartMoney(int startMoney)
    {
        _startMoney = startMoney;
        OnMoneyChange?.Invoke(_startMoney - _spendedMoney, _startMoney);
    }

    public void BuyItem(ScriptableItem item)
    {
        _spendedMoney += item.cost;
        OnMoneyChange?.Invoke(_startMoney - _spendedMoney, _startMoney);
    }
}
