﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : Character
{
    [SerializeField] private float _stepTime;
    [SerializeField] private WalkEffect _walkEffect;
    private NavMeshAgent _agent;
    private bool _canInteract = true;
    private bool _noStalls = false;
    private string _name;
    public string name => _name;
    private Item_Table _huntingItem;
    private bool _isExciting = false;
    private int _idleTimer = 15;

    protected override void Awake()
    {
        base.Awake();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        AIHandler.Instance.AddNewEnemy(this);
        StartCoroutine(MakeSteps());
        OnCashing += SetActiveMovement;
    }

    private void Update()
    {
        if (_canInteract is false) return;
        if (_agent.remainingDistance <= 0.5f)
        {
            if (_isExciting)
            {
                Die();
            }
            Interact();
        }
        StartCoroutine(InteractReload());
    }

    public void SetName(string newName)
    {
        _name = newName;
    }

    private void SetNewStall()
    {
        if (_isExciting) return;
        if (_huntingItem != null)
        {
            _huntingItem.OnCancel -= CancelInteract;
            _huntingItem = null;
        }

        _huntingItem = StallHandler.Instance.GetRandomItem();

        if (_huntingItem == null)
        {
            SetNewCash();
            _noStalls = true;
            return;
        }
        _huntingItem.OnCancel += CancelInteract;
        _agent.SetDestination(_huntingItem.interactPoint.position);
        _idleTimer = 15;
    }

    private void SetNewCash()
    {
        if (_isExciting) return;
        var newItem = StallHandler.Instance.GetRandomCash().interactPoint.position;
        _agent.SetDestination(newItem);
        _idleTimer = 15;
    }


    public override void AddItem(Item_Table newItem)
    {
        _inventory.AddItem(newItem.scriptableItem);
    }

    public override void Interact()
    {
        if (_isExciting) return;
        if (_currentSelectedTable == null)
            return;
        if (_currentSelectedTable.tag == "Item")
        {
            _itemTable = _currentSelectedTable.GetComponent<Item_Table>();
            if (_inventory.CheckIfCanAdd(_itemTable.scriptableItem))
            {

                AddItem(_itemTable);
                _currentSelectedTable.Interact();
                if (_inventory.CheckIsFull())
                    SetNewCash();
                else
                    SetNewStall();
                //DeleteCurrentItem();

                return;
            }
            SetNewCash();
            return;
        }
        else if (_currentSelectedTable.tag == "CashBox")
        {
            _inventory.BuyAllItems();
            if (_noStalls is true)
            {
                GoToExit();
                return;

            }
            SetNewStall();
        }
    }

    private IEnumerator InteractReload()
    {
        _canInteract = false;
        yield return new WaitForSeconds(0.5f);
        _canInteract = true;
    }


    public override void CancelInteract(InteractableTable table)
    {
        SetNewStall();
    }

    public void StartSeeking()
    {
        SetNewStall();
        StartCoroutine(StartNewIdleTimer());
    }

    private IEnumerator MakeSteps()
    {
        while (true)
        {
            if (_agent.velocity.magnitude != 0)
            {
                _soundPlayer.PlayOneStep();
                _walkEffect.Play();

            }
            else
            {
                _walkEffect.Stop();
            }

            yield return new WaitForSeconds(_stepTime * Random.Range(0.9f, 1.1f));

        }
    }

    private void GoToExit()
    {
        _isExciting = true;
        _agent.SetDestination(AIHandler.Instance.exit.position);
    }

    private void Die()
    {
        _agent.isStopped = true;
        transform.position = new Vector3(9999, 3, 9999);
    }

    private IEnumerator StartNewIdleTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            _idleTimer -= 1;
            if (_idleTimer <= 0)
            {
                if (!_isExciting)
                    SetNewStall();
            }
        }


    }

    private void SetActiveMovement(bool isActive)
    {
        if (isActive)
            _agent.isStopped = false;
        else
            _agent.isStopped = true;
    }
}
