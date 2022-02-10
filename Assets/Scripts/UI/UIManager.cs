using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    internal PlayerBehaviour player;
    [SerializeField] private UIInventory _inventory;
    public UIInventory inventory => _inventory;

}
