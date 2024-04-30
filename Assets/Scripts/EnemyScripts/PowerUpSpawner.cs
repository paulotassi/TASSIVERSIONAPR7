using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public float ct = 0f;
    [SerializeField] private int randomSpawnNum = 0;
    [SerializeField] private int randomSpawnLocation = 0;
    [SerializeField] private float randomSpawnTime = 0f;
    [SerializeField] private bool spawnSwitch = true;
    [SerializeField] public int waveNumDesignation = 1;
    [SerializeField] public GameManager manager;
    public GameObject PowerUpVariety;
    public Transform[] spawnLocations;
    // Update is called once per frame

    private void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        waveNumDesignation = manager.waveNum * 5;
    }
    private void Start()
    {
        SpawnEnemies();
    }
    void Update()
    {
        randomSpawnTime = Random.Range(1, 1.1f);
        randomSpawnLocation = Random.Range(0, 4);
        ct += Time.deltaTime;
       
    }
    public void SpawnEnemies()
    {
         waveNumDesignation = (manager.waveNum*5);
        randomSpawnNum = Random.Range(4, 5);
        for (int i = 0; i < waveNumDesignation; i++)
        {
            randomSpawnLocation = Random.Range(0, 4);
            Instantiate(PowerUpVariety, new Vector3(spawnLocations[randomSpawnLocation].transform.position.x + randomSpawnNum, spawnLocations[randomSpawnLocation].transform.position.y, spawnLocations[randomSpawnLocation].transform.position.z + randomSpawnNum), Quaternion.identity);
        }
    }
}
