using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("References")]
    public Rigidbody rig;
    public BoxCollider collider;
    public GameObject hamter;

    [Header("Moving")]
    public float moveSpeed;

    [Header("Shifting")]
    public GameObject currentSegment;

    [Header("Turning")]
    public bool inTurnZone;
    public float alignmentAccuracyNum;

    [Header("Body Bobble")]
    public float bottomHeight;
    public float topHeight;
    public float lerpDuration;
    private float elapsedTime;

    [Header("Silly Wobble")]
    public float leftAngle;
    public float rightAngle;
    public float angleLerpDuration;
    private float angleElapsedTime;

    void Start()
    {
        inTurnZone = false;
    }

    void Update()
    {
        Move();
        Wobbler();
        ClickChecker();
        Aligner();
        Bobbler();
    }

    void Move()
    {
        // constant forward velocity of moveSpeed
        rig.velocity = transform.forward * moveSpeed;
    }

    void Wobbler()
    {
        elapsedTime += Time.deltaTime;
        float t = Mathf.PingPong(elapsedTime / lerpDuration, 1.0f);

        float currentValue = Mathf.Lerp(bottomHeight, topHeight, t);

        hamter.transform.localPosition = new Vector3(0, currentValue, 0);
    }

    void Bobbler()
    {
        angleElapsedTime += Time.deltaTime;
        float t = Mathf.PingPong(angleElapsedTime / angleLerpDuration, 1.0f);

        float currentValue = Mathf.Lerp(leftAngle, rightAngle, t);

        hamter.transform.localRotation = Quaternion.Euler(0, 180, currentValue);
    }

    void CornerLerper()
    {
        if (Mathf.Abs(transform.rotation.eulerAngles.y - currentSegment.transform.rotation.eulerAngles.y) > alignmentAccuracyNum)
        {
            // sets target positions
            Vector3 targetPos = currentSegment.transform.TransformPoint(new Vector3(0, transform.position.y, 0));
            Quaternion targetRot = Quaternion.Euler(transform.rotation.x, currentSegment.transform.rotation.eulerAngles.y, transform.rotation.z);

            // lerps position and rotation
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * 0.15f * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, moveSpeed * Time.deltaTime * 0.5f);
        }
    }

    void ClickChecker()
    {
        if (inTurnZone)
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
            targetPos = new Vector3(currentSegment.transform.position.x, transform.position.y, transform.position.z);
        }
        else if (Mathf.Abs(transform.rotation.eulerAngles.y - 180) < alignmentAccuracyNum)
        {
            targetPos = new Vector3(currentSegment.transform.position.x, transform.position.y, transform.position.z);
        }
        else if (Mathf.Abs(transform.rotation.eulerAngles.y - 90) < alignmentAccuracyNum)
        {
            targetPos = new Vector3(transform.position.x, transform.position.y, currentSegment.transform.position.z);
        }
        else if (Mathf.Abs(transform.rotation.eulerAngles.y - 270) < alignmentAccuracyNum)
        {
            targetPos = new Vector3(transform.position.x, transform.position.y, currentSegment.transform.position.z);
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

        // sets minimum height
        if (transform.position.y < 2.07f)
        {
            transform.position = new Vector3(transform.position.x, 2.07f, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy Segment"))
        {
            currentSegment = other.gameObject;
        }
    }
}
