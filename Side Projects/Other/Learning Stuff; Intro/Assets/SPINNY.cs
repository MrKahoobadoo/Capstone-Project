using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPINNY : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RotateByDegrees(15, 45, 30);
    }

    void RotateByDegrees(float a, float b, float c)
    {
        Vector3 rotationToAdd = new Vector3(a, b, c);
        transform.Rotate(rotationToAdd);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotationPerSecond = new Vector3(15, 45, 30);

        transform.Rotate(rotationPerSecond * Time.deltaTime);
    }
}
