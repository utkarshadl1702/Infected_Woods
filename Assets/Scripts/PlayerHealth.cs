using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float Hitpoints = 100f;
    DeathHandler deathHandler;

    float currentHealth;
    // [SerializeField]float damage = 20f;
    // Start is called before the first frame update
    void Start()
    {
        deathHandler = FindObjectOfType<DeathHandler>();
    }
    
    // Update is called once per frame
    void Update()
    {
        currentHealth=Hitpoints;
    }

    public float retHealth()
    {
        return currentHealth;
    }

    public void TakeDamage(float damage)
    {
        Hitpoints-=damage;
        if (Hitpoints<=0)
        {
            Debug.Log("Player is dead");
            deathHandler.HandleDeath();
        }

    } 
}
