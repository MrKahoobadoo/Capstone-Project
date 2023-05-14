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

    [Header("Scoring")]
    public int score;
    public float multiplier;
   

    [Header("References")]
    public GameObject movingCircle;
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
        Instantiate(movingCircle, canvasVisualElements.transform.position + new Vector3(0, startingHeight - 400, 0), Quaternion.identity, canvasVisualElements.transform);
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
