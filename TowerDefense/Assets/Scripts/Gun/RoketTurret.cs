using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoketTurret : MonoBehaviour
{
    
    [SerializeField] private List<Transform> _roketList = new List<Transform>() { };
    [SerializeField] private GameObject _prefabRoket;
    [SerializeField] private GameObject _roketContainer;
    [SerializeField] private GameObject _headGun;
    [SerializeField] private int _delayShot;
    [SerializeField] private int _delayReload;
    [SerializeField] private float _turnSpeed;   

    private GameObject _roketPrefab;
    private GameObject _enemyNear;
    private bool _reloadStatus = false;
    private bool _corutine = true;
    public int Cost;
    public int CostSell;



    public List<GameObject> _enemyList = new List<GameObject>() { };

    private void Awake()
    {
        GameEvents.RemoveEnemyFromGunsLists += RomoveEnemyFromList;
    }
    private void OnDestroy()
    {
        GameEvents.RemoveEnemyFromGunsLists += RomoveEnemyFromList;
    }
    private void Start()
    {
        _roketContainer = GameObject.Find("ROKET CONTAINER");
    }
    void FixedUpdate()
    {       
        if ((_enemyList.Count != 0))
        {
       
            LookAtX(_headGun.transform, FindMostNearEnemy().transform.position, _turnSpeed);
            if (_corutine) 
            {
                StartCoroutine(ResetRoket());
                StartCoroutine(StartRoket());
            }
        }
        else
        {         
            LookAtX(_headGun.transform, new Vector3(0, 0, 0), _turnSpeed);
            if (_corutine)
            {
                StartCoroutine(ResetRoket());
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.ENEMY_tag))
        {
            _enemyList.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Tags.ENEMY_tag))
        {
            _enemyList.Remove(other.gameObject);
        }
    }
    private void LookAtX(Transform transform, Vector3 point, float speed)
    {
        var direction = (point - _headGun.transform.position).normalized;
        direction.y = 0;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), speed);

    }
    private GameObject FindMostNearEnemy()
    {
        foreach (GameObject enemy in _enemyList)
        {
            if ((_enemyNear == null) || (_enemyList.Contains(_enemyNear) == false) || ((enemy.GetComponent<Enemy>().distanceTravelled >= _enemyNear.GetComponent<Enemy>().distanceTravelled)))
                _enemyNear = enemy;
        }
        return _enemyNear;
    }
    private void RomoveEnemyFromList(GameObject enemyWhichRemove) 
    {
        if (_enemyList.Contains(enemyWhichRemove) == true)
        {
            _enemyList.Remove(enemyWhichRemove);
        }
    }
    private IEnumerator ResetRoket()
    {
        _corutine = false;
        if (_reloadStatus==false)
        {        
            int i = 0;
            foreach (Transform element in _roketList)
            {                
                _roketPrefab = Instantiate(_prefabRoket, element);
                _roketPrefab.GetComponent<Roket>().NumderRoket = i;
                _roketPrefab.GetComponent<Roket>().Examination = gameObject;
                yield return new WaitForSeconds(_delayReload);
                i++;
            }
            _reloadStatus = true;
            _corutine = true;
        }        
    }  
    private IEnumerator StartRoket()
    {
        _corutine = false;
        if (_reloadStatus)
        {
            int i = 0;
            foreach (Transform element in _roketList)
            {
                GameEvents.CallStartRoketEvent(i,_enemyNear, _roketContainer,gameObject);
                yield return new WaitForSeconds(_delayShot);
                i++;
            }
            _reloadStatus = false;
            _corutine = true;
        }     
    }
}
