using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StallHandler : MonoBehaviour
{
    public static StallHandler Instance { get; set; }
    private List<Item_Table> _stalls;
    private List<CashBox_Table> _cashboxes;
    public Action OnStallsEnded;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
            Instance = null;
        }
        Instance = this;
        _stalls = new List<Item_Table>();
        _cashboxes = new List<CashBox_Table>();
    }

    public void AddNewItem(Item_Table item)
    {
        _stalls.Add(item);
    }

    public void RemoveItem(Item_Table item)
    {
        _stalls.Remove(item);
    }

    public void AddNewCash(CashBox_Table item)
    {
        _cashboxes.Add(item);
    }

    public Item_Table GetRandomItem()
    {
        if (_stalls.Count == 0)
        {
            OnStallsEnded?.Invoke();
            return null;
        }

        return _stalls[UnityEngine.Random.Range(0, _stalls.Count)];
    }

    public CashBox_Table GetRandomCash()
    {

        return _cashboxes[UnityEngine.Random.Range(0, _cashboxes.Count)];
    }

}
