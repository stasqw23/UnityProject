using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : Bullet
{
    [SerializeField] private int _fireBuffDuration;
    [SerializeField] private int _fireBuffTiks;
    [SerializeField] private int _tikDamage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.ENEMY_tag))
        {
            var target = other.gameObject.GetComponent<Buffs>();
            if (target.fireBuffActive == true) // Если на объекте нет бафа
            {
                target.FireBuffRestart(_fireBuffDuration, _fireBuffTiks, _tikDamage);
            }
            else if (target.fireBuffActive == false)
            {
                target.StartFireBuff(_fireBuffDuration, _fireBuffTiks, _tikDamage);
            }
            DamageEffect(other.gameObject);
        }
    }
}
