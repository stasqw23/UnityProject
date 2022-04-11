using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("FOLLOWING VARIABLES")]
    [SerializeField] private GameObject _gunHead;
    [SerializeField] private GameObject _mostNearEnemy;
    [SerializeField] private float _totalRotationSpeed;
    [SerializeField] private bool _gunRocketType;
    public List<GameObject> _enemiesInRange = new List<GameObject>() { };
    private Vector3 _enemyDirection;

    [Header("ATTACK VARIABLES")]
    [SerializeField] private GameObject _bulletSpawner;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _deleyBetweenShots;
    private float _currentTime;
    public GameObject _bulletContainer;
    public int Cost;
    public int CostSell;

    private void Awake()
    {
        GameEvents.RemoveEnemyFromGunsLists += RomoveEnemyFromList;
    }
    private void OnDestroy()
    {
        GameEvents.RemoveEnemyFromGunsLists -= RomoveEnemyFromList;
    }
    void Start()
    {

    }
    void Update()
    {
        FindMostNearEnemy();
        if (_mostNearEnemy != null)
        {
            ToEnemyGunsHeadRotation();
            Shot();
        }
        else
        {
            ToNormalPositionGunsHeadRotation();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Tags.ENEMY_tag))
        {
            _enemiesInRange.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Tags.ENEMY_tag))
        {
            _enemiesInRange.Remove(other.gameObject);
            if (_mostNearEnemy == other.gameObject)
            {
                _mostNearEnemy = null;
            }
        }
    }
    private void FindMostNearEnemy()
    {
        if (_enemiesInRange.Count != 0) //Если массив врагов не равен нулю
        {
            if (_enemiesInRange.Contains(_mostNearEnemy) == false) //Если в массиве врагов неопределен ближайший таргет
            {
                for(int i = 0; i < _enemiesInRange.Count; i++)
                {
                    if (_mostNearEnemy == null) //Устанавливает значение для ближайшего таргета, если тот отсутствует
                    {
                        _mostNearEnemy = _enemiesInRange[i];
                    }
                    else 
                    {
                        if (_enemiesInRange[i].GetComponent<Enemy>().distanceTravelled > _mostNearEnemy.GetComponent<Enemy>().distanceTravelled)
                        {
                            _mostNearEnemy = _enemiesInRange[i];
                        }
                    }
                }
            }
        }
    }
    public virtual void ToEnemyGunsHeadRotation()
    {
        _enemyDirection = _mostNearEnemy.transform.position - transform.position;
        _gunHead.transform.rotation = Quaternion.RotateTowards(_gunHead.transform.rotation, Quaternion.LookRotation(_enemyDirection), _totalRotationSpeed);
    }
    private void ToNormalPositionGunsHeadRotation()
    {
        _gunHead.transform.rotation = Quaternion.RotateTowards(_gunHead.transform.rotation, Quaternion.LookRotation(Vector3.forward), _totalRotationSpeed);
    }
    public virtual void Shot()
    {
        _currentTime += Time.deltaTime;
        if(_currentTime >= _deleyBetweenShots)
        {
            var lastBullet = Instantiate(_bullet, _bulletSpawner.transform.position, Quaternion.LookRotation(_enemyDirection));
            lastBullet.transform.SetParent(_bulletContainer.transform);
            lastBullet.GetComponent<Bullet>().DefineTarget(_mostNearEnemy.transform);
            _currentTime = 0;
        }
    }
    private void RomoveEnemyFromList(GameObject enemyWhichRemove) //Нужно подвязать к событию смерти
    {
        if(_enemiesInRange.Contains(enemyWhichRemove) == true)
        {
            _enemiesInRange.Remove(enemyWhichRemove);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if(_mostNearEnemy != null)
        {
            Gizmos.DrawLine(_gunHead.transform.position, _mostNearEnemy.transform.position);
        }
    }

}
