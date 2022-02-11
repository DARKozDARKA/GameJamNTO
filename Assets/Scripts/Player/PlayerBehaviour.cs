using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerBehaviour : Character
{
    private PlayerMover _playerMover;

    public override void SetNewCurrentTable(InteractableTable table)
    {
        base.SetNewCurrentTable(table);
        _currentSelectedTable.outlineTrigger.SetChoose(true);
    }
    public override void DeleteCurrentItem()
    {
        if (_currentSelectedTable == null)
            return;
        _currentSelectedTable.outlineTrigger.SetChoose(false);
        base.DeleteCurrentItem();
    }
    protected override void Awake()
    {
        base.Awake();
        _playerMover = GetComponent<PlayerMover>();

        gameObject.tag = "Player";
        gameObject.layer = 10;
    }

    public override void AddItem(Item_Table newItem)
    {
        _inventory.AddItem(newItem.scriptableItem);
    }


    public void SetMoveDirection(Vector2 moveDirection)
    {
        _playerMover.SetMoveDirection(moveDirection);
    }




}
