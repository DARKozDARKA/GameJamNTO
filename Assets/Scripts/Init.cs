using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputDistributor))]
public class Init : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour _player;
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private InputDistributor _inputDistribitor;
    [SerializeField] private UIManager _UIManager;
    [SerializeField] private BuyTimer _timer;
    private PlayerInput _playerInput;

    private void Start()
    {
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
        _playerInput.Init(_player, _inputDistribitor.GetInput());
        _player.inventory.OnAddSucceses += _UIManager.inventory.AddItemSuccusfully;
        _player.inventory.OnAddFailure += _UIManager.inventory.AddItemFailed;
        _player.inventory.OnAllItemsRemoved += _UIManager.inventory.RemoveAllItems;
        _player.moneyController.OnMoneyChange += _UIManager.money.ChangeMoney;
        _UIManager.wheel.OnCostEstablished += _player.moneyController.SetStartMoney;
        _UIManager.wheel.OnTimeEstablished += _timer.InitTimer;
        _timer.OnTimeChange += _UIManager.timer.ChangeTime;

        _timer.OnTimeRunOut += Lose;
        _player.moneyController.OnAllMoneyWasted += Win;

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
        _timer.OnTimeChange -= _UIManager.timer.ChangeTime;
        _timer.OnTimeRunOut -= Lose;
        _player.moneyController.OnAllMoneyWasted -= Win;
    }

    private void Win()
    {
        _timer.OnTimeRunOut -= Lose;
        _UIManager.screens.SetWinScreen();
    }
    private void Lose()
    {
        _player.moneyController.OnAllMoneyWasted -= Win;
        _UIManager.screens.SetLoseScreen();
    }




}
