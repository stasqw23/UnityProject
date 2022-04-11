using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    [SerializeField] private float _damageLaser;
    [SerializeField] private float _damageInterval;
    private bool _corutine = true;
    


    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        GetComponent<CapsuleCollider>().center = new Vector3(0,0, GetComponent<LineRenderer>().GetPosition(1).z);
    }
    private void OnTriggerStay(Collider collision)
    {      
        if ((_corutine) && (collision.CompareTag(Tags.ENEMY_tag)))
        {
            StartCoroutine(Damage(collision.gameObject));
        }
    }
    private IEnumerator Damage(GameObject other)
    {
        _corutine = false;        
        
        other.GetComponent<Enemy>().GetDamage(_damageLaser);
        Debug.Log("qwe");      
        yield return new WaitForSeconds(_damageInterval);
        _corutine = true;
    }
    
}
