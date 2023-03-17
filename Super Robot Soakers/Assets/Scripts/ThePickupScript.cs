using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum PickupType
{
    Water,
    Health
}

public class ThePickupScript : MonoBehaviour
{
    [Header("Information")]
    public PickupType type;
    public int healthToGive;
    public int waterToGive;
    public float yOffset;

    [Header("Auto Movement")]
    public float spinSpeed;
    private float elapsedTime;
    public float bottomValue;
    public float topValue;
    public float lerpDuration;

    [Header("References")]
    public RealPlayerController realPlayerController;
    //public NavMesh navMesh;

    private Vector3 spawnPosition;
    private float newY;

    void Start()
    {
        Respawn(50);
        newY += transform.position.y;
    }

    void OnTriggerEnter(Collider other)
    {
        // did we hit the player?
        switch (type)
        {
            case PickupType.Water:
                realPlayerController.ReloadWater(waterToGive);
                break;
            case PickupType.Health:
                realPlayerController.GiveHealth(healthToGive);
                break;
        }


        Respawn(50);
    }

    public void Respawn(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += Vector3.zero;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        transform.position = finalPosition + new Vector3(0, yOffset, 0);
    }

    public void Spinny()
    {
        newY += spinSpeed * Time.deltaTime;
        
        transform.rotation = Quaternion.Euler(transform.rotation.x, newY, 0);
    }

    void Bouncer()
    {

        elapsedTime += Time.deltaTime;
        float t = Mathf.PingPong(elapsedTime / lerpDuration, 1.0f);
        float currentValue = Mathf.Lerp(bottomValue, topValue, t);

        transform.position = new Vector3 (transform.position.x, currentValue, transform.position.z);

    }

    void Update()
    {
        Spinny();
        Bouncer();
    }
}
