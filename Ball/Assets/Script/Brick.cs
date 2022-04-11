using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private int _hp;
    [SerializeField] private Color _color1;
    [SerializeField] private int _addScore = 10;
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
        if(collision.tag == "bullet")
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
            

        }
    }
    private void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
        GameEvents.CallScoreEvent(_addScore);
        
    }
}
