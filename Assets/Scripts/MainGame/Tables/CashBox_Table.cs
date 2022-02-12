using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashBox_Table : InteractableTable
{
    [SerializeField] private GameObject _spendEffect;

    private void Start()
    {
        StallHandler.Instance.AddNewCash(this);
    }

    public override void Interact()
    {
        Instantiate(_spendEffect, transform.position, Quaternion.identity);
    }
}
