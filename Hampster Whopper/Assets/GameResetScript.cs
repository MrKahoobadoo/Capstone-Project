using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResetScript : MonoBehaviour
{
    public HamsterScript hamsterScript;

    public hamburgerham Hamburgerham;

    public LoseText loseText;

    IEnumerator WaitAndDoSomething(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        // Do something here after the wait time has passed
    }

    void gameReset()
    {
        if (hamsterScript.gameWon == true)
        {

            StartCoroutine(Restart(3f));

        }

        if (loseText.gameOver == true)
        {

            StartCoroutine(Restart(3f));

        }

        if(hamsterScript.gameLose == true)
        {
            StartCoroutine(Restart(3f));
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

    private IEnumerator Restart(float timeSeconds)
    {
        yield return new WaitForSeconds(timeSeconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
