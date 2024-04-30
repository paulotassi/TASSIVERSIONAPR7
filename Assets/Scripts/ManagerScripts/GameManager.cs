using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [SerializeField] public AnimationManager animationManager;
    [SerializeField] public AudioManager audioManager;
    [SerializeField] public PowerUpSpawner spawner;
    [SerializeField] public InputManager inputManager;
    [SerializeField] public LightingManager lightingManager;
    [SerializeField] public SaveManager saveManager;
    [SerializeField] public UIManager uiManager;
    [SerializeField] public ScenesManager scenesManager;
    public int waveNum = 1;
    [SerializeField] public bool waveIncrease = false;
    [SerializeField] public int killCount;
    [SerializeField] public TMP_Text scoreText;
    [SerializeField] public TMP_Text waveText;

    [SerializeField] public int enemiesAlive = 0;

    private void Awake()
    {
        waveNum = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("EnemySpawner").GetComponent<PowerUpSpawner>();
        killCount = 0;
        waveNum = 1;
        scoreText.text = "Bounties: " + killCount;

        waveText.text = "Wave: " + waveNum;
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Bounties: " + killCount;
        waveText.text = "Wave: " + waveNum;
        if (enemiesAlive - 1 == 0)
        {
            waveNum++;
            spawner.SpawnEnemies();
        }
  
    }
    public void AddEnemy()
    {
        enemiesAlive++;
        //Debug.Log("Enemies" + (enemiesAlive - 1));
    }
    public void RemoveEnemy()
    {
        enemiesAlive--;
        //Debug.Log("Enemies" + enemiesAlive);
    }

}
