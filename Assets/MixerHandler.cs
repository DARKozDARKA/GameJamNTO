using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerHandler : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private Slider _slider;
    public void SetVolume()
    {
        if (_slider.value == -20)
            _mixer.SetFloat("Volume", -80);
        else
            _mixer.SetFloat("Volume", _slider.value);
    }
}
