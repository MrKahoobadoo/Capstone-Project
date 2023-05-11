using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public int color;
public GameObject redCircle;
public GameObject greenCircle;
public GameObject blueCircle;
public GameObject yellowCircle;

public class MovingCircleScript : MonoBehaviour
{
    
    void Start()
    {
        redCircle.SetActive(false);
        greenCircle.SetActive(false);
        blueCircle.SetActive(false);
        yellowCircle.SetActive(false);

        switch (color)
        {
            case 1:
                redCircle.SetActive(false);
                break;

            case 2:
                greenCircle.SetActive(false);
                break;

            case 3:
                blueCircle.SetActive(false);
                break;

            case 4:
                yellowCircle.SetActive(false);
                break;
        }
    }
}
