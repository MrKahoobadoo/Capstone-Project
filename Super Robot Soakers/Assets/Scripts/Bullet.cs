using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float lifetime;
    private float shootTime;

    public bool playerBullet;

    public float bulletGravityConstant;
    public Rigidbody rig;

    public GameObject hitParticle;

    void OnEnable()
    {
        shootTime = Time.time;
    }

    void Update()
    {
        if (Time.time - shootTime >= lifetime)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // did we hit the player?
        if (other.CompareTag("Player"))
        {
            if (!playerBullet)
            {
                other.GetComponent<RealPlayerController>().TakeDamage(damage);
            }
        }
        else if (other.CompareTag("Enemy"))
        {
            if (playerBullet)
            {
                other.GetComponent<TheEnemyScript>().TakeDamage(damage);
            }
        }
        else if (other.CompareTag("Bullet") || other.CompareTag("AimAligner") || other.CompareTag("Pickup"))
        {
            return;
        }

        GameObject obj = Instantiate(hitParticle, transform.position, Quaternion.identity);
        Destroy(obj, 1f);

        gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        Vector3 force = Vector3.down * rig.mass * bulletGravityConstant;
        rig.AddForce(force, ForceMode.Force);
    }
}
