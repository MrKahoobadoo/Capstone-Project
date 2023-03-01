using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    public int clicksToPop;
    
    void OnMouseDown ()
    {
        clicksToPop -= 1;
        transform.localScale += new Vector3(0.075f, 0.075f, 0.075f);

        if (clicksToPop == 0)
        {
            Destroy(gameObject);
        }
        
    }
    
}
