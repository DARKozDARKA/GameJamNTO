using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput
{
    private InputSystem _input;
    private PlayerBehaviour _player;

    public void Init(PlayerBehaviour player, InputSystem input)
    {
        _player = player;
        _input = input;
        Subscribe();
    }

    private void Subscribe()
    {
        _input.OnVelocityChange += _player.SetMoveDirection;
        _input.OnInteract += _player.Interact;
    }

    public void Unsubscribe()
    {
        _input.OnVelocityChange -= _player.SetMoveDirection;
        _input.OnInteract -= _player.Interact;
    }
}
