using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXDestroyer : MonoBehaviour
{
    [SerializeField] private float _destroyAfter = 1;
    private void Start()
    {
        Destroy(gameObject, _destroyAfter);
    }

}
