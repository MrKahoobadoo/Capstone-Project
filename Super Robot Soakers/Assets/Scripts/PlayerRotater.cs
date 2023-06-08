using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotater : MonoBehaviour
{
    public float mouseSensitivity;
    public float setMouseSensitivity;
    public float turnAmount;

    public bool menuOpen;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void rotate()
    {
        turnAmount += Input.GetAxis("Mouse X") * mouseSensitivity;

        transform.localRotation = Quaternion.Euler(0, turnAmount, 0);
    }

    public void OnSensitivityChanged(float value)
    {
        setMouseSensitivity = value;
    }

    // Update is called once per frame
    void Update()
    {
        float fps = 1 / Time.deltaTime;
        mouseSensitivity = 60 / (1 / Time.deltaTime) * setMouseSensitivity;

        if (!menuOpen)
        {
            rotate();
        }
    }
}
