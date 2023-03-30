using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAudioScript : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource.Play();
        
        Destroy(gameObject, 3f);
    }
}
