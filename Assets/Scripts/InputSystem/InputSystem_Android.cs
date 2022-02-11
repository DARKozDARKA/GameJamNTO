using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputSystem_Android : InputSystem
{
    public DynamicJoystick joystick;
    public Button interactButton;
    private void Start()
    {
        interactButton.onClick.AddListener(InteractButton);
    }
    private void Update()
    {
        OnVelocityChange?.Invoke(new Vector2(joystick.Vertical, joystick.Horizontal));
    }

    public void InteractButton()
    {
        OnInteract?.Invoke();
    }
}
