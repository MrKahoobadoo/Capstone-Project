using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlinker : MonoBehaviour
{
    public GameObject pointLight;
    public float flickChance;
    public float returnChance;

    private bool turnedOn;

    void Start()
    {
        turnedOn = true;
    }

    void FixedUpdate()
    {
        Flicker();
    }

    void Flicker()
    {
        if (turnedOn)
        {
            float flick = Random.Range(0f, 100f);

            if (flick <= flickChance)
            {
                pointLight.SetActive(false);
                turnedOn = false;
            }
        } 
        else
        {
            float returner = Random.Range(0f, 100f);

            if (returner <= returnChance)
            {
                pointLight.SetActive(true);
                turnedOn = true;
            }
        }
    }
}
