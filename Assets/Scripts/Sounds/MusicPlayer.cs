using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _gameMusic;
    [SerializeField] private float _speed;

    private float _startVolume;
    private bool _isMakingQuiet = false;
    private bool _isMakingLoud = false;

    private void Start()
    {
        _startVolume = _source.volume;
    }

    private void Update()
    {
        if (_isMakingQuiet)
        {
            if (_source.volume <= 0) _isMakingQuiet = false;
            _source.volume -= Time.deltaTime * _speed;
        }
        if (_isMakingLoud)
        {
            if (_source.volume >= _startVolume) _isMakingLoud = false;
            _source.volume += Time.deltaTime * _speed;
        }

    }

    public void QuietMenuMusic()
    {
        _isMakingQuiet = true;
    }

    public void StartGameMusic()
    {
        _isMakingQuiet = false;
        _isMakingLoud = true;

        _source.clip = _gameMusic;
        _source.Play();
    }


}
