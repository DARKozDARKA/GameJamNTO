using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table_skinChanger : MonoBehaviour
{
    public InteractableTable table;
    private GameObject modelGM;
    public Material normalMat, selectedMat, buyedMat;
    [SerializeField] private Renderer render;

    private void Awake()
    {
        if (table is Item_Table)
        {
            ((Item_Table)table).OnModelSet += SetModel;
        }
    }

    private void Start()
    {
        if (render == null)
            render = GetComponent<Renderer>();
        table.outlineTrigger.onPlayerEnter.AddListener(SetSelected);
        table.outlineTrigger.onPlayerExit.AddListener(SetUnselected);
        table.OnDisableInteractive.AddListener(SetBuyed);
        SetUnselected();

    }

    public void SetModel(GameObject model)
    {
        modelGM = model;
        ((Item_Table)table).OnModelSet -= SetModel;
    }

    public void SetSelected()
    {
        render.material = selectedMat;
    }
    public void SetUnselected()
    {
        render.material = normalMat;
    }
    public void SetBuyed()
    {
        table.outlineTrigger.SetChoose(false);
        modelGM.SetActive(false);
        render.material = buyedMat;
    }
}
