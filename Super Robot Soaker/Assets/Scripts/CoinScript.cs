using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<RealPlayerController>().AddScore(1);
            Debug.Log("Game ENdEDE");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
