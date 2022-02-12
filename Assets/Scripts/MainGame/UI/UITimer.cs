using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UITimer : MonoBehaviour
{
    [SerializeField] private Text _timerText;
    public void ChangeTime(int currentTime, int maxTime)
    {
        var currentTimeSpan = TimeSpan.FromSeconds(currentTime);
        var maxTimeSpan = TimeSpan.FromSeconds(maxTime);
        _timerText.text = currentTimeSpan.Minutes.ToString() + ":" + ((currentTimeSpan.Seconds == 0) ? "00" :
           (currentTimeSpan.Seconds.ToString().Length == 1 ? "0" + currentTimeSpan.Seconds.ToString() : currentTimeSpan.Seconds.ToString())) +
         " / "
          + maxTimeSpan.Minutes.ToString() + ":" + ((maxTimeSpan.Seconds == 0) ? "00" :
           (maxTimeSpan.Seconds.ToString().Length == 1 ? "0" + maxTimeSpan.Seconds.ToString() : maxTimeSpan.Seconds.ToString()));
    }
}
