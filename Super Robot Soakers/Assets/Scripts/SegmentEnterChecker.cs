using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentEnterChecker : MonoBehaviour
{
    public GameObject spawnHub;
    public PathwaySpanwer pathwaySpanwer;

    private bool entered;

    void Start()
    {
        spawnHub = GameObject.Find("Spawn Hub");
        pathwaySpanwer = spawnHub.GetComponent<PathwaySpanwer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !entered)
        {
            entered = true;
            pathwaySpanwer.SegmentPassed();
        }
    }
}
