using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class woohoo : MonoBehaviour
{

    public int score;
    public TextMeshProUGUI scoreText;

    public AudioClip myClip;
    public AudioSource audioSource;

    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = myClip;
        
        updateScoreText();

    }

    public void increaseScore (int amount)
    {
        score += amount;
        updateScoreText();
    }

    void Quit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    void updateScoreText ()
    {
        scoreText.text = "Hampsters Popped: " + score;
        
        if(score != 0)
        {
            audioSource.PlayOneShot(myClip);
        }
        
    }

    IEnumerator WaitAndDoSomething(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

    // Update is called once per frame
    void Update()
    {
        Quit();
    }
    
}
