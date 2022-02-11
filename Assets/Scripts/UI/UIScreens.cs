using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreens : MonoBehaviour
{
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private GameObject _winScreen;

    private void Start()
    {
        _loseScreen.SetActive(false);
        _winScreen.SetActive(false);
    }

    public void SetLoseScreen()
    {
        _loseScreen.SetActive(true);
    }

    public void SetWinScreen()
    {
        _winScreen.SetActive(true);
    }

}
