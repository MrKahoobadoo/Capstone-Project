using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILoseScreenScript : MonoBehaviour
{
    public bool gameIsOver;
    public PlayerRotater playerRotater;
    public CameraYRotate cameraYRotate;

    public GameObject endScreen;

    void Start()
    {
        gameIsOver = false;
        endScreen.SetActive(false);
    }

    void displayScreen()
    {
        if (gameIsOver)
        {
            endScreen.SetActive(true);
            playerRotater.menuOpen = true;
            cameraYRotate.menuOpen = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //Time.timeScale = 0;
        }
    }

    void Update()
    {
        displayScreen();
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnQuitButton()
    {
        SceneManager.LoadScene(0);
    }
}
