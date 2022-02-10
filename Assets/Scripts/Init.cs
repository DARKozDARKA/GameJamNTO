using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour _player;
    [SerializeField] private CameraMover _cameraMover;
    private void Awake()
    {
        _cameraMover.Init(new CameraParameters(), _player.gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
