using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScriptWOw : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int playerHealth = 100;
        Debug.Log(playerHealth);
        playerHealth = 50;
        Debug.Log(playerHealth);

        float moveSpeed = 5.25f;
        Debug.Log(moveSpeed);

        string playerName = "Tennis Bill";
        playerName = "Still Tennis Bill";

        Debug.Log(playerName);

        bool gameOver = false;
        gameOver = true;

        Debug.Log(gameOver);

        // random country thing

        /* 
        string countryName = "YellowBridegSimulartor";
        int population = 12;
        float highestAltitude = 11.3f;
        bool landLocked = true;
        */

        // operators

        int score = 0;
        score += 1;
        score += 5;
        Debug.Log(score);

        int a = 5;
        int b = 2;
        int c = a + b;

        // little "challenge" thing

        float money = 10.00f;
        money += 5;
        money *= 2;
        money -= 3;
        money /= 2;
        Debug.Log(money);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
