using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;
    Ammo ammo;

    private void Start()
    {
        ammo = FindObjectOfType<Ammo>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Debug.Log("Pickup Taken");
            Destroy(gameObject);
            ammo.IncreaseAmmo(ammoAmount, ammoType);
        }

    }
}
