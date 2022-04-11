using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roket : MonoBehaviour
{
    [SerializeField] float _roketMoveSpeed;
    [SerializeField] float _roketRotationSpeed;
    [SerializeField] float _roketamage;
    [SerializeField] GameObject _fleime;
    [SerializeField] float _blowRadius;


    public int NumderRoket;
    public GameObject Examination;
    private bool _queueRoket;
    private GameObject _target;
    private GameObject _roketContainer;
    private Quaternion _radius;
    private bool blow = false;
    // Start is called before the first frame update
    private void Awake()
    {
        GameEvents.StartRoketEvent += RoketQueue;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_queueRoket)
        {
            transform.SetParent(_roketContainer.transform);
            StartRoket();
        }              
    }
    private void OnDestroy()
    {
        GameEvents.StartRoketEvent -= RoketQueue;
    }
    private void RoketQueue(int number , GameObject target, GameObject roketConteiner, GameObject examination)
    {
        if ((NumderRoket == number)&&(Examination== examination))
        {
            _queueRoket = true;
            _target = target;
            _roketContainer = roketConteiner;
        }
    }
    private void StartRoket()
    {
        if (_target == null)
        {
            Destroy(gameObject);
        }
        else
        {
                _fleime.SetActive(true);
            //    _radius = Quaternion.LookRotation(_target.transform.position + _target.transform.forward - transform.position);
            //    transform.rotation = Quaternion.Slerp(transform.rotation, _radius, _roketRotationSpeed);
            //    //transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _roketMoveSpeed);
            //    transform.Translate(Vector3.forward * _roketMoveSpeed);
           var  _targetDirection = _target.transform.position - transform.position;
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _roketMoveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(_targetDirection), _roketRotationSpeed);
        }       
    }
    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.CompareTag(Tags.ENEMY_tag))
        {
            Explosion();
            Destroy(gameObject);
        }
    }
    private void Explosion()
    {
        var hits = Physics.SphereCastAll(transform.position, _blowRadius, -transform.up);
        foreach (var hit in hits)
        {
            var script = hit.collider.GetComponent<Enemy>();
            if (script != null)
            {
                script.GetDamage(_roketamage);
            }
        }
    }

}
