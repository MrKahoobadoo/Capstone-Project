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

    public AudioSource audioSource;

    public bool autoClicking;

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
        TriggerList.Add(other);
        
        /*Destroy(TriggerList[0]);
        audioSource.Play();
        Debug.Log("Hit");*/
        //UNCOMMENT AND MOVE COLLIDERS DOWN 200 UNITS TO ENABLED AUTO CLICKING FOR TIMING FIXES
    }

    void OnTriggerExit2D(Collider2D other)
    {
        TriggerList.Remove(other);
        Destroy(other.gameObject);
        //OSUGameScript.FailedClick();
    }

}