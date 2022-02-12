using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PostProcessBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _volume;

    private bool _isBad = false;
    public void Switch()
    {
        _volume.SetActive(_isBad);
        _isBad = !_isBad;
    }

}
