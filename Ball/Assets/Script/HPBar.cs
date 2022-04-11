using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HPBar : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _hPBar;
    //[SerializeField] private int _helsPoint;

    private void Awake()
    {
        GameEvents.HP += HPCounter;
        
    }

    void Start()
    {
      //  GameEvents.CollHPEvent(_helsPoint);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        GameEvents.HP -= HPCounter;

    }
    private void  HPCounter(int HP)
    {
        _hPBar.SetText($"{HP}");

    }
}
