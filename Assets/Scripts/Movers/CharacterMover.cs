using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterMover : MonoBehaviour
{
    [SerializeField] protected float _speed = 7.5f;
    public enum MoverState { idle, isMoving }
    protected MoverState _state;

    protected abstract void Move();

    public void SetState(MoverState state)
    {
        _state = state;
    }
    public abstract Vector2 GetMoveTransition();

}
