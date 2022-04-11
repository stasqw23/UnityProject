using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdBullet : Bullet
{
    [SerializeField] private int _coldBuffDuration;
    [SerializeField] private int _coldBuffTiks;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.ENEMY_tag))
        {
            var target = other.gameObject.GetComponent<Buffs>();
            if (target.coldBuffActive == true) // Если на объекте нет бафа
            {
                target.ColdBuffRestart(_coldBuffDuration, _coldBuffTiks);
            }
            else if (target.coldBuffActive == false)
            {
                target.StartColdBuff(_coldBuffDuration, _coldBuffTiks);
            }
            DamageEffect(other.gameObject);
        }
    }
}
