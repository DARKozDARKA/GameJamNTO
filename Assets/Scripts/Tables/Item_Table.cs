using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Table : InteractableTable
{
    public ScriptableItem scriptableItem;
    public int weight => scriptableItem.weight;




    private void Start()
    {
        StallHandler.Instance.AddNewItem(this);
    }

    public override void Interact()
    {
        if (_canBeUsed is false) return;
        _canBeUsed = false;
        StallHandler.Instance.RemoveItem(this);
    }


}
