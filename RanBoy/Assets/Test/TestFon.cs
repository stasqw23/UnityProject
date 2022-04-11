using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fon : MonoBehaviour
{
    private Rigidbody2D rg;
    private Vector2 Move;
    private Transform tr;
    public float speed;

    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        Move = new Vector2 (-1,0);

    }

    
    void Update()
    {
        tr.Translate(Move*Time.deltaTime*speed);   
    }
    public void Destroy()
    {
        Destroy(gameObject);   
    }
}
