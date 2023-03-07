using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript2 : MonoBehaviour
{

    public int scoreToGive = 1;

    public float scaleIncreasePerClick = 0.3f;

    public int clicksToPop;

    public Transform target;

    public woohoo woohoo;

    private float rotateX;
    private float rotateY;
    private float rotateZ;

    public AudioClip myClip;
    public AudioSource audioSource;

    void Start()
    {
        float scale = Random.Range(0.3f, 0.6f);

        transform.localScale = new Vector3(scale, scale, scale);

        transform.position = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(1.0f, 8.0f), -18.0f);

        transform.LookAt(target);
        
        rotateX = Random.Range(-0.1f, 0.1f);
        rotateY = Random.Range(-0.1f, 0.1f);
        rotateZ = Random.Range(-0.1f, 0.1f);

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = myClip;
    }

    void RotateByDegrees(float a, float b, float c)
    {
        Vector3 rotationToAdd = new Vector3(a, b, c);
        transform.Rotate(rotationToAdd);
    }

    void OnMouseDown()
    {
        clicksToPop -= 1;
        transform.localScale += new Vector3(0, 0, scaleIncreasePerClick);

        audioSource.PlayOneShot(myClip);

        if (clicksToPop == 0)
        {
            Destroy(gameObject);
            woohoo.increaseScore(scoreToGive);

        }

    }

    void Update()
    {
        RotateByDegrees(rotateX, rotateY, rotateZ);
    }

}
