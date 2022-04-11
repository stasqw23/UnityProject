using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;

public class Mover : MonoBehaviour

{
    private bool Buton;
    private Rigidbody2D rb;
    private Vector2 Direckt;
    private Transform tr;
    public float JumpForse;
    private Animator am;
    private string gm;
    [SerializeField] private GameObject _youLose;






    void Start()
    {
        
        am = GetComponent<Animator>();
        tr = GetComponent<Transform>();
        Direckt = new Vector2(0, 0);
        rb = GetComponent<Rigidbody2D>();
        

    }
    
    public void OnClic()
    {

       if (Buton == true)
            rb.AddForce(transform.up * JumpForse, ForceMode2D.Impulse);

    }
 
    void Update()
    {
        if 
            (rb.velocity.y < 0)
        {
            am.SetTrigger("Fall");
            
        }    
        else 
            am.ResetTrigger("Fall");
        if (rb.velocity.y > 0)
        {
            am.SetTrigger("Jump");

        }
        else
            am.ResetTrigger("Jump");
    }

    private void Death()
    {
        //  Debug.Log("123");
        // Debug.Break();
        am.SetTrigger("Death");
        Time.timeScale = 0;
        _youLose.SetActive(true);

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Platdorm") && (rb.velocity.y == 0))
            Buton = true;
    }
  
    private void OnCollisionExit2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Platdorm")&&(rb.velocity.y == JumpForse))
        {
          
          
           // am.SetTrigger("Jump");
            
        }
        Buton = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Death();



        }  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Platdorm") && (rb.velocity.y == 0))
        {
            am.SetTrigger("Lending");
            


        }
    }
    

}


