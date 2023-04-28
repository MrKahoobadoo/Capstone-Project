using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerCar : MonoBehaviour
{
    [Header("References")]
    public CarScript carScript;
    
    [Header("Obstacle Spawning")]

    public int obstacleCount;
    public int deathCubeCount;
    public int repairObjectCount;

    [Header("Obstacles")]

    public GameObject CarObstacle;
    public GameObject DeathCube;
    public GameObject repairObject;

    [Header("Important Numbas")]
    public int obstaclesAvoided;
    public int obstaclesForMultiIncrease;
    public float multiIncreaseConstant;
    public float score;
    public float multiplier;
    public float timeElapsed;
    public int damageLevel;
    

    void Start()
    {
        SpawnObstacles();
        multiplier = 1;
    }

    // Public functions
    public void GameEnd()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void GameWin()
    {

    }

    public void AddScore()
    {
        obstaclesAvoided++;
        multiplier = 1 + multiIncreaseConstant * Mathf.FloorToInt(obstaclesAvoided / obstaclesForMultiIncrease);
        score += multiplier;
    }

    public void ResetScore()
    {
        obstaclesAvoided = 0;
        multiplier = 1;
    }

    public void Damage()
    {
        damageLevel++;
        if(damageLevel >= 3)
        {
            carScript.Crash();
            Invoke("GameEnd", 4);
        }
    }

    public void Fix()
    {
        damageLevel--;
    }

    // Private functions

    void SpawnObstacles()
    {
        System.Random rand = new System.Random();
        
        // spawns normal objects
        // will later include randomization of mesh
        for (int i = 0; i < obstacleCount; i++)
        {
            float xCoor = rand.Next(-14, 14);
            float yCoor = 1.5f;
            float zCoor = rand.Next(20, 10000);
            Vector3 spawnLocation = new Vector3(xCoor, yCoor, zCoor);

            Instantiate(CarObstacle, spawnLocation, Quaternion.identity);
        }

        // spawns repair objects
        for (int i = 0; i < repairObjectCount; i++)
        {
            float xCoor = rand.Next(-14, 14);
            float yCoor = 1f;
            float zCoor = rand.Next(20, 10000);
            Vector3 spawnLocation = new Vector3(xCoor, yCoor, zCoor);

            Instantiate(repairObject, spawnLocation, Quaternion.identity);
        }

        // spawns death cubes
        // death cube
        for (int i = 0; i < deathCubeCount; i++)
        {
            float xCoor = rand.Next(-14, 14);
            float yCoor = 1.5f;
            float zCoor = rand.Next(20, 10000);
            Vector3 spawnLocation = new Vector3(xCoor, yCoor, zCoor);

            Instantiate(CarObstacle, spawnLocation, Quaternion.identity);
        }



    }
}
