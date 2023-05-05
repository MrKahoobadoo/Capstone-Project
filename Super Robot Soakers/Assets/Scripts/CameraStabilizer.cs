using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStabilizer : MonoBehaviour
{

    public GameObject carBody;
    public GameObject lookBackHub;

    private Quaternion targetRotation;
    public float lerpIncrement;

    private Quaternion originalRotation;
    private Quaternion backRotation;

    void Start()
    {
        originalRotation = Quaternion.Euler(0, 0, 0);
        backRotation = Quaternion.Euler(0, 180, 0);
    }

    void Update()
    {
        Follow();
        transform.position = carBody.transform.position;
        LookBack();
    }

    void Follow()
    {
        // position accordingly
        transform.position = carBody.transform.position;

        // rotate accordingly
        targetRotation = Quaternion.Euler(0, carBody.transform.rotation.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, lerpIncrement * Time.deltaTime);
    }

    void LookBack()
    {
        originalRotation = transform.rotation;
        backRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z);
        if (Input.GetKey(KeyCode.R))
        {
            lookBackHub.transform.rotation = Quaternion.Lerp(lookBackHub.transform.rotation, backRotation, Time.deltaTime * 10);
        }
        else
        {
            lookBackHub.transform.rotation = Quaternion.Lerp(lookBackHub.transform.rotation, originalRotation, Time.deltaTime * 10);
        }
    }
}
