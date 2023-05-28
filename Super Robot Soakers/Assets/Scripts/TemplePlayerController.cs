using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplePlayerController : MonoBehaviour
{
    [Header("References")]
    public Rigidbody rig;
    public GameObject mainCamera;

    [Header("Moving and Jumping")]
    public float moveSpeed;
    public float jumpForce;

    private bool isGrounded;
    private bool isMoving;

    [Header("Camera Bobble")]
    public float bottomHeight;
    public float topHeight;
    public float lerpDuration;
    private float elapsedTime;

    [Header("Rotation")]
    public float mouseSensitivity;
    public float setMouseSensitivity;
    private float turnAmount;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Wobbler();

        float fps = 1 / Time.deltaTime;
        mouseSensitivity = 60 / (1 / Time.deltaTime) * setMouseSensitivity;

        Rotate();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float z = Input.GetAxisRaw("Vertical") * moveSpeed;

        //Debug.Log(z + ", " + x);
        if (isGrounded)
        {
            if (x != 0 || z != 0)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }

            rig.velocity = transform.forward * z + transform.right * x + new Vector3(0, rig.velocity.y, 0);
        }
        else
        {
            x /= 2;
            z /= 2;

            if (x != 0 || z != 0)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }

            rig.velocity = transform.forward * z + transform.right * x + new Vector3(0, rig.velocity.y, 0);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void Rotate()
    {
        turnAmount += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        transform.localRotation = Quaternion.Euler(0, turnAmount, 0);
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
}

