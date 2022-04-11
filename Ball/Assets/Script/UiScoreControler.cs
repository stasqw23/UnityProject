using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiScoreControler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textScore;
    private int _totalScore;
    void Awake()
    {
        GameEvents.Score += AddScore;   
    }
    private void OnDestroy()
    {
        GameEvents.Score -= AddScore;
    }


    private void AddScore(int Score)
    {
        _totalScore += Score;
        _textScore.SetText($"Score: {_totalScore}");

    }
}
