using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    private float _Xrot;
    private float _Yrot;
    [SerializeField] private GameObject _youWinWindows; 
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _boundary;
    [SerializeField] private SpriteRenderer _platformNormSprite;
    [SerializeField] private SpriteRenderer _platformSmallSprite;
    [SerializeField] private SpriteRenderer _platformBigSprite;
    [SerializeField] private SpriteRenderer _platformGunSprite;
    [SerializeField] private int _timeBuffPlatform;
    [SerializeField] private GameObject _sizeBigPlatformColl;
    [SerializeField] private GameObject _sizeSmallPlatformColl;
    [SerializeField] private GameObject _bulletLeft;
    [SerializeField] private GameObject _bulletRight;
    [SerializeField] GameObject _bullet;
    [SerializeField] private int _numberOfShots;
    [SerializeField] private int _delayedShots;
    [SerializeField] private float _bulletSpeed;
    private Vector2 _plaerPosition;
    private CapsuleCollider2D _coll;


    private void Awake()
    {
      
    }

    void Start()
    {
        _plaerPosition = transform.position;
        _coll = GetComponent<CapsuleCollider2D>();
        
    }
    private void Update()
    {
        if (GameObject.FindWithTag("Brick") == false)
      {
            NextLvl();
      }
    }

    void FixedUpdate()
    {

        _Xrot = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(_Xrot , 0) * _speed);

        if (transform.position.x > _boundary )
        {
            transform.position = new Vector2(_boundary , transform.position.y);

        }
        if (transform.position.x < -_boundary)
        {
            transform.position = new Vector2(-_boundary , transform.position.y);       
            
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            BigPlatform();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            SmallPlatform();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlatformGun();
        }
    }

    private void SmallPlatform()
    {
        _platformNormSprite.enabled = false;
        _platformSmallSprite.enabled = true;
        _coll.size = _sizeSmallPlatformColl.GetComponent<SpriteRenderer>().size;
        StartCoroutine(TimeBuffPlatform());
    }
    private void BigPlatform()
    {
        _platformNormSprite.enabled = false;
        _platformBigSprite.enabled = true;
        _coll.size = _sizeBigPlatformColl.GetComponent<SpriteRenderer>().size;
        StartCoroutine(TimeBuffPlatform());
    }
    private void PlatformGun()
    {
        StartCoroutine(PlatformGunCoroutines());
    }

    
    private void Shot()
    {        
        Instantiate(_bullet, _bulletLeft.transform.position , _bulletLeft.transform.rotation);
        Instantiate(_bullet, _bulletRight.transform.position, _bulletLeft.transform.rotation);
        GameEvents.CollsSpeedBulledEvent(_bulletSpeed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "FastBrick(Clone)")
        {
            GameEvents.CollFastBrickEvent();
            Destroy(collision.gameObject);
        }
        if(collision.name == "SlowBrick(Clone)")
        {
            GameEvents.CollSlowBrickEvent();
            Destroy(collision.gameObject);
        }
        if(collision.name == "SmallPlatformBrick(Clone)")
        {
            SmallPlatform();
            Destroy(collision.gameObject);
        }
        if(collision.name == "BigPlatformBrick(Clone)")
        {
            BigPlatform();
            Destroy(collision.gameObject);
        }
        if(collision.name == "GunPlatformBrick(Clone)")
        {
            PlatformGun();
            Destroy(collision.gameObject);
        }
        if (collision.name == "ThreeBollBrick(Clone)")
        {
            GameEvents.CollThreeBollEvent();
            Destroy(collision.gameObject);
        }
        if (collision.name == "PlusHundredBrick(Clone)")
        {
            GameEvents.CallScoreEvent(100);
            Destroy(collision.gameObject);
        }
        if (collision.name == "PlusFiveHundredBrick(Clone)")
        {
            GameEvents.CallScoreEvent(500);
            Destroy(collision.gameObject);
        }
        if (collision.name == "MinusHundredBrick(Clone)")
        {
            GameEvents.CallScoreEvent(-100);
            Destroy(collision.gameObject);
        }
        if (collision.name == "MinusFiveHundredBrick(Clone)")
        {
            GameEvents.CallScoreEvent(-500);
            Destroy(collision.gameObject);
        }
    }
    private void NextLvl()
    {
        _youWinWindows.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Yo win");
    }
    IEnumerator TimeBuffPlatform()

    {
        yield return new WaitForSeconds(_timeBuffPlatform);
        
        {
            _platformNormSprite.enabled = true;
            _platformBigSprite.enabled = false;
            _platformSmallSprite.enabled = false;
            _coll.size = gameObject.GetComponent<SpriteRenderer>().size;
        }

    }
    IEnumerator PlatformGunCoroutines()
    {
        _platformNormSprite.enabled = false;
        _platformGunSprite.enabled = true;
        for( int i = 0 ; i <= _numberOfShots; i++)
        {
            Shot();
            yield return new WaitForSeconds(_delayedShots);
        }
        _platformNormSprite.enabled = true;
        _platformGunSprite.enabled = false;
    }



}
