using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GameObject maxwell;
    public AudioSource audioSource;

    private float elapsedTime;
    public float maxwellLerpDuration;
    public float maxwellLeftAngle;
    public float maxwellRightAngle;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<RealPlayerController>().AddScore(1);
            Debug.Log("Collision Detected");
            Destroy(maxwell);
        }
    }

    void wobbler()
    {
        elapsedTime += Time.deltaTime;
        float t = Mathf.PingPong(elapsedTime / maxwellLerpDuration, 1.0f);
        float currentValue = Mathf.Lerp(maxwellLeftAngle, maxwellRightAngle, t);

        maxwell.transform.rotation = Quaternion.Euler(maxwell.transform.rotation.x, maxwell.transform.rotation.y, currentValue);
        
    }

    // Update is called once per frame
    void Update()
    {
        wobbler();
    }
}
