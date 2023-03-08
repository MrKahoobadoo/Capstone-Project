using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    public float leftConstraint;
    public float rightConstraint;
    public float forwardForce;
    public float moveIncrement;
    public Rigidbody rig;

    void Start()
    {
        Bowl();
    }

    void Bowl()
    {
        rig.AddForce(transform.forward * forwardForce);
    }
}
