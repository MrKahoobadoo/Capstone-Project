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
    // basic score management
    public float score;
    public float streak;
    public float multiplier;
    public float multiplierIncrement;

    // percentage of circles hit
    public int circlesHit;
    public int circlesPassed;
    public float accuracy;

    [Header("Circles")]
    public GameObject redCircle;
    public GameObject greenCircle;
    public GameObject blueCircle;
    public GameObject yellowCircle;

    private bool redInst;
    private bool greenInst;
    private bool blueInst;
    private bool yellowInst;

    [Header("References")]
    public GameObject canvasVisualElements;
    public AudioSource audioSource;

    [Header("other")]
    public bool musicPlaying;
    public float songLength;
    public bool menuOpen;

    void Start()
    {
        // figures out time interval for circle instantiation
        secondsBetweenBeat = (60f / songTempo) / frequency; // determines exact time offset between spawning circles by taking the bpm and frequency (circles per beat)
        startingDistance = secondsBetweenBeat * travelSpeed; // determines distance the circle must travel given the time it needs to take and the speed it is travelling at
        startingDistance += (startingDistance) * preLayers; // adds more distance that it needs to travel from depending on how many prelayers you wish to have

        startingHeight = startingDistance; // adds -217 offset due to clicker rack position

        preDelay = startingDistance / travelSpeed; // determines amount of time in total that the song must wait to play in order to allow circles to reach clicker rack at exact time

        InvokeRepeating("CircleSpawner", startOffset, secondsBetweenBeat); // repeatedly spawns circles with these parameters
        Invoke("StartSong", startOffset + preDelay); // starts song after predelay

    }

    // circle spawning and musicplaying functions
    void SpawnRed()
    {
        Instantiate(redCircle, canvasVisualElements.transform.position + new Vector3(0, startingHeight - 400, 0), Quaternion.identity, canvasVisualElements.transform);
        redInst = true;
    }
    void SpawnGreen()
    {
        Instantiate(greenCircle, canvasVisualElements.transform.position + new Vector3(0, startingHeight - 400, 0), Quaternion.identity, canvasVisualElements.transform);
        greenInst = true;
    }
    void SpawnBlue()
    {
        Instantiate(blueCircle, canvasVisualElements.transform.position + new Vector3(0, startingHeight - 400, 0), Quaternion.identity, canvasVisualElements.transform);
        blueInst = true;
    }
    void SpawnYellow()
    {
        Instantiate(yellowCircle, canvasVisualElements.transform.position + new Vector3(0, startingHeight - 400, 0), Quaternion.identity, canvasVisualElements.transform);
        yellowInst = true;
    }

    void CircleSpawner()
    {
        // determines circle count with percentage chance
        int circleChance = Random.Range(0, 100);
        int circleCount;

        if (circleChance < 70)
        {
            circleCount = 1;
        }
        else if (circleChance < 85)
        {
            circleCount = 2;
        }
        else if (circleChance < 95)
        {
            circleCount = 3;
        }
        else
        {
            circleCount = 4;
        }

        // loops spawning and checking functions circleCount times
        for (int i = 0; i < circleCount; i++)
        {
            bool isFinished = false;

            while (!isFinished)
            {
                int whichCircle = Random.Range(0, 4);

                switch (whichCircle)
                {
                    case 0:
                        if (!redInst)
                        {
                            SpawnRed();
                            isFinished = true;
                        }
                        break;
                    case 1:
                        if (!greenInst)
                        {
                            SpawnGreen();
                            isFinished = true;
                        }
                        break;
                    case 2:
                        if (!blueInst)
                        {
                            SpawnBlue();
                            isFinished = true;
                        }
                        break;
                    case 3:
                        if (!yellowInst)
                        {
                            SpawnYellow();
                            isFinished = true;
                        }
                        break;
                }
            }
        }

        redInst = false;
        greenInst = false;
        blueInst = false;
        yellowInst = false;
    }

    /*// functions to be used in the Invoke statements
    void CircleSpawner()
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
    }*/

    void StartSong()
    {
        audioSource.Play();
        musicPlaying = true;
    }
    // =============================================

    public void Hit(float distance)
    {
        // score
        float scoreToAdd = (200 - distance) / 200;
        score += scoreToAdd * multiplier;
        multiplier += multiplierIncrement;

        // accuracy
        streak++;
        circlesHit++;
        circlesPassed++;
        accuracy = circlesHit / circlesPassed;
    }

    public void Miss()
    {
        // score
        multiplier = 0;

        // accuracy
        streak = 0;
        circlesPassed++;
        accuracy = circlesHit / circlesPassed;
    }

    void Lose()
    {
        if (accuracy < 0.5)
        {

        }
    }

    void Finish()
    {
        if (!audioSource.isPlaying && !menuOpen)
        {

        }
    }
}