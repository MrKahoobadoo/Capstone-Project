using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentEnterChecker : MonoBehaviour
{
    public GameObject spawnHub;
    public PathwaySpanwer pathwaySpanwer;
    
    void Start()
    {
        spawnHub = GameObject.Find("Spawn Hub");
        pathwaySpanwer = spawnHub.GetComponent<PathwaySpanwer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pathwaySpanwer.SegmentSpawnPrompter();
            Debug.Log("oh a person appeared");
        }
    }
}
