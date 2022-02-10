using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerBehaviour : Character
{
    private PlayerMover _playerMover;
    [SerializeField] private Camera _camera;
    [SerializeField] private Item _testItem;


    protected override void Awake()
    {
        base.Awake();
        _playerMover = GetComponent<PlayerMover>();

        gameObject.tag = "Player";
        gameObject.layer = 10;
    }

    public override void AddItem(Item newItem)
    {
        _inventory.AddItem(newItem);
    }


    public void SetMoveDirection(Vector2 moveDirection)
    {
        _playerMover.SetMoveDirection(moveDirection);
    }

    public void Interact() // On player pressed interact button
    {
        if (_inventory.CheckIfCanAdd(_testItem))
            AddItem(_testItem);
    }


}
