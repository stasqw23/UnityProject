using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pauseWindow;
    [SerializeField] private Button _continue;
    [SerializeField] private Button _exit;
    [SerializeField] private Button _pause;
    [SerializeField] private Button _reload;
    void Start()
    {
        _continue.onClick.AddListener(Continue);
        _exit.onClick.AddListener(Exit);
        _pause.onClick.AddListener(PauseWindow);
        _reload.onClick.AddListener(Reload);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Continue()
    {
        _pauseWindow.SetActive(false);
        Time.timeScale = 1;
    }
    private void Exit()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
    }
    private void PauseWindow()
    {
        _pauseWindow.SetActive(true);
        Time.timeScale = 0;

    }
    private void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
