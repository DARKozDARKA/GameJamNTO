using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy_Mover : CharacterMover
{
    private NavMeshAgent navMeshAgent;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    public override Vector2 GetMoveTransition()
    {
        return new Vector2(-navMeshAgent.velocity.x / navMeshAgent.speed, -navMeshAgent.velocity.z / navMeshAgent.speed);
    }

    protected override void Move()
    {

    }
}
