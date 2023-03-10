using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class wintext : MonoBehaviour
{
    public HamsterScript hamsterScript;

    public TextMeshProUGUI myText;

    void Start()
    {
        myText.enabled = false;
    }

    void Update()
    {
        if (hamsterScript.gameWon == true)
        {
            myText.enabled = true;
        }
    }
}
