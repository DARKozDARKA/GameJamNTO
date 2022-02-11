using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table_skinChanger : MonoBehaviour
{
    public InteractableTable table;
    public GameObject modelGM;
    public Material normalMat, selectedMat, buyedMat;
    private Renderer render;

    private void Start()
    {
        render = GetComponent<Renderer>();
        table.outlineTrigger.onPlayerEnter.AddListener(SetSelected);
        table.outlineTrigger.onPlayerExit.AddListener(SetUnselected);
        table.OnDisableInteractive.AddListener(SetBuyed);
        SetUnselected();

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
