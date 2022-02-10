using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableTable : MonoBehaviour
{
    public InteractableTable_OutlineTrigger outlineTrigger;

    [SerializeField] private Transform _interactPoint;
    public Transform interactPoint => _interactPoint;

    public abstract void Interact();

    protected bool _canBeUsed = true;
    public bool canBeUsed => _canBeUsed;
}
