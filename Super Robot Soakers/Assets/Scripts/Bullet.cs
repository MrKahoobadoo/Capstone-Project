using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float lifetime;
    private float shootTime;
    
    public float bulletGravityConstant;
    public Rigidbody rig;

    void OnEnable()
    {
        shootTime = Time.time;
    }

    void Update()
    {
        if(Time.time - shootTime >= lifetime)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter (Collider other)
    {
        // did we hit the player?
        if (other.CompareTag("Player"))
        {
            other.GetComponent<RealPlayerController>().TakeDamage(damage);
        }
        else if (other.CompareTag("Enemy"))
        {
            other.GetComponent<TheEnemyScript>().TakeDamage(damage);
        }
        else if (other.CompareTag("Bullet"))
        {
            return;
        }
        gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        Vector3 force = Vector3.down * rig.mass * bulletGravityConstant;
        rig.AddForce(force, ForceMode.Force);
    }
}
