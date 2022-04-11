using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Transform _camaera;
    [SerializeField] private Transform _healthUI;

    private void Start()
    {
        _camaera = GameObject.Find("Main Camera").transform;
    }
    void LateUpdate()
    {
        _healthUI.transform.LookAt(_healthUI.transform.position + _camaera.forward);
    }
}
