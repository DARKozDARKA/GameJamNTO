using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(Inventory))]
public abstract class Character : MonoBehaviour
{
    protected Inventory _inventory;
    public Inventory inventory => _inventory;

    protected virtual void Awake()
    {
        _inventory = GetComponent<Inventory>();
    }
    public abstract void AddItem(Item newItem);
}
