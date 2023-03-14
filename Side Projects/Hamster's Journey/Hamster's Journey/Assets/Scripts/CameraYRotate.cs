using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraYRotate : MonoBehaviour
{
    public float rotateAmount;
    public PlayerRotater playerRotater;

    void rotate()
    {
        rotateAmount += Input.GetAxis("Mouse Y") * playerRotater.mouseSensitivity;

        if(rotateAmount > 60)
        {
            rotateAmount = 60;
        }
        else
        {
            if(rotateAmount < -60)
            {
                rotateAmount = -60;
            }
        }

        transform.localRotation = Quaternion.Euler(-rotateAmount, 0, 0);
    }

    void Update()
    {
        rotate();
    }
}
