using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBuyZone : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 9 && Input.GetKeyDown(KeyCode.F))
        {
            DoWithItem(other);
        }
    }

    private void DoWithItem(Collider other)
    {
        print(other.gameObject.name);
        Destroy(other.gameObject);
    }
}
