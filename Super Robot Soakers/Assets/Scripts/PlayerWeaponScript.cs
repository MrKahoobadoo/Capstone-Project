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
    public RealPlayerController realPlayerController;
    
    private Quaternion newRotation;
    private Vector3 modPointOfFocus;

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
        if(Time.time - lastFlowTime > flowRate)
        {
            if(curAmmo > 0 || infiniteAmmo)
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

    public void AutoAim()
    {
        if(realPlayerController.focusPresent == true)
        {
            modPointOfFocus = realPlayerController.pointOfFocus - transform.position;
            
            newRotation = Quaternion.LookRotation(modPointOfFocus);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);

            //transform.LookAt(realPlayerController.pointOfFocus);
            
        }
        else
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0f, 0f, 0f), rotationSpeed * Time.deltaTime);

            //transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            
        }
    }

    void Update()
    {
        AutoAim();
    }
    
}
