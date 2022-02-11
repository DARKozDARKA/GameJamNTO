using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryVisualizer : MonoBehaviour
{
    public Character character;
    public List<InstantItemOnHead> instantiatedGM;
    public Transform spawnPoint;

    private bool isSelling;

    public float maxAngle;

    private void Start()
    {
        character.inventory.OnAddSucceses += Instantiate;
        character.inventory.OnAllItemsRemoved += SellAll;
        instantiatedGM = new List<InstantItemOnHead>();
    }

    private void Update()
    {
        SetAngle(FromDirectionToAngle(character.mover.GetMoveTransition()));
    }

    public void Instantiate(ScriptableItem item)
    {
        Vector3 newPos;
        Quaternion newRot;

        if (instantiatedGM.Count == 0)
        {
            newPos = spawnPoint.position;
            newRot = spawnPoint.rotation;
        }
        else
        {
            newPos = instantiatedGM[instantiatedGM.Count - 1].instance.transform.position;
            newRot = instantiatedGM[instantiatedGM.Count - 1].instance.transform.rotation;
        }
        InstantItemOnHead instant = new InstantItemOnHead();

        instant.instance = Instantiate(item.headPrefab, newPos, newRot);
        instant.reference = item;

        if (instantiatedGM.Count == 0)
            instant.instance.transform.SetParent(spawnPoint);
        else
            instant.instance.transform.SetParent(instantiatedGM[instantiatedGM.Count - 1].instance.transform);
        Vector3 localPos = instant.instance.transform.localPosition;
        if (instantiatedGM.Count > 0) 
            localPos.y += instantiatedGM[instantiatedGM.Count - 1].reference.hightOfHeadPrefab;
        instant.instance.transform.localPosition = localPos;
        instantiatedGM.Add(instant);
    }

    public void SetAngle(Vector2 vector)
    {
        foreach (var item in instantiatedGM)
        {
            Vector3 rotation = item.instance.transform.localEulerAngles;
            rotation.x = -vector.y;
            rotation.z = vector.x;
            item.instance.transform.localEulerAngles = rotation;
        }
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

    public Vector2 FromDirectionToAngle(Vector2 direction)
    {
        Vector2 newAngle = new Vector2((direction.x + 1 / 2) * maxAngle, (direction.y - 1 / -2) * maxAngle);
        return newAngle;
    }
}

public class InstantItemOnHead
{
    public GameObject instance;
    public ScriptableItem reference;
}
