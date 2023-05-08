using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerCar : MonoBehaviour
{
    [Header("References")]
    public CarScript carScript;
    public GameObject car;
    public WODScript wodScript;
    
    [Header("Obstacle Spawning")]

    public int obstacleCount;
    public int deathCubeCount;
    public int repairObjectCount;

    [Header("Obstacles")]

    public GameObject CarObstacle;
    public GameObject DeathCube;
    public GameObject repairObject;
    private bool isDamageCoolDown;
    public float damageCoolDownLength;

    [Header("Important Numbas")]
    public int obstaclesAvoided;
    public int obstaclesForMultiIncrease;
    public float multiIncreaseConstant;
    public float score;
    public float multiplier;
    public float timeElapsed;
    public int damageLevel;
    public int greatestStreak;

    [Header("Game Status")]
    public bool gameLost;
    public bool gameWon;
    

    void Start()
    {
        SpawnObstacles();
        multiplier = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        gameLost = false;
        gameWon = false;
    }

    void Update()
    {
        CheckForWinOrLose();
    }

    // Public functions
    public void GameEnd()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void GameWin()
    {
        gameWon = true;
    }

    public void GameLose()
    {
        gameLost = true;
        carScript.Crash();
    }

    public void AddScore()
    {
        obstaclesAvoided++;
        multiplier = 1 + multiIncreaseConstant * Mathf.FloorToInt(obstaclesAvoided / obstaclesForMultiIncrease);
        score += multiplier * 10;
        if(obstaclesAvoided > greatestStreak)
        {
            greatestStreak = obstaclesAvoided;
            Debug.Log(greatestStreak);
        }
    }

    public void ResetScore()
    {
        obstaclesAvoided = 0;
        multiplier = 1;
    }

    public void Damage()
    {
        if(damageLevel > 0 && !isDamageCoolDown)
        {
            damageLevel--;
            PauseDamage();
        }
    }

    // damage cooldown
    void PauseDamage()
    {
        isDamageCoolDown = true;
        Invoke("ResumeDamage", damageCoolDownLength);
    }

    void ResumeDamage()
    {
        isDamageCoolDown = false;
    }

    public void Fix()
    {
        if(damageLevel < 3)
        {
            damageLevel++;
        }
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

    void CheckForWinOrLose()
    {
        // checks for losing conditions
        if ((car.transform.position.y < -10 || damageLevel <= 0 || wodScript.hit) && !gameLost && !gameWon)
        {
            GameLose();
        }

        if (car.transform.position.z >= 9960 && !gameLost && !gameWon)
        {
            GameWin();
        }
    }
}
