using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCubeScript : MonoBehaviour
{

    private GameManagerCar gameManagerCar;

    void Start()
    {
        GameObject gameManagerGO = GameObject.Find("GameManager");
        gameManagerCar = gameManagerGO.GetComponent<GameManagerCar>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInParent<CarScript>().Crash();
            Invoke("EndGame", 3f);
        }
    }

    void EndGame()
    {
        gameManagerCar.GameEnd();
    }
}
