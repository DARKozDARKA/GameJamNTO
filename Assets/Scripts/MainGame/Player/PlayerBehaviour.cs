using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

[RequireComponent(typeof(PlayerMover))]
public class PlayerBehaviour : Character
{

    private PlayerMover _playerMover;

    public override void SetNewCurrentTable(InteractableTable table)
    {
        if (_currentSelectedTable != null)
            if (_currentSelectedTable.canBeUsed)
                _currentSelectedTable.outlineTrigger.SetChoose(false);
        base.SetNewCurrentTable(table);
        if (_currentSelectedTable.canBeUsed)
            _currentSelectedTable.outlineTrigger.SetChoose(true);
    }
    public override void DeleteCurrentItem(InteractableTable table)
    {
        if (_currentSelectedTable == null)
            return;
        if (_currentSelectedTable.canBeUsed)
            _currentSelectedTable.outlineTrigger.SetChoose(false);
        base.DeleteCurrentItem(table);
        if (_currentSelectedTable != null)
            if (_currentSelectedTable.canBeUsed)
                _currentSelectedTable.outlineTrigger.SetChoose(true);
    }
    protected override void DeleteCurrentItem()
    {
        if (_currentSelectedTable == null)
            return;
        if (_currentSelectedTable.canBeUsed)
            _currentSelectedTable.outlineTrigger.SetChoose(false);
        base.DeleteCurrentItem();
        if (_currentSelectedTable != null)
            if (_currentSelectedTable.canBeUsed)
                _currentSelectedTable.outlineTrigger.SetChoose(true);
    }
    protected override void Awake()
    {
        base.Awake();
        _playerMover = GetComponent<PlayerMover>();

        gameObject.tag = "Player";
        gameObject.layer = 10;
        _playerMover.OnStep += _soundPlayer.PlayOneStep;
        OnCashing += _playerMover.SetActiveMovement;
    }

    private void OnDestroy()
    {
        _playerMover.OnStep -= _soundPlayer.PlayOneStep;

    }

    public override void AddItem(Item_Table newItem)
    {
        _inventory.AddItem(newItem.scriptableItem);
        _soundPlayer.PlayGetItem();
    }


    public void SetMoveDirection(Vector2 moveDirection)
    {
        _playerMover.SetMoveDirection(moveDirection);
    }

    public void DisableMovement()
    {
        OnCashing -= _playerMover.SetActiveMovement;
        _playerMover.DisableMovement();
    }

    public override void BuyAllItems()
    {
        base.BuyAllItems();
        _soundPlayer.PlayCashOut();
    }

    [Command(requiresAuthority = false)]
    private void NewPlayerJoin(uint id)
    {
        Server.Instance.SetNewPlayer(this, id);
    }

    [ClientRpc]
    public void SetPlayers(PlayerBehaviour[] players)
    {
        //Client.Instance.SetPlayers(new List<PlayerBehaviour>(players));
        if (!isLocalPlayer) return;
    }


}
