using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMoney : MonoBehaviour
{
    [SerializeField] private Text _moneyText;
    public void ChangeMoney(int currentMoney, int maxMoney)
    {
        _moneyText.text = currentMoney.ToString() + " / " + maxMoney.ToString();
    }
}
