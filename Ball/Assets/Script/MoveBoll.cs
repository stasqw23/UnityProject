using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoll : MonoBehaviour
{
    [SerializeField] private GameObject _windowsLose;
    [SerializeField] private Rigidbody2D _RB;
    [SerializeField] private GameObject _platform;
    [SerializeField] private float _speed = 0.5f;
    [SerializeField] private Transform _gM;
    [SerializeField] private int _timeCounterSlow;
    [SerializeField] private int _timeCounterFast;
    [SerializeField] private GameObject _prefabBoll;
    [SerializeField] private int _hP;




    private Vector2 _direction;
    private bool _startBoton = false;
    private float _Xrot;

    private void Awake()
    {
        GameEvents.FastBrick += FasteBall;
        GameEvents.SlowBrick += SlowBrick;
        GameEvents.ThreeBoll += ThreeBalls;
        GameEvents.HP += HPPlatformCounter;
    }
    void Start()
    {
         GameEvents.CollHPEvent(_hP);
        _RB = GetComponent<Rigidbody2D>();
        _direction = transform.up;



    }
    private void Update()
    {
        if ((_hP <= 0))
        {
            _windowsLose.SetActive(true);
            Time.timeScale = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {    
        if (_startBoton == true)
        {
           // transform.parent = null;
            if (_RB.velocity.y ==  0f )
            {
                _RB.velocity = _direction * _speed;
            }
           
        }
        else if (Input.GetKey(KeyCode.Space)&&!_startBoton)
        {
            _startBoton = true;
            
        }
        else if (_RB.velocity.y != 0)
        {
            _startBoton = true;
        }
        else
        {
            transform.position = new Vector2(_platform.transform.position.x, transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            ThreeBalls();
        }
    }

    private void OnDestroy()
    {
        GameEvents.FastBrick -= FasteBall;
        GameEvents.SlowBrick -= SlowBrick;
        GameEvents.ThreeBoll -= ThreeBalls;
        GameEvents.HP -= HPPlatformCounter;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "death")
        {

            if (GameObject.FindGameObjectsWithTag("Ball").Length == 1)  
            {
                DeathBall();              
            }
          
            else
            {              
                Destroy(gameObject);
                
            }
        }


    }
    private void DeathBall()
    {
        
        
        GameEvents.CollHPEvent((_hP-1));
        _RB.velocity = new Vector2(0, 0);
        transform.position = new Vector2(_platform.transform.position.x, transform.position.y+0.6f);
        _startBoton = false;
        
        

    }
    private void FasteBall()
    {      
        _RB.AddForce(_RB.velocity, ForceMode2D.Impulse);
        StartCoroutine(TimeCounterCoroutineFast());
    }

    private void SlowBrick()
    {
        _RB.AddForce(-_RB.velocity * 0.5f, ForceMode2D.Impulse);       
        StartCoroutine(TimeCounterCoroutineSlow());
    }

    private void ThreeBalls()
    {
        Instantiate(_prefabBoll, transform.position, transform.rotation).gameObject.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0, 0 , 45) * _RB.velocity, ForceMode2D.Impulse);
        Instantiate(_prefabBoll, transform.position, transform.rotation).gameObject.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0, 0, -45) * _RB.velocity, ForceMode2D.Impulse);
    }
    private void HPPlatformCounter(int HP)
    {
        _hP = HP;
    }
    IEnumerator TimeCounterCoroutineSlow()
    {
        yield return new WaitForSeconds(_timeCounterSlow);
        _RB.AddForce(_RB.velocity, ForceMode2D.Impulse);

    }
    IEnumerator TimeCounterCoroutineFast()
    {
        yield return new WaitForSeconds(_timeCounterFast);
        _RB.AddForce(-_RB.velocity * 0.5f, ForceMode2D.Impulse);

    }
    //    private void OnCollisionEnter2D(Collision2D collision)
    //    {
    //        var VectorReflekt = Vector2.Reflect(_direction.normalized, collision.contacts[0].normal);
    //        _direction = VectorReflekt.normalized;
    //    }
}
