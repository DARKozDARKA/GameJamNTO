using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : Character
{
    [SerializeField] private float _stepTime;
    private NavMeshAgent _agent;
    private bool _canInteract = true;
    private bool _noStalls = false;
    private string _name;
    public string name => _name;

    protected override void Awake()
    {
        base.Awake();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        AIHandler.Instance.AddNewEnemy(this);
        StartCoroutine(MakeSteps());
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

    public void SetName(string newName)
    {
        _name = newName;
    }

    private void SetNewStall()
    {
        var newItem = StallHandler.Instance.GetRandomItem();
        if (newItem == null)
        {
            SetNewCash();
            _noStalls = true;
            return;
        }
        _agent.SetDestination(newItem.interactPoint.position);
    }

    private void SetNewCash()
    {
        var newItem = StallHandler.Instance.GetRandomCash().interactPoint.position;
        _agent.SetDestination(newItem);
    }


    public override void AddItem(Item_Table newItem)
    {
        _inventory.AddItem(newItem.scriptableItem);
    }

    public override void Interact()
    {
        /*
        if (_currentSelectedTable == null)
            return;

        if (_noStalls is false)
        {
            if (_currentSelectedTable.tag == "Item")
            {
                _itemTable = _currentSelectedTable.GetComponent<Item_Table>();
                if (_inventory.CheckIfCanAdd(_itemTable.scriptableItem))
                {
                    _currentSelectedTable.Interact();
                    if (_inventory.CheckIsFull())
                        SetNewCash();
                    else
                        SetNewStall();
                }

                else
                    SetNewCash();
            }
        }


        else if (_currentSelectedTable.tag == "CashBox")
            SetNewStall();
        base.Interact();
        */

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
                DeleteAllCurrentItems();

                return;
            }
            SetNewCash();
            return;
        }
        else if (_currentSelectedTable.tag == "CashBox")
        {
            _inventory.BuyAllItems();
            if (_noStalls is true) return;
            SetNewStall();
        }

    }

    private IEnumerator InteractReload()
    {
        _canInteract = false;
        yield return new WaitForSeconds(0.5f);
        _canInteract = true;
    }


    public override void CancelInteract()
    {
        SetNewStall();
    }

    public void StartSeeking()
    {
        SetNewStall();
    }

    private IEnumerator MakeSteps()
    {
        while (true)
        {
            if (_agent.velocity.magnitude != 0)
            {
                _soundPlayer.PlayOneStep();

            }
            yield return new WaitForSeconds(_stepTime * Random.Range(0.9f, 1.1f));

        }
    }
}
