﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public abstract class InteractableTable : MonoBehaviour
{
    public InteractableTable_OutlineTrigger outlineTrigger;

    [SerializeField] private Transform _interactPoint;
    public Transform interactPoint => _interactPoint;

    public UnityEvent OnDisableInteractive;
    public Action<InteractableTable> OnCancel;
    public abstract void Interact();

    protected bool _canBeUsed = true;
    public bool canBeUsed => _canBeUsed;


}