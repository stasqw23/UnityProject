using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthPoint : MonoBehaviour
{
    [SerializeField] private Text _hpScore;
    [SerializeField] private Text _scoreText;
    [SerializeField] private int _score;
    [SerializeField] private GameObject _endGame;
    [SerializeField] private Text _scoreEndText;
    private void Awake()
    {
        GameEvents.HealthPointEvent += ChangeHP;
        GameEvents.ScoreEvent += ScoreAdd;
    }
    private void OnDestroy()
    {
        GameEvents.HealthPointEvent -= ChangeHP;
        GameEvents.ScoreEvent -= ScoreAdd;

    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void ChangeHP(int HP)
    {
        _hpScore.text = $"{HP}";
        if(!(HP>0))
        {          
            _endGame.SetActive(true);
            _scoreEndText.text = $"{_score}";
            Time.timeScale = 0;
        }
    }
    private void ScoreAdd(int score)
    {
        _score += score;
        _scoreText.text = $"{_score}";
    }

}
