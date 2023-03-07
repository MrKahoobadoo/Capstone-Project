using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class uicontroll : MonoBehaviour
{

    public TextMeshProUGUI myText;

    public woohoo woohoo;

    // Start is called before the first frame update
    void Start()
    {

        myText.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(woohoo.score == 100)
        {
            myText.enabled = true;
        }
    }
}
