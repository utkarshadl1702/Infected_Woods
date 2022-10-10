using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public int currentWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        SetWeaponActive();
    }
    void Update()
    {
        int previousWeapon = currentWeapon;

        ProcessKeyInput();
        ProcessScrollWheel();

        if (previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }

    private void ProcessScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeapon > transform.childCount - 2)//go back to 0 when we are at end
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeapon > transform.childCount - 2)//go back to 0 when we are at end
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }

        }
    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentWeapon = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            currentWeapon = 4;
        }
    }

    private void SetWeaponActive()
    {
        int WeaponIndex = 0;
        foreach (Transform weapon in transform)
        {
            if (WeaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            WeaponIndex++;
        }
    }

    // Update is called once per frame
}
