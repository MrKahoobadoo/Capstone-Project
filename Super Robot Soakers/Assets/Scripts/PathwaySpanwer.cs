using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathwaySpanwer : MonoBehaviour
{
    [Header("Path Stuff")]
    List<char> path = new List<char>();
    List<GameObject> segments = new List<GameObject>();
    public int pathLength;
    private GameObject newSegment;

    [Header("References")]
    public GameObject straightHallwayPrefab;
    public GameObject rightHallwayPrefab;
    public GameObject leftHallwayPrefab;
    

    void Start()
    {
        SetPath();
        LogListValues(path);
        InstantiatePath();
    }

    void Update()
    {

    }

    // functions
    void SetPath()
    {
        for (int i = 0; i < pathLength; i++)
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
    }

    void InstantiatePath()
    {
        // spawns first segment, always the straight hallway at 0, 0, 0
        newSegment = (GameObject)Instantiate(straightHallwayPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        segments.Add(newSegment);

        // iteratres through list to create other segments
        for (int i = 0; i < pathLength; i++)
        {
            if (path[i] == 'S')
            {
                newSegment = (GameObject)Instantiate(straightHallwayPrefab, segments[segments.Count - 1].transform.position + new Vector3(0, 0, 46), Quaternion.identity, segments[segments.Count - 1].transform);
                segments.Add(newSegment);
            }
            else if (path[i] == 'R')
            {
                newSegment = (GameObject)Instantiate(rightHallwayPrefab, segments[segments.Count - 1].transform.position + new Vector3(3, 0, 43), Quaternion.Euler(0, 90, 0), segments[segments.Count - 1].transform);
                segments.Add(newSegment);
            } 
            else
            {
                newSegment = (GameObject)Instantiate(leftHallwayPrefab, segments[segments.Count - 1].transform.position + new Vector3(-3, 0, 43), Quaternion.Euler(0, -90, 0), segments[segments.Count - 1].transform);
                segments.Add(newSegment);
            }

            if (segments.Count > 3)
            {
                //path.RemoveAt(0);
            }
        }
        
        
        // instantiate first hallway at (0, 0, 0).

        // iterate through the list of characters, spawning the hallway at the appropriate position, adding the appropriate corner piece to join them together
            // use individual functions for "spawn left" "spawn right" and "spawn forward"
            // add temporary local gameobjects so that the transform of the previous segment can be accessedd
            // gamer
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
