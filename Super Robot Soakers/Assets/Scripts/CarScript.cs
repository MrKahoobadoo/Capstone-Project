using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    // references
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform;

    [SerializeField] Rigidbody rig;
    [SerializeField] GameObject car;
    [SerializeField] AudioSource engineSound;

    // movement stuff
    public float acceleration = 500f;
    public float brakeForce = 300f;
    public float maxTurnAngle = 45f;

    private float currentAcceleration = 0f;
    private float currentBrakeForce = 0f;
    private float currentTurnAngle = 0f;

    // engine noise stuff
    public float idlePitch;
    public float basePitch;
    public float maxPitch;

    private float currentPitch;
    public float pitchIncrement;

    private float gear;
    private bool isFirstGear;

    void FixedUpdate()
    {
        //basic controls
        Gas();
        Brake();
        Turn();
        EngineNoise();

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
        //frontRight.motorTorque = currentAcceleration;
        //frontLeft.motorTorque = currentAcceleration;

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
        // aligns wheel mesh with wheel collider
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;

        Quaternion newRotation = Quaternion.Euler(trans.rotation.eulerAngles.x, trans.rotation.eulerAngles.y, rotation.eulerAngles.z + 90);

        trans.rotation = newRotation;
    }

    void EngineNoise()
    {
        // gets rigidbody velocity
        float velocity = rig.velocity.magnitude;
        Debug.Log(velocity);

        // determines the car's current "gear"
        switch (velocity)
        {
            case < 10:
                gear = 1;
                isFirstGear = true;
                break;

            case < 20:
                gear = 2;
                isFirstGear = false;
                break;

            case < 30:
                gear = 3;
                isFirstGear = false;
                break;

            case < 40:
                gear = 4;
                isFirstGear = false;
                break;

            case < 50:
                gear = 5;
                isFirstGear = false;
                break;
            
            case < 60:
                gear = 6;
                isFirstGear = false;
                break;

            case < 70:
                gear = 7;
                isFirstGear = false;
                break;

            case < 80:
                gear = 8;
                isFirstGear = false;
                break;
        }

        // checks if car is in first gear. If so, the current pitch is set to be extra low. If not, it sits at a higher pitch
        if (!isFirstGear)
        {
            currentPitch = basePitch + (gear - 1f) * pitchIncrement;
        }
        else
        {
            currentPitch = idlePitch + (gear - 1f) * pitchIncrement;
        }

        // sets pitch based off of velocity and current gear and yaddah yaddah mathy stuff
        engineSound.pitch = currentPitch + (velocity - ((gear - 1f) * 10f)) * (maxPitch - currentPitch) / 10f;

    }

}
