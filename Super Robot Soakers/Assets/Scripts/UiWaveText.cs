using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiWaveText : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI waveText;

    void Update()
    {
        updateWaveText();
    }

    void updateWaveText()
    {
        waveText.text = "Wave " + gameManager.currentWave;
    }
}
