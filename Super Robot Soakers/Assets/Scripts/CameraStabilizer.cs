using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStabilizer : MonoBehaviour
{
    
    public GameObject carBody;

    private Quaternion targetRotation;
    public float lerpIncrement;
    
    // Update is called once per frame
    void Update()
    {
        Follow();
        transform.position = carBody.transform.position;
    }

    void Follow()
    {
        // position accordingly
        transform.position = carBody.transform.position;

        // rotate accordingly
        targetRotation = Quaternion.Euler(0, carBody.transform.rotation.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, lerpIncrement * Time.deltaTime);
    }
}
