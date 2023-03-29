using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIWinText : MonoBehaviour
{
    public GameObject winScreen;
    public PlayerRotater playerRotater;
    public CameraYRotate cameraYRotate;

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
    }
}
