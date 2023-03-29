using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public GameObject enemy;

    [Header("Enemy Count")]
    public int enemiesToSpawn;
    public int enemyIncreasePerWave;

    [Header("Wave Count")]
    public int currentWave;
    public int wavesSurvived;

    private Vector3 spawnLocation;
    public int enemiesEliminated;

    // Start is called before the first frame update
    void Start()
    {
        currentWave = 1;
        wavesSurvived = 0;
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Spawn(50);
        }
    }

    // Update is called once per frame
    void Update()
    {
        newWave();
        Debug.Log("Enemies Eliminated: " + enemiesEliminated);
        Debug.Log("Current Wave Size: " + enemiesToSpawn);
    }

    public void Spawn(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += Vector3.zero;
        UnityEngine.AI.NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        
        spawnLocation = finalPosition + new Vector3(0, 0.9f, 0);

        Instantiate(enemy, spawnLocation, Quaternion.Euler(0, 0, 0));
    }

    public void newWave()
    {
        if(enemiesEliminated == enemiesToSpawn)
        {
            enemiesEliminated = 0;
            enemiesToSpawn += enemyIncreasePerWave;

            wavesSurvived++;
            currentWave++;

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Spawn(50);
            }
            Debug.Log("NEW WAAAAVE");
        }
    }
}
