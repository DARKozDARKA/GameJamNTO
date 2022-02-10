using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StallHandler : MonoBehaviour
{
    public static StallHandler Instance { get; set; }
    private List<Item_Table> _stalls;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
            Instance = null;
        }
        Instance = this;
        _stalls = new List<Item_Table>();
    }

    public void AddNewItem(Item_Table item)
    {
        _stalls.Add(item);
    }

    public Item_Table GetRandomItem()
    {
        return _stalls[Random.Range(0, _stalls.Count)];
    }

}
