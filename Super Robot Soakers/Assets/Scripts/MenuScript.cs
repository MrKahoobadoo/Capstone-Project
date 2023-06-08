using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject theCanvas;
    public GameObject otherCanvas;

    void Start()
    {
        theCanvas.SetActive(true);
        otherCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }
    
    // main buttons
    public void OnPlayButton()
    {
        otherCanvas.SetActive(true);
        theCanvas.SetActive(false);
    }

    public void OnBackButton()
    {
        otherCanvas.SetActive(false);
        theCanvas.SetActive(true);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

    // levels
    public void OpenWaveGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenDrivingGame()
    {
        SceneManager.LoadScene(2);
    }

    public void OpenOSUGame()
    {
        SceneManager.LoadScene(3);
    }

    public void OpenRunningGame()
    {
        SceneManager.LoadScene(4);
    }
}
