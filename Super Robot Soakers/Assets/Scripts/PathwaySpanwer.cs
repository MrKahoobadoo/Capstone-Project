using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathwaySpanwer : MonoBehaviour
{
    [Header("Path Stuff")]
    public List<char> path = new List<char>();
    public List<GameObject> segments = new List<GameObject>();
    public int pathLength;
    private GameObject newSegment;
    private float turnAmount;
    private string turnAmounts;

    public int preSpawn;
    int increment;

    [Header("References")]
    public GameObject straightHallwayPrefab;
    public GameObject rightHallwayPrefab;
    public GameObject leftHallwayPrefab;
    

    void Start()
    {
        SetPath();
        LogListValues(path);
        turnAmount = 0;
        increment = 0;

        // spawns first segment
        newSegment = (GameObject)Instantiate(straightHallwayPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        segments.Add(newSegment);
        increment++;

        InstantiatePath();
        InstantiatePath();
    }

    void Update()
    {
        
    }

    // functions
    void SetPath()
    {
        path.Add('S');
        // creates initial path
        for (int i = 1; i < pathLength; i++)
        {
            float rand = Random.Range(0f, 100f);
            char direction;

            if (rand <= 25f)
            {
                direction = 'L';
            }
            else if (rand <= 50)
            {
                direction = 'R';
            }
            else
            {
                direction = 'S';
            }

            path.Add(direction);
        }

        /*// checks path for possible overlapping situations
        for (int i = 0; i < pathLength; i++)
        {
            if (path[i] == 'R')
            {
                turnAmount++;
                
                if (turnAmount < 2)
                {
                    path[i] = 'S';
                    turnAmount = 0;
                }
            } 
            else if (path[i] == 'L')
            {
                turnAmount--;
                
                if (turnAmount < -2)
                {
                    path[i] = 'S';
                    turnAmount++;
                }
            }

            turnAmounts += turnAmount;
        }

        Debug.Log(turnAmounts);*/
    }

    public void InstantiatePath()
    {
        if (path[increment] == 'S')
        {
            GameObject newSegment = Instantiate(
                straightHallwayPrefab,
                segments[segments.Count - 1].transform.position,
                segments[segments.Count - 1].transform.rotation
            );

            newSegment.transform.position += newSegment.transform.rotation * new Vector3(0, 0, 46);

            segments.Add(newSegment);
        }
        else if (path[increment] == 'R')
        {
            GameObject newSegment = Instantiate(
                rightHallwayPrefab,
                segments[segments.Count - 1].transform.position,
                segments[segments.Count - 1].transform.rotation
            );

            newSegment.transform.position += newSegment.transform.rotation * new Vector3(3, 0, 43);
            newSegment.transform.rotation = Quaternion.Euler(0, newSegment.transform.rotation.eulerAngles.y + 90, 0);
            segments.Add(newSegment);
        }
        else
        {
            GameObject newSegment = Instantiate(
                leftHallwayPrefab,
                segments[segments.Count - 1].transform.position,
                segments[segments.Count - 1].transform.rotation
            );

            newSegment.transform.position += newSegment.transform.rotation * new Vector3(-3, 0, 43);
            newSegment.transform.rotation = Quaternion.Euler(0, newSegment.transform.rotation.eulerAngles.y - 90, 0);
            segments.Add(newSegment);
        }

        if (segments.Count > 5)
        {
            Destroy(segments[0].gameObject);
            segments.RemoveAt(0);
        }

        increment++;
    }

    public void SegmentSpawnPrompter()
    {
        InstantiatePath();
        Debug.Log("preSpawn increased");
    }

    void LogListValues(List<char> list)
    {
        string pathList = "";
        for (int i = 0; i < list.Count; i++)
        {
            pathList += path[i];
        }

        Debug.Log(pathList);
    }
}
