using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashBox_Table : InteractableTable
{


    private void Start()
    {
        StallHandler.Instance.AddNewCash(this);
    }

    public override void Interact()
    {
        // Pass
    }
}
