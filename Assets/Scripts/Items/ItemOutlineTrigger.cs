using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemOutlineTrigger : MonoBehaviour
{
    public UnityEvent onPlayerEnter, onPlayerExit;
    // Start is called before the first frame update

    private void Start()
    {
        onPlayerExit.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
            onPlayerEnter.Invoke();
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == 10)
            onPlayerExit.Invoke();
    }
}
