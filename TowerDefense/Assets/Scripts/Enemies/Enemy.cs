using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using UnityEngine.UI;


public abstract class Enemy : MonoBehaviour
{
    [Header("MOVE VARIABLES")]
    public PathCreator _pathCreator;
    public float _speed;
    public float distanceTravelled;

    private float _startSpeed;

    [Header("HEALTH VARIABLES")]
    public float _startHealth;
    private float _currentHealth;

    [Header("REWARDS VARIABLES")]
    [SerializeField] private int _coinsForDie;
    [SerializeField] private int _extraСurrencyForDie;

    [Header("UI COMPONENTS")]
    [SerializeField] private GameObject _healthPointsBarObject;
    [SerializeField] private Image _healthPointsBarImage;

    [Header("MATERIALS VARIABLES")]
    [SerializeField] private GameObject _collorObject;
    private Material _material;

    private void Awake()
    {
        _currentHealth = _startHealth;
    }
    private void Start()
    {
        _startSpeed = _speed;
        _material = _collorObject.GetComponent<SkinnedMeshRenderer>().material;
    }
    private void OnDestroy()
    {
        GameEvents.CallScoreEvent(_extraСurrencyForDie);
        GameEvents.CallChangeGoldEvent(_coinsForDie);
    }
    void Update()
    {
        MoveAlongPath();
    }
    private void MoveAlongPath()
    {
        distanceTravelled += _speed * Time.deltaTime;
        transform.position = _pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = _pathCreator.path.GetRotationAtDistance(distanceTravelled);
    }
    private void Die()
    {
        GameEvents.Call_RemoveEnemyFromGunsLists(gameObject);
        Destroy(gameObject);
    }
    public virtual void GetDamage(float damage) //Засунь в GetDamage урон, который хочешь нанести врагу
    {
        _currentHealth -= damage;
        _healthPointsBarImage.fillAmount = _currentHealth / _startHealth;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }
    public void SetObjectCollor(Color setColor)
    {
        _material.color = setColor;
    }
    public void RefreshObjectParams()
    {
        _speed = _startSpeed;
    }
}
