using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableTable : MonoBehaviour
{
    public InteractableTable_OutlineTrigger outlineTrigger;

    [SerializeField] private Transform _interactPoint;
    public Transform interactPoint => _interactPoint;
}
