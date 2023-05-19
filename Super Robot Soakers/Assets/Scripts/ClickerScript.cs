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

    public OSUGameScript OSUGameScript;

    public bool autoClicking;

    void Update()
    {
        if (!OSUGameScript.gameOver)
        {
            OnKeyClick();
        }
    }

    void OnKeyClick()
    {
        switch (color)
        {
            case ClickerColor.red:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    OSUGameScript.clickCount++;
                    audioSource.Play();
                    if (TriggerList.Count > 0)
                    {
                        float distance = Vector3.Distance(transform.position, TriggerList[0].transform.position);
                        Destroy(TriggerList[0].gameObject);
                        OSUGameScript.Hit(distance);
                    }
                    else
                    {
                        OSUGameScript.Miss();
                    }
                }
                break;

            case ClickerColor.green:
                if (Input.GetKeyDown(KeyCode.S))
                {
                    OSUGameScript.clickCount++;
                    audioSource.Play();
                    if (TriggerList.Count > 0)
                    {
                        float distance = Vector3.Distance(transform.position, TriggerList[0].transform.position);
                        Destroy(TriggerList[0].gameObject);
                        OSUGameScript.Hit(distance);
                    }
                    else
                    {
                        OSUGameScript.Miss();
                    }
                }
                break;

            case ClickerColor.blue:
                if (Input.GetKeyDown(KeyCode.Semicolon))
                {
                    OSUGameScript.clickCount++;
                    audioSource.Play();
                    if (TriggerList.Count > 0)
                    {
                        float distance = Vector3.Distance(transform.position, TriggerList[0].transform.position);
                        Destroy(TriggerList[0].gameObject);
                        OSUGameScript.Hit(distance);
                    }
                    else
                    {
                        OSUGameScript.Miss();
                    }
                }
                break;

            case ClickerColor.yellow:
                if (Input.GetKeyDown(KeyCode.Quote))
                {
                    OSUGameScript.clickCount++;
                    audioSource.Play();
                    if (TriggerList.Count > 0)
                    {
                        float distance = Vector3.Distance(transform.position, TriggerList[0].transform.position);
                        Destroy(TriggerList[0].gameObject);
                        OSUGameScript.Hit(distance);
                    }
                    else
                    {
                        OSUGameScript.Miss();
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
        float distance = Vector3.Distance(transform.position, other.transform.position);
        if(distance > 200)
        {
            OSUGameScript.Miss();
        }
        //OSUGameScript.circlesPassed++;
        TriggerList.Remove(other);
        Destroy(other.gameObject);
    }

}