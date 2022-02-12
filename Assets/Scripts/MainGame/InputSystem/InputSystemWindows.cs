using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystemWindows : InputSystem
{
    private void Update()
    {
        OnVelocityChange?.Invoke(new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")));
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnInteract?.Invoke();
        }
    }

}
