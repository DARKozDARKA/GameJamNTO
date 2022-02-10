using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Table : InteractableTable
{
    public ScriptableItem scriptableItem;
    public int weight => scriptableItem.weight;
}
