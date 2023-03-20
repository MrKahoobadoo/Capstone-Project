using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    public RealPlayerController realPlayerController;

    public TextMeshProUGUI healthText;

    // Update is called once per frame
    void Update()
    {
        updateHealthText();
    }

    void updateHealthText()
    {
        healthText.text = "Health: " + realPlayerController.curHp + "/" + realPlayerController.maxHp;
    }
}
