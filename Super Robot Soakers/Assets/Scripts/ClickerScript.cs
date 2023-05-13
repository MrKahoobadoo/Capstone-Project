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
    public List<Collider2D> TriggerList = new List<Collider2D>();

    void Update()
    {
        OnKeyClick();
        Debug.Log(TriggerList.Count);
    }

    void OnKeyClick()
    {
        switch (color)
        {
            case ClickerColor.red:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    Debug.Log("A");
                    if (TriggerList.Count > 0)
                    {
                        float distance = Vector3.Distance(transform.position, TriggerList[0].transform.position);
                        Debug.Log(distance);
                        Destroy(TriggerList[0].gameObject);
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
                    if (TriggerList.Count > 0)
                    {
                        float distance = Vector3.Distance(transform.position, TriggerList[0].transform.position);
                        Debug.Log(distance);
                        Destroy(TriggerList[0].gameObject);
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
                    if (TriggerList.Count > 0)
                    {
                        float distance = Vector3.Distance(transform.position, TriggerList[0].transform.position);
                        Debug.Log(distance);
                        Destroy(TriggerList[0].gameObject);
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
                    if (TriggerList.Count > 0)
                    {
                        float distance = Vector3.Distance(transform.position, TriggerList[0].transform.position);
                        Debug.Log(distance);
                        Destroy(TriggerList[0].gameObject);
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
            if (!TriggerList.Contains(other))
            {
                // add the object to the list if not already there
                TriggerList.Add(other);
            }
        }

        Debug.Log("Entered");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("OSU_Circle"))
        {
            if (TriggerList.Contains(other))
            {
                // remove it from the list if its in the list
                TriggerList.Remove(other);
                Destroy(other.gameObject);
            }
        }
        Debug.Log("Exited");
    }
}
