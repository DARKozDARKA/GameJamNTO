using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : Character
{
    private NavMeshAgent _agent;
    private bool _canInteract = true;

    protected override void Awake()
    {
        base.Awake();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        SetNewStall();
    }

    private void Update()
    {
        if (_canInteract is false) return;
        if (_agent.remainingDistance <= 0.5f)
        {
            Interact();
        }
        StartCoroutine(InteractReload());
    }

    private void SetNewStall()
    {
        var newItem = StallHandler.Instance.GetRandomItem().interactPoint.position;
        _agent.SetDestination(newItem);
    }


    public override void AddItem(Item newItem)
    {
        _inventory.AddItem(newItem.scriptableItem);
    }

    public override void Interact()
    {
        if (_currentSelectedItem == null)
            return;
        if (_inventory.CheckIfCanAdd(_currentSelectedItem.scriptableItem))
        {
            SetNewStall();
            AddItem(_currentSelectedItem);
        }
        else
        {

        }

    }

    private IEnumerator InteractReload()
    {
        _canInteract = false;
        yield return new WaitForSeconds(0.5f);
        _canInteract = true;
    }
}
