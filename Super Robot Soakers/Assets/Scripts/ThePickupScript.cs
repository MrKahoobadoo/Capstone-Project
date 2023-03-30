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
    public float spawnRadius;
    private bool hasBeenCollected;

    [Header("Auto Movement")]
    public float spinSpeed;
    private float elapsedTime;
    public float bottomValue;
    public float topValue;
    public float lerpDuration;

    [Header("References")]
    public GameObject player;
    public GameObject pickup;
    private GameObject pickupManager;
    private GameObject ground;
    //public NavMesh navMesh;

    public GameObject healthAudioSource;
    public GameObject waterAudioSource;

    private Vector3 spawnPosition;
    private float newY;

    void Start()
    {
        pickupManager = GameObject.Find("Pickup Manager");
        player = GameObject.Find("Player");
        ground = GameObject.Find("Ground");

        newY += transform.position.y;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasBeenCollected)
        {
            hasBeenCollected = true;
            switch (type)
            {
                case PickupType.Water:
                    player.GetComponent<RealPlayerController>().ReloadWater(waterToGive);
                    pickupManager.GetComponent<PickupSpawner>().actualWaterPickupCount--;
                    Instantiate(waterAudioSource, transform.position, Quaternion.identity);

                    break;
                case PickupType.Health:
                    player.GetComponent<RealPlayerController>().GiveHealth(healthToGive);
                    pickupManager.GetComponent<PickupSpawner>().actualHealthPickupCount--;
                    Instantiate(healthAudioSource, transform.position, Quaternion.identity);
                    break;
            }
            Destroy(pickup);
        }
    }

    /*public void Respawn(float radius)
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
    }*/

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

    void RemoverChecker()
    {
        if(pickup.transform.position.x > ground.transform.localScale.x / 2 || pickup.transform.position.x * -1 > ground.transform.localScale.x / 2 || pickup.transform.position.z > ground.transform.localScale.z / 2 || pickup.transform.position.z * -1 > ground.transform.localScale.z / 2)
        {
            switch (type)
            {
                case PickupType.Water:
                    pickupManager.GetComponent<PickupSpawner>().actualWaterPickupCount--;

                    break;
                case PickupType.Health:
                    pickupManager.GetComponent<PickupSpawner>().actualHealthPickupCount--;
                    break;
            }
            Destroy(pickup);
        }
    }

    void Update()
    {
        Spinny();
        Bouncer();
        RemoverChecker();
    }
}
