using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponScript : MonoBehaviour
{
    public ObjectPool waterPool;
    public Transform muzzle;
    public int curAmmo;
    public int maxAmmo;
    public bool infiniteAmmo;

    public float bulletSpeed;
    
    public float flowRate;
    private float lastFlowTime;
    //public bool isPlayer;

    //public GameObject player;

    void Awake()
    {
        /*infiniteAmmo = true;

        if (transform.IsChildOf(player.transform))
        {
            isPlayer = true;
            infiniteAmmo = false;
        }*/

    }

    public bool CanShoot()
    {
        if(Time.time - lastFlowTime > flowRate)
        {
            if(curAmmo > 0 || infiniteAmmo)
            {
                Debug.Log("Can Shoot weehee");
                return true;
            }
        }
        Debug.Log("Cannot shoot");
        return false;
    }

    public void Shoot()
    {
        Debug.Log("Pew Pew");
        lastFlowTime = Time.time;
        curAmmo--;

        GameObject waterSphere = waterPool.GetObject();

        waterSphere.transform.position = muzzle.position;
        waterSphere.transform.rotation = muzzle.rotation;

        waterSphere.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
    }
    
}
