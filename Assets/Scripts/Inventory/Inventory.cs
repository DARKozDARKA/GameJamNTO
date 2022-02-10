using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int _maxWeight = 5;
    [SerializeField] private List<ScriptableItem> _items;
    private int _totalWeight;

    public Action<ScriptableItem> OnAddSucceses;
    public Action OnAddFailure;
    public Action OnAllItemsRemoved;


    private void Awake()
    {
        _items = new List<ScriptableItem>();
    }

    public bool CheckIfCanAdd(ScriptableItem item)
    {
        if (item.weight + _totalWeight > _maxWeight)
        {
            OnAddFailure?.Invoke();
            return false;
        }

        return true;
    }

    public void AddItem(ScriptableItem item)
    {
        if (item.weight + _totalWeight > _maxWeight)
        {
            throw new Exception("You're loser");
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
