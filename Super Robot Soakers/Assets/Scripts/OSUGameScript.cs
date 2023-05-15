using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSUGameScript : MonoBehaviour
{
    [Header("Circle Movement and Timing")]
    public float songTempo; // tempo in beats per minute
    public float frequency; // circles per beat or something like that idk
    private float secondsBetweenBeat; // amount of time in seconds between each beat
    private float startingDistance; // the height the circle needs to start at
    private float startingHeight; // the height that the circle will spawn at (with offset accounted for)
    public float travelSpeed; // the speed that the circle will travel at
    public float startOffset; // time before teh game starts
    public float preLayers; // number of circles that should spawn in addition to the current one
    private float preDelay; // uyeah
    public int multiChance;

    [Header("Scoring")]
    public int score;
    public float multiplier;

    [Header("Circles")]
    public GameObject redCircle;
    public GameObject greenCircle;
    public GameObject blueCircle;
    public GameObject yellowCircle;

    [Header("References")]
    public GameObject canvasVisualElements;
    public AudioSource audioSource;

    void Start()
    {
        // figures out time interval for circle instantiation
        secondsBetweenBeat = (60f / songTempo) / frequency; // determines exact time offset between spawning circles by taking the bpm and frequency (circles per beat)
        startingDistance = secondsBetweenBeat * travelSpeed; // determines distance the circle must travel given the time it needs to take and the speed it is travelling at
        startingDistance += (startingDistance) * preLayers; // adds more distance that it needs to travel from depending on how many prelayers you wish to have

        startingHeight = startingDistance; // adds -217 offset due to clicker rack position

        preDelay = startingDistance / travelSpeed; // determines amount of time in total that the song must wait to play in order to allow circles to reach clicker rack at exact time

        InvokeRepeating("SpawnCircle", startOffset, secondsBetweenBeat); // repeatedly spawns circles with these parameters
        Invoke("StartSong", startOffset + preDelay); // starts song after predelay

    }

    // functions to be used in the Invoke statements
    void SpawnCircle()
    {
        
        int colorChoice = Random.Range(0, 4);

        switch (colorChoice)
        {
            case 0:
                Instantiate(redCircle, canvasVisualElements.transform.position + new Vector3(0, startingHeight - 400, 0), Quaternion.identity, canvasVisualElements.transform);
                break;
            case 1:
                Instantiate(greenCircle, canvasVisualElements.transform.position + new Vector3(0, startingHeight - 400, 0), Quaternion.identity, canvasVisualElements.transform);
                break;
            case 2:
                Instantiate(blueCircle, canvasVisualElements.transform.position + new Vector3(0, startingHeight - 400, 0), Quaternion.identity, canvasVisualElements.transform);
                break;
            case 3:
                Instantiate(yellowCircle, canvasVisualElements.transform.position + new Vector3(0, startingHeight - 400, 0), Quaternion.identity, canvasVisualElements.transform);
                break;
        }

        int chancer = Random.Range(0, 100);

        switch (chancer)
        {
            case < 60:
                break;

            case < 80:
                bool isDifferent = false;
                int subColorChoice = 0;

                while (isDifferent)
                {
                    subColorChoice = Random.Range(0, 4);
                    if (subColorChoice != colorChoice)
                    {
                        isDifferent = true;
                    }
                }

                switch (subColorChoice)
                {
                    case 0:
                        Instantiate(redCircle, canvasVisualElements.transform.position + new Vector3(0, startingHeight - 400, 0), Quaternion.identity, canvasVisualElements.transform);
                        break;
                    case 1:
                        Instantiate(greenCircle, canvasVisualElements.transform.position + new Vector3(0, startingHeight - 400, 0), Quaternion.identity, canvasVisualElements.transform);
                        break;
                    case 2:
                        Instantiate(blueCircle, canvasVisualElements.transform.position + new Vector3(0, startingHeight - 400, 0), Quaternion.identity, canvasVisualElements.transform);
                        break;
                    case 3:
                        Instantiate(yellowCircle, canvasVisualElements.transform.position + new Vector3(0, startingHeight - 400, 0), Quaternion.identity, canvasVisualElements.transform);
                        break;
                }
                break;

            case < 95:
                int isDifferentEnough = 0;
                int subColorChoice1 = 0;
                int subColorChoice2 = 0;

                while (isDifferentEnough < 1)
                {
                    subColorChoice1 = Random.Range(0, 4);
                    if (subColorChoice1 != colorChoice)
                    {
                        isDifferentEnough++;
                    }
                }

                while (isDifferentEnough < 1)
                {
                    subColorChoice2 = Random.Range(0, 4);
                    if (subColorChoice2 != colorChoice && subColorChoice2 != subColorChoice1)
                    {
                        isDifferentEnough++;
                    }
                }

                switch (subColorChoice1)
                {
                    case 0:
                        Instantiate(redCircle, canvasVisualElements.transform.position + new Vector3(0, startingHeight - 400, 0), Quaternion.identity, canvasVisualElements.transform);
                        break;
                    case 1:
                        Instantiate(greenCircle, canvasVisualElements.transform.position + new Vector3(0, startingHeight - 400, 0), Quaternion.identity, canvasVisualElements.transform);
                        break;
                    case 2:
                        Instantiate(blueCircle, canvasVisualElements.transform.position + new Vector3(0, startingHeight - 400, 0), Quaternion.identity, canvasVisualElements.transform);
                        break;
                    case 3:
                        Instantiate(yellowCircle, canvasVisualElements.transform.position + new Vector3(0, startingHeight - 400, 0), Quaternion.identity, canvasVisualElements.transform);
                        break;
                }

                switch (subColorChoice2)
                {
                    case 0:
                        Instantiate(redCircle, canvasVisualElements.transform.position + new Vector3(0, startingHeight - 400, 0), Quaternion.identity, canvasVisualElements.transform);
                        break;
                    case 1:
                        Instantiate(greenCircle, canvasVisualElements.transform.position + new Vector3(0, startingHeight - 400, 0), Quaternion.identity, canvasVisualElements.transform);
                        break;
                    case 2:
                        Instantiate(blueCircle, canvasVisualElements.transform.position + new Vector3(0, startingHeight - 400, 0), Quaternion.identity, canvasVisualElements.transform);
                        break;
                    case 3:
                        Instantiate(yellowCircle, canvasVisualElements.transform.position + new Vector3(0, startingHeight - 400, 0), Quaternion.identity, canvasVisualElements.transform);
                        break;
                }
                break;

            case < 100:
                Instantiate(redCircle, canvasVisualElements.transform.position + new Vector3(0, startingHeight - 400, 0), Quaternion.identity, canvasVisualElements.transform);
                Instantiate(greenCircle, canvasVisualElements.transform.position + new Vector3(0, startingHeight - 400, 0), Quaternion.identity, canvasVisualElements.transform);
                Instantiate(blueCircle, canvasVisualElements.transform.position + new Vector3(0, startingHeight - 400, 0), Quaternion.identity, canvasVisualElements.transform);
                Instantiate(yellowCircle, canvasVisualElements.transform.position + new Vector3(0, startingHeight - 400, 0), Quaternion.identity, canvasVisualElements.transform);
                break;
        }
    }

    void StartSong()
    {
        audioSource.Play();
    }
    // =============================================

    public void SuccessfulClick(float distance)
    {

    }
}
