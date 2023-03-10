using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFullscreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = true;
    }

    void OnApplicationQuit()
    {
        Screen.fullScreen = false;
    }
}
