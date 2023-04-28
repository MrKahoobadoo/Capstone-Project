using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairObjectScript : MonoBehaviour
{
    public float spinSpeed;
    public float elapsedTime;
    public float lerpDuration;
    public float bottomValue;
    public float topValue;
    private float newY;

    private GameManagerCar gameManagerCar;
    private CarScript carScript;
    private GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManagerGO = GameObject.Find("GameManager");
        gameManagerCar = gameManagerGO.GetComponent<GameManagerCar>();

        car = GameObject.Find("Car");
        carScript = car.GetComponent<CarScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Spinny();
        Bouncer();
    }

    void Spinny()
    {
        newY += spinSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(transform.rotation.x, newY, 0);
    }

    void Bouncer()
    {
        elapsedTime += Time.deltaTime;
        float t = Mathf.PingPong(elapsedTime / lerpDuration, 1.0f);
        float currentValue = Mathf.Lerp(bottomValue, topValue, t);

        transform.position = new Vector3(transform.position.x, currentValue, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManagerCar.Fix();
        }

        Destroy(gameObject);
    }


}
