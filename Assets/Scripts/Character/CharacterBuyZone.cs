using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBuyZone : MonoBehaviour
{
    public Character character;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9 && (other.tag == "Item" || other.tag == "CashBox"))
        {
            InteractableTable table = other.GetComponent<InteractableTable>();
            if (table.canBeUsed is false)
            {
                character.CancelInteract();
                return;
            }

            character.SetNewCurrentTable(table);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9 && (other.tag == "Item" || other.tag == "CashBox"))
        {
            InteractableTable table = other.GetComponent<InteractableTable>();
            character.DeleteCurrentItem(table);
        }
    }

    private void DestroyItem(Collider other)
    {
        Destroy(other.gameObject);
    }
}
