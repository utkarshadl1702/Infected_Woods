using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoUI : MonoBehaviour
{
    WeaponSwitcher weaponSwitcher;
    AmmoType ammoType;
    Ammo ammo;
    public TMP_Text shots;

    // Start is called before the first frame update
    void Start()
    {
        weaponSwitcher = FindObjectOfType<WeaponSwitcher>();
        ammo = FindObjectOfType<Ammo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponSwitcher.currentWeapon == 0)
        {
            shots.text = ammo.GetCurrentAmmo(AmmoType.SmallBullet1).ToString();
            if (ammo.GetCurrentAmmo(AmmoType.SmallBullet1) < 50)
            {
                shots.color = Color.red;
            }
            else
            {
                shots.color = Color.white;
            }


        }
        else if (weaponSwitcher.currentWeapon == 1)
        {

            shots.text = ammo.GetCurrentAmmo(AmmoType.BigBullet2).ToString();

            if (ammo.GetCurrentAmmo(AmmoType.BigBullet2) < 50)
            {
                shots.color = Color.red;
            }
            else
            {
                shots.color = Color.white;
            }

        }
        else if (weaponSwitcher.currentWeapon == 2)
        {

            shots.text = ammo.GetCurrentAmmo(AmmoType.ShotGun).ToString();

            if (ammo.GetCurrentAmmo(AmmoType.BigBullet2) < 10)
            {
                shots.color = Color.red;
            }
            else
            {
                shots.color = Color.white;
            }
        }
        else if (weaponSwitcher.currentWeapon == 3)
        {

            shots.text = ammo.GetCurrentAmmo(AmmoType.Rockets).ToString();

            if (ammo.GetCurrentAmmo(AmmoType.BigBullet2) < 5)
            {
                shots.color = Color.red;
            }
            else
            {
                shots.color = Color.white;
            }
        }
        else if (weaponSwitcher.currentWeapon == 4)
        {

            shots.text = ammo.GetCurrentAmmo(AmmoType.Sniper).ToString();
            if (ammo.GetCurrentAmmo(AmmoType.BigBullet2) < 5)
            {
                shots.color = Color.red;
            }
            else
            {
                shots.color = Color.white;
            }
        }
    }

}
