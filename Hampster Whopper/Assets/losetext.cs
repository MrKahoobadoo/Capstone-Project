using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class losetext : MonoBehaviour
{
    public hamburgerham Hamburgerham;

    public HamsterScript hamsterScript;
    
    public TextMeshProUGUI myText;

    void Start()
    {
        myText.enabled = false;
    }

    void Update()
    {
        if (Hamburgerham.gameOver == true)
        {
            myText.enabled = true;
        }

        if (hamsterScript.gameLose == true)
        {
            myText.enabled = true;
        }
    }
}
