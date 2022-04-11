using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lose : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _scoreWin;
    [SerializeField] private Button _exit;
    [SerializeField] private Button _reboot;
    private int _scoreCount;

    private void Awake()
    {
        GameEvents.Score += Score;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        _score.SetText($"You Score: {_scoreCount}");
        _scoreWin.SetText($"You Score: {_scoreCount}");

    }
    private void OnDestroy()
    {
        GameEvents.Score -= Score;
    }
    private void Score(int score)
    {
        _scoreCount = score;
    }
    private void ExitGame()
    {
        Application.Quit();
    }
    private void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lvl1");
    }
}
