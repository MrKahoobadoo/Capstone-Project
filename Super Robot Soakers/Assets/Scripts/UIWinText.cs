using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIWinText : MonoBehaviour
{
    public GameObject winScreen;

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
        }
    }

    // Update is called once per frame
    void Update()
    {
        displayScreen();
    }
}
