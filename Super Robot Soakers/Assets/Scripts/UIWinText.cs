using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIWinText : MonoBehaviour
{
    public GameObject winScreen;
    public PlayerRotater playerRotater;
    public CameraYRotate cameraYRotate;

    public RealPlayerController realPlayerController;
    public StopwatchScript stopwatchScript;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI timeText;


    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        winScreen.SetActive(false);
    }

    void displayScreen()
    {
        if (gameManager.gameIsWon == true)
        {
            winScreen.SetActive(true);
            playerRotater.menuOpen = true;
            cameraYRotate.menuOpen = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            stopwatchScript.isRunning = false;
            Time.timeScale = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        displayScreen();
        timeText.text = "Time: " + stopwatchScript.elapsedTimeString;
        waveText.text = "Survived " + gameManager.wavesSurvived + " Waves";
        scoreText.text = "Eliminated " + realPlayerController.score + " Dharrs";
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
