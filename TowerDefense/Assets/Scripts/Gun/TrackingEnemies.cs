using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingEnemies : MonoBehaviour
{
    
    [SerializeField] private float _speedlaser;
    [SerializeField] private float _turnSpeed;

    [SerializeField] private GameObject _headGun;
    [SerializeField] private LineRenderer _laser;
    [SerializeField] private GameObject _laserGameObject;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speedAnimation;

    private GameObject _enemyNear;

    public List<GameObject> _enemyList = new List<GameObject>() { };
    public int Cost;
    public int CostSell;

    private void Awake()
    {
        GameEvents.RemoveEnemyFromGunsLists += RomoveEnemyFromList;
    }
    private void OnDestroy()
    {
        GameEvents.RemoveEnemyFromGunsLists += RomoveEnemyFromList;
    }
    void FixedUpdate()
    {

        if (_enemyList.Count != 0)
        {
            Debug.Log(_enemyNear);
            _animator.SetFloat("speed",_speedAnimation);
            LookAtXY(_headGun.transform, FindMostNearEnemy().transform.position, _turnSpeed);
            _laser.SetPosition(1,new Vector3 (0, 0, (FindMostNearEnemy().transform.position - _laserGameObject.transform.position).magnitude));
            
        }
        else 
        {
            _animator.SetFloat("speed", 1f);
            LookAtXY(_headGun.transform, new Vector3(0, 0, 0), _turnSpeed);
            _laser.SetPosition(1, new Vector3(0, 0, 0));         
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
    private void LookAtXY(Transform transform, Vector3 point, float speed)
    {

        var direction = (point - _laserGameObject.transform.position).normalized;
        transform.rotation = Quaternion.RotateTowards( transform.rotation, Quaternion.LookRotation(direction), speed);

    }
    private GameObject FindMostNearEnemy()
    {

        foreach (GameObject enemy in _enemyList)
        { 
           
             if ((_enemyNear == null) || (_enemyList.Contains(_enemyNear) == false) || ((enemy.GetComponent<Enemy>().distanceTravelled >= _enemyNear.GetComponent<Enemy>().distanceTravelled) ))
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
}
