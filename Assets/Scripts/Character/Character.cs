using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(Inventory), typeof(Character_MoneyController), typeof(CharacterSoundPlayer))]
[RequireComponent(typeof(CharacterMover))]
public abstract class Character : MonoBehaviour
{
    protected Inventory _inventory;
    protected Character_MoneyController _moneyController;
    public Character_MoneyController moneyController => _moneyController;
    protected CharacterMover _mover;
    public CharacterMover mover => _mover;
    public Inventory inventory => _inventory;
    protected List<InteractableTable> _currentSelectedTables;
    protected InteractableTable _currentSelectedTable;
    protected Item_Table _itemTable;
    protected CharacterSoundPlayer _soundPlayer;

    public virtual void SetNewCurrentTable(InteractableTable table)
    {
        _currentSelectedTables.Add(table);


        _currentSelectedTable = _currentSelectedTables[_currentSelectedTables.Count - 1];
        _currentSelectedTables[_currentSelectedTables.Count - 1].OnCancel += DeleteAllCurrentItems;
    }
    public virtual void DeleteCurrentItem(InteractableTable table)
    {
        _currentSelectedTables.Remove(table);

        if (_currentSelectedTables.Count == 0)
        {
            _currentSelectedTable = null;
            return;
        }
        _currentSelectedTable = _currentSelectedTables[_currentSelectedTables.Count - 1];
    }

    protected virtual void DeleteAllCurrentItems()
    {
        for (int i = 0; i < _currentSelectedTables.Count; i++)
        {
            _currentSelectedTables[i].OnCancel -= DeleteAllCurrentItems;
        }
        _currentSelectedTables.Clear();
        _currentSelectedTable = null;
    }

    protected virtual void Awake()
    {
        _moneyController = GetComponent<Character_MoneyController>();
        _soundPlayer = GetComponent<CharacterSoundPlayer>();
        _inventory = GetComponent<Inventory>();
        _mover = GetComponent<CharacterMover>();
        _inventory.SetCharacter(this);
        _currentSelectedTables = new List<InteractableTable>();
    }
    public abstract void AddItem(Item_Table newItem);

    public virtual void Interact()
    {
        if (_currentSelectedTable == null)
            return;
        if (_currentSelectedTable.tag == "Item")
        {
            _itemTable = _currentSelectedTable.GetComponent<Item_Table>();
            if (_inventory.CheckIfCanAdd(_itemTable.scriptableItem))
            {

                AddItem(_itemTable);
                _currentSelectedTable.Interact();
                DeleteAllCurrentItems();

                return;
            }
        }
        else if (_currentSelectedTable.tag == "CashBox")
        {
            _inventory.BuyAllItems();
            BuyAllItems();
        }
    }

    protected virtual void GetItemTable()
    {
        _itemTable = _currentSelectedTable.GetComponent<Item_Table>();
    }

    public virtual void BuyAllItems()
    {

    }

    public virtual void CancelInteract()
    {
        // Pass
    }

}
