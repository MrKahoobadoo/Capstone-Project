using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScriptGameOver : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public RealPlayerController realPlayerController;

    public bool gameIsOver;

    void Start()
    {
        gameIsOver = false;
        gameOverText.enabled = false;
    }

    void gameEnd()
    {
        if (gameIsOver)
        {
            gameOverText.enabled = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        gameEnd();
    }
}
