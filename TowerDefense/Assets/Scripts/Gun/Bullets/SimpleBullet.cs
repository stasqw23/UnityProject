using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : Bullet
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.ENEMY_tag))
        {
            DamageEffect(other.gameObject);
        }
    }
}
