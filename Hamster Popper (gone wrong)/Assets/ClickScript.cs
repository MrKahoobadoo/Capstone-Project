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

    void Start ()
    {
        float scale = Random.Range(0.5f, 2.0f);
        
        transform.localScale = new Vector3(scale, scale, scale);
        
        transform.position = new Vector3(Random.Range(-14.5f, 14.5f), Random.Range(0.0f, 9.0f), 2.8f);

        transform.LookAt(target);

        RotateByDegrees(0, 180, 0);
        
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
