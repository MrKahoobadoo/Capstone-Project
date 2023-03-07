using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public woohoo woohoo;

    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioClip myClip2;

    // Start is called before the first frame update
    void Start()
    {
        audioSource1.volume = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(woohoo.score == 100)
        {
            audioSource1.volume = 0;
            audioSource2.PlayOneShot(myClip2);
        }
    }
}
