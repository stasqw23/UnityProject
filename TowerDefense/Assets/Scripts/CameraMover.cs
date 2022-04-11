using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] float _speedCamera;
    private Camera _cam;
    private float _targetPos;
    private Vector3 _startPos;
    private Vector3 direction;

    void Start()
    {
        _cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _startPos = _cam.ScreenToWorldPoint(Input.mousePosition);
        else if (Input.GetMouseButton(0))
        {
            float pos = _startPos.z - Camera.main.ScreenToWorldPoint(Input.mousePosition).z;
            direction = new Vector3(0 , 0 , pos);
            _cam.transform.position += direction;
        }
    }
}
