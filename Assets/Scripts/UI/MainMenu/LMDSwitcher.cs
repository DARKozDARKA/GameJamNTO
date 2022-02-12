using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LMDSwitcher : MonoBehaviour
{
    private bool _isBad = false;
    public void Switch()
    {
        if (_isBad)
            QualitySettings.SetQualityLevel(2);
        else
            QualitySettings.SetQualityLevel(0);
        _isBad = !_isBad;
    }
}
