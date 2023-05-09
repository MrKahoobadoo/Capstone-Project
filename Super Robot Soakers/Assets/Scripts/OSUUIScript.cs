using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OSUUIScript : MonoBehaviour
{
    [Header("References")]
    
    public GameObject loseScreen;
    public GameObject winScreen;

    [Header("Normal Screen")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiplierText;

    [Header("Lose Screen")]
    public bool loseScreenOpen;

    [Header("Win Screen")]
    public bool winScreenOpen;
    public TextMeshProUGUI scoreText2;
    public TextMeshProUGUI greatestStreakText;
    public StopwatchScript stopwatchScript;

    void Start()
    {
        loseScreenOpen = false;
        loseScreen.SetActive(false);

        winScreenOpen = false;
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateNormalScreen();
        ManageLoseScreen();
        ManageWinScreen();
    }

    // update the normal screen stuff
    void UpdateNormalScreen()
    {
        
    }

    // Manage the lose screen stuff
    void ManageLoseScreen()
    {
        if (4 == 3 /*need win state*/)
        {
            loseScreenOpen = true;
            loseScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            stopwatchScript.StopStopwatch();
            StopTime();
        }
    }

    void StopTime()
    {
        Time.timeScale = 0f;
    }

    // Manage the win screen stuff

    void ManageWinScreen()
    {
        if (1 == 2 /*need win state*/)
        {
            winScreenOpen = true;
            winScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            stopwatchScript.StopStopwatch();
            StopTime();
        }

    }

    // buttons woo

    public void OnRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Time.timeScale = 1;
    }

    public void OnQuitButton()
    {
        SceneManager.LoadScene(0);
        //Time.timeScale = 1;
    }

}
