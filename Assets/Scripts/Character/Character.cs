using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Character : MonoBehaviour
{
    protected Inventory _inventory;
    public Inventory inventory => _inventory;
    public abstract void AddItem(Item newItem);
}
