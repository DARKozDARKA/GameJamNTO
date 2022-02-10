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
        StartCoroutine(StartPlaying());

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


    public override void AddItem(Item_Table newItem)
    {
        _inventory.AddItem(newItem.scriptableItem);
    }

    public override void Interact()
    {
        if (_currentSelectedTable == null)
            return;
        base.Interact(); 
        if (_currentSelectedTable.tag == "Item")
            if (_inventory.CheckIfCanAdd(_itemTable.scriptableItem))
                SetNewStall();
    }

    private IEnumerator InteractReload()
    {
        _canInteract = false;
        yield return new WaitForSeconds(0.5f);
        _canInteract = true;
    }

    private IEnumerator StartPlaying()
    {
        yield return new WaitForEndOfFrame();
        SetNewStall();
    }
}
