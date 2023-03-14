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

        if(rotateAmount > 80)
        {
            rotateAmount = 80;
        }
        else
        {
            if(rotateAmount < -80)
            {
                rotateAmount = -80;
            }
        }

        transform.localRotation = Quaternion.Euler(-rotateAmount, 0, 0);
    }

    void Update()
    {
        rotate();
    }
}
