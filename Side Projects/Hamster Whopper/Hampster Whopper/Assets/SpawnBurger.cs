using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBurger : MonoBehaviour
{
    public int numBurger;

    public GameObject Burgie;

    private Quaternion rotation = Quaternion.Euler(35, 0, 0);

    // Start is called before the first frame update
    void Start()
    {

        if (Burgie != null)
        {
            spawnBurgers();
        }

        

    }

    void spawnBurgers()
    {
        for(int i = 0; i <= numBurger; i++)
        {
            float xCoord = Random.Range(-8.5f, 8.5f);

            float zCoord = Random.Range(-400f, 400f);

            float yCoord = zCoord * -0.7002075382f;


            // Instantiate(Burgie, new Vector3(transform.position.x + xCoord, transform.position.y + yCoord, transform.position.z + zCoord), Quaternion.identity);

            // Instantiate the Burgie object under the parent object
            GameObject newObject = Instantiate(Burgie, new Vector3(transform.position.x + xCoord, transform.position.y + yCoord, transform.position.z + zCoord), rotation);

        }
    }

}
