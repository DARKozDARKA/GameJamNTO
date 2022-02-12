using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        if (PlayerPrefs.HasKey("totalSpented"))
        {
            SetTotalWin(PlayerPrefs.GetInt("totalSpented"));
        }
        print(PlayerPrefs.GetInt("totalSpented"));
    }

    public void SetTotalWin(int amount)
    {
        _text.text = amount.ToString() + "$";
    }
}
