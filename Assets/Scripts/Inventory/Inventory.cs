using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    private Character character;
    [SerializeField] private int _maxWeight = 5;
    public int maxWeight => _maxWeight;
    [SerializeField] private List<ScriptableItem> _items;
    private int _totalWeight;
    public int totalWeight => _totalWeight;

    public Action<ScriptableItem> OnAddSucceses;
    public Action OnAddFailure;
    public Action OnAllItemsRemoved;

    public void SetCharacter(Character character) => this.character = character;

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

    public void BuyAllItems()
    {
        foreach (var item in _items)
            character.moneyController.BuyItem(item);
        _items.Clear();
        _totalWeight = 0;
        OnAllItemsRemoved?.Invoke();
    }

    public bool CheckIsFull()
    {
        return totalWeight == maxWeight;
    }
}
