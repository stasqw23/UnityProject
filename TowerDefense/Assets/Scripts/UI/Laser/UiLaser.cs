using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiLaser : MonoBehaviour
{
    [SerializeField] private GameObject _menuPlatform;
    [SerializeField] private GameObject _closeCanvas;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _sellButton;
    [SerializeField] private Button _gunTowerButton;
    [SerializeField] private Button _laserTowerButton;
    [SerializeField] private Button _roketTowerButton;
    [SerializeField] private GameObject _gunTower;
    [SerializeField] private GameObject _laserTower;
    [SerializeField] private GameObject _roketTower;
    [SerializeField] private Text _costGunTower;
    [SerializeField] private Text _costLaserTower;
    [SerializeField] private Text _costRoketTower;
    private bool _permission;


    private GameObject _aktiveCanvas;
    private bool _aktivePlatform = true;


    private void Awake()
    {
        GameEvents.PermissionEvent += PermissionSet;
    }
    void Start()
    {
        _closeButton.onClick.AddListener(CloseCanvas);
        _gunTowerButton.onClick.AddListener(SpawnGunTower);
        _laserTowerButton.onClick.AddListener(SpawnLaserTower);
        _roketTowerButton.onClick.AddListener(SpawnRoketTower);
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
            _costGunTower.text = $"Cost: {_gunTower.GetComponent<TrackingEnemies>().Cost}";
            _costRoketTower.text = $"Cost: {_roketTower.GetComponent<TrackingEnemies>().Cost}";
            _costLaserTower.text = $"Cost: {_laserTower.GetComponent<TrackingEnemies>().Cost}";
        }

    }
    private void SpawnGunTower()
    {
        GameEvents.CallChangeGoldEvent(-_gunTower.GetComponent<TrackingEnemies>().Cost);
        if (_permission)
        {
            var Gun = Instantiate(_gunTower, transform);
            Gun.GetComponent<TrackingEnemies>().CostSell = gameObject.GetComponent<TrackingEnemies>().CostSell + _gunTower.GetComponent<TrackingEnemies>().Cost;
            Gun.transform.SetParent(transform.parent);
            CloseCanvas();
            _aktivePlatform = false;
            Destroy(gameObject);
        }

    }
    private void SpawnLaserTower()
    {
        GameEvents.CallChangeGoldEvent(-_laserTower.GetComponent<TrackingEnemies>().Cost);
        if (_permission)
        {
            var Gun = Instantiate(_laserTower, transform);
            Gun.GetComponent<TrackingEnemies>().CostSell = gameObject.GetComponent<TrackingEnemies>().CostSell + _laserTower.GetComponent<TrackingEnemies>().Cost;
            Gun.transform.SetParent(transform.parent);
            CloseCanvas();
            _aktivePlatform = false;
            Destroy(gameObject);
        }
    }
    private void SpawnRoketTower()
    {
        GameEvents.CallChangeGoldEvent(-_roketTower.GetComponent<TrackingEnemies>().Cost);
        if (_permission)
        {
            var Gun = Instantiate(_roketTower, transform);
            Gun.GetComponent<TrackingEnemies>().CostSell = gameObject.GetComponent<TrackingEnemies>().CostSell + _roketTower.GetComponent<TrackingEnemies>().Cost;
            Gun.transform.SetParent(transform.parent);
            CloseCanvas();
            _aktivePlatform = false;
            Destroy(gameObject);
        }
    }
    private void PermissionSet(bool permission)
    {
        _permission = permission;
    }
    private void Sell()
    {
        gameObject.GetComponentInParent<UIPlatform>()._aktivePlatform = true;
        GameEvents.CallChangeGoldEvent(gameObject.GetComponent<TrackingEnemies>().CostSell);
        Destroy(gameObject);
    }
}
