using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExaminationHP : MonoBehaviour
{
    [SerializeField] private int _healthPoint;
    void Start()
    {
        GameEvents.CallHealthPointEvent(_healthPoint);
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Tags.ENEMY_tag))
        {
            _healthPoint -= 1;
            GameEvents.CallHealthPointEvent(_healthPoint);
        }
    }
}
