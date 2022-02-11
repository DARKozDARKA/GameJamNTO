using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Item_Table : InteractableTable
{
    [SerializeField] private ScriptableItem[] scriptableItems;
    [SerializeField] private Transform _itemPoint;
    [SerializeField] private GameObject _stoleEffect;
    public ScriptableItem scriptableItem;
    public int weight => scriptableItem.weight;
    public Action<GameObject> OnModelSet;



    private void Start()
    {
        StallHandler.Instance.AddNewItem(this);
        scriptableItem = scriptableItems[UnityEngine.Random.Range(0, scriptableItems.Length)];
        var newModel = Instantiate(scriptableItem.headPrefab, _itemPoint.position, _itemPoint.rotation);
        newModel.transform.parent = transform;
        OnModelSet?.Invoke(newModel);
    }

    public override void Interact()
    {
        if (_canBeUsed is false) return;
        OnDisableInteractive.Invoke();
        _canBeUsed = false;
        StallHandler.Instance.RemoveItem(this);
        OnCancel?.Invoke();
        OnDisableInteractive.RemoveAllListeners();
        Instantiate(_stoleEffect, new Vector3(_itemPoint.position.x, _itemPoint.position.y + 1, _itemPoint.position.z), Quaternion.identity);
    }


}
