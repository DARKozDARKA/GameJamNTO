using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Character_AnimatorController : MonoBehaviour
{
    public Character character;
    private CharacterMover mover;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        mover = character.mover;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 speed = mover.GetMoveTransition();
        animator.SetFloat("Speed", (Mathf.Abs(speed.x) + Mathf.Abs(speed.y)) * 2);
    }
}
