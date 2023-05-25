using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathwaySpanwer : MonoBehaviour
{
    [Header("Path Stuff")]
    List<char> path = new List<char>();
    public int pathLength;

    [Header("References")]
    public GameObject hallway;
    public GameObject cornerStraight;
    public GameObject cornerTurn;
    

    void Start()
    {
        SetPath();
        LogListValues(path);
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
