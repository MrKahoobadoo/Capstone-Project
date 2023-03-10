using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewScriptBecauseTheOtherOneWasGettingTooBigLol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int score = 1;

        if (score == 10)
        {
            Debug.Log("PLAYER WIIIN!!!!!");
        } 
        else
        {
            Debug.Log("Player not cool enough");
        }
        
        int health = 50;

        if (health <= 0)
        {
            Debug.Log("player gone heh");
        } 
        else
        {
            Debug.Log("player chillin");
        }

        // challenge?

        string country = "Venezuela";

        if (country == "France")
        {
            Debug.Log("IS FRANCE!!!!????");
        }
        else
        {
            Debug.Log("Ok good not france we are safe");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
