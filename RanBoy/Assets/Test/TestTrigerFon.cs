using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TrigerFon : MonoBehaviour
{
    public GameObject GaOb;
    
     void Start()
    {
        Debug.Log("GO");
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        if (GaOb.gameObject.tag == "Fon")
        {
            Debug.Log("GOOD");
            

            Instantiate(GaOb, new Vector2(49.2f, 2), Quaternion.identity);
            //EditorApplication.isPaused = true;
            Destroy(collision.gameObject,5f);
            


        }
    }

}
