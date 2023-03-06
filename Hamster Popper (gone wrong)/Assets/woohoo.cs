using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class woohoo : MonoBehaviour
{

    public int score;
    public TextMeshProUGUI scoreText;

    void Start ()
    {
        updateScoreText();
    }

    public void increaseScore (int amount)
    {
        score += amount;
        updateScoreText();
    }

    public void Quit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
    }

    void updateScoreText ()
    {
        scoreText.text = "Hampsters Popped: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        Quit();
    }
    
}
