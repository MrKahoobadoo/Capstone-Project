using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseText : MonoBehaviour
{
    public hamburgerham Hamburgerham;

    public HamsterScript hamsterScript;
    
    public TextMeshProUGUI myText;

    public bool gameOver = false;

    void Start()
    {
        myText.enabled = false;
    }

    void Update()
    {
        if (gameOver == true)
        {
            myText.enabled = true;
        }

        if (hamsterScript.gameLose == true)
        {
            myText.enabled = true;
        }
    }
}
