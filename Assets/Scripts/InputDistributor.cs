using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDistributor : MonoBehaviour
{
    public InputSystem android, windows;

    public InputSystem GetInput()
    {
#if UNITY_EDITOR
        return windows;
#endif

#if PLATFORM_ANDROID
        return android;
#endif
    }
}
