using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exiter : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        Exit();
    }
    
    void Exit()
    {
        // restarts scene
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(4);
        }

        // opens menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
