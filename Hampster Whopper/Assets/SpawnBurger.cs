using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBurger : MonoBehaviour
{
    public int numBurger;

    public GameObject Burgie;

    
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


            Instantiate(Burgie, new Vector3(xCoord, yCoord, zCoord), Quaternion.identity);
        }
    }

}
