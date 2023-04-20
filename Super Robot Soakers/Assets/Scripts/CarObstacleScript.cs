using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarObstacleScript : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Fuf");
        if (other.CompareTag("Player"))
        {
            other.GetComponentInParent<CarScript>().Crash();
            Debug.Log("Game ENdEDE");
        }
    }
}
