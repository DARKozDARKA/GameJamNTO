using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreens : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _startScreen;

    private void Start()
    {
        _winScreen.SetActive(false);
        _gameScreen.SetActive(false);
    }

    public void SetLoseScreen()
    {
        _gameScreen.SetActive(false);
    }

    public void SetWinScreen()
    {
        _gameScreen.SetActive(false);
        _winScreen.SetActive(true);
    }

    public void SetGameScreen()
    {
        _startScreen.SetActive(false);
        _gameScreen.SetActive(true);
    }

}
