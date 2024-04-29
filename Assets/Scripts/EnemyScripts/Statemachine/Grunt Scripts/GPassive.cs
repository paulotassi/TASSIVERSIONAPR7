using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class GPassive : EnemyStateBase
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 position;

    //help from ChatGPT on the patrol points
    [SerializeField] private int patrolPoints;
    [SerializeField] private Transform[] patrolPointslocations;
    [SerializeField] private int currentPatrolIndex = 0;

    public Grunt grunt;

    public override void OnActivate()
    {
        Debug.Log("Grunt is passive");
    }

    private void Start()
    {
        patrolPoints = 3;
        patrolPointslocations = new Transform[patrolPoints];
        patrolGeneration();

    }

    private void patrolGeneration()
    {
        for (int i =0; i<patrolPoints; i++)
        {
            GameObject patrolPointObj = new GameObject("PatrolPoint " + i);
            patrolPointObj.transform.position = new Vector3(i * Random.Range(0, 10), 0, i* Random.Range(0, 10));

            patrolPointslocations[i] = patrolPointObj.transform;
        }
    }

    private void Update()
    {
        position = transform.position;
        speed = 2f * Time.deltaTime;
        walking(speed);
        search();
    }

    private void search()
    {
       Collider[] hitcolliders = Physics.OverlapSphere(position, 10);
        foreach (Collider collider in hitcolliders)
        {
            if (collider.GetComponent<PlayerController>() != null)
            {
                grunt.ChangeState(Grunt.GSEnum.Aggro);
                OnDeactivate();    
            }
        }
    }

    private void walking(float spd)
    {


       transform.position = Vector3.MoveTowards(transform.position, patrolPointslocations[currentPatrolIndex].position, spd);
       if (Vector3.Distance(transform.position, patrolPointslocations[currentPatrolIndex].position) < 2f) 
       {
            currentPatrolIndex = currentPatrolIndex + 1;
            Debug.Log("Reached tarGET");
            if (currentPatrolIndex >= patrolPointslocations.Length)
            {
                currentPatrolIndex = 0;
            }
       }
    }
    public override void OnDeactivate()
    {
        Debug.Log("Grunt is no longer passive");
        Array.Clear(patrolPointslocations, 0, patrolPointslocations.Length);
    }
}
