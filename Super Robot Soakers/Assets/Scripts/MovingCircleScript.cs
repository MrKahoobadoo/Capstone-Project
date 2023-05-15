using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Colore
{
    Red,
    Green,
    Blue,
    Yellow
}

public class MovingCircleScript : MonoBehaviour
{

    [Header("Movement")]
    private float travelSpeed;

    // references
    private GameObject gameCanvas;
    public Colore color;

    void Start()
    {
        // gets speed from OSUGameScript
        gameCanvas = GameObject.Find("Game Canvas");
        travelSpeed = gameCanvas.GetComponent<OSUGameScript>().travelSpeed;

        switch (color)
        {
            case Colore.Red:
                transform.position += new Vector3(-360, 0, 0);
                break;

            case Colore.Green:
                transform.position += new Vector3(-120, 0, 0);
                break;

            case Colore.Blue:
                transform.position += new Vector3(120, 0, 0);
                break;

            case Colore.Yellow:
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
