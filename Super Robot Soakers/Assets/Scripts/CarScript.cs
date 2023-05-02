using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    public float acceleration = 2000f;
    public float brakeForce = 1000f;
    public float maxTurnAngle = 30f;

    private float currentAcceleration = 0f;
    private float currentBrakeForce = 0f;
    private float currentTurnAngle = 0f;

    public float speedForTurn;

    // engine noise stuff
    public float idlePitch;
    public float basePitch;
    public float maxPitch;

    private float currentPitch;
    public float pitchIncrement;
    public float pitchLerper;

    private float gear;
    private bool isFirstGear;

    // crash stuff

    // stabilization stuff
    public float maxTilt;

    // rigidbody modification
    private Vector3 valueCOM;
    public GameObject visualCOM;

    // menu stuff
    public bool menuOpen;

    void Start()
    {
        valueCOM = visualCOM.transform.localPosition;
        rig.centerOfMass = valueCOM;
        menuOpen = false;
    }

    void FixedUpdate()
    {
        //basic controls
        Gas();
        Brake();
        Turn();
        EngineNoise();
        //Stabilize();
        COMChanger();

        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(backRight, backRightTransform);
        UpdateWheel(backLeft, backLeftTransform);
    }

    void Gas()
    {
        //get input
        currentAcceleration = acceleration * Input.GetAxis("Vertical");
        currentAcceleration = (currentAcceleration * 0.75f) + (currentAcceleration * 0.25f) * (1 - (rig.velocity.magnitude - (gear - 1f) * 10f) / 10);

        //apply power
        backRight.motorTorque = currentAcceleration;
        backLeft.motorTorque = currentAcceleration;
        //frontRight.motorTorque = currentAcceleration;
        //frontLeft.motorTorque = currentAcceleration;
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
        float velocity = rig.velocity.magnitude;

        //get input
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal") * (speedForTurn - velocity)/speedForTurn;

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
        // mutes audio when game is paused
        /*if (!menuOpen)
        {
            engineSound.volume = 0.75f;
            Debug.Log("Bens)");
        }
        if (menuOpen)
        {
            engineSound.Stop();
            Debug.Log("Steamer");
        }*/

        /*
        if (menuOpen)
        {
            if (engineSound.isPlaying)
            {
                engineSound.Stop();
            }
        }
        else
        {
            if (!engineSound.isPlaying)
            {
                engineSound.Play();
            }
        }*/

        // gets rigidbody velocity
        float velocity = rig.velocity.magnitude;

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
        float goalPitch;
        goalPitch = currentPitch + (velocity - ((gear - 1f) * 10f)) * (maxPitch - currentPitch) / 10f;
        
        engineSound.pitch = Mathf.Lerp(engineSound.pitch, goalPitch, pitchLerper * Time.deltaTime);
    }

    public void Crash()
    {
        /*System.Random rand = new System.Random();
        
        float xVel = rand.Next(100, 1000);
        float yVel = rand.Next(100, 1000);
        float zVel = rand.Next(100, 1000);

        rig.velocity = new Vector3(xVel, yVel, zVel);*/

        rig.AddForce(Vector3.up * 100000, ForceMode.Impulse);
    }

    void Stabilize()
    {
        float tilt = car.transform.localRotation.eulerAngles.z;
        tilt = Mathf.Clamp(tilt, -maxTilt, maxTilt);

        car.transform.localRotation = Quaternion.Euler(rig.rotation.eulerAngles.x, rig.rotation.eulerAngles.y, tilt);
    }

    void COMChanger()
    {
        valueCOM = visualCOM.transform.localPosition;
        rig.centerOfMass = valueCOM;
    }
}
