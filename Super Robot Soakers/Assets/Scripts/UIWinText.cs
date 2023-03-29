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
    public TextMeshProUGUI timeText;

    public bool gameIsWon;
    
    // Start is called before the first frame update
    void Start()
    {
        gameIsWon = false;
        winScreen.SetActive(false);
    }

    void displayScreen()
    {
        if (gameIsWon)
        {
            winScreen.SetActive(true);
            playerRotater.menuOpen = true;
            cameraYRotate.menuOpen = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        displayScreen();
        timeText.text = stopwatchScript.elapsedTimeString;
        scoreText.text = "Score: " + realPlayerController.score;
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
