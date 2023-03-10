using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hamburgerham : MonoBehaviour
{
    public LoseText loseText;

    public AudioSource audioSource;

    public AudioClip audioClip;

    int oofCount;

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();
        loseText.gameOver = true;
    }


    
}
