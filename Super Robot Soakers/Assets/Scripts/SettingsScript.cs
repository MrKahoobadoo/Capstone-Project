using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    public GameObject settingsPage;
    public GameObject pauseMenu;
    public PlayerRotater playerRotater;
    public CameraYRotate cameraYRotate;

    void Start()
    {
        settingsPage.SetActive(false);
    }

    public void OnGoBackButton()
    {
        settingsPage.SetActive(false);
        pauseMenu.SetActive(true);
    }

    void CloseSettings()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingsPage.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            playerRotater.menuOpen = false;
            cameraYRotate.menuOpen = false;
            Time.timeScale = 1;
        }
    }

    void Update()
    {
        CloseSettings();
    }
}
