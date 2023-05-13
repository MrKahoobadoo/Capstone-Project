using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSUGameScript : MonoBehaviour
{
    public float songTempo; // tempo in beats per minute
    public float frequency; // circles per beat or something like that idk
    private float secondsBetweenBeat; // amount of time in seconds between each beat
    private float startingHeight; // the height that the circle will spawn at
    public float travelSpeed; // the speed that the circle will travel at

    public float startOffset;

    public int preLayers;

    //references
    public GameObject movingCircle;
    public GameObject canvasVisualElements;
    public AudioSource audioSource;

    void Start()
    {
        // figures out time interval for circle instantiation
        secondsBetweenBeat = (60 / songTempo) / frequency; // determines exact time offset between spawning circles by taking the bpm and frequency (circles per beat)
        startingHeight = secondsBetweenBeat * travelSpeed - 217; // determines the height the circle needs to spawn at by multiplying the speed it is travelling at and the time it needs to get to the clicker spot
        startingHeight += (secondsBetweenBeat * travelSpeed) * preLayers;

        Debug.Log(startingHeight);

        Invoke("StartSong", startOffset + secondsBetweenBeat + (preLayers) * secondsBetweenBeat);
        InvokeRepeating("SpawnCircle", startOffset, secondsBetweenBeat); // repeatedly spawns circles with these parameters

    }

    void SpawnCircle()
    {
        Instantiate(movingCircle, canvasVisualElements.transform.position + new Vector3(0, startingHeight, 0), Quaternion.identity, canvasVisualElements.transform);
    }

    void StartSong()
    {
        audioSource.Play();
    }
    
}
