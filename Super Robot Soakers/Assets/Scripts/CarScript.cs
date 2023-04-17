using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    
    
    public GameObject FRWheel;
    public GameObject FLWheel;
    public GameObject BRWheel;
    public GameObject BLWheel;

    public float horsepower;
    public float turnAngle;

    private Quaternion moveSpinAmount;
    private float turnAngleAmount;


    void Move()
    {
        float power = Input.GetAxisRaw("Vertical") * horsepower * Time.deltaTime;
        BRWheel.transform.localRotation = Quaternion.Euler(BRWheel.transform.localRotation.eulerAngles.x + power, BRWheel.transform.localRotation.eulerAngles.y, BRWheel.transform.localRotation.eulerAngles.z);
        BLWheel.transform.localRotation = Quaternion.Euler(BLWheel.transform.localRotation.eulerAngles.x + power, BLWheel.transform.localRotation.eulerAngles.y, BLWheel.transform.localRotation.eulerAngles.z);

        

        Debug.Log(BRWheel.transform.localRotation.eulerAngles);
    }
    
    
    
    
    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
