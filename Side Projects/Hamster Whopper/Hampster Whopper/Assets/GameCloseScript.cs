using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCloseScript : MonoBehaviour
{
    // Start is called before the first frame update
    void gameQuit()
    {
        if(Input.GetKeyDown(KeyCode.Escape) == true)
        {
            Application.Quit();
            Debug.Log("game Quit");
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameQuit();
    }
}
