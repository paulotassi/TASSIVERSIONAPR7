using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public float ct = 0f;
    [SerializeField] private int randomSpawnNum = 0;
    [SerializeField] private int randomSpawnLocation = 0;
    [SerializeField] private float randomSpawnTime = 0f;
    public GameObject PowerUpVariety;
    public Transform[] spawnLocations;
    // Update is called once per frame
    void Update()
    {
        randomSpawnTime = Random.Range(1, 1.1f);
        randomSpawnLocation = Random.Range(0, 4);
        ct += Time.deltaTime;
        if (ct > randomSpawnTime)
        {
            randomSpawnNum = Random.Range(4, 5);
           
            Instantiate(PowerUpVariety, new Vector3(spawnLocations[randomSpawnLocation].transform.position.x + randomSpawnNum, spawnLocations[randomSpawnLocation].transform.position.y, spawnLocations[randomSpawnLocation].transform.position.z + randomSpawnNum), Quaternion.identity);
            
            ct = 0f;
            Debug.Log(randomSpawnLocation);
        }
        
    }
}
