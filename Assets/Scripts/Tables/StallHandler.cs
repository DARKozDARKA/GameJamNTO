using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StallHandler : MonoBehaviour
{
    public static StallHandler Instance { get; set; }
    private List<Stall> _stalls;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
            Instance = null;
        }
        Instance = this;
        _stalls = new List<Stall>();
    }

    public void AddNewItem(Stall item)
    {
        _stalls.Add(item);
    }

    public Stall GetRandomItem()
    {
        return _stalls[Random.Range(0, _stalls.Count)];
    }

}
