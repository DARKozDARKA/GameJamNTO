using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_SkinChanger : MonoBehaviour
{
    public List<GameObject> skins;

    private void Start()
    {
        int rand = Random.Range(0, skins.Count);
        skins.Remove(skins[rand]);
        foreach (var item in skins)
        {
            Destroy(item);
        }
    }
}
