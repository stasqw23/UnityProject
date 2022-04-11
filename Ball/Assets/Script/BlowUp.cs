using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowUp : MonoBehaviour
{
    [SerializeField] GameObject BlowParticle;
    [SerializeField] int _addScore;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BlowUpBrick();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            BlowUpBrick();
        }
    }
    private void BlowUpBrick()
    {
        Instantiate(BlowParticle, transform.position, transform.rotation);
        Destroy(gameObject);
        GameEvents.CallScoreEvent(_addScore);
    }
}
