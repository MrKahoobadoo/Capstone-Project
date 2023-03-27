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
    public Image movingBar;

    private float curHP;
    private float maxHP;
    private float healthRatio;

    private Color newColor = new Color(0f, 1f, 0f);

    void Start()
    {
        curHP = realPlayerController.curHp;
        maxHP = realPlayerController.maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        updateHealthText();
    }

    void updateHealthText()
    {
        curHP = realPlayerController.curHp;
        maxHP = realPlayerController.maxHp;
        healthText.text = curHP + "/" + maxHP;
        healthRatio = (curHP / maxHP);
        slider.value = healthRatio * 280f;

        if(curHP >= 50)
        {
            newColor = new Color(2f * (1f - healthRatio), 1f, 0f);
        }
        else
        {
            newColor = new Color(1f, healthRatio * 2f, 0f);
        }
        
        movingBar.color = newColor;
    }
}
