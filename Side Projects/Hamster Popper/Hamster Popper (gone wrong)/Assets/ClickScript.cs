using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{

    public int scoreToGive = 1;

    public float scaleIncreasePerClick = 0.2f;

    public int clicksToPop;

    public Transform target;

    public woohoo woohoo;

    public AudioClip myClip;
    public AudioSource audioSource;

    void Start ()
    {
        float scale = Random.Range(0.4f, 1.4f);
        
        transform.localScale = new Vector3(scale, scale, scale);
        
        transform.position = new Vector3(Random.Range(-12f, 12f), Random.Range(1.0f, 8.0f), -18.0f);

        transform.LookAt(target);

        RotateByDegrees(0, 180, 0);

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = myClip;

    }

    void RotateByDegrees(float a, float b, float c)
    {
        Vector3 rotationToAdd = new Vector3(a, b, c);
        transform.Rotate(rotationToAdd);
    }

    void OnMouseDown ()
    {
        clicksToPop -= 1;
        transform.localScale += new Vector3(scaleIncreasePerClick, scaleIncreasePerClick, scaleIncreasePerClick);

        audioSource.PlayOneShot(myClip);
        
        if (clicksToPop == 0)
        {
            Destroy(gameObject);
            woohoo.increaseScore(scoreToGive);
        }

    }

    void Update()
    {
       
    }
    
}
