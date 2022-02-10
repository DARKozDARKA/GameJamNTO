﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerBehaviour : MonoBehaviour
{
    private PlayerMover _playerMover;
    [SerializeField] private Camera _camera;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

}
