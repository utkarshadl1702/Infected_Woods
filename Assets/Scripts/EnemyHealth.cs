using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isdead = false;

    public bool Isdead() { return isdead; }
    public void TakeDamage(float damage)
    {
        //could do this
        // GetComponent<EnemyAI>().OnDamageTaken();
        BroadcastMessage("OnDamageTaken");//can call any function on that particular gameobject


        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            // Destroy(gameObject);
            EnemyDead();

        }

    }

    private void EnemyDead()
    {
        if (isdead)
        {
            return;//we are doing this so that when we shoot enemy again it doesnt play animation again
        }
        isdead = true;
        GetComponent<Animator>().SetTrigger("dead");
    }
}

