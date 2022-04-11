using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [Header("MOVE VARIABLES")]
    [SerializeField] private float _bulletMoveSpeed;
    [SerializeField] private float _bulletRotationSpeed;
    private Transform _target;
    private Vector3 _targetDirection;

    [Header("DAMAGE VARIABLES")]
    [SerializeField] private GameObject _finishBlow;
    [SerializeField] private float _bulletDamage;

    void Update()
    {
        if (_target != null)
        {
            MoveBullet();
        }
        else
        {
            Destroyer(gameObject.transform);
        }
    }
    private void MoveBullet()
    {
        _targetDirection = _target.position - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _bulletMoveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(_targetDirection), _bulletRotationSpeed);
    }
    public void DefineTarget(Transform targetTransform)
    {
        _target = targetTransform;
    }
    private void Destroyer(Transform blowSpawn)
    {
        if (_finishBlow != null)
        {
            Instantiate(_finishBlow, blowSpawn.position, Quaternion.Euler(0, 0, 0));
        }
        Destroy(gameObject);
    }
    public virtual void DamageEffect(GameObject enemy)
    {
        enemy.GetComponent<Enemy>().GetDamage(_bulletDamage);
        Destroyer(enemy.transform);
    }
}
