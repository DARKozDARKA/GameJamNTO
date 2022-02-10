using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Character : MonoBehaviour
{
    public Action<Item> OnItemAdd;
    public Action OnItemAddFail;
    public Action OnRemoveAllItems;
    protected Inventory _inventory;
    public Inventory inventory => _inventory;
    public abstract void AddItem(Item newItem);
}
