using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour _player;
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private InputSystem _input;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _cameraMover.Init(new CameraParameters(), _player.gameObject.transform);
        _playerInput = new PlayerInput();
        _playerInput.Init(_player, _input);
    }

    private void OnDestroy()
    {
        _playerInput.Unsubscribe();
    }
}
