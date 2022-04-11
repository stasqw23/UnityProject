using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesSwicher : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void ScenLoad(string ScenName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(ScenName);
    }
}
