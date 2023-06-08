using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentEnterChecker : MonoBehaviour
{
    public GameObject spawnHub;
    public PathwaySpanwer pathwaySpanwer;

    private bool playerEntered;

    void Start()
    {
        spawnHub = GameObject.Find("Spawn Hub");
        pathwaySpanwer = spawnHub.GetComponent<PathwaySpanwer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !playerEntered)
        {
            playerEntered = true;
            pathwaySpanwer.SegmentPassed();
        }
    }
}
