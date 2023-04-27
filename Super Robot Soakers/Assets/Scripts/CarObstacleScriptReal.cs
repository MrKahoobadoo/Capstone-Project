using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarObstacleScriptReal : MonoBehaviour
{

    private GameManagerCar gameManagerCar;
    private CarScript carScript;
    private GameObject car;

    private bool isPassed;

    void Start()
    {
        GameObject gameManagerGO = GameObject.Find("GameManager");
        gameManagerCar = gameManagerGO.GetComponent<GameManagerCar>();

        car = GameObject.Find("Car");
        carScript = car.GetComponent<CarScript>();

        isPassed = false;
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

    void CarPass()
    {
        if (!isPassed)
        {
            if(car.transform.position.z > transform.position.z)
            {
                gameManagerCar.AddScore();
                isPassed = true;
            }
        }
    }
}