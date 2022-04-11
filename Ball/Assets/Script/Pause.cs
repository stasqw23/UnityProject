using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _VindowsPause;
    [SerializeField] private Button _pause;
    [SerializeField] private Button _resume;
    [SerializeField] private Button _exit;
    void Start()
    {
        _pause.onClick.AddListener(PauseMenu);
        _resume.onClick.AddListener(ResResume);
        _exit.onClick.AddListener(ExitGame);
    }

    void Update()
    {
        
    }
   private void PauseMenu()
    {
        _VindowsPause.SetActive(true);
        Time.timeScale = 0;
    }
    private void ResResume()
    {
        _VindowsPause.SetActive(false);
        Time.timeScale = 1;
    }
    private void ExitGame ()
    {
        Application.Quit();
    }
}
