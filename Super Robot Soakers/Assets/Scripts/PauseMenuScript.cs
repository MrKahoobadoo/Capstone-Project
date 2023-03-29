using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsPage;
    public PlayerRotater playerRotater;
    public CameraYRotate cameraYRotate;

    private bool isOpen;

    void Start()
    {
        pauseMenu.SetActive(false);
        isOpen = false;
    }

    void Update()
    {
        OpenCloseMenu();
    }

    void OpenCloseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isOpen)
            {
                
                pauseMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                playerRotater.menuOpen = true;
                cameraYRotate.menuOpen = true;
                Time.timeScale = 0;
                isOpen = true;
            }
            else
            {

                pauseMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                playerRotater.menuOpen = false;
                cameraYRotate.menuOpen = false;
                Time.timeScale = 1;
                isOpen = false;
            }
        }
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void OnSettingsButton()
    {
        pauseMenu.SetActive(false);
        settingsPage.SetActive(true);
    }

    public void OnQuitButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
