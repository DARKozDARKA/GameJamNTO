using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(Inventory), typeof(Character_MoneyController))]
public abstract class Character : MonoBehaviour
{
    protected Inventory _inventory;
    protected Character_MoneyController _moneyController;
    public Character_MoneyController moneyController => _moneyController;
    public Inventory inventory => _inventory;
    protected InteractableTable _currentSelectedTable;
    protected Item_Table _itemTable;
    public virtual void SetNewCurrentTable(InteractableTable table)
    {
        if (_currentSelectedTable != null)
            DeleteCurrentItem();

        _currentSelectedTable = table;
    }
    public virtual void DeleteCurrentItem()
    {
        if (_currentSelectedTable == null)
            return;
        _currentSelectedTable = null;
    }

    protected virtual void Awake()
    {
        _moneyController = GetComponent<Character_MoneyController>();
        _inventory = GetComponent<Inventory>();
        _inventory.SetCharacter(this);
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
                DeleteCurrentItem();

                return;
            }
        }
        else if (_currentSelectedTable.tag == "CashBox")
        {
            _inventory.BuyAllItems();
        }
    }

    protected virtual void GetItemTable()
    {
        _itemTable = _currentSelectedTable.GetComponent<Item_Table>();
    }

    public virtual void BuyAllItems()
    {
        inventory.BuyAllItems();
    }

    public virtual void CancelInteract()
    {
        // Pass
    }
}
