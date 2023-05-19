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

    public OSUGameScript osuGameScript;

    [Header("Normal Screen")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiplierText;
    public TextMeshProUGUI accuracyText;
    public TextMeshProUGUI streakText;

    [Header("Lose Screen")]
    public bool loseScreenOpen;
    public TextMeshProUGUI accuracyText3;

    [Header("Win Screen")]
    public bool winScreenOpen;
    public TextMeshProUGUI scoreText2;
    public TextMeshProUGUI accuracyText2;

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
        float score = Mathf.Round(osuGameScript.score);
        scoreText.text = "" + score;

        float multiplier = Mathf.Round(osuGameScript.multiplier * 100) / 100;
        multiplierText.text = "" + multiplier + "x";

        float accuracy = Mathf.Round(osuGameScript.accuracy * 10000) / 100;
        accuracyText.text = "" + accuracy + "%";

        streakText.text = "" + osuGameScript.streak;
    }

    // Manage the lose screen stuff
    void ManageLoseScreen()
    {
        if (osuGameScript.gameLost)
        {
            Debug.Log("SISISI");
            loseScreenOpen = true;
            loseScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            StopTime();

            float accuracy = Mathf.Round(osuGameScript.accuracy * 10000) / 100;
            accuracyText3.text = "" + accuracy + "%";
        }
    }

    void StopTime()
    {
        Time.timeScale = 0f;
    }

    // Manage the win screen stuff

    void ManageWinScreen()
    {
        if (osuGameScript.gameWon)
        {
            winScreenOpen = true;
            winScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            StopTime();

            float score = Mathf.Round(osuGameScript.score);
            scoreText2.text = "Score: " + score;
            float accuracy = Mathf.Round(osuGameScript.accuracy * 10000) / 100;
            accuracyText2.text = "Accuracy: " + accuracy + "%";

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
