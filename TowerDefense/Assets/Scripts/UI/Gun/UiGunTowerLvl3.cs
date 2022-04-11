using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiGunTowerLvl3 : MonoBehaviour
{
    [SerializeField] private GameObject _menuPlatform;
    [SerializeField] private GameObject _closeCanvas;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _sellButton;


    private GameObject _aktiveCanvas;
    private bool _aktivePlatform = true;

    private void Awake()
    {
    }
    void Start()
    {
        _closeButton.onClick.AddListener(CloseCanvas);
        _sellButton.onClick.AddListener(Sell);
        _closeCanvas.GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {

    }
    private void CloseCanvas()
    {
        _aktiveCanvas.SetActive(false);
        _closeCanvas.SetActive(false);
    }
    private void OpenUIPlatform()
    {
        _menuPlatform.SetActive(true);
    }
    private void OnMouseDown()
    {
        if (_aktivePlatform)
        {

            _closeCanvas.SetActive(true);
            _aktiveCanvas = _menuPlatform;
            _aktiveCanvas.SetActive(true);
        }

    }
    private void Sell()
    {
        gameObject.GetComponentInParent<UIPlatform>()._aktivePlatform = true;
        GameEvents.CallChangeGoldEvent(gameObject.GetComponent<Gun>().CostSell);
        Destroy(gameObject);


    }
}
