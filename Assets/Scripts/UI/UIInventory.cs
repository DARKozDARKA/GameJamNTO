using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    // Базовая реализация
    [SerializeField] private Text _text;

    public void AddItemSuccusfully(ScriptableItem newItem)
    {
        print("added new item");
    }

    public void AddItemFailed()
    {
        print("can't add new item");
    }

    public void RemoveAllItems()
    {
        print("removed all items");
    }


}
