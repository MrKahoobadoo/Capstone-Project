using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rig;
    public float moveForce;
    public float moveForceInit;
    public float jumpForce;

    private bool isGrounded;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.GetContact(0).normal == Vector3.up)
        {
            isGrounded = true;
        }
    }

    void moveForwardBackward()
    {
        float yInput = Input.GetAxis("Vertical");

        if (isGrounded)
        {
            //rig.AddForce(transform.forward * moveForceInit, ForceMode.Impulse);
            rig.AddForce(transform.forward * yInput * moveForce);
        }
    }

    void moveLeftRight()
    {
        float xInput = Input.GetAxis("Horizontal");

        if (isGrounded)
        {
            //rig.AddForce(transform.right * moveForceInit, ForceMode.Impulse);
            rig.AddForce(transform.right * xInput * moveForce);
        }
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {

        moveForwardBackward();
        moveLeftRight();
        
        Debug.Log(isGrounded);
        
    }

    void Update()
    {
       
        jump();

    }

    


}

