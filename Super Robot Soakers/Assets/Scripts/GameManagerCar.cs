using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerCar : MonoBehaviour
{
    [Header("Obstacle Spawning")]

    public int obstacleCount;
    public int deathCubeCount;

    [Header("Obstacles")]

    public GameObject CarObstacle;
    public GameObject DeathCube;

    void Start()
    {
        SpawnObstacles();
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

    public void idkyetbutsomething()
    {

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
