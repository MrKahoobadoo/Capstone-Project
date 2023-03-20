using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoScript : MonoBehaviour
{
    public PlayerWeaponScript playerWeaponScript;

    public TextMeshProUGUI ammoText;

    // Update is called once per frame
    void Update()
    {
        updateAmmoText();
    }

    void updateAmmoText()
    {
        ammoText.text = "Ammo: " + playerWeaponScript.curAmmo + "/" + playerWeaponScript.maxAmmo;
    }
}
