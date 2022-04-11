using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject _enemy;
    [SerializeField] PathCreator _patth;
    [SerializeField] float _exitGap;
    [SerializeField] float _hpIncrease;
    private float hp = 1;
    private bool _Corutine = true;
    void Start()
    {
        
    }

    void Update()
    {
        StartCoroutine(SpawnerCorutine());
    }

    IEnumerator SpawnerCorutine()
    {
        if (_Corutine)
        {
            _Corutine = false;
            yield return new WaitForSeconds(_exitGap);
            var enemy = Instantiate(_enemy, transform.position, transform.rotation);
            enemy.GetComponent<Enemy>()._startHealth += hp;
            enemy.GetComponent<Enemy>()._pathCreator = _patth;
            enemy.transform.SetParent(GameObject.Find("EnemyContainer").transform);
            hp += _hpIncrease;
            _Corutine = true;
        }
    }
}
