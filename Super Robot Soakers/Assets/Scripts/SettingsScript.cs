using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    public GameObject settingsPage;
    public GameObject pauseMenu;

    public bool settingsActive;

    void Start()
    {
        settingsPage.SetActive(false);
        settingsActive = false;
    }

    public void OnGoBackButton()
    {
        settingsActive = false;
        settingsPage.SetActive(false);
        pauseMenu.SetActive(true);
    }

    /*void CloseSettings()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && settingsActive)
        {
            settingsPage.SetActive(false);
            pauseMenu.SetActive(true);
            settingsActive = false;
        }
    }*/

    void Update()
    {
        //CloseSettings();
    }
}
