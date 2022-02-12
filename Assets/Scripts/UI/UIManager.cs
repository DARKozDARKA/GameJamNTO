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
    [SerializeField] private UITimer _timer;
    public UITimer timer => _timer;
    [SerializeField] private UIScreens _screens;
    public UIScreens screens => _screens;
    [SerializeField] private WinMenu _winMenu;
    public WinMenu winMenu => _winMenu;



}
