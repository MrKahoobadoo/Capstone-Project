using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coolnewoneanother : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LogToConsole();
        Debug.Log(Add(4.3f, 6.3434324f));
    }

    void LogToConsole()
    {
        Debug.Log("Function has been Called!");
    }

    float Add (float a, float b)
    {
        float sum = a + b;
        return sum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
