using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    EnemyHealth health;



    float turnSpeed = 5f;
    NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<EnemyHealth>();
        // enemyAttack=FindObjectOfType<EnemyAttack>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    void Update()
    {
        if (health.Isdead())
        {
            this.enabled = false;
            navMeshAgent.enabled = false;
        }
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }
    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)//stopping distance is in navmesh properties
        {
            ChaseTarget();

        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance + 0.5f)
        {
            AttackTarget();
        }

    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void ChaseTarget()
    {

        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        if (!health.Isdead())
        {
            navMeshAgent.SetDestination(target.position);

        }
    }
    private void AttackTarget()
    {
        Debug.Log("Enemy attacks");
        // enemyAttack.AttackHitEvent();
        // GetComponent<Animator>().SetBool("attack",true); for booleans
        GetComponent<Animator>().SetBool("attack", true);

    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
}
