using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class WODScript : MonoBehaviour
{
    public GameObject car;
    
    public float chaseSpeed;
    public bool hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Invoke("Chase", 5);
        CheckForHit();
    }

    void Chase()
    {
        transform.position += new Vector3(0, 0, chaseSpeed);
    }

    void CheckForHit()
    {
        if(car.transform.position.z < transform.position.z && !hit)
        {
            hit = true;
        }
    }
}
