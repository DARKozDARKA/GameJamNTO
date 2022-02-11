using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip[] _steps;
    [SerializeField] private AudioClip[] _getItem;
    [SerializeField] private AudioClip[] _cashOut;
    [SerializeField] private AudioClip[] _errors;

    public void PlayOneStep()
    {
        _source.pitch = Random.Range(0.9f, 1.1f);
        _source.PlayOneShot(_steps[Random.Range(0, _steps.Length)]);
    }

    public void PlayGetItem()
    {
        _source.pitch = Random.Range(0.9f, 1.1f);
        _source.PlayOneShot(_getItem[Random.Range(0, _getItem.Length)]);
    }
    public void PlayCashOut()
    {
        _source.pitch = Random.Range(0.9f, 1.1f);
        _source.PlayOneShot(_cashOut[Random.Range(0, _cashOut.Length)]);
    }

    public void PlayError()
    {
        _source.pitch = Random.Range(0.9f, 1.1f);
        _source.PlayOneShot(_errors[Random.Range(0, _errors.Length)]);
    }
}
