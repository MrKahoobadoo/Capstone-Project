using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySegmentEnterChecker : MonoBehaviour
{
    public GameObject enemyPathwaySpawnerz;
    public EnemyPathwaySpawner enemyPathwaySpawner;

    private bool enemyEntered;

    void Start()
    {
        enemyPathwaySpawnerz = GameObject.Find("EnemyPathwaySpawner");
        enemyPathwaySpawner = enemyPathwaySpawnerz.GetComponent<EnemyPathwaySpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && !enemyEntered)
        {
            enemyEntered = true;
            enemyPathwaySpawner.SegmentPassed();
        }
    }
}
