using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover), typeof(Inventory))]
public class PlayerBehaviour : Character
{
    private PlayerMover _playerMover;
    [SerializeField] private Camera _camera;
    [SerializeField] private Item _testItem;


    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _inventory = GetComponent<Inventory>();
    }

    public override void AddItem(Item newItem)
    {
        _inventory.AddItem(newItem);
    }


    public void SetMoveDirection(Vector2 moveDirection)
    {
        _playerMover.SetMoveDirection(moveDirection);
    }

    public void Interact() { AddItem(_testItem); } // On player pressed interact button


}
