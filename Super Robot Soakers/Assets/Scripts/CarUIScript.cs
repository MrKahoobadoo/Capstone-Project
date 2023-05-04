using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CarUIScript : MonoBehaviour
{
    [Header("References")]
    public GameManagerCar gameManagerCar;
    public Rigidbody carRig;
    public CarScript carScript;

    public GameObject loseScreen;
    public GameObject winScreen;
    public AudioSource engineSound;

    [Header("Normal Screen")]
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiplierText;
    public TextMeshProUGUI timeText;

    [Header("Lose Screen")]
    public bool loseScreenOpen;
    public float slowTimeSpeed;

    [Header("Win Screen")]
    public bool winScreenOpen;
    public TextMeshProUGUI scoreText2;
    public TextMeshProUGUI timeText2;
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
        // damage
        damageText.text = "Damage: " + gameManagerCar.damageLevel + "/3";

        // speed
        int speedMPH = (int)Mathf.Floor(carRig.velocity.magnitude * 2.23694f);
        speedText.text = speedMPH + " MPH";

        // score
        float score = Mathf.Floor(gameManagerCar.score);
        scoreText.text = "Score:\n" + score;

        // multiplier
        multiplierText.text = "" + gameManagerCar.multiplier + "x";

        // time dealt with in "StopWatch Script"
    }

    // Manage the lose screen stuff
    void ManageLoseScreen()
    {
        if(gameManagerCar.gameLost)
        {
            loseScreenOpen = true;
            loseScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            carScript.menuOpen = true;
            stopwatchScript.StopStopwatch();
            Invoke("SlowTime", 0.5f);
            Invoke("StopTime", 7.5f);
            Invoke("MuteEngine", 7.5f);
        }
    }

    void StopTime()
    {
        Time.timeScale = 0f;
    }

    void SlowTime()
    {
        Time.timeScale = slowTimeSpeed;
    }

    void MuteEngine()
    {
        if (engineSound.isPlaying)
        {
            engineSound.Stop();
        }
    }

    // Manage the win screen stuff

    void ManageWinScreen()
    {
        if(gameManagerCar.gameWon)
        {
            winScreenOpen = true;
            winScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            carScript.menuOpen = true;
            stopwatchScript.StopStopwatch();
            Invoke("SlowTime", 0.5f);
            Invoke("StopTime", 7.5f);
            Invoke("MuteEngine", 7.5f);
        }
        
        // score
        float score = Mathf.Floor(gameManagerCar.score);
        scoreText2.text = "Score: " + score;

        // time
        timeText2.text = "Time: " + stopwatchScript.elapsedTimeString;

        // greatest streak
        greatestStreakText.text = "Best Streak: " + gameManagerCar.greatestStreak;

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
