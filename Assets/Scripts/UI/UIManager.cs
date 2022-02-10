using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    internal PlayerBehaviour player;
    [SerializeField] private UIInventory _inventory;
    public UIInventory inventory => _inventory;
    [SerializeField] private UIMoney _money;
    public UIMoney money => _money;
    [SerializeField] private EasyUI.PickerWheelUI.PickerWheel _wheel;
    public EasyUI.PickerWheelUI.PickerWheel wheel => _wheel;


}
