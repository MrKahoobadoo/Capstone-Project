using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VBectors : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*
        Vector3 newPosition = new Vector3(1,0,-2);
        transform.position = newPosition;
        */

        Vector3 movement = new Vector3(1, 01);
        transform.position += movement;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
    }
}
