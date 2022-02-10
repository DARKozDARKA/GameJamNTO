using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_MoneyController : MonoBehaviour
{
    private int _startMoney;
    private int _spendedMoney; 
    public int startMoney => _startMoney;
    public int spendedMoney => _spendedMoney;

    public void BuyItem(ScriptableItem item)
    {
        _spendedMoney += item.cost;
    }
}
