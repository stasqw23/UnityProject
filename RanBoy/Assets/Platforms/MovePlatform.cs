using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public float PlatformSpeed;
    private Vector2 Move;
    private Transform tr;
    private Rigidbody2D rg;
    private GameObject gm;
    void Start()
    {

        Move = new Vector2(-1,0);
        tr = GetComponent<Transform>();
        rg = GetComponent<Rigidbody2D>();
        gm = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.Translate(Move*PlatformSpeed*Time.deltaTime);
       
    }
    private void OnBecameInvisible()
    {
        if (tr.position.x < 18)
        {
            Debug.Log("GOOD");
            Destroy(gameObject);
        }
    }
}

