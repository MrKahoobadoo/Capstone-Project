using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraYRotaterTemple : MonoBehaviour
{
    private float yRotateAmount;
    public float yRotateSensitivity;

    void Rotate()
    {
        yRotateAmount += Input.GetAxis("Mouse Y") * yRotateSensitivity * Time.deltaTime;

        if (yRotateAmount > 80)
        {
            yRotateAmount = 80;
        }
        else
        {
            if (yRotateAmount < -80)
            {
                yRotateAmount = -80;
            }
        }

        transform.localRotation = Quaternion.Euler(-yRotateAmount, 0, 0);
    }

    void Update()
    {
        Rotate();
    }
}
