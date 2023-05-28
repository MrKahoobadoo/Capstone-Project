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

        // spawns more so that preSpawn segments exist at initialization
        for (int i = 1; i < preSpawn; i++)
        {
            InstantiatePath();
        }
        while (path[increment - 1] == 'S')
        {
            InstantiatePath();
        }
    }

    void Update()
    {
        
    }

    // functions
    void SetPath()
    {
        // starts path with a straight hallway as always
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
    }

    public void InstantiatePath()
    {
        if (path[increment] == 'S')
        {
            // instantiates object and sets it to "newSegment"
            newSegment = (GameObject)Instantiate(straightHallwayPrefab);

            // sets newSegment transform to proper position and rotation offset relative to the previous segment's transform
            newSegment.transform.position = segments[segments.Count - 1].transform.TransformPoint(new Vector3(0, 0, 46));
            newSegment.transform.rotation = Quaternion.Euler(0, segments[segments.Count - 1].transform.rotation.eulerAngles.y, 0);

            // adds segment to the list
            segments.Add(newSegment);
        }
        else if (path[increment] == 'R')
        {
            // instantiates object and sets it to "newSegment"
            newSegment = (GameObject)Instantiate(rightHallwayPrefab);

            // sets newSegment transform to proper position and rotation offset relative to the previous segment's transform
            newSegment.transform.position = segments[segments.Count - 1].transform.TransformPoint(new Vector3(3, 0, 43));
            newSegment.transform.rotation = Quaternion.Euler(0, segments[segments.Count - 1].transform.rotation.eulerAngles.y + 90, 0);

            // adds segment to the list
            segments.Add(newSegment);
        }
        else
        {
            // instantiates object and sets it to "newSegment"
            newSegment = (GameObject)Instantiate(leftHallwayPrefab);

            // sets newSegment transform to proper position and rotation offset relative to the previous segment's transform
            newSegment.transform.position = segments[segments.Count - 1].transform.TransformPoint(new Vector3(-3, 0, 43));
            newSegment.transform.rotation = Quaternion.Euler(0, segments[segments.Count - 1].transform.rotation.eulerAngles.y - 90, 0);

            // adds segment to the list
            segments.Add(newSegment);
        }
        increment++;
    }

    void DeleteOldSegment()
    {
        // checks if the segment path length is greater than preSpawn
        if (segments.Count > preSpawn)
        {
            // deletes the furthest back segment (preSpawn + 1 segments back) so that there are no future collisions
            Destroy(segments[0]);
            segments.RemoveAt(0);
        }
    }

    public void SegmentPassed()
    {
        if (segments.Count <= preSpawn)
        {
            InstantiatePath();
            while (path[increment - 1] == 'S')
            {
                InstantiatePath();
            }
        }

        DeleteOldSegment();
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
