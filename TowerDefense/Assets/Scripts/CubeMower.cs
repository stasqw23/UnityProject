using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMower : MonoBehaviour
{
    [SerializeField] private GameObject _firstPosition;
    [SerializeField] private GameObject _secondPosition;
    [SerializeField] private float _speed;
        void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _secondPosition.transform.position, _speed );
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
        }
    }
}
