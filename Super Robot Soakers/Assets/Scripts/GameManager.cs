using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public GameObject enemy;
    public GameObject ground;
    public TheEnemyScript theEnemyScript;
    public PickupSpawner pickupSpawner;
    public GameObject winScreen;
    //public GameObject

    [Header("Enemy Mods")]
    public int enemiesToSpawn;
    public int enemyIncreasePerWave;
    public float moveSpeed;
    public float speedIncrease;

    [Header("Wave Count")]
    public int currentWave;
    public int wavesSurvived;

    private Vector3 spawnLocation;
    public int enemiesEliminated;

    [Header("Other Numbers")]
    public float spawnRadius;
    public float groundDecreaser;
    public bool gameIsWon;
    public int wavesToWin;

    // Start is called before the first frame update
    void Start()
    {
        gameIsWon = false;
        currentWave = 1;
        wavesSurvived = 0;

        moveSpeed += (speedIncrease * wavesSurvived);
        ground.transform.localScale = new Vector3(ground.transform.localScale.x - (groundDecreaser * wavesSurvived), ground.transform.localScale.y, ground.transform.localScale.z - (groundDecreaser * wavesSurvived));
        pickupSpawner.spawnRadius = ground.transform.localScale.x / 2f;
        spawnRadius = ground.transform.localScale.x / 2f;

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Spawn(spawnRadius);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //NewWave();
        WinGame();
        GroundShrinker();
        //Debug.Log("Enemies Eliminated: " + enemiesEliminated);
        //Debug.Log("Current Wave Size: " + enemiesToSpawn);
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

    public void NewWave()
    {
        if(enemiesEliminated == enemiesToSpawn)
        {
            //update waves
            wavesSurvived++;
            currentWave++;

            //modify difficulty
            moveSpeed += (speedIncrease * wavesSurvived);
            /*ground.transform.localScale = new Vector3(ground.transform.localScale.x * groundDecreaser, ground.transform.localScale.y, ground.transform.localScale.z * groundDecreaser);
            pickupSpawner.spawnRadius = ground.transform.localScale.x / 2f;
            spawnRadius = ground.transform.localScale.x / 2f;*/

            //add more enemies and stuff
            enemiesEliminated = 0;
            enemiesToSpawn += enemyIncreasePerWave;

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Spawn(spawnRadius);
            }
            Debug.Log("NEW WAAAAVE");

        }
    }

    public void WinGame()
    {
        if (wavesSurvived == wavesToWin)
        {
            gameIsWon = true;
        }
    }

    void GroundShrinker()
    {
        ground.transform.localScale = Vector3.Lerp(ground.transform.localScale, new Vector3(0, ground.transform.localScale.y, 0), groundDecreaser * Time.deltaTime);
        //ground.transform.localScale = new Vector3(ground.transform.localScale.x * groundDecreaser, ground.transform.localScale.y, ground.transform.localScale.z * groundDecreaser);
        
        pickupSpawner.spawnRadius = ground.transform.localScale.x / 2f;
        spawnRadius = ground.transform.localScale.x / 2f;  
    }
}
