using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform player;
    public Animator enemyAnimator;
    public LayerMask whatIsGround, whatIsPlayer, whatIsWall;


    //patrolling
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    public GameObject bossProjectile;


    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        walkPointSet = false;
        enemyAnimator = GetComponent<Animator>();

    }

    private void Patrolling()
    {
        if (!walkPointSet)
        {

            SearchWalkPoint();

        }
        else if (walkPointSet)
        {
            agent.SetDestination(new Vector3(walkPoint.x, transform.position.y, walkPoint.z));
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1.5f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomx = Random.Range(-walkPointRange, walkPointRange);
        

        walkPoint = new Vector3(transform.position.x + randomx, transform.position.y, transform.position.z + randomZ);
        //walkPointSet = true;
        if (Physics.Raycast(walkPoint, -transform.up, 10f, whatIsGround))
        {
            Debug.DrawRay(transform.position, walkPoint, Color.red);

            walkPointSet = true;
        }

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
            var attackSelection = Random.Range(1, 3);
            //Attack Code Here Shooting or anything else
            if (attackSelection == 1) { 
                enemyAnimator.SetTrigger("isAttacking"); 
            } else if (attackSelection == 2) {
                enemyAnimator.SetTrigger("isStomping");
                    }

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    public void EnemyProjectileSpawn()
    {
        Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 10f, ForceMode.Impulse);
        rb.AddForce(transform.up * 2f, ForceMode.Impulse);
    }

    public void BossProjectileSpawn()
    {
        Rigidbody rb = Instantiate(bossProjectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        //rb.AddForce(transform.forward * 10f, ForceMode.Impulse);
        //rb.AddForce(transform.up * 2f, ForceMode.Impulse);
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }


    // Update is called once per frame
    void Update()
    {
        //Check if in sight or Attack Range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
