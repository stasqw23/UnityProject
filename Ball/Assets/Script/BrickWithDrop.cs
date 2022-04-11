using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BrickWithDrop : MonoBehaviour
{
   
    [SerializeField] private int _hp;
    [SerializeField] private Color _color1;
    [SerializeField] private int _addScore = 10;
    [SerializeField] private List<GameObject> _buf = new List<GameObject>();
    private Animator _animatorBrick;
    private SpriteRenderer _rendererBoll;
    
    void Start()
    {
        _animatorBrick = gameObject.GetComponent<Animator>();
        _rendererBoll = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        DestroyBrick();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _hp -= 1;
        _animatorBrick.SetInteger("HP", _hp);
        //_rendererBoll.color = _color1;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            _hp -= 1;
            _animatorBrick.SetInteger("HP", _hp);
            Destroy(collision.gameObject);
        }
    }
    private void DestroyBrick()
    {
        if (_hp == 0)
        {
            Destroy(gameObject);
            GameEvents.CallScoreEvent(_addScore);
            GetDrop();


        }
    }
    private void OnParticleCollision(GameObject other)
    {
        GetDrop();
        Destroy(gameObject);       
        GameEvents.CallScoreEvent(_addScore);
        Debug.Log("qwe");
    }
    private void GetDrop()
    {
        int asd = (Random.Range(0, _buf.Count));
        Instantiate(_buf[asd], transform.position, transform.rotation);
        
    }
}
