using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform;

    public float acceleration = 500f;
    public float brakeForce = 300f;
    public float maxTurnAngle = 45f;

    private float currentAcceleration = 0f;
    private float currentBrakeForce = 0f;
    private float currentTurnAngle = 0f;

    void FixedUpdate()
    {
        //basic controls
        Gas();
        Brake();
        Turn();

        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(backRight, backRightTransform);
        UpdateWheel(backLeft, backLeftTransform);
    }

    void Gas()
    {
        //get input
        currentAcceleration = acceleration * Input.GetAxis("Vertical");

        Debug.Log(currentAcceleration);

        //apply power
        backRight.motorTorque = currentAcceleration;
        backLeft.motorTorque = currentAcceleration;

        Debug.Log(backRight.motorTorque);
    }

    void Brake()
    {
        //get input
        if (Input.GetKey(KeyCode.Space))
        {
            currentBrakeForce = brakeForce;
        }
        else
        {
            currentBrakeForce = 0;
        }

        //apply brake
        frontRight.brakeTorque = currentBrakeForce;
        frontLeft.brakeTorque = currentBrakeForce;
        backRight.brakeTorque = currentBrakeForce;
        backLeft.brakeTorque = currentBrakeForce;
    }

    void Turn()
    {
        //get input
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");

        //apply turn
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;
    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;

        Quaternion newRotation = Quaternion.Euler(trans.rotation.eulerAngles.x, trans.rotation.eulerAngles.y, rotation.eulerAngles.z + 90);

        trans.rotation = newRotation;
    }

}
