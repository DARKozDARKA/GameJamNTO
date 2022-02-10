using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBuyZone : MonoBehaviour
{
    public Character character;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9 && other.tag == "Item")
        {
            Item item = other.GetComponent<Item>();
            character.SetNewCurrentItem(item);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9 && other.tag == "Item")
        {
            character.DeleteCurrentItem();
        }
    }

    private void DestroyItem(Collider other)
    {
        print(other.gameObject.name);
        Destroy(other.gameObject);
    }
}
