using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hamburgerham : MonoBehaviour
{
    public bool gameOver = false;

    private void OnCollisionEnter (Collision collision)
    {
        gameOver = true;
    }


    
}
