using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PickupSpawner : MonoBehaviour
{
    public float spawnRadius;
    private Vector3 spawnPosition;
    public float yOffset;
    
    public int healthPickupCount;
    public int actualHealthPickupCount;
    public int waterPickupCount;
    public int actualWaterPickupCount;

    public GameObject pickupHealth;
    public GameObject pickupWater;
    public bool isHealth;

    // Start is called before the first frame update
    void Start()
    {
        actualHealthPickupCount = healthPickupCount;
        actualWaterPickupCount = waterPickupCount;

        isHealth = false;
        for(int i = 0; i < waterPickupCount; i++)
        {
            Respawn(spawnRadius);
        }

        isHealth = true;
        for (int i = 0; i < healthPickupCount; i++)
        {
            Respawn(spawnRadius);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Maintainer();
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

        spawnPosition = finalPosition + new Vector3(0, yOffset, 0);

        if (!isHealth)
        {
            StartCoroutine(SpawnPickup(pickupWater, spawnPosition));
        }
        else
        {
            StartCoroutine(SpawnPickup(pickupHealth, spawnPosition));
        }
        Debug.Log("Respawn called");
    }

    IEnumerator SpawnPickup(GameObject pickup, Vector3 position)
    {
        yield return new WaitForEndOfFrame();

        Instantiate(pickup, position, Quaternion.Euler(0, 0, 0));
    }

        void Maintainer()
    {
        if (actualHealthPickupCount < healthPickupCount)
        {
            isHealth = true;
            Respawn(spawnRadius);
            actualHealthPickupCount+=1;
        }

        if (actualWaterPickupCount < waterPickupCount)
        {
            isHealth = false;
            Respawn(spawnRadius);
            actualWaterPickupCount+=1;
        }
    }
}
