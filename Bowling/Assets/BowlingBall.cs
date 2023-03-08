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

    }

    public void Bowl()
    {
        rig.AddForce(transform.forward * forwardForce, ForceMode.Impulse);
    }

    public void MoveLeft()
    {
        if(transform.position.z > leftConstraint)
        {
            transform.position += new Vector3(0, 0, -moveIncrement);
        }
        
    }

    public void MoveRight()
    {
        if (transform.position.z < rightConstraint)
        {
            transform.position += new Vector3(0, 0, moveIncrement);
        }

    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Bowl();
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
    }
}
