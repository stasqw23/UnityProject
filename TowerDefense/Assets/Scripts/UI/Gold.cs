using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    [SerializeField] private Text _goldText;
    [SerializeField] private int _startGold;
    private int _gold;

    private void Awake()
    {
        GameEvents.ChangeGoldEvent += GoldChange;
    }
    void Start()
    {
        GoldChange(_startGold);


    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GoldChange(10);

        }
    }
    private void OnDestroy()
    {
        GameEvents.ChangeGoldEvent -= GoldChange;
    }
    private void GoldChange (int gold)
    {
        
        if ((_gold + gold) >= 0)
        {
            _gold += gold;
            _goldText.text = $"Gold:{_gold}";           
            GameEvents.CallPermissionEvent(true);
        }
        else
        {           
            GameEvents.CallPermissionEvent(false);
        }

    }
   
}
