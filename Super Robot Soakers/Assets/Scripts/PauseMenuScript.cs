using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameLevel
{
    IKEA_Wave,
    Car
}

public class PauseMenuScript : MonoBehaviour
{
    public GameLevel type;
    public GameObject pauseMenu;
    public GameObject settingsPage;
    public SettingsScript settingsScript;

    // IKEA_Wave
    public PlayerRotater playerRotater;
    public CameraYRotate cameraYRotate;
    public RealPlayerController realPlayerController;

    // Car Game
    public CarScript carScript;
    public AudioSource engineSound;

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
        if (Input.GetKeyDown(KeyCode.Escape) && settingsScript.settingsActive == false)
        {
            if (!isOpen)
            {
                
                pauseMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                if (true)
                {
                    Time.timeScale = 0f;
                }

                switch (type)
                {
                    case GameLevel.IKEA_Wave:
                        playerRotater.menuOpen = true;
                        cameraYRotate.menuOpen = true;
                        realPlayerController.menuOpen = true;
                        break;
                    
                    case GameLevel.Car:
                        carScript.menuOpen = true;
                        if (engineSound.isPlaying)
                        {
                            engineSound.Stop();
                        }
                        break;
                }
                
                isOpen = true;
            }
            else
            {
                pauseMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
                isOpen = false;
                
                switch (type)
                {
                    case GameLevel.IKEA_Wave:
                        playerRotater.menuOpen = false;
                        cameraYRotate.menuOpen = false;
                        realPlayerController.menuOpen = false;
                        break;

                    case GameLevel.Car:
                        carScript.menuOpen = false;
                        if (!engineSound.isPlaying)
                        {
                            engineSound.Play();
                        }
                        break;
                }
            }
        }
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restarted");
        //Time.timeScale = 1;
    }

    public void OnSettingsButton()
    {
        settingsScript.settingsActive = true;
        pauseMenu.SetActive(false);
        settingsPage.SetActive(true);
    }

    public void OnQuitButton()
    {
        SceneManager.LoadScene(0);
        //Time.timeScale = 1;
    }
}
