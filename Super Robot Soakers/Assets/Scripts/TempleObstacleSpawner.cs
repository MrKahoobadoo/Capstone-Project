using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleObstacleSpawner : MonoBehaviour
{
    public List<float> spawnLocations;
    public GameObject hallway;

    // objects to spawn
    private GameObject ob1;
    private GameObject ob2;

    // prefabs
    public GameObject lDesk;
    public GameObject desk;
    public GameObject chair;
    public GameObject closet;

    // interates through each spawn location in the specified list, calling a random instantiation function with the specified spawn location
    void Start()
    {
        for (int i = 0; i < spawnLocations.Count; i++)
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


    // spawns the L Desk prefab with a random rotation value at an inputted spawn location
    void Spawn_LDesk(float spawnLoc)
    {
        int choice = Random.Range(0, 4);
        float rotationVal = 90 * choice;

        GameObject obstacle = Instantiate(lDesk, Vector3.zero, Quaternion.identity, hallway.transform);
        obstacle.transform.localPosition = new Vector3(0, 0, spawnLoc);
        obstacle.transform.localRotation = Quaternion.Euler(0, rotationVal, 0);
    }

    // spawns the desk prefab with a random x-offset and rotation at an inputted spawn location
    void Spawn_Desk(float spawnLoc)
    {
        int choice = Random.Range(0, 2);
        float rotationVal = 90 * choice;
        float xPos;
        
        if(rotationVal == 0)
        {
            // if the desk is perpendicular, then it only spawns at 2 location choices
            choice = Random.Range(0, 2);
            if (choice == 0)
            {
                xPos = -2.7f;
            } 
            else
            {
                xPos = -1.1f;
            }
        } 
        else
        {
            // if the desk is parallel, then it has 3 choices
            choice = Random.Range(0, 3);
            xPos = -1.9f + 1.9f * choice;
        }

        GameObject obstacle = Instantiate(desk, Vector3.zero, Quaternion.identity, hallway.transform);
        obstacle.transform.localPosition = new Vector3(xPos, 0, spawnLoc);
        obstacle.transform.localRotation = Quaternion.Euler(0, rotationVal, 0);
    }

    // spawns chair prefab with a random x-offset and rotation at the inputted spawn location
    void Spawn_Chair(float spawnLoc)
    {
        int choice = Random.Range(0, 3);
        float xPos = -1.9f + 1.9f * choice;

        choice = Random.Range(0, 4);
        float rotationVal = 90 * choice;

        GameObject obstacle = Instantiate(chair, Vector3.zero, Quaternion.identity, hallway.transform);
        obstacle.transform.localPosition = new Vector3(xPos, 0, spawnLoc);
        obstacle.transform.localRotation = Quaternion.Euler(0, rotationVal, 0);
    }

    // spawns angled closet pregab with a random rotation at the inputted spawn location
    void Spawn_Closet(float spawnLoc)
    {
        int choice = Random.Range(0, 2);
        float rotationVal = 180 * choice;

        GameObject obstacle = Instantiate(closet, Vector3.zero, Quaternion.identity, hallway.transform);
        obstacle.transform.localPosition = new Vector3(0, 0, spawnLoc);
        obstacle.transform.localRotation = Quaternion.Euler(0, rotationVal, 0);
    }
}
