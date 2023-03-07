using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Beans : MonoBehaviour
{

    public woohoo woohoo;

    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (woohoo.score == 100)
        {
            image.enabled = true;
        }
    }
}
