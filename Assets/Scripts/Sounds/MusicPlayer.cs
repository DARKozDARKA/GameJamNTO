using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip[] _gameMusic;
    [SerializeField] private float _speed;

    private float _startVolume;
    private bool _isMakingQuiet = false;
    private bool _isMakingLoud = false;
    private int _currentTrackIndex;
    private bool _isPlaying = false;

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
        if (_isPlaying)
        {
            if (!_source.isPlaying)
                PlayNextTrack();
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
        _isPlaying = true;
        _source.loop = false;

        _currentTrackIndex = Random.Range(0, _gameMusic.Length);
        _source.clip = _gameMusic[_currentTrackIndex];
        _source.Play();
    }

    private void PlayNextTrack()
    {
        _currentTrackIndex++;
        if (_currentTrackIndex >= _gameMusic.Length)
            _currentTrackIndex = 0;
        _source.clip = _gameMusic[_currentTrackIndex];
        _source.Play();
    }


}
