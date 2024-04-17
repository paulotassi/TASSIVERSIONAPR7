using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyQDSpawner : MonoBehaviour
{
    public float ct = 0f;
    public GameObject prefabSpawn;
    public GameObject SpawnLocation;
    // Update is called once per frame
    void Update()
    {
        ct += Time.deltaTime;
        if (ct > 2f)
        {
        
            Instantiate(prefabSpawn, SpawnLocation.transform.position, Quaternion.identity);
            ct = 0f;
         
        }
    }
}
