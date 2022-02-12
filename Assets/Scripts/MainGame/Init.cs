﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(InputDistributor))]
public class Init : MonoBehaviour
{
    public static Init Instance;

    private PlayerBehaviour _player;
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private InputDistributor _inputDistribitor;
    [SerializeField] private UIManager _UIManager;
    [SerializeField] private BuyTimer _timer;
    [SerializeField] private MusicPlayer _music;
    private PlayerInput _playerInput;
    public UnityEvent onStartGame;

    private void Awake()
    {
        Instance = this;
    }

    public void InitPlayer(PlayerBehaviour player)
    {
        _player = player;
        _cameraMover.Init(new CameraParameters(), _player.gameObject.transform);
        _playerInput = new PlayerInput();
        Subscribe();

    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        _UIManager.inventory.player = _player;

        _player.inventory.OnAddSucceses += _UIManager.inventory.AddItemSuccusfully;
        _player.inventory.OnAddFailure += _UIManager.inventory.AddItemFailed;
        _player.inventory.OnAllItemsRemoved += _UIManager.inventory.RemoveAllItems;
        _player.moneyController.OnMoneyChange += _UIManager.money.ChangeMoney;
        _UIManager.wheel.OnCostEstablished += _player.moneyController.SetStartMoney;
        _UIManager.wheel.OnSpinEnded += StartGame;
        _UIManager.wheel.OnTimeEstablished += _timer.InitTimer;
        _UIManager.wheel.OnSpinStarted += StartSpin;
        _timer.OnTimeChange += _UIManager.timer.ChangeTime;
        StallHandler.Instance.OnStallsEnded += Win;

        _timer.OnTimeRunOut += Win;

    }

    private void Unsubscribe()
    {

        _playerInput.Unsubscribe();
        _player.inventory.OnAddSucceses -= _UIManager.inventory.AddItemSuccusfully;
        _player.inventory.OnAddFailure -= _UIManager.inventory.AddItemFailed;
        _player.inventory.OnAllItemsRemoved -= _UIManager.inventory.RemoveAllItems;
        _player.moneyController.OnMoneyChange -= _UIManager.money.ChangeMoney;
        _UIManager.wheel.OnCostEstablished -= _player.moneyController.SetStartMoney;
        _UIManager.wheel.OnTimeEstablished -= _timer.InitTimer;
        _UIManager.wheel.OnSpinEnded -= StartGame;
        _UIManager.wheel.OnSpinStarted -= StartSpin;
        _timer.OnTimeChange -= _UIManager.timer.ChangeTime;

        _timer.OnTimeRunOut -= Win;
    }

    private void StartSpin()
    {
        _music.QuietMenuMusic();
    }

    private void StartGame()
    {
        _playerInput.Init(_player, _inputDistribitor.GetInput());
        _UIManager.screens.SetGameScreen();
        AIHandler.Instance.StartGame();
        _music.StartGameMusic();

    }

    private void Win()
    {
        _timer.OnTimeRunOut -= Lose;
        StallHandler.Instance.OnStallsEnded -= Win;
        _UIManager.screens.SetWinScreen();
        _playerInput.Unsubscribe();
        _player.DisableMovement();
        AIHandler.Instance.PrintAllEnemiesSpendMoney();


        SetPrefs();
    }
    private void Lose()
    {
        _player.moneyController.OnAllMoneyWasted -= Win;
        _UIManager.screens.SetLoseScreen();
        _playerInput.Unsubscribe();
        _player.DisableMovement();
        AIHandler.Instance.PrintAllEnemiesSpendMoney();
    }

    private void SetPrefs()
    {
        if (!PlayerPrefs.HasKey("totalSpented"))
        {
            PlayerPrefs.SetInt("totalSpented", _player.moneyController.spendedMoney);
        }
        else
        {
            PlayerPrefs.SetInt("totalSpented", PlayerPrefs.GetInt("totalSpented") + _player.moneyController.spendedMoney);

        }
        _UIManager.winMenu.SetText(_player.moneyController.spendedMoney);
    }



}