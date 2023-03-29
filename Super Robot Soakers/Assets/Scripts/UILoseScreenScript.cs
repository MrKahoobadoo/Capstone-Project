using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILoseScreenScript : MonoBehaviour
{
    public bool gameIsOver;
    public PlayerRotater playerRotater;
    public CameraYRotate cameraYRotate;

    public GameObject endScreen;

    void Start()
    {
        gameIsOver = false;
        endScreen.SetActive(false);
    }

    void displayScreen()
    {
        if (gameIsOver)
        {
            endScreen.SetActive(true);
            playerRotater.menuOpen = true;
            cameraYRotate.menuOpen = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void Update()
    {
        displayScreen();
    }
}
