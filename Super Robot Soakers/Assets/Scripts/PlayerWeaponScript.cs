using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponScript : MonoBehaviour
{
    public GameObject waterPrefab;
    public Transform muzzle;
    public int curAmmo;
    public int maxAmmo;
    //public bool infiniteAmmo;

    public float bulletSpeed;
    
    public float flowRate;
    private float lastFlowTime;
    //private bool isPlayer;

    void Awake()
    {
        /*if (GetComponent<Player>())
        {
            isPlayer = true;
        }*/
    }

    public bool CanShoot()
    {
        if(Time.time - lastFlowTime < flowRate)
        {
            if(curAmmo > 0)
            {
                return true;
            }
        }

        return false;
    }

    public void Shoot()
    {
        Debug.Log("Pew Pew");
        lastFlowTime = Time.time;
        curAmmo--;

        GameObject waterSphere = Instantiate(waterPrefab, muzzle.position, muzzle.rotation);

        waterSphere.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
    }
    
}
