using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILoseScreenScript : MonoBehaviour
{
    public bool gameIsOver;

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
        }
    }

    void Update()
    {
        displayScreen();
    }
}
