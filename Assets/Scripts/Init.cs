using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour _player;
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private InputSystem _input;
    [SerializeField] private UIManager _UIManager;
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
        _playerInput.Init(_player, _input);
        _player.inventory.OnAddSucceses += _UIManager.inventory.AddItemSuccusfully;
        _player.inventory.OnAddFailure += _UIManager.inventory.AddItemFailed;
        _player.inventory.OnAllItemsRemoved += _UIManager.inventory.RemoveAllItems;
    }

    private void Unsubscribe()
    {
        _playerInput.Unsubscribe();
        _player.inventory.OnAddSucceses -= _UIManager.inventory.AddItemSuccusfully;
        _player.inventory.OnAddFailure -= _UIManager.inventory.AddItemFailed;
        _player.inventory.OnAllItemsRemoved -= _UIManager.inventory.RemoveAllItems;
    }




}
