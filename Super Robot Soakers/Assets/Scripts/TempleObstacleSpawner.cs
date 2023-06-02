using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleObstacleSpawner : MonoBehaviour
{
    [Header("Spawn Positions")]
    public List<float> spawnLocations;

    // objects to spawn
    private GameObject ob1;
    private GameObject ob2;

    // prefabs
    public GameObject lDesk;
    public GameObject desk;
    public GameObject chair;
    public GameObject closet;

    void Start()
    {
        foreach (int i in spawnLocations)
        {
            int choice = Random.Range(0, 4);
            switch (choice)
            {
                case 0:
                    Spawn_LDesk(spawnLocations[i]);
                    break;
                case 1:
                    Spawn_Desk(spawnLocations[i]);
                    break;
                case 2:
                    Spawn_Chair(spawnLocations[i]);
                    break;
                case 3:
                    Spawn_Closet(spawnLocations[i]);
                    break;
            }
        }
    }

    void Spawn_LDesk(float spawnLoc)
    {

    }

    void Spawn_Desk(float spawnLoc)
    {

    }

    void Spawn_Chair(float spawnLoc)
    {

    }

    void Spawn_Closet(float spawnLoc)
    {

    }
}
