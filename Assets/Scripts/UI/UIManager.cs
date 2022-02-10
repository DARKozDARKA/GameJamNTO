using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIInventory _inventory;
    public UIInventory inventory => _inventory;

}
