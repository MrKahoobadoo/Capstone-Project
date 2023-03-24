using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthText : MonoBehaviour
{
    public RealPlayerController realPlayerController;
    public TextMeshProUGUI healthText;
    public Slider slider;

    private float curHP;
    private float maxHP;
    private float healthRatio;

    // Update is called once per frame
    void Update()
    {
        updateHealthText();
    }

    void updateHealthText()
    {
        healthText.text = realPlayerController.curHp + "/" + realPlayerController.maxHp;
        healthRatio = (realPlayerController.curHp / (realPlayerController.maxHp)f);
        slider.value = healthRatio * 280f;
        //slider.value = realPlayerController.curHp;
    }
}
