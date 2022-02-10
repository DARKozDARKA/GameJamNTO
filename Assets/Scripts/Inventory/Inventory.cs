using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int _maxWeight = 5;
    private List<Item> _items;
    private int _totalWeight;

    public Action<Item> OnAddSucceses;
    public Action OnAddFailure;
    public Action OnAllItemsRemoved;


    private void Awake()
    {
        _items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        if (item.weight + _totalWeight > _maxWeight)
        {
            OnAddFailure?.Invoke();
            return;
        }
        _items.Add(item);
        _totalWeight += item.weight;
        OnAddSucceses?.Invoke(item);
    }

    public void RemoveAllItems()
    {
        _items.Clear();
        _totalWeight = 0;
        OnAllItemsRemoved?.Invoke();
    }
}
