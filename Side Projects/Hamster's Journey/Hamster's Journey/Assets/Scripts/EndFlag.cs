using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag : MonoBehaviour
{
    public string nextSceneName;
    public bool lastLevel;

    public UIWinText uIWinText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uIWinText.gameIsWon = true;

            Invoke("SceneChanger", 3f);
        }
    }

    void SceneChanger()
    {
        if (lastLevel == true)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(nextSceneName);
        }  
    }
}
