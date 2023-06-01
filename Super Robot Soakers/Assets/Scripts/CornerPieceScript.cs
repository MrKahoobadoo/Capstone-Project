using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerPieceScript : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player (Rail-Locked)");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<PlayerRailScript>().inTurnZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<PlayerRailScript>().inTurnZone = false;
        }
    }
}
