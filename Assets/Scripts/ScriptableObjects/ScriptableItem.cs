using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Items/NewItem", order = 1)]
public class ScriptableItem : ScriptableObject
{
    public Vector2Int instanceSize;
    public int weight;
    public int cost;
    public GameObject prefab;
}
