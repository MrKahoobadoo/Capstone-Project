using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResetScript : MonoBehaviour
{
    public HamsterScript hamsterScript;

    public hamburgerham Hamburgerham;

    IEnumerator WaitAndDoSomething(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        // Do something here after the wait time has passed
    }

    void sceneEnder()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void gameReset()
    {
        if (hamsterScript.gameWon == true)
        {
            
            Invoke("sceneEnder", 3f);
           
        }

        if (Hamburgerham.gameOver == true)
        {

            Invoke("sceneEnder", 3f);

        }

        if(hamsterScript.gameLose == true)
        {
            Invoke("sceneEnder", 3f);
        }
    }

    void Start()
    {
        Debug.Log("i do in fact exist");
    }

    void Update()
    {
        gameReset();
    }

}
