﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryVisualizer : MonoBehaviour
{
    public Inventory inventory;
    public List<InstantItemOnHead> instantiatedGM;
    public Transform spawnPoint;

    private bool isSelling;

    private void Start()
    {
        inventory.OnAddSucceses += Instantiate;
        inventory.OnAllItemsRemoved += SellAll;
        instantiatedGM = new List<InstantItemOnHead>();
    }

    public void Instantiate(ScriptableItem item)
    {
        Vector3 newSpawn = spawnPoint.position;
        newSpawn.y += CulculateHight();
        InstantItemOnHead instant = new InstantItemOnHead();
        instant.instance = Instantiate(item.headPrefab, newSpawn, spawnPoint.rotation);
        instant.reference = item;
        instant.instance.transform.SetParent(spawnPoint);
        instantiatedGM.Add(instant);
    }

    public void SellAll()
    {
        if(!isSelling)
            StartCoroutine(Selling());
    }

    private IEnumerator Selling()
    {
        isSelling = true;
        for (int i = instantiatedGM.Count - 1; i >= 0; i--)
        {
            Destroy(instantiatedGM[i].instance);
            instantiatedGM.Remove(instantiatedGM[i]);
            yield return new WaitForSeconds(0.25f);
        }
        isSelling = false;
    }

    private float CulculateHight()
    {
        float hight = 0;

        foreach (var item in instantiatedGM)
        {
            hight += item.reference.hightOfHeadPrefab;
        }
        print(instantiatedGM.Count + " " + hight);
        return hight;
    }
}

public class InstantItemOnHead
{
    public GameObject instance;
    public ScriptableItem reference;
}
