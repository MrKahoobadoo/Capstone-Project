using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCircleScript : MonoBehaviour
{
    [Header("Color Type Stuff")]
    public int color;
    public GameObject redCircle;
    public GameObject greenCircle;
    public GameObject blueCircle;
    public GameObject yellowCircle;

    [Header("Movement")]
    public float travelSpeed;

    void Start()
    {
        redCircle.SetActive(false);
        greenCircle.SetActive(false);
        blueCircle.SetActive(false);
        yellowCircle.SetActive(false);

        switch (color)
        {
            case 0:
                redCircle.SetActive(true);
                transform.position += new Vector3(-360, 0, 0);
                break;

            case 1:
                greenCircle.SetActive(true);
                transform.position += new Vector3(-120, 0, 0);
                break;

            case 2:
                blueCircle.SetActive(true);
                transform.position += new Vector3(120, 0, 0);
                break;

            case 3:
                yellowCircle.SetActive(true);
                transform.position += new Vector3(360, 0, 0);
                break;
        }

    }

    void Update()
    {
        SlideDown();
    }

    void SlideDown()
    {
        transform.position += new Vector3(0, -travelSpeed * Time.deltaTime, 0);
    }
}
