using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRailScript : MonoBehaviour
{
    [Header("References")]
    public Rigidbody rig;
    public GameObject mainCamera;

    [Header("Moving and Jumping")]
    public float moveSpeed;
    public float jumpForce;

    private bool isGrounded;
    private bool isMoving;

    [Header("Shifting")]
    public GameObject currentSegment;
    public char rail;
    public float railPos;

    [Header("Camera Bobble")]
    public float bottomHeight;
    public float topHeight;
    public float lerpDuration;
    private float elapsedTime;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rail = 'M';
    }

    void Update()
    {
        Shift();
        Move();
        Jump();
        Wobbler();
    }

    void Shift()
    {
        // switches rail
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (rail == 'R')
            {
                rail = 'M';
            } 
            else
            {
                rail = 'L';
            } 
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if(rail == 'L')
            {
                rail = 'M';
            }
            else
            {
                rail = 'R';
            }
        }

        // checks which rail the player is on
        if (rail == 'M')
        {
            railPos = 0.0f;
        }
        else if (rail == 'R')
        {
            railPos = 1.75f;
        }
        else
        {
            railPos = -1.75f;
        }

        // aligns movement and position to the current segment the player is in
        //transform.rotation = currentSegment.transform.rotation;
        transform.position = currentSegment.transform.TransformPoint(new Vector3(railPos, transform.position.y, transform.position.z));
    }
    
    void Move()
    {
        // constant forward velocity of moveSpeed
        rig.velocity = transform.forward * moveSpeed;
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.W) && isGrounded == true)
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void Wobbler()
    {
        if (isMoving && isGrounded)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.PingPong(elapsedTime / lerpDuration, 1.0f);

            float currentValue = Mathf.Lerp(bottomHeight, topHeight, t);

            mainCamera.transform.localPosition = new Vector3(0, currentValue, 0);
        }
        else
        {
            mainCamera.transform.localPosition = new Vector3(0, Mathf.Lerp(mainCamera.transform.localPosition.z, 1, 1f), 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.GetContact(0).normal == Vector3.up)
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Segment"))
        {
            currentSegment = other.gameObject;
            // aligns movement and position to the current segment the player is in
            transform.rotation = currentSegment.transform.rotation;
            transform.position = currentSegment.transform.TransformPoint(new Vector3(railPos, transform.position.y, 0));
        }
        Debug.Log("new seg");
    }

}
