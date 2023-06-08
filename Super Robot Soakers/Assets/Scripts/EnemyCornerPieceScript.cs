using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCornerPieceScript : MonoBehaviour
{
    private GameObject enemy;

    void Start()
    {
        enemy = GameObject.Find("Enemy");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemy.GetComponent<EnemyScript>().inTurnZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemy.GetComponent<EnemyScript>().inTurnZone = false;
        }
    }
}
