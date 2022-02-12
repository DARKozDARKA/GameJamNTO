using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void SetText(int money)
    {
        _text.text = money.ToString() + "$";
    }

}
