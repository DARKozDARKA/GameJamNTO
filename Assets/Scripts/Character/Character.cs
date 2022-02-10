using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(Inventory))]
public abstract class Character : MonoBehaviour
{
    protected Inventory _inventory;
    public Inventory inventory => _inventory;
    [SerializeField]protected Item _currentSelectedItem;
    public void SetNewCurrentItem(Item item)
    {
        if (_currentSelectedItem != null)
            DeleteCurrentItem();

        _currentSelectedItem = item;
        _currentSelectedItem.outlineTrigger.SetChoose(true);
    }
    public void DeleteCurrentItem()
    {
        if (_currentSelectedItem == null)
            return;

        _currentSelectedItem.outlineTrigger.SetChoose(false);
        _currentSelectedItem = null;
    }

    protected virtual void Awake()
    {
        _inventory = GetComponent<Inventory>();
    }
    public abstract void AddItem(Item newItem);

    public abstract void Interact();
}
