using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    [Header("ENEMY VARIABLES")]
    private Enemy _thisEnemy;

    [Header("COLD BUFF VARIABLES")]
    [SerializeField] private float _slow;
    public bool coldBuffActive = false;

    [Header("FIRE BUFF VARIABLES")]
    [SerializeField] private int _fireBuffDuration;
    [SerializeField] private int _fireBuffTiks;
    [SerializeField] GameObject _fireEffect;
    public bool fireBuffActive = false;

    private void Start()
    {
        _thisEnemy = gameObject.GetComponent<Enemy>();
    }
    public void StartColdBuff(int _buffDuration, int _buffTiks)
    {
        coldBuffActive = true;
        _thisEnemy._speed = _thisEnemy._speed * _slow;
        _thisEnemy.SetObjectCollor(Color.blue);
        StartCoroutine(ColdBuffAction(_buffDuration, _buffTiks));
    }
    public void StopColdBuff()
    {
        coldBuffActive = false;
        _thisEnemy.RefreshObjectParams();
        _thisEnemy.SetObjectCollor(Color.white);
    }
    IEnumerator ColdBuffAction(int _buffDuration, int _buffTiks)
    {
        for (int i = 0; i <= _buffTiks; i++)
        {
            yield return new WaitForSeconds(_buffDuration);
        }
        StopColdBuff();
    }
    public void ColdBuffRestart(int _buffDuration, int _buffTiks)
    {
        StopCoroutine("ColdBuffAction");
        StartColdBuff(_buffDuration, _buffTiks);
    }



    public void StartFireBuff(int _buffDuration, int _buffTiks, int _tikDamage)
    {
        fireBuffActive = true;
        _fireEffect.SetActive(true);
        _thisEnemy.SetObjectCollor(Color.blue);
        StartCoroutine(FireBuffAction(_buffDuration, _buffTiks, _tikDamage));
    }
    public void StopFireBuff()
    {
        _fireEffect.SetActive(false);
        fireBuffActive = false;
        _thisEnemy.RefreshObjectParams();
        _thisEnemy.SetObjectCollor(Color.white);

    }
    IEnumerator FireBuffAction(int _buffDuration, int _buffTiks, int _tikDamage)
    {
        for (int i = 0; i <= _buffTiks; i++)
        {
            _thisEnemy.GetDamage(_tikDamage);
            yield return new WaitForSeconds(_buffDuration);
        }
        StopColdBuff();
    }
    public void FireBuffRestart(int _buffDuration, int _buffTiks, int _tikDamage)
    {
        StopCoroutine("FireBuffAction");
        StartFireBuff(_buffDuration, _buffTiks, _tikDamage);
    }


}
