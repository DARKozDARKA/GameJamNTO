﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : CharacterMover
{
    //[SerializeField] private float jumpSpeed = 8.0f;
    [SerializeField] private float _gravity = 20.0f;
    [SerializeField] private Vector3 _cameraRotation;
    private CharacterController _characterController;
    private Vector3 moveDirection = Vector3.zero;
    private float _startHeight;

    private bool _initStartHeight = false;
    private Vector2 _moveDirection;

    private bool _canMove = true;



    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _state = MoverState.isMoving;
        _startHeight = transform.position.y;
    }

    private void Update()
    {
        Move();
    }

    protected override void Move()
    {
        if (_state == MoverState.idle) return;
        if (_characterController.isGrounded)
        {
            if (_state == MoverState.isMoving)
            {
                Vector3 forward = Quaternion.AngleAxis(_cameraRotation.y, Vector3.up) * Vector3.forward;
                Vector3 right = Quaternion.AngleAxis(_cameraRotation.y, Vector3.up) * Vector3.right;
                float curSpeedX = _canMove ? _speed * _moveDirection.x : 0;
                float curSpeedY = _canMove ? _speed * _moveDirection.y : 0;
                moveDirection = (forward * curSpeedX) + (right * curSpeedY);
                moveDirection = moveDirection.normalized * _speed;
            }


            /*
            if (Input.GetButton("Jump") && canMove)
            {
                moveDirection.y = jumpSpeed;
            }
            */
            if (_initStartHeight is false)
            {
                _initStartHeight = true;
                _startHeight = transform.position.y;
            }

        }

        moveDirection.y -= _gravity * Time.deltaTime;

        _characterController.Move(moveDirection * Time.deltaTime);

        if (!_canMove) return;

        //.eulerAngles = new Vector2(0, rotation.y);
    }

    public void SetNewCameraAngle(float angle)
    {
        _cameraRotation.y = angle;
    }

    public void SetMoveDirection(Vector2 moveDirection)
    {
        _moveDirection = moveDirection;
    }

}