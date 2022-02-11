using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
    private bool _isPlaying = false;

    private void Start()
    {
        _particle.Stop();
    }

    public void Play()
    {
        if (_isPlaying == true) return;
        _isPlaying = true;
        _particle.Play();
    }
    public void Stop()
    {
        if (_isPlaying == false) return;
        _isPlaying = false;
        _particle.Stop();
    }
}
