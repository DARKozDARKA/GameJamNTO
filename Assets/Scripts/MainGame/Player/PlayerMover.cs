using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : CharacterMover
{
    public GameObject humanRotator;
    //[SerializeField] private float jumpSpeed = 8.0f;
    [SerializeField] private WalkEffect _walkEffect;
    [SerializeField] private float _gravity = 20.0f;
    [SerializeField] private float _stepPerTime = 0.5f;
    private Transform _cameraTransform;
    private CharacterController _characterController;
    private Vector3 moveDirection = Vector3.zero;
    private float _startHeight;

    private bool _initStartHeight = false;
    private Vector2 _moveDirection;

    private bool _canMove = true;
    private bool _previousIsMoving = false;
    public Action OnStep;
    [SerializeField] private bool _isMoving = false;

    private GameObject napr;
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _state = MoverState.isMoving;
        _startHeight = transform.position.y;
        _cameraTransform = Camera.main.transform;
        StartCoroutine(MakeSteps());
        napr = GameObject.CreatePrimitive(PrimitiveType.Cube);
        napr.GetComponent<Collider>().enabled = false;
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
                Vector3 forward = Quaternion.AngleAxis(_cameraTransform.eulerAngles.y, Vector3.up) * Vector3.forward;
                Vector3 right = Quaternion.AngleAxis(_cameraTransform.eulerAngles.y, Vector3.up) * Vector3.right;
                float curSpeedX = _canMove ? _speed * _moveDirection.x : 0;
                float curSpeedY = _canMove ? _speed * _moveDirection.y : 0;
                moveDirection = (forward * curSpeedX) + (right * curSpeedY);
                //moveDirection = moveDirection.normalized * _speed;
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
        Vector3 pos = transform.position + moveDirection.normalized * 10;
        pos.y = humanRotator.transform.position.y;
        humanRotator.transform.LookAt(pos);
        _characterController.Move(moveDirection * Time.deltaTime);

        if (!_canMove) return;

        //.eulerAngles = new Vector2(0, rotation.y);
    }

    /*public void SetNewCameraAngle(float angle)
    {
        _cameraTransform.y = angle;
    }*/

    public void SetMoveDirection(Vector2 moveDirection)
    {
        _moveDirection = moveDirection;
        _isMoving = moveDirection != Vector2.zero;
        if (_isMoving != _previousIsMoving)
        {
            _previousIsMoving = _isMoving;
            if (_isMoving)
                _walkEffect.Play();
            else
                _walkEffect.Stop();
        }

    }

    public void DisableMovement()
    {
        _canMove = false;
    }

    public void SetActiveMovement(bool isActive)
    {
        _canMove = isActive;
    }

    private IEnumerator MakeSteps()
    {
        while (true)
        {
            if (_isMoving && _canMove)
                OnStep?.Invoke();

            yield return new WaitForSeconds(_stepPerTime);

        }

    }


    public override Vector2 GetMoveTransition()
    {
        return new Vector2(_characterController.velocity.x / _speed, _characterController.velocity.z / _speed);
    }

}
