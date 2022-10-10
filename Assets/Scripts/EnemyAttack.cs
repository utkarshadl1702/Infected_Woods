using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 10f;
    // PlayerHealth playerHealth;
    void Start()
    {
        // playerHealth = GetComponent<PlayerHealth>();
        target = FindObjectOfType<PlayerHealth>();
    }


    public void AttackHitEvent()
    {
        if (target == null)
        {
            return;
        }
        Debug.Log("It hit");

        target.TakeDamage(damage);


    }
}
