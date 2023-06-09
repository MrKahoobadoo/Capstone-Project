using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicScript : MonoBehaviour
{
    public Scene currentScene;
    // Start is called before the first frame update
    void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Jukebox");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        
    }

    void Update()
    {
        currentScene = SceneManager.GetActiveScene();

        if (currentScene.buildIndex != 2)
        {
            Destroy(gameObject);
        }
    }
}
