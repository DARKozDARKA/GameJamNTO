using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerBehaviour : Character
{
    private PlayerMover _playerMover;
    [SerializeField] private Camera _camera;


    protected override void Awake()
    {
        base.Awake();
        _playerMover = GetComponent<PlayerMover>();

        gameObject.tag = "Player";
        gameObject.layer = 10;
    }

    public override void AddItem(Item newItem)
    {
        _inventory.AddItem(newItem.scriptableItem);
    }


    public void SetMoveDirection(Vector2 moveDirection)
    {
        _playerMover.SetMoveDirection(moveDirection);
    }

    public override void Interact() // On player pressed interact button
    {
        if (_currentSelectedItem == null)
            return;
        if (_inventory.CheckIfCanAdd(_currentSelectedItem.scriptableItem))
            AddItem(_currentSelectedItem);
    }


}
