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

    [Header("Turning")]
    public bool inTurnZone;
    public float alignmentAccuracyNum;

    [Header("Camera Bobble")]
    public float bottomHeight;
    public float topHeight;
    public float lerpDuration;
    private float elapsedTime;

    [Header("Jumping")]
    public float originHeight;
    public float jumpHeight;
    public float jumpIncrement;

    public float originAngle;
    public float jumpAngle;
    public float angleIncrement;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rail = 'M';
        railPos = 0.0f;
        inTurnZone = false;
    }

    void Update()
    {
        Shift();
        Move();
        JumpCommand();
        Wobbler();
        ClickChecker();
        Aligner();
    }

    void Shift()
    {
        if (!inTurnZone)
        {
            // switches rail
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (rail == 'R')
                {
                    rail = 'M';
                    railPos = 0.0f;
                }
                else if (rail == 'M')
                {
                    rail = 'L';
                    railPos = -1.5f;
                }
                else
                {
                    rail = 'L';
                    railPos = -3f;
                }
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (rail == 'L')
                {
                    rail = 'M';
                    railPos = 0.0f;
                }
                else if (rail == 'M')
                {
                    rail = 'R';
                    railPos = 1.5f;
                }
                else
                {
                    rail = 'R';
                    railPos = 3f;
                }
            }
        }
    }
    
    void Move()
    {
        // constant forward velocity of moveSpeed
        rig.velocity = transform.forward * moveSpeed;

        /*// Get the forward direction of the object's rotation
        Vector3 forwardDirection = transform.rotation * Vector3.forward;

        // Ignore the X-axis rotation by setting the X component to zero
        forwardDirection.x = 0f;

        // Move the object forward based on the modified direction
        transform.Translate(forwardDirection.normalized * moveSpeed * Time.deltaTime);*/
    }

    /*void Jump()
    {
        if (Input.GetKey(KeyCode.W) && isGrounded == true)
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        //rig.AddForce(Vector3.up * gravityConstant);
    }*/

    void JumpCommand()
    {
        if (Input.GetKey(KeyCode.W) && isGrounded == true)
        {
            StartCoroutine(Jump());
        }
    }
    
    IEnumerator Jump()
    {

        float elapsedTime = 0f;
        float duration = 0.45f; // Adjust this value to control the duration of the jump

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;

            // Calculate the target height and angle using a curve or direct values
            float targetHeight = Mathf.Lerp(originHeight, jumpHeight, t);
            float targetAngle = Mathf.Lerp(originAngle, jumpAngle, t);

            // Update the position and rotation
            transform.position = new Vector3(transform.position.x, targetHeight, transform.position.z);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, targetAngle);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        //yield return new WaitForSeconds(0.1f); // Optional delay for visual effect

        elapsedTime = 0f;
        duration = 0.45f; // Adjust this value to control the duration of the return

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;

            // Calculate the target height and angle using a curve or direct values
            float targetHeight = Mathf.Lerp(jumpHeight, originHeight, t);
            float targetAngle = Mathf.Lerp(jumpAngle, originAngle, t);

            // Update the position and rotation
            transform.position = new Vector3(transform.position.x, targetHeight, transform.position.z);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, targetAngle);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    /*void JumpAction()
    {
        // Lerping position
        float targetY = jumpHeight;
        float targetAngle = jumpAngle;

        while (Mathf.Abs(transform.position.y - targetY) > 0.1f && Mathf.Abs(transform.rotation.eulerAngles.z - targetAngle) > 0.1f)
        {
            float newY = Mathf.Lerp(transform.position.y, targetY, jumpIncrement * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }

        float newAngle = Mathf.Lerp(transform.rotation.eulerAngles.z, targetAngle, angleIncrement * Time.deltaTime);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, newAngle);


    }*/

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

    void CornerLerper()
    {
        if (Mathf.Abs(transform.rotation.eulerAngles.y - currentSegment.transform.rotation.eulerAngles.y) > alignmentAccuracyNum)
        {
            // sets target positions
            Vector3 targetPos = currentSegment.transform.TransformPoint(new Vector3(railPos, transform.position.y, 0));
            Quaternion targetRot = Quaternion.Euler(transform.rotation.x, currentSegment.transform.rotation.eulerAngles.y, transform.rotation.z);

            // lerps position and rotation
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * 0.15f * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, moveSpeed * Time.deltaTime * 0.5f);
        }
    }

    void ClickChecker()
    {
        if (inTurnZone && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)))
        {
            StartCoroutine(PerformCornerLerp());
        }
    }

    IEnumerator PerformCornerLerp()
    {
        float elapsedTime = 0f;
        float duration = 2f; // Adjust this value to control the duration of the lerp

        while (elapsedTime < duration)
        {
            CornerLerper();
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    void Aligner()
    {
        Vector3 targetPos;
        // determines direction, and therefore targetPos
        if (transform.rotation.eulerAngles.y < 0.1f)
        {
            targetPos = new Vector3(currentSegment.transform.position.x + railPos, transform.position.y, transform.position.z);
        }
        else if (Mathf.Abs(transform.rotation.eulerAngles.y - 180) < alignmentAccuracyNum)
        {
            targetPos = new Vector3(currentSegment.transform.position.x - railPos, transform.position.y, transform.position.z);
        }
        else if (Mathf.Abs(transform.rotation.eulerAngles.y - 90) < alignmentAccuracyNum)
        {
            targetPos = new Vector3(transform.position.x, transform.position.y, currentSegment.transform.position.z - railPos);
        }
        else if (Mathf.Abs(transform.rotation.eulerAngles.y - 270) < alignmentAccuracyNum)
        {
            targetPos = new Vector3(transform.position.x, transform.position.y, currentSegment.transform.position.z + railPos);
        }
        else
        {
            targetPos = transform.position;
        }

        // aligns rotation and position
        if (Mathf.Abs(transform.rotation.eulerAngles.y - currentSegment.transform.rotation.eulerAngles.y) < alignmentAccuracyNum)
        {
            Quaternion targetRot = Quaternion.Euler(transform.rotation.x, currentSegment.transform.rotation.eulerAngles.y, transform.rotation.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, moveSpeed * Time.deltaTime * 0.5f);
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * 0.3f * Time.deltaTime);
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
        }
    }


}
