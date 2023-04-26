using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarObstacleScriptReal : MonoBehaviour
{

    private GameManagerCar gameManagerCar;

    void Start()
    {
        GameObject gameManagerGO = GameObject.Find("GameManager");
        gameManagerCar = gameManagerGO.GetComponent<GameManagerCar>();
    }

    void Update()
    {
        CarPass();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManagerCar.ResetScore();
            gameManagerCar.Damage();
        }
    }

    private void CarPass()
    {
        gameManagerCar.AddScore();
    }
}