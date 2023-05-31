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
    public float gravityConstant;

    private bool isGrounded;

    [Header("Shifting")]
    public GameObject currentSegment;
    public char rail;
    public float railPos;

    [Header("Camera Bobble")]
    public float bottomHeight;
    public float topHeight;
    public float lerpDuration;
    private float elapsedTime;

    private bool bixcuit;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rail = 'M';
        railPos = 0.0f;
    }

    void Update()
    {
        Shift();
        Move();
        Jump();
        Wobbler();
        CornerLerper();
        Aligner();
    }

    void Shift()
    {
        // switches rail
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (rail == 'R')
            {
                rail = 'M';
                railPos = 0.0f;
                transform.Translate(transform.right * -1.5f, Space.World);
            } 
            else if (rail == 'M')
            {
                rail = 'L';
                railPos = -1.5f;
                transform.Translate(transform.right * -1.5f, Space.World);
            } else
            {
                rail = 'L';
                railPos = -1.5f;
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if(rail == 'L')
            {
                rail = 'M';
                railPos = 0.0f;
                transform.Translate(transform.right * 1.5f, Space.World);
            }
            else if (rail == 'M')
            {
                rail = 'R';
                railPos = 1.5f;
                transform.Translate(transform.right * 1.5f, Space.World);
            }
            else
            {
                rail = 'R';
                railPos = 1.5f;
            }
        }
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

        rig.AddForce(Vector3.up * gravityConstant);
    }

    void Wobbler()
    {
        if (isGrounded)
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
        if (other.CompareTag("Straight_Segment") || other.CompareTag("Turned_Segment"))
        {
            currentSegment = other.gameObject;
            // aligns movement and position to the current segment the player is in

            if (other.CompareTag("Turned_Segment"))
            {
                
            } 
            else
            {
                transform.rotation = currentSegment.transform.rotation;
                transform.position = currentSegment.transform.TransformPoint(new Vector3(railPos, transform.position.y, -6));
            }
        }
        Debug.Log("new seg");
    }

    void CornerLerper()
    {
        if (Mathf.Abs(transform.transform.rotation.eulerAngles.y - currentSegment.transform.rotation.eulerAngles.y) > 0.05f)
        {
            // sets target positions
            Vector3 targetPos = currentSegment.transform.TransformPoint(new Vector3(railPos, transform.position.y, 0));
            Quaternion targetRot = currentSegment.transform.rotation;

            // lerps position and rotation
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * 0.1f * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, moveSpeed * Time.deltaTime * 0.5f);
            Debug.Log("lerping");
        }
    }

    void Aligner()
    {
        if (Mathf.Abs(transform.rotation.eulerAngles.y - currentSegment.transform.rotation.eulerAngles.y) < 0.05f)
        {
            transform.rotation = currentSegment.transform.rotation;
        }
    }

}
