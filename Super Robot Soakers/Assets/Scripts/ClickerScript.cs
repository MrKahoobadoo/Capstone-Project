using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClickerColor
{
    red,
    green,
    blue,
    yellow
}

public class ClickerScript : MonoBehaviour
{
    public ClickerColor color;
    public bool hitCircle;
    public GameObject other1;

    void Update()
    {
        OnKeyClick();
    }

    void OnKeyClick()
    {
        switch (color)
        {
            case ClickerColor.red:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    Debug.Log("A");
                    if (hitCircle)
                    {
                        float distance = Vector3.Distance(transform.position, other1.transform.position);
                        Debug.Log(distance);
                        Destroy(other1);
                        //OSUGameScript.SuccessfulClick(distance);
                    }
                    else
                    {
                        //OSUGameScript.FailedClick();
                    }
                }
                break;

            case ClickerColor.green:
                if (Input.GetKeyDown(KeyCode.S))
                {
                    Debug.Log("S");
                    if (hitCircle)
                    {
                        float distance = Vector3.Distance(transform.position, other1.transform.position);
                        Debug.Log(distance);
                        Destroy(other1);
                        //OSUGameScript.SuccessfulClick(distance);
                    }
                    else
                    {
                        //OSUGameScript.FailedClick();
                    }
                }
                break;
            
            case ClickerColor.blue:
                if (Input.GetKeyDown(KeyCode.D))
                {
                    Debug.Log("D");
                    if (hitCircle)
                    {
                        float distance = Vector3.Distance(transform.position, other1.transform.position);
                        Debug.Log(distance);
                        Destroy(other1);
                        //OSUGameScript.SuccessfulClick(distance);
                    }
                    else
                    {
                        //OSUGameScript.FailedClick();
                    }
                }
                break;

            case ClickerColor.yellow:
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("F");
                    if (hitCircle)
                    {
                        float distance = Vector3.Distance(transform.position, other1.transform.position);
                        Debug.Log(distance);
                        Destroy(other1);
                        //OSUGameScript.SuccessfulClick(distance);
                    }
                    else
                    {
                        //OSUGameScript.FailedClick();
                    }
                }
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.CompareTag("OSU_Circle"))
        {
            hitCircle = true;
            other1 = other.gameObject;
            Debug.Log("Entered");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("OSU_Circle"))
        {
            hitCircle = false;
            other1 = null;
            Debug.Log("Exited");
        }
    }
}
