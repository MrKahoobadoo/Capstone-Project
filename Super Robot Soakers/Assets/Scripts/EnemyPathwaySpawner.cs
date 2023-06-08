using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathwaySpawner : MonoBehaviour
{
    [Header("Path Stuff")]
    List<char> path = new List<char>();
    List<GameObject> segments = new List<GameObject>();
    private GameObject newSegment;
    private float turnAmount;
    private string turnAmounts;

    public int preSpawn;
    int increment;

    [Header("References")]
    public GameObject enemyStraightHallwayPrefab;
    public GameObject enemyRightHallwayPrefab;
    public GameObject enemyLeftHallwayPrefab;

    public PathwaySpanwer pathwaySpanwer;

    public void ILoveCheese()
    {
        // tyler's name idea
        SetPath();
        LogListValues(path);
        turnAmount = 0;
        increment = 0;

        // spawns first segment
        newSegment = (GameObject)Instantiate(enemyStraightHallwayPrefab, new Vector3(0, 0, 0), Quaternion.identity);
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
        path = PathwaySpanwer.path;
    }

    public void InstantiatePath()
    {
        if (path[increment] == 'S')
        {
            // instantiates object and sets it to "newSegment"
            newSegment = (GameObject)Instantiate(enemyStraightHallwayPrefab);

            // sets newSegment transform to proper position and rotation offset relative to the previous segment's transform
            Vector3 newPos = segments[segments.Count - 1].transform.TransformPoint(new Vector3(0, 0, 46));
            newSegment.transform.position = RoundVector3(newPos);
            newSegment.transform.rotation = Quaternion.Euler(0, segments[segments.Count - 1].transform.rotation.eulerAngles.y, 0);

            // adds segment to the list
            segments.Add(newSegment);
        }
        else if (path[increment] == 'R')
        {
            // instantiates object and sets it to "newSegment"
            newSegment = (GameObject)Instantiate(enemyRightHallwayPrefab);

            // sets newSegment transform to proper position and rotation offset relative to the previous segment's transform
            Vector3 newPos = segments[segments.Count - 1].transform.TransformPoint(new Vector3(3, 0, 43));
            newSegment.transform.position = RoundVector3(newPos);
            newSegment.transform.rotation = Quaternion.Euler(0, segments[segments.Count - 1].transform.rotation.eulerAngles.y + 90, 0);

            // adds segment to the list
            segments.Add(newSegment);
        }
        else
        {
            // instantiates object and sets it to "newSegment"
            newSegment = (GameObject)Instantiate(enemyLeftHallwayPrefab);

            // sets newSegment transform to proper position and rotation offset relative to the previous segment's transform
            Vector3 newPos = segments[segments.Count - 1].transform.TransformPoint(new Vector3(-3, 0, 43));
            newSegment.transform.position = RoundVector3(newPos);
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

    Vector3 RoundVector3(Vector3 newPos)
    {
        int x = Mathf.RoundToInt(newPos.x);
        int y = Mathf.RoundToInt(newPos.y);
        int z = Mathf.RoundToInt(newPos.z);
        return new Vector3(x, y, z);
    }
}
