using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(Inventory))]
public class PlayerBehaviour : Character
{
    private PlayerMover _playerMover;
    [SerializeField] private Camera _camera;


    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    public override void AddItem(Item newItem)
    {
        _inventory.AddItem(newItem);
    }


    public void SetMoveDirection(Vector2 moveDirection)
    {
        _playerMover.SetMoveDirection(moveDirection);
    }

    public void Interact() { } // On player pressed interact button


}
