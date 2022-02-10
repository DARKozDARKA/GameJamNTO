using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stall : MonoBehaviour
{
    [SerializeField] private Item _item;
    [SerializeField] private Transform _interactPoint;
    public Transform interactPoint => _interactPoint;

    private void Start()
    {
        StallHandler.Instance.AddNewItem(this);
    }
}
