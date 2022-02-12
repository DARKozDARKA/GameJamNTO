using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class WinMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void SetText(int money)
    {
        _text.text = money.ToString() + "$";
    }

}
