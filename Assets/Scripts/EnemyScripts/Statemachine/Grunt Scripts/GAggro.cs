using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GAggro : EnemyStateBase
{
    //object refrences
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    //attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //other stuff
    public float attackRange;
    public bool playerInAttackRange;

    public override void OnActivate()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        Debug.Log("Grunt is Aggressive");
        ChasePlayer();
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesnt move
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //Attack Code Here Shooting or anything else
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 15f, ForceMode.Impulse);
            rb.AddForce(transform.up * 2f, ForceMode.Impulse);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void Update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!playerInAttackRange) ChasePlayer();
        if (playerInAttackRange) AttackPlayer();
    }

    public override void OnDeactivate()
    {
        Debug.Log("Grunt is no longer Aggressive");
    }
}
