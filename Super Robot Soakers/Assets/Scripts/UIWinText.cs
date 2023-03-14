using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIWinText : MonoBehaviour
{
    public TextMeshProUGUI winText;

    public bool gameIsWon;
    
    // Start is called before the first frame update
    void Start()
    {
        gameIsWon = false;
        winText.enabled = false;
    }

    void displayText()
    {
        if (gameIsWon)
        {
            winText.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        displayText();
    }
}
