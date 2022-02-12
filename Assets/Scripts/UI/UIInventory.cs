using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public Character player;
    // Базовая реализация
    [SerializeField] private List<Hand> _hands;

    private bool startChange;

    private void Update()
    {
        if (!startChange)
        {
            startChange = true;
            ChangeCountText();
        }
    }
    public void ChangeCountText()
    {
        int i = 1;
        foreach (var item in _hands)
        {
            if (i <= player.inventory.totalWeight)
            {
                item.SetAvalible(false);
            }
            else
            {
                item.SetAvalible(true);
            }
            i++;
        }
        //_inventoryText.text = player.inventory.totalWeight.ToString() + " / " + player.inventory.maxWeight.ToString();
        //_currentCostText.text = player.inventory.currentCost.ToString();
    }
    public void AddItemSuccusfully(ScriptableItem newItem)
    {
        print("added new item");
        ChangeCountText();
    }

    public void AddItemFailed()
    {
        print("can't add new item");
        ChangeCountText();
    }

    public void RemoveAllItems()
    {
        print("removed all items");
        ChangeCountText();
    }


}
