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

    public void SetChoose(bool isChoosing)
    {
        if(isChoosing)
            onPlayerEnter.Invoke();
        else
            onPlayerExit.Invoke();
    }
}
