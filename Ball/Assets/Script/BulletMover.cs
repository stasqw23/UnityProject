using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    private float _speed;
    
    void Awake()
    {
        GameEvents.SpeedBulled += Mover;
        
    }
    private void OnDestroy()
    {
        GameEvents.SpeedBulled -= Mover;
    }

    void Update()
    {
        transform.Translate(transform.up * _speed);
    }
    private void Mover(float speed)
    {
        _speed = speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "balka")
        {
            Destroy(gameObject);
        }
    }
}
