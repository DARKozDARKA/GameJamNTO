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
    [SerializeField]protected InteractableTable _currentSelectedTable;
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

    public abstract void Interact();

    public virtual void BuyAllItems()
    {
        inventory.BuyAllItems();
    }
}
