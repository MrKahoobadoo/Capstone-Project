using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScriptGameOver : MonoBehaviour
{
    public GameObject endScreen;
    public RealPlayerController realPlayerController;

    public bool gameIsOver;

    void Start()
    {
        gameIsOver = false;
        endScreen.SetActive(false);
    }

    public void GameEnd()
    {
        if (gameIsOver)
        {
            endScreen.SetActive(true);
            Debug.Log("game Over Diapled");
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameEnd();
        Debug.Log(gameIsOver);
    }
}
