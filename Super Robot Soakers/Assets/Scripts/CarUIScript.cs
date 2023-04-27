using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarUIScript : MonoBehaviour
{
    
    
    [Header("Normal Screen")]
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiplierText;
    public TextMeshProUGUI timeText;

    public GameManagerCar gameManagerCar;
    public Rigidbody carRig;
    public CarScript carScript;

    // Update is called once per frame
    void Update()
    {
        updateNormalScreen();
    }

    void updateNormalScreen()
    {
        // damage
        damageText.text = "Damage: " + gameManagerCar.damageLevel + "/3";

        // speed
        int speedMPH = (int)Mathf.Floor(carRig.velocity.magnitude * 2.23694f);
        speedText.text = "Speed: " + speedMPH;

        // score
        scoreText.text = "Score: " + gameManagerCar.score;

        // multiplier
        multiplierText.text = "" + gameManagerCar.multiplier;

        // time
        

    }

}
