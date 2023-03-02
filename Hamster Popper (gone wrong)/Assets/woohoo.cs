using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woohoo : MonoBehaviour
{

    void Start()
    {
       
    }

    public void Quit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Quit();
    }
    
}
