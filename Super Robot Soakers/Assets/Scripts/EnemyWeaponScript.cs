using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponScript : MonoBehaviour
{
    public ObjectPool waterPool;
    public Transform muzzle;
    public int curAmmo;
    public int maxAmmo;
    public bool infiniteAmmo;

    public float bulletSpeed;

    public float flowRate;
    private float lastFlowTime;
    public RealPlayerController realPlayerController;
    private Quaternion newRotation;

    public float rotationSpeed;


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
        if (Time.time - lastFlowTime > flowRate)
        {
            if (curAmmo > 0 || infiniteAmmo)
            {
                return true;
            }
        }
        return false;
    }

    public void Shoot()
    {
        lastFlowTime = Time.time;
        curAmmo--;

        GameObject waterSphere = waterPool.GetObject();

        waterSphere.transform.position = muzzle.position;
        waterSphere.transform.rotation = muzzle.rotation;

        waterSphere.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
    }

    void Update()
    {

    }

}
