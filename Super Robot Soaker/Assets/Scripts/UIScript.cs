using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public RealPlayerController realPlayerController;


    void Start()
    {

    }

    void updateScore()
    {
        scoreText.text = "Score: " + realPlayerController.score;
    }


    // Update is called once per frame
    void Update()
    {
        updateScore();
    }
}
